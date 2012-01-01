using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using elfam.web.Dao;
using elfam.web.Models;
using elfam.web.Services.Results;
using elfam.web.Utils;
using elfam.web.ViewModels;
using Microsoft.Practices.Unity;

namespace elfam.web.Services
{
    public class OrderService
    {
        private IDaoTemplate _daoTemplate;

        [Dependency]
        public IDaoTemplate DaoTemplate
        {
            set { _daoTemplate = value; }
        }

        public AddOrderResult AddOrder(Cart cart, User user, OrderShippingInfo orderInfo)
        {

            if (cart == null)
                throw new ArgumentException("cart is null");
            if (cart.Items == null)
                throw new ArgumentException("cart items is null");
            if (user == null)
                throw new ArgumentException("user is null");
            if (orderInfo == null)
                throw new ArgumentException("orderInfo is null");


            // construct order
            var orderLines = new List<OrderLine>();
            var orderOutcomes = new List<Outcome>();
            foreach (CartItem item in cart.Items)
            {
                IList<Income> incomes = FindOldestIncomesForProduct(item.Product, item.Quantity);
                int quantity = item.Quantity;
                var outcomes = new List<Outcome>();
                foreach (Income income in incomes)
                {
                    int n = Math.Min(quantity, income.QuantityCurrent);
                    income.QuantityCurrent -= n;
                    _daoTemplate.Save(income);
                    Outcome outcome = new Outcome(item.Product.Price, n, income, user.Discount + cart.CurrentDiscount());
                    quantity -= n;
                    outcomes.Add(outcome);
                }
                orderOutcomes.AddRange(outcomes);
                orderLines.Add(new OrderLine(item.Product, item.Quantity, outcomes));
            }
            Order order = new Order(orderOutcomes, orderLines);
            order.Comment = orderInfo.Comment ?? "";
            DeliverPrices prices = _daoTemplate.FindAll<DeliverPrices>()[0];
            if (orderInfo.PaymentType == PaymentType.OnPost)
            {
                order.DeliverPrice = prices.PostWhenReceived(cart.SummDiscount());
            }
            else
            {
                order.DeliverPrice = GetPrice(orderInfo.DeliverType);
            }
            order.CopyFrom(orderInfo);
            order.User = user;
            order.Discount = user.Discount + cart.CurrentDiscount();
            _daoTemplate.Save(order);
            order.Uid = _daoTemplate.FindByID<UniqueId>(order.Id).Uid;
            _daoTemplate.Save(order);

            
            return new AddOrderResult(){Order = order};
        }

        public decimal GetPrice(DeliverType deliverType)
        {
            DeliverPrices prices = _daoTemplate.FindAll<DeliverPrices>()[0];
            if (deliverType == DeliverType.CourierMoscow)
                return prices.CourierMoscow;
            if (deliverType == DeliverType.CourierSubMoscow)
                return prices.CourierSubMoscow;
            if (deliverType == DeliverType.Post)
                return prices.Post;
            //if (deliverType == DeliverType.Myself)
            return prices.Self;
        }

        public void RevertOrder(Order order)
        {
            IEnumerable<Outcome> outcomes = order.Outcomes();
            foreach (Outcome outcome in outcomes)
            {
                outcome.Income.QuantityCurrent += outcome.Quantity;
            }
            order.ClearOutcomes();
            order.Status = OrderStatus.Revoked;
        }

        public IList<Income> FindOldestIncomesForProduct(Product product, int quantity)
        {
            product = _daoTemplate.FindByID<Product>(product.Id);
            List<Income> result = new List<Income>();
            foreach (Income income in product.Incomes.OrderBy(x => x.Date))
            {
                if (income.QuantityCurrent == 0)
                {
                    continue;
                }
                result.Add(income);
                quantity -= Math.Min(income.QuantityCurrent, quantity);
                if (quantity == 0)
                {
                    break;
                }
            }
            if (quantity > 0)
            {
                // not enough products in stock
            }
            return result;
        }

        public void UpdateUserDicount(User user, ControllerContext context)
        {
            var summ = user.Summ();
            if (summ >= 10000)
            {
                user.Discount = 10;
                string message = MailService.RenderViewToString("~/Views/MailTemplates/Discount.aspx", user, context);
                MailService.Send("Elfam.ru - Уведомление", message, user.Email);
            } 
            _daoTemplate.Save(user);
        }

        public void NotifyUser(Order order, ControllerContext context)
        {
            string message = MailService.RenderViewToString("~/Views/MailTemplates/OrderStatusChanged.aspx", order, context);
            MailService.Send("Elfam.ru - Уведомление", message, order.User.Email);
        }


    }
}

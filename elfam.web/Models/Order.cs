using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using elfam.web.ViewModels;
using NHibernate.Criterion;

namespace elfam.web.Models
{
    public class Order: DomainEntity
    {
        public static string UidProperty = "Uid";
        public static string UserProperty = "User";

        public virtual User User { get; set; }
        public virtual OrderStatus Status { get; set; }
        // public virtual IList OrderStatusHistory { get; set; } 
        public virtual PaymentType PaymentType { get; set; }
        public virtual DeliverType DeliverType { get; set; }
        public virtual Decimal DeliverPrice { get; set; }
        public virtual Contact ShippingDetails { get; set; }
        public virtual IList<OrderLine> Lines { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual int Uid { get; set; }
        public virtual int Discount { get; set; }
        public virtual string Comment { get; set; }

        public static IList<OrderStatus> ProfitStatuses
        {
            get { return new List<OrderStatus>(){OrderStatus.Delivered, OrderStatus.Payed, OrderStatus.Sent};}
        }

//        public virtual IList<Outcome> Outcomes { get; set; }
        


        protected Order()
        {
            ShippingDetails = new Contact();
            Lines = new List<OrderLine>();
            Date = DateTime.Now;
//            Outcomes = new List<Outcome>();
            Status = OrderStatus.WaitPayment;
            Comment = "";
        }

        public Order(IEnumerable<Outcome> outcomes, List<OrderLine> orderLines): this()
        {
            Lines = orderLines;
            orderLines.ForEach(ol => ol.Order = this);

            Summ = outcomes.Sum(o => o.Summ);
            SummWithDiscount = outcomes.Sum(o => o.SummWithDiscount);
            Profit = outcomes.Sum(o => o.Profit);
            DiscountSumm = outcomes.Sum(o => o.DiscountSumm);
        }


        public virtual OrderLine AddOrderLine(Product product, int quantity, List<Outcome> outcomes)
        {
            OrderLine orderLine = new OrderLine(product, quantity, outcomes);
            orderLine.Price = product.Price;
            orderLine.ProductName = product.Name;

            Lines.Add(orderLine);
            return orderLine;
        }

        public virtual IEnumerable<Outcome> Outcomes()
        {
            return Lines.SelectMany(orderLine => orderLine.Outcomes);
        }

        public virtual decimal Summ { get; private set; }
//        public virtual decimal Summ()
//        {
//            return Outcomes().Sum(o => o.Summ);
//        }

        public virtual decimal SummWithDiscount { get; private set; }
//        public virtual decimal SummWithDiscount()
//        {
//            return Outcomes().Sum(o => o.SummWithDiscount);
//        }

        public virtual decimal Profit { get; private set; }
//        public virtual decimal Profit()
//        {
//            return Outcomes().Sum(o => o.Profit);
//        }


        public virtual void CopyFrom(OrderShippingInfo info)
        {
            DeliverType = info.DeliverType;
            PaymentType = info.PaymentType;
            ShippingDetails = info.Contact;
        }

        public virtual void ClearOutcomes()
        {
            foreach (OrderLine line in Lines)
            {
                line.Outcomes.Clear();
            }
        }

        public virtual decimal DiscountSumm { get; private set; }
//        public virtual decimal DiscountSumm()
//        {
//            return Outcomes().Sum(x => x.DiscountSumm);
//        }
        public virtual decimal Total()
        {
            return DeliverPrice + SummWithDiscount;
        }
    }
}

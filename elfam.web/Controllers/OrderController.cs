using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using elfam.web.Attributes;
using elfam.web.Exceptions;
using elfam.web.Models;
using elfam.web.Paging;
using elfam.web.Paging.Order;
using elfam.web.Services;
using elfam.web.ViewModels;
using elfam.web.ViewModels.Order;
using elfam.web.ViewModels.User;
using Microsoft.Practices.Unity;
using NHibernate.Criterion;
using Order = elfam.web.Models.Order;

namespace elfam.web.Controllers
{
    public class OrderController : BaseController
    {
        OrderService orderService;
        private MailService mailService;

        [Dependency]
        public MailService MailService
        {
            set { mailService = value; }
        }

        [Dependency]
        public OrderService OrderService
        {
            set { orderService = value; }
        }
        
        [Admin]
        public ActionResult Details(int id)
        {
            // id is hash
            var order = daoTemplate.FindOrderByUid(id);
            if (order == null)
                throw new NotFoundException();
            return View(order);
        }

        [Authorize]
        public ActionResult DetailsUser(int id)
        {
            var order = daoTemplate.FindOrderByUid(id);
            if (order == null)
                throw new NotFoundException();
            if (!order.User.Equals(CurrentUser()) && !CurrentUser().IsAdmin)
                throw new NotFoundException();
            return View(order);
        }

        [Admin]
        public ActionResult List(OrderListSearchCriteria criteria)
        {
            var queryBuilder = new OrderListQueryBuilder(criteria);
            var result = queryBuilder.Execute(daoTemplate.Session);
            return View(result);
        }

        [Admin]
        public ActionResult Revert(int id)
        {
            orderService.RevertOrder(daoTemplate.FindByID<Order>(id));
            return RedirectToAction("List");
        }
        
        [Authorize][HttpPost]
        public ActionResult RevertUser(int uid)
        {
            orderService.RevertOrder(daoTemplate.FindOrderByUid(uid));
            return RedirectToAction("MyOrders", "User");
        }

        [Authorize][HttpPost]
        public ActionResult Cancel(int uid)
        {
            //var uid = Request.Params["uid"];
            var order = daoTemplate.FindOrderByUid(uid);
            if (order.User.Id != CurrentUser().Id)
            {
                return Json(1);
            }
            order.Status = OrderStatus.Revoked;
            return Json(0);
        }

        [Admin]
        public ActionResult Update(int orderId, int status)
        {
            Order order = daoTemplate.FindByID<Order>(orderId);
            if (status == (int) OrderStatus.Revoked)
                return Revert(orderId);
            bool statusChanged = ((OrderStatus) status) != order.Status;
            order.Status = (OrderStatus) status;
            if (statusChanged)
            {
                if (order.Status == OrderStatus.Sent)
                {
                    var message = MailService.RenderViewToString("~/Views/MailTemplates/OrderSent.aspx", order, ControllerContext);
                    mailService.SendCcAdmins("Заказ отправлен - Elfam.ru", message, order.User.Email);
                }
                else if (order.Status == OrderStatus.WaitPickup)
                {
                    var message = MailService.RenderViewToString("~/Views/MailTemplates/OrderWaitPickup.aspx", order, ControllerContext);
                    mailService.SendCcAdmins("Заказ готов к самовывозу - Elfam.ru", message, order.User.Email);
                }
                
            }
                
            orderService.UpdateUserDicount(order.User, this.ControllerContext);
            daoTemplate.Save(order);
            return RedirectToAction("Details", new {Id = order.Uid});
        }

        public ActionResult Bill(int id)
        {
            var order = daoTemplate.FindOrderByUid(id);
            var model = new BillViewModel()
                            {
                                Price = order.SummWithDiscount + order.DeliverPrice,
                                Address = order.ShippingDetails.AddressBill(),
                                Uid = order.Uid,
                                UserName = order.ShippingDetails.FullName
                            };
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var order = daoTemplate.FindOrderByUid(id);
            return View(order);
        }
        
        [Authorize]
        [HttpPost]
        public ActionResult Edit(ContactViewModel contactViewModel, int uid, DeliverType DeliverType, PaymentType PaymentType)
        {
            if (!ModelState.IsValid || DeliverType == DeliverType.NULL)
            {
                if (DeliverType == DeliverType.NULL)
                {
                    ModelState.AddModelError("DeliverType", "Выберите способ доставки");
                }
                return View(daoTemplate.FindOrderByUid(uid));
            }

            var order = daoTemplate.FindOrderByUid(uid);
            var contact = Contact.From(contactViewModel);
            order.ShippingDetails = contact;
            order.PaymentType = PaymentType;
            order.DeliverType = DeliverType;
            order.DeliverPrice = orderService.GetPrice(order.DeliverType);
            daoTemplate.Save(order);
            return RedirectToAction("DetailsUser", new {id = order.Uid});

        }
    }

    
}

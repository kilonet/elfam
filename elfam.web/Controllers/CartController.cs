using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using elfam.web.Models;
using elfam.web.Services;
using elfam.web.Services.Results;
using elfam.web.ViewModels;
using elfam.web.ViewModels.Cart;
using elfam.web.ViewModels.Order;
using elfam.web.ViewModels.User;
using Microsoft.Practices.Unity;

namespace elfam.web.Controllers
{
    public class CartController : BaseController
    {
        private UserService userService = new UserService();
        private OrderService orderService;

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
        
        public ActionResult Index(Cart cart)
        {
            return View("Review", new ReviewCartViewModel{ Cart = cart});
        }



        public ActionResult Add(Cart cart, int productId, int quantity)
        {
            Product product = daoTemplate.FindByID<Product>(productId);
            var quantityInCart = cart.CurrentQuantity(productId);
            if (quantityInCart + quantity > product.Rest())
            {
                return Json(new [] {new { Key = "quantity", Value = "Слишком большое количество" }});
            }
            cart.Add(product, quantity);
            return Json(new object[]{});
        }

        public ActionResult CartWidget(Cart  cart)
        {
            return View(cart);
        }

        [HttpPost]
        public ActionResult Recalc(EditAndCheckoutViewModel viewModel, Cart cart)
        {
            // take products from cart and update quantity
            foreach (var item in viewModel.CartLines)
            {
                CartLineViewModel item1 = item;
                cart.Items.Single(x => x.Product.Id == item1.ProductId).Quantity = item.Quantity;
            }
            int i = 0;
            foreach (CartItem cartItem in cart.Items)
            {
                cartItem.Product = daoTemplate.FindByID<Product>(cartItem.Product.Id);
                if (cartItem.Product.Rest() < cartItem.Quantity)
                    ModelState.AddModelError(string.Format("CartLines[{0}].Quantity", i), "Слишком большое количество");
                i++;
            }
            return View("Review", new ReviewCartViewModel { Cart = cart }); 
        }

        [HttpPost]
        public ActionResult Checkout(EditAndCheckoutViewModel viewModel, Cart cart)
        {
            // take products from cart and update quantity
            foreach (var item in viewModel.CartLines)
            {
                CartLineViewModel item1 = item;
                cart.Items.Single(x => x.Product.Id == item1.ProductId).Quantity = item.Quantity;
            }

            if (CurrentUser() == null)
            {
                return View("LoginOrRegister");
            }

            int i = 0;
            foreach (CartItem cartItem in cart.Items)
            {
                cartItem.Product = daoTemplate.FindByID<Product>(cartItem.Product.Id);
                if (cartItem.Product.Rest() < cartItem.Quantity)
                    ModelState.AddModelError(string.Format("CartLines[{0}].Quantity", i), "Слишком большое количество");
                i++;
            }
            if (!ModelState.IsValid)
            {
                return View("Review", new ReviewCartViewModel
                {
                    Cart = cart
                });
            }
            return RedirectToAction("EnterShippingDetails");
        }

        public ActionResult EnterShippingDetails(Cart cart)
        {
            if (cart.Summ() < 300)
            {
                ModelState.AddModelError("summ", "Минимальная сумма заказа 300 рублей");
                return View("Review", new ReviewCartViewModel { Cart = cart });
            }
            var model = new EnterShippingDetailsViewModel()
                            {
                                Contact = ContactViewModel.From(CurrentUser().Contact),
                                User = CurrentUser(),
                                Cart = cart,
                                DeliverPrices = daoTemplate.FindAll<DeliverPrices>()[0]
                            };
            return View("EnterShippingDetails", model);
        }

        [HttpPost]
        public ActionResult LoginAndCheckout(string email, string password, Cart cart)
        {
            if (userService.AuthenticateUser(email, password))
            {
                User user = daoTemplate.FindUniqueByField<User>(Models.User.EmailProperty, email);
                FormsAuthentication.SetAuthCookie(email, true);
                return View("EnterShippingDetails", new EnterShippingDetailsViewModel()
                                                        {
                                                            Contact = ContactViewModel.From(user.Contact),
                                                            User = user,
                                                            Cart = cart,
                                                            DeliverPrices = daoTemplate.FindAll<DeliverPrices>()[0]
                                                        });
            }
            else
            {
               ModelState.AddModelError("login", "Неправильное имя пользователя или пароль");
               return View("LoginOrRegister", cart); 
            }
        }

        [HttpPost]
        public ActionResult Send(EnterShippingDetailsViewModel viewModel, Cart cart)
        {
            if (!ModelState.IsValid || viewModel.DeliverType == DeliverType.NULL || viewModel.PaymentType == PaymentType.NULL)
            {
                if (viewModel.DeliverType == DeliverType.NULL)
                {
                    ModelState.AddModelError("DeliverType", "Выберите способ доставки");
                }

                if (viewModel.PaymentType == PaymentType.NULL)
                {
                    ModelState.AddModelError("PaymentType", "Выберите способ оплаты");
                }

                return View("EnterShippingDetails", new EnterShippingDetailsViewModel()
                                                        {
                                                            Contact = ContactViewModel.From(CurrentUser().Contact),
                                                            Cart = cart,
                                                            User = CurrentUser(),
                                                            DeliverPrices = daoTemplate.FindAll<DeliverPrices>()[0],
                                                            DeliverType = viewModel.DeliverType,
                                                            Comment = viewModel.Comment

                });
            }

            OrderShippingInfo info = OrderShippingInfo.From(viewModel);


            AddOrderResult result = orderService.AddOrder(cart, CurrentUser(), info);

            var message = MailService.RenderViewToString("~/Views/MailTemplates/NewOrder.aspx", result.Order, this.ControllerContext);
            BillViewModel model = new BillViewModel()
                            {
                                Price = result.Order.SummWithDiscount,
                                Address = result.Order.ShippingDetails.AddressBill(),
                                Uid = result.Order.Uid,
                                UserName = result.Order.ShippingDetails.FullName
                            };
            var attachment = "";
            if (result.Order.PaymentType == PaymentType.Bank)
            {
                attachment = MailService.RenderViewToString("~/Views/Order/Bill.aspx", model, this.ControllerContext);                
            }
            MailService.Send("Новый заказ - Elfam.ru", message, result.Order.User.Email, attachment, null);

            message = MailService.RenderViewToString("~/Views/MailTemplates/NewOrderAdmin.aspx", result.Order, this.ControllerContext);
//            MailService.Send("Новый заказ № " + result.Order.Uid, message, "littleone@yandex.ru");
            mailService.SendCcAdmins("Новый заказ № " + result.Order.Uid, message, "littleone@yandex.ru");

            cart.Items.Clear();
            return RedirectToAction("DetailsUser", "Order", new { id = result.Order.Uid });
        }

        [HttpPost]
        public ActionResult Remove(int productId, Cart cart)
        {
            var remove = cart.Items.Single(x => x.Product.Id == productId);
            cart.Items.Remove(remove);
            return View("Review", new ReviewCartViewModel()
            {
                Cart = cart

            }); 
        }

    }
}

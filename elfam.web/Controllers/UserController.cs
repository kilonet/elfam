using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using elfam.web.Attributes;
using elfam.web.Extensions;
using elfam.web.Models;
using elfam.web.Services;
using elfam.web.ViewModels;
using elfam.web.ViewModels.User;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using Order = elfam.web.Models.Order;

namespace elfam.web.Controllers
{
    public class UserController : BaseController
    {
        UserService userService = new UserService();
        public static string LOGIN_ERROR = "login_error";

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserViewModel viewModel)
        {
            ValidateInput(viewModel);

            if (ModelState.IsValid)
            {
                User user = new User();
                user.Contact = Contact.From(viewModel.Contact);
                user.Email = viewModel.Email;
                user.IsSignedForNews = viewModel.IsSignForNews;
                user.PasswordHash = UserService.CalculateHash(viewModel.Password);
                

                daoTemplate.Save(user);
                FormsAuthentication.SetAuthCookie(user.Email, true);
                return Redirect("/");
            }
            return View(viewModel);

        }

        private void ValidateInput(UserViewModel viewModel)
        {
            if (viewModel.ConfirmPassword == null)
                viewModel.ConfirmPassword = "";
            if (viewModel.Password == null)
                viewModel.Password = "";
            if (!viewModel.Password.Equals(viewModel.ConfirmPassword))
            {
                ModelState.AddModelError("ConfirmPassword", "Пароли должны совпадать");
            }
            
            var user = daoTemplate.FindUniqueByField<User>(Models.User.EmailProperty, viewModel.Email);
            if (user != null)
            {
                ModelState.AddModelError("Email", "Пользователь с таким email уже существует");
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password, string returnUrl)
        {
            if (userService.AuthenticateUser(email, password))
            {
                FormsAuthentication.SetAuthCookie(email, true);
                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                return Redirect("/");
            }
            else
            {
                TempData[LOGIN_ERROR] = "Неправильный пароль либо пользователь с таким email не существует<br/>";
                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                return View();
            }
            
        }

        [Admin]
        public ActionResult Subscribe(string email)
        {
            if (!email.isEmail())
            {
                return Json(new[] {new {Key = "email-subs", Value = "введите корректный email"}});
            }

            DetachedCriteria criteria = DetachedCriteria.For<Subscriber>();
            criteria.Add(Restrictions.Eq("Email", email));
            Subscriber subscriber = daoTemplate.FindUniqueByCriteria<Subscriber>(criteria);
            if (subscriber == null)
            {
                subscriber = new Subscriber(){Email = email};
                daoTemplate.Save(subscriber);
                return Json(new int[0]);
            }
            return Json(new[] { new { Key = "email-subs", Value = "Введённый адрес уже в списке рассылки" } });
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        [ChildActionOnly]
        public ActionResult LoginWidget()
        {
            User user = daoTemplate.FindUniqueByField<User>(Models.User.EmailProperty, User.Identity.Name);
            if (user != null)
                return View("Loggedin", user);
            
            return View("NotLoggedin");
        }

        public ActionResult Index()
        {
            IList<User> users = daoTemplate.FindAll<User>();
            return View(users);
        }

        [Authorize]
        public ActionResult MyOrders()
        {
            DetachedCriteria criteria = DetachedCriteria.For<Order>();
            criteria.Add(Restrictions.Eq(Order.UserProperty, CurrentUser()));
            var orders = daoTemplate.FindByCriteria<Order>(criteria);
            MyOrdersViewModel viewModel = new MyOrdersViewModel()
                                              {
                                                  Orders = orders
                                              };
            return View(viewModel);
        }

        [Authorize]
        public ActionResult MyInfo()
        {
            var user = CurrentUser();
            MyInfoViewModel viewModel = MyInfoViewModel.From(user);
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult MyInfo(MyInfoViewModel viewModel)
        {
            User user = CurrentUser();
            if (!user.Email.Equals(viewModel.Email))
            {
                if (daoTemplate.FindUniqueByField<User>(Models.User.EmailProperty, viewModel.Email) != null)
                {
                    ModelState.AddModelError("Email", "Пользователь с таким email уже зарегистрирован");
                }    
            }
            
            if (ModelState.IsValid)
            {
                user.Contact = Contact.From(viewModel.Contact);
                user.Email = viewModel.Email;
                user.IsSignedForNews = viewModel.IsSignForNews;
            }
            return View(viewModel);
        }

        [Admin]
        public ActionResult List()
        {
            DetachedCriteria criteria = DetachedCriteria.For(typeof (User));
            criteria.CreateAlias("Orders", "o");
            criteria.SetProjection(
                Projections.ProjectionList()
                    .Add(Projections.Count("Orders").As("Quantity"))
                    .Add(Projections.GroupProperty("Id").As("UserId")));
            criteria.SetResultTransformer(Transformers.AliasToBean(typeof (UserOrdersReportRow)));
            IList<UserOrdersReportRow> userOrders = daoTemplate.FindByCriteria<UserOrdersReportRow>(criteria);
            DetachedCriteria usersCriteria = DetachedCriteria.For(typeof (User)).SetFetchMode("Orders", FetchMode.Select);
            IList<User> users = daoTemplate.FindByCriteria<User>(usersCriteria);
            IList<UserListItemViewModel> viewModels = new List<UserListItemViewModel>(users.Count);
            foreach (User user in users)
            {
                UserOrdersReportRow row = userOrders.SingleOrDefault(x => x.UserId == user.Id);
                int quantity = row == null ? 0 : row.Quantity;
                viewModels.Add(new UserListItemViewModel()
                                   {
                                       Quantity = quantity,
                                       User = user,
                                       Profit = user.Profit(),
                                       Summ = user.Orders.Sum(x => x.SummWithDiscount)
                                   });
            }
            return View(viewModels);
        }

        [Admin][HttpPost]
        public ActionResult Discount(int userId, int discount)
        {
            if (discount > 100 || discount < 0)
                return Json(new[] { new { Key = "input-discount", Value = "введите число от 0 до 100" } });
            User user = daoTemplate.FindByID<User>(userId);
            user.Discount = discount;
            daoTemplate.Save(user);
            return Json(null);
        }

        [Admin]
        public ActionResult Details(int id)
        {
            User user = daoTemplate.FindByID<User>(id);
            return View(user);
        }
        
        [HttpPost]
        [Admin]
        public ActionResult CanLogin(bool canLogin, int id)
        {
            User user = daoTemplate.FindByID<User>(id);
            user.CanLogin = canLogin;
            daoTemplate.Save(user);
            return Json(null);
        }

        [Admin]
        public ActionResult SubscribeUser(int id, bool subscribe)
        {
            User subscriber = daoTemplate.FindByID<User>(id);
            subscriber.IsSignedForNews = subscribe;
            daoTemplate.Save(subscriber);
            return Json(id);
        }

        [HttpGet]
        public ActionResult Recover()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Recover(string email)
        {
            User user = daoTemplate.FindUniqueByField<User>(Models.User.EmailProperty, email);
            if (user == null)
            {
                ModelState.AddModelError("email", "Пользователь с таким адресом не найден");
                return View();
            }
            string newPassword = Membership.GeneratePassword(6, 0);
            user.PasswordHash = UserService.CalculateHash(newPassword);
            daoTemplate.Save(user);

            MailService.NotifyPasswordChange(user, newPassword);
            FlashMessage("Пароль изменён и отправлен на email. Проверьте свой почтовый ящик.");

            return Redirect("/");
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult ChangePassword(string password, string newPassword, string confirmNewPassword)
        {
            if (userService.AuthenticateUser(CurrentUser().Email, password))
            {
                if (newPassword.Equals(confirmNewPassword))
                {
                    if (UserService.IsValidPassword(newPassword))
                    {
                        User current = CurrentUser();
                        current.PasswordHash = UserService.CalculateHash(newPassword);
                        daoTemplate.Save(current);    
                    }
                    else
                    {
                        ModelState.AddModelError("newPassword", "Минимальная длина пароля 4 символа");
                    }

                }
                else
                {
                    ModelState.AddModelError("confirmNewPassword", "Новые пароли не совпадают");
                }
            }
            else
            {
                ModelState.AddModelError("password", "Неправильный пароль");
            }
            if (ModelState.IsValid)
            {
                FlashMessage("Пароль успешно обновлён");
                return RedirectToAction("ChangePassword");
            }
            return View();
        }
    }

    

    public class UserOrdersReportRow
    {
        public int UserId { get; set; }
        public int Quantity { get; set; }
    }
}


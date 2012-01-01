using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using elfam.web.Attributes;
using elfam.web.Exceptions;
using elfam.web.Models;
using elfam.web.Paging;
using elfam.web.Paging.Subscriber;
using elfam.web.Services;
using elfam.web.Utils;
using NHibernate.Criterion;
using Order = NHibernate.Criterion.Order;
using System.Security.Cryptography;

namespace elfam.web.Controllers
{
    public class SubscriberController : BaseController
    {
        [Admin]
        public ActionResult List(SubscriberListSearchCriteria criteria)
        {
            var queryBuilder = new SubscriberListQueryBuilder(criteria);
            var result = queryBuilder.Execute(daoTemplate.Session);
            return View(result);
        }
        
        public ActionResult Subscribe(int id, bool subscribe)
        {
            Subscriber subscriber = daoTemplate.FindByID<Subscriber>(id);
            subscriber.IsActive = subscribe;
            daoTemplate.Save(subscriber);
            return Json(id);
        }

        [HttpGet]
        public ActionResult Send()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Send(string text, string subject)
        {
            var messages = new List<MailMessage>();

            DetachedCriteria subscriberCriteria = DetachedCriteria.For<Subscriber>();
            subscriberCriteria.Add(Restrictions.Eq("IsActive", true));
            var subscribers = daoTemplate.FindByCriteria<Subscriber>(subscriberCriteria);
            foreach (Subscriber subscriber in subscribers)
            {
                MailMessage message = new MailMessage(new MailAddress(Settings.Instance.MailFromAddress, Settings.Instance.MailFromDisplayName), new MailAddress(subscriber.Email));
                message.Subject = subject;
                message.Body = text;
                message.IsBodyHtml = true;
                message.BodyEncoding = Encoding.UTF8;
                message.Body += "<br/>" + string.Format("Чтобы отписаться от рассылки  перейдите по ссылке: http://{2}/Unsubscribe/{0}/{1}", subscriber.Email, SubscriberService.CalculateToken(subscriber.Email), Request.ServerVariables["HTTP_HOST"]);
                messages.Add(message);
            }
            
            DetachedCriteria userCriteria = DetachedCriteria.For<User>();
            userCriteria.Add(Restrictions.Eq(Models.User.IsSignedForNewsProperty, true));
            var users = daoTemplate.FindByCriteria<User>(userCriteria);
            foreach (User user in users)
            {
                MailMessage message = new MailMessage(new MailAddress(Settings.Instance.MailFromAddress, Settings.Instance.MailFromDisplayName), new MailAddress(user.Email, user.Contact.FullName));
                message.Subject = subject;
                message.Body = text;
                message.IsBodyHtml = true;
                message.BodyEncoding = Encoding.UTF8;
                message.Body += "<br/>" + string.Format("Чтобы отписаться от рассылки  перейдите по ссылке: http://{2}/UnsubscribeUser/{0}/{1}", user.Email, SubscriberService.CalculateToken(user.Email), Request.ServerVariables["HTTP_HOST"]);
                messages.Add(message);
            }

            SmtpClient client = new SmtpClient(Settings.Instance.MailSmtpServer, Settings.Instance.MailSmtpPort)
                                    {
                                        Credentials = new NetworkCredential() {UserName = Settings.Instance.MailUserName, Password = Settings.Instance.MailUserPassword}
                                        
                                    };
            foreach (MailMessage message in messages)
            {
                client.Send(message);    
            }
            
            
            return View();
        }

        public ActionResult Unsubscribe(string email, string signature)
        {
            if (SubscriberService.VerifyToken(email, signature))
            {
                var subscriber = daoTemplate.FindUniqueByField<Subscriber>(Subscriber.EmailProperty, email);
                if (subscriber == null) throw new NotFoundException();
                subscriber.IsActive = false;
                daoTemplate.Save(subscriber);
                ViewData["email"] = email;
                return View();
            }
            throw new NotFoundException();
        }

        public ActionResult UnsubscribeUser(string email, string signature)
        {
            if (SubscriberService.VerifyToken(email, signature))
            {
                var user = daoTemplate.FindUniqueByField<User>(Models.User.EmailProperty, email);
                if (user == null) throw new NotFoundException();
                user.IsSignedForNews = false;
                daoTemplate.Save(user);
                ViewData["email"] = email;
                return View("Unsubscribe");
            }
            throw new NotFoundException();
        }
    }
}

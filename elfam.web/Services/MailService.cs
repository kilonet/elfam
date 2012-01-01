using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mail;
using System.Web.Mvc;
using elfam.web.Models;
using elfam.web.Utils;
using MailMessage = System.Net.Mail.MailMessage;

namespace elfam.web.Services
{
    public class MailService
    {
        UserService userService = new UserService();

        public static void Send(string subject, string text, string email)
        {
            Send(subject, text, email, "", null);    
        }
        
        public void SendCcAdmins(string subject, string text, string email)
        {
            var admins = userService.FindAllAdmins();
            var ccs = admins.Select(user => user.Email);
            Send(subject, text, email, "", ccs);
        }

        public static void Send(string subject, string text, string email, string attachmentText, IEnumerable<string> cc)
        {
            MailMessage message = new MailMessage(new MailAddress(Settings.Instance.MailFromAddress, Settings.Instance.MailFromDisplayName), new MailAddress(email));
            if (cc != null)
            {
                foreach (string address in cc)
                {
                    if (email != address)
                        message.Bcc.Add(address);
                }
            }
            message.Subject = subject;
            message.Body = text;
            message.IsBodyHtml = true;
            message.BodyEncoding = Encoding.UTF8;
            SmtpClient client = new SmtpClient(Settings.Instance.MailSmtpServer, Settings.Instance.MailSmtpPort)
            {
                Credentials = new NetworkCredential() { UserName = Settings.Instance.MailUserName, Password = Settings.Instance.MailUserPassword }

            };
            var stream = new MemoryStream(Encoding.GetEncoding("windows-1251").GetBytes(attachmentText));
            if (!string.IsNullOrEmpty(attachmentText))
            {
                Attachment attachment = new Attachment(stream, "счёт_на_оплату.html");
                message.Attachments.Add(attachment);
            }
            Thread thread = new Thread(() =>
                                           {
                                               try
                                               {
                                                   client.Send(message);
                                               }
                                               catch (SmtpException)
                                               {
                                               }
                                           });
        
            thread.Start();               
            
        }

        public static void NotifyPasswordChange(User user, string password)
        {
            var text = "Уважаемый пользователь!<br/>";
            text += "Вы запросили новый пароль для входа на сайт http://elfam.ru <br/>" + Environment.NewLine;
            text += "Ваш новый пароль: " + password + "<br/><br/>";
            text += "Администрация Elfam.ru";
            Send("Elfam.ru - Восстановление пароля", text, user.Email, "", null);
        }

        public static string RenderViewToString(string viewPath, object model, ControllerContext controllerContext)
        {
            using (var writer = new StringWriter())
            {
                var view = new WebFormView(viewPath);
                var vdd = new ViewDataDictionary(model);
                var viewCxt = new ViewContext(controllerContext, view, vdd, new TempDataDictionary(), writer);
                viewCxt.ViewData = new ViewDataDictionary(model);
                viewCxt.View.Render(viewCxt, writer);
                return writer.ToString();
            }
        }
    }
}

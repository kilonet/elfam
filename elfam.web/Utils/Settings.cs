using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace elfam.web.Utils
{
    public class Settings
    {
        private static readonly Settings instanse = new Settings();

        private Settings()
        {
            
            MailFromAddress = ConfigurationManager.AppSettings["MailFromAddress"];
            MailFromDisplayName = ConfigurationManager.AppSettings["MailFromDisplayName"];
            MailSmtpServer = ConfigurationManager.AppSettings["MailSmtpServer"];
            MailSmtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["MailSmtpPort"]);
            MailUserName = ConfigurationManager.AppSettings["MailUserName"];
            MailUserPassword = ConfigurationManager.AppSettings["MailUserPassword"];
        }

        public static Settings Instance
        {
            get { return instanse; }
        }

        public string   MailFromAddress { get; private set; }
        public string   MailFromDisplayName { get; private set; }
        public string   MailSmtpServer { get; private set; }
        public int      MailSmtpPort { get; private set; }
        public string   MailUserName { get; private set; }
        public string   MailUserPassword { get; private set; }


    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using elfam.web.Dao;
using elfam.web.Models;
using elfam.web.Paging;
using Microsoft.Practices.Unity;
using NHibernate.Criterion;

namespace elfam.web.Controllers
{
    public class BaseController: Controller
    {
        protected IDaoTemplate daoTemplate;

       [Dependency]
        public IDaoTemplate DaoTemplate
        {
            set { daoTemplate = value; }
        }

        protected User CurrentUser()
        {
            if (!string.IsNullOrEmpty(User.Identity.Name))
            {
                return daoTemplate.FindUniqueByField<User>(Models.User.EmailProperty, User.Identity.Name);
            }
            return null;
        }

        public void FlashMessage(string message)
        {
            TempData["message"] = message;
        }
    }
}

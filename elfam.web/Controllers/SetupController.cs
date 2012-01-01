using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using elfam.web.Attributes;
using elfam.web.Dao;
using elfam.web.Models;
using Microsoft.Practices.Unity;

namespace elfam.web.Controllers
{
    public class SetupController : Controller
    {
        

        private IDaoTemplate daoTemplate;

        [Dependency]
        public IDaoTemplate DaoTemplate
        {
            set { daoTemplate = value; }
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(daoTemplate.FindAll<DeliverPrices>()[0]);
        }

        [HttpPost]
        [Admin]
        public ActionResult Index(DeliverPrices prices)
        {
            if (!ModelState.IsValid)
            {
                return View(prices);
            }
            prices.Id = 1;
            daoTemplate.Save(prices);
            return RedirectToAction("Index");
        }

    }
}

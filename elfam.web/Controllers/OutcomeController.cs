using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using elfam.web.Models;
using elfam.web.ViewModels;
using NHibernate.Criterion;
using Order = NHibernate.Criterion.Order;

namespace elfam.web.Controllers
{
    public class OutcomeController : BaseController
    {
        //
        // GET: /Outcome/

        public ActionResult List()
        {
            DetachedCriteria criteria = DetachedCriteria.For(typeof (Outcome));
            criteria.AddOrder(Order.Asc("Date"));
            var outcomes = daoTemplate.FindByCriteria<Outcome>(criteria);
            IEnumerable<OutcomeListItemViewModel> viewModels = outcomes.Select(income => new OutcomeListItemViewModel(income));
            return View(viewModels);
        }

    }
}

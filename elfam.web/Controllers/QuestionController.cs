using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using elfam.web.Attributes;
using elfam.web.Models;
using elfam.web.Services;
using elfam.web.ViewModels.Question;
using System.Diagnostics;
using NHibernate.Criterion;
using Order = NHibernate.Criterion.Order;

namespace elfam.web.Controllers
{
    public class QuestionController : BaseController
    {
        
        [HttpPost]
        public ActionResult Ask(QueViewModel model)
        {
            IList<Error> errors = new List<Error>();
            if (!ModelState.IsValid)
            {
                for (int i = 0; i < ModelState.Keys.Count; i++)
                {
                    if (ModelState.Values.ToArray()[i].Errors.Count > 0)
                    {
                        foreach (ModelError error in ModelState.Values.ToArray()[i].Errors)
                        {
                            errors.Add(new Error() { Key = ModelState.Keys.ToArray()[i], Value = error.ErrorMessage});
                        }
                        
                    }
                }
            }
            if (errors.Count > 0)
                return Json(errors);
            Question q = new Question();
            q.Email = model.Email;
            q.Product = daoTemplate.FindByID<Product>(model.ProductId);
            q.Text = model.Text;
            q.User = CurrentUser();
            daoTemplate.Save(q);
            return Json(errors);
        }

        [Admin]
        public ActionResult List()
        {
            var crit = DetachedCriteria.For(typeof (Question));
            crit.AddOrder(Order.Desc(Question.DateProperty));
            IList<Question> qs = daoTemplate.FindByCriteria<Question>(crit);
            var notViewed = qs.Where(x => x.IsViewed == false);
            foreach (var q in notViewed)
            {
                q.IsViewed = true;
                daoTemplate.Save(q);
            }
            return View(qs);
        }

        [Admin][HttpPost]
        public ActionResult Answer(string subject, string text, int questionId)
        {
            Question q = daoTemplate.FindByID<Question>(questionId);
            MailService.Send(subject, text, q.User.Email);
            q.IsAnswered = true;
            daoTemplate.Save(q);
            return Json(new object());
        }

        [Admin]
        public String RenderQuestionsLabel()
        {
            DetachedCriteria criteria = DetachedCriteria.For<Question>();
            criteria.Add(Restrictions.Eq(Question.IsViewedProperty, false));
            criteria.SetProjection(Projections.RowCount());
            int count = criteria.GetExecutableCriteria(daoTemplate.Session).UniqueResult<int>();
            if (count > 0)
                return string.Format("<b>вопросы ({0})</b>", count);
            return string.Format("вопросы");
        }

    }

    class Error
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}

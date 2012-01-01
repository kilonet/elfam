using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using elfam.web.Attributes;
using elfam.web.Exceptions;
using elfam.web.Models;
using NHibernate.Criterion;
using Order = NHibernate.Criterion.Order;

namespace elfam.web.Controllers
{
    public class ArticleController : BaseController
    {
        //
        // GET: /Article/

        [Admin]
        public ActionResult Index()
        {
            var criteria = DetachedCriteria.For(typeof(Article)).AddOrder(Order.Desc(Article.LastUpdatedProperty));
            var articles = daoTemplate.FindByCriteria<Article>(criteria);
            return View(articles);                
        }

        public ActionResult Details(int id)
        {
            var article = daoTemplate.FindByID<Article>(id);
            if (article == null) throw new NotFoundException();
            return View("Details", article);
        }

        [Admin]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Admin]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Exclude = "Id")]Article article)
        {
            if (ModelState.IsValid)
            {
                article.Author = CurrentUser();
                daoTemplate.Save(article);
                return Redirect("/Article/Details/" + article.Id);
            }
            return View(article);
        }

        [Admin]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var article = daoTemplate.FindByID<Article>(id);
            return View(article);
        }

        [Admin]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                article.Author = CurrentUser();
                if (article.ManuallySetLastUpdated != null)
                {
                    article.LastUpdated = article.ManuallySetLastUpdated.Value;
                }
                daoTemplate.Save(article);
                return Redirect("/Article/Details/" + article.Id);
            }
            return View(article);
        }

        [HttpPost][Admin]
        public ActionResult Delete()
        {
            int id = Convert.ToInt32(Request.Form["Id"]);
            var article = daoTemplate.FindByID<Article>(id);
            if (article != null)
            {
                daoTemplate.Remove(article);
            }
            return RedirectToAction("Index");
        }

        public ActionResult AsList()
        {
            var criteria = DetachedCriteria.For<Article>().AddOrder(Order.Asc(Article.IndexProperty));
            criteria.Add(Restrictions.Eq(Article.PlacementProperty, ArticlePlacement.TopMenu));
            IList<Article> articles = daoTemplate.FindByCriteria<Article>(criteria);
            return View(articles);
        }

        [HttpPost]
        [Admin]
        public ActionResult RemoveComment()
        {
            int id = Convert.ToInt32(Request.Form["id"]);
            Comment comment = daoTemplate.FindByID<Comment>(id);
            if (comment.Image != null)
                comment.Image.DeleteFiles(this);
            daoTemplate.Remove(comment);
            return Content("");
        }
    }
}

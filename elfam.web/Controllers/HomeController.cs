using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using elfam.web.Models;
using elfam.web.Paging;
using elfam.web.Paging.News;
using elfam.web.Services;
using Microsoft.Practices.Unity;
using NHibernate.Criterion;
using Order = NHibernate.Criterion.Order;


namespace elfam.web.Controllers
{
    public class HomeController : BaseController
    {

        [Dependency]
        public CategoryService CategoryService { set; get; }

        private const int COUNT = 10;

        public ActionResult NotWorking()
        {
            return View();
        }

        public ActionResult Index()
        {
            ViewData["categories"] = CategoryService.FindRootCategories().Where(cat => cat.IsVisible && cat.ParentIsVisible);
            
            var criteria = DetachedCriteria.For(typeof (Article));
            criteria.Add(Restrictions.Eq(Article.PlacementProperty, ArticlePlacement.News));
            criteria.AddOrder(Order.Desc(Article.LastUpdatedProperty));
            criteria.SetMaxResults(1);
            var articles = daoTemplate.FindByCriteria<Article>(criteria);
            if (articles.Count > 0)
                ViewData["news"] = articles[0];
            else
                ViewData["news"] = new Article();

            SetNewsArticleToViewData();


            return View();
        }

        private void SetNewsArticleToViewData()
        {
            DetachedCriteria criteria;
            IList<Article> articles;
            criteria = DetachedCriteria.For(typeof(Article));
            criteria.Add(Restrictions.Eq(Article.PlacementProperty, ArticlePlacement.MainPage));
            criteria.AddOrder(Order.Desc(Article.LastUpdatedProperty));
            criteria.SetMaxResults(1);
            articles = daoTemplate.FindByCriteria<Article>(criteria);
            if (articles.Count > 0)
                ViewData["article"] = articles[0].Text;
            else
                ViewData["article"] = "";
        }


        public ActionResult News(SearchCriteria criteria)
        {
            NewsQueryBuilder queryBuilder = new NewsQueryBuilder(criteria);
            var result = queryBuilder.Execute(daoTemplate.Session);

            SetNewsArticleToViewData();

            return View(result);
        }

    }
}

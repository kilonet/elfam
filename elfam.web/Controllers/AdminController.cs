using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using elfam.web.Attributes;
using elfam.web.Exceptions;
using elfam.web.Models;
using elfam.web.Paging;
using elfam.web.Paging.Product;
using elfam.web.Utils;
using elfam.web.ViewModels.Admin;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using NHibernate.Transform;
using Order = NHibernate.Criterion.Order;

namespace elfam.web.Controllers
{
    public class AdminController : BaseController
    {
        [Admin]
        public ActionResult ListProducts(ProductListAdminSearchCriteria searchCriteria)
        {
            ProductListAdminQueryBuilder queryBuilder = new ProductListAdminQueryBuilder(searchCriteria);
            var categories = daoTemplate.FindAll<Category>();
            var result = queryBuilder.Execute(daoTemplate.Session);
            return View(new ProductListViewModel{SearchResults = result, Categories = categories});
        }

        [Admin][HttpGet]
        public ActionResult FixImages_g3qq2()
        {
            return Redirect("/");
            string[] small = Directory.GetFiles(Server.MapPath("~/Content/Uploads"), "small*.jpg");
            foreach (var path in small)
            {
                System.IO.File.Delete(path);
            }
            string[] big = Directory.GetFiles(Server.MapPath("~/Content/Uploads"), "big*.jpg");
            foreach (var s in big)
            {
                ImageUtils.SaveImageToFile(ImageUtils.ResizeImageSquare(s), s.Replace("big", "small"));
            }
            return Redirect("/");
        }
    }

    public class ProductListRow
    {
        public int  ProductId { get; set; }
        public string   CategoryName { get; set; }
        public string   ProductName { get; set; }
        public DateTime Date { get; set; }
    }
}

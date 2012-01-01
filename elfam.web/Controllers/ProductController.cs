using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using elfam.web.Attributes;
using elfam.web.Exceptions;
using elfam.web.FilterAttributes;
using elfam.web.Models;
using elfam.web.Paging;
using elfam.web.Paging.Product;
using elfam.web.Services;
using elfam.web.Utils;
using elfam.web.ViewModels;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Impl;
using NHibernate.SqlCommand;
using NHibernate.Transform;
using Wiki;
using Order = NHibernate.Criterion.Order;

namespace elfam.web.Controllers
{
    public class ProductController : BaseController
    {
        private ProductService productService = new ProductService();
        private static string CategoryIdProperty = "categoryId";

        public ActionResult List(ProductListSearchCriteria searchCriteria)
        {
            ProductListQueryBuilder queryBuilder = new ProductListQueryBuilder(searchCriteria);
            var result = queryBuilder.Execute(daoTemplate.Session);
            Category category = null;
            if (searchCriteria.CategoryId != null)
                category = daoTemplate.FindByID<Category>(searchCriteria.CategoryId);
            return View(new ProductListViewModel(){Category = category, Results = result, IsNew = searchCriteria.IsNew});
        }

        [Authorize(Roles = "Admin")]
        [AttachCategories]
        public ActionResult Create()
        {
            return View(new ProductViewModel());
        }
        
        
        [Admin]
        [AttachCategories]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            Product product = new Product();
            product.Date = DateTime.UtcNow;
            product.CopyFrom(viewModel);
            daoTemplate.Save(product);

            handleImages(product);

            return RedirectToAction("Edit", new {Id = product.Id});
        }

        private void handleImages(Product product)
        {
            foreach (string inputTagName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[inputTagName];
                if (file.ContentLength == 0) continue;
                Image image = new Image();
                image.PathRootBased = "";
                daoTemplate.Save(image);
                // TODO check for mime type
                // TODO add support for GIF, PNG
                if (file.ContentLength > 0)
                {
                    string filePath = Path.Combine(HttpContext.Server.MapPath("../Content/Uploads"), image.Big);
                    string thumbFilePath = Path.Combine(HttpContext.Server.MapPath("../Content/Uploads"), image.Small);
                    file.SaveAs(filePath);
                    
                    ImageUtils.SaveImageToFile(ImageUtils.ResizeImage(filePath, 640), filePath);
                    ImageUtils.SaveImageToFile(ImageUtils.ResizeImageSquare(filePath), thumbFilePath);

                    
                }
                product.Images.Add(image);
                daoTemplate.Save(product);
            }
        }

        [Admin]
        [AttachCategories]
        public ActionResult Edit(int id)
        {
            Product product = daoTemplate.FindByID<Product>(id);
            if (product == null)
                throw new NotFoundException();
            ProductViewModel viewModel = ProductViewModel.From(product);
            return View(viewModel);
        }

        [ValidateInput(false)]
        [Admin]
        [HttpPost]
        [AttachCategories]
        public ActionResult Edit(ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Product product = daoTemplate.FindByID<Product>(viewModel.Id);
                product.CopyFrom(viewModel);

                handleImages(product);

                daoTemplate.Save(product);
                RedirectToAction("Edit", new {id = product.Id});
            }
            return View(viewModel);
        }

       

        public ActionResult ProductImages(int productId)
        {
            var product = daoTemplate.FindByID<Product>(productId);
            return View(product);
        }

        public ActionResult Details(int id)
        {
            Product product = daoTemplate.FindByID<Product>(id);
            return View(ProductViewModel.From(product));
        }

        [HttpPost]
        [Authorize]
        [ValidateInput(false)]
        private ActionResult AddComment(int productId, string text)
        {
            // text 
            if (text.Trim().Length == 0)
            {
                return Redirect("/Product/Details/" + productId);
            }
            Comment comment = new Comment();
            CreoleParser parser = new CreoleParser();
            comment.Text = parser.ToHTML(HttpUtility.HtmlEncode(text.Replace(Environment.NewLine, "\\\\")));
            comment.User = CurrentUser();

            // upload

            foreach (string inputTagName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[inputTagName];
                if (file.ContentLength == 0) continue;
                Image image = new Image();
                image.PathRootBased = "Users";
                daoTemplate.Save(image);
                string filePath = HttpContext.Server.MapPath(image.PathRootBasedBig);
                string thumbFilePath = HttpContext.Server.MapPath(image.PathRootBasedSmall);
                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                file.SaveAs(filePath);
                ImageUtils.SaveImageToFile(ImageUtils.ResizeImage(filePath, 640), filePath);
                ImageUtils.SaveImageToFile(ImageUtils.ResizeImageSquare(filePath, 100), thumbFilePath);
                
                
                comment.Image = image;
                daoTemplate.Save(image);
                
            }
            daoTemplate.Save(comment);
            return Redirect("/Product/Details/" + productId);
        }




        private ActionResult CommentsWidget()
        {
            var criteria = DetachedCriteria.For<Comment>();
            criteria.AddOrder(Order.Desc(Comment.DateProperty));
            var coments = daoTemplate.FindByCriteria<Comment>(criteria);
            return View(coments);
        }

      

        [Admin]
        public ActionResult DeleteImage(int imageId, int productId)
        {
            Image image = daoTemplate.FindByID<Image>(imageId);
            Product product = daoTemplate.FindByID<Product>(productId);
            System.IO.File.Delete(HttpContext.Server.MapPath(@"~\Content\Uploads\" + image.Big));
            System.IO.File.Delete(HttpContext.Server.MapPath(@"~\Content\Uploads\" + image.Small));
            product.Images.Remove(image);
            daoTemplate.Save(product);
            return RedirectToAction("Edit", new {id = productId});
        }

        [Admin][HttpGet]
        public ActionResult Report()
        {
            IList<ProductReportRow> report = productService.ProductReport();
            return View(report);
        }

        [Admin]
        public ActionResult SelectProductsWidget(int productId)
        {
            ViewData["productId"] = productId;
            return View();
        }

        
        public ActionResult GetProductsJson(int productId)
        {
            var product = daoTemplate.FindByID<Product>(productId);
            var criteria = DetachedCriteria.For<Product>();
            criteria.AddOrder(Order.Desc(Product.NameProperty));
            criteria.Add(Restrictions.Eq(Product.IsVisibleProperty, true));
            var products = daoTemplate.FindByCriteria<Product>(criteria);
            var productsJson = products.Select(p => new { Name = p.Name, Id = p.Id, IsRecomended = product.Recomended.Contains(p) });
            return Json(productsJson, JsonRequestBehavior.AllowGet);
        }

        [HttpPost][Admin]
        public ActionResult UpdateRecomended(int productId)
        {
            IEnumerable<int> ids;
            if (Request.Form["ids[]"] == null)
                ids = new int[] {};
            else
                ids = Request.Form["ids[]"].Split(new[] { ',' }).Select(id => Convert.ToInt32(id));
            var product = daoTemplate.FindByID<Product>(productId);
            product.Recomended.Clear();
            foreach (int id in ids)
            {
                var recomended = daoTemplate.FindByID<Product>(id);
                product.Recomended.Add(recomended);
            }
            daoTemplate.Save(product);
            return Json(ids);
        }
    }
}


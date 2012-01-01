using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using elfam.web.Attributes;
using elfam.web.FilterAttributes;
using elfam.web.Models;
using elfam.web.Services;
using elfam.web.Utils;
using elfam.web.ViewModels;

namespace elfam.web.Controllers
{
    public class CategoryController : BaseController
    {
        private CategoryService categoryService = new CategoryService();

        [Admin]
        public ActionResult Index()
        {
            return View();
        }       
             
        [Admin]
        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [AttachCategories]
        public ActionResult Create()
        {
            return View(new CategoryViewModel());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [AttachCategories]
        [ValidateInput(false)]
        public ActionResult Create(CategoryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            Category category = new Category();
            if (viewModel.ParentId.HasValue)
            {
                Category parent = daoTemplate.FindByID<Category>(viewModel.ParentId);
                parent.AddSubCategory(category);    
            }
            category.CopyFrom(viewModel);
            handleImage(category);
            daoTemplate.Save(category);
            return RedirectToAction("Index");
        }

        private void handleImage(Category category)
        {
            foreach (string inputTagName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[inputTagName];
                if (file.ContentLength > 0)
                {
                    Image image = new Image();
                    image.PathRootBased = "Category";
                    daoTemplate.Save(image);
                    string fileName = image.Small;
                    string filePath = Path.Combine(HttpContext.Server.MapPath("../Content/Uploads/"), fileName);
                    file.SaveAs(filePath);
                    ImageUtils.SaveImageToFile(ImageUtils.ResizeImageSquare(filePath), filePath);
                    category.Image = image;
                    
                    daoTemplate.Save(image);
                }
                break;
            }
        }

        [Admin]
        [AttachCategories]
        public ActionResult Edit(int id)
        {
            var category = daoTemplate.FindByID<Category>(id);
            if (category == null)
                throw new HttpException(404, "Страница не найдена");
            var viewModel = CategoryViewModel.From(category);
            return View(viewModel);
        }

        [HttpPost]
        [Admin]
        [AttachCategories]
        [ValidateInput(false)]
        public ActionResult Edit(CategoryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var category = daoTemplate.FindByID<Category>(viewModel.Id);

            if ((category.Parent != null && category.Parent.Id != viewModel.ParentId) ||
                (category.Parent == null && viewModel.ParentId > 0))
            {
                Category newParent = null;
                if (viewModel.ParentId != null)
                {
                    newParent = daoTemplate.FindByID<Category>(viewModel.ParentId);
                }
                category.MoveToNewParent(newParent);
            }

            handleImage(category);

            category.CopyFrom(viewModel);
            daoTemplate.Save(category);
            
            return RedirectToAction("Edit", new {Id = category.Id});
        }

        public string CategoryWidget()
        {
            return CategoryWidgetInternal(x => VirtualPathUtility.ToAbsolute("~/Product/List/") + "?categoryId=" + x, false);
        }

        public string CategoryWidgetEdit()
        {
            return CategoryWidgetInternal(x => VirtualPathUtility.ToAbsolute("~/Category/Edit/") + x, true);
        }

        private string CategoryWidgetInternal(Func<int, string> url, bool showAll)
        {
            IEnumerable<Category> categories = categoryService.FindRootCategories();

            string html = "";
            var subs = showAll ? categories : categories.Where(cat => cat.IsVisible);
            foreach (Category category in subs)
            {
                html += string.Format("<li><a href=\"{0}\">{1}</a>", url(category.Id), category.Name);
                listChildren(ref html, category, url, showAll);
            }

            return html;
        }

        private static void listChildren(ref string html, Category category, Func<int, string> url, bool showAll)
        {
            var subs = showAll ? new List<Category>(category.Subcategories)
                : new List<Category>(category.Subcategories.Where(cat => cat.IsVisible));
            if (subs.Count > 0)
            {
                html += "<ul>";
            }
            else
                return;

            foreach (var subCategory in subs)
            {
                html += string.Format("<li><a href=\"{0}\">{1}</a>", url(subCategory.Id), subCategory.Name);

                listChildren(ref html, subCategory, url, showAll);
                html += "</li>";
            }

            html += "</ul>";
        }

        [Admin][HttpPost]
        public ActionResult DeleteImage(int categoryId)
        {
            Category category = daoTemplate.FindByID<Category>(categoryId);
            System.IO.File.Delete(HttpContext.Server.MapPath(@"~\Content\Uploads\" + category.Image.Small ));
            category.Image = null;
            daoTemplate.Save(category);
            return RedirectToAction("Edit", new {id = categoryId});
        }

        [HttpPost][Admin]
        public ActionResult UploadImage(int categoryId)
        {
            foreach (string inputTagName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[inputTagName];
                string fileName = categoryId + ".jpg";
                string tempFileName = categoryId + "temp.jpg";
                if (file.ContentLength > 0)
                {
                    string tempFilePath = Path.Combine(HttpContext.Server.MapPath("../Content/Uploads/Category/"), tempFileName);
                    string filePath = Path.Combine(HttpContext.Server.MapPath("../Content/Uploads/Category/"), fileName);
                    file.SaveAs(tempFilePath);
                    ImageUtils.SaveImageToFile(ImageUtils.ResizeImageSquare(tempFilePath, 100), filePath);
                    System.IO.File.Delete(tempFilePath);
                }
                break;
            }
            return RedirectToAction("Edit", new{Id = categoryId });
        }
    }
}

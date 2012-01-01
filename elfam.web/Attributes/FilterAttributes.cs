using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using elfam.web.Models;
using elfam.web.Services;

namespace elfam.web.FilterAttributes
{
    public class AttachCategories: ActionFilterAttribute
    {
        public static string Key = "categories";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            CategoryService categoryService = new CategoryService();
            IList<Category> categories = categoryService.FindRootCategories();
            IList<SelectListItem> listItems = new List<SelectListItem>(categories.Count + 1);
            listItems.Add(new SelectListItem(){Text = "", Value = ""});
            int level = 0;
            foreach (Category category in categories)
            {
                listItems.Add(new SelectListItem() {Text = category.Name, Value = category.Id.ToString()});
                AddChildCategories(category, listItems, level);
            }
            filterContext.Controller.ViewData[Key] = listItems;
        }

        private void AddChildCategories(Category category, IList<SelectListItem> listItems, int level)
        {
            level++;
            foreach (Category subcategory in category.Subcategories)
            {
                string indent = "";
                for (int i = 0; i < level; i++)
                {
                    indent += "-";
                }
                listItems.Add(new SelectListItem() { Text = indent + subcategory.Name, Value = subcategory.Id.ToString() });
                AddChildCategories(subcategory, listItems, level);

            }
            level--;
        }
    }
}

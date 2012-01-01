using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using elfam.web.Attributes;
using elfam.web.FilterAttributes;
using elfam.web.Models;
using elfam.web.Services;

namespace elfam.web.Extensions
{
    public static class Extensions
    {
        public static IList<SelectListItem> Categories(this ViewDataDictionary viewData, int? selectedId)
        {
            var items = (IList<SelectListItem>) viewData[AttachCategories.Key];
            if (selectedId.HasValue)
            {
                var selected = items.SingleOrDefault(item => item.Value.Equals(selectedId.ToString()));
                if (selected != null)
                    selected.Selected = true;    
            }
            return items;
        }

        public static IList<SelectListItem> CategoriesExcluding(this ViewDataDictionary viewData, int selectedId, int excludedId)
        {
            CategoryService categoryService = new CategoryService();
            IList<Category> categories = categoryService.FindRootCategories();

            var toRemove = categories.SingleOrDefault(x => x.Id == excludedId);
            if (toRemove != null)
                categories.Remove(toRemove);

            IList<SelectListItem> listItems = new List<SelectListItem>(categories.Count + 1);
            listItems.Add(new SelectListItem() { Text = "", Value = "" });
            int level = 0;
            foreach (Category category in categories)
            {
                listItems.Add(new SelectListItem() { Text = category.Name, Value = category.Id.ToString() });
                AddChildCategories(category, listItems, level, excludedId);
            }
            return listItems;
        }

        private static void AddChildCategories(Category category, IList<SelectListItem> listItems, int level, int excludedId)
        {
            level++;
            var subcategories = new List<Category>();
            var toRemove = category.Subcategories.SingleOrDefault(x => x.Id == excludedId);
            foreach (Category subcategory in category.Subcategories)
            {
                if (subcategory.Equals(toRemove))
                    continue;
                subcategories.Add(subcategory);
            }
            foreach (Category subcategory in subcategories)
            {
                string indent = "";
                for (int i = 0; i < level; i++)
                {
                    indent += "-";
                }
                listItems.Add(new SelectListItem() { Text = indent + subcategory.Name, Value = subcategory.Id.ToString() });
                AddChildCategories(subcategory, listItems, level, excludedId);

            }
            level--;
        }

        public static string Description(this Enum e, Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(Description), false);

                if (attrs.Length > 0)
                    return ((Description)attrs[0]).Text;
            }
            return en.ToString();
        }

        public static bool isEmail(this string s)
        {
            const string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            return re.IsMatch(s);
        }

        public static string PageLinks(PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            TagBuilder div = new TagBuilder("div");
            div.AddCssClass("pager");
            int N = 5;
            if (pagingInfo.TotalPages < N + 1)
            {
                StringBuilder result = new StringBuilder();
                for (int i = 1; i <= pagingInfo.TotalPages; i++)
                {
                    TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag 
                    tag.MergeAttribute("href", pageUrl(i));
                    tag.InnerHtml = i.ToString();
                    if (i == pagingInfo.CurrentPage)
                        tag.AddCssClass("selected");
                    result.AppendLine(tag.ToString());
                }
                div.InnerHtml = result.ToString();
                return div.ToString();
            }
            else
            {
                StringBuilder result = new StringBuilder();
                int begin = Math.Max(pagingInfo.CurrentPage - 7, 1);
                int end = Math.Min(pagingInfo.CurrentPage + 7, pagingInfo.TotalPages);
                if (begin != 1)
                {
                    TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag 
                    tag.MergeAttribute("href", pageUrl(begin - 1));
                    tag.InnerHtml = "...";
                    result.AppendLine(tag.ToString());
                }

                for (int i = begin; i <= end; i++)
                {
                    TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag 
                    tag.MergeAttribute("href", pageUrl(i));
                    tag.InnerHtml = i.ToString();
                    if (i == pagingInfo.CurrentPage)
                        tag.AddCssClass("selected");
                    result.AppendLine(tag.ToString());
                }
                if (end != pagingInfo.TotalPages)
                {
                    TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag 
                    tag.MergeAttribute("href", pageUrl(end + 1));
                    tag.InnerHtml = "...";
                    result.AppendLine(tag.ToString());
                }
                div.InnerHtml = result.ToString();
                return div.ToString();
            }

        }

            public static string PageLinks(this HtmlHelper html,
                                                  PagingInfo pagingInfo,
                                                  Func<int, string> pageUrl)
            {
                int N = 5;
                if (pagingInfo.TotalPages < N + 1)
                {
                    StringBuilder result = new StringBuilder();
                    for (int i = 1; i <= pagingInfo.TotalPages; i++)
                    {
                        TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag 
                        tag.MergeAttribute("href", pageUrl(i));
                        tag.InnerHtml = i.ToString();
                        if (i == pagingInfo.CurrentPage)
                            tag.AddCssClass("selected");
                        result.AppendLine(tag.ToString());
                    }

                    return result.ToString();    
                }
                else
                {
                    StringBuilder result = new StringBuilder();
                    int begin = Math.Max(pagingInfo.CurrentPage - 7, 1);
                    int end = Math.Min(pagingInfo.CurrentPage + 7, pagingInfo.TotalPages);
                    if (begin != 1)
                    {
                        TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag 
                        tag.MergeAttribute("href", pageUrl(begin - 1));
                        tag.InnerHtml = "...";
                        result.AppendLine(tag.ToString());
                    }
                    
                    for (int i = begin; i <= end; i++)
                    {
                        TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag 
                        tag.MergeAttribute("href", pageUrl(i));
                        tag.InnerHtml = i.ToString();
                        if (i == pagingInfo.CurrentPage)
                            tag.AddCssClass("selected");
                        result.AppendLine(tag.ToString());
                    }
                    if (end != pagingInfo.TotalPages)
                    {
                        TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag 
                        tag.MergeAttribute("href", pageUrl(end + 1));
                        tag.InnerHtml = "...";
                        result.AppendLine(tag.ToString());
                    }
                    return result.ToString();
                }
                
            }
        

        public static string ToCurrencyString(this decimal d)
        {
            return d.ToString("C0");
        }

        public static string AdminActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues)
        {
            if (HttpContext.Current.User.IsInRole("Admin"))
                return htmlHelper.ActionLink(linkText, actionName, routeValues).ToHtmlString();
            return "";
        }

        public static string CategoryImage(this HtmlHelper htmlHelper, Image image)
        {
            if (image == null)
                return "";
            string file = image.Small;
            return string.Format("<img src=\"{0}\"/>", VirtualPathUtility.ToAbsolute("~/Content/Uploads/") + file);
        }

        public static string ProductImage(this HtmlHelper htmlHelper, Product product)
        {
            string file = product.Images.Count > 0 ? product.Images.First().Small : "";
            if (string.IsNullOrEmpty(file))
                return string.Format("<img src='{0}'/>", VirtualPathUtility.ToAbsolute("~/Content/Uploads/") + "no_image.gif");
            return string.Format("<a rel='lightbox' href='{1}'><img src=\"{0}\"/></a>", 
                VirtualPathUtility.ToAbsolute("~/Content/Uploads/") + file,
                VirtualPathUtility.ToAbsolute(product.Images.First().PathRootBasedBig));
        }

        public static string ProductImageNoLink(this HtmlHelper htmlHelper, Product product)
        {
            string file = product.Images.Count > 0 ? product.Images.First().Small : "";
            if (string.IsNullOrEmpty(file))
                return string.Format("<img src='{0}'/>", VirtualPathUtility.ToAbsolute("~/Content/Uploads/") + "no_image.gif");
            return string.Format("<img src=\"{0}\"/>", 
                VirtualPathUtility.ToAbsolute("~/Content/Uploads/") + file);
        }

        public static string ToYesNo(this bool b)
        {
            return b ? "Да" : "Нет";
        }

        public static T Clone<T>(this object source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }

        }

        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
        }

    }
}

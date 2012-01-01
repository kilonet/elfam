using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using elfam.web.Extensions;
using elfam.web.Models;

namespace elfam.web.Paging
{
    [Serializable]
    public class SearchCriteria
    {
        [Link]
        public int? PageIndex { get; set; }

        [Link]
        public string SortExpression { get; set; }

        [Link]
        public string SortDirection { get; set; }
        
        public static string PageIndexProperty = "PageIndex";
        public static string SortFieldProperty = "SortField";
        public static string SortDirectionProperty = "SortDirection";
        public static string AscSearchOrder = "asc";
        public static string DescSearchOrder = "desc";
        public int PageSize = 20;

        public string Header(string caption, string sortExpression)
        {
            SearchCriteria anotherSc;
            if (sortExpression == SortExpression)
            {
                if (SortDirection == null)
                    anotherSc = Asc();
                else
                {
                    if (SortDirection.Equals(AscSearchOrder))
                        anotherSc = Desc();
                    else
                        anotherSc = Asc();    
                }
                
            }
            else
                anotherSc = OrderBy(sortExpression);

            string highlited = "";
            if (sortExpression.Equals(SortExpression))
                highlited = " class=\"sort-highlight\" ";
            return string.Format("<a {2} href=\"{0}\">{1}</a>", Link(anotherSc), caption, highlited);
        }

        public string Link(SearchCriteria criteria)
        {
            PropertyInfo[] propertyInfos = criteria.GetType().GetProperties();
            var nameValues = new List<NameValue>();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (propertyInfo.GetCustomAttributes(typeof(LinkAttribute), false).Length > 0)
                    if (propertyInfo.GetValue(criteria, null) != null)
                    nameValues.Add(
                        new NameValue(
                            propertyInfo.Name,
                            propertyInfo.GetValue(criteria, null).ToString()));
            }
            string queryString = string.Join("&", nameValues.Select(x => x.ToString()).ToArray());
            return "" + "?" + queryString;
        }

        public SearchCriteria OrderBy(string sortExpression)
        {
            SearchCriteria another = this.Clone<SearchCriteria>();
            another.SortExpression = sortExpression;
            return another;
        }

        public SearchCriteria Asc()
        {
            SearchCriteria another = this.Clone<SearchCriteria>();
            another.SortDirection = AscSearchOrder;
            return another;
        }

        public SearchCriteria Desc()
        {
            SearchCriteria another = this.Clone<SearchCriteria>();
            another.SortDirection = DescSearchOrder;
            return another;
        }

        public string Pages(int totalPages)
        {
            return Extensions.Extensions.PageLinks(new PagingInfo()
            {
                CurrentPage = PageIndex.HasValue ? PageIndex.Value : 1,
                TotalPages = totalPages
            }, i => Link(WithPage(i)));
        }

        private SearchCriteria WithPage(int i)
        {
            SearchCriteria another = this.Clone<SearchCriteria>();
            another.PageIndex = i;
            return another;
        }
    }
}

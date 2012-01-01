using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using elfam.web.Extensions;
using elfam.web.Models;

namespace elfam.web.Paging.Income
{
    [Serializable]
    public class IncomeSearchCriteria: SearchCriteria
    {
        [Link]
        public int? CategoryId { get; set; }

        public IncomeSearchCriteria()
        {
            this.SortExpression = Models.Income.DateProperty;
            this.SortDirection = SearchCriteria.DescSearchOrder;
        }

        public IncomeSearchCriteria WithCategory(Category category)
        {
            IncomeSearchCriteria another = this.Clone<IncomeSearchCriteria>();
            if (category != null)
            {
                another.CategoryId = category.Id;
            }
            else
            {
                another.CategoryId = null;
            }
            
            // need to reset page index
            another.PageIndex = 1;
            return another;
        }
    }
}

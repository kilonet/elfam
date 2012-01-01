using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SearchCriteria = elfam.web.Paging.SearchCriteria;

namespace elfam.web.Paging.Product
{
    [Serializable]
    public class ProductListSearchCriteria : SearchCriteria
    {
        [Link]
        public int? CategoryId { get; set; }

        [Link]
        public bool IsNew { get; set; }

        public ProductListSearchCriteria()
        {
            this.SortExpression = "date";
        }
    }
}

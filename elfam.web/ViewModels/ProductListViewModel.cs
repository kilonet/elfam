using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using elfam.web.Models;
using elfam.web.Paging;

namespace elfam.web.ViewModels
{
    public class ProductListViewModel
    {
        public SearchResults<Product> Results { get; set; }
        public Category Category { get; set; }

        public bool IsNew { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using elfam.web.Controllers;
using elfam.web.Models;
using elfam.web.Paging;
using elfam.web.Paging.Product;

namespace elfam.web.ViewModels.Admin
{
    public class ProductListViewModel
    {
        public SearchResults<ProductListAdminItem> SearchResults { get; set; }
        public IList<Category> Categories { get; set; }
    }
}

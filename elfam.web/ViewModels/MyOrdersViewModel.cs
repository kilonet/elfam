using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using elfam.web.Models;

namespace elfam.web.ViewModels
{
    public class MyOrdersViewModel
    {
        public IList<Models.Order> Orders { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elfam.web.ViewModels.Order
{
    public class BillViewModel
    {
        public decimal Price { get; set; }
        public string Address { get; set; }
        public int Uid { get; set; }
        public string UserName { get; set; }
    }
}

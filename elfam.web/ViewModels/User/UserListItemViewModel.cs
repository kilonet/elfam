using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elfam.web.ViewModels.User
{
    public class UserListItemViewModel
    {
        public Models.User User { get; set; }
        public int Quantity { get; set; }
        public decimal Summ { get; set; }
        public decimal Profit { get; set; }
    }
}

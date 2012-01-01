using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using elfam.web.Models;

namespace elfam.web.ViewModels
{
    public class CheckoutViewModel
    {
        public Models.Cart Cart { get; set; }
        public Models.User User { get; set; }

    }
}

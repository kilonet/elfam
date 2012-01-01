using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace elfam.web.ViewModels.Cart
{
    public class EditAndCheckoutViewModel
    {
        public IList<CartLineViewModel> CartLines { get; set; }
    }
}

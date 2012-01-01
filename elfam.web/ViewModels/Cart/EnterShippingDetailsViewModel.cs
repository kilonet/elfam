using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using elfam.web.Models;
using elfam.web.ViewModels.User;

namespace elfam.web.ViewModels.Cart
{
    public class EnterShippingDetailsViewModel
    {
        public Models.Cart Cart { get; set; }
        public DeliverType DeliverType { get; set; }
        public PaymentType PaymentType { get; set; }
        public DeliverPrices DeliverPrices { get; set; }
        public ContactViewModel Contact { get; set; }
        [DisplayName("Комментарий к заказу")]
        [StringLength(500, ErrorMessage = "Слишком длинное значение")]
        public string Comment { get; set; }

        public Models.User User { get; set; }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using elfam.web.Models;

namespace elfam.web.ViewModels
{
    public class OrderViewModel
    {
        public IList<CartLineViewModel> CartLines { get; set; }
        public DeliverType DeliverType { get; set; }
        public PaymentType PaymentType { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Введите телефон")]
        public string Phone { get; set; }

        
    }
}

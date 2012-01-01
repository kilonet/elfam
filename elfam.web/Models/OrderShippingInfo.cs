using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using elfam.web.ViewModels.Cart;

namespace elfam.web.Models
{
    public class OrderShippingInfo
    {
        public DeliverType DeliverType { get; set; }
        public PaymentType PaymentType { get; set; }
        public Contact Contact { get; set; }
        public string Comment { get; set; }
        
        public static OrderShippingInfo From(EnterShippingDetailsViewModel viewModel)
        {
            OrderShippingInfo info = new OrderShippingInfo();            
            info.Contact = Contact.From(viewModel.Contact);
            info.DeliverType = viewModel.DeliverType;
            info.PaymentType = viewModel.PaymentType;
            info.Comment = viewModel.Comment;
            
            return info;
        }
    }
}

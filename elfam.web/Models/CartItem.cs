using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elfam.web.Models
{
    public class CartItem
    {
        
        public Product Product { get; set; }
        public int Quantity { get; set; }
        //public int CartItemId { get; set; }

        public CartItem()
        {
            Quantity = 1;
        }

        public decimal Summ()
        {
            return Product.Price*Quantity;
        }

        public override string ToString()
        {
            return Product.Name + " " + Quantity;
        }

        public decimal DiscountPrice(int discount)
        {
            return Summ() * (1 - (decimal)discount / 100);
        }
    }
}

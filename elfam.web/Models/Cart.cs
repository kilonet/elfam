using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elfam.web.Models
{
    public class Cart
    {
        public IList<CartItem> Items { get; set; }
        //public int Discount;

        public Cart()
        {
            Items = new List<CartItem>();
            //if (UserContext.User() != null)
                //Discount = UserContext.User().Discount;
        }

        public void Add(Product product, int quantity)
        {
            var productInCart = Items.SingleOrDefault(x => x.Product.Id == product.Id);
            if (productInCart == null)
                Items.Add(new CartItem(){Product = product, Quantity = quantity});
            else
            {
                productInCart.Quantity += quantity;
            }
        }

        public decimal Summ()
        {
            return Items.Sum(item => item.Product.Price*item.Quantity);
        }

        public decimal SummDiscount()
        {
            var discount = UserContext.Discount() + CurrentDiscount();
            return Items.Sum(item => item.DiscountPrice(discount));
        }

        public int CurrentDiscount()
        {
            if (Summ() > 5000)
                return 10;
            else if (Summ() > 2000)
                return 5;
            else if (Summ() > 1000)
                return 3;
            return 0;
        }

        public int CurrentQuantity(int productId)
        {
            var item = Items.SingleOrDefault(i => i.Product.Id == productId);
            if (item == null)
                return 0;
            else
                return item.Quantity;
       }
    }
}
//Product.Price * item.Quantity * (1 - (decimal)discount/100)
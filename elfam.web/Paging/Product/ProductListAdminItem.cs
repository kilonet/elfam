using System;

namespace elfam.web.Paging.Product
{
    public class ProductListAdminItem
    {
        public Models.Product Product { get; set; }
        public DateTime? Date { get; set; }
        public Int64? Quantity { get; set; }

        public ProductListAdminItem(Models.Product product, Int64? quantity, DateTime? date)
        {
            Product = product;
            Date = date;
            Quantity = quantity;
        }
    }
}
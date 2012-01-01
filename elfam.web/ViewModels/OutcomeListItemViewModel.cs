using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using elfam.web.Models;

namespace elfam.web.ViewModels
{
    public class OutcomeListItemViewModel
    {
        public int OrderLineId { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Id { get; set; }
        public int IncomeId { get; set; }
        public int Quantity { get; set; }
        public decimal SellPrice { get; set; }
        public DateTime Date { get; set; }

        public OutcomeListItemViewModel(Outcome outcome)
        {
            Id = outcome.Id;
            IncomeId = outcome.Income.Id;
            Quantity = outcome.Quantity;
            SellPrice = outcome.SellPrice;
            Date = outcome.Date;
            OrderLineId = outcome.OrderLine.Id;
            ProductName = outcome.Income.Product.Name;
            ProductId = outcome.Income.Product.Id;
            Product = outcome.Income.Product;
        }
    }
}

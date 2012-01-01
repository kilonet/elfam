using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using elfam.web.Models;

namespace elfam.web.ViewModels.Income
{
    public class IncomeListItemViewModel
    {
        public IncomeListItemViewModel(Models.Income income)
        {
            Id = income.Id;
            ProductName = income.Product.Name;
            Date = income.Date;
            QuantityCurrent = income.QuantityCurrent;
            QuantityInitial = income.QuantityInital;
            ProductId = income.Product.Id;
            BuyPrice = income.BuyPrice;
            SKU = income.Product.SKU;
            Product = income.Product;
        }

        public Product Product { get; set; }

        public int ProductId { get; set; }
        public int Id { get; set; }
        public string ProductName { get; set; }
        public DateTime Date { get; set; }
        public int QuantityCurrent { get; set; }
        public int QuantityInitial { get; set; }
        public decimal BuyPrice { get; set; }
        public string SKU { get; set; }
    }
}

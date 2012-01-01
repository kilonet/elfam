using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace elfam.web.ViewModels
{
    public class IncomeViewModel
    {
        [DisplayName("Цена закупки")]
        public decimal BuyPrice { get; set; }
        
        [Range(1, int.MaxValue)]
        [DisplayName("Товар")]
        public int ProductId { get; set; }

        [DisplayName("Количество")]
        public int Quantity { get; set; }

        public IList<SelectListItem> Products { get; set; }

        public int IncomeId { get; set; }

        public IncomeViewModel()
        {
            Products = new List<SelectListItem>();
        }

        public static IncomeViewModel From(elfam.web.Models.Income income)
        {
            IncomeViewModel model = new IncomeViewModel();
            model.BuyPrice = income.BuyPrice;
            model.IncomeId = income.Id;
            model.ProductId = income.Product.Id;
            model.Quantity = income.QuantityCurrent;
            return model;

        }
    }
}

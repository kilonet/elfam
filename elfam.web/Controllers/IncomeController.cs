using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using elfam.web.Attributes;
using elfam.web.Models;
using elfam.web.Paging.Income;
using elfam.web.Services;
using elfam.web.ViewModels;
using elfam.web.ViewModels.Income;
using NHibernate.Criterion;
using Order = NHibernate.Criterion.Order;

namespace elfam.web.Controllers
{
    public class IncomeController : BaseController
    {
        [Admin]
        public ActionResult Index()
        {
            return View();
        }

        CategoryService _categoryServise = new CategoryService();

        [Admin]
        public ActionResult List(IncomeSearchCriteria criteria)
        {
            IncomeQueryBuilder queryBuilder = new IncomeQueryBuilder(criteria);
            var result = queryBuilder.Execute(daoTemplate.Session);
            var incomes = result.Results;
            IEnumerable<IncomeListItemViewModel> viewModels = incomes.Select(income => new IncomeListItemViewModel(income));
            ViewData["searchResult"] = result;
            ViewData["categories"] = _categoryServise.AllVisibleCategories();
            return View(viewModels);
        }

        [Admin][HttpGet]
        public ActionResult Add()
        {
            IncomeViewModel viewModel = new IncomeViewModel();
            viewModel.Products = Products();
            
            return View(viewModel);
        }

        [Admin][HttpPost]
        public ActionResult Add(IncomeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Products = Products();
                return View(viewModel);
            }
            Income income = new Income();
            income.Date = DateTime.Now;
            income.BuyPrice = viewModel.BuyPrice;
            income.Product = daoTemplate.FindByID<Product>(viewModel.ProductId);
            income.Category = income.Product.Category;
            income.QuantityCurrent = viewModel.Quantity;
            income.QuantityInital = viewModel.Quantity;
            daoTemplate.Save(income);
            return RedirectToAction("List");
        }

        [Admin][HttpGet]
        public ActionResult Edit(int id)
        {
            Income income = daoTemplate.FindByID<Income>(id);
            IncomeViewModel viewModel = IncomeViewModel.From(income);
            viewModel.Products = Products();
            return View(viewModel);
        }

        [Admin]
        [HttpPost]
        public ActionResult Edit(IncomeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Products = Products();
                return View(viewModel);
            }
            Income income = daoTemplate.FindByID<Income>(viewModel.IncomeId);
            income.BuyPrice = viewModel.BuyPrice;
            income.Product = daoTemplate.FindByID<Product>(viewModel.ProductId);
            income.QuantityCurrent = viewModel.Quantity;
            daoTemplate.Save(income);
            return RedirectToAction("List");
        }

        private IList<SelectListItem> Products()
        {
            var products = daoTemplate.FindByCriteria(DetachedCriteria.For(typeof(Product)).AddOrder(Order.Asc("Name")));
            return (from Product product in products
                    select new SelectListItem() {Text = product.Name, Value = product.Id.ToString()}).ToList();
        }
    }
}

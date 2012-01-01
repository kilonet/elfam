using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using elfam.web.Models;
using Iesi.Collections.Generic;

namespace elfam.web.ViewModels
{
    public class ProductViewModel: BaseViewModel
    {
        [Required(ErrorMessage = "Ведите краткое описание")]
        [StringLength(512, ErrorMessage = "Максимальная длина 512 символов")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Ведите название")]
        [StringLength(255, ErrorMessage = "Максимальная длина 255 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Выберите категорию")]
        public int CategoryId { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть больше нуля")]
        public decimal Price { get; set; }

        [DisplayName("Артикул")]
        [StringLength(50, ErrorMessage = "Максимальная длина 50 символов")]
        public string SKU { get; set; }

        [DisplayName("Размер")]
        [StringLength(50, ErrorMessage = "Максимальная длина 50 символов")]
        public string Size { get; set; }

        [DisplayName("Вес")]
        [StringLength(50, ErrorMessage = "Максимальная длина 50 символов")]
        public string Weight { get; set; }

        [DisplayName("Цвет")]
        [StringLength(50, ErrorMessage = "Максимальная длина 50 символов")]
        public string Color { get; set; }

        [DisplayName("Страна")]
        [StringLength(50, ErrorMessage = "Максимальная длина 50 символов")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Введите описание")]
        [StringLength(5000, ErrorMessage = "Максимальная длина 5000 символов")]
        public string Description { get; set; }


        [DisplayName("Отображать товар в каталоге")]
        public bool IsVisible { get; set; }

        [DisplayName("Новинка")]
        public bool IsNew { get; set; }

        public ISet<Product> Recomended { get; set; }

        public ProductViewModel()
        {
            IsVisible = true;
            IsNew = false;
        }

        public IList<Image> Images { get; set; }

        public IList<ProductBreadCrumbViewModel> ProductBreadCrumbViewModels { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime Date { get; set; }

        public static ProductViewModel From(Product product)
        {
            ProductViewModel viewModel = new ProductViewModel();
            viewModel.CategoryId = product.Category.Id;
            viewModel.Description = product.Description;
            viewModel.ShortDescription = product.ShortDescription;
            viewModel.Id = product.Id;
            viewModel.Name = product.Name;
            viewModel.Price = product.Price;
            viewModel.Images = product.Images;
            viewModel.IsAvailable = product.IsAvailable;
            viewModel.ProductBreadCrumbViewModels = product.BreadCrumb().ToList().ConvertAll(cat => new ProductBreadCrumbViewModel(){Id = cat.Id, Name = cat.Name});
            viewModel.Date = product.Date;

            viewModel.SKU = product.SKU;
            viewModel.Size = product.Size;
            viewModel.Color = product.Color;
            viewModel.Weight = product.Weight;
            viewModel.Country = product.Country;
            viewModel.IsVisible = product.IsVisible;
            viewModel.IsNew = product.IsNew;

            viewModel.Recomended = product.Recomended;

            return viewModel;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using elfam.web.Models;

namespace elfam.web.ViewModels
{
    public class CategoryViewModel: BaseViewModel
    {
        [DisplayName("Описание")]
        [StringLength(5000, ErrorMessage = "Слишком длинное описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Введите название")]
        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Родительская категория")]
        public int? ParentId { get; set; }

        [DisplayName("Отображать категорию и её товары в каталоге")]
        public bool IsVisible { get; set; }

        public Image Image { get; set; }

        public static CategoryViewModel From(Category category)
        {
            CategoryViewModel viewModel = new CategoryViewModel();
            viewModel.Id = category.Id;
            viewModel.Name = category.Name;
            if (category.Parent != null)
                viewModel.ParentId = category.Parent.Id;
            viewModel.Description = category.Description;
            viewModel.Image = category.Image != null ? new Image(){Id = category.Image.Id} : null;
            viewModel.IsVisible = category.IsVisible;
            return viewModel;
        }

        public CategoryViewModel()
        {
            ParentId = 0;
            IsVisible = true;
        }
    }
}

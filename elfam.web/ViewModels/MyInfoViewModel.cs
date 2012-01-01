using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using elfam.web.Models;
using elfam.web.Validation;
using elfam.web.ViewModels.User;

namespace elfam.web.ViewModels
{
    public class MyInfoViewModel
    {
        [Email][DisplayName("Email")]
        [Required(ErrorMessage = "Введите Email")]
        [StringLength(255, ErrorMessage = "Слишком длинное значение")]
        public  string Email { get; set; }

        public ContactViewModel Contact { get; set; }

        [DisplayName("Подписаться на новости")]
        public bool IsSignForNews { get; set; }

        public static MyInfoViewModel From(Models.User user)
        {
            MyInfoViewModel model = new MyInfoViewModel();
            model.Contact = ContactViewModel.From(user.Contact);

            model.Email = user.Email;
            model.Contact = ContactViewModel.From(user.Contact);
            model.IsSignForNews = user.IsSignedForNews;
            return model;
        }

        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using elfam.web.Validation;
using elfam.web.ViewModels.User;

namespace elfam.web.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Password = ConfirmPassword = Email = "";
        }

        [Email]
        [Required(ErrorMessage = "Введите Email")]
        [DisplayName("Email *")]
        [StringLength(255, ErrorMessage = "Слишком длинное значение")]
        public string Email { get; set; }

        [DisplayName("Пароль *")]
        [Password]
        public string Password { get; set; }

        [DisplayName("Подтвердите пароль *" )]
        public string ConfirmPassword { get; set; }

        [DisplayName("Подписаться на новости")]
        public bool IsSignForNews { get; set; }

        public ContactViewModel Contact { get; set; }
    }
}

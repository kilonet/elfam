using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using elfam.web.Validation;

namespace elfam.web.ViewModels.Question
{
    public class QueViewModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Введите Email")]
        [StringLength(255, ErrorMessage = "Слишком длинное значение")]
        [Email]
        public string Email { get; set; }

        [Required(ErrorMessage = "Задайте вопрос")]
        [StringLength(1000, ErrorMessage = "Слишком длинное значение")]
        public string Text { get; set; }
    }
}

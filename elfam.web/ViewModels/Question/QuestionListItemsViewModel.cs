using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elfam.web.ViewModels.Question
{
    public class QuestionListItemsViewModel
    {
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public string UserName { get; set; }
        public int? UserId { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public static QuestionListItemsViewModel From(Models.Question question)
        {
            QuestionListItemsViewModel model = new QuestionListItemsViewModel();
            if (question.User != null)
            {
                model.UserId = question.User.Id;
                model.UserName = question.User.Contact.FullName;
            }
            model.ProductId = question.Product.Id;
            model.ProductName = question.Product.Name;
            model.Email = question.Email;
            model.Text = question.Text;
            model.Date = question.Date;
            return model;
        }
    }
}

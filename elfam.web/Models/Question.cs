using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elfam.web.Models
{
    public class Question: DomainEntity
    {
        public virtual string Email { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
        public virtual string Text { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual bool IsAnswered { get; set; }
        public virtual bool IsViewed { get; set; }

        public static string DateProperty = "Date";
        public static string IsAnsweredProperty = "IsAnswered";
        public static string IsViewedProperty = "IsViewed";
        

        public Question()
        {
            Date = DateTime.Now;
            IsAnswered = false;
            IsViewed = false;
        }

        public virtual string DefaultText()
        {
            return "Ваш вопрос про " + Product.Name + ": " + Environment.NewLine + Text;
        }
    }
}

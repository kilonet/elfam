using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Criterion;

namespace elfam.web.Models
{
    public class Comment: DomainEntity
    {
        public virtual string Text { get; set; }
        public virtual Image Image { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual User User { get; set; }

//        public virtual Product Product { get; set; }

        public static string ProductProperty = "Product";
        public static string DateProperty = "Date";

        public Comment()
        {
            Date = DateTime.Now;
        }

    }
}

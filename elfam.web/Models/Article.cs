using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using NHibernate.Criterion;

namespace elfam.web.Models
{
    public class Article: DomainEntity
    {
        [DisplayName("Заголовок")]
        public virtual string Title { get; set; }
        [DisplayName("Текст")]
        public virtual string Text { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        [DisplayName("Дата обновления")]
        public virtual DateTime? ManuallySetLastUpdated { get; set; }
        public virtual User Author { get; set; }
//        [DisplayName("Выводить в меню")]
//        public virtual bool IsVisible{ get; set; }
        [DisplayName("Индекс")]
        public virtual int Index { get; set; }
        [DisplayName("Место, где располагается статья или ссылка на неё")]
        public virtual ArticlePlacement Placement { get; set; }


        public static string LastUpdatedProperty = "LastUpdated";
        public static string IndexProperty = "Index";
        public static string PlacementProperty = "Placement";

        public Article()
        {
            LastUpdated = DateTime.Now;
            Placement = ArticlePlacement.Nowhere;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace elfam.web.Models.Mappings
{
    public class ArticleMapping: ClassMap<Article>
    {
        public ArticleMapping()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Text).Length(500000);
            Map(x => x.Title).Not.Nullable();
            Map(x => x.LastUpdated);
            Map(x => x.Placement);
            Map(x => x.Index);
            References(x => x.Author);
        }
    }
}

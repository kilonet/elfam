using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace elfam.web.Models.Mappings
{
    public class CategoryMapping: ClassMap<Category>
    {
        public CategoryMapping()
        {
            Table("category");
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Name).Not.Nullable().Length(255);
            Map(x => x.Description).Length(5000);
            Map(x => x.IsVisible);
            References(x => x.Image);
            References(x => x.Parent).Nullable().Cascade.SaveUpdate();
            HasMany(x => x.Subcategories).Fetch.Subselect().Cascade.SaveUpdate();
        }
    }
}

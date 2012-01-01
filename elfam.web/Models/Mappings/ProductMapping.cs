using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using FluentNHibernate.MappingModel.Collections;

namespace elfam.web.Models.Mappings
{
    public class ProductMapping: ClassMap<Product>
    {
        public ProductMapping()
        {
            Table("products");
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Name).Not.Nullable().Length(255);
            Map(x => x.Description).Not.Nullable().Length(5000);
            Map(x => x.ShortDescription).Not.Nullable().Length(512);
            Map(x => x.Price).Not.Nullable();
            Map(x => x.Date);
            Map(x => x.SKU).Length(50);
            Map(x => x.Size).Length(50);
            Map(x => x.Weight).Length(50);
            Map(x => x.Color).Length(50);
            Map(x => x.Country).Length(50);
            Map(x => x.IsVisible);
            Map(x => x.IsNew);
            References(x => x.Category).Not.Nullable();
            HasMany(x => x.Images).Not.LazyLoad().Fetch.Subselect().Cascade.AllDeleteOrphan();
            HasMany(x => x.Incomes).Inverse();
            HasManyToMany(x => x.Recomended).ParentKeyColumn("recomended_product_id").AsSet();
        }
    }
}

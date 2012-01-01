using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace elfam.web.Models.Mappings
{
    public class OrderLineMapping: ClassMap<OrderLine>
    {
        public OrderLineMapping()
        {
            Table("order_line");
            Id(x => x.Id).GeneratedBy.Increment();
            References(x => x.Product);
            Map(x => x.Price).Not.Nullable();
            Map(x => x.ProductName).Not.Nullable().Length(255);
            Map(x => x.Quantity).Not.Nullable();
            HasMany(x => x.Outcomes).Cascade.AllDeleteOrphan();
            References(x => x.Order);
            Map(x => x.Profit);
            Map(x => x.SummWithDiscount);
        }
    }
}

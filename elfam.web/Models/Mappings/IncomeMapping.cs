using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace elfam.web.Models.Mappings
{
    public class IncomeMapping: ClassMap<Income>
    {
        public IncomeMapping()
        {
            Table("income");
            Id(x => x.Id).GeneratedBy.Increment();
            References(x => x.Product);
            References(x => x.Category);
            Map(x => x.BuyPrice).Not.Nullable();
            Map(x => x.Date).Not.Nullable();
            Map(x => x.QuantityCurrent);
            Map(x => x.QuantityInital);
            HasMany(x => x.Outcomes);
        }
    }
}

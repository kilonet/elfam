using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace elfam.web.Models.Mappings
{
    public class DeliverPricesMapping: ClassMap<DeliverPrices>
    {
        public DeliverPricesMapping()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.CourierMoscow);
            Map(x => x.CourierSubMoscow);
            Map(x => x.Post);
            Map(x => x.Self);
        }
    }
}

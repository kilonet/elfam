using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace elfam.web.Models.Mappings
{
    public class OutcomeMapping: ClassMap<Outcome>
    {
        public  OutcomeMapping()
        {
            Table("outcome");
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Quantity);
            Map(x => x.SellPrice);
            Map(x => x.Date);
            Map(x => x.Discount);
            Map(x => x.SummWithDiscount);
            Map(x => x.Profit);
            Map(x => x.DiscountSumm);
            Map(x => x.Summ);
            References(x => x.Income);
            References(x => x.OrderLine);
        }
    }
}

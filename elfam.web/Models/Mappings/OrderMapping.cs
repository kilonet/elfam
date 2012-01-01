using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace elfam.web.Models.Mappings
{
    public class OrderMapping: ClassMap<Order>
    {
        public OrderMapping()
        {
            Table("orders");
            Id(x => x.Id).GeneratedBy.Increment();
            References(x => x.User);
            HasMany(x => x.Lines).Cascade.SaveUpdate();
            Map(x => x.DeliverType);
            Map(x => x.PaymentType);
            Map(x => x.Status);
            Map(x => x.Date);
            Map(x => x.Uid).Unique();
            Map(x => x.Discount);
            Map(x => x.Summ);
            Map(x => x.Comment).Length(500);
            Map(x => x.SummWithDiscount);
            Map(x => x.Profit);
            Map(x => x.DiscountSumm);
            Map(x => x.DeliverPrice);
            Component(x => x.ShippingDetails, m =>
                                                  {
                                                      m.Map(x => x.City);
                                                      m.Map(x => x.Country);
                                                      m.Map(x => x.House).Length(50);
                                                      m.Map(x => x.Room).Length(50);
                                                      m.Map(x => x.Street);
                                                      m.Map(x => x.Zip).Length(50);
                                                      m.Map(x => x.Region);

                                                      m.Map(x => x.Name).Not.Nullable().Length(255);
                                                      m.Map(x => x.Surname).Not.Nullable().Length(255);
                                                      m.Map(x => x.Phone).Nullable().Length(255);
                                                  });
        }
    }
}


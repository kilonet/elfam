using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using FluentNHibernate.MappingModel.ClassBased;

namespace elfam.web.Models.Mappings
{
    public class UserMapping: ClassMap<User>
    {
        public UserMapping()
        {
            Table("users");
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Email).Not.Nullable().Length(255).Unique();
            Map(x => x.PasswordHash).Not.Nullable();
            Map(x => x.Role).Not.Nullable();
            Map(x => x.IsSignedForNews);
            Map(x => x.Discount);
            Map(x => x.CanLogin);
            Component(x => x.Contact, m =>
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
                                          }
            );
            HasMany(x => x.Orders);
        }
    }
}

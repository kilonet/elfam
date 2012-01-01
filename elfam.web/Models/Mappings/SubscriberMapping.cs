using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace elfam.web.Models.Mappings
{
    public class SubscriberMapping: ClassMap<Subscriber>
    {
        public SubscriberMapping()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Email).Not.Nullable().Length(255);
            Map(x => x.IsActive).Not.Nullable();
        }
    }
}

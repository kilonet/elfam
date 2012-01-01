using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace elfam.web.Models.Mappings
{
    public class UniqueIdMapping: ClassMap<UniqueId>
    {
        public UniqueIdMapping()
        {
            Table("xxxsstt");
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Uid);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace elfam.web.Models.Mappings
{
    public class ImageMapping: ClassMap<Image>
    {
        public ImageMapping()
        {
            Table("images");
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.PathRootBased);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace elfam.web.Models.Mappings
{
    public class CommentMapping: ClassMap<Comment>
    {
        public CommentMapping()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            Table("comments");
            Map(x => x.Date);
            Map(x => x.Text).Length(512);
            References(x => x.User);
            References(x => x.Image);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace elfam.web.Models.Mappings
{
    public class QuestionMapping: ClassMap<Question>
    {
        public QuestionMapping()
        {
            Table("question");
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Email).Length(255);
            Map(x => x.Text).Length(1000);
            Map(x => x.Date);
            Map(x => x.IsAnswered);
            Map(x => x.IsViewed);
            References(x => x.User).Nullable();
            References(x => x.Product);
        }
    }
}

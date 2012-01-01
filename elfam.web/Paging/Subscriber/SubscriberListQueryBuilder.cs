using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elfam.web.Paging.Subscriber
{
    public class SubscriberListQueryBuilder : QueryBuilder<Models.Subscriber>
    {
        public SubscriberListQueryBuilder(SubscriberListSearchCriteria criteria) : base(criteria)
        {
        }

        protected override Dictionary<string, string> initAliases()
        {
            return new Dictionary<string, string>()
                       {
                           {"email", "s.Email"},
                           {"active", "s.IsActive"}
                       };
        }

        protected override string getTotalCountHql()
        {
            return "select count (s.Id) from Subscriber s";
        }

        protected override string getHql()
        {
            return "from Subscriber s";
        }
    }
}

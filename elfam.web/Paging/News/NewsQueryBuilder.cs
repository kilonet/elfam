using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using elfam.web.Models;

namespace elfam.web.Paging.News
{
    public class NewsQueryBuilder: QueryBuilder<Article>
    {
        public NewsQueryBuilder(SearchCriteria criteria) : base(criteria)
        {
        }

        protected override Dictionary<string, string> initAliases()
        {
            return new Dictionary<string, string>();
        }

        protected override string getTotalCountHql()
        {
            return "select count(a.Id) from Article a where a.Placement = 'News'";
        }

        protected override string getHql()
        {
            return "select a from Article a where a.Placement = 'News' order by a.LastUpdated desc";
        }
    }
}

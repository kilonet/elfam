using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elfam.web.Paging.Comment
{
    public class CommentListQueryBuilder : QueryBuilder<Models.Comment>
    {
        public CommentListQueryBuilder(SearchCriteria criteria) : base(criteria)
        {
        }

        protected override Dictionary<string, string> initAliases()
        {
            return new Dictionary<string, string>()
                       {
                           {"date", "c.Date"}
                       };
        }

        protected override string getTotalCountHql()
        {
            string hql = "select count(c.Id) from Comment c";
            var conditions = new List<string>();
            WhereHqlBuilder whereHqlBuilder = new WhereHqlBuilder(hql, conditions);
            return whereHqlBuilder.Hql();
        }

        protected override string getHql()
        {
            string hql = "select c from Comment c";
            var conditions = new List<string>();
            WhereHqlBuilder whereHqlBuilder = new WhereHqlBuilder(hql, conditions);
            return whereHqlBuilder.Hql();
        }
    }
}

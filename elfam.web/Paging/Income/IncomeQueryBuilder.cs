using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using elfam.web.Dao;
using elfam.web.Models;

namespace elfam.web.Paging.Income
{
    public class IncomeQueryBuilder: QueryBuilder<Models.Income>
    {
        private Category _category;
        DaoTemplate _daoTemplate = new DaoTemplate();

        public IncomeQueryBuilder(IncomeSearchCriteria criteria) : base(criteria)
        {
            if (criteria.CategoryId.HasValue)
            {
                _category = _daoTemplate.FindByID<Category>(criteria.CategoryId);
            }
        }

        protected override Dictionary<string, string> initAliases()
        {
            return new Dictionary<string, string>()
                       {
                           { "category", "i.Category.Id" },
                           { Models.Income.DateProperty, "i.Date" }
                       };
        }

        protected override string getTotalCountHql()
        {
            string hql = string.Format("select count(i.Id) from Income i ");
            var conditions = new List<string>();
            if (_category != null)
            {
                conditions.Add("i.Category.Id = " + _category.Id);
            }
            WhereHqlBuilder whereHqlBuilder = new WhereHqlBuilder(hql, conditions);
            return whereHqlBuilder.Hql();
        }

        protected override string getHql()
        {
            string hql = string.Format("select i from Income i ");
            var conditions = new List<string>();
            if (_category != null)
            {
                conditions.Add("i.Category.Id = " + _category.Id );
            }
            WhereHqlBuilder whereHqlBuilder = new WhereHqlBuilder(hql, conditions);
            return whereHqlBuilder.Hql();
        }
    }
}

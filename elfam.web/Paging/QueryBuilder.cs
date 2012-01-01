using System;
using System.Collections.Generic;
using elfam.web.Dao;
using NHibernate;

namespace elfam.web.Paging
{
    public abstract class QueryBuilder<T>
    {
        protected SearchCriteria _searchCriteria;
        protected DaoTemplate DaoTemplate;
        

        protected QueryBuilder(SearchCriteria criteria)
        {
            _searchCriteria = criteria;
            DaoTemplate = new DaoTemplate();
        }

        protected abstract Dictionary<string, string> initAliases();
        
        public SearchResults<T> Execute(ISession session)
        {
            string hql = getHql();
            hql = applyOrder(hql);
            IQuery query = session.CreateQuery(hql);
            int totalCount = (int) session.CreateQuery(getTotalCountHql()).UniqueResult<Int64>();
            int pageCount = (int)Math.Ceiling((float)totalCount / _searchCriteria.PageSize);
            applyPaging(query);
            return new SearchResults<T>(pageCount, _searchCriteria, query.List<T>());
        }

        protected abstract string getTotalCountHql();

        private void applyPaging(IQuery query)
        {
            if (!_searchCriteria.PageIndex.HasValue)
                query.SetFirstResult(0);
            else
                query.SetFirstResult(_searchCriteria.PageSize*(_searchCriteria.PageIndex.Value - 1));
            query.SetMaxResults(_searchCriteria.PageSize);
        }

        protected virtual string applyOrder(string hql)
        {
            if (string.IsNullOrEmpty(_searchCriteria.SortExpression))
                return hql;
            Dictionary<string, string> aliases = initAliases();
            if (!aliases.ContainsKey(_searchCriteria.SortExpression))
                return hql;
            
            string direction = string.IsNullOrEmpty(_searchCriteria.SortDirection) ? SearchCriteria.AscSearchOrder : _searchCriteria.SortDirection;
            string order = string.Format(" order by {0} {1} ", aliases[_searchCriteria.SortExpression], direction);
            return hql + order;
        }

        protected abstract string getHql();

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using elfam.web.Models;
using elfam.web.Paging;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using NHibernate.Type;
using Order = elfam.web.Models.Order;

namespace elfam.web.Dao
{
    public class DaoTemplate: IDaoTemplate
    {
        public ISession Session { get { return NHibernateSessionPerRequest.GetCurrentSession(); } }

        public bool IsTemporary(object obj)
        {
            return !Session.Contains(obj);
        }

        public T Save<T>(T entity) where T : DomainEntity
        {
            Session.SaveOrUpdate(entity);
            return entity;
        }

        public T CheckAndUpdate<T>(T entity) where T : DomainEntity
        {
            if (Session.Contains(entity))
            {
                // Evicting entity to force opt.locking check
                Evict(entity);
            }
            return Save(entity);
        }

        

        public IList<T> FindAll<T>() where T : DomainEntity
        {
            return DetachedCriteria.For(typeof(T))
                    .GetExecutableCriteria(Session).List<T>();
        }

        public object Get(string entityName, object id)
        {
            return Session.Get(entityName, id);
        }

        public T FindByID<T>(object id) where T : DomainEntity
        {
            return Session.Get<T>(id);
        }

        public void Remove<T>(T entity) where T : DomainEntity
        {
            Session.Delete(entity);
        }

        //public void LoadAndRemove<T>(T entity) where T : DomainEntity
        //{
        //    T reloadedEntity = Session.Get<T>(entity.Id);
        //    if (reloadedEntity == null || reloadedEntity.Version != entity.Version)
        //    {
        //        throw new ConcurrencyFailureException("Object was modified since loading: " + entity);
        //    }
        //    Session.Delete(reloadedEntity);
        //}

        public void Evict<T>(T obj) where T : DomainEntity
        {
            Session.Evict(obj);
        }

        public void Clear()
        {
            Session.Clear();
        }

        public void Flush()
        {
            Session.Flush();
        }

        public IList<T> FindAllByFields<T>(IDictionary<string, object> parameters, int start, int max) where T : DomainEntity
        {
            DetachedCriteria q = DetachedCriteria.For(typeof(T));
            q = AddParams(q, parameters);
            return FindByCriteria<T>(q, start, max);
        }

        public int GetCount<T>() where T : DomainEntity
        {
            DetachedCriteria q = DetachedCriteria.For(typeof(T));
            q.SetProjection(Projections.Count("Id"));
            return q.GetExecutableCriteria(Session).UniqueResult<int>();
        }

        public int GetCount(DetachedCriteria q)
        {
            q.SetProjection(Projections.Count("Id"));
            return q.GetExecutableCriteria(Session).UniqueResult<int>();
        }

        public IList<T> FindAllByFields<T>(IDictionary<string, object> parameters) where T : DomainEntity
        {
            return FindAllByFields<T>(parameters, 0, -1);
        }

        public IList<T> FindAllByField<T>(string name, object value) where T : DomainEntity
        {
            return FindAllByFields<T>(new Dictionary<string, object> { { name, value } });
        }

        public T FindByFieldScalarOrThrow<T>(string name, object value) where T : DomainEntity
        {
            DetachedCriteria q = DetachedCriteria.For(typeof(T));
            q.Add(Restrictions.Eq(name, value));
            IList<T> list = q.GetExecutableCriteria(Session).List<T>();
            return getScalarResult(list);
        }

        public T FindByFieldsScalarOrThrow<T>(IDictionary<string, object> parameters) where T : DomainEntity
        {
            IList<T> list = FindAllByFields<T>(parameters, 0, 2);
            return getScalarResult(list);
        }

        public IList<T> ExecuteQuery<T>(string queryString, IEnumerable values) where T : DomainEntity
        {
            return ExecuteQuery<T>(queryString, values, -1, -1);
        }

        public T ExecuteQueryScalar<T>(string queryString, IEnumerable values) where T : DomainEntity
        {
            return getScalarResult(ExecuteQuery<T>(queryString, values, -1, -1));
        }

        public IList<T> ExecuteQuery<T>(string queryString, IEnumerable values, int start, int max) where T : DomainEntity
        {
            IQuery query = Session.CreateQuery(queryString);

            query = AddParams(query, values);
            query = Limit(query, start, max);
            return query.List<T>();
        }

        public IList<T> ExecuteQuery<T>(string queryString, IDictionary<string, object> parameters, int start, int max, IResultTransformer resultTransformer) where T : DomainEntity
        {
            IQuery query = Session.CreateQuery(queryString);

            query = AddParams(query, parameters);
            query = Limit(query, start, max);
            IList<T> result;
            if (resultTransformer != null)
            {
                result = (IList<T>)resultTransformer.TransformList(query.List());
            }
            else
            {
                result = query.List<T>();
            }

            return result;
        }

        public IList ExecuteQuery(string queryString, IEnumerable parameters)
        {
            IQuery query = Session.CreateQuery(queryString);
            query = AddParams(query, parameters);
            return query.List();
        }

        public IList<T> ExecuteQuery<T>(string queryString, IDictionary<string, object> parameters, int start, int max) where T : DomainEntity
        {
            return ExecuteQuery<T>(queryString, parameters, start, max, null);
        }

        public IList<T> ExecuteQuery<T>(string queryString, IDictionary<string, object> parameters) where T : DomainEntity
        {
            return ExecuteQuery<T>(queryString, parameters, 0, -1, null);
        }

        public T ExecuteQueryScalar<T>(string queryString, IDictionary<string, object> parameters) where T : DomainEntity
        {
            return getScalarResult(ExecuteQuery<T>(queryString, parameters));
        }

        // Criteria finders
        public IList<T> FindByCriteria<T>(DetachedCriteria criteria, int start, int max)
        {
            criteria = Limit(criteria, start, max);
            return criteria.GetExecutableCriteria(Session).List<T>();
        }

        public IList FindByCriteria(DetachedCriteria criteria, int start, int max)
        {
            criteria = Limit(criteria, start, max);
            return criteria.GetExecutableCriteria(Session).List();
        }

        public IList<T> FindByCriteria<T>(DetachedCriteria criteria)
        {
            return FindByCriteria<T>(criteria, 0, -1);
        }

        public T FindUniqueByCriteria<T>(DetachedCriteria criteria)
        {
            try
            {
                return criteria.GetExecutableCriteria(Session).UniqueResult<T>();
            }
            catch (NHibernate.NonUniqueResultException ex)
            {
                throw;
            }
        }

        public T FindUniqueByField<T>(string fieldName, object fieldValue)
        {
            return FindUniqueByCriteria<T>(DetachedCriteria.For<T>().Add(Restrictions.Eq(fieldName, fieldValue)));
        }


//        public IList<T> FindByQueryBuilder<T>(ProductAdminListQueryBuilder queryBuilder) where T : DomainEntity
//        {
//            return queryBuilder.executeQuery(this);
//        }

        public T ExecuteNativeQueryScalar<T>(string query, string selectFieldName, IType selectFieldType, IDictionary<string, object> parameters)
        {
            ISQLQuery sqlQuery = Session.CreateSQLQuery(query);

            sqlQuery.AddScalar(selectFieldName, selectFieldType);

            AddParams(sqlQuery, parameters);


            return getScalarResult(sqlQuery.List<T>());
        }

        public void Initialize(object lazyObject)
        {
            NHibernateUtil.Initialize(lazyObject);
        }

        protected T getScalarResult<T>(IList<T> list)
        {
            if (list == null || list.Count <= 0)
            {
                return default(T);
            }
            if (list.Count == 1)
            {
                return list[0];
            }
            throw new NonUniqueResultException(list.Count);
        }

        protected IQuery AddParams(IQuery query, IDictionary<String, Object> parameters)
        {
            if (parameters != null)
            {
                foreach (String key in parameters.Keys)
                {
                    Object value = parameters[key];
                    if (value is ICollection)
                    {
                        query = query.SetParameterList(key, value as ICollection);
                    }
                    else
                    {
                        query = query.SetParameter(key, value);
                    }
                }
            }
            return query;
        }

        protected IQuery AddParams(IQuery query, IEnumerable values)
        {
            if (values != null)
            {
                int index = 0;
                foreach (object value in values)
                {
                    query = query.SetParameter(index++, value);
                }
            }
            return query;
        }

        protected DetachedCriteria AddParams(DetachedCriteria criteria, IDictionary<String, Object> parameters)
        {
            if (parameters != null)
            {
                foreach (String key in parameters.Keys)
                {
                    Object value = parameters[key];
                    criteria = criteria.Add(Restrictions.Eq(key, value));
                }
            }
            return criteria;
        }

        protected IQuery Limit(IQuery query, int start, int max)
        {
            if (start >= 1)
            {
                query.SetFirstResult(start);
            }
            if (max >= 0)
            {
                query.SetMaxResults(max);
            }
            return query;
        }

        protected DetachedCriteria Limit(DetachedCriteria criteria, int start, int max)
        {
            if (start >= 1)
            {
                criteria.SetFirstResult(start);
            }
            if (max >= 0)
            {
                criteria.SetMaxResults(max);
            }
            return criteria;
        }


        public IList FindByCriteria(DetachedCriteria criteria)
        {
            return criteria.GetExecutableCriteria(Session).List();
        }

        public Order FindOrderByUid(int uid)
        {
            return FindUniqueByField<Order>(Order.UidProperty, uid);
        }

        #region IDaoTemplate Members


        public void LoadAndRemove<T>(T entity) where T : DomainEntity
        {
            throw new NotImplementedException();
        }

        public SearchResults<T> FindByQueryBuilder<T>(QueryBuilder<T> queryBuilder) where T : DomainEntity
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}


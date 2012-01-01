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

namespace elfam.web.Dao
{
    public interface IDaoTemplate
    {

        bool IsTemporary(object obj);

        T Save<T>(T entity) where T : DomainEntity;

        T CheckAndUpdate<T>(T entity) where T : DomainEntity;

        IList<T> FindAll<T>() where T : DomainEntity;

        T FindByID<T>(object id) where T : DomainEntity;

        void Remove<T>(T entity) where T : DomainEntity;

        void LoadAndRemove<T>(T entity) where T : DomainEntity;

        void Evict<T>(T obj) where T : DomainEntity;

        /**
         * Clears the whole HibernateSession (caches and pending operations).
         * Use only for testing purpose.
         */
        void Clear();

        void Flush();

        IList<T> FindAllByFields<T>(IDictionary<string, object> parameters, int start, int max) where T : DomainEntity;

        int GetCount<T>() where T : DomainEntity;

        IList<T> FindAllByFields<T>(IDictionary<string, object> parameters) where T : DomainEntity;

        IList<T> FindAllByField<T>(String name, object value) where T : DomainEntity;

        T FindByFieldScalarOrThrow<T>(String name, Object value) where T : DomainEntity;

        T FindByFieldsScalarOrThrow<T>(IDictionary<string, object> parameters) where T : DomainEntity;

        IList<T> ExecuteQuery<T>(String queryString, IEnumerable values) where T : DomainEntity;

        T ExecuteQueryScalar<T>(String queryString, IEnumerable values) where T : DomainEntity;

        IList<T> ExecuteQuery<T>(String queryString, IEnumerable values, int start, int max) where T : DomainEntity;

        IList<T> ExecuteQuery<T>(string queryString, IDictionary<string, object> parameters, int start, int max, IResultTransformer resultTransformer) where T : DomainEntity;

        IList<T> ExecuteQuery<T>(String queryString, IDictionary<String, Object> parameters) where T : DomainEntity;

        T ExecuteQueryScalar<T>(String queryString, IDictionary<String, Object> parameters) where T : DomainEntity;

        IList<T> ExecuteQuery<T>(String queryString, IDictionary<String, Object> parameters, int start, int max) where T : DomainEntity;

        IList<T> FindByCriteria<T>(DetachedCriteria criteria, int start, int max);

        IList<T> FindByCriteria<T>(DetachedCriteria criteria);

        T FindUniqueByCriteria<T>(DetachedCriteria criteria);

        T FindUniqueByField<T>(string fieldName, object fieldValue);

        SearchResults<T> FindByQueryBuilder<T>(QueryBuilder<T> queryBuilder) where T : DomainEntity;

        T ExecuteNativeQueryScalar<T>(string query, string fieldname, IType fieldType, IDictionary<string, object> parameters);

        void Initialize(object lazyObject);

        #region MyShit

        ISession Session { get; }

        Models.Order FindOrderByUid(int id);

        int GetCount(DetachedCriteria q);

        IList FindByCriteria(DetachedCriteria criteria);

        #endregion
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using elfam.web.Controllers;
using elfam.web.Dao;
using elfam.web.Models;
using elfam.web.Paging;
using elfam.web.ViewModels;
using Moq;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using NHibernate.Type;
using NUnit.Framework;
using Order = elfam.web.Models.Order;

namespace elfam.web.tests
{
    [TestFixture]
    class CategoryControllerTest
    {
        [Test]
        public void TestCreateCategory()
        {
            CategoryController controller = new CategoryController();
            var model = new CategoryViewModel(){Description = "", Name = "", ParentId = 10};
            var daoTemplate = new SaveCategoryFakeDao();
            controller.DaoTemplate = daoTemplate;
            controller.Create(model);
        }
    }

    internal class SaveCategoryFakeDao: IDaoTemplate
    {
        public bool IsTemporary(object obj)
        {
            throw new NotImplementedException();
        }

        public T Save<T>(T entity) where T : DomainEntity
        {
            if (entity is Category)
            {
                Category category = entity as Category;
                Assert.IsTrue(category.Parent != null);
            }
            return default(T);
        }

        public T CheckAndUpdate<T>(T entity) where T : DomainEntity
        {
            throw new NotImplementedException();
        }

        public IList<T> FindAll<T>() where T : DomainEntity
        {
            throw new NotImplementedException();
        }

        public T FindByID<T>(object id) where T : DomainEntity
        {
            return new Category() {Id = (int)id} as T;
            throw new NotImplementedException();
        }

        public void Remove<T>(T entity) where T : DomainEntity
        {
            throw new NotImplementedException();
        }

        public void LoadAndRemove<T>(T entity) where T : DomainEntity
        {
            throw new NotImplementedException();
        }

        public void Evict<T>(T obj) where T : DomainEntity
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Flush()
        {
            throw new NotImplementedException();
        }

        public IList<T> FindAllByFields<T>(IDictionary<string, object> parameters, int start, int max) where T : DomainEntity
        {
            throw new NotImplementedException();
        }

        public int GetCount<T>() where T : DomainEntity
        {
            throw new NotImplementedException();
        }

        public IList<T> FindAllByFields<T>(IDictionary<string, object> parameters) where T : DomainEntity
        {
            throw new NotImplementedException();
        }

        public IList<T> FindAllByField<T>(string name, object value) where T : DomainEntity
        {
            throw new NotImplementedException();
        }

        public T FindByFieldScalarOrThrow<T>(string name, object value) where T : DomainEntity
        {
            throw new NotImplementedException();
        }

        public T FindByFieldsScalarOrThrow<T>(IDictionary<string, object> parameters) where T : DomainEntity
        {
            throw new NotImplementedException();
        }

        public IList<T> ExecuteQuery<T>(string queryString, IEnumerable values) where T : DomainEntity
        {
            throw new NotImplementedException();
        }

        public T ExecuteQueryScalar<T>(string queryString, IEnumerable values) where T : DomainEntity
        {
            throw new NotImplementedException();
        }

        public IList<T> ExecuteQuery<T>(string queryString, IEnumerable values, int start, int max) where T : DomainEntity
        {
            throw new NotImplementedException();
        }

        public IList<T> ExecuteQuery<T>(string queryString, IDictionary<string, object> parameters) where T : DomainEntity
        {
            throw new NotImplementedException();
        }

        public T ExecuteQueryScalar<T>(string queryString, IDictionary<string, object> parameters) where T : DomainEntity
        {
            throw new NotImplementedException();
        }

        public IList<T> ExecuteQuery<T>(string queryString, IDictionary<string, object> parameters, int start, int max) where T : DomainEntity
        {
            throw new NotImplementedException();
        }

        public T FindUniqueByField<T>(string fieldName, object fieldValue)
        {
            throw new NotImplementedException();
        }

        public SearchResults<T> FindByQueryBuilder<T>(QueryBuilder<T> queryBuilder) where T : DomainEntity
        {
            throw new NotImplementedException();
        }

        public void Initialize(object lazyObject)
        {
            throw new NotImplementedException();
        }

        public ISession Session
        {
            get { throw new NotImplementedException(); }
        }

        public Order FindByUid(string id)
        {
            throw new NotImplementedException();
        }

        public IList FindByCriteria(DetachedCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public Order FindOrderByUid(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCount(DetachedCriteria q)
        {
            throw new NotImplementedException();
        }

        public T ExecuteNativeQueryScalar<T>(string query, string fieldname, IType fieldType, IDictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public T FindUniqueByCriteria<T>(DetachedCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public IList<T> FindByCriteria<T>(DetachedCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public IList<T> FindByCriteria<T>(DetachedCriteria criteria, int start, int max)
        {
            throw new NotImplementedException();
        }

        public IList<T> ExecuteQuery<T>(string queryString, IDictionary<string, object> parameters, int start, int max, IResultTransformer resultTransformer) where T : DomainEntity
        {
            throw new NotImplementedException();
        }
    }
}

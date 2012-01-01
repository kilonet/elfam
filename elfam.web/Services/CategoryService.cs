using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using elfam.web.Models;
using NHibernate;
using NHibernate.Criterion;

namespace elfam.web.Services
{
    public class CategoryService: BaseService
    {
        public IList<Category> FindRootCategories()
        {
            return daoTemplate.ExecuteQuery<Category>("from Category c where c.Parent = null", null);
        }

        public IList<Category> AllVisibleCategories()
        {
            return daoTemplate.ExecuteQuery<Category>("from Category c where c.IsVisible = 't'", null);
        }
    }
}

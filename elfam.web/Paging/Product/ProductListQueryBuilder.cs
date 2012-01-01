using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using elfam.web.Models;
using elfam.web.Services;
using Microsoft.Practices.Unity;

namespace elfam.web.Paging.Product
{
    public class ProductListQueryBuilder: QueryBuilder<Models.Product>
    {
        private Category _category;
        private string isNewCriteria;

        
        private CategoryService CategoryService = new CategoryService();
        private IList<Category> categories;


        public ProductListQueryBuilder(ProductListSearchCriteria criteria)
            : base(criteria)
        {
            if (criteria.CategoryId.HasValue)
                _category = DaoTemplate.FindByID<Category>(criteria.CategoryId);

            isNewCriteria = criteria.IsNew ? " and p.IsNew = 't' " : " ";

            categories = _category == null ? CategoryService.AllVisibleCategories() : _category.ThisAndSubcategories();
        }

        protected override Dictionary<string, string> initAliases()
        {
            return new Dictionary<string, string>()
                       {
                           {"name", "p.Name"},
                           {"price", "p.Price"},
                           {"date", "p.Date"},
                           {"category", "p.Category.Name"}
                       };
        }

        protected override string getTotalCountHql()
        {
            return string.Format("select count(p.Id) from Product p where p.Category.Id in ({0}) and p.Category.IsVisible = 't' and p.IsVisible = 't'" + isNewCriteria, 
                string.Join(",", categories.Select(x => x.Id.ToString()).ToArray()));
            
        }

        protected override string getHql()
        {
            return @"select p
                from Product p left join p.Incomes inc
                where p.Category.Id in (" + string.Join(",", categories.Select(x => x.Id.ToString()).ToArray()) + @") and p.Category.IsVisible = 't' and p.IsVisible = 't'"
                                          + isNewCriteria + @" 
                group by p.Id, p.Name, p.Description, p.ShortDescription, p.Price, p.IsVisible, p.Date, p.Category, p.Category.Name, p.Category.IsVisible, p.IsNew, p.SKU,
                p.Size, p.Weight, p.Color, p.Country";

        }

//        protected override string applyOrder(string hql)
//        {
//            if (string.IsNullOrEmpty(_searchCriteria.SortExpression))
//                return hql;
//            Dictionary<string, string> aliases = initAliases();
//            if (!aliases.ContainsKey(_searchCriteria.SortExpression))
//                return hql;
//
//            string direction = string.IsNullOrEmpty(_searchCriteria.SortDirection) ? SearchCriteria.AscSearchOrder : _searchCriteria.SortDirection;
//            string order = string.Format(" ,{0} {1} ", aliases[_searchCriteria.SortExpression], direction);
//            return hql + order;
//        }
    }
}

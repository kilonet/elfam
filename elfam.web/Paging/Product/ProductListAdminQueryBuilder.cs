using System.Collections.Generic;
using System.Linq;
using elfam.web.Dao;
using elfam.web.Models;

namespace elfam.web.Paging.Product
{
    public class ProductListAdminQueryBuilder: QueryBuilder<ProductListAdminItem>
    {
        private Category _category;
        DaoTemplate _daoTemplate = new DaoTemplate();

        public ProductListAdminQueryBuilder(ProductListAdminSearchCriteria criteria)
            : base(criteria)
        {
            if (criteria.CategoryId.HasValue)
                _category = _daoTemplate.FindByID<Category>(criteria.CategoryId);
        }

        protected override Dictionary<string, string> initAliases()
        {
            return new Dictionary<string, string>
                                                     {
                                                         {"p", "p.Name"},
                                                         {"sku", "p.SKU"},
                                                         {"sum", "sum(inc.QuantityCurrent)"},
                                                         {"date", "max(inc.Date)"},
                                                         {"category", "p.Category.Name"}
                                                     };
        }

        protected override string getTotalCountHql()
        {
            string hql = @"select count(p.Id) from Product p";

            if (_category != null)
            {
                var subs = new List<Category>();
                subs.Add(_category);
                subs.AddRange(_category.AllSubCategories());
                hql += string.Format(" where p.Category.Id in ({0}) ", string.Join(",", subs.Select(x => x.Id.ToString()).ToArray()));
            }
            return hql;
        }

        protected override string getHql()
        {
            string categoryHql = "";
            if (_category != null)
            {
                var subs = new List<Category>();
                subs.Add(_category);
                subs.AddRange(_category.AllSubCategories());
                categoryHql = string.Format(" where p.Category.Id in ({0}) ", string.Join(",", subs.Select(x => x.Id.ToString()).ToArray()));
            }

            string hql = string.Format(@"select new ProductListAdminItem(p, sum(inc.QuantityCurrent), max(inc.Date))
                from Product p left join p.Incomes inc {0} 
                group by p.Id, p.IsNew, p.IsVisible, p.Name, p.Description, p.ShortDescription, p.Price, p.Date, p.Category, p.Category.Name, p.SKU, p.Size, p.Weight, p.Color, p.Country", categoryHql);

            
            return hql;
        }

       
    }
}

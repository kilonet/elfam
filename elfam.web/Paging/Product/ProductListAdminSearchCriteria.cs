using System;
using elfam.web.Extensions;

namespace elfam.web.Paging.Product
{
    [Serializable]
    public class ProductListAdminSearchCriteria: SearchCriteria
    {
        [Link]
        public int? CategoryId { get; set; }

        public ProductListAdminSearchCriteria WithCategoryId(int categoryId)
        {
            ProductListAdminSearchCriteria another = this.Clone<ProductListAdminSearchCriteria>();
            another.CategoryId = categoryId;
            // need to reset page index
            another.PageIndex = 1;
            return another;
        }
    }
}

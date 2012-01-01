using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using elfam.web.Models;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using NHibernate.Transform;
using Order = elfam.web.Models.Order;

namespace elfam.web.Services
{
    public class ProductService: BaseService
    {
        internal IList<Product> FindByCategory(Category category)
        {
            return daoTemplate.FindAllByField<Product>("Category", category);
        }

        public IList<ProductReportRow> ProductReport()
        {
            OrderStatus[] reservedStatuses = {OrderStatus.Processing, OrderStatus.WaitPayment, OrderStatus.WaitPickup};
            DetachedCriteria reservedProductsCriteria = DetachedCriteria.For(typeof (Order))
                .CreateAlias("Lines", "ol")
                .CreateAlias("ol.Product", "p", JoinType.RightOuterJoin)
                .SetProjection(
                    Projections.ProjectionList()
                        .Add(Projections.GroupProperty("ol.Product").As("Product"))
                        .Add(Projections.Sum("ol.Quantity").As("Quantity")))
                .Add(Restrictions.In("Status", reservedStatuses))
                .SetResultTransformer(Transformers.AliasToBean(typeof(ProductReportResultRow)));
            IList<ProductReportResultRow> reservedProducts = daoTemplate.FindByCriteria<ProductReportResultRow>(reservedProductsCriteria);

            OrderStatus[] payedStatuses = { OrderStatus.Payed, OrderStatus.Delivered };
            DetachedCriteria payedProductsCriteria = DetachedCriteria.For(typeof(Order))
                .CreateAlias("Lines", "ol")
                .CreateAlias("ol.Product", "p", JoinType.RightOuterJoin)
                .SetProjection(
                    Projections.ProjectionList()
                        .Add(Projections.GroupProperty("ol.Product").As("Product"))
                        .Add(Projections.Sum("ol.Quantity").As("Quantity")))
                .Add(Restrictions.In("Status", payedStatuses))
                .SetResultTransformer(Transformers.AliasToBean(typeof(ProductReportResultRow)));
            IList<ProductReportResultRow> payedProducts = daoTemplate.FindByCriteria<ProductReportResultRow>(payedProductsCriteria);

            var profit = daoTemplate.Session.CreateQuery(@"
                select p.Id as ProductId, out.Quantity as Quantity , out.Profit as Profit  from 
                Order o 
                join o.Lines ol
                join ol.Outcomes out
                join out.Income inc
                right join inc.Product p
                where o.Status in (:statuses)
                order by p.Id").SetParameterList("statuses", new OrderStatus[] { OrderStatus.Delivered, OrderStatus.Payed })
                              .SetResultTransformer(Transformers.AliasToBean(typeof(ProfitReportRow))).List<ProfitReportRow>();

            IDictionary<int, ProductReportRow> report = new Dictionary<int, ProductReportRow>();
            foreach (ProductReportResultRow row in payedProducts)
            {
                if (report.ContainsKey(row.Product.Id))
                {
                    report[row.Product.Id].PayedQuantity = row.Quantity;
                }
                else
                {
                    report.Add(row.Product.Id, new ProductReportRow(){PayedQuantity = row.Quantity, Product = row.Product});
                }
            }

            foreach (ProductReportResultRow row in reservedProducts)
            {
                if (report.ContainsKey(row.Product.Id))
                {
                    report[row.Product.Id].ReservedQuantity = row.Quantity;
                }
                else
                {
                    report.Add(row.Product.Id, new ProductReportRow() { ReservedQuantity = row.Quantity, Product = row.Product});
                }
            }

            foreach (ProfitReportRow row in profit)
            {
                report[row.ProductId].Profit += row.Profit*row.Quantity;
            }

            return report.Values.ToList();

        }

    }



    public class ProfitReportRow
    {
        public int ProductId { get; set; }
        //public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Profit { get; set; }
    }

    public class ProductReportResultRow
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class ProductReportRow
    {
        public Product Product { get; set;}
        public int ReservedQuantity { get; set; }
        public int PayedQuantity { get; set; }
        public decimal Profit { get; set; }
    }
}

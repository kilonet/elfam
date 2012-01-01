using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using elfam.web.Dao;
using elfam.web.Models;

namespace elfam.web.Paging.Order
{
    public class OrderListQueryBuilder : QueryBuilder<Models.Order>
    {
        private User _user;
        private OrderStatus? status;
        DaoTemplate _daoTemplate = new DaoTemplate();

        public OrderListQueryBuilder(OrderListSearchCriteria criteria) 
            : base(criteria)
        {
            if (criteria.UserId.HasValue)
                _user = _daoTemplate.FindByID<User>(criteria.UserId);

            if (criteria.Status.HasValue)
                status = criteria.Status.Value;
        }

        protected override Dictionary<string, string> initAliases()
        {
            return new Dictionary<string, string>()
                       {
                           {"user", "o.User.Id"},
                           {"date", "o.Date"},
                           {"summ", "o.SummWithDiscount"},
                           {"profit", "o.Profit"},
                           {"payment", "o.PaymentType"},
                           {"deliver", "o.DeliverType"},
                           {"city", "o.ShippingDetails.City"},
                           {"status", "o.Status"},
                       };
        }

        protected override string getTotalCountHql()
        {
            string hql = "select count(o.Id) from Order o";
            var conditions = new List<string>();
            if (_user != null)
                conditions.Add(" o.User.Id = " + _user.Id);
            if (status.HasValue)
                conditions.Add(" o.Status = '" + Enum.GetName(typeof(OrderStatus), status) + "'");
            WhereHqlBuilder whereHqlBuilder = new WhereHqlBuilder(hql, conditions);
            return whereHqlBuilder.Hql();
        }

        protected override string getHql()
        {
            string hql = "select o from Order o";
            var conditions = new List<string>();
            if (_user != null)
                conditions.Add(" o.User.Id = " + _user.Id);
            if (status.HasValue)
                conditions.Add(" o.Status = '" + Enum.GetName(typeof(OrderStatus), status) + "'");
            WhereHqlBuilder whereHqlBuilder = new WhereHqlBuilder(hql, conditions);
            return whereHqlBuilder.Hql();
        }
    }
}

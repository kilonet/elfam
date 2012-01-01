using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using elfam.web.Extensions;
using elfam.web.Models;

namespace elfam.web.Paging.Order
{
    [Serializable]
    public class OrderListSearchCriteria : SearchCriteria
    {
        [Link]
        public int? UserId { get; set; }

        [Link]
        public OrderStatus? Status { get; set; }

        public OrderListSearchCriteria()
        {
            this.SortExpression = "date";
            this.SortDirection = DescSearchOrder;
        }

        public OrderListSearchCriteria WithStatus(OrderStatus status)
        {
            OrderListSearchCriteria another = this.Clone<OrderListSearchCriteria>();
            another.Status = status;
            // need to reset page index
            another.PageIndex = 1;
            return another;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elfam.web.Models
{
    public class DeliverPrices: DomainEntity
    {
        public virtual decimal CourierSubMoscow { get; set; }
        public virtual decimal Self { get; set; }
        public virtual decimal CourierMoscow { get; set; }
        public virtual decimal Post { get; set; }
        public virtual decimal PostWhenReceived(decimal orderSumm)
        {
            decimal d;
            if (orderSumm <= 1000)
            {
                d = 25 + ((decimal)0.05)*orderSumm;
            }
            else
            {
                d = 75 + ((decimal)0.04)*orderSumm;
            }
            return Post + d;
        } 
    }
}

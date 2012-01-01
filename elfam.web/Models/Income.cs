using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elfam.web.Models
{
    public class Income: DomainEntity
    {
        public virtual Product Product { get; set; }
        public virtual decimal BuyPrice { get; set; }
        public virtual int QuantityCurrent { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual int QuantityInital { get; set; }
        public virtual IList<Outcome> Outcomes { get; set; }
        public virtual Category Category { get; set; }

        public static string DateProperty = "Date";
        
        public Income()
        {
            
        }

    }
}

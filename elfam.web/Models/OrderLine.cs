using System;
using System.Collections.Generic;
using System.Linq;
using elfam.web.Extensions;


namespace elfam.web.Models
{
    public class OrderLine: DomainEntity
    {
        public virtual Product Product { get; set; }
        public virtual string ProductName { get; set; }
        public virtual decimal Price { get; set; }
        public virtual int Quantity { get; set; }
        public virtual IList<Outcome> Outcomes { get; set; }
        public virtual Order Order { get; set; }

        protected OrderLine()
        {
            Outcomes = new List<Outcome>();
        }

        public OrderLine(Product product, int quantity, IList<Outcome> outcomes):this()
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;
            ProductName = product.Name;

            Outcomes = outcomes;
            outcomes.ForEach(x => x.OrderLine = this);

            Profit = Outcomes.Sum(outcome => outcome.Profit);
            SummWithDiscount = Outcomes.Sum(outcome => outcome.SummWithDiscount);

        }

//        public virtual void AddOutcome(Outcome outcome)
//        {
//            Outcomes.Add(outcome);
//            outcome.OrderLine = this;
//        }

        public virtual decimal Profit { get; private set; }
//        public virtual decimal Profit()
//        {
//            return Outcomes.Sum(outcome => outcome.Profit);
//        }

        public virtual decimal SummWithDiscount { get; private set; }
//        public virtual decimal SummWithDiscount()
//        {
//            return Outcomes.Sum(outcome => outcome.SummWithDiscount);
//        }
    }
}
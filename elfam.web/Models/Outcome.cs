using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elfam.web.Models
{
    public class Outcome: DomainEntity
    {
        public virtual Income Income { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal SellPrice { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual OrderLine OrderLine { get; set; }
        public virtual int Discount { get; set; }

        protected Outcome()
        {
            Date = DateTime.Now;
            Discount = 0;
        }

        public Outcome(decimal sellPrice, int quantity, Income income, int discount): this()
        {
            Income = income;
            Quantity = quantity;
            SellPrice = sellPrice;
            Discount = discount;

            Summ = sellPrice*quantity;
            SummWithDiscount = sellPrice*quantity*(1 - ((decimal) discount/100));
            Profit = SummWithDiscount - income.BuyPrice*quantity;
            DiscountSumm = sellPrice*quantity*((decimal) discount/100);
        }

        public virtual decimal SummWithDiscount { get; private set; }
        public virtual decimal Summ { get; private set; }

//        public virtual decimal SummWithDiscount()
//        {
//            return SellPrice*Quantity * (1 -((decimal)Discount / 100));
//        }

//        protected  virtual decimal Summ { get; private set; }
//        public virtual decimal Summ()
//        {
//            return SellPrice * Quantity;
//        }

        public virtual decimal Profit { get; private set; }
//        public virtual decimal Profit()
//        {
//            return SummWithDiscount() - Income.BuyPrice*Quantity;
//        }

        public virtual decimal DiscountSumm { get; private set; }
//        public virtual decimal DiscountSumm()
//        {
//            return Summ()*((decimal)Discount/100);
//        }
    }
}

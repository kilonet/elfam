using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using elfam.web.Validation;
using NHibernate.Criterion;

namespace elfam.web.Models
{
    public class User: DomainEntity
    {
        public User()
        {
            Role = Role.User;
            CanLogin = true;
        }

        public virtual string Email { get; set; }
        public virtual byte[] PasswordHash { get; set; }
        public virtual Role Role { get; set; }
        public virtual bool IsSignedForNews { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual IList<Order> Orders { get; set; }
        public virtual int Discount { get; set; }
        public virtual bool CanLogin { get; set; }

        public virtual bool IsAdmin
        {
            get { return Role.Equals(Role.Admin); }
            
        }

        public static string RoleProperty = "Role";
        public static string CanLoginProperty = "CanLogin";
        

        public static string EmailProperty = "Email";
        public static string IsSignedForNewsProperty = "IsSignedForNews";

        public virtual bool Equals(User other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Email, Email);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (User)) return false;
            return Equals((User) obj);
        }

        public override int GetHashCode()
        {
            return (Email != null ? Email.GetHashCode() : 0);
        }

        public virtual decimal Profit()
        {
            return Orders.Where(order => Order.ProfitStatuses.Contains(order.Status)).Sum(x => x.Profit);
        }

        public virtual decimal Summ()
        {
            return Orders.Where(order => Order.ProfitStatuses.Contains(order.Status)).Sum(x => x.SummWithDiscount);
        }

        public virtual int GreenLength()
        {
            return (int)((Summ()/10000)*190);
        }

        public virtual int WhiteLength()
        {
            return 190 - GreenLength();
        }

        public virtual decimal LeftToDiscount()
        {
            if (10000 - Summ() < 0) return 0;
            return 10000 - Summ();
        }
    }
}


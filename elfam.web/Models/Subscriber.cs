using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elfam.web.Models
{
    public class Subscriber: DomainEntity
    {
        public virtual string Email { get; set; }
        public virtual bool IsActive { get; set; }

        public static string UnsubscribeKey = "cRfqktHdctCfv";
        public static string EmailProperty = "Email";
        public static string IsActiveProperty = "IsActive";

        public Subscriber()
        {
            IsActive = true;
        }

    }
}

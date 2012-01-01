using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elfam.web.Models
{
    public class UniqueId: DomainEntity
    {
        public virtual int Uid { get; set; }
    }
}

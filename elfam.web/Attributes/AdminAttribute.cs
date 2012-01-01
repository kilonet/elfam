using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace elfam.web.Attributes
{
    public class AdminAttribute: AuthorizeAttribute
    {
        public AdminAttribute()
        {
            Roles = "Admin";
        }
    }
}

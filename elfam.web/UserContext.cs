using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using elfam.web.Dao;
using elfam.web.Models;

namespace elfam.web
{
    public class UserContext
    {
        // todo
        static DaoTemplate daoTemplate = new DaoTemplate();

        public static User User()
        {
            User user = daoTemplate.FindUniqueByField<User>(Models.User.EmailProperty,
                                                            HttpContext.Current.User.Identity.Name);
            return user;
        }

        public static bool IsAdmin()
        {
            var user = User();
            if (user == null)
                return false;
            return user.IsAdmin;
        }

        public static int Discount()
        {
            if (User() == null)
                return 0;
            return User().Discount;
        }
    }
}

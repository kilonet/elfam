using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using elfam.web.Models;
using NHibernate.Criterion;

namespace elfam.web.Services
{
    public class UserService: BaseService
    {
        
        public bool AuthenticateUser(string email, string password)
        {
            User user = daoTemplate.FindUniqueByField<User>(User.EmailProperty, email);
            if (user == null || !user.CanLogin)
                return false;
            byte[] passwordHash = CalculateHash(password);
            return user.PasswordHash.SequenceEqual(passwordHash);
        }

        public static byte[] CalculateHash(string password)
        {
            HashAlgorithm algorythm = HashAlgorithm.Create();
            byte[] input = Encoding.UTF8.GetBytes(password);
            return algorythm.ComputeHash(input);
        }

        public static bool IsValidPassword(string newPassword)
        {
            return newPassword != null && newPassword.Length > 3;
        }

        public IList<User> FindAllAdmins()
        {
            DetachedCriteria criteria = DetachedCriteria.For<User>();
            criteria.Add(Restrictions.Eq(User.RoleProperty, Role.Admin));
            criteria.Add(Restrictions.Eq(User.CanLoginProperty, true));
            return daoTemplate.FindByCriteria<User>(criteria);
        }
    }
}

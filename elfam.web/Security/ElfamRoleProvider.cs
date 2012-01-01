using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using elfam.web.Dao;
using elfam.web.Models;

namespace elfam.web.Security
{
    public class ElfamRoleProvider : RoleProvider
    {
        DaoTemplate daoTemplate = new DaoTemplate();

        private User GetUser(string userName)
        {
            return daoTemplate.FindUniqueByField<User>(User.EmailProperty, userName);
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            Role role = (Role)Enum.Parse(typeof (Role), roleName);
            User user = GetUser(username);
            return user.Role == role;
        }

        public override string[] GetRolesForUser(string username)
        {
            User user = GetUser(username);
            string roleName = Enum.GetName(typeof (Role), user.Role);
            return new string[] {roleName};
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}

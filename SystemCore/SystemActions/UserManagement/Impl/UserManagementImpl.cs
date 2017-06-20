using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Users;
using SystemCore.Exceptions;
using SystemCore.Mappers;
using SystemModel.DAO;

namespace SystemCore.SystemActions.UserManagement.Impl
{
    public class UserManagementImpl : UserManagement
    {
        private const string MSG_PRIVILEGE_VIOLATED = "User [{0}] has no privilege. Required privilege level: {1}.";

        public void DegradeUser(User userToDegrade, int newPrivilegeLevel)
        {
            var performingUser = SystemContext.SystemContext.CurrentUser;

            if(performingUser.PrivilegeLevel >= newPrivilegeLevel)
            {
                throw new AccessDeniedException(string.Format(MSG_PRIVILEGE_VIOLATED, performingUser.Name, newPrivilegeLevel - 1));
            }

            if(userToDegrade.PrivilegeLevel <= newPrivilegeLevel)
            {
                throw new ArgumentOutOfRangeException("newPrivilegeLevel", string.Format("New privilege level ({0}) should be smaller than current ({1})", newPrivilegeLevel, userToDegrade.PrivilegeLevel));
            }

            userToDegrade.PrivilegeLevel = newPrivilegeLevel;
            SystemUserDAO.GetInstance().Update(User2SystemUserTO.Map(userToDegrade));
        }

        public IEnumerable<User> GetRegisteredUsers()
        {
            return SystemUserTO2UserMapper.Map(SystemUserDAO.GetInstance().GetAll());
        }

        public void PromoteUser(User userToPromote, int newPrivilegeLevel)
        {
            User performingUser = SystemContext.SystemContext.CurrentUser;

            if (performingUser.PrivilegeLevel >= newPrivilegeLevel)
            {
                throw new AccessDeniedException(string.Format(MSG_PRIVILEGE_VIOLATED, performingUser.Name, newPrivilegeLevel - 1));
            }

            if (userToPromote.PrivilegeLevel >= newPrivilegeLevel)
            {
                throw new ArgumentOutOfRangeException("newPrivilegeLevel", string.Format("New privilege level ({0}) should be greater than current ({1})", newPrivilegeLevel, userToPromote.PrivilegeLevel));
            }

            userToPromote.PrivilegeLevel = newPrivilegeLevel;
            SystemUserDAO.GetInstance().Update(User2SystemUserTO.Map(userToPromote));
        }

        public void RegisterUser(User registeredUser)
        {
            User registratingUser = SystemContext.SystemContext.CurrentUser;

            if (registratingUser.PrivilegeLevel >= registeredUser.PrivilegeLevel)
            {
                throw new AccessDeniedException(string.Format(MSG_PRIVILEGE_VIOLATED, registratingUser.Name, registeredUser.PrivilegeLevel));
            }

            var registeredUserTO = User2SystemUserTO.Map(registeredUser);
            SystemUserDAO.GetInstance().Insert(registeredUserTO);
        }

        public void RemoveUser(User userToRemove)
        {
            User performingUser = SystemContext.SystemContext.CurrentUser;

            if (performingUser.PrivilegeLevel >= userToRemove.PrivilegeLevel)
            {
                throw new AccessDeniedException(string.Format(MSG_PRIVILEGE_VIOLATED, performingUser.Name, userToRemove.PrivilegeLevel));
            }

            SystemUserDAO.GetInstance().Delete(User2SystemUserTO.Map(userToRemove));
        }
    }
}

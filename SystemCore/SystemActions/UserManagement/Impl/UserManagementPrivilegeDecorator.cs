using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Users;
using SystemCore.Helpers;

namespace SystemCore.SystemActions.UserManagement.Impl
{
    public class UserManagementPrivilegeDecorator : UserManagement
    {
        private readonly UserManagement _userManagement;

        public UserManagementPrivilegeDecorator(UserManagement userManagement)
        {
            if (userManagement == null)
                throw new ArgumentNullException("userManagement");

            _userManagement = userManagement;
        }

        public void DegradeUser(User userToDegrade, int newPrivilegeLevel)
        {
            PrivilegeHelper.CheckUserPrivilegeForMethod(((Action<User, int>)_userManagement.DegradeUser).Method);
            _userManagement.DegradeUser(userToDegrade, newPrivilegeLevel);
        }

        public IEnumerable<User> GetRegisteredUsers()
        {
            PrivilegeHelper.CheckUserPrivilegeForMethod(((Func<IEnumerable<User>>)_userManagement.GetRegisteredUsers).Method);
            return _userManagement.GetRegisteredUsers();
        }

        public void PromoteUser(User userToPromote, int newPrivilegeLevel)
        {
            PrivilegeHelper.CheckUserPrivilegeForMethod(((Action<User, int>)_userManagement.PromoteUser).Method);
            _userManagement.PromoteUser(userToPromote, newPrivilegeLevel);
        }

        public void RegisterUser(User registeredUser)
        {
            PrivilegeHelper.CheckUserPrivilegeForMethod(((Action<User>)_userManagement.RegisterUser).Method);
            _userManagement.RegisterUser(registeredUser);
        }

        public void RemoveUser(User userToRemove)
        {
            PrivilegeHelper.CheckUserPrivilegeForMethod(((Action<User>)_userManagement.RemoveUser).Method);
            _userManagement.RemoveUser(userToRemove);
        }
    }
}

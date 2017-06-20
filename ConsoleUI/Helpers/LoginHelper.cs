using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Exceptions;
using SystemCore.Mappers;
using SystemCore.SystemContext;
using SystemModel.DAO;

namespace ConsoleUI.Helpers
{
    public static class LoginHelper
    {

        public static void SignIn(string login, string password)
        {
            var userTO = SystemUserDAO.GetInstance().GetByName(login);
            if (userTO == null)
                throw new AccessDeniedException("Niewłaściwy login");

            var user = SystemUserTO2UserMapper.Map(userTO);
            if (user.Password != password)
                throw new AccessDeniedException("Niewłaściwe hasło");

            SystemContext.LoginUser(user, password);
        }

        public static void SignOut(string login)
        {
            if (login == null)
                throw new ArgumentNullException(nameof(login));

            var userTO = SystemUserDAO.GetInstance().GetByName(login);
            if (userTO == null)
                throw new ArgumentException(string.Format("unknown login: {0}", login));

            var user = SystemUserTO2UserMapper.Map(userTO);
            SystemContext.LogoutUser(user);
        }

    }
}

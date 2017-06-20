using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModel.TO;
using SystemModel.DAO;
using SystemCore.Users;

namespace SystemCore.Mappers
{
    public class User2SystemUserTO
    {
        public static SystemUserTO Map(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            var privilegeTO = PrivilegeDAO.GetInstance().GetByPrivilegeLevelEq(user.PrivilegeLevel).FirstOrDefault();
            if(privilegeTO == null)
            {
                privilegeTO = new PrivilegeTO { PrivilegeName = user.Name + " privilege", PrivilegeLevel = user.PrivilegeLevel };
                privilegeTO = PrivilegeDAO.GetInstance().Insert(privilegeTO);
            }

            return new SystemUserTO
            {
                UserId = user.Id,
                UserName = user.Name,
                UserPassword = user.Password,
                PhoneNumber = user.PhoneNumber,
                PrivilegeId = privilegeTO.PrivilegeId
            };
        }

        public static IEnumerable<SystemUserTO> Map(IEnumerable<User> users)
        {
            if (users == null)
                throw new ArgumentNullException("users");

            foreach (var user in users)
                yield return Map(user);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Users;
using SystemModel.DAO;
using SystemModel.TO;

namespace SystemCore.Mappers
{
    public static class SystemUserTO2UserMapper
    {
        /// <summary>
        /// Mapuje pojedynczy TO SystemUserTO na strukturę User. Jeśli userTO.PrivilegeId jest null, bądź nie istnieje w bazie, 
        /// przypisywany jest mu poziom dostępu PrivilegeLevel == int.MaxValue, co w praktyce oznacza że nie ma nigdzie dostępu, bądź jest ograniczony
        /// tylko do bazowych funkcjonalności systemu.
        /// </summary>
        /// <param name="userTO">Obiekt SystemUserTO utworzony np. w SystemUserDAO.</param>
        /// <returns></returns>
        public static User Map(SystemUserTO userTO)
        {
            if (userTO == null)
                throw new ArgumentNullException("userTO");

            var privilegeTO = PrivilegeDAO.GetInstance().GetById(userTO.PrivilegeId);
            int privilegeLevel = privilegeTO.PrivilegeLevel ?? int.MaxValue;

            return new User
            {
                Id = userTO.UserId,
                Name = userTO.UserName,
                Password = userTO.UserPassword,
                PrivilegeLevel = privilegeLevel,
                PhoneNumber = userTO.PhoneNumber
            };
        }

        /// <summary>
        /// Map serię SystemUserTO do User leniwie. Należy uwarzać by nie utracić połączenia z bazą danych.
        /// </summary>
        /// <param name="userTOs">Enumerator obiektów SystemUserTO.</param>
        /// <returns>Enumerator zmapowanych obiektów User.</returns>
        public static IEnumerable<User> Map(IEnumerable<SystemUserTO> userTOs)
        {
            foreach (var uTO in userTOs)
                yield return Map(uTO);
        }
    }
}

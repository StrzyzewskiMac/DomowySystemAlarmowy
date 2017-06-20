using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Users;
using SystemCore.Exceptions;

namespace SystemCore.SystemActions.UserManagement
{
    public interface UserManagement
    {
        IEnumerable<User> GetRegisteredUsers();

        /// <summary>
        /// Metoda używana do rejestrowania nowego użytkownika w systemie.
        /// </summary>
        /// <exception cref="AccessDeniedException">Gdy użytkownik, który rejestruje nowego użytkownika nie ma wystarczających uprawnień, bądź gdy nowy użytkownik ma wyższy/równy poziom uprawnień co użytkownik, który go rejestruje.</exception>
        /// <param name="registratingUser">Użytkownik, który rejestruje nowego użytkownika.</param>
        /// <param name="registeredUser">Nowy użytkownik, który jest rejestrowany.</param>
        void RegisterUser(User registeredUser);

        void RemoveUser(User userToRemove);

        void DegradeUser(User userToDegrade, int newPrivilegeLevel);

        void PromoteUser(User userToPromote, int newPrivilegeLevel);
    }
}

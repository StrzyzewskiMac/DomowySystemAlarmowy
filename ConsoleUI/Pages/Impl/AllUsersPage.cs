using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.SystemContext;

namespace ConsoleUI.Pages.Impl
{
    public class AllUsersPage : PageBase
    {
        public AllUsersPage() : base(UsersPage.TITLE + " - lista", "Lista wszystkich użytkowników.")
        {
        }

        public override void ShowCustomMessage()
        {
            var registeredUsers = SystemContext.UserManagement.GetRegisteredUsers();
            foreach(var user in registeredUsers)
            {
                Console.WriteLine("\tId: {0}", user.Id);
                Console.WriteLine("\tImię: {0}", user.Name);
                Console.WriteLine("\tPoziom dostępu: {0}", user.PrivilegeLevel);
                Console.WriteLine("\tNr telefonu: {0}", user.PhoneNumber);
                Console.WriteLine("-----");
            }

            Console.ReadLine();
        }
    }
}

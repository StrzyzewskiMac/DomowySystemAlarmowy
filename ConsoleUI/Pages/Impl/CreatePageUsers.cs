using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Mappers;
using SystemCore.Users;
using SystemModel.DAO;
using static SystemCore.Helpers.PrivilegeHelper;

namespace ConsoleUI.Pages.Impl
{
    public class CreatePageUsers : PageBase
    {
        private const string TITLE = "Dodawanie użytkowników";
        private const string UNDERTITLE = "Wypełnij poniższe pola, aby dodać użytkownika.";

        public CreatePageUsers() : base(TITLE, UNDERTITLE)
        {  }

        public override void ShowCustomMessage()
        {
            var user = new User();

            user.Name = Helpers.PageHelper.GetValidInput<string>("Imie:");
            user.Password = Helpers.PageHelper.GetValidInput<string>("Hasło:");
            user.PhoneNumber = Helpers.PageHelper.GetValidInput<string>("Nr telefonu:");
            user.PrivilegeLevel = DefaultPrivileges.User;

            var userTO = User2SystemUserTO.Map(user);
            SystemUserDAO.GetInstance().Insert(userTO);
        }

        public override object GetInput()
        {
            Console.ReadLine();
            return base.GetInput();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI.PageLayout;

namespace ConsoleUI.Pages.Impl
{
    public class UsersPage : PageBase
    {
        public const string TITLE = "Użytkownicy";

        public UsersPage() : base(TITLE, "Akcje związane z obsługą użytkowników.")
        {
            pageConnection.Add(new AllUsersPage());
            pageConnection.Add(new CreatePageUsers());
        }

        public override object GetInput()
        {
            return Helpers.PageHelper.ChoosePage();
        }

        public override bool ProcessInput(PageLayoutManager manager, object obj)
        {
            return Helpers.PageHelper.GoToPage(manager, pageConnection, obj);
        }
    }
}

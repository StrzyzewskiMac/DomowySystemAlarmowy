using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI.PageLayout;
using ConsoleUI.Helpers;
using ConsoleUI.Pages.Impl.Zone;
using SystemCore.SystemContext;

namespace ConsoleUI.Pages.Impl
{
    public class MainPage : PageBase
    {
        public MainPage() : base("Strona główna", "")
        {
            pageConnection.Add(new UsersPage());
            pageConnection.Add(new AlarmsPage());
            pageConnection.Add(new ZonesMainPage());
            pageConnection.Add(new EventsLogPage());
        }

        public override void ShowCustomMessage()
        {
            var user = SystemContext.CurrentUser;
            if (user != null)
            {
                var cLeft = Console.CursorLeft;
                var cTop = Console.CursorTop;
                var loggedAsString = string.Format("Użytkownik: {0}", user.Name);
                Console.SetCursorPosition((Console.WindowWidth - loggedAsString.Length) / 2, 5);
                PageHelper.WriteInAnotherColor(loggedAsString, ConsoleColor.DarkGreen);
                Console.SetCursorPosition(cLeft, cTop);
            }
        }

        public override object GetInput()
        {
            return PageHelper.ChoosePage();
        }

        public override bool ProcessInput(PageLayoutManager manager, object obj)
        {
            return PageHelper.GoToPage(manager, pageConnection, obj);
        }
    }
}

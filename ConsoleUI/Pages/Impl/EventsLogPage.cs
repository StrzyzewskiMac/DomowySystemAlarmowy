using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI.Helpers;
using ConsoleUI.PageLayout;

namespace ConsoleUI.Pages.Impl
{
    public class EventsLogPage : PageBase
    {
        public const string TITLE = "Zdarzenia systemowe";

        public EventsLogPage() : base(TITLE, "Menu obsługi zdarzeń systemowych")
        {
            pageConnection.Add(new AllEventsPage());
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

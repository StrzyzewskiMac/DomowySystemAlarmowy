using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.SystemContext;

namespace ConsoleUI.Pages.Impl
{
    public class AllEventsPage : PageBase
    {

        public AllEventsPage() : base(EventsLogPage.TITLE + " - lista", "Lista wszystkich zdarzeń systemowych.")
        {
        }

        public override void ShowCustomMessage()
        {
            var events = SystemContext.SystemLogger.GetAllEvents();
            foreach(var ev in events)
            {
                Console.WriteLine("[{3}, {0}] ({1}) {2}", ev.EventDate, ev.SensorId, ev.EventDescription, ev.Severity.ToString());
            }

            Console.ReadLine();
        }
    }
}

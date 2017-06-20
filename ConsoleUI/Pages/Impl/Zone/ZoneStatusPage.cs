using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI.PageLayout;
using SystemCore.SystemContext;

namespace ConsoleUI.Pages.Impl.Zone
{
    public class ZoneStatusPage : PageBase
    {
        private const string TITLE = "Zmiana statusu";

        public ZoneStatusPage() : base(TITLE, string.Empty)
        {
            foreach(var zone in SystemContext.ZoneManagement.GetAllSensorsGroupedByZone())
            {
                pageConnection.Add(new ZoneStatusManagerPage(zone.Key));
            }
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

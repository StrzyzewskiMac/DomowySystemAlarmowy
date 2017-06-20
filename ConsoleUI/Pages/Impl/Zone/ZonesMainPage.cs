using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI.PageLayout;

namespace ConsoleUI.Pages.Impl.Zone
{
    public class ZonesMainPage : PageBase
    {
        public const string TITLE = "Zarządzanie strefami";

        public ZonesMainPage() : base(TITLE, string.Empty)
        {
            pageConnection.Add(new ShowAllZonesPages());
            pageConnection.Add(new ZoneStatusPage());
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

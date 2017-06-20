using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI.PageLayout;
using SystemCore.SystemContext;
using ConsoleUI.Helpers;

namespace ConsoleUI.Pages.Impl.Zone
{
    public class ZoneStatusManagerPage : PageBase
    {
        private const string TitleTemplate = "Zarządzanie strefą {0}.";
        private readonly uint zoneId;
        private readonly IList<Action<uint>> currentlyAvailalbleActions = 
            new List<Action<uint>>();

        public ZoneStatusManagerPage(uint zoneId) 
            : base(string.Format(TitleTemplate, zoneId), string.Empty)
        {
            this.zoneId = zoneId;
        }

        public override void ShowCustomMessage()
        {
            Console.WriteLine("Status: {0}", (!SystemContext.ZoneManagement.IsZoneDisabled(zoneId)).ToOnOffStatus());

            var text = "Dostepne akcje:";
            Console.WriteLine(text);
            Console.WriteLine(new string('-', text.Length));

            ShowActions();
        }

        public override object GetInput()
        {
            return Helpers.PageHelper.GetValidInput<int>("Wybierz akcję: ");
        }

        public override bool ProcessInput(PageLayoutManager manager, object obj)
        {
            try
            {
                var action = currentlyAvailalbleActions[(int)obj];
                action(zoneId);
                return true;
            }
            catch(ArgumentOutOfRangeException)
            {
                return false;
            }
        }

        private void ShowActions()
        {
            currentlyAvailalbleActions.Clear();
            int counter = 0;
            foreach(var action in _actions)
            {
                if(action.Item2(zoneId))
                {
                    Console.WriteLine("[{0}] {1}", counter, action.Item1);
                    currentlyAvailalbleActions.Add(action.Item3);
                    ++counter;
                }
            }
        }

        private static readonly IList<Tuple<string, Predicate<uint>, Action<uint>>> _actions = 
            new List<Tuple<string, Predicate<uint>, Action<uint>>>()
        {
            new Tuple<string, Predicate<uint>, Action<uint>>(
                "Aktywuj strefę", 
                zoneId => SystemContext.ZoneManagement.IsZoneDisabled(zoneId),
                zoneId => SystemContext.ZoneManagement.EnableZone(zoneId)),
            new Tuple<string, Predicate<uint>, Action<uint>>(
                "Dezaktywuj strefę",
                zoneId => !SystemContext.ZoneManagement.IsZoneDisabled(zoneId),
                zoneId => SystemContext.ZoneManagement.DisableZone(zoneId))
                
        };
    }
}

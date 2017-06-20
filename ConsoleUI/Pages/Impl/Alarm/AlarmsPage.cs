using System;
using SystemCore.Devices.Alarm.Impl;
using SystemCore.SystemContext;
using ConsoleUI.Helpers;
using ConsoleUI.Pages.Impl.Alarm;
using ConsoleUI.PageLayout;

namespace ConsoleUI.Pages.Impl
{
    public class AlarmsPage : PageBase
    {
        public const string TITLE = "Zarzadzanie alarmem";
        public const string UNDERTITLE = "";

        public AlarmsPage() : base(TITLE, UNDERTITLE)
        {
            pageConnection.Add(new TurnOnOffAlarmPage());
            pageConnection.Add(new DisableAlarmPage());
        }
        
        private void ShowAlarmStatus()
        {
            var alarmSystem = SystemContext.AlarmSystem;
            Console.WriteLine(string.Format("Status alarmu: {0}", alarmSystem.AlarmOn.ToOnOffStatus()));
            var alarmDisabled = (alarmSystem as AlarmSystemMuterDecorator)?.Enabled ?? true;
            Console.WriteLine(string.Format("Alarm system: {0}", alarmDisabled.ToOnOffStatus()));
            Console.WriteLine();
        }

        public override object GetInput()
        {
            return Helpers.PageHelper.ChoosePage();
        }

        public override bool ProcessInput(PageLayoutManager manager, object obj)
        {
            return PageHelper.GoToPage(manager, pageConnection, obj);
        }
    }
}

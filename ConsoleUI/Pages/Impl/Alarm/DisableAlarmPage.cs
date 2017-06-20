using System;
using ConsoleUI.PageLayout;
using SystemCore.Devices.Alarm;
using SystemCore.Devices.Alarm.Impl;
using SystemCore.SystemContext;
using ConsoleUI.Helpers;

namespace ConsoleUI.Pages.Impl.Alarm
{
    public class DisableAlarmPage : PageBase
    {
        public const string UNDERTITLE = "Włączenie/wyłączenie alarmu.";
        private readonly AlarmSystem _alarmSystem;

        public DisableAlarmPage() : base("Zarządzanie statusem urządzenia", UNDERTITLE)
        {
            _alarmSystem = SystemContext.AlarmSystem;
        }

        public override void ShowCustomMessage()
        {
            var status = GetAlarmSystemEnabledStatus();
            Console.WriteLine("Obecny status alarmu: {0}", status.ToOnOffStatus());
        }

        public override object GetInput()
        {
            if (GetAlarmSystemEnabledStatus())
                return !Helpers.PageHelper.GetAnswer("Czy chcesz wyłączyć alarm? [t/T/n/N]: ", "t", "T");
            else
                return Helpers.PageHelper.GetAnswer("Czy chcesz włączyć alarm? [t/T/n/N]: ", "t", "T");
        }

        public override bool ProcessInput(PageLayoutManager manager, object obj)
        {
            var alarmSystemDecorator = (_alarmSystem as AlarmSystemMuterDecorator);
            if(alarmSystemDecorator != null)
                alarmSystemDecorator.Enabled = (bool)obj;
            return true;
        }

        private bool GetAlarmSystemEnabledStatus()
        {
            return (_alarmSystem as AlarmSystemMuterDecorator)?.Enabled ?? true;
        }
    }
}

using System;
using SystemCore.Devices.Alarm;
using SystemCore.SystemContext;
using ConsoleUI.Helpers;
using ConsoleUI.PageLayout;

namespace ConsoleUI.Pages.Impl.Alarm
{
    public class TurnOnOffAlarmPage : PageBase
    {
        public const string UNDERTITLE = "Włączanie/wyłączanie alarmu.";
        private readonly AlarmSystem _alarmSystem;

        public TurnOnOffAlarmPage() : base("Zarządzanie aktywacją alarmu", UNDERTITLE)
        {
            _alarmSystem = SystemContext.AlarmSystem;
        }

        public override void ShowCustomMessage()
        {
            Console.WriteLine("Status alarmu: {0}", _alarmSystem.AlarmOn.ToOnOffStatus());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>true jeśli alarm ma zostać wyłączony, false w przeciwnym wypadku</returns>
        public override object GetInput()
        {
            if (_alarmSystem.AlarmOn)
                return Helpers.PageHelper.GetAnswer("Czy chcesz wyłączyć alarm? [t/n]: ", "t", "T");
            else
                return !Helpers.PageHelper.GetAnswer("Czy chcesz włączyć alarm? [t/n]: ", "t", "T");
        }

        public override bool ProcessInput(PageLayoutManager manager, object obj)
        {
            var shouldTurnOff = (bool)obj;
            if (shouldTurnOff && _alarmSystem.AlarmOn)
                _alarmSystem.TurnOffAlarm();
            else if (!shouldTurnOff && !_alarmSystem.AlarmOn)
                _alarmSystem.TurnOnAlarm(_alarmSystem.BeepLengthInMiliseconds, 
                    _alarmSystem.BeepIntervalInMiliseconds);

            return true;
        }
    }


}

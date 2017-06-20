using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SystemCore.Sensors.SensorEvents;
using SystemCore.Sensors.SensorEvents.SpecificSensorEvents;
using SystemCore.SystemContext;

namespace ConsoleUI.SensorDrivers.DriverRunner
{
    public static class SensorsDriverRunner
    {
        private const int SleepTimeInMs = 25000;

        public static void RunMoveSensorDriver(MoveSensorDriver moveSensorDriver, uint zone)
        {
            Task.Run(() =>
            {
                Thread.Sleep(6000);
                while (true)
                {
                    moveSensorDriver.ChangeState(SystemCore.Sensors.Drivers.SensorState.ON);
                    var ev = new MoveSensorEvent
                    {
                        Severity = EventSeverity.WARNING,
                        EventType = SystemCore.Sensors.EventType.MOVE_SENSOR,
                        EventDescription = "Wykryto ruch w strefie.",
                        Angle = 91.25f,
                        Distance = 13.73f
                    };
                    moveSensorDriver.EventCallback(ev);
                    moveSensorDriver.ChangeState(SystemCore.Sensors.Drivers.SensorState.ON_HOLD);
                    Thread.Sleep(SleepTimeInMs);
                    if (!SystemContext.ZoneManagement.IsZoneDisabled(zone))
                        Helpers.PageHelper.WriteStatus(string.Format("[{0}] Czujnik ruchu 1 aktywowany!", GetCurrentTime()));
                }
            });
        }

        private static object GetCurrentTime()
        {
            var now = DateTime.Now;
            return String.Format("{0,2}:{1,2}:{2,2}", now.Hour, now.Minute, now.Second);
        }

        public static void RunSomeDriver(SomeDriver driver, uint zone)
        {
            Task.Run(() =>
            {
                Thread.Sleep(6000);
                while (true)
                {
                    driver.ChangeState(SystemCore.Sensors.Drivers.SensorState.ON);
                    var ev = new Event
                    {
                        Severity = EventSeverity.INFO,
                        EventType = SystemCore.Sensors.EventType.UNKNOWN,
                        EventDescription = "Aktualizacja stanu."
                    };
                    driver.EventCallback(ev);
                    driver.ChangeState(SystemCore.Sensors.Drivers.SensorState.ON_HOLD);
                    Thread.Sleep(SleepTimeInMs);
                    if(!SystemContext.ZoneManagement.IsZoneDisabled(zone))
                        Helpers.PageHelper.WriteStatus(string.Format("[{0}] Czujnik ruchu 2 aktywowany!", GetCurrentTime()));
                }
            });
        }
    }
}

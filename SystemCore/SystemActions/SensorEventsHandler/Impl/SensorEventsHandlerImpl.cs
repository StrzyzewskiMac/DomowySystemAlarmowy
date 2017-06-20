using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Sensors;
using SystemCore.Sensors.Drivers;
using SystemCore.Sensors.SensorEvents;
using SystemCore.SystemContext;

namespace SystemCore.SystemActions.SensorEventsHandler.Impl
{
    public class SensorEventsHandlerImpl : SensorEventsHandler
    {
        private const string MSG_STATE_CHANGES = "Stan [{0}] został zmieniony na {1}";
        

        public void HandleSensorEvent(SensorInfo sensorInfo, Event ev)
        {
            ev.SensorId = sensorInfo.SensorId;
            SystemContext.SystemContext.SystemLogger.Log(ev);

            if(ev.EventType == EventType.MOVE_SENSOR)
            {
                if(!SystemContext.SystemContext.ZoneManagement.IsSensorDisabled(sensorInfo))
                {
                    SystemContext.SystemContext.AlarmSystem.TurnOnAlarm(beepLengthInMs: 2, beepIntervalInMs: 1);
                }
            }
        }

        public void HandleStateChangedEvent(SensorInfo sensorInfo, SensorState newState)
        {
            if (sensorInfo == null)
                throw new ArgumentNullException("sensorInfo");

            _LogSensorStateChanged(sensorInfo, newState);
        }

        private void _LogSensorStateChanged(SensorInfo si, SensorState newState)
        {
            var sensorEvent = new Event { SensorId = si.SensorId, Severity = EventSeverity.INFO };
            sensorEvent.EventDescription = string.Format(MSG_STATE_CHANGES, si.SensorId, newState);
            sensorEvent.EventType = EventType.UNKNOWN;

            SystemContext.SystemContext.SystemLogger.Log(sensorEvent);
        }
    }
}

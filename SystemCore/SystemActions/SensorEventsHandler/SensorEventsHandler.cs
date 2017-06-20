using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Sensors;
using SystemCore.Sensors.Drivers;
using SystemCore.Sensors.SensorEvents;

namespace SystemCore.SystemActions.SensorEventsHandler
{
    public interface SensorEventsHandler
    {
        void HandleSensorEvent(SensorInfo sensorInfo, Event ev);

        void HandleStateChangedEvent(SensorInfo sensorInfo, SensorState newState);
    }
}

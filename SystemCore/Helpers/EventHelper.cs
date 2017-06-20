using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Sensors;
using SystemCore.Sensors.SensorEvents;

namespace SystemCore.Helpers
{
    public class EventHelper
    {
        public static Event MakeMessage(string source, string message)
        {
            return new Event {
                EventType = EventType.MESSAGE,
                EventDescription = message,
                Severity = EventSeverity.INFO,
                SensorId = source
            };
        }
    }
}

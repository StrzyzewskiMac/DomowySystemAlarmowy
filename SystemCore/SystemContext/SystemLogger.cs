using System.Collections.Generic;
using SystemCore.Sensors.SensorEvents;

namespace SystemCore.SystemContext
{
    /// <summary>
    /// Loguje zdarzenia w systemie.
    /// </summary>
    public interface SystemLogger
    {
        void Log(Event sensorEvent);

        IEnumerable<Event> GetAllEvents();
    }
}

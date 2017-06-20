using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Sensors.SensorEvents
{
    /// <summary>
    /// Typ zdarzenia związanego z czujnikami.
    /// </summary>
    public enum EventSeverity
    {
        INFO = 0,
        DEBUG = 1,
        WARNING = 2,
        ERROR = 3,
        CRITICAL_ERROR = 4
    }

}

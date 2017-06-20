using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Sensors.Drivers
{
    /// <summary>
    /// Reprezentuje stan wewnętrzny czujnika.
    /// </summary>
    public enum SensorState
    {
        UNKNOWN, ON, OFF, ERROR, ON_HOLD
    }
}

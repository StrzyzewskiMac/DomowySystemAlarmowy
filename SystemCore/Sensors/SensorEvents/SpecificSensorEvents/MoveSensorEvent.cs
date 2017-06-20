using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Sensors.SensorEvents.SpecificSensorEvents
{
    public class MoveSensorEvent : Event
    {
        /// <summary>
        /// Odległoś od czujnika obiektu.
        /// </summary>
        public float Distance { get; set; }

        /// <summary>
        /// Wychylenie czujnika od poziomu.
        /// </summary>
        public float Angle { get; set; }
    }
}

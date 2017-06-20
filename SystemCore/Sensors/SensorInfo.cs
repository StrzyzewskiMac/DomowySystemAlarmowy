using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Sensors.Drivers;

namespace SystemCore.Sensors
{
    public class SensorInfo
    {
        /// <summary>
        /// Unikalny identyfikator urządzenia.
        /// </summary>
        public string SensorId { get; set; }

        /// <summary>
        /// Określa do jakiej strefy należy czujnik.
        /// </summary>
        public uint Zone { get; set; }

        /// <summary>
        /// Sterownik urządzenia.
        /// </summary>
        public SensorDriver Driver { get; set; }

    }
}

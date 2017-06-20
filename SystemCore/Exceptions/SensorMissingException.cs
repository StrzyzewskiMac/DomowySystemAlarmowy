using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Exceptions
{
    public class SensorMissingException : ArgumentNullException
    {
        public string SensorId { get; private set; }

        public SensorMissingException(string paramName, string sensorId) : base(paramName)
        {
            SensorId = sensorId;
        }

        public SensorMissingException(string paramName) : base(paramName)
        {
        }
    }
}

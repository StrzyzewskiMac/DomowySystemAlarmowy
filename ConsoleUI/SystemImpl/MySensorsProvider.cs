using ConsoleUI.SensorDrivers;
using ConsoleUI.SensorDrivers.DriverRunner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Sensors;
using SystemCore.SystemContext;

namespace ConsoleUI.SystemImpl
{
    class MySensorsProvider : SensorsProvider
    {
        public IEnumerable<SensorInfo> FindAllSensors(object discriminator)
        {
            var sensor1 = new SensorInfo { SensorId = "Czujnik_ruchu_1", Zone = 1, Driver = new MoveSensorDriver() };
            var sensor2 = new SensorInfo { SensorId = "Czujnik_ruchu_2", Zone = 2, Driver = new SomeDriver() };

            SensorsDriverRunner.RunMoveSensorDriver(sensor1.Driver as MoveSensorDriver, sensor1.Zone);
            SensorsDriverRunner.RunSomeDriver(sensor2.Driver as SomeDriver, sensor2.Zone);

            return new List<SensorInfo> { sensor1, sensor2 };
        }
    }
}

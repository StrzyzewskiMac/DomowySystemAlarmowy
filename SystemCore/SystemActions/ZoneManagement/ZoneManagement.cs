using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Sensors;

namespace SystemCore.SystemActions.ZoneManagement
{
    public interface ZoneManagement
    {
        IEnumerable<IGrouping<uint, SensorInfo>> GetAllSensorsGroupedByZone();

        IReadOnlyList<SensorInfo> GetAllSensorsInZone(uint zone);

        bool AssignZoneToSensor(string sensorId, uint zone);

        bool AssignZoneToSensor(SensorInfo sensorInfo, uint zone);

        uint GetSensorZone(string sensorId);

        uint GetSensorZone(SensorInfo sensorInfo);

        bool IsZoneDisabled(uint zone);

        void DisableZone(uint zone);

        void EnableZone(uint zone);

        bool IsSensorDisabled(string sensorId);

        bool IsSensorDisabled(SensorInfo sensor);

        IEnumerable<SensorInfo> GetAllDisabledSensors();
    }
}

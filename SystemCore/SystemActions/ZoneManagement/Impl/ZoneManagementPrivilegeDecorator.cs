using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Sensors;
using SystemCore.Helpers;

namespace SystemCore.SystemActions.ZoneManagement.Impl
{
    public class ZoneManagementPrivilegeDecorator : ZoneManagement
    {
        private readonly ZoneManagement _zoneManagement;

        public ZoneManagementPrivilegeDecorator(ZoneManagement zoneManagement)
        {
            if (zoneManagement == null)
                throw new ArgumentNullException("zoneManagement");

            _zoneManagement = zoneManagement;
        }

        public bool AssignZoneToSensor(SensorInfo sensorInfo, uint zone)
        {
            PrivilegeHelper.CheckUserPrivilegeForMethod(((Func<SensorInfo, uint, bool>)_zoneManagement.AssignZoneToSensor).Method);
            return _zoneManagement.AssignZoneToSensor(sensorInfo, zone);
        }

        public bool AssignZoneToSensor(string sensorId, uint zone)
        {
            PrivilegeHelper.CheckUserPrivilegeForMethod(((Func<string, uint, bool>)_zoneManagement.AssignZoneToSensor).Method);
            return _zoneManagement.AssignZoneToSensor(sensorId, zone);
        }

        public void DisableZone(uint zone)
        {
            PrivilegeHelper.CheckUserPrivilegeForMethod(((Action<uint>)_zoneManagement.DisableZone).Method);
            _zoneManagement.DisableZone(zone);
        }

        public void EnableZone(uint zone)
        {
            PrivilegeHelper.CheckUserPrivilegeForMethod(((Action<uint>)_zoneManagement.EnableZone).Method);
            _zoneManagement.EnableZone(zone);
        }

        public IEnumerable<SensorInfo> GetAllDisabledSensors()
        {
            PrivilegeHelper.CheckUserPrivilegeForMethod(((Func<IEnumerable<SensorInfo>>)_zoneManagement.GetAllDisabledSensors).Method);
            return _zoneManagement.GetAllDisabledSensors();
        }

        public IEnumerable<IGrouping<uint, SensorInfo>> GetAllSensorsGroupedByZone()
        {
            PrivilegeHelper.CheckUserPrivilegeForMethod(((Func<IEnumerable<IGrouping<uint, SensorInfo>>>)_zoneManagement.GetAllSensorsGroupedByZone).Method);
            return _zoneManagement.GetAllSensorsGroupedByZone();
        }

        public IReadOnlyList<SensorInfo> GetAllSensorsInZone(uint zone)
        {
            PrivilegeHelper.CheckUserPrivilegeForMethod(((Func<uint, IReadOnlyList<SensorInfo>>)_zoneManagement.GetAllSensorsInZone).Method);
            return _zoneManagement.GetAllSensorsInZone(zone);
        }

        public uint GetSensorZone(SensorInfo sensorInfo)
        {
            PrivilegeHelper.CheckUserPrivilegeForMethod(((Func<SensorInfo, uint>)_zoneManagement.GetSensorZone).Method);
            return _zoneManagement.GetSensorZone(sensorInfo);
        }

        public uint GetSensorZone(string sensorId)
        {
            PrivilegeHelper.CheckUserPrivilegeForMethod(((Func<string, uint>)_zoneManagement.GetSensorZone).Method);
            return _zoneManagement.GetSensorZone(sensorId);
        }

        public bool IsSensorDisabled(SensorInfo sensor)
        {
            PrivilegeHelper.CheckUserPrivilegeForMethod(((Func<SensorInfo, bool>)_zoneManagement.IsSensorDisabled).Method);
            return _zoneManagement.IsSensorDisabled(sensor);
        }

        public bool IsSensorDisabled(string sensorId)
        {
            PrivilegeHelper.CheckUserPrivilegeForMethod(((Func<string, bool>)_zoneManagement.IsSensorDisabled).Method);
            return _zoneManagement.IsSensorDisabled(sensorId);
        }

        public bool IsZoneDisabled(uint zone)
        {
            PrivilegeHelper.CheckUserPrivilegeForMethod(((Func<uint, bool>)_zoneManagement.IsZoneDisabled).Method);
            return _zoneManagement.IsZoneDisabled(zone);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Devices.Alarm;
using SystemCore.Services.SMS;
using SystemCore.Services.SMS.DefaultImpl;
using SystemCore.SystemActions.SensorEventsHandler;
using SystemCore.SystemActions.SensorEventsHandler.Impl;
using SystemCore.SystemActions.UserManagement;
using SystemCore.SystemActions.UserManagement.Impl;
using SystemCore.SystemActions.ZoneManagement;
using SystemCore.SystemActions.ZoneManagement.Impl;
using SystemCore.Devices.Alarm.Impl;


namespace SystemCore.SystemContext.Default
{
    /// <summary>
    /// Domyślny
    /// </summary>
    public abstract class DefaultSystemContextConstructor : SystemContextConstructor
    {
        public abstract void AfterInit();
        public abstract void BeforeInit();

        public virtual AlarmSystem GetAlarmSystem()
        {
            return new AlarmSystemImpl();
        }

        public SensorEventsHandler GetSensorEventsHandler()
        {
            return new SensorEventsHandlerImpl();
        }

        public SystemLogger GetSensorsLogger()
        {
            return new DefaultDBLogger();
        }

        public SensorsManager GetSensorsManager()
        {
            return new DefaultSensorsManager();
        }

        public abstract SensorsProvider GetSensorsProvider();

        public SMSService GetSMSService()
        {
            return new SMSServiceImpl();
        }

        public UserManagement GetUserManagement()
        {
            return new UserManagementPrivilegeDecorator(new UserManagementImpl());
        }

        public ZoneManagement GetZoneManagement()
        {
            return new ZoneManagementPrivilegeDecorator(new ZoneManagementImpl());
        }
    }
}

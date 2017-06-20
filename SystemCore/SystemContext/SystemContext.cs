using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Services.SMS;
using SystemCore.SystemActions.SensorEventsHandler;
using SystemCore.SystemActions.SensorEventsHandler.Impl;
using SystemCore.SystemActions.UserManagement;
using SystemCore.SystemActions.UserManagement.Impl;
using SystemCore.SystemActions.ZoneManagement;
using SystemCore.SystemActions.ZoneManagement.Impl;
using SystemCore.Users;
using SystemCore.Exceptions;
using SystemCore.Helpers;
using SystemCore.Devices.Alarm;

namespace SystemCore.SystemContext
{
    public static class SystemContext
    {
        private static User _user;

        public static User CurrentUser {
            get
            {
                if (_user == null)
                    throw new AccessDeniedException("No user is logged in.");
                return _user;
            }
            private set
            {
                if (_user != null && value != null)
                    throw new AccessDeniedException("First current user must log out.");
                _user = value;
            }
        }

        public static SensorsProvider SensorsProvider { get; private set; }

        public static SensorsManager SensorsManager { get; private set; }

        public static SystemLogger SystemLogger { get; private set; }

        public static SMSService SMSService { get; private set; }

        public static UserManagement UserManagement { get; private set; }

        public static SensorEventsHandler SensorEventsHandler { get; private set; }

        public static ZoneManagement ZoneManagement { get; private set; }

        public static AlarmSystem AlarmSystem { get; private set; }

        public static void InitSystemContext(SystemContextConstructor systemContextTemplate)
        {
            if (systemContextTemplate == null)
                throw new ArgumentNullException("systemContextTemplate");

            // czynności przed inicjalizacją komponentów
            systemContextTemplate.BeforeInit();

            SystemLogger = systemContextTemplate.GetSensorsLogger();

            SensorsProvider = systemContextTemplate.GetSensorsProvider();

            SensorsManager = systemContextTemplate.GetSensorsManager();

            SMSService = systemContextTemplate.GetSMSService();

            UserManagement = systemContextTemplate.GetUserManagement();

            SensorEventsHandler = systemContextTemplate.GetSensorEventsHandler();

            ZoneManagement = systemContextTemplate.GetZoneManagement();

            AlarmSystem = systemContextTemplate.GetAlarmSystem();

            // czynności po inicjalizacji komponentów
            systemContextTemplate.AfterInit();

            if (SensorsProvider == null || SensorsManager == null || 
                SystemLogger == null || SMSService == null || UserManagement == null || 
                SensorEventsHandler == null || ZoneManagement == null || AlarmSystem == null)
            {
                throw new InvalidOperationException("One of services isn't instantiated.");
            }
        }

        public static void LoginUser(User user, string password)
        {
            CurrentUser = user;
            _LogAction(string.Format("Użytkownik [{0}] zalogował się.", user.Name));
        }

        public static void LogoutUser(User user)
        {
            if (IsSomeoneLoggedIn() && CurrentUser != user)
                throw new AccessDeniedException("Niewłaściwy użytkownik próbuje sie wylogować.");
            CurrentUser = null;
            _LogAction(string.Format("Użytkownik [{0}] wylogował się.", user.Name));
        }

        public static bool IsSomeoneLoggedIn()
        {
            return _user != null;
        }

        public static void LogAction(string source, string msg, params object[] paramsStr)
        {
            if(paramsStr.Length == 0)
                SystemLogger.Log(EventHelper.MakeMessage(source, msg));
            else
                SystemLogger.Log(EventHelper.MakeMessage(source, string.Format(msg, paramsStr)));
        }

        private static void _LogAction(string msg)
        {
            var ev = EventHelper.MakeMessage("SystemContext", msg);
            SystemLogger.Log(ev);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Services.SMS;
using SystemCore.SystemActions.UserManagement;
using SystemCore.SystemActions.ZoneManagement;
using SystemCore.SystemActions.SensorEventsHandler;
using SystemCore.Devices.Alarm;

namespace SystemCore.SystemContext
{
    public interface SystemContextConstructor
    {
        /// <summary>
        /// Metoda wywoływana jako pierwsza podczas konstruowania kontekstu.
        /// </summary>
        void BeforeInit();

        /// <summary>
        /// Konstruuje i zwraca loggera.
        /// </summary>
        /// <returns></returns>
        SystemLogger GetSensorsLogger();

        /// <summary>
        /// Konstruuje i zwraca managera sensorów.
        /// </summary>
        /// <returns></returns>
        SensorsManager GetSensorsManager();

        /// <summary>
        /// Konstruuje i zwraca dostawcę providerów.
        /// </summary>
        /// <returns></returns>
        SensorsProvider GetSensorsProvider();

        /// <summary>
        /// Konstruuje i zwraca obiekt proxy do wysylania wiadomosci.
        /// </summary>
        /// <returns></returns>
        SMSService GetSMSService();

        /// <summary>
        /// Konstruuje i zwraca menadżera użytkowników systemu.
        /// </summary>
        /// <returns></returns>
        UserManagement GetUserManagement();

        /// <summary>
        /// Konstruuje i zwraca menadżera stref czujników.
        /// </summary>
        /// <returns></returns>
        ZoneManagement GetZoneManagement();

        /// <summary>
        /// Konstruuje i zwraca menadżera zdarzeń.
        /// </summary>
        /// <returns></returns>
        SensorEventsHandler GetSensorEventsHandler();

        /// <summary>
        /// Konstruuje i zwraca kontroler alarmu.
        /// </summary>
        /// <returns></returns>
        AlarmSystem GetAlarmSystem();

        /// <summary>
        /// Metoda wywoływana jako ostatnia podczas konstruowania kontekstu.
        /// </summary>
        void AfterInit();
    }
}

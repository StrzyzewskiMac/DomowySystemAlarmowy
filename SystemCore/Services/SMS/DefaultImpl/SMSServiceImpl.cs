using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Sensors;
using SystemCore.Sensors.SensorEvents;
using SystemModel.TO;

namespace SystemCore.Services.SMS.DefaultImpl
{
    public class SMSServiceImpl : SMSService
    {
        private const string MSG_MESSAGE_SENT = "Wiadomość \"{0}\" zostałą wysłana do {1}";
        private const string SERVICE_NAME = "SMSService";

        /// <summary>
        /// Tworzy nową wiadomość do wysłania.
        /// </summary>
        /// <returns></returns>
        public SMSMessage NewMessage()
        {
            return new SMSMessageImpl();
        }

        public bool SendMessage(SMSMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            // Wysylanie wiadomosci...

            LogMessage(message);
            return true;
        }

        private void LogMessage(SMSMessage msg)
        {
            string phoneNumbers = string.Join<string>(", ", msg.Recipients.Select(r => r.PhoneNumber));
            var eventMsg = new Event
            {
                EventDescription = string.Format(MSG_MESSAGE_SENT, msg.Message, phoneNumbers),
                EventType = EventType.MESSAGE,
                Severity = EventSeverity.INFO,
                SensorId = "SMSService"
            };

            SystemContext.SystemContext.SystemLogger.Log(eventMsg);
        }
    }
}

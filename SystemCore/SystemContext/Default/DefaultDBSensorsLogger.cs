using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Sensors.SensorEvents;
using SystemCore.Mappers;
using SystemModel.DAO;

namespace SystemCore.SystemContext.Default
{
    public class DefaultDBLogger : SystemLogger
    {
        public IEnumerable<Event> GetAllEvents()
        {
            return EventDAO.GetInstance().GetAll().Select(EventTO2Event.Map);
        }

        /// <summary>
        /// Logguje wszystkie zdarzenia zgłoszone przez czujniki w bazie danych.
        /// </summary>
        /// <param name="sensorEvent"></param>
        public void Log(Event sensorEvent)
        {
            if (sensorEvent == null)
                throw new ArgumentNullException("sensorEvent");

            // mapowanie do TO i zapisanie w bazie danych
            var mappedTo = Event2EventTO.Map(sensorEvent);
            EventDAO.GetInstance().Insert(mappedTo);
        }
    }
}

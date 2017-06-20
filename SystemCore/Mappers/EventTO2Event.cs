using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModel.TO;
using SystemCore.Sensors.SensorEvents;

namespace SystemCore.Mappers
{
    /// <summary>
    /// Klasa zapewniająca metody konwertujące SensorEventTO do SensorEvent
    /// </summary>
    public static class EventTO2Event
    {
        /// <summary>
        /// Mapuje SensorEventTO na SensorEvent.
        /// </summary>
        /// <param name="sensorEventTO"></param>
        /// <returns></returns>
        public static Event Map(EventTO sensorEventTO)
        {
            var mapper = EventMapperFactory.GetMapper(sensorEventTO.SourceType);
            return mapper.Map(sensorEventTO);
        }

        /// <summary>
        /// Mapuje kolekcję SensorEventTO do SensorEvent
        /// </summary>
        /// <param name="sensorEventTOs"></param>
        /// <returns></returns>
        public static IEnumerable<Event> Map(IEnumerable<EventTO> sensorEventTOs)
        {
            if (sensorEventTOs == null)
                throw new ArgumentNullException("sensorEventTOs");

            foreach (var sensorEventTO in sensorEventTOs)
                yield return Map(sensorEventTO);
        }
    }
}

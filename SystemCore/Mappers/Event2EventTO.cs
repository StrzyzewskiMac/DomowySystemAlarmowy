using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Sensors.SensorEvents;
using SystemModel.TO;

namespace SystemCore.Mappers
{
    public static class Event2EventTO
    {
        /// <summary>
        /// Mapuje SensorEvent na SensorEventTO.
        /// </summary>
        /// <param name="sensorEvent"></param>
        /// <returns></returns>
        public static EventTO Map(Event sensorEvent)
        {
            if (sensorEvent == null)
                throw new ArgumentNullException("sensorEvent");

            var mapper = EventMapperFactory.GetMapper(sensorEvent.EventType);
            var mapped = mapper.Map(sensorEvent);
            return mapped;
        }

        /// <summary>
        /// Mapuje kolekcję SensorEvent na SensorEventTO.
        /// </summary>
        /// <param name="sensorEvents"></param>
        /// <returns></returns>
        public static IEnumerable<EventTO> Map(IEnumerable<Event> sensorEvents)
        {
            if (sensorEvents == null)
                throw new ArgumentNullException("sensorEvents");

            foreach (var sensorEvent in sensorEvents)
                yield return Map(sensorEvent);
        }
    }
}

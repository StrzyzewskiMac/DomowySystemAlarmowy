using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModel.TO;

namespace SystemCore.Sensors.SensorEvents.SensorEventMappers
{
    public class DefaultSensorEventMapper : EventMapper
    {
        public EventTO Map(Event sensorEvent)
        {
            return new EventTO
            {
                EventId = sensorEvent.Id,
                EventSource = sensorEvent.SensorId,
                EventDescription = sensorEvent.EventDescription,
                EventDate = sensorEvent.EventDate,
                Severity = (int)sensorEvent.Severity,
                SourceType = sensorEvent.EventType.ToString()
            };
        }

        public IEnumerable<EventTO> Map(IEnumerable<Event> sensorEvents)
        {
            if (sensorEvents == null)
                throw new ArgumentNullException("sensorEvents");

            foreach (var sensorEvent in sensorEvents)
                yield return Map(sensorEvent);
        }

        public IEnumerable<Event> Map(IEnumerable<EventTO> eventTOs)
        {
            foreach (var to in eventTOs)
                yield return Map(to);
        }

        public Event Map(EventTO eventTO)
        {
            return new Event
            {
                Id = eventTO.EventId,
                SensorId = eventTO.EventSource,
                EventDate = eventTO.EventDate,
                EventDescription = eventTO.EventDescription,
                Severity = (EventSeverity)eventTO.Severity,
                EventType = EventType.UNKNOWN
            };
        }
    }
}

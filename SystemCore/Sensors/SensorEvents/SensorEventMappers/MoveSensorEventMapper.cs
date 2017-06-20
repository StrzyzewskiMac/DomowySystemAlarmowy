using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModel.TO;
using SystemCore.Sensors.SensorEvents.SpecificSensorEvents;

namespace SystemCore.Sensors.SensorEvents.SensorEventMappers
{
    public class MoveSensorEventMapper : EventMapper
    {
        public EventTO Map(Event sensorEvent)
        {
            var castedSensorEvent = sensorEvent as MoveSensorEvent;

            if (castedSensorEvent == null)
                throw new ArgumentException("Invalid type of sensorEvent. Expected MoveSensorEvent, get - " + sensorEvent.GetType().Name);

            return new EventTO
            {
                EventId = castedSensorEvent.Id,
                EventSource = castedSensorEvent.SensorId,
                EventDescription = castedSensorEvent.EventDescription,
                EventDate = castedSensorEvent.EventDate,
                Severity = (int)castedSensorEvent.Severity,
                SourceType = castedSensorEvent.EventType.ToString(),
                EventPar1 = castedSensorEvent.Distance.ToString(),
                EventPar2 = castedSensorEvent.Angle.ToString()
            };
        }

        public IEnumerable<EventTO> Map(IEnumerable<Event> sensorEvents)
        {
            if (sensorEvents == null)
                throw new ArgumentNullException("sensorEvents");

            foreach (var sensorEvent in sensorEvents)
                yield return Map(sensorEvent);
        }

        public Event Map(EventTO eventTO)
        {
            float distance = .0f;
            float.TryParse(eventTO.EventPar1, out distance);
            float angle = .0f;
            float.TryParse(eventTO.EventPar2, out angle);

            return new MoveSensorEvent
            {
                Id = eventTO.EventId,
                SensorId = eventTO.EventSource,
                EventDescription = eventTO.EventDescription,
                EventDate = eventTO.EventDate,
                Severity = (EventSeverity)eventTO.Severity,
                Distance = distance,
                Angle = angle,
                EventType = EventType.MOVE_SENSOR
            };
        }

        public IEnumerable<Event> Map(IEnumerable<EventTO> eventTOs)
        {
            if (eventTOs == null)
                throw new ArgumentNullException("eventTOs");

            foreach (var eventTO in eventTOs)
                yield return Map(eventTO);
        }
    }
}

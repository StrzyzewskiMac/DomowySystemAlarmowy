using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Sensors.SensorEvents.SensorEventMappers;

namespace SystemCore.Sensors.SensorEvents
{
    public static class EventMapperFactory
    {
        private static readonly Dictionary<EventType, EventMapper> _mappers = new Dictionary<EventType, EventMapper>()
        {
            { EventType.UNKNOWN, new DefaultSensorEventMapper() },
            { EventType.MOVE_SENSOR, new MoveSensorEventMapper() }
        };

        /// <summary>
        /// Zwraca odpowiedni mapper dla SensorEvent
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static EventMapper GetMapper(EventType type)
        {
            EventMapper sem = null;
            _mappers.TryGetValue(type, out sem);
            return sem ?? _mappers[EventType.UNKNOWN];
        }

        /// <summary>
        /// Do użycia przy typie czujnika zapisanym jako łańcuch znaków, zamiast Enum.
        /// </summary>
        /// <param name="sensorType"></param>
        /// <returns>Odpowiedni mapper, bądź domyślny mapper jeśli nie znaleziono wyspecjalizowanej wersji.</returns>
        public static EventMapper GetMapper(string sensorType)
        {
            EventType deductedType = EventType.UNKNOWN;
            Enum.TryParse(sensorType, out deductedType);

            return GetMapper(deductedType);
        }

        /// <summary>
        /// Dodaje nowy mapper do fabryki. Jeśli wcześniej z danym typem czujnika był związany
        /// inny mapper, zostanie zwrócony, w przeciwnym wypadku metoda zwraca null.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        public static EventMapper AddMapper(EventType type, EventMapper mapper)
        {
            EventMapper sem = null;
            _mappers.TryGetValue(type, out sem);
            _mappers[type] = mapper;
            return sem;
        }
    }
}

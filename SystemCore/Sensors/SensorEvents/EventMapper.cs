using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModel.TO;

namespace SystemCore.Sensors.SensorEvents
{
    public interface EventMapper
    {
        Event Map(EventTO eventTO);

        EventTO Map(Event sensorEvent);

        IEnumerable<Event> Map(IEnumerable<EventTO> eventTOs);

        IEnumerable<EventTO> Map(IEnumerable<Event> sensorEvents);
    }
}

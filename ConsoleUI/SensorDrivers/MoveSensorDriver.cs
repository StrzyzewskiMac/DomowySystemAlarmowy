using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Sensors.Drivers;
using SystemCore.Sensors.SensorEvents;

namespace ConsoleUI.SensorDrivers
{
    public class MoveSensorDriver : SensorDriver
    {

        public SensorState CurrentState
        {
            get; private set;
        }

        public int CurrentStateCode
        {
            get; private set;
        }

        public Action<Event> EventCallback
        {
            get; set;
        }

        public IReadOnlyDictionary<string, object> Params
        {
            get
            {
                return null;
            }
        }

        public Action<SensorState> StateChangedCallback
        {
            get; set;
        }

        public bool ChangeState(SensorState newState)
        {
            CurrentState = newState;
            StateChangedCallback?.Invoke(newState);

            return true;
        }

        public object SetParam(string paramName, object newValue)
        {
            return null;
        }
    }
}

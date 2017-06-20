using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Devices.Alarm
{
    public interface AlarmSystem
    {
        void TurnOnAlarm(int beepLengthInMs, int beepIntervalInMs);

        void TurnOffAlarm();

        bool AlarmOn { get; }

        int BeepLengthInMiliseconds { get; }

        int BeepIntervalInMiliseconds { get; }
    }
}

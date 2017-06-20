using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Devices.Alarm.Impl
{
    public class AlarmSystemMuterDecorator : AlarmSystem
    {
        private readonly AlarmSystem _alarmSystem;

        public AlarmSystemMuterDecorator(AlarmSystem alarmS)
        {
            _alarmSystem = alarmS ?? throw new ArgumentNullException(nameof(alarmS));
        }

        public bool AlarmOn { get { return _alarmSystem.AlarmOn; } }

        public int BeepLengthInMiliseconds
        {
            get
            {
                return _alarmSystem.BeepLengthInMiliseconds;
            }
        }

        public int BeepIntervalInMiliseconds
        {
            get
            {
                return _alarmSystem.BeepIntervalInMiliseconds;
            }
        }

        public void TurnOffAlarm()
        {
            if(Enabled)
                _alarmSystem.TurnOffAlarm();
        }

        public void TurnOnAlarm(int beepLengthInMs, int beepIntervalInMs)
        {
            if(Enabled)
                _alarmSystem.TurnOnAlarm(beepLengthInMs, beepIntervalInMs);
        }

        public bool Enabled { get; set; } = true;
    }
}

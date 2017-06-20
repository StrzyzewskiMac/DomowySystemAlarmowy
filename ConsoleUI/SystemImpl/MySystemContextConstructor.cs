using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Devices.Alarm;
using SystemCore.Devices.Alarm.Impl;
using SystemCore.SystemContext;
using SystemCore.SystemContext.Default;

namespace ConsoleUI.SystemImpl
{
    public class MySystemContextConstructor : DefaultSystemContextConstructor
    {
        public override void AfterInit()
        {
            SystemContext.SensorsManager.AddSensors(SystemContext.SensorsProvider.FindAllSensors(null));
        }

        public override void BeforeInit()
        {
            
        }

        public override SensorsProvider GetSensorsProvider()
        {
            return new MySensorsProvider();
        }

        public override AlarmSystem GetAlarmSystem()
        {
            return new AlarmSystemMuterDecorator(base.GetAlarmSystem());
        }
    }
}

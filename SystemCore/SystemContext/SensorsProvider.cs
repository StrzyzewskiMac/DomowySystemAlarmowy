using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Sensors;

namespace SystemCore.SystemContext
{
    /// <summary>
    /// Interfejs modułu znajdującego aktywne czujniki, np. wszystkie czujniki
    /// podłączone do sieci.
    /// </summary>
    public interface SensorsProvider
    {
        IEnumerable<SensorInfo> FindAllSensors(object discriminator);
    }
}

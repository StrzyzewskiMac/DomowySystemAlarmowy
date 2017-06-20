using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Sensors;

namespace SystemCore.SystemContext
{
    /// <summary>
    /// Moduł zarządzający zarejestrowanymi w systemie czujnikami.
    /// </summary>
    public interface SensorsManager
    {
        /// <summary>
        /// Obejmuje zarządzaniem pojedynczy czujnik.
        /// </summary>
        /// <param name="sensor"></param>
        void AddSensor(SensorInfo sensor);

        /// <summary>
        /// Obejmuje zarządzaniem kolekcji czujników.
        /// </summary>
        /// <param name="sensors"></param>
        void AddSensors(IEnumerable<SensorInfo> sensors);

        /// <summary>
        /// Zwraca kolekcję wszystkich zarejestrowanych czujników.
        /// </summary>
        /// <returns></returns>
        IEnumerable<SensorInfo> GetAllSensors();

        /// <summary>
        /// Zwraca pojedynczy czujnik o danym id.
        /// </summary>
        /// <param name="sensorId"></param>
        /// <returns></returns>
        SensorInfo GetSensor(string sensorId);
    }

    /// <summary>
    /// Moduł zarządzający zarejestrowanymi czujnikami.
    /// </summary>
    [Obsolete]
    public abstract class SensorsManagerBase
    {
        /// <summary>
        /// Dodaje do zarządcy nowy czujnik.
        /// </summary>
        /// <param name="sensor"></param>
        public abstract void AddSensor(SensorInfo sensor);

        /// <summary>
        /// Dodaje do zarządcy kilka czujników
        /// </summary>
        /// <param name="sensors"></param>
        public virtual void AddSensors(IEnumerable<SensorInfo> sensors)
        {
            if (sensors == null)
                throw new ArgumentNullException("sensors");
            foreach (var sensor in sensors)
                AddSensor(sensor);
        }

        /// <summary>
        /// Zwraca enumerator do wszystkich obecnie zarejestrowanych czujników.
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<SensorInfo> GetAllSensors();

        /// <summary>
        /// Zwraca konkretny sensor, bądź null jeśli nie jest zarejestrowany
        /// w systemie czujnik o takim identyfikatorze.
        /// </summary>
        /// <param name="sensorId">Identyfikator czujnika.</param>
        /// <returns></returns>
        public abstract SensorInfo GetSensor(string sensorId);
    }
}

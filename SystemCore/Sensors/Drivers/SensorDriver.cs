using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Sensors.SensorEvents;

namespace SystemCore.Sensors.Drivers
{
    /// <summary>
    /// Interfejs, który muszą udostępniać sterowniki czujników.
    /// </summary>
    public interface SensorDriver
    {
        /// <summary>
        /// Metoda, która jest wywoływana, gdy zajdzie jakieś zdarzenie w systemie.
        /// </summary>
        Action<Event> EventCallback { get; set; }

        /// <summary>
        /// Metoda wywoływana gdy zmieni się stan czujnika (chodzi o stan wewnętrzny czujnika,
        /// nie zdarzenia jak np. wykrycie ruchu)
        /// </summary>
        Action<SensorState> StateChangedCallback { get; set; }

        /// <summary>
        /// Podaje aktualny stan czujnika.
        /// </summary>
        SensorState CurrentState { get; }

        /// <summary>
        /// Zwraca kod obecnego stanu w jakim znajduje się urządzenie.
        /// Używany, gdy CurrentState zwraca SensorState.UNKNOWN.
        /// </summary>
        int CurrentStateCode { get; }

        /// <summary>
        /// Zmienia stan czujnika.
        /// </summary>
        /// <param name="newState">Nowy stan.</param>
        /// <returns>True jeśli udało się zmienić na nowy stan, false inaczej.</returns>
        bool ChangeState(SensorState newState);

        /// <summary>
        /// Zwraca parametry czujnika.
        /// </summary>
        IReadOnlyDictionary<string, object> Params { get; }

        /// <summary>
        /// Zmienia/ustawia parametr czujnika.
        /// </summary>
        /// <param name="paramName">Nazwa parametru.</param>
        /// <param name="newValue">Nowa wartość parametru.</param>
        /// <exception cref="ArgumentException">Rzucany, gdy nie istnieje dany parametr.</exception>
        /// <returns>Null jeśli wartość jest ustawiona po raz pierwszy, w innym wypadku zwraca poprzednią wartość parametru.</returns>
        object SetParam(string paramName, object newValue);
    }
}

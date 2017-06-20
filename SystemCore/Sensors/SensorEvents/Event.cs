using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Sensors.SensorEvents
{
    public class Event
    {
        /// <summary>
        /// Unikalne id zdarzenia. Może być null, bądź mniejsze od zera jeśli zdarzenie ma być wstawione do db.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Unikalny identyfikator sensora.
        /// </summary>
        public string SensorId { get; set; }

        /// <summary>
        /// Opis zdarzenia. Niekoniecznie w formie wypowiedzi, może to być np. ciąg parametrów oddzielonych przecinkiem.
        /// </summary>
        public string EventDescription { get; set; }

        /// <summary>
        /// Data i czas zajścia zdarzenia.
        /// </summary>
        public DateTime? EventDate { get; set; }

        /// <summary>
        /// "Poważność" zdarzenia.
        /// </summary>
        public EventSeverity Severity { get; set; }

        /// <summary>
        /// Typ sensora. Jeśli typ ten jest inny niż UNKNOWN, można użyć tej informacji do rzutowania tego typu w dół,
        /// w celu pozyskania dokładniejszych informacji zawartych wcześniej w EventPar1-4.
        /// </summary>
        public EventType EventType { get; set; }

    }
}

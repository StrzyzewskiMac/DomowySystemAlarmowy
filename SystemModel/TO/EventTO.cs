using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemModel.TO
{
    /// <summary>
    /// Obiekt opisujący pojedyncze zdarzenie, które zostało zgłoszone do systemu przez czujniki.
    /// </summary>
    public class EventTO
    {
        /// <summary>
        /// Unikalne id zdarzenia.
        /// </summary>
        public int? EventId { get; set; }

        /// <summary>
        /// Źródło zdarzenia - unikalny identyfikator czujnika
        /// </summary>
        public string EventSource { get; set; }

        /// <summary>
        /// Rodzaj sensora. Może być null, wtedy będzie traktowany jako UNKNOWN.
        /// </summary>
        public string SourceType { get; set; }

        /// <summary>
        /// Opis zdarzenia/parametry w czasie zajścia zdarzenia itp.
        /// </summary>
        public string EventDescription { get; set; }

        /// <summary>
        /// Data i czas zajścia zdarzenia.
        /// </summary>
        public DateTime? EventDate { get; set; }

        /// <summary>
        /// "Poważność" zdarzenia.
        /// </summary>
        public int Severity { get; set; }

        /// <summary>
        /// Dodatkowy parametr używany przez wyspecjalizowane parsery zdarzeń.
        /// </summary>
        public string EventPar1 { get; set; }

        /// <summary>
        /// Dodatkowy parametr używany przez wyspecjalizowane parsery zdarzeń.
        /// </summary>
        public string EventPar2 { get; set; }

        /// <summary>
        /// Dodatkowy parametr używany przez wyspecjalizowane parsery zdarzeń.
        /// </summary>
        public int EventPar3 { get; set; }

        /// <summary>
        /// Dodatkowy parametr używany przez wyspecjalizowane parsery zdarzeń.
        /// </summary>
        public int EventPar4 { get; set; }
    }
}

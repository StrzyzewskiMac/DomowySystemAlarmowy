using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemModel.TO
{
    /// <summary>
    /// Obiekt TO przechowujący szablon wiadomości wysyłanej jako SMS do użytkowników
    /// </summary>
    public class MessageTemplateTO
    {
        /// <summary>
        /// Unikalny identyfikator szablonu wiadomości.
        /// </summary>
        public int? MessageId { get; set; }

        /// <summary>
        /// Tytuł wiadomości, do wyświetlania w ComboBoxie czy
        /// czymś podobnym.
        /// </summary>
        public string MessageTitle { get; set; }

        /// <summary>
        /// Szablon wiadomości do użycia w metodzie String.Format
        /// </summary>
        public string MessageTemplate { get; set; }
    }
}

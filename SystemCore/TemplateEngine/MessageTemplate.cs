using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.TemplateEngine
{
    /// <summary>
    /// Obiekt przechowujący szablon wiadomości wysyłanej jako SMS do użytkowników
    /// </summary>
    public class MessageTemplate
    {
        /// <summary>
        /// Unikalny identyfikator szablonu wiadomości.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Tytuł wiadomości, do wyświetlania w ComboBoxie czy
        /// czymś podobnym.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Szablon wiadomości do użycia w metodzie String.Format
        /// </summary>
        public string Template { get; set; }
    }
}

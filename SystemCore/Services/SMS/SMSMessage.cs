using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Services.SMS
{
    public interface SMSMessage
    {
        /// <summary>
        /// Tytuł wiadomości.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Treść wiadomości.
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Lista odbiorców.
        /// </summary>
        IList<SMSRecipient> Recipients { get; }
    }
}

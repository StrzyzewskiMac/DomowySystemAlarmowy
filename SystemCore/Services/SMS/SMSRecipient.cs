using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Services.SMS
{
    /// <summary>
    /// Pojedynczy odbiorca wiadomości.
    /// </summary>
    public struct SMSRecipient
    {
        public string PhoneNumber { get; set; }
    }
}

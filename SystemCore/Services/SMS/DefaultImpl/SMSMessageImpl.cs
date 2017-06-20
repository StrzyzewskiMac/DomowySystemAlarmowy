using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Services.SMS.DefaultImpl
{
    public class SMSMessageImpl : SMSMessage
    {
        private readonly List<SMSRecipient> _recipients = new List<SMSRecipient>();

        public string Message
        {
            get;
            set;
        }

        public IList<SMSRecipient> Recipients
        {
            get
            {
                return _recipients;
            }
        }

        public string Title
        {
            get;
            set;
        }
        
    }
}

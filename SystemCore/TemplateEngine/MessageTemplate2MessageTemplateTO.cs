using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModel.TO;

namespace SystemCore.TemplateEngine
{
    /// <summary>
    /// Klasa mapująca MessageTemplate na MessageTemplateTO
    /// </summary>
    public static class MessageTemplate2MessageTemplateTO
    {
        /// <summary>
        /// Mapuje pojedynczy element.
        /// </summary>
        /// <param name="messageTemplate"></param>
        /// <returns></returns>
        public static MessageTemplateTO map(MessageTemplate messageTemplate)
        {
            if (messageTemplate == null)
                throw new ArgumentNullException("messageTemplate");

            return new MessageTemplateTO
            {
                MessageId = messageTemplate.Id,
                MessageTitle = messageTemplate.Title,
                MessageTemplate = messageTemplate.Template
            };
        }

        /// <summary>
        /// Mapuje serię elementów.
        /// </summary>
        /// <param name="messageTemplates"></param>
        /// <returns></returns>
        public static IEnumerable<MessageTemplateTO> map(IEnumerable<MessageTemplate> messageTemplates)
        {
            if (messageTemplates == null)
                throw new ArgumentNullException("messageTemplates");

            foreach (var messageTemplate in messageTemplates)
                yield return map(messageTemplate);
        }
    }
}

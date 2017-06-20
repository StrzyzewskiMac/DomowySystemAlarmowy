using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModel.TO;

namespace SystemCore.TemplateEngine
{
    /// <summary>
    /// Klasa mapująca MessageTemplateTO na MessageTemplate
    /// </summary>
    public static class MessageTemplateTO2MessageTemplateMapper
    {
        public static MessageTemplate map(MessageTemplateTO messageTemplateTO)
        {
            if (messageTemplateTO == null)
                throw new ArgumentNullException("messageTemplateTO");

            return new MessageTemplate
            {
                Id = messageTemplateTO.MessageId,
                Title = messageTemplateTO.MessageTitle,
                Template = messageTemplateTO.MessageTemplate
            };
        }

        public static IEnumerable<MessageTemplate> map(IEnumerable<MessageTemplateTO> messageTemplateTOs)
        {
            if (messageTemplateTOs == null)
                throw new ArgumentNullException("messageTemplateTOs");

            foreach (var template in messageTemplateTOs)
                yield return map(template);
        }
    }
}

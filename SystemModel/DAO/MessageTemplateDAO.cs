using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModel.TO;
using Dapper;

namespace SystemModel.DAO
{
    public sealed class MessageTemplateDAO : AbstractDAO<MessageTemplateTO>
    {
        private static volatile MessageTemplateDAO _instance;
        private static object _mutex = new object();

        private const string QUERY_SELECT_BY_ID = 
            "select * from messages_templates where MessageId = @messageId";
        private const string QUERY_SELECT_IDs_AND_TITLES =
            "select MessageId, MessageTitle from messages_templates";

        public static MessageTemplateDAO GetInstance()
        {
            if(_instance == null)
            {
                lock(_mutex)
                {
                    if(_instance == null)
                        _instance = new MessageTemplateDAO();
                }
            }

            return _instance;
        }

        private MessageTemplateDAO() : base("messages_templates") { }

        /// <summary>
        /// Zwraca konkretny szablon o danym id, bądź null jeśli szablon o takim
        /// id nie istnieje w bazie.
        /// </summary>
        /// <param name="id">Id wiadomości > 0</param>
        /// <returns>Szablon wiadomości o danym id, bądź null jeśli takowa nie istnieje.</returns>
        public MessageTemplateTO GetById(int id)
        {
            using(var connection = GetConnection())
            {
                return connection.Query<MessageTemplateTO>(QUERY_SELECT_BY_ID, new { messageId = id }).FirstOrDefault();
            }
        }

        /// <summary>
        /// Pobiera tylko id i tytuły wszystkich wiadomości.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MessageTemplateTO> GetAllMessagesTitles()
        {
            using(var connection = GetConnection())
            {
                return connection.Query<MessageTemplateTO>(QUERY_SELECT_IDs_AND_TITLES);
            }
        }
    }
}

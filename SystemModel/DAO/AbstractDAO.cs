using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace SystemModel.DAO
{
    /// <summary>
    /// Abstrakcyjna klasa skupiająca wspólne metody dla wszystkich klas DAO.
    /// </summary>
    public abstract class AbstractDAO<T>
    {
        protected readonly string QUERY_SELECT_ALL;
        protected readonly string TABLE_NAME;

        protected AbstractDAO(string tableName)
        {
            TABLE_NAME = tableName;
            QUERY_SELECT_ALL = string.Format("select * from {0}", tableName);
        }

        public virtual IEnumerable<T> GetAll()
        {
            using(var connection = SQLiteDBConnection.GetInstance().GetConnection())
            {
                return connection.Query<T>(QUERY_SELECT_ALL);
            }
        }

        protected virtual IDbConnection GetConnection()
        {
            return SQLiteDBConnection.GetInstance().GetConnection();
        }
    }
}

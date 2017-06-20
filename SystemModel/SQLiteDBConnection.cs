using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemModel
{
    public class SQLiteDBConnection
    {
        //private static IDbConnection _connection;
        public const string DATABASE_NAME = "system.db";
        private static object mutex = new object();
        private static volatile SQLiteDBConnection _instance;
        private string _connectionString;

        public static SQLiteDBConnection GetInstance()
        {
            if (_instance == null)
            {
                lock (mutex)
                {
                    if (_instance == null)
                        _instance = new SQLiteDBConnection();
                }
            }

            return _instance;
        }

        public SQLiteDBConnection()
        {
            _connectionString = string.Format("Data Source={0}\\{1}", 
                Environment.CurrentDirectory, DATABASE_NAME);
        }

        public IDbConnection GetConnection()
        {
            var conn = new SQLiteConnection(_connectionString);
            conn.Open();
            return conn;
            //return new SqlConnection(_connectionString);
        }
    }
}

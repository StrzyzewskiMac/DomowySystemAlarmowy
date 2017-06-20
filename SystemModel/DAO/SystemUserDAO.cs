using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModel.TO;
using Dapper;

namespace SystemModel.DAO
{
    public class SystemUserDAO : AbstractDAO<SystemUserTO>
    {
        private const string QUERY_SELECT_BY_ID = "select * from users where UserId = @userId";
        private const string QUERY_SELECT_BY_PRIVILEGE_ID = "select * from users where PrivilegeId = @privilegeId";
        private const string QUERY_SELECT_BY_NAME = "select * from users where UserName = @userName";
        private const string QUERY_UPDATE = "UPDATE users SET UserName=@UserName, UserPassword=@UserPassword, PrivilegeId=@PrivilegeId, PhoneNumber=@PhoneNumber WHERE UserId=@UserId";
        private const string QUERY_INSERT = "INSERT INTO users(UserName, UserPassword, PrivilegeId, PhoneNumber) VALUES (@UserName, @UserPassword, @PrivilegeId, @PhoneNumber); SELECT last_insert_rowid()";
        private const string QUERY_DELETE = "REMOVE FROM users WHERE UserId=@UserId";

        private static volatile SystemUserDAO _instance;
        private static object _mutex = new object();

        public static SystemUserDAO GetInstance()
        {
            if(_instance == null)
            {
                lock(_mutex)
                {
                    if (_instance == null)
                        _instance = new SystemUserDAO();
                }
            }

            return _instance;
        }

        private SystemUserDAO() : base("users") { }

        /// <summary>
        /// Zwraca użytkownika o żądanym id, bądź null jeśli użytkownik nie istnieje. Jeżeli w systemie jest więcej użytkowników o tym id
        /// zostanie rzucony wyjątek InvalidOperationException.
        /// </summary>
        /// <param name="id">Id szukanego użytkownika.</param>
        /// <returns>Instancja SystemUserTO z danymi użytkownika o danym id, bądź null jeśli użytkownika nie ma w systemie.</returns>
        public SystemUserTO GetById(int id)
        {
            using(var connection = GetConnection())
            {
                return connection.Query<SystemUserTO>(QUERY_SELECT_BY_ID, new { userId = id }).SingleOrDefault();
            }
        }

        public SystemUserTO GetByName(string name)
        {
            using (var connection = GetConnection())
            {
                return connection.Query<SystemUserTO>(QUERY_SELECT_BY_NAME, new { userName = name }).SingleOrDefault();
            }
        }

        /// <summary>
        /// Zwraca wszystkich użytkowników, posiadających ten sam poziom dostępu.
        /// </summary>
        /// <param name="privId">Id poziomu dostępu.</param>
        /// <returns>Enumerator do obiektów SystemUserTO spełniających ww. wymaganie.</returns>
        public IEnumerable<SystemUserTO> GetByPrivilegeId(int privId)
        {
            using(var connection = GetConnection())
            {
                return connection.Query<SystemUserTO>(QUERY_SELECT_BY_PRIVILEGE_ID, new { privilegeId = privId });
            }
        }

        public SystemUserTO Update(SystemUserTO userTO)
        {
            if (userTO == null)
                throw new ArgumentNullException("userTO");

            using(var connection = GetConnection())
            {
                connection.Execute(QUERY_UPDATE, userTO);
            }

            return userTO;
        }

        public SystemUserTO Insert(SystemUserTO userTO)
        {
            if (userTO == null)
                throw new ArgumentNullException("userTO");

            using(var connection = GetConnection())
            {
                userTO.UserId = connection.Query<int?>(QUERY_INSERT, userTO).FirstOrDefault();
            }

            return userTO;
        }

        public void Delete(SystemUserTO userTO)
        {
            if (userTO == null)
                throw new ArgumentNullException("userTO");

            using(var connection = GetConnection())
            {
                connection.Execute(QUERY_DELETE, userTO);
            }
        }


    }
}

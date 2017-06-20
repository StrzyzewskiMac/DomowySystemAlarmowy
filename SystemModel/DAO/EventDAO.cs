using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModel.TO;
using Dapper;

namespace SystemModel.DAO
{
    /// <summary>
    /// Dostarcza metody do wymiany informacji o zdarzeniach w systemie z bazą danych.
    /// </summary>
    public sealed class EventDAO : AbstractDAO<EventTO>
    {
        private const string QUERY_INSERT_SENSOR_EVENT =
            "INSERT INTO events(EventSource, SourceType, EventDescription, EventDate, Severity, EventPar1, EventPar2, EventPar3, EventPar4) VALUES " +
            "(@EventSource, @SourceType, @EventDescription, @EventDate, @Severity, @EventPar1, @EventPar2, @EventPar3, @EventPar4); SELECT last_insert_rowid()";
        private const string QUERY_UPDATE_EVENT =
            "UPDATE events SET EventSource=@EventSource, SourceType=@SourceType, EventDescription=@EventDescription, EventDate=@EventDate, " +
            "Severity=@Severity, EventPar1=@EventPar1, EventPar2=@EventPar2, EventPar3=@EventPar3, EventPar4=@EventPar4 WHERE EventId=@EventId";
        private const string QUERY_SELECT_BY_ID = "select * from events where EventId = @eventId";

        private static volatile EventDAO _instance;
        private static object _mutex = new object();

        public static EventDAO GetInstance()
        {
            if(_instance == null)
            {
                lock(_mutex)
                {
                    if (_instance == null)
                        _instance = new EventDAO();
                }
            }

            return _instance;
        }


        private EventDAO() : base("events") { }

        public EventTO Insert(EventTO sensor)
        {
            if (sensor == null)
                throw new ArgumentNullException("sensor");

            if (sensor.EventDate == null)
                sensor.EventDate = DateTime.Now;

            using(var connection = GetConnection())
            {
                sensor.EventId = connection.Query<int?>(QUERY_INSERT_SENSOR_EVENT, sensor).First();
            }

            return sensor;
        }

        /// <summary>
        /// Zwraca konkretne zarejestrowane w systemie zdarzenie lub null jeśli nie istnieje zdarzenie o podanym id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EventTO GetById(int id)
        {
            using(var connection = GetConnection())
            {
                return connection.Query<EventTO>(QUERY_SELECT_BY_ID, new { eventId = id }).FirstOrDefault();
            }
        }

        public EventTO Update(EventTO ev) {
            if (ev == null)
                throw new ArgumentNullException("ev");

            using(var connection = GetConnection())
            {
                connection.Execute(QUERY_UPDATE_EVENT, ev);
            }

            return ev;
        }
    }
}

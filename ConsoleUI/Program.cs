using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModel.TO;
using SystemModel.DAO;
using SystemCore.Sensors;
using SystemCore.Sensors.SensorEvents;
using SystemCore.Sensors.SensorEvents.SpecificSensorEvents;
using SystemCore.SystemContext;
using ConsoleUI.SystemImpl;
using ConsoleUI.PageLayout;
using ConsoleUI.Pages;
using ConsoleUI.Pages.Impl;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            SystemContext.InitSystemContext(new MySystemContextConstructor());
            // login: Admin, hasło: password
            // login: SomeUser, hasło: pass

            Login();

            var pageLayoutManager = new PageLayoutManager();
            pageLayoutManager.StartPage = new MainPage();

            pageLayoutManager.Show();
        }

        private static void Login()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Logowanie do systemu:");
                var login = Helpers.PageHelper.GetValidInput<string>("Login: ");
                var password = Helpers.PageHelper.ReadInput<string>("Hasło: ");

                try
                {
                    Helpers.LoginHelper.SignIn(login, password);
                    break;
                }
                catch(Exception ex)
                {
                    Helpers.PageHelper.PrintError(ex);
                }
            }
        }

        private static void test2()
        {
            Event se = new MoveSensorEvent
            {
                SensorId = "move_detector_#1",
                EventType = EventType.MOVE_SENSOR,
                Severity = EventSeverity.DEBUG,
                Angle = 69.41f,
                Distance = 11.5f
            };

            var to = EventMapperFactory.GetMapper(EventType.MOVE_SENSOR).Map(se);
            to = EventDAO.GetInstance().Insert(to);
            int newId = to.EventId ?? 0;

            var readBackSensorEvent = EventDAO.GetInstance().GetById(newId);
            Event newSE = EventMapperFactory.GetMapper(readBackSensorEvent.SourceType).Map(readBackSensorEvent);

            
            return;
        }

        private static void test1()
        {
            foreach (var privilege in PrivilegeDAO.GetInstance().GetAll())
            {
                WritePrivilege(privilege);
            }

            WritePrivilege(PrivilegeDAO.GetInstance().GetById(2));

            foreach (var mess in MessageTemplateDAO.GetInstance().GetAllMessagesTitles())
            {
                WriteMessageTemplate(mess);
            }
        }

        private static void WritePrivilege(PrivilegeTO privilege)
        {
            Console.WriteLine("Id: {0}", privilege.PrivilegeId);
            Console.WriteLine("Name: {0}", privilege.PrivilegeName);
            Console.WriteLine("Description: {0}", privilege.PrivilegeDesc);
            Console.WriteLine("Level: {0}", privilege.PrivilegeLevel);
        }

        private static void WriteMessageTemplate(MessageTemplateTO messageTemplate)
        {
            Console.WriteLine("Id: {0}", messageTemplate.MessageId);
            Console.WriteLine("MessageTitle: {0}", messageTemplate.MessageTitle ?? string.Empty);
            Console.WriteLine("MessageTemplate: {0}", messageTemplate.MessageTemplate ?? string.Empty);
        }

        private static void WriteSensorEventTO(EventTO seTO)
        {
            Console.WriteLine("Id: {0}", seTO.EventId);
            Console.WriteLine("Sensor id: {0}", seTO.EventSource);
            Console.WriteLine("Source type: {0}", seTO.SourceType);
            Console.WriteLine("Description: {0}", seTO.EventDescription);
            Console.WriteLine("Event date: {0}", seTO.EventDate);
        }
    }
}

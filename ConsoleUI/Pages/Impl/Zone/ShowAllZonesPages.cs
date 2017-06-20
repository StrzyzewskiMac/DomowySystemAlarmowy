using System;
using SystemCore.SystemContext;

namespace ConsoleUI.Pages.Impl.Zone
{
    public class ShowAllZonesPages : PageBase
    {
        private const string TITLE = "Wszystkie strefy";

        public ShowAllZonesPages() : base(TITLE, string.Empty)
        {}

        public override void ShowCustomMessage()
        {
            foreach(var zone in SystemContext.ZoneManagement.GetAllSensorsGroupedByZone())
            {
                Console.WriteLine("Strefa #{0}:", zone.Key);
                foreach(var sensor in zone)
                {
                    Console.WriteLine("\tCzujnik id: {0}, stan: {1}", sensor.SensorId, sensor.Driver.CurrentState);
                }
            }
        }

        public override object GetInput()
        {
            Console.ReadLine();
            return base.GetInput();
        }
    }
}

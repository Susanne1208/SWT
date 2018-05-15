////using System;
////using System.Collections.Generic;
////using System.IO;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;

using System.IO;
using ATM.Interfaces;

namespace ATM
{
    public class EventRendition : IEventRendition
    {
        private readonly IProximityDetectionData _proximityDetectionData;

        public EventRendition(IProximityDetectionData proximityDetectionData)
        {
            _proximityDetectionData = proximityDetectionData;
        }

        public EventRendition()
        {
        }


        public void LogToFile()
        {
            string path = @"C:\Temp\Logfile.txt";
            string text = "Planes in conflict: " + _proximityDetectionData.Tag1 + " and " + _proximityDetectionData.Tag2 +
                          "\nTime of occurance: " + _proximityDetectionData.Timestamp;

            File.WriteAllText(path, text);
        }



        public void PrintEvent()
        {
            //Print the collision warning to the console
            System.Console.WriteLine(_proximityDetectionData);
        }
    }
}

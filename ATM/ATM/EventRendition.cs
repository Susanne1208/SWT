////using System;
////using System.Collections.Generic;
////using System.IO;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;

////namespace ATM
//{
//    public class EventRendition : IEventRendition
//    {
//        public EventRendition()
//        {
//        }

//        public void LogToFile(SeperationData seperationData)
//        {
//            string path = @"C:\Temp\Logfile.txt";
//            string text = "Planes in conflict: " + seperationData.TAG1 + " and " + seperationData.TAG2 +
//                              "\nTime of occurance: " + seperationData.TimeStamp;
//            File.WriteAllText(path, text);
//        }

//        public void PrintEvent(SeperationData seperationData)
//        {
//            System.Console.WriteLine(seperationData);
//        }
//    }
//}

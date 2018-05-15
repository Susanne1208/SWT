using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Interfaces;
using TransponderReceiver;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            ITransponderReceiver transponderDataReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();

            IEventRendition eventRendition = new EventRendition();
            ITrackRendition trackRendition = new TrackRendition();
            IProximityDetectionData proximityDetectionData = new IProximityDetectionData();
            

            IProximityDetection proximityDetection = new ProximityDetection(eventRendition, proximityDetectionData);
            ITrackUpdate trackUpdate = new TrackUpdate(trackRendition, proximityDetection);
            IFiltering filtering = new Filtering(trackUpdate);
            
            var decoder = new Parsing(transponderDataReceiver, filtering);
            System.Console.ReadLine();
        }
    }
}

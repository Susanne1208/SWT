using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ATM.Data;
using ATM.Interfaces;

namespace ATM
{
    public class ProximityDetection : IProximityDetection
    {
        private int HorizontalSeperation = 5000; //Horizontal seperation less than 5000 meters
        private int VerticalSeperation = 300; //vertical seperation less than 300 meters

        //private readonly IEventRendition _eventRendition;
        private readonly IEventRendition _eventRendition;
        private readonly ProximityDetectionData _proximityDetectionData;



        public ProximityDetection(IEventRendition eventRendition, ProximityDetectionData proximityDetectionData)
        {
            //Need to call LogToFile
            _eventRendition = eventRendition;
            _proximityDetectionData = proximityDetectionData;
        }

        public void CheckProximityDetection(List<ITrackData> trackDataList)
        {
            //Runs through the tracks in the trackDataList to see if any tracks are in collision distance
            foreach (var track1 in trackDataList)
            {
                foreach (var track2 in trackDataList)
                {
                    //Track data
                    double x1 = track1.X;
                    double x2 = track2.X;
                    double y1 = track1.Y;
                    double y2 = track2.Y;
                    double alt1 = track1.Altitude;
                    double alt2 = track1.Altitude;
                    

                    //Formula: sqrt((x1-x2)^2+(y1-y2)^2)
                    var horizantalDistance = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));

                    //vertical seperation less than 300 meters
                    var veritalDistance = Math.Abs(alt1 - alt2); 

                    // If the to two planes tag is different and is conflicting with the minimum seperation.
                    if (track1.Tag != track2.Tag && veritalDistance < VerticalSeperation && horizantalDistance < HorizontalSeperation)
                    {
                        //_proximityDetectionData(track1.Tag, track2.Tag, DateTime.Now);
                        _proximityDetectionData.Tag1 = track1.Tag;
                        _proximityDetectionData.Tag2 = track2.Tag;
                        _proximityDetectionData.Timestamp = DateTime.Now;
                        
                        //Sending data to EventRendition class to be log and printed on console application
                        //_eventRendition.LogToFile(_proximityDetectionData);
                        //_eventRendition.PrintEvent(_proximityDetectionData);
                        _eventRendition.PrintEvent();
                        _eventRendition.LogToFile();

                        //the time og the event needs to be logged to files or application
                        //track1.TimeStamp = DateTime.Now;
                        
                    }
                }
            }
        }
    }
}

//public bool IsTracksInConflict(TrackData track1, TrackData track2)
//{
//    //Formula: distance = sqrt((x1-x2)^2+(y1-y2)^2)
//    var horizantalDistance = Math.Sqrt(Math.Pow(track1.X - track2.X, 2) + Math.Pow(track2.Y - track2.Y, 2));

//    //vertical seperation less than 300 meters
//    var veritalDistance = Math.Abs(track1.Altitude - track2.Altitude);

//    if (track1.Tag != track2.Tag && veritalDistance < VerticalSeperation &&
//        horizantalDistance < HorizontalSeperation)
//    {
//        return true;
//    }
//    else return false;


//}

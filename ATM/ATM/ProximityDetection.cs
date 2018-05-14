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

        //Horizontal seperation less than 5000 meters
        private int HorizontalSeperation = 5000;

        //vertical seperation less than 300 meters
        private int VerticalSeperation = 300;

        private readonly IEventRendition _eventRendition;


        public ProximityDetection(IEventRendition eventRendition)
        {
            _eventRendition = eventRendition;
        }

        public void CheckProximityDetection(List<ITrackData> trackDataList)
        {
            
            foreach (var trackOne in trackDataList)
            {
                foreach (var trackTwo in trackDataList)
                {

                    double x1 = trackOne.X;
                    double x2 = trackTwo.X;
                    double y1 = trackOne.Y;
                    double y2 = trackTwo.Y;
                    double alt1 = trackOne.Altitude;
                    double alt2 = trackTwo.Altitude;

                    
                    //Formula: distance = sqrt((x1-x2)^2+(y1-y2)^2)
                    var horizantalDistance = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));

                    //vertical seperation less than 300 meters
                    var veritalDistance = Math.Abs(alt1 - alt2); 

                    // If the to two planes tag is different and is conflicting with the minimum seperation.
                    if (trackOne.Tag != trackTwo.Tag && veritalDistance < VerticalSeperation && horizantalDistance < HorizontalSeperation)
                    {
                        //Kan ikke kalde funktioner....
                        //_eventRendition.LogToFile();
                        //_eventRendition.PrintEvent();

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

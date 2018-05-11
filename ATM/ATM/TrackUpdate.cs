using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
   public class TrackUpdate
    {
        //opdater dens værdi. De tracks der er indenfor area
        //jeg får en liste af tracks fra filtering
        //hvad skal den opdatere?
        //og hvor kommer de fra
        //og hvor skal de placeres henne

        //to liser
        //en gammel og ny
        //hvor var jeg før 
        //find tag samme tag, dvs samme fly 
        //calvelocity
        //calcourse
       
        public List<IFiltering> oldList { get; }                      
        //public List<IFiltering> newList { get; }


        public TrackUpdate(List<IFiltering> newList)   //From Filtering
        {

            if (oldList == null)                      //Entrypoint
            {
                oldList = new List<IFiltering>();

                foreach (var track in newList)
                {
                    oldList.Add(track);               //now OldList is equal to Newlist

                }
            }

            foreach (var newTrack in newList)
            {
                foreach (var oldTrack in oldList)
                {
                    if(newTrack.Tag==oldTrack.Tag)
                        Console.WriteLine("Equal");
                }
            }

            
        }

        public void CalVelocity(TrackData track1, TrackData track2)
        {
            //Coordinates 
            x1 = track1.X;
            x2 = track2.X;
            y1 = track1.Y;
            y2 = track2.Y;

            //Distance between the 2 tracks
            double distance = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));

            double time = track2.Timestamp.Subtract(track1.Timestamp).TotalSeconds;

            track2.Velocity = distance / time;
        }



        public void CalCourse(TrackData track1, TrackData track2)
        {
            double deltaX = track2.X - track1.X;
            double deltaY = track2.Y - track1.Y;

            double Degree = 0;

            if (deltaX == 0)
            {
                //if deltaY er større end 0
                // condition ? first_expression : second_expression;
                Degree = deltaY > 0 ? 0 : 180;
            }
            else
            {
                double radian = Math.Atan2(deltaY, deltaX);
                //Convert to degress 
                Degree = radian / Math.PI * 180;

                Degree = 90 - Degree;
                if (Degree < 0)
                {
                    Degree += 360;
                }
            }

            track2.Course = Degree;

        }


    }


}
}

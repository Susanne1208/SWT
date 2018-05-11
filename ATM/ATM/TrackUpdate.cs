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
        public List<IFiltering> oldList { get; set; }                      
        //public List<IFiltering> newList { get; }
        public TrackUpdate(List<IFiltering> newList) 
        {
        }

        public void Update(List<IFiltering> newList) //From Filtering
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
                    CalVelocity(newTrack,oldTrack);
                    CalCourse(newTrack, oldTrack);
                }
            }

        }

        public void CalVelocity(IFiltering track1, IFiltering track2)
        {
            //Coordinates 
            newList.x1 = track1.X;
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

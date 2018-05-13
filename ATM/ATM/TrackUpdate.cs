using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ATM.Data;
using ATM.Interfaces;

namespace ATM
{
   public class TrackUpdate : ITrackUpdate
    {
        public List<ITrackData> oldList { get; set; }                      
        //public List<IFiltering> newList { get; }


        public List<ITrackData> Update(List<ITrackData> newList)
        {
            if (oldList == null)                      //Entrypoint
            {
                oldList = new List<ITrackData>();

                foreach (var track in newList)
                {
                    oldList.Add(track);               //now OldList is equal to Newlist
                }
            }
            else
            {
                foreach (var newTrack in newList)
                {

                    foreach (var oldTrack in oldList)
                    {
                        if (newTrack.Tag == oldTrack.Tag)
                        {
                            CalVelocity(newTrack, oldTrack); //i fortæller hvor oldtrack befinder sig 
                            CalCourse(newTrack, oldTrack);
                        }
                    }
                }

                //foreach (var newTrack in newList)
                //{
                //    oldList.Add(newTrack);
                //}
            }

            return oldList;
        }

        public int CalVelocity(ITrackData track1, ITrackData track2)
        {

            // calculate velocity


            //Coordinates 
            int x1 = track1.X;
            int x2 = track2.X;
            int y1 = track1.Y;
            int y2 = track2.Y;

            //Distance between the 2 tracks
            double distance = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));

            double time = track2.TimeStamp.Subtract(track1.TimeStamp).TotalSeconds;

            return (int)distance /(int) time;  //Updating speed
        }

        public double CalCourse(TrackData track1, TrackData track2)
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

            return Degree;
        }



    }


}


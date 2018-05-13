using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ATM.Interfaces;

namespace ATM
{
   public class TrackUpdate : ITrackUpdate
    {
        public List<IFiltering> oldList { get; set; }                      
        //public List<IFiltering> newList { get; }
        public List<IFiltering> Update(List<IFiltering> newList) //From Filtering
        {
            if (oldList == null)                      //Entrypoint
            {
                oldList = new List<IFiltering>();

                foreach (var track in newList)
                {
                    oldList.Add(track);               //now OldList is equal to Newlist
                }
            }
            else
            {
                foreach (var newTrack in newList)
                {

                    for (int i = 0; i > oldList.Count; i++)
                    {
                        if (newTrack.Tag == oldList[i].Tag)
                        {
                            CalVelocity(newTrack, oldList[i], i); //i fortæller hvor oldtrack befinder sig 
                            CalCourse(newTrack, oldList[i], i);
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


        public void CalVelocity(IFiltering track1, IFiltering track2, int index)
        {

            // calculate velocity


            //Coordinates 
            int x1 = track1.X;
            int x2 = track2.X;
            int y1 = track1.Y;
            int y2 = track2.Y;

            //Distance between the 2 tracks
            double distance = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));

            double time = track2.Timestamp.Subtract(track1.Timestamp).TotalSeconds;

            oldList[index].Velocity = distance / time;  //Updating speed
        }



        public void CalCourse(IFiltering track1, IFiltering track2, int index)
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

           oldList[index].Course = Degree;

        }


       
    }


}


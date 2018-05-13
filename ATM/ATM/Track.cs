using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Data;
using ATM.Interfaces;

namespace ATM
{
    class Track : ITrack
    {
        public TrackData ConvertData(string data)
        {
            TrackData track = new TrackData();


            var words = data.Split(';');

            track.Tag = words[0];
            track.X = int.Parse(words[1]);
            track.Y = int.Parse(words[2]);
            track.Altitude = int.Parse(words[3]); 
            track.TimeStamp = DateTime.ParseExact(words[4], "yyyyMMddHHmmssff", System.Globalization.CultureInfo.InvariantCulture);
            track.Course = 0;
            track.Velocity = 0;



            return track;
        }
    }
}

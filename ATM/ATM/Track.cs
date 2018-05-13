using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Data;
using ATM.Interfaces;
using TransponderReceiver;

namespace ATM
{
    class Track : /*ITrack*/
    {

        //private List<TrackData> trackList;
        //private ITrackDataReceiver receiverOutput;



        //public Track(ITransponderReceiver receiver, ITrackDataReceiver trackDataReceiver)
        //{//    receiver.TransponderDataReady += Data;
        //    receiverOutput = trackDataReceiver; 
        //    trackList = new List<TrackData>();

        //}

        //public void Data(object o, RawTransponderDataEventArgs args)
        //{
        //    trackList.Clear();

        //    foreach (var data in args.TransponderData)
        //    {
        //        trackList.Add(ConvertData(data));
        
        //    }

        //    receiverOutput.ReceiveTracks(trackList);
        //}


        //public TrackData ConvertData(string data)
        //{
        //    TrackData track = new TrackData();


        //    var words = data.Split(';');

        //    track.Tag = words[0];
        //    track.X = int.Parse(words[1]);
        //    track.Y = int.Parse(words[2]);
        //    track.Altitude = int.Parse(words[3]); 
        //    track.TimeStamp = DateTime.ParseExact(words[4], "yyyyMMddHHmmssff", System.Globalization.CultureInfo.InvariantCulture);
        //    track.Course = 0;
        //    track.Velocity = 0;



        //    return track;
        //}
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Data;
using ATM.Interfaces;
using TransponderReceiver;

namespace ATM
{
    class Parsing
    {
        private IFiltering _filtering;
        List<TrackData> trackList = new List<TrackData>();


        public Parsing(ITransponderReceiver receiver, IFiltering filtering) //subscring
        {
            receiver.TransponderDataReady += Data;
            _filtering = filtering;
            trackList = new List<TrackData>();

        }
        public TrackData ConvertData(string data) //parsing
        {
            TrackData track = new TrackData();


            var words = data.Split(';');

            track.Tag = words[0];
            track.X = int.Parse(words[1]);
            track.Y = int.Parse(words[2]);
            track.Altitude = int.Parse(words[3]);
            track.TimeStamp = DateTime.ParseExact(words[4], "yyyyMMddHHmmssff",
                System.Globalization.CultureInfo.InvariantCulture);
            track.Course = 0;
            track.Velocity = 0;



            return track;
        }
        public void Data(object o, RawTransponderDataEventArgs args)
        {

            List<TrackData> trackList = new List<TrackData>();
            trackList.Clear();

            foreach (var data in args.TransponderData)
            {
                trackList.Add(ConvertData(data));

            }

            _filtering.ValidateTracks(trackList);
        }


    }


}

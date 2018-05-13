﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Data;

namespace ATM
{
    public class TrackRendition : ITrackRendition
    {
        public TrackRendition()
        {
        }

        public void Print(List<TrackData> trackDataList)
        {
            foreach (var track in trackDataList)
            {
                System.Console.WriteLine(track);
            }
        }
    }
}
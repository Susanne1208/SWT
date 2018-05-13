using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Data;
using ATM.Interfaces;

namespace ATM
{
    public class TrackDataReceiver: ITrackDataReceiver
    {
        public void ReceiveTracks(List<TrackData> tracks)
        {
            foreach (var track in tracks)
            {
                System.Console.WriteLine(track);
                
            }
        }
    }
}

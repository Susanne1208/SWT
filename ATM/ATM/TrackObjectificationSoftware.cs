using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;
using System.Collections.Generic;
using ATM.Interfaces;

namespace ATM
{
    class TrackObjectificationSoftware : List<TrackObjectificationSoftware>
    {
        public List<ITrack> ReceivedTracks { get; set; } = new List<ITrack>();

        public TrackObjectificationSoftware(ITransponderReceiver iTransponderReceiver)
        {

        }


        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Data;

namespace ATM.Interfaces
{
    interface ITrack
    {
        TrackData ConvertData(string data);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ProximityDetectionData
    {
        //Each time a track is to close to each other a file need to log the following information: tags and time of event.
        public string Tag1;
        public string Tag2;
        public DateTime Timestamp;
        public ProximityDetectionData(string tag1, string tag2, DateTime timestamp)
        {
            Tag1 = tag1;
            Tag2 = tag2;
            Timestamp = timestamp;
        }
    }
}

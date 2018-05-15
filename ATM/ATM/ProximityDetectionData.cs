using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Interfaces;

namespace ATM
{
    public class ProximityDetectionData: IProximityDetectionData
    {
        //Each time a track is to close to each other a file need to log the following information: tags and time of event.
        public string Tag1{ get; set;}
        public string Tag2 { get; set;}
        public DateTime Timestamp { get; set; }
        public ProximityDetectionData()
        {
            Tag1 = "";
            Tag2 = "";
            Timestamp = DateTime.MinValue;
        }


      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Interfaces;
using TransponderReceiver;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            ITransponderReceiver transponderDataReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            ITrackUpdate trackUpdate = new TrackUpdate();
            IFiltering filtering = new Filtering(trackUpdate);

            var decoder = new Parsing(transponderDataReceiver, filtering);
            System.Console.ReadLine();
        }
    }
}

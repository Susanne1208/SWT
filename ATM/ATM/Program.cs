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
            ITrackDataReceiver trackReceiver = new TrackDataReceiver();

           var decoder = new Track(transponderDataReceiver, trackReceiver);
           System.Console.ReadLine();

        }
    }
}

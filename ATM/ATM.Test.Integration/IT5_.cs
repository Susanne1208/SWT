using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Data;
using ATM.Interfaces;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TransponderReceiver;

namespace ATM.Test.Integration
{
    [TestFixture]
    class IT5_
    {
        private ITrackUpdate _trackUpdate;
        private ITrackRendition _trackRendition;
        private IFiltering _filtering;
        private ITrackData _trackData;
        private IProximityDetection _proximityDetection;
        private IParsing _parsing;
        private IEventRendition _eventRendition;
        private ITransponderReceiver _transponderReceiver;

        private List<ITrackData> tracks;
        private RawTransponderDataEventArgs _args;





        [SetUp]
        public void Setup()
        {
            _parsing = new Parsing(_transponderReceiver, _filtering);
            _trackData = new TrackData();

            _transponderReceiver = Substitute.For<ITransponderReceiver>();
            _eventRendition = Substitute.For<IEventRendition>();
            _trackUpdate = Substitute.For<ITrackUpdate>();
            _trackRendition = Substitute.For<ITrackRendition>();
            _filtering = Substitute.For<IFiltering>();
            _proximityDetection = Substitute.For<IProximityDetection>(); 



            //_args = new RawTransponderDataEventArgs();







        }
    }
}

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
        private IProximityDetectionData _proximityDetectionData;
        private RawTransponderDataEventArgs _dataEvent;


        private ITrackData _fakeTrackData;
        private List<ITrackData> _faketrackList;





        [SetUp]
        public void Setup()
        {

            _transponderReceiver = Substitute.For<ITransponderReceiver>();
            _trackRendition = Substitute.For<ITrackRendition>();
            _proximityDetectionData = new ProximityDetectionData();
            _eventRendition = new EventRendition(_proximityDetectionData);
            _proximityDetection = new ProximityDetection(_eventRendition, _proximityDetectionData);
            _trackUpdate = new TrackUpdate(_trackRendition, _proximityDetection);
            _filtering = new Filtering(_trackUpdate);
            _parsing = new Parsing(_transponderReceiver, _filtering);
            _trackData = new TrackData();
            _faketrackList = new List<ITrackData>();
            //_trackRendition = new TrackRendition();

            _dataEvent = new RawTransponderDataEventArgs(new List<string>()
                { "JAS001;12345;67890;12000;20160101100909111" });

            _fakeTrackData = new TrackData
            {
                Tag = "JAS001", 
                X = 12345,
                Y = 67890, 
                Altitude = 12000, 
                Course = 0, 
                Velocity = 0, 
                TimeStamp = DateTime.ParseExact("20160101100909111", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture)
            };

            
            

        }


        private void RaiseFakeEvent()
        {
            _transponderReceiver.TransponderDataReady += Raise.EventWith(_dataEvent);
        }


        [Test]
        public void HvadSkalJegTeste()
        {
            _faketrackList.Add(_fakeTrackData);
            RaiseFakeEvent();
            // RaiseFakeEvent();
            _trackRendition.Received().Print(Arg.Is<List<ITrackData>>(data => data.Equals(_faketrackList)));
            

        }


    }
}

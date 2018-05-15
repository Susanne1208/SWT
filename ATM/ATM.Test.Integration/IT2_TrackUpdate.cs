using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NUnit.Framework;

namespace ATM.Test.Integration
{
    [TestFixture]
    class IT2_TrackUpdate
    {

        private List<ITrackData> _trackData;
        private IFiltering _filtering;
        private ITrackRendition _trackRendition;
        private IEventRendition _eventRendition;
        private IProximityDetection _proximityDetection;
        private IProximityDetectionData _proximityDetectionData;
        private ITrackUpdate _trackUpdate;
        private ITrackData _track1;
        private ITrackData _track2;

        [SetUp]
        public void SetUp()
        {
            _trackData = new List<ITrackData>();  //elementerne i listen skal subtitutes
            //_filtering = Substitute.For<IFiltering>();

            _trackRendition = new TrackRendition();
            _eventRendition = Substitute.For<IEventRendition>();
            _proximityDetection = new ProximityDetection(_eventRendition, _proximityDetectionData);
            //_proximityDetectionData = Substitute.For<IProximityDetectionData>();
            _trackUpdate = new TrackUpdate(_trackRendition, _proximityDetection);
            _track1 = Substitute.For<ITrackData>();
            _track2 = Substitute.For<ITrackData>();
            
        }

        [Test]
        public void blabla()
        {
            var uut = new TrackUpdate(_trackRendition, _proximityDetection);
            _track1.X.Returns(50000);
            _track1.Tag.Returns("AB1234");
            _track2.Tag.Returns("AB1235");
            _track1.TimeStamp.Returns(DateTime.Today);
            _track2.TimeStamp.Returns(DateTime.Today);
            _track2.X.Returns(50010);
            _track1.Y.Returns(60000);
            _track2.Y.Returns(60100);
            _track1.Altitude.Returns(500);
            _track2.Altitude.Returns(520);

            _trackData.Add(_track1);
            _trackData.Add(_track2);
            uut.Update(_trackData);

            //_proximityDetection.CheckProximityDetection(_trackData);

            _eventRendition.Received().PrintEvent(Arg.Is<List<IProximityDetectionData>>(data => data[0].Tag1==_track1.Tag));//LogToFile(_trackData);

            
        }

        public void printNewList_NewlistPrinted()
        {
            _track1.X.Returns(50000);
            _track1.Y.Returns(90000);
            _trackData.Add(_track1);
            _trackRendition.Print(_trackData);
            _trackRendition.Received().Print(_trackData);

        }




    }
}

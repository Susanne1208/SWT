using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Data;
using ATM.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace ATM.Test.Unit
{
    [TestFixture]
    public class ProximityDetectionTest
    {
        private IProximityDetection _uut;
        private List<ITrackData> _trackDataList;

        private List<IProximityDetectionData> _proximityDetections;
        //private ITrackData _track1;
        //private ITrackData _track2;
        private ITrackData _track1, _track2, _track3, _track4;

        private IEventRendition _eventRendition;
        private IProximityDetectionData _proximityDetectionData;

        //Horizontal seperation less than 5000 meters
        //vertical seperation less than 300 meters

        [SetUp]
        public void SetUp()
        {
            _uut = new ProximityDetection(_eventRendition, _proximityDetectionData);

            _trackDataList = new List<ITrackData>();
            _proximityDetectionData = new ProximityDetectionData();
            _proximityDetections = Substitute.For<List<IProximityDetectionData>>();

            _track1 = Substitute.For<ITrackData>();
            _track2 = Substitute.For<ITrackData>();
            //_track1 = new TrackData();
            //_track2 = new TrackData();
            _track3 = new TrackData();
            //_track4 = new TrackData();
            _track4 = new TrackData
            {
                Tag = "ABC123",
                X = 10050,
                Y = 10050,
                Altitude = 10050,
            };

            _track4 = new TrackData
            {
                Tag = "123ABC",
                X = 10000,
                Y = 10000,
                Altitude = 12000,
            };

            _eventRendition = Substitute.For<IEventRendition>();
            
            
        }

        [Test]
        public void eoauehaefha()
        {
            _trackDataList.Clear();

            //_track1.Tag = "ART123";
            //_track2.Tag = "THF334";
            //_track1.X = 30000;
            //_track2.X = 30050;
            //_track1.Y = 50000;
            //_track2.Y = 50050;
            //_track1.Altitude = 5000;
            //_track2.Altitude = 5050;

            _trackDataList.Add(_track1);
            _trackDataList.Add(_track2);

            //_proximityDetectionData.Tag1 = _track1.Tag;
            //_proximityDetectionData.Tag2 = _track2.Tag;
            //_proximityDetectionData.Timestamp = DateTime.Now;

            _uut.CheckProximityDetection(_trackDataList);
            //_proximityDetections.Add(_proximityDetectionData);

            Assert.That(_proximityDetections.Count, Is.EqualTo(1));

        }

        //[TestCase(10000, 20000, 5000, 11000, 21000, 5200)] //Horizontal conflict
        //[TestCase(10000, 20000, 11000, 21000, 5000, 5200)]
        //[TestCase(11111, 22222, 1122, 2233, 8000, 8700)] // Vertical conflict
        //int x1, int y1, int x2, int y2, int alt1, int alt2
        [Test]
        public void CheckProximityDetection_CollisionCountIsOne()
        {

            //_uut.CheckProximityDetection(_trackDataList);
            //var uut = new ProximityDetection(_eventRendition);

            //LogToFile is called when tracks are colliding

            //_track1.X = x1;
            //_track1.Y = y1;
            //_track1.Altitude = alt1;

            //_track2.X = x2;
            //_track2.Y = y2;
            //_track2.Altitude = alt2;

            _track1.Tag = "ART123";
            _track2.Tag = "THF334";
            _track1.X = 30000;
            _track2.X = 30050;
            _track1.Y = 50000;
            _track2.Y = 50050;
            _track1.Altitude = 5000;
            _track2.Altitude = 5050;

            _trackDataList.Add(_track1);
            _trackDataList.Add(_track2);

            //_proximityDetectionData.Tag1 = _track1.Tag;
            //_proximityDetectionData.Tag2 = _track2.Tag;
            //_proximityDetectionData.Timestamp = DateTime.Now;

            _uut.CheckProximityDetection(_trackDataList);

            Assert.That(_proximityDetections.Count, Is.EqualTo(1));

        }

        [Test]
        public void CheckProximityDetection_CollisionCountIsOne_withThreeTracks()
        {

            _track1.Tag = "ART123";
            _track2.Tag = "THF334";
            _track1.X = 30000;
            _track2.X = 30050;
            _track1.Y = 50000;
            _track2.Y = 50050;
            _track1.Altitude = 5000;
            _track2.Altitude = 5050;
            _track3.X = 50000;
            _track3.Y = 70000;
            _track3.Altitude = 3000;

            _trackDataList.Add(_track1);
            _trackDataList.Add(_track2);
            _trackDataList.Add(_track3);

            //_proximityDetectionData.Tag1 = _track1.Tag;
            //_proximityDetectionData.Tag2 = _track2.Tag;
            //_proximityDetectionData.Timestamp = DateTime.Now;

            _uut.CheckProximityDetection(_trackDataList);

            Assert.That(_proximityDetections.Count, Is.EqualTo(1));

        }


        //[TestCase(11111, 22222, 33333, 4444, 8000, 8100)] //Horizontal conflict
        //[TestCase(11111, 22222, 1122, 2233, 8000, 8700)] // Vertical conflict
        //public void CheckProximityDetection_EventRendition_PrintEventIsCalled(int x1, int y1, int x2, int y2, int alt1, int alt2)
        //{
        //    //_uut.CheckProximityDetection(_trackDataList);
        //    //var uut = new ProximityDetection(_eventRendition);

        //    //PrintEvent is called when tracks are colliding

        //    _proximityDetectionData.Tag1 = "AB1234";
        //    _proximityDetectionData.Tag2 = "AB1236";


        //    _proximityDetections.Add(_proximityDetectionData);
        //    _proximityDetections.Add(_proximityDetectionData);


        //    //_uut.CheckProximityDetection(_trackDataList);

        //    _eventRendition.Received().PrintEvent(_proximityDetections);
        //}

        //[TestCase(11111, 22222, 33333, 44444, 8000, 6000)] //Horizontal NO Conflict
        //[TestCase(11111, 22222, 40000, 50000, 8000, 7000)] // Vertical NO conflict
        //public void CheckProximityDetection_EventRendtion_PrintEventIsNotCalled(int x1, int y1, int x2, int y2, int alt1, int alt2)
        //{
        //    //PrintEvent is NOT called when tracks are not colliding
        //    _track1.X = x1;
        //    _track1.Y = y1;
        //    _track1.Altitude = alt1;

        //    _track2.X = x2;
        //    _track2.Y = y2;
        //    _track2.Altitude = alt2;

        //    _trackDataList.Add(_track1);
        //    _trackDataList.Add(_track2);
        //    _uut.CheckProximityDetection(_trackDataList);
        //    //_eventRendition.DidNotReceive().PrintEvent();

        //}

    }
}

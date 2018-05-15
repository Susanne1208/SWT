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
        //private ITrackData _track1;
        //private ITrackData _track2;
        private ITrackData _track1, _track2, _track3, _track4;

        private IEventRendition _eventRendition;
        private ProximityDetectionData _proximityDetectionData;

        //Horizontal seperation less than 5000 meters
        //vertical seperation less than 300 meters

        [SetUp]
        public void SetUp()
        {
            _uut = new ProximityDetection(_eventRendition, _proximityDetectionData);

            _trackDataList = new List<ITrackData>();
            _track1 = new TrackData();
            _track2 = new TrackData();
            _track3 = new TrackData();
            _track4 = new TrackData();

            _eventRendition = Substitute.For<IEventRendition>();
            
            //_track1 = Substitute.For<ITrackData>();
            //_track2 = Substitute.For<ITrackData>();
        }


        [TestCase(11111, 22222, 33333, 4444, 8000, 8100, true)] //Horizontal conflict
        [TestCase(11111, 22222, 1122, 2233, 8000, 8700, true)] // Vertical conflict
        public void CheckProximityDetection_EventRendtion_LogTofileIsCalled(int x1, int y1, int x2, int y2, int alt1, int alt2)
        {

            //_uut.CheckProximityDetection(_trackDataList);
            //var uut = new ProximityDetection(_eventRendition);

            //LogToFile is called when tracks are colliding

            _track1.X = x1;
            _track1.Y = y1;
            _track1.Altitude = alt1;

            _track2.X = x2;
            _track2.Y = y2;
            _track2.Altitude = alt2;

            _trackDataList.Add(_track1);
            _trackDataList.Add(_track2);

            _proximityDetectionData.Tag1 = _track1.Tag;
            _proximityDetectionData.Tag2 = _track2.Tag;
            _proximityDetectionData.Timestamp = DateTime.Now;;
            _uut.CheckProximityDetection(_trackDataList);

            //_eventRendition.Received().LogToFile(_proximityDetectionData);
        }


        [TestCase(11111, 22222, 33333, 44444, 8000, 6000)] //Horizontal NO Conflict
        [TestCase(11111, 22222, 40000, 50000, 8000, 7000)] // Vertical NO conflict
        public void CheckProximityDetection_EventRendtion_LogTofileIsNotCalled(int x1, int y1, int x2, int y2, int alt1, int alt2)
        {
            //LogToFile is NOT called when tracks are not colliding
            _track1.X = x1;
            _track1.Y = y1;
            _track1.Altitude = alt1;

            _track2.X = x2;
            _track2.Y = y2;
            _track2.Altitude = alt2;
            
            _trackDataList.Add(_track1);
            _trackDataList.Add(_track2);
            _uut.CheckProximityDetection(_trackDataList);
           // _eventRendition.DidNotReceive().LogToFile();

        }

        [TestCase(11111, 22222, 33333, 4444, 8000, 8100, true)] //Horizontal conflict
        [TestCase(11111, 22222, 1122, 2233, 8000, 8700, true)] // Vertical conflict
        public void CheckProximityDetection_EventRendition_PrintEventIsCalled(int x1, int y1, int x2, int y2, int alt1, int alt2)
        {
            //_uut.CheckProximityDetection(_trackDataList);
            //var uut = new ProximityDetection(_eventRendition);

            //PrintEvent is called when tracks are colliding

            _track1.X = x1;
            _track1.Y = y1;
            _track1.Altitude = alt1;

            _track2.X = x2;
            _track2.Y = y2;
            _track2.Altitude = alt2;

            _trackDataList.Add(_track1);
            _trackDataList.Add(_track2);


            _uut.CheckProximityDetection(_trackDataList);

            //_eventRendition.Received().PrintEvent();
        }


        [TestCase(11111, 22222, 33333, 44444, 8000, 6000)] //Horizontal NO Conflict
        [TestCase(11111, 22222, 40000, 50000, 8000, 7000)] // Vertical NO conflict
        public void CheckProximityDetection_EventRendtion_PrintEventIsNotCalled(int x1, int y1, int x2, int y2, int alt1, int alt2)
        {
            //PrintEvent is NOT called when tracks are not colliding
            _track1.X = x1;
            _track1.Y = y1;
            _track1.Altitude = alt1;

            _track2.X = x2;
            _track2.Y = y2;
            _track2.Altitude = alt2;

            _trackDataList.Add(_track1);
            _trackDataList.Add(_track2);
            _uut.CheckProximityDetection(_trackDataList);
            //_eventRendition.DidNotReceive().PrintEvent();

        }

        ////x1, y1, x2, y2,  alt1, alt2, result
        //[TestCase(11111,22222,33333,4444,8000,8100, true)] //Horizontal conflict
        //[TestCase(11111,22222,1122,2233,8000,8700, true)] // Vertical conflict
        //public void IsTracksInConflict_returnsTrue(int x1, int y1, int x2, int y2, int alt1, int alt2, bool result)
        //{
        //    //track1 and track 2 is conflicting because of horizontal and vertical distance
        //    _track1.X = x1;
        //    _track1.Y = y1;
        //    _track1.Altitude = alt1;

        //    _track2.X = x2;
        //    _track2.Y = y2;
        //    _track2.Altitude = alt2;

        //    //Assert.AreEqual();
        //    //Assert.AreEqual(result, _uut.IsTracksInConflict(_track1,_track2));


        //}

        ////x1, y1, x2, y2,  alt1, alt2, result
        //[TestCase(11111, 22222, 33333, 44444, 8000, 6000, false)] //Horizontal
        //[TestCase(11111, 22222, 40000, 50000, 8000, 7000, false)] // Vertical
        //public void IsTracksInConflict_returnsFalse(int x1, int y1, int x2, int y2, int alt1, int alt2, bool result)
        //{
        //    //track1 and track 2 is NOT conflicting because of distance
        //    _track1.X = x1;
        //    _track1.Y = y1;
        //    _track1.Altitude = alt1;

        //    _track2.X = x2;
        //    _track2.Y = y2;
        //    _track2.Altitude = alt2;

        //    //Assert.AreEqual(result, _uut.IsTracksInConflict(_track1, _track2));
        //}
    }
}

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
        private TrackData _track1;
        private TrackData _track2;


        [SetUp]
        public void SetUp()
        {
            _uut = new ProximityDetection();
            _track1 = Substitute.For<TrackData>();
            _track2 = Substitute.For<TrackData>();
        }


        //Horizontal seperation less than 5000 meters


        //vertical seperation less than 300 meters

        //x1, y1, x2, y2,  alt1, alt2, result
        [TestCase(11111,22222,33333,4444,8000,8100, true)] //Horizontal conflict
        [TestCase(11111,22222,1122,2233,8000,8700, true)] // Vertical conflict
        public void IsTracksInConflict_returnsTrue(int x1, int y1, int x2, int y2, int alt1, int alt2, bool result)
        {
            //track1 and track 2 is conflicting because of horizontal and vertical distance
            _track1.X = x1;
            _track1.Y = y1;
            _track1.Altitude = alt1;

            _track2.X = x2;
            _track2.Y = y2;
            _track2.Altitude = alt2;

            Assert.AreEqual(result, _uut.IsTracksInConflict(_track1,_track2));


        }

        //x1, y1, x2, y2,  alt1, alt2, result
        [TestCase(11111, 22222, 33333, 44444, 8000, 6000, false)] //Horizontal
        [TestCase(11111, 22222, 40000, 50000, 8000, 7000, false)] // Vertical
        [Test]
        public void IsTracksInConflict_returnsFalse(int x1, int y1, int x2, int y2, int alt1, int alt2, bool result)
        {
            //track1 and track 2 is NOT conflicting because of distance
            _track1.X = x1;
            _track1.Y = y1;
            _track1.Altitude = alt1;

            _track2.X = x2;
            _track2.Y = y2;
            _track2.Altitude = alt2;

            Assert.AreEqual(result, _uut.IsTracksInConflict(_track1, _track2));
        }
    }
}

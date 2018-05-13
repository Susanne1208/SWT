using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Data;
using ATM.Interfaces;
using NUnit.Framework;

namespace ATM.Test.Unit
{
    [TestFixture]
    public class TrackUpdateTests
    {
        //private List<ITrackData> _track;
        private ITrackData _track1;
        private ITrackData _track2;

        [SetUp]

        public void SetUp()
        {
            _track1 = new TrackData {TimeStamp = new DateTime(2018, 05, 13,10,20,30)};
            _track2 = new TrackData { TimeStamp = new DateTime(2018, 05, 13, 10, 20, 31) };
        }
      
        [Test]
        [TestCase(50000, 50100,50000,50100,141)]
        public void CalVelocity_CalculateTrack1andTrack2_ReturnsVelocity(int x1, int x2, int y1, int y2, int result) //WORKS
        {
            var uut = new TrackUpdate();
            _track1.X = x1;
            _track1.Y = y1;
            _track2.X = x2;
            _track2.Y = y2;
            Assert.That(uut.CalVelocity(_track1,_track2), Is.EqualTo(result));
        }

        [Test]
        public void CalCourse_CalculateTrack1andTrack2_Returns()
        {
            var uut = new TrackUpdate();

        }

    }
}

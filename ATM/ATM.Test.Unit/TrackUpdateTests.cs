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
    
      
        [Test]
        [TestCase(50000, 50100,50000,50100,6000)]
        public void CalVelocity_CalculateTrack1andTrack2_ReturnsVelocity(int x1, int x2, int y1, int y2, int result)
        {
            var uut = new TrackUpdate();  
            Assert.That(uut.CalVelocity(new TrackData{X = x1, Y = y1},new  TrackData{X=x2, Y=y2}), Is.EqualTo(result));
        }

        [Test]
        public void CalCourse_CalculateTrack1andTrack2_Returns()
        {
            var uut = new TrackUpdate();

        }

    }
}

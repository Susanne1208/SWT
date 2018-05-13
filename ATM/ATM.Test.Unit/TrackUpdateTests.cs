using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ATM.Test.Unit
{
    [TestFixture]
    public class TrackUpdateTests
    {
        private List<IFiltering> _filtering;

        [Test]
        public void Update_UpdateOldAndNew_returns()
        {
            var uut = new TrackUpdate();    //declare my class under test
            Assert.That(uut.Update(_filtering), Is.EqualTo(true));
        }

        [Test]
        public void CalVelocity_CalculateTrack1andTrack2_Returns()
        {
            var uut = new TrackUpdate();  
            Assert.That(uut.CalVelocity(), Is.EqualTo());
        }

        [Test]
        public void CalCourse_CalculateTrack1andTrack2_Returns()
        {
            var uut = new TrackUpdate();

        }

    }
}

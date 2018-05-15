using System;
using ATM.Interfaces;
using NUnit.Framework;
using NSubstitute;


namespace ATM.Test.Integration
{
    [TestFixture]
    public class IT1_ProximityDetection
    {
        private ITrackUpdate _fakeTrackUpdate;
        

        [SetUp]
        public void SetUp()
        {
            _fakeTrackUpdate = Substitute.For<ITrackUpdate>();
        }
    }
}

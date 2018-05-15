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

        [SetUp]
        public void SetUp()
        {
            _trackData = new List<ITrackData>();  //elementerne i listen skal subtitutes
            //_filtering = Substitute.For<IFiltering>();
            
            _trackRendition=new TrackRendition();
            _eventRendition = new EventRendition();
            _proximityDetection = new ProximityDetection(_eventRendition,_proximityDetectionData);
            //_proximityDetectionData = Substitute.For<IProximityDetectionData>();
            _trackUpdate = new TrackUpdate(_trackRendition, _proximityDetection);
            _track1 = Substitute.For<ITrackData>();
        }

        [Test]

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

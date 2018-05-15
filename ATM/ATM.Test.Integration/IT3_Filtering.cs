using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Data;
using ATM.Interfaces;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NSubstitute;

namespace ATM.Test.Integration
{
    [TestFixture]
    class IT3_Filtering
    {
        private IParsing _fakeParsing;
        private ITrackRendition _trackRendition;
        private ITrackUpdate _trackUpdate;
        private IEventRendition _eventRendition;
        private IProximityDetectionData _proximityDetectionData;
        private IProximityDetection _proximityDetection;

        private ITrackData _fakeTrackDataValid;
        private ITrackData _fakeTrackDataInvalid;
        private List<ITrackData> _fakeTrackDataList;

        [SetUp]
        public void SetUp()
        {
            _fakeParsing = Substitute.For<Parsing>();
            _trackRendition = new TrackRendition();
            _proximityDetectionData = new ProximityDetectionData();
            //_eventRendition = new EventRendition(_proximityDetectionData);
            _proximityDetection = new ProximityDetection(_eventRendition, _proximityDetectionData);
            _trackUpdate = new TrackUpdate(_trackRendition, _proximityDetection);

            _fakeTrackDataList = new List<ITrackData>();
            _fakeTrackDataValid = new TrackData
            {
                X = 11000,
                Y = 11000,
                Altitude = 15000
            };
            _fakeTrackDataInvalid = new TrackData
            {
                X = 9000,
                Y = 9000,
                Altitude = 200
            };
        }

        [Test]
        public void ValidateTracks_TracksInArea_IsCorrect()
        {
            _fakeTrackDataList.Add(_fakeTrackDataValid);


            //_uut.ValidateTracks(_fakeTrackDataList);


            _trackUpdate.Received().Update(Arg.Is<List<ITrackData>>(x => x.Count == 1));
        }
        [Test]
        public void ValidateTracks_TracksNotInArea_IsCorrect()
        {
            _fakeTrackDataList.Add(_fakeTrackDataInvalid);

           // _uut.ValidateTracks(_fakeTrackDataList);

            _trackUpdate.Received().Update(Arg.Is<List<ITrackData>>(x => x.Count == 0));
        }
    }
}

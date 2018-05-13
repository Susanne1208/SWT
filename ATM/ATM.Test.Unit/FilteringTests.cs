using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATM;
using ATM.Data;
using ATM.Interfaces;
using NUnit.Framework;
using NSubstitute;

namespace ATM.Test.Unit
{
    [TestFixture]
    public class FilteringTests
    {
        private ITrackUpdate _trackUpdate;
        private Filtering _uut;
        private TrackData _fakeTrackDataValid;
        private TrackData _fakeTrackDataInvalid;
        private List<TrackData> _fakeTrackDataList;


        [SetUp]
        public void Setup()
        {
            _fakeTrackDataList = new List<TrackData>();
            _trackUpdate = Substitute.For<ITrackUpdate>();
            _uut = new Filtering(_trackUpdate);
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

            
            _uut.ValidateTracks(_fakeTrackDataList);

            _trackUpdate.Received().Update(Arg.Is(List<TrackData>), l => l.Length()==1);
        }
        [Test]
        public void ValidateTracks_TracksNotInArea_IsCorrect()
        {
            _fakeTrackDataList.Add(_fakeTrackDataInvalid);
        
            _uut.ValidateTracks(_fakeTrackDataList);
            
            _trackUpdate.Received().
        }

    }
}

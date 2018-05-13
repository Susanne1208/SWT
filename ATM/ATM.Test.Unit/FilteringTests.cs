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
        private List<TrackData> _fakeTrackDataList;

        [SetUp]
        public void Setup()
        {
            _fakeTrackDataList = new List<TrackData>();
            _fakeTrackDataValid = new TrackData
            {
                X = 11000,
                Y = 11000,
                Altitude = 15000
            };
            _fakeTrackDataList.Add(_fakeTrackDataValid);
        }

        [Test]
        public void ValidateTracks_TracksNotInArea_IsCorrect()
        {
            _trackUpdate = Substitute.For<ITrackUpdate>();
            _uut = new Filtering(_trackUpdate);
            
            //Skal laves en liste, der indeholder et TrackDataObjekt, der ikke er inde for området.
            _uut.ValidateTracks(_fakeTrackDataList);
            //Skal modtage en tom liste
            _trackUpdate.Received().Update(Arg.Is(List<TrackData>), l => l.Length()==1);
        }
        [Test]
        public void ValidateTracks_TracksInArea_IsCorrect()
        {
            //Skal laves en liste, der indeholder et TrackDataObjekt, der er indenfor området.
            _uut.ValidateTracks(List<>);
            //Skal modtage en liste med et objekt
            _trackUpdate.Received().
        }

    }
}

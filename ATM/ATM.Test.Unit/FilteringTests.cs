using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATM;
using ATM.Interfaces;
using NUnit.Framework;
using NSubstitute;

namespace ATM.Test.Unit
{
    [TestFixture]
    public class FilteringTests
    {
        private TrackUpdate _trackUpdate;
        private Filtering _uut;
        private List<TrackData> _fakeTrackData;

        [SetUp]
        public void Setup()
        {
            _trackUpdate = Substitute.For<ITrackUpdate>;
            _uut = new Filtering(_trackUpdate);
            
            _fakeTrackData = new List<TrackData>;
        }

        [Test]
        public void ValidateTracks_TracksNotInArea_IsCorrect()
        {
            //_fakeTrackData.Add()
            //Skal laves en liste, der indeholder et TrackDataObjekt, der ikke er inde for området.
            _uut.ValidateTracks(List<>);
            //Skal modtage en tom liste
            _trackUpdate.Received().
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

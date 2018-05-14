using System;
using System.Collections.Generic;
using ATM.Data;
using ATM.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute; 
using NUnit.Framework;
using TransponderReceiver;

namespace ATM.Test.Unit
{
    [TestFixture]

    class ParsingTests
    {
        private Parsing _uut; 
        private ITransponderReceiver _receiver;
        private RawTransponderDataEventArgs _fakeTransponderDataEventArgs;
        private ITrackRendition _trackRendition;
        private IFiltering _filtering;



        [SetUp]
        public void Setup()
        {
            _receiver = Substitute.For<ITransponderReceiver>();
            _filtering = Substitute.For<IFiltering>();
            _trackRendition = Substitute.For<ITrackRendition>(); 
            _uut = new Parsing(_receiver, _filtering);
            _fakeTransponderDataEventArgs = new RawTransponderDataEventArgs(new List<string>()
                { "JAS002;12345;67890;12000;20170101123456789" });

        }

        private void RaiseFakeEvent()
        {
            _receiver.TransponderDataReady += Raise.EventWith(_fakeTransponderDataEventArgs);
        }

        [Test]
        public void OneTrackInList_CountCorrect()
        {
            RaiseFakeEvent();
            _trackRendition.Received().Print(Arg.Is<List<TrackData>>(x => x.Count == 1));

        }


        [Test]
        public void OneTrackInList_TagCorrect()
        {
            RaiseFakeEvent();
            _trackRendition.Received().Print(Arg.Is<List<TrackData>>(x => x[0].Tag == "JAS002"));
        }

        [Test]
        public void OneTrackInList_XCorrect()
        {
            RaiseFakeEvent();
            _trackRendition.Received().Print(Arg.Is<List<TrackData>>(x => x[0].X == 12345));
        }


        [Test]
        public void OneTrackInList_YCorrect()
        {
            RaiseFakeEvent();
            _trackRendition.Received().Print(Arg.Is<List<TrackData>>(x => x[0].Y == 67890));
        }

        [Test]
        public void OneTrackInList_AltitudeCorrect()
        {
            RaiseFakeEvent();
            _trackRendition.Received().Print(Arg.Is<List<TrackData>>(x => x[0].Altitude == 12000));
        }


        [Test]
        public void OneTrackInList_TimeStampYearCorrect()
        {
            RaiseFakeEvent();
            _trackRendition.Received().Print(Arg.Is<List<TrackData>>(x => x[0].TimeStamp.Year == 2017));
        }


        [Test]
        public void OneTrackInList_TimeStampMonthCorrect()
        {
            RaiseFakeEvent();
            _trackRendition.Received().Print(Arg.Is<List<TrackData>>(x => x[0].TimeStamp.Month == 01));
        }

        [Test]
        public void OneTrackInList_TimeStampDayCorrect()
        {
            RaiseFakeEvent();
            _trackRendition.Received().Print(Arg.Is<List<TrackData>>(x => x[0].TimeStamp.Day == 01));
        }

        public void OneTrackInList_TimeStampHourCorrect()
        {
            RaiseFakeEvent();
            _trackRendition.Received().Print(Arg.Is<List<TrackData>>(x => x[0].TimeStamp.Hour == 12));
        }

        [Test]
        public void OneTrackInList_TimeStampMinuteCorrect()
        {
            RaiseFakeEvent();
            _trackRendition.Received().Print(Arg.Is<List<TrackData>>(x => x[0].TimeStamp.Minute ==34 ));
        }


        [Test]
        public void OneTrackInList_TimeStampSecondCorrect()
        {
            RaiseFakeEvent();
            _trackRendition.Received().Print(Arg.Is<List<TrackData>>(x => x[0].TimeStamp.Second == 56));
        }

        [Test]
        public void OneTrackInList_TimeStampMsCorrect()
        {
            RaiseFakeEvent();
            _trackRendition.Received().Print(Arg.Is<List<TrackData>>(x => x[0].TimeStamp.Millisecond == 789));
        }

        [Test]
        public void ThreeTracksInList_CountCorrect()
        {

        }

        [Test]
        public void ThreeTracksInList_ThirdTagCorrect()
        {

        }
          


    }
}

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
        private Track _uut; 
        private ITransponderReceiver _receiver;
        private RawTransponderDataEventArgs _fakeTransponderDataEventArgs;
        private ITrackDataReceiver _trackDataReceiver;



        [SetUp]
        public void Setup()
        {
            _receiver = Substitute.For<ITransponderReceiver>();
            _trackDataReceiver = Substitute.For<ITrackDataReceiver>(); 
            _uut = new Track(_receiver, _trackDataReceiver);
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
            _trackDataReceiver.Received().ReceiveTracks(Arg.Is<List<TrackData>>(x => x.Count == 1));

        }


        [Test]
        public void OneTrackInList_TagCorrect()
        {
            RaiseFakeEvent();
            _trackDataReceiver.Received().ReceiveTracks(Arg.Is<List<TrackData>>(x => x[0].Tag == "JAS002"));
        }

        [Test]
        public void OneTrackInList_XCorrect()
        {
            RaiseFakeEvent();
            _trackDataReceiver.Received().ReceiveTracks(Arg.Is<List<TrackData>>(x => x[0].X == 12345));
        }


        [Test]
        public void OneTrackInList_YCorrect()
        {
            RaiseFakeEvent();
            _trackDataReceiver.Received().ReceiveTracks(Arg.Is<List<TrackData>>(x => x[0].Y == 67890));
        }

        [Test]
        public void OneTrackInList_AltitudeCorrect()
        {
            RaiseFakeEvent();
            _trackDataReceiver.Received().ReceiveTracks(Arg.Is<List<TrackData>>(x => x[0].Altitude == 12000));
        }


        [Test]
        public void OneTrackInList_TimeStampYearCorrect()
        {
            RaiseFakeEvent();
            _trackDataReceiver.Received().ReceiveTracks(Arg.Is<List<TrackData>>(x => x[0].TimeStamp.Year == 2017));
        }


        [Test]
        public void OneTrackInList_TimeStampMonthCorrect()
        {
            RaiseFakeEvent();
            _trackDataReceiver.Received().ReceiveTracks(Arg.Is<List<TrackData>>(x => x[0].TimeStamp.Month == 01));
        }

        [Test]
        public void OneTrackInList_TimeStampDayCorrect()
        {
            RaiseFakeEvent();
            _trackDataReceiver.Received().ReceiveTracks(Arg.Is<List<TrackData>>(x => x[0].TimeStamp.Day == 01));
        }

        public void OneTrackInList_TimeStampHourCorrect()
        {
            RaiseFakeEvent();
            _trackDataReceiver.Received().ReceiveTracks(Arg.Is<List<TrackData>>(x => x[0].TimeStamp.Hour == 12));
        }

        [Test]
        public void OneTrackInList_TimeStampMinuteCorrect()
        {
            RaiseFakeEvent();
            _trackDataReceiver.Received().ReceiveTracks(Arg.Is<List<TrackData>>(x => x[0].TimeStamp.Minute ==34 ));
        }


        [Test]
        public void OneTrackInList_TimeStampSecondCorrect()
        {
            RaiseFakeEvent();
            _trackDataReceiver.Received().ReceiveTracks(Arg.Is<List<TrackData>>(x => x[0].TimeStamp.Second == 56));
        }

        [Test]
        public void OneTrackInList_TimeStampMsCorrect()
        {
            RaiseFakeEvent();
            _trackDataReceiver.Received().ReceiveTracks(Arg.Is<List<TrackData>>(x => x[0].TimeStamp.Millisecond == 789));
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

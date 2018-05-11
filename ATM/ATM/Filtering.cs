using System.Collections.Generic;

namespace ATM
{
    public class Filtering : IFiltering
    {
        private TrackUpdate _trackUpdate;
        public int _minXCoordinate { get; set; }
        public int _maxXCoordinate { get; set; }
        public int _minYCoordinate { get; set; }
        public int _maxYCoordinate { get; set; }
        public int _minAltitude { get; set; }
        public int _maxAltitude { get; set; }

        public Filtering(ITrackUpdate trackUpdate)
        {
            _minXCoordinate = 10000;
            _maxXCoordinate = 90000;
            _minYCoordinate = 10000;
            _maxYCoordinate = 90000;
            _minAltitude = 500;
            _maxAltitude = 20000;
            _trackUpdate = trackUpdate;
        }

        public Filtering(int minXCoordinate, int maxXCoordinate, int minYCoordinate, 
            int maxYCoordinate, int minAltitude, int maxAltitude, ITrackUpdate trackUpdate)
        {
            _minXCoordinate = minXCoordinate;
            _maxXCoordinate = maxXCoordinate;
            _minYCoordinate = minYCoordinate;
            _maxYCoordinate = maxYCoordinate;
            _minAltitude = minAltitude;
            _maxAltitude = maxAltitude;
            _trackUpdate = trackUpdate;
        }

        public void ValidateTracks(List<TrackData>)
        {
            List<TrackData> NewTracks = new List<TrackData>();

            foreach (var Track in TrackData)
            {
                if (Track.X >= _minXCoordinate && Track.X <= _maxXCoordinate
                                               && Track.Y >= _minYCoordinate && Track.Y <= _maxYCoordinate
                                               && Track.Altitude >= _minAltitude && Track.Altitude <= _maxAltitude)
                {
                    NewTracks.Add(Track);
                }
            }
            //Kald beregningsfunktioner i TrackUpdate med liste af nye TrackData
            //_trackUpdate.
        }
    }
}
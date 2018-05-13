using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Interfaces
{
    public interface ITrackUpdate
    {
        List<ITrackData> Update(List<ITrackData> newList);
        int CalVelocity(ITrackData track1, ITrackData track2);
        double CalCourse(ITrackData track1, ITrackData track2);
    }
}

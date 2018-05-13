using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Interfaces
{
    public interface ITrackUpdate
    {
        List<IFiltering> Update(List<IFiltering> newList);
        void CalVelocity(IFiltering track1, IFiltering track2, int index);
        void CalCourse(IFiltering track1, IFiltering track2, int index);
    }
}

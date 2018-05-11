using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Interfaces
{
    public interface IUpdateTrack
    {
        void Update(List<IFiltering> newList);
        void CalVelocity(IFiltering track1, IFiltering track2);
        void CalCourse(IFiltering track1, IFiltering track2);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Data
{
    public interface IScenceData : ITrajectoryData, IObjectsMetaData
    {
        int Source { get; set; }
    }
}

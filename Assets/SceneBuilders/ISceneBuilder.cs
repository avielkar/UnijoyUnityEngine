using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnijoyData.Shared.Data;

namespace Assets.SceneBuilders
{
    public interface ISceneBuilder
    {
        ISceneData Build(ITrialData trialData);
    }
}

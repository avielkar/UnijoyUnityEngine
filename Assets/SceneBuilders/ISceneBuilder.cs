using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assets.Data;

namespace Assets.SceneBuilders
{
    public interface ISceneBuilder<T> where T : ISceneData
    {
        bool Build(ITrialData trialData, out T sceneData);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnijoyData.Shared.Data;

namespace Assets.SceneBuilders
{
    public class SceneBuilder<T> : ISceneBuilder<T> where T : ISceneData
    {
        public bool Build(ITrialData trialData, out T sceneData)
        {
            throw new NotImplementedException();
        }
    }
}

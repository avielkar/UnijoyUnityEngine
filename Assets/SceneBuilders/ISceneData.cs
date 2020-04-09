using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnijoyData.Shared.Data;

namespace Assets.SceneBuilders
{
    public interface ISceneData : ITrialData
    {
        List<float> ObjectsVertices { get; set; }
    }
}

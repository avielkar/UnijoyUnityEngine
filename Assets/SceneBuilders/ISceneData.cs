using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnijoyData.Shared.Data;
using UnityEngine;

namespace Assets.SceneBuilders
{
    public interface ISceneData : IVisualTrialData
    {
        List<Vector3> ObjectsVertices { get; set; }

        int TotalObjects { get; }
    }
}

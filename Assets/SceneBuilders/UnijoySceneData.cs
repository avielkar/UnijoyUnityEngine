using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnijoyData.Shared.Data;
using UnityEngine;

namespace Assets.SceneBuilders
{
    public class UnijoySceneData : ISceneData
    {
        
        public List<Vector3> ObjectsVertices { get ; set ; }
        
        //public string  Source { get ; set ; }

        public List<float> X { get ; set ; }
        
        public List<float> Y { get ; set ; }
        
        public List<float> Z { get ; set ; }
        
        public List<float> RX { get ; set ; }
        
        public List<float> RY { get ; set ; }
        
        public List<float> RZ { get ; set ; }
        
        
        public ColorData ColorData { get ; set ; }
        
        public ObjectType ObjectType { get ; set ; }

        public float Density { get ; set ; }

        public (float, float) Size { get ; set ; }
        public int TotalObjects => (int) (Density* StarFieldDimension.Item1* StarFieldDimension.Item2 * StarFieldDimension.Item3);


        public int Coherence { get; set; }

        public (float, float, float) StarFieldDimension { get ; set ; }


        public (float, float) ClipPlanes { get ; set ; }

        public (float, float, float) EyeOffsets { get ; set ; }

        public (float, float, float) HeadCenter { get ; set ; }

        public (float, float) ScreenDimension { get ; set ; }
    }
}

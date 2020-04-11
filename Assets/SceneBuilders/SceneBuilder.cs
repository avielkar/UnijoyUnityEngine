using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnijoyData.Shared.Data;
using UnityEngine;
using Assets.Extensions.Random;

namespace Assets.SceneBuilders
{
    public class SceneBuilder : ISceneBuilder
    {
        private ISceneData _sceneData;

        System.Random _rand;

        public SceneBuilder()
        {
            _rand = new System.Random();
        }

        public ISceneData Build(ITrialData trialData)
        {
            _sceneData = new UnijoySceneData()
            {
                ColorData = trialData.ColorData,
                X = trialData.X,
                Y = trialData.Y,
                Z = trialData.Z,
                RX = trialData.RX,
                RY = trialData.RY,
                RZ = trialData.RZ,
                ObjectType = trialData.ObjectType,
                Source = trialData.Source,
                NumOfObjects = trialData.NumOfObjects,
                ObjectsVertices = new List<Vector3>()
            };

            AddObjectives();

            return _sceneData;
        }

        public void AddObjectives()
        {
            for (int i=0;i< /*_sceneData.NumOfObjects*/1; i++)
            {
                if(_sceneData.ObjectType == ObjectType.Triangle)
                {
                    _sceneData.ObjectsVertices.AddRange(CreateTriangle());
                }
            }
        }

        public List<Vector3> CreateTriangle()
        {
            List<Vector3> triangleVetexes = new List<Vector3>();

            for (int i = 0; i < 1000; i++)
            {
                float sd0 = 100;
                float sd1 = 100;
                float sd2 = 100;
                float ts0 = 1;
                float ts1 = 1;

                float baseX1 = (float)_rand.NextDouble();
                float baseX = baseX1 / 1 * sd0 - sd0 / 2.0f;
                float baseY1 = (float)_rand.NextDouble();
                float baseY = baseY1 / 1 * sd1 - sd1 / 2.0f;
                float baseZ1 = (float)_rand.NextDouble();
                float baseZ = baseZ1 / 1 * sd2 - sd2 / 2.0f;

                // Vertex 1
                triangleVetexes.Add(new Vector3(baseX - ts0 / 2.0f,
                    baseY - ts1 / 2.0f,
                    baseZ));

                // Vertex 2
                triangleVetexes.Add(new Vector3(baseX,
                    baseY + ts1 / 2.0f,
                    baseZ));

                // Vertex 3
                triangleVetexes.Add(new Vector3(baseX + ts0 / 2.0f,
                    baseY - ts1 / 2.0f,
                    baseZ));
            }

            return triangleVetexes;
        }
    }
}

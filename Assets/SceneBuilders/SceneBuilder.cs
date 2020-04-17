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

        public ISceneData Build(IVisualTrialData trialData)
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
                //Source = trialData.Source,
                ObjectsVertices = new List<Vector3>(),
                Density = trialData.Density,
                Size = trialData.Size,
                Coherence = trialData.Coherence
            };

            AddObjects();

            return _sceneData;
        }

        public void AddObjects()
        {
            switch (_sceneData.ObjectType)
            {
                case ObjectType.Triangle:
                    _sceneData.ObjectsVertices.AddRange(CreateTriangles());
                    break;
                case ObjectType.Circle:
                    break;
                default:
                    break;
            }
        }

        public List<Vector3> CreateTriangles()
        {
            List<Vector3> triangleVetexes = new List<Vector3>();

            (float starFieldDimensionX, float starFieldDimensionY, float starFieldDimensionZ)  = _sceneData.StarFieldDimension;
            (float objectSizeX, float objectSizeY) = _sceneData.Size;

            for (int i = 0; i < _sceneData.TotalObjects; i++)
            {
                float baseX = (float)_rand.NextDouble() / 1 * starFieldDimensionX - starFieldDimensionX / 2.0f;
                float baseY = (float)_rand.NextDouble() / 1 * starFieldDimensionY - starFieldDimensionY / 2.0f;
                float baseZ = (float)_rand.NextDouble() / 1 * starFieldDimensionZ - starFieldDimensionZ / 2.0f;

                // Vertex 1
                triangleVetexes.Add(new Vector3(baseX - objectSizeX / 2.0f,
                    baseY - objectSizeY / 2.0f,
                    baseZ));

                // Vertex 2
                triangleVetexes.Add(new Vector3(baseX,
                    baseY + objectSizeY / 2.0f,
                    baseZ));

                // Vertex 3
                triangleVetexes.Add(new Vector3(baseX + objectSizeX / 2.0f,
                    baseY - objectSizeY / 2.0f,
                    baseZ));
            }

            return triangleVetexes;
        }
    }
}

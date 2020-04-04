using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using Assets.SceneManager;
using Assets.SceneBuilders;
using Assets.Network.Retrievers;
using Assets.Network.Handlers;

namespace Assets.Initializers
{
    public class EngineLogicInitializer:MonoBehaviour
    {
        private int SERVER_PORT = 8910;

        private SceneManager<UnijoySceneData, UnijoyTrialData> _sceneManager;

        private void Awake()
        {
            _sceneManager = new SceneManager<UnijoySceneData, UnijoyTrialData>(
            new SceneBuilder<UnijoySceneData>(),
            new DataRetriever<UnijoyTrialData>(),
            new CommandsRetriever(SERVER_PORT));
        }
        private void Start()
        {
            _sceneManager.Start();
        }
    }
}

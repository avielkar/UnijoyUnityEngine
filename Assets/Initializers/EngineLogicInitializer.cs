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
using UnijoyData.Shared.Data;

namespace Assets.Initializers
{
    public class EngineLogicInitializer:MonoBehaviour
    {
        private int SERVER_PORT = 8910;

        private SceneManager<UnijoyTrialMetaData> _sceneManager;

        private void Awake()
        {
            _sceneManager = new SceneManager<UnijoyTrialMetaData>(
            new SceneBuilder(),
            new DataRetriever<UnijoyTrialMetaData>(),
            new CommandsRetriever(SERVER_PORT));
        }
        private void Start()
        {
            _sceneManager.Start();
        }
    }
}

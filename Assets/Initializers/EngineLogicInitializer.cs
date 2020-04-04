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

        private SceneManager<UnijoySceneData,UnijoyTrialData> _sceneManager;
        private SceneBuilder<UnijoySceneData> _sceneBuilder;
        private DataRetriever<UnijoyTrialData> _dataRetriever;
        private CommandsRetriever _commandsRetriever;

        private void Awake()
        {
            _commandsRetriever = new CommandsRetriever(SERVER_PORT);
            _dataRetriever = new DataRetriever<UnijoyTrialData>();
            _sceneBuilder = new SceneBuilder<UnijoySceneData>();

            _sceneManager = new SceneManager<UnijoySceneData, UnijoyTrialData>(
                _sceneBuilder,
                _dataRetriever,
                _commandsRetriever);
        }
        private void Start()
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Assets.Network;
using Assets.Network.Handlers;
using Assets.Network.Retrievers;
using Assets.SceneBuilders;
using Assets.Scenes.Shared;
using UnijoyData.Shared.Commands;
using UnijoyData.Shared.Data;
using UnityEngine;

namespace Assets.SceneManager
{
    public class SceneManager<M>:ISceneManager<ISceneData> where M:IVisualTrialData
    {
        private SceneBuilder _sceneBuilder;
        private IDataRetriever<M> _dataRetriever;
        private ICommandsRetriever _commandRetriever;

        private ISceneData _currentUnijoySceneData;
        private M _currentTrialMetaData;

        //public EventHandler<ISceneData> NewSceeneReceived { get; set; }

        public event EventHandler<ISceneData> NewSceneReceived;
        public event EventHandler StartRenderCommandReceived;

        public Task _grabCommands;


        public SceneManager(
            SceneBuilder sceneBuilder,
            IDataRetriever<M> dataRetriever,
            ICommandsRetriever dataHandler)
        {
            _sceneBuilder = sceneBuilder;
            _dataRetriever = dataRetriever;
            _commandRetriever = dataHandler;

            ScenesEventRegister.Init(this);

            _grabCommands = new Task(() => Grabcommands());
        }

        public void Start()
        {
            if (_commandRetriever.Start())
            {
                _grabCommands.Start();
            }
        }

        public void Grabcommands()
        {
            while (true)
            {
                Debug.Log("waiting...");
                Thread.Sleep(100);
                if (_commandRetriever.TryGrabCommand(out var commandName, out var commandValue))
                {
                    if (commandName.Equals(UnityEngineCommands.ReadTrialData))
                    {
                        _dataRetriever.RetrieveData(commandValue, out _currentTrialMetaData);

                        _currentUnijoySceneData = _sceneBuilder.Build(_currentTrialMetaData);

                        NewSceneReceived.Invoke(this, _currentUnijoySceneData);
                    }
                    else if (commandName.Equals(UnityEngineCommands.VisualOperationCommand))
                    {
                        StartRenderCommandReceived.Invoke(this, null);
                    }
                }
            }
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Resume()
        {
            throw new NotImplementedException();
        }
    }
}

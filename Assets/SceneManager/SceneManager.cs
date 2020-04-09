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
using UnijoyData.Shared.Commands;
using UnijoyData.Shared.Data;

namespace Assets.SceneManager
{
    public class SceneManager<T,M>:ISceneManager<T> where T : ISceneData where M:ITrialData
    {
        private ISceneBuilder<T> _sceneBuilder;
        private IDataRetriever<M> _dataRetriever;
        private ICommandsRetriever _commandRetriever;

        private ISceneData _currentUnijoySceneData;
        private M _currentTrialMetaData; 

        public SceneManager(
            ISceneBuilder<T> sceneBuilder,
            IDataRetriever<M> dataRetriever,
            ICommandsRetriever dataHandler)
        {
            _sceneBuilder = sceneBuilder;
            _dataRetriever = dataRetriever;
            _commandRetriever = dataHandler;
        }

        public void Start()
        {
            if (_commandRetriever.Start())
            {
                Task.Run(() =>
                {
                    while (true)
                    {
                        //Thread.Sleep(100);
                        if (_commandRetriever.TryGrabCommand(out var commandName, out var commandValue))
                        {
                            if (commandName.Equals(UnityEngineCommands.ReadTrialData))
                            {
                                _dataRetriever.RetrieveData(commandValue, out _currentTrialMetaData);
                            }
                        }
                    }
                }
                );

                Task.Run(() =>
                {

                });
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

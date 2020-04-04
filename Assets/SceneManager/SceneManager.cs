using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assets.Data;
using Assets.Network;
using Assets.Network.Handlers;
using Assets.Network.Retrievers;
using Assets.SceneBuilders;

namespace Assets.SceneManager
{
    public class SceneManager<T,M>:ISceneManager<T> where T : ISceneData where M:ITrialData
    {
        private int SERVER_PORT = 8910;

        private ISceneBuilder<T> _sceneBuilder;
        private IDataRetriever<M> _dataRetriever;
        private ICommandsRetriever _commandRetriever;

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
            Task.Run(() =>
            {
                if(_commandRetriever.TryGrabCommand(out var commandName, out var commandValue))
                {

                }
            }
            );
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

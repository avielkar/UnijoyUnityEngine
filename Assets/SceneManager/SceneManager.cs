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
        private ISceneBuilder<T> _sceneBuilder;
        private IDataRetriever<M> _dataRetriever;
        private ICommandsHandler _dataHandler;
        private NetworkManager _networkManager;

        public SceneManager(
            ISceneBuilder<T> sceneBuilder,
            IDataRetriever<M> dataRetriever,
            ICommandsHandler dataHandler)
        {
            _networkManager = new NetworkManager(dataHandler.Handle);
            _sceneBuilder = sceneBuilder;
            _dataRetriever = dataRetriever;
            _dataHandler = dataHandler;
        }

        public void Start()
        {
            _networkManager.Start();
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

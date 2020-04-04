using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assets.Data;
using Assets.Network.Handlers;
using Assets.Network.Retrievers;
using Assets.SceneBuilders;

namespace Assets.SceneManager
{
    public class SceneManager<T,M>:ISceneManager<T> where T : ISceneData where M:ITrialData
    {
        private ISceneBuilder<T> _sceneBuilder;
        private IDataRetriever<M> _dataRetriever;
        private IDataHandler<M> _dataHandler;

        public SceneManager(
            ISceneBuilder<T> sceneBuilder,
            IDataRetriever<M> dataRetriever,
            IDataHandler<M> dataHandler)
        {
            _sceneBuilder = sceneBuilder;
            _dataRetriever = dataRetriever;
            _dataHandler = dataHandler;
        }
    }
}

using Assets.SceneBuilders;
using Assets.SceneManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scenes.Shared
{
    public static class ScenesEventRegister
    {
        private static ISceneManager<ISceneData> _sceneManager;

        public static void Init(ISceneManager<ISceneData> sceneManager)
        {
            _sceneManager = sceneManager;
        }

        public static void NewSceneReceivedRegistration(EventHandler<ISceneData> action)
        {
            _sceneManager.NewSceneReceived += action;
        }

        public static void StartRenderCommandReceivedRegistraion(EventHandler action)
        {
            _sceneManager.StartRenderCommandReceived += action;
        }
    }
}

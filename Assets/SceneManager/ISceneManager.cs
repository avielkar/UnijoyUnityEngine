using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assets.SceneBuilders;

namespace Assets.SceneManager
{
    public interface ISceneManager<T> where T : ISceneData
    {
        void Start();

        void Stop();

        void Pause();

        void Resume();

        event EventHandler<T> NewSceneReceived;

        event EventHandler StartRenderCommandReceived;
    }
}

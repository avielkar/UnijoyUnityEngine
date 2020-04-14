using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assets.Network.Retrievers;

namespace Assets.Network.Handlers
{
    public interface ICommandsRetriever
    {
        bool TryGrabCommand(out string commandName, out string commandValue);

        bool Start();

        void Stop();
    }
}

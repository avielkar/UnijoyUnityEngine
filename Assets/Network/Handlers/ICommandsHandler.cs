using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assets.Data;
using Assets.Network.Retrievers;

namespace Assets.Network.Handlers
{
    public interface ICommandsHandler
    {
        public void Handle(string cmd, out string commandName, out string commandValue);
    }
}

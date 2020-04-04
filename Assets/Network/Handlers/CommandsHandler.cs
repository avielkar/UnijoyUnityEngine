using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assets.Data;
using Assets.Network.Retrievers;

namespace Assets.Network.Handlers
{
    public class CommandsHandler : ICommandsHandler
    {
        private readonly char[] _commandSplitChar = new char[]{'?'};

        public CommandsHandler()
        {
        }

        public void Handle(string cmd, out string commandName , out string commandValue)
        {
            var commandValuePair = cmd.Split(_commandSplitChar);
            (commandName, commandValue) = (commandValuePair[0], commandValuePair[1]);
        }
    }
}

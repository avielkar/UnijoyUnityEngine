using System;
using System.Collections.Concurrent;
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

        private ConcurrentQueue<(string, string)> _commandsBuffer;

        public CommandsHandler()
        {
            _commandsBuffer = new ConcurrentQueue<(string, string)>();
        }

        public void Handle(string cmd)
        {
            var commandValuePair = cmd.Split(_commandSplitChar);
            _commandsBuffer.Enqueue((commandValuePair[0], commandValuePair[1]));
        }

        public bool TryGrabCommand(out string commandName, out string commandValue)
        {
            if (_commandsBuffer.TryDequeue(out var command))
            {
                (commandName, commandValue) = command;

                return true;
            }
            (commandName, commandValue) = (null, null);
            return false;
        }
    }
}

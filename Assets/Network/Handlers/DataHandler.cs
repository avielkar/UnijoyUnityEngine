using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assets.Data;
using Assets.Network.Retrievers;

namespace Assets.Network.Handlers
{
    public class DataHandler : IDataHandler
    {
        private readonly char[] _commandSplitChar = new char[]{'?'};

        public DataHandler()
        {
        }

        public void Handle(string cmd)
        {
            var commandValuePair = cmd.Split(_commandSplitChar);
            var (commandName, commandValue) = (commandValuePair[0], commandValuePair[1]);


        }
    }
}

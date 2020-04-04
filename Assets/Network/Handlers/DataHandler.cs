using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assets.Data;
using Assets.Network.Retrievers;

namespace Assets.Network.Handlers
{
    public class DataHandler<T> : IDataHandler<T> where T:IScenceData
    {
        private IDataRetriever<T> _dataRetriever;
        private readonly char[] _commandSplitChar = new char[]{'?'};

        public DataHandler(IDataRetriever<T> dataRetriever)
        {
            _dataRetriever = dataRetriever;
        }

        public void Handle(string cmd)
        {
            var commandValuePair = cmd.Split(_commandSplitChar);
            var (commandName, commandValue) = (commandValuePair[0], commandValuePair[1]);
            
            if(commandName == "ReadTrialJsonData")
            {
                _dataRetriever.RetrieveData(commandValue , out var data);
            }
        }
    }
}

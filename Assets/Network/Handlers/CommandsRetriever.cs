using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTCP;
using System.Net;
using UnityEngine;

using UnijoyData.Shared.Data;
using Assets.Network.Retrievers;

namespace Assets.Network.Handlers
{
    public class CommandsRetriever : ICommandsRetriever
    {
        private readonly char[] _commandSplitChar = new char[]{'?'};
        private byte COMMANDS_DELIMITER = (byte)'#';
        
        private SimpleTcpServer _server;
        private readonly int _listeningPort;

        private ConcurrentQueue<(string, string)> _commandsBuffer;

        public CommandsRetriever(int listeningPort)
        {
            _listeningPort = listeningPort;

            _commandsBuffer = new ConcurrentQueue<(string, string)>();
        }

        public bool Start()
        {
            try
            {
                Debug.Log("Server is start listening...");
                _server = new SimpleTcpServer().Start(IPAddress.Parse("127.0.0.1"), _listeningPort);

                _server.ClientConnected += _server_ClientConnected;
                _server.Delimiter = COMMANDS_DELIMITER;
                _server.DelimiterDataReceived += _server_DelimiterDataReceived;

                return true;
            }
            catch (Exception e)
            {
                Debug.Log($"Failed to start lisening {e.Message}");

                return false;
            }

            void _server_ClientConnected(object sender, System.Net.Sockets.TcpClient e)
            {
                Debug.Log($"New client connected...");
            }

            void _server_DelimiterDataReceived(object sender, Message e)
            {
                var commandValuePair = e.MessageString.Split(_commandSplitChar);
                Debug.Log($"Received new command {commandValuePair[0]} with value {commandValuePair[1]}");
                _commandsBuffer.Enqueue((commandValuePair[0], commandValuePair[1]));
            }
        }

        public void Stop()
        {

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SimpleTCP;
using UnityEngine;

using Assets.Data;
using Assets.Network.Handlers;
using Assets.Network.Retrievers;

namespace Assets.Network
{

    public class NetworkManager : MonoBehaviour
    {
        private int SERVER_PORT = 8910;
        private byte COMMANDS_DELIMITER = (byte)'#';
        private SimpleTcpServer _server;

        private IDataHandler<IData> _dataHandler;
        private IDataRetriever<IData> _dataRetriever;

        public NetworkManager(
            IDataRetriever<IData> dataRetriever,
            IDataHandler<IData> dataHandler
            )
        {
            _dataHandler = dataHandler;
            _dataRetriever = dataRetriever;
        }
        void Start()
        {
            Debug.Log("Server is start listening...");
            _server = new SimpleTcpServer().Start(IPAddress.Parse("127.0.0.1"), SERVER_PORT);
            
            _server.ClientConnected += _server_ClientConnected;
            _server.Delimiter = COMMANDS_DELIMITER;
            _server.DelimiterDataReceived += _server_DelimiterDataReceived;

            void _server_ClientConnected(object sender, System.Net.Sockets.TcpClient e)
            {
                Debug.Log($"New client connected...");
            }
        }

        private void _server_DelimiterDataReceived(object sender, Message e)
        {
            _dataHandler.Handle(e.MessageString);
        }
    }
}

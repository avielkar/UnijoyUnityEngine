using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using SimpleTCP;
using UnityEngine;

namespace Assets.Network
{

    public class NetworkManager : MonoBehaviour
    {
        private int SERVER_PORT = 8910;
        private SimpleTcpServer _server;

        void Start()
        {
            Debug.Log("Server is start listening...");
            _server = new SimpleTcpServer().Start(IPAddress.Parse("127.0.0.1"), SERVER_PORT);
            _server.ClientConnected += _server_ClientConnected;

            void _server_ClientConnected(object sender, System.Net.Sockets.TcpClient e)
            {
                throw new NotImplementedException();
            }
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}

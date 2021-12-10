using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace wpfAppScarabeo
{
    class ThreadServer
    {
        String IPEnemy;
        int port;
        public ThreadServer(String IPEnemy, int port)
        {
            this.IPEnemy = IPEnemy;
            this.port = port;
        }

        public void waitForConnection()
        {
            TcpClient client = new TcpClient(IPEnemy, port);
            Byte[] data = new Byte[256]; // contiene i dati da ricevere o da mandare
        }
    }
}

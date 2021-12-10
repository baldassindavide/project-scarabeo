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
        int portEnemy;
        public ThreadServer(String IPEnemy, int portEnemy)
        {
            this.IPEnemy = IPEnemy;
            this.portEnemy = portEnemy;
        }

        public void waitForConnection()
        {
            bool done = false; // sentinella

            var listener = new TcpListener(System.Net.IPAddress.Parse(IPEnemy), portEnemy); // ascolto ip e porta del nemico
            listener.Start();

            while (!done)
            {
                Console.Write("Waiting for connection...");
                TcpClient client = listener.AcceptTcpClient();

                Console.WriteLine("Connection accepted.");
                NetworkStream ns = client.GetStream();
            }
        }
    }
}

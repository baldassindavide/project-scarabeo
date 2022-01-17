using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace wpfAppScarabeo
{
    class Server
    {
        String IPEnemy;
        int port;
        public Server(String IPEnemy, int port)
        {
            this.IPEnemy = IPEnemy;
            this.port = port;
        }

        public void waitForConnection()
        {
            String hostname = "172.16.102.76"; // my ip

            IPAddress addr;
            IPAddress.TryParse(hostname, out addr);
            TcpListener listener = new TcpListener(addr, 666);
            listener.Start();
            TcpClient c = listener.AcceptTcpClient();
            StreamReader sr = new StreamReader(c.GetStream());
            String s = sr.ReadLine();
            MessageBox.Show(s);
        }

        public void start()
        {
            Thread t = new Thread(waitForConnection);
            t.Start();
        }
    }
}//ggg

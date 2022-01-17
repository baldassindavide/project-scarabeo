using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace wpfAppScarabeo
{
    class Client
    {
        string IPEnemy,nickname;
        int port;

        public Client(string IPEnemy, int port, string nickname)
        {
            this.IPEnemy = IPEnemy;
            this.port = port;
            this.nickname = nickname;
        }

        public void requestConnection()
        {
            TcpClient c = new TcpClient("172.16.102.71", 667);
            StreamWriter sw = new StreamWriter(c.GetStream());
            

            // prendo il mio indirizzo ip
            //string hostName = Dns.GetHostName();
            //string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();

            //string sToSend = "C;" + myIP + ";" + nickname;
            //Byte[] byteToSend = Encoding.ASCII.GetBytes(sToSend); // converto la stringa contenuta nel pacchetto in un array di byte
            //client.Send(byteToSend, byteToSend.Length); // invio pacchetto
            //MessageBox.Show("Messaggio " + sToSend +" inviato");


        }
    }
}

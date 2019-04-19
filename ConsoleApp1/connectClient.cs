using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class connectClient
    {
        private string ip;
        private int port;
        public connectClient(int port, string _ip)
        {
            this.port = port;
            this.ip = _ip;
        }
        public void toConnect()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            TcpClient client = new TcpClient();
            client.Connect(ep);
            Console.WriteLine("Client Added");
            BinaryWriter writer = new BinaryWriter(client.GetStream());
            string result = "set controls/flight/rudder -1";
            string temp = result + "\r\n";
            Console.WriteLine(temp);
            writer.Write(System.Text.Encoding.ASCII.GetBytes(temp));
        }
    }
}

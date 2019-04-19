using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Command
    {
        private string ip;
        private int port;
        public Command(int port, string _ip)
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
            string result = "set controls/flight/rudder 0";
            string temp = result + "\r\n";
            Console.WriteLine("whattt");
            Console.WriteLine(temp);
            writer.Write(System.Text.Encoding.ASCII.GetBytes(temp));
        }
    }
}

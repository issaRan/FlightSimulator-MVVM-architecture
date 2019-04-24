using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class Command
    { 
        private BinaryWriter writer;
        private TcpClient client;
        bool connected = false;
        public Command()
        {
            //this.port = port;
            //this.ip = _ip;
        }
        #region Singelton
        private static Command m_Instance = null;
        public static Command Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new Command();
                }
                return m_Instance;
            }
        }
        #endregion
        public void toConnect(string ip,int port)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            client = new TcpClient();
            client.Connect(ep);
            Console.WriteLine("Client Added");
            connected = true;
            writer = new BinaryWriter(client.GetStream());
                      
        }
        public void send(string command)
        {
            BinaryWriter writer = new BinaryWriter(client.GetStream());
            string temp = command + "\r\n";
            writer.Write(System.Text.Encoding.ASCII.GetBytes(temp));
            writer.Flush();
        }
        public bool ifConnected()
        {
            return this.connected;
        }
        public void Stop()
        {
            this.client.Close();
        }
    }
}

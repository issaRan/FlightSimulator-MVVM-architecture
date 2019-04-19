using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Info
    {
        private int port;
        private string ip;
        private TcpListener listener;
        private IClinetHandler ch;
        private Thread thread;
        public Info(int port, string _ip, IClinetHandler ch)
        {
            this.port = port;
            this.ip = _ip;
            this.ch = ch;
        }
        public void Start()
        {
            listener = new TcpListener(new IPEndPoint(IPAddress.Parse(ip), port));
            listener.Start();
            Console.WriteLine("Waiting for connections...");
            TcpClient client = listener.AcceptTcpClient();
            try
            {
                this.thread = new Thread(() => readFromSimulator(client));
                thread.Start();
            }
            catch (SocketException)
            {
                throw new Exception("Error");
            }
        }
        public void readFromSimulator(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(client.GetStream());
            string message;
            string[] splitStr;
            while (client.Connected)
            {
                System.Threading.Thread.Sleep(3000);
                message = reader.ReadLine();
                Console.WriteLine(message);
                splitStr = message.Split(',');
                //reader = new StreamReader(client.GetStream());
            }
        }
        public void Stop()
        {
            listener.Stop();
        }
    }
}

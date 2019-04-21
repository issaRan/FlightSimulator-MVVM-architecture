using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class Info
    {
        private int port;
        private string ip;
        private TcpListener listener;
        TcpClient client;
        private Thread thread;

        public Info()
        {

        }
        #region
        private static Info m_Instance = null;
        public static Info Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new Info();
                }
                return m_Instance;
            }
        }
        #endregion
        public void Start()
        {
            
            string ip = "127.0.0.1";
            int port = 9586;
            listener = new TcpListener(new IPEndPoint(IPAddress.Parse(ip), port));
            listener.Start();
            Console.WriteLine("Waiting for connections...");
            this.client = listener.AcceptTcpClient();
            try
            {
                this.thread = new Thread(() => readFromSimulator());
                thread.Start();
            }
            catch (SocketException)
            {
                throw new Exception("Error");
            }
            
        }
        public string[] readFromSimulator()
        {
            if (!client.Connected)
            {
                Start();
            }
            NetworkStream stream = this.client.GetStream();
            BinaryReader reader = new BinaryReader(stream);
            string message = "";
            string[] splitted;
            char c;
            while ((c = reader.ReadChar()) != '\n')
            {
                message += c;
            }
            Console.WriteLine(message);
            splitted = message.Split(',');
            message = "";
            return splitted;
        }

        public void Stop()
        {
            listener.Stop();
        }
    }
}

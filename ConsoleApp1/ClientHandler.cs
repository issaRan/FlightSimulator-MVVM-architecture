using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ClientHandler : IClinetHandler
    {
        TcpClient _client;
        public ClientHandler(TcpClient client)
        {
            this._client = client;
        }
        public void HandleClient(TcpClient client)
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
                reader = new StreamReader(client.GetStream());
            }            
        }
        private string ExecuteCommand(string commandLine, TcpClient client)
        {
            return commandLine;
        }
    }
}

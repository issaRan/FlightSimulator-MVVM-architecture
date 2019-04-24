using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class AutomaticModel
    {
        private Thread thread;
        public void sendCommands(string commnds)
        {
            try
            {
                this.thread = new Thread(() => sendCommandsToModel(commnds));
                thread.Start();
            }
            catch (SocketException)
            {
                throw new Exception("Error");
            }

        }
        public void sendCommandsToModel(string commnds)
        {
            String[] splittedCommands;
            splittedCommands = commnds.Split('\n');
            foreach (string Message in splittedCommands)
            {
                if (Command.Instance.ifConnected())
                {
                    Command.Instance.send(Message);
                    System.Threading.Thread.Sleep(2000);
                }
            }
        }
    }
}

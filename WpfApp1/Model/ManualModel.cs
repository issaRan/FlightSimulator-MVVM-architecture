using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class ManualModel
    {
        private Info info;
        private Command command;
        public ManualModel(){}
        public void send(string commandSend)
        {
            new Thread(delegate ()
            {
                Command.Instance.send(commandSend);
            }).Start();
        }
    }
}

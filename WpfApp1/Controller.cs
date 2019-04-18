using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1
{
    class Controller
    {
        private Dictionary<string, ICommand> commands;
        private IModel model;
        public Controller(IModel model)
        {/*
            this.model = model;
            commands = new Dictionary<string, ICommand>();
            commands.Add("generate", new GenerateMazeCommand(model));
            // more commands...
            */
        }
        /*
        public string ExecuteCommand(string commandLine, TcpClient client)
        {
            string[] arr = commandLine.Split(',');
            string commandKey = arr[0];
            if (!commands.ContainsKey(commandKey))
                return "Command not found";
            string[] args = arr.Skip(1).ToArray();
            ICommand command = commands[commandKey];
            return command.Execute(args, client);
        }
        */
    }
}

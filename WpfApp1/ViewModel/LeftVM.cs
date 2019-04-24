using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Model;
using WpfApp1.Views.Windows;

namespace WpfApp1.ViewModel
{
    class LeftVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand _settingsCommand;
        public ICommand SettingsCommand
        {
            get
            {
                return this._settingsCommand ?? (this._settingsCommand = new CommandHandler(() => {
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SettingsCommand"));
                    (new Settings()).Show();
                }));
            }
        }
        private ICommand _connectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                return this._connectCommand ?? (this._connectCommand = new CommandHandler(() => {
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ConnectCommand"));
                    ToConnect();
                }));
            }
        }
        private ICommand _disconnectCommand;
        public ICommand DisConnectCommand
        {
            get
            {
                return this._disconnectCommand ?? (this._disconnectCommand = new CommandHandler(() => {
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DisconnectCommand;"));
                    Todisconnect();
                }));
            }
        }
        public void ToConnect()
        {
            FlightBoardModel salim = FlightBoardModel.getInstance();
            Thread connection = new Thread(() => salim.connect());
            connection.Start();
        }
        public void Todisconnect()
        {
            Info todisconnectServer = Info.Instance;
            todisconnectServer.Stop();
            Command todisconnectClient = Command.Instance;
            todisconnectClient.Stop();
        }
    }
}

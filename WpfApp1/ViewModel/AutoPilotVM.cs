using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    class AutoPilotVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Brush background;
        private AutomaticModel model;
        private string commands;
        public AutoPilotVM()
        {
            this.model = new AutomaticModel();
            this.background = Brushes.White;
            this.commands = "";
        }
        public Brush Background
        {
            get { return this.background; }
            set
            {
                this.background = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Background"));
            }
        }

        public String Commands
        {
            get { return this.commands; }
            set
            {
                if (!string.IsNullOrEmpty(commands = value))
                {
                    if (Background == Brushes.White) { Background = Brushes.LightPink; }
                }
                else if (Background != Brushes.White) { Background = Brushes.White; }
                /*
                 * IMPLEMENT THE REST OF SET METHOD HERE ! 
                 */
            }
        }

        private ICommand _clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand = new CommandHandler(() =>
                {
                    this.commands = "";
                    this.background = Brushes.White;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Commands"));
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Background"));
                }));
            }
        }
        private ICommand _okCommand;
        public ICommand OkCommand
        {
            get
            {
                return _okCommand ?? (_okCommand = new CommandHandler(() =>
                {
                    string commandsToModel = commands;
                    Commands = "";
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Commands"));
                    Background = Brushes.White;
                    model.sendCommands(commandsToModel);
                }));
            }
        }
    }
}
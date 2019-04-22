using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
    }
}

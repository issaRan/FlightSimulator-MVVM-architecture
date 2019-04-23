using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Model;
using WpfApp1.Model.Interface;

namespace WpfApp1.ViewModel
{
    public class SettingsVM
    {
        private ISettingsModel model;
        private static ISettingsModel m_Instance = null;
        public static ISettingsModel Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new ApplicationSettingsModel();
                }
                return m_Instance;
            }
        }
        public SettingsVM()
        {
            this.model = new ApplicationSettingsModel();
        }
        public string FlightServerIP
        {
            get { return this.model.FlightServerIP; }
            set { this.model.FlightServerIP = value; }
        }
        public int FlightInfoPort
        {
            get { return this.model.FlightInfoPort; }
            set { this.model.FlightInfoPort = value; }
        }
        public int FlightCommandPort
        {
            get { return this.model.FlightCommandPort; }
            set { this.model.FlightCommandPort = value; }
        }

        private ICommand _cancelCommand;
        private ICommand _okCommand;

        public ICommand CancelCommand
        {
            get
            {
                return this._cancelCommand ?? (this._cancelCommand = new CommandHandler(() => this.model.ReloadSettings()));
            }
        }
        public ICommand OkCommand
        {
            get
            {
                return this._okCommand ?? (this._okCommand = new CommandHandler(() =>
                {
                    this.SaveSettings();
                    this.ReloadSettings();
                }));
            }
        }
        public void SaveSettings() {
            this.model.SaveSettings();
        }
        public void ReloadSettings() {
            this.SaveSettings();
            this.FlightCommandPort = this.model.FlightCommandPort;
            this.FlightInfoPort = this.model.FlightInfoPort;
            this.FlightServerIP = this.model.FlightServerIP;
        }
    }
}
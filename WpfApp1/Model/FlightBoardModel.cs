using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfApp1.Model.Interface;
using WpfApp1.ViewModel;


namespace WpfApp1.Model
{
    class FlightBoardModel : BaseNotify
    {
        private FlightBoardVM boardVM;
        private static FlightBoardModel instance = null;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        private Info info;
        private Command command;
        
        public static FlightBoardModel getInstance()
        {
            if (instance == null)
            {
                return instance = new FlightBoardModel();
            }
            return instance;
        }
        private double lon = 0;
        public double Lon
        {
            get
            {
                return lon;
            }
            set
            {
                lon = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Lon"));
            }
        }
        private double lat;
        public double Lat
        {
            get
            {
                return lat;
            }
            set
            {
                lat = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Lat"));
            }
        }
        public void connect()
        {
            ISettingsModel model = ApplicationSettingsModel.Instance;
            info = Info.Instance;
            command = Command.Instance;
            info.Start(model.FlightServerIP, model.FlightInfoPort);
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    string[] splittedVal;
                    splittedVal = info.readFromSimulator();
                    Lon = Convert.ToDouble(splittedVal[0]);
                    Lat = Convert.ToDouble(splittedVal[1]);
                }
            });
            thread.Start();
            command.toConnect(model.FlightServerIP, model.FlightCommandPort);
        }
    }
}


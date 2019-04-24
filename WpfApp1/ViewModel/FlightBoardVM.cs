using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    class FlightBoardVM : BaseNotify
    {
        private FlightBoardModel model;
        public new event PropertyChangedEventHandler PropertyChanged;
        public double Lon { get; set; }
        // The len property.
        public double Lat { get; set; }
        private static FlightBoardVM m_Instance = null;
        public static FlightBoardVM Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new FlightBoardVM();
                }
                return m_Instance;
            }
        }

        public FlightBoardVM()
        {
            model = FlightBoardModel.getInstance();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "Lat")
                {
                    Lat = model.Lat;
                }
                // Update the lon.
                else if (e.PropertyName == "Lon")
                {
                    Lon = model.Lon;
                }
                // Notify everyone of changes.
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(e.PropertyName));
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel;

namespace WpfApp1.Model.EventArgs
{
    public class VirtualJoystickEventArgs
    {
        private double aileron;
        private double elevator;
        PathsForSimulator paths = new PathsForSimulator();
        public VirtualJoystickEventArgs()
        {            
            aileron = 0;
            elevator = 0;
        }
        public double Aileron {
            get { return aileron; }
            set
            {               
                aileron = value;
                if (aileron < -1)
                {
                    aileron = -1;
                }
                else if (aileron > 1)
                {
                    aileron = 1;
                }
                if (Command.Instance.ifConnected())
                {
                    Command.Instance.send(paths.GetElevetor() + Convert.ToString(elevator));
                }
            }
        }
        public double Elevator {
            get { return elevator; }
            set
            {
                elevator = value;
                if (elevator < -1)
                {
                    elevator = -1;
                }
                else if (elevator > 1)
                {
                    elevator = 1;
                }
                
                if (Command.Instance.ifConnected())
                {
                    Command.Instance.send(paths.GetAileronPath() + Convert.ToString(aileron));
                }
            }
        }
    }
}

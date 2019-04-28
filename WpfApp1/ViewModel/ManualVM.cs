using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
namespace WpfApp1.ViewModel
{
    class ManualVM
    {
        private double aileron;
        private double elevator;
        private double throttle;
        private double rudder;
        private ManualModel manualModel = new ManualModel();
        private PathsForSimulator paths = new PathsForSimulator();
        public double Throttle
        {
            get { return throttle; }
            set
            {
                throttle = value;
                if (throttle < -1)
                {
                    throttle = -1;
                }
                else if (throttle > 1)
                {
                    throttle = 1;
                }
                if (Command.Instance.ifConnected())
                {
                    Command.Instance.send(paths.GetThrottlePath() + Convert.ToString(throttle));
                }
            }
        }
        public double Rudder
        {
            get { return rudder; }
            set
            {
                rudder = value;
                if (rudder < -1)
                {
                    rudder = -1;
                }
                else if (rudder > 1)
                {
                    rudder = 1;
                }
                if (Command.Instance.ifConnected())
                {
                    Command.Instance.send(paths.GetRudder() + Convert.ToString(rudder));
                }
            }
        }

        public double Aileron
        {
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
        public double Elevator
        {
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

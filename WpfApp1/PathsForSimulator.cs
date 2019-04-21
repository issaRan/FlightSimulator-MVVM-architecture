using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class PathsForSimulator
    {
        public string GetThrottlePath()
        {
            string ThrottlePath ="set /controls/engines/current-engine/throttle ";
            return ThrottlePath;
        }
        public string GetAileronPath()
        {
            string aileronPath = "set /controls/flight/aileron ";
            return aileronPath;
        }
        public string GetRudder()
        {
            string rudderPath = "set /controls/flight/rudder ";
            return rudderPath;
        }
        public string GetElevetor()
        {
            string elevetorPath = "set /controls/flight/elevator ";
            return elevetorPath;
        }
    }
}

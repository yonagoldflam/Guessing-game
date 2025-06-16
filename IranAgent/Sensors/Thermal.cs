using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranAgent.Sensors
{
    public class Thermal : Sensor
    {
        public Thermal() 
        { 
            Type = "thermal";
            
        }

        public override void Activate()
        {
            HistoryActivate += 1;
        }
    }
}

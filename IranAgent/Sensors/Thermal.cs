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
            Name = "thermal";
            Type = "audio";
        }

        public override void TrueActivate()
        {
            CountTrueActivate += 1;
        }

        public override bool FalseActivate()
        {
            return false;
        }
    }
}


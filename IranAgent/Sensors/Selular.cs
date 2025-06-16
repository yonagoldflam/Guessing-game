using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranAgent.Sensors
{
    public class Selular : Sensor
    {
        public Selular()
        {
            Name = "selular";
            Type = "Pulse";
        }

        public override void TrueActivate()
        {
            CountTrueActivate += 1;
        }

        public override void FalseActivate()
        {
            CountFalseActivate += 1;
        }
    }
}


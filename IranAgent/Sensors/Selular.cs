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
            Type = "pulse";
        }

        public override void TrueActivate()
        {
            CountTrueActivate += 1;
        }

        public override bool FalseActivate()
        {
            
            CountFalseActivate += 1;
            return CountFalseActivate % 3 == 0;  
        }
    }
}


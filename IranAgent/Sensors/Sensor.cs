using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranAgent.Sensors
{
    public abstract class Sensor
    {
        public string Name;
        public string Type;
        public int CountTrueActivate = 0;
        public int CountFalseActivate = 0;
        public virtual void TrueActivate()
        {
            CountTrueActivate += 1;
        }

        public virtual bool FalseActivate() 
        { 
            CountFalseActivate += 1;
            return false;
        }
    }
}

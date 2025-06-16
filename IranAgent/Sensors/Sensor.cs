using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranAgent.Sensors
{
    public abstract class Sensor
    {
        public string Type ;
        public int HistoryActivate = 0;
        public virtual void Activate()
        {
            HistoryActivate += 1;
        }
    }
}

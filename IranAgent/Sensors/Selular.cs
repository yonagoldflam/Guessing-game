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
            Type = "selular";

        }

        public override void Activate()
        {
            HistoryActivate += 1;
        }
    }
}

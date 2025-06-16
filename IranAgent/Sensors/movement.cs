using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranAgent.Sensors
{
    public class Movement : Sensor
    {
        public Movement()
        {
            Type = "movement";
        }

        public override void Activate()
        {
            HistoryActivate += 1;
        }
    }
}

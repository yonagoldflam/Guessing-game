using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IranAgent.Sensors;

namespace IranAgent.Agents
{
    public class IraniAgent
    { 
        public List<string> Weak = new List<string>();

        public IraniAgent(string WeakSensor1, string WeakSensor2)
        {
            Weak.Add(WeakSensor1);
            Weak.Add(WeakSensor2);
        }
    }
}

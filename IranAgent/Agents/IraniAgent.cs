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
        public List<string> Weaknes = new List<string>();
        public bool Status = true;

        public IraniAgent(string WeakSensor1, string WeakSensor2)
        {
            Weaknes.Add(WeakSensor1);
            Weaknes.Add(WeakSensor2);
        }
    }
}

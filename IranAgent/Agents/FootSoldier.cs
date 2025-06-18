using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IranAgent.Sensors;

namespace IranAgent.Agents
{
    public class FootSoldier
    { 
        public List<string> Weaknes;
        public bool Status = true;
        public int ContAttack = 0;
        public string Type = "foot soldier";

        public FootSoldier(List<string> weaknes)
        {
            Weaknes = weaknes;
        }

        public virtual bool CarryingOutAttack()
        {
            return false;
        }
    }
}

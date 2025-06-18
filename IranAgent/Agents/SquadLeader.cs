using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranAgent.Agents
{
    public class SquadLeader : FootSoldier
    {
        public SquadLeader(List<string> weaknes) : base(weaknes)
        {
            Weaknes = weaknes;
            Type = "SquadLeader";
        }

        public override bool CarryingOutAttack()
        {
            ContAttack++;
            return DoAttack();
        }

        public bool DoAttack()
        {
            return ContAttack % 5 == 0;
        }
    }
}

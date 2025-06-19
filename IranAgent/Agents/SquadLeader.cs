using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranAgent.Soldier
{
    public class SquadLeader : FootSoldier
    {
        public SquadLeader(List<string> weaknesses, string name, int id=0) : base(weaknesses,name,id)
        {
            Weaknesses = weaknesses;
            Type = "squad leader";
            Name = name;
            Id = id;
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

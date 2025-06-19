using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IranAgent.Sensors;

namespace IranAgent.Soldier
{
    public class FootSoldier
    {
        public List<string> Weaknesses;
        public int Id;
        public string Name;
        public string Type;
        public int ContAttack = 0;


        public FootSoldier(List<string> weaknesses, string name, int id=0)
        {
            Weaknesses = weaknesses;
            Name = name;
            Type = "foot soldier";
            Id = id;
        }

        public virtual bool CarryingOutAttack()
        {
            return false;
        }
    }
}

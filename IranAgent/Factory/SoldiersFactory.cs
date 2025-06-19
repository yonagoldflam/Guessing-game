using IranAgent.Dal;
using IranAgent.Soldier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranAgent.Factory
{
    public static class SoldiersFactory
    {
        public static Random rnd = new Random();
        public static List<string> WeaknessesSensors = new List<string> { "thermal", "selular", "movement"};

        public static List<FootSoldier> a = SoldiersDal.ReadAllSoldiers();
        public static List<FootSoldier> Soldires = new List<FootSoldier>(a);

        public static int CurrentIndex = 0;
        public static void NextSoldier()
        {
            if (Soldires.Count-1 > CurrentIndex) 
                CurrentIndex++;
        }
        public static FootSoldier GanarateFootSoldier(string soldierName)
        {
            return new FootSoldier(new List<string> { WeaknessesSensors[rnd.Next(WeaknessesSensors.Count)], WeaknessesSensors[rnd.Next(WeaknessesSensors.Count)] }, soldierName);
        }
        public static FootSoldier GanarateSquadSoldier(string soldierName)
        {
            return new SquadLeader(new List<string> { WeaknessesSensors[rnd.Next(WeaknessesSensors.Count)], WeaknessesSensors[rnd.Next(WeaknessesSensors.Count)], WeaknessesSensors[rnd.Next(WeaknessesSensors.Count)], WeaknessesSensors[rnd.Next(WeaknessesSensors.Count)] }, soldierName);
        }

    }
}

using IranAgent.Agents;
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
        public static List<string> WeaknesSensors = new List<string> { "thermal", "selular", "movement"};
        
        public static FootSoldier FootSoldier1 = new FootSoldier(new List<string> { WeaknesSensors[rnd.Next(WeaknesSensors.Count)], WeaknesSensors[rnd.Next(WeaknesSensors.Count)] });
        public static FootSoldier FootSoldier2 = new FootSoldier(new List<string> { WeaknesSensors[rnd.Next(WeaknesSensors.Count)], WeaknesSensors[rnd.Next(WeaknesSensors.Count)] });
        public static SquadLeader SquadSoldier = new SquadLeader(new List<string> { WeaknesSensors[rnd.Next(WeaknesSensors.Count)], WeaknesSensors[rnd.Next(WeaknesSensors.Count)], WeaknesSensors[rnd.Next(WeaknesSensors.Count)], WeaknesSensors[rnd.Next(WeaknesSensors.Count)] });
        public static List<FootSoldier> Soldires = new List<FootSoldier> {FootSoldier1,FootSoldier2, SquadSoldier };

        public static int CurrentIndex = 0;
        public static void NextSoldier()
        {
            if (Soldires.Count-1 > CurrentIndex) 
                CurrentIndex++;
        }

    }
}

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
        public static List<string> Weaknes = new List<string> { "thermal", "selular", "movement"};
        
        public static FootSoldier FootSoldier1 = new FootSoldier(Weaknes[rnd.Next(Weaknes.Count)], Weaknes[rnd.Next(Weaknes.Count)]);
        public static FootSoldier FootSoldier2 = new FootSoldier(Weaknes[rnd.Next(Weaknes.Count)], Weaknes[rnd.Next(Weaknes.Count)]);
        //public static SquadLeader SquadSoldier = new SquadLeader();
        public static List<FootSoldier> Soldires = new List<FootSoldier> {FootSoldier1,FootSoldier2 };

        public static int CurrentIndex = 0;
        public static void NextSoldier()
        {
            if (Soldires.Count-1 > CurrentIndex) 
                CurrentIndex++;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IranAgent.Sensors;
namespace IranAgent
{
    public static class Menue
    {
        public static void PrintMenu()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1. choice sensor. other key to exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        while (InitializationAgents.Agent1.Status)
                        {
                            Manager.AddsToAppropriateList(Manager.GenarateNewSensor());
                            InitializationAgents.Agent1.Status = Manager.Equality();
                        }
                        break;

                    default:
                        flag = false;
                        break;
                }
            }
        }
    }
}

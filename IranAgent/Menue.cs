using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IranAgent.Factory;
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
                Console.WriteLine("1. choice sensor \n2. add soldiers to DB \nother key to exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        Manager.LoadSoldierList();
                        Console.WriteLine(SoldiersFactory.Soldires.Count());
                        string uname = Manager.GetUserName();
                        bool flagg = true;
                        while (flagg)
                        {
                            Manager.SensorActivation(Manager.GenarateSensor());
                            Manager.SoldierDiscovered(Manager.PrintEqualyResalt());
                        }
                        break;

                    case "2":
                        Manager.InsertNewSoldier();
                        break;

                    default:
                        flag = false;
                        break;
                }
            }
        }
    }
}

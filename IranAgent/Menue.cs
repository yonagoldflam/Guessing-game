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
                        bool Guessesd = false;
                        while (!Guessesd)
                        {
                            Console.WriteLine("enter sensor type");
                            Manager.SensorsList.Add(Manager.GenarateNewSensor(Console.ReadLine()));
                            Manager.ActivateChooseSensors();
                            Console.WriteLine(Manager.SensorsList[0].Type);
                            string TxtResalt = Manager.Equality();
                            Console.WriteLine(TxtResalt);   
                            Guessesd = Manager.CheckDone(TxtResalt);
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

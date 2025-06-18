using IranAgent.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IranAgent.Agents;
using IranAgent.Factory;

namespace IranAgent
{
    public static class Manager
    {
        public static FootSoldier CurrentSoldier = SoldiersFactory.Soldires[SoldiersFactory.CurrentIndex];
        public static List<string> CurrCopyWeaknes = new List<string>(CurrentSoldier.Weaknes);
        public static List<string> SuccessGuesses = new List<string>();
        public static int CountTurns = 0;

        public static void UpdateCurrentSoldier()
        {
            SoldiersFactory.NextSoldier();
            CurrentSoldier = SoldiersFactory.Soldires[SoldiersFactory.CurrentIndex];
            CurrCopyWeaknes = new List<string>(CurrentSoldier.Weaknes);
        }
        
        public static Sensor GenarateSensor()
        {
            bool CorectInput = false;
            while (!CorectInput)
            {
                Console.WriteLine("enter sensor type. to exit enter: exit");
                Sensor sensor = SensorsFactory.GanarateSensorInstance(Console.ReadLine().ToLower());
                if (sensor != null) 
                    return sensor;
                else    
                    Console.WriteLine("the sensor is not found, plees try again");               
            }
            return null;
        }

        public static void SensorActivation(Sensor sensor)
        {
            if (sensor != null)
            {
                switch (sensor.Type)
                {
                    case "audio":
                        if (ComplianceCheckVulnerability(sensor))
                        {
                            sensor.TrueActivate();
                        }
                        break;

                    case "pulse":
                        if (ComplianceCheckVulnerability(sensor))
                        {
                            sensor.TrueActivate();
                        }
                        else
                        {
                            sensor.FalseActivate();
                        }
                        if (sensor.CountFalseActivate >= 3)
                        {
                            bool a = SuccessGuesses.Remove(sensor.Name);
                            sensor.CountFalseActivate = 0;
                            if (a)
                                CurrCopyWeaknes.Add(sensor.Name);
                        };
                        break;
                }
            }
        }

        public static bool ComplianceCheckVulnerability(Sensor sensor)
        {
            foreach (string WeakSensor in CurrCopyWeaknes)
            {
                if (sensor.Name == WeakSensor)
                {
                    CurrCopyWeaknes.Remove(sensor.Name);
                    SuccessGuesses.Add(sensor.Name);
                    return true;
                }
            }
            return false;
        }
        
        public static string PrintEqualyResalt()
        {
            string TxtEqualy = $"{SuccessGuesses.Count()}/{CurrentSoldier.Weaknes.Count()}";
            Console.WriteLine(TxtEqualy);            
            return TxtEqualy;
        }

        public static void SoldierDiscovered(string TxtEqualy)
        {
            if (TxtEqualy == new string(TxtEqualy.Reverse().ToArray()))
            {
                SuccessGuesses.Clear();
                CountTurns++;
                if (CountTurns % 10 == 0)
                    SuccessGuesses.Clear();
                CurrentSoldier.CarryingOutAttack();
                UpdateCurrentSoldier();
                Console.WriteLine($"You have discovered the agent!!.\nNow try to discover the next agent which is of type: {CurrentSoldier.Type}");
            }

        }
    }
}

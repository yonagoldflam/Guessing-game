using IranAgent.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IranAgent.Agents;
using IranAgent.Factory;
using System.Collections;

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
                if (ComplianceCheckVulnerability(sensor))
                {
                    sensor.TrueActivate();
                }
                else
                {
                    if (sensor.FalseActivate())
                    {
                        bool a = SuccessGuesses.Remove(sensor.Name);
                        if (a) CurrCopyWeaknes.Add(sensor.Name);
                    }
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
            EndTurn();
            return TxtEqualy;
        }

        public static void EndTurn()
        {
            CountTurns++;
            ClearGuessesAt10Turn();
            if (CurrentSoldier.CarryingOutAttack()) Attacking();
        }
        
        public static void SoldierDiscovered(string TxtEqualy)
        {
            if (TxtEqualy == new string(TxtEqualy.Reverse().ToArray()))
            {
                SuccessGuesses.Clear();
                UpdateCurrentSoldier();
                Console.WriteLine($"You have discovered the agent!!.\nNow try to discover the next agent which is of type: {CurrentSoldier.Type}");
            }
        }

        public static void Attacking()
        {
            if (SuccessGuesses.Count > 0)
            {
                Random random = new Random();
                int randomIndex = random.Next(SuccessGuesses.Count);
                CurrCopyWeaknes.Add(SuccessGuesses[randomIndex]);
                SuccessGuesses.RemoveAt(randomIndex);
                Console.WriteLine("=========ATTACK========");
            }
        }

        public static void ClearGuessesAt10Turn()
        {
            if (CountTurns % 10 == 0)
            {
                CurrCopyWeaknes.AddRange(SuccessGuesses);
                SuccessGuesses.Clear();
                Console.WriteLine("==10TURNS==");
            }
        }
    }
}

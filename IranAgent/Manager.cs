using IranAgent.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IranAgent.Soldier;
using IranAgent.Factory;
using System.Collections;
using malshinon.db;
using IranAgent.Dal;
using Org.BouncyCastle.Asn1.X509;
using IranAgent.RoundsGame;

namespace IranAgent
{
    public static class Manager
    {
        public static FootSoldier CurrentSoldier = SoldiersFactory.Soldires[SoldiersFactory.CurrentIndex];
        public static List<string> CurrCopyWeaknesses = new List<string>(CurrentSoldier.Weaknesses);
        public static List<string> SuccessGuesses = new List<string>();
        public static int CountTurns = 0;
        public static DateTime StartRound;
        public static string CurrentUser;
        public static MySqlData SqlData = new MySqlData();

        public static void UpdateCurrentSoldier()
        {
            SoldiersFactory.NextSoldier();
            CurrentSoldier = SoldiersFactory.Soldires[SoldiersFactory.CurrentIndex];
            CurrCopyWeaknesses = new List<string>(CurrentSoldier.Weaknesses);
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
                        if (SuccessGuesses.Remove(sensor.Name)) CurrCopyWeaknesses.Add(sensor.Name);
                        Console.WriteLine("=========SELULAR 3 TIMES===========");
                    }
                }                                      
            }
        }

        public static bool ComplianceCheckVulnerability(Sensor sensor)
        {
            foreach (string WeakSensor in CurrCopyWeaknesses)
            {
                if (sensor.Name == WeakSensor)
                {
                    CurrCopyWeaknesses.Remove(sensor.Name);
                    SuccessGuesses.Add(sensor.Name);
                    return true;
                }
            }
            return false;
        }
        
        public static string PrintEqualyResalt()
        {          
            string TxtEqualy = $"{SuccessGuesses.Count()}/{CurrentSoldier.Weaknesses.Count()}";           
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
                EndRound();
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
                CurrCopyWeaknesses.Add(SuccessGuesses[randomIndex]);
                SuccessGuesses.RemoveAt(randomIndex);
                Console.WriteLine("=========ATTACK========");
            }
        }

        public static void ClearGuessesAt10Turn()
        {
            if (CountTurns % 10 == 0)
            {
                CurrCopyWeaknesses.AddRange(SuccessGuesses);
                SuccessGuesses.Clear();
                Console.WriteLine("==10TURNS==");
            }
        }

        public static void GetUserName()
        {
            Console.WriteLine("enter user name");
            string userName = Console.ReadLine();
            if (UserDal.UserNameIsExist(userName))
            {
                Console.WriteLine("Your name has been successfully recognized.");
            }
            else
            {
                UserDal.NewUser(userName);
                Console.WriteLine("You are identified as a new user.");
            }
            CurrentUser = userName;
        }

        public static void InsertNewSoldier()
        {
            Console.WriteLine("enter type (foot or squad)");
            string type = Console.ReadLine();
            Console.WriteLine("enter the name soldier");
            if (type == "foot") 
                SoldiersDal.NewSoldier(SoldiersFactory.GanarateFootSoldier(Console.ReadLine()));
            else if (type == "squad")
                SoldiersDal.NewSoldier(SoldiersFactory.GanarateSquadSoldier(Console.ReadLine()));
            Console.WriteLine("done");
        }

        public static void LoadSoldierList()
        {
            StartRound = DateTime.Now;

        }

        public static void EndRound()
        {
            Console.WriteLine(CurrentSoldier.Id + CurrentSoldier.Name);
            GameRoundDal.InsertRound(new Round(UserDal.GetPlayerID(CurrentUser), CurrentSoldier.Id, StartRound, CountTurns-CurrentSoldier.Weaknesses.Count()));
        }
    }
}

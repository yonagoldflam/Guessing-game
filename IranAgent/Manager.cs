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
        public static List<string> CopyWeakAgent1 = new List<string>(InitializationAgents.Agent1.Weaknes);
        public static List<string> SuccessGuesses = new List<string>();

        public static Sensor GenarateNewSensor()
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

        public static void AddsToAppropriateList(Sensor sensor)
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
                            SuccessGuesses.Remove(sensor.Name);
                            sensor.CountFalseActivate = 0;
                            CopyWeakAgent1.Add(sensor.Name);
                        };
                        break;
                }
            }
        }

        public static bool ComplianceCheckVulnerability(Sensor sensor)
        {
            foreach (string WeakSensor in CopyWeakAgent1)
            {
                if (sensor.Name == WeakSensor)
                {
                    CopyWeakAgent1.Remove(sensor.Name);
                    SuccessGuesses.Add(sensor.Name);
                    return true;
                }
            }
            return false;
        }
        
        public static string PrintEqualyResalt()
        {
            string TxtEqualy = $"{SuccessGuesses.Count()}/{InitializationAgents.Agent1.Weaknes.Count()}";
            Console.WriteLine(TxtEqualy);
            return TxtEqualy;
        }

        public static bool CheckAgentStatus(string TxtEqualy)
        {
            if (TxtEqualy == new string(TxtEqualy.Reverse().ToArray()))
            {
                SuccessGuesses.Clear();
                return false; 
            }
            return true; 
        }
    }
}

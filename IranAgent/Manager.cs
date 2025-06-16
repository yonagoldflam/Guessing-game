using IranAgent.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IranAgent.Agents;

namespace IranAgent
{
    public static class Manager
    {
        public static List<string> CopyWeakAgent1 = new List<string>(InitializationAgents.Agent1.Weak);

        public static List<Sensor> AudioSensors = new List<Sensor>();
        public static List<Sensor> PulseSensors = new List<Sensor>();
        public static List<string> SuccessGuesses = new List<string>();


        public static Sensor GenarateNewSensor()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("enter sensor type. to exit enter: exit");
                switch (Console.ReadLine().ToLower())
                {
                    case "selular":
                        return new Selular();
                        break;
                    case "movement":
                        return new Movement();
                        break;
                    case "thermal":
                        return new Thermal();
                        break;

                    case "exit":
                        flag = false;
                        break;

                    default:
                        Console.WriteLine("the sensor is not found, plees try again");
                        break;
                }
            }
            return null;
        }

        public static void AddsToAppropriateList(Sensor sensor)
        {
            switch (sensor.Type)
            {
                case "audio":
                    AudioSensors.Add(sensor);
                    break;

                case "Pulse":
                    PulseSensors.Add(sensor);
                    break;
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

        public static bool Equality()
        {
            foreach (Sensor sensor in AudioSensors)
            {
                if (ComplianceCheckVulnerability(sensor))
                {
                    sensor.TrueActivate();
                }
            }
            foreach (Sensor sensor in PulseSensors)
            {
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
                }



            }
            string TxtEqualy = $"{SuccessGuesses.Count()}/{InitializationAgents.Agent1.Weak.Count()}";
            Console.WriteLine(TxtEqualy);
            if (TxtEqualy == new string(TxtEqualy.Reverse().ToArray()))
            {
                SuccessGuesses.Clear();
                return false; //for agent status
            }
            return true; //for agent status
            
        }
    }
}

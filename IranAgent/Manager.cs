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

        public static List<Sensor> SensorsList = new List<Sensor>();
        public static int GuessingTimes = 0;

        public static void ActivateChooseSensors()
        {
            foreach (Sensor sensor in SensorsList)
            {
                sensor.Activate();
            }
        }

        public static Sensor GenarateNewSensor(string type)
        {
            switch (type.ToLower())
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

                default:
                    return null;
            }

        }

        public static bool ComplianceCheckVulnerability(Sensor sensor)
        {
            foreach (string WeakSensor in CopyWeakAgent1)
            {
                if (sensor.HistoryActivate>0 && sensor.Type == WeakSensor)
                {
                    CopyWeakAgent1.Remove(WeakSensor);
                    return true;
                }
            }
            return false;
        }

        public static string Equality()
        {
            foreach (Sensor sensor in SensorsList)
            {
                if (ComplianceCheckVulnerability(sensor))
                    GuessingTimes++;
            }

            return $"{GuessingTimes}/{InitializationAgents.Agent1.Weak.Count()}";
        }

        public static bool CheckDone(string TxtEqualy)
        {
            return TxtEqualy == new string(TxtEqualy.Reverse().ToArray());
        }

    }
}

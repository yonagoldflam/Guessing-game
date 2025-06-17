using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IranAgent.Sensors;

namespace IranAgent.Factory
{
    public static class SensorsFactory
    {
        public static List<Sensor> Sensors = new List<Sensor>();
        public static Sensor GanarateSensorInstance(string sensorName)
        {
            Sensor Exist = ContainsSensorName(sensorName);
            if (Exist != null)
                return Exist;
                
            switch (sensorName)
            {
                case "selular":
                    Sensor selular = new Selular();
                    Sensors.Add(selular);
                    return selular;
                    break;
                case "movement":
                    Sensor movement = new Movement();
                    Sensors.Add(movement);
                    return movement;
                    break;
                case "thermal":
                    Sensor thermal = new Thermal();
                    Sensors.Add(thermal);
                    return thermal;
                    break;
                default:
                    return null;
            }               
            
           
        }

        public static Sensor ContainsSensorName(string sensorName)
        {
            foreach (Sensor sensor in Sensors)
            {
                if (sensor.Name == sensorName)
                    return sensor;
            }
            return null;
        }
    }
}

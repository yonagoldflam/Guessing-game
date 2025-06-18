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
            Sensor sensor = ContainsSensorName(sensorName);
            if (sensor != null)
                return sensor;
                
            switch (sensorName)
            {
                case "selular":
                    sensor = new Selular();                                      
                    break;
                case "movement":
                    sensor = new Movement();
                    break;
                case "thermal":
                    sensor = new Thermal();
                    break;
                default:
                    return null;
            }
            Sensors.Add(sensor);
            return sensor;                     
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

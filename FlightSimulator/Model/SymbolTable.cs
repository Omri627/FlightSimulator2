using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;
using System.ComponentModel;

namespace FlightSimulator.Model
{
    public class SymbolTable : INotifyPropertyChanged
    {
        public static readonly string LONGITUDE_DEG = "/position/longitude-deg";
        public static readonly string LATITUDE_DEG = "/position/latitude-deg";
        public static readonly string INDICATED_SPEED = "/instrumentation/airspeed-indicator/indicated-speed-kt";
        public static readonly string INDICATED_ALTITUDE_ALTIMETER = "/instrumentation/altimeter/indicated-altitude-ft";
        public static readonly string PRESSURE_ALT_ALTIMETER = "/instrumentation/altimeter/pressure-alt-ft";
        public static readonly string INDICATED_PITCH_DEG = "/instrumentation/attitude-indicator/indicated-pitch-deg";
        public static readonly string INDICATED_ROLL_DEG = "/instrumentation/attitude-indicator/indicated-roll-deg";
        public static readonly string INTERNAL_PITCH_DEG = "/instrumentation/attitude-indicator/internal-pitch-deg";
        public static readonly string INTERNAL_ROLL_DEG = "/instrumentation/attitude-indicator/internal-roll-deg";
        public static readonly string INDICATED_ALTITUDE_DEG = "/instrumentation/encoder/indicated-altitude-ft";
        public static readonly string PRESSURE_ALT_ENCODER = "/instrumentation/encoder/pressure-alt-ft";
        public static readonly string INDICATED_ALTITUDE_GPS = "/instrumentation/gps/indicated-altitude-ft";
        public static readonly string INDICATED_GROUND_SPEED_GPS = "/instrumentation/gps/indicated-ground-speed-kt";
        public static readonly string INDICATED_VERTICAL_SPEED_GPS = "/instrumentation/gps/indicated-vertical-speed";
        public static readonly string INDICATED_HEADING_DEG_INDECATOR = "/instrumentation/heading-indicator/indicated-heading-deg";
        public static readonly string INDICATED_HEADING_DEG_COMPASS = "/instrumentation/magnetic-compass/indicated-heading-deg";
        public static readonly string INDICATED_SLIP_SKID = "/instrumentation/slip-skid-ball/indicated-slip-skid";
        public static readonly string INDICATED_TURN_RATE = "/instrumentation/turn-indicator/indicated-turn-rate";
        public static readonly string INDICATED_SPEED_FPM = "/instrumentation/vertical-speed-indicator/indicated-speed-fpm";
        public static readonly string AILERON = "/controls/flight/aileron";
        public static readonly string ALEVATOR = "/controls/flight/elevator";
        public static readonly string RUDDER = "/controls/flight/rudder";
        public static readonly string FLAPS = "/controls/flight/flaps";
        public static readonly string THROTTLE = "/controls/engines/current-engine/throttle";
        public static readonly string RPM = "/engines/engine/rpm";
        private OrderedDictionary table;
        public event PropertyChangedEventHandler PropertyChanged;
        #region Singleton
        private static SymbolTable instance = null;
        public static SymbolTable Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SymbolTable();
                }
                return instance;
            }
        }
        #endregion
        /**
         * constuctor - all keys are added with 0 as value
         * */
        private SymbolTable()
        {
            table = new OrderedDictionary
            {
                { LONGITUDE_DEG, 0.0 },
                { LATITUDE_DEG, 0.0 },
                { INDICATED_SPEED, 0.0 },
                { INDICATED_ALTITUDE_ALTIMETER, 0.0 },
                { PRESSURE_ALT_ALTIMETER, 0.0 },
                { INDICATED_PITCH_DEG, 0.0 },
                { INDICATED_ROLL_DEG, 0.0 },
                { INTERNAL_PITCH_DEG, 0.0 },
                { INDICATED_ALTITUDE_DEG, 0.0 },
                { PRESSURE_ALT_ENCODER, 0.0 },
                { INDICATED_ALTITUDE_GPS, 0.0 },
                { INDICATED_GROUND_SPEED_GPS, 0.0 },
                { INDICATED_VERTICAL_SPEED_GPS, 0.0 },
                { INDICATED_HEADING_DEG_INDECATOR, 0.0 },
                { INDICATED_HEADING_DEG_COMPASS, 0.0 },
                { INDICATED_SLIP_SKID, 0.0 },
                { INDICATED_TURN_RATE, 0.0 },
                { INDICATED_SPEED_FPM, 0.0 },
                { AILERON, 0.0 },
                { ALEVATOR, 0.0 },
                { RUDDER, 0.0 },
                { FLAPS, 0.0 },
                { THROTTLE, 0.0 },
                { RPM, 0.0 }
            };
        }
        /**
         * indexer to add and get the values from existing keys
         **/
        public double this[string key]
        {
            get
            {
                double value;
                if (table.Contains(key))
                {
                    value = (double)table[key];
                    return value;
                }
                else
                {
                    throw new KeyNotFoundException("Key= " + key + " is not found.");
                }
            }

            set
            {
                if (table.Contains(key))
                {
                    table[key] = value;
                }
                else
                {
                    Console.WriteLine("Key= " + key + " is not found.");
                }
            }
        }
        /**
         * update each value that separate by comma in the data string and add it to the Ordered dictonary 
         **/
        public void UpdateData(string data)
        {
            Queue<double> queue = SplitData(data);
            int queueCount = queue.Count;
            for (int i = 0; i < table.Count; ++i)
            {
                if (i < queueCount)
                {//insert the element only if they exist also in the queue
                    if ((double)table[i] != queue.Peek())
                    {
                        table[i] = queue.Dequeue();
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(GetProperty(i)));
                    }
                }
                else
                    break;
            }
        }
        /**
         * split the data from the string that separate by commas, and return a quque of doubles 
         * */
        private Queue<double> SplitData(string data)
        {
            string[] values = data.Split(',');
            Queue<double> valuesQueue = new Queue<double>();
            foreach (string s in values)
            {
                valuesQueue.Enqueue(double.Parse(s));
            }
            return valuesQueue;
        }
        private string GetProperty(int index)
        {
            switch (index)
            {
                case 0: return "Aileron";
                case 1: return "Elevator";
                case 2: return "Rudder";
                case 3: return "Throttle";
                default: return string.Empty;
            }
        } 
    }
}

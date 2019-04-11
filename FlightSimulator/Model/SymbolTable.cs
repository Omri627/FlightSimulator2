using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{

    class SymbolTable
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

    }
}

using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    public class ApplicationSettingsModel : ISettingsModel
    {
        #region Singleton
        /* m_Instance contains the single instance of application settings model
         * if no instance created then m_Instance is null */
        private static ISettingsModel m_Instance = null;
        /** 
         *  Instance is static property which provides a mechanism to
         *  receive the instance of application settings model
         **/
        public static ISettingsModel Instance
        {
            get
            {
                /* if there is no instance exist, create new instance */
                if(m_Instance == null)
                {
                    m_Instance = new ApplicationSettingsModel();
                }
                return m_Instance;
            }
        }
        #endregion
        /**
         *  FlightServerIP Property provides flexible mechanism to set and get
         *  the ip of info flight server
         **/
        public string FlightServerIP
        {
            get { return Properties.Settings.Default.FlightServerIP; }
            set { Properties.Settings.Default.FlightServerIP = value; }
        }
        /**
        *  FlightServerIP Property provides flexible mechanism to set and get
        *  the port of commands flight server
        **/
        public int FlightCommandPort
        {
            get { return Properties.Settings.Default.FlightCommandPort; }
            set { Properties.Settings.Default.FlightCommandPort = value; }
        }
        /**
        *  FlightInfoPort Property provides flexible mechanism to set and get
        *  the port of commands flight server
        **/
        public int FlightInfoPort
        {
            get { return Properties.Settings.Default.FlightInfoPort; }
            set { Properties.Settings.Default.FlightInfoPort = value; }
        }
        /**
         * save the settings of connection in data storage
         **/ 
        public void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }
        /**
         * reload the settings of connections
         **/
        public void ReloadSettings()
        {
            Properties.Settings.Default.Reload();
        }
    }
}

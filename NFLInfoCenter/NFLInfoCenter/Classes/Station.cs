using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;

namespace NFLInfoCenter.Classes
{
    class Station
    {
        private System.Windows.Forms.Form commingFrom;
        private string stationKey = "StationName";

        private DysonDB dyson;
        /// <summary>
        /// Helps with mapping of the hostname to a station name through a preload stationname-hostname map.
        /// Mainly working in the printing label features of PreReceiving and Receiving.
        /// </summary>
        /// <param name="commingFrom"></param>
        public Station(System.Windows.Forms.Form commingFrom)
        {
            this.commingFrom = commingFrom;
            /*Setting host name we class is called*/
            setHostName();
            MsgTypes.printme(MsgTypes.msg_success, "hostname set " + this.hostname, this.commingFrom);

            /*Instantiating query functions of Flelxink/ELP Dyson database*/
            dyson = new DysonDB(commingFrom);

            /*Setting object station name*/
            if (IsStationNameSet())
            {
                this.name = GetStationName();
            }
            else
            {
                CreateStationKey("");
            }
        }

        public string hostname { get; set; }
        public string name { get; set; }

        public void setHostName()
        {
            this.hostname = Dns.GetHostName();
        }

        public void UpdateStationName(string name)
        {
            try
            {
                System.Configuration.Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
               settings[stationKey].Value =  name;
               configFile.Save(ConfigurationSaveMode.Modified);

                MsgTypes.printme(MsgTypes.msg_success, "Station name updated: " + GetStationName(), commingFrom);
            }
            catch (ConfigurationErrorsException)
            {
                MsgTypes.printme(MsgTypes.msg_failure, "Error writing app settings.", commingFrom);
            }
        }
        public void CreateStationKey(string name)
        {
            try
            {
                System.Configuration.Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                settings.Add(stationKey, name);
                configFile.Save(ConfigurationSaveMode.Modified);

                MsgTypes.printme(MsgTypes.msg_success, "Station name updated: " + GetStationName(), commingFrom);
            }
            catch (ConfigurationErrorsException)
            {
                MsgTypes.printme(MsgTypes.msg_failure, "Error writing app settings.", commingFrom);
            }
        }



        private string GetStationName()
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[stationKey].Value == null)
                {
                    return "";
                }
                else
                {
                    return settings[stationKey].Value;
                }
            }
            catch (ConfigurationErrorsException)
            {
                MsgTypes.printme(MsgTypes.msg_failure, "Error writing app settings.", commingFrom);
                return "";
            }
        }

        private bool IsStationNameSet()
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[stationKey].Value == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MsgTypes.printme(MsgTypes.msg_failure, "Error writing app settings.", commingFrom);
                return false;
            }
        }
    
        
    }

    
}

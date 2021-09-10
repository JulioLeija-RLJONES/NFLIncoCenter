using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace NFLInfoCenter.Classes
{
    class Station
    {
        private System.Windows.Forms.Form commingFrom;

        private DysonDB dyson;
        /// <summary>
        /// Helps with mapping of the hostname to a station name through a preload stationname-hostname map.
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
            setName();
        }

        public string hostname { get; set; }
        public string name { get; set; }

        public void setHostName()
        {
            this.hostname = Dns.GetHostName();
        }
        public void setName()
        {
            this.name = dyson.getStationName(this.hostname);
            MsgTypes.printme(MsgTypes.msg_success, "hostname: " + this.hostname + " name: " + this.name,commingFrom);
        }
        
    }

    
}

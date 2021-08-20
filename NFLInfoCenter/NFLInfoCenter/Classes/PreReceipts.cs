using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLInfoCenter.Classes
{
    class PreReceipts
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public List<string> Url { get; set; }
        public string TrackingNumber { get; set; }
        public int Pallets { get; set; }
        public int Boxes { get; set; }
        public string CreatedOn { get; set; }
        public string Employee { get; set; }
        public string Channel { get; set; }
        public int Item { get; set; }
        public string identifier = "pre";


        public int Count()
        {
            return this.Pallets + this.Boxes;
        }
        
        public override string ToString()
        {
            return this.Id + " > " + this.OrderNumber;
        }
        


    }
}

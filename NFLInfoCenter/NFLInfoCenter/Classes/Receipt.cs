using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLInfoCenter.Classes
{
    class Receipt
    {

        public int Id { get; set; }
        public string Sku { get; set; }
        public string SerialNumber { get; set; }
        public string RMANumber { get; set; }
        public string Family { get; set; }
        public List<string> Url { get; set; }
        public string fileName { get; set; }
        public int Qty { get; set; }
        public string Tote { get; set; }
        public string COO { get; set; }
        public string channel { get; set; }
        public string disposition { get; set; }
        public string employee { get; set; }
        public string scanTime { get; set; }
        public string station { get; set; }
        public string identifier = "re";


        public override string ToString()
        {
            return "id: " + this.Id + " sn: " + this.SerialNumber + " sku: " + this.Sku;
        }

        /// <summary>
        /// Checks if the receipt is Serialized or Non Serialized.
        /// </summary>
        /// <returns>True if receipt is serialized, False otherwise.</returns>
        public bool IsSerialized()
        {
            if (this.SerialNumber != "")
                return true;
            return false;
        }
        /// <summary>
        /// Checks the value of the station field of the receipt.
        /// </summary>
        /// <returns>True if station field has a value, False otherwise.</returns>
        public bool HasStation()
        {
            if (this.station != "")
                return true;
            return false;
        }




           
    }
}

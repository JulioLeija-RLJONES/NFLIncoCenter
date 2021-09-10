using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Deployment.Application;


namespace NFLInfoCenter.Classes
{
    class msftDB : SqlHelper
    {
        private System.Windows.Forms.Form commingFrom;
        public msftDB(System.Windows.Forms.Form commingFrom) : base("microsoft")
        {
            this.commingFrom = commingFrom;
        }
        /// <summary>
        /// Queries MSFT flexlink database and pulls the receipts of the given stationName.
        /// </summary>
        /// <param name="stationName"></param>
        /// <returns>The total receipts found for stationName in the current hour.</returns>
        public int getStationReceiptsCount(string stationName)
        {
            int count = 0;
            string sql = Queries.getQuery("msft_getStationReceiptsCount");
            sql = string.Format(sql, stationName);
            Console.WriteLine("*************** formated query *******");
            Console.WriteLine(sql);
            Console.WriteLine("*************** formated query *******");
            var rows = ExecuteReader(sql);
            Console.WriteLine("total rows obtained: " + rows.Count);
            count = rows.Count;
            return count;
        }
        /// <summary>
        /// Queries msft flexlink database and pulls all active station names.
        /// </summary>
        /// <returns>An array of strings containing all active workstation names.</returns>
        public string[] getActiveStations()
        {
            List<string> list = new List<string>();
            string sql = Queries.getQuery("msft_getActiveStations");
            var rows = ExecuteReader(sql);

            Console.WriteLine("*************** formated query *******" );
            Console.WriteLine(sql);
            Console.WriteLine("*************** formated query *******" );
            Console.WriteLine("total rows obtained: " + rows.Count);

            foreach(var data in rows)
            {
                var match = list.FirstOrDefault(stringToCheck => stringToCheck == data.FieldValues[0].ToString());

                if (match == null)
                {
                    list.Add(data.FieldValues[0].ToString());
                    Console.WriteLine("adding new station to list:" + data.FieldValues[0].ToString());
                }
            }
            return list.ToArray();
        }


}
}

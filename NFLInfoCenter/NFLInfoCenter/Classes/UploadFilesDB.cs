using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Deployment.Application;
using System.IO;


namespace NFLInfoCenter.Classes
{
    class UploadFilesDB : SqlHelper
    {
        /// <summary>
        /// Class handles high level SQL queries of Images and Files uploaded to flexlink.
        /// </summary>
        public UploadFilesDB()
          : base(ApplicationDeployment.IsNetworkDeployed ? "ProductionDatabase" : "DebugDatabase"){}

        /// <summary>
        /// Queries dyson flexlink database and pulls receipt data of the row matching the serial number
        /// provided.
        /// </summary>
        /// <param name="serialNmber"></param>
        /// <returns>A Receipt object containing data of the serial number.</returns>
        public Receipt getReceiptData(string serialNumber)
        {
            Receipt unit;
           

            string sql = getQuery("getdata");
            sql = string.Format(sql, serialNumber);
            Console.WriteLine("query formated: " + sql);
            var rows = ExecuteReader(sql);

            if (rows.Count>0)
            {
                var data = rows[0];


                unit = new Receipt()
                {
                    Id = Convert.ToInt32(data.FieldValues[0]),
                    SerialNumber = data.FieldValues[1].ToString(),
                    RMANumber = data.FieldValues[2].ToString(),
                };

                List<string> lst = new List<string>();

                foreach(var row in rows)
                {
                    Console.WriteLine("url : " + row.FieldValues[3]);
                    lst.Add(row.FieldValues[3].ToString());
                }
                unit.Url = lst;


            }
            else
            {
                unit = new Receipt();
                Console.WriteLine("empty unit created");

            }

            return unit;
        }
        /// <summary>
        /// Queries dyson flexlink database and pulls data of PreReceipt matching the order number
        /// provided.
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns>A PreReceipt object containing incoming data of the order number.</returns>
        public PreReceipts getPreReceiptData(string orderNumber)
        {
            PreReceipts prereciept;
            string sql = getQuery("dyson_getUploadedFiles");
            sql = string.Format(sql, orderNumber);
            Console.WriteLine("query formated: " + sql);
            var rows = ExecuteReader(sql);

            if (rows.Count > 0)
            {
                var data = rows[0];
                prereciept = new PreReceipts()
                {
                    Id = Convert.ToInt32(data.FieldValues[0]),
                    OrderNumber = data.FieldValues[2].ToString(),
                };
                List<string> lst = new List<string>();
                foreach (var row in rows)
                {
                    Console.WriteLine("url : " + row.FieldValues[3]);
                    lst.Add(row.FieldValues[3].ToString());
                }
                prereciept.Url = lst;
            }
            else
            {
                prereciept = new PreReceipts();
                Console.WriteLine("empty prereceipt created");
            }
                return prereciept;
        }
        /// <summary>
        /// Queries dyson flexlink database and pulls all receipts generated during the current day.
        /// </summary>
        /// <returns>The List of Receipts performed during the current day.</returns>
        public async Task<List<Receipt>> getPlayList()
        {
            List<Receipt> playList = new List<Receipt>();
            Receipt unit;
            string sql = getQuery("playlist");
            string today = DateTime.Now.Date.ToString("yyyy/MM/dd");
            string tomorrow = DateTime.Now.Date.AddDays(1).ToString("yyyy/MM/dd");
            Console.WriteLine("date range: " + today.ToString() + " - " + tomorrow.ToString());
            sql = string.Format(sql, today, tomorrow);
            Console.WriteLine("query for playlist:");
            Console.WriteLine(sql);
            var data = await ExecuteReaderAsync(sql);

            if (data.Count > 0)
            {
                foreach (var row in data)
                {
                    List<string> lst = new List<string>();
                    lst.Add(row.FieldValues[3].ToString());

                    unit = new Receipt()
                    {
                        Id = Convert.ToInt32(row.FieldValues[0]),
                        SerialNumber = row.FieldValues[1].ToString(),
                        RMANumber = row.FieldValues[2].ToString(),
                        Url = lst,
                        fileName = row.FieldValues[5].ToString()
                    };
                    playList.Add(unit);
                }
            }
                return playList;
        }
        /// <summary>
        /// Gets a predefined SQL statement from a project file located in Queries folder.
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The SQL statement stored in the file named with name value.</returns>
        public string getQuery(string name)
        {
            //Console.WriteLine("query name: " + name);
            string path = System.Windows.Forms.Application.ExecutablePath;
            path = path.Replace("NFLInfoCenter.exe", "");

            //string[] files = Directory.GetFiles(Directory.GetCurrentDirectory()+"\\Queries\\");
            string[] files = Directory.GetFiles(path+"\\Queries\\");
            string sql = "";

            foreach (string file in files)
            {
                Console.WriteLine("file name: " + file.ToString());
                if (file.Contains(name))
                {
                    sql = System.IO.File.ReadAllText(file);
                }
            }
            if (sql == "")
            {
                Console.WriteLine("faiules >> no query obtained");
            }
            else
            {
                //Console.WriteLine("query obtained");
            }
            Console.WriteLine(sql);

            return sql;
        }

    }
}


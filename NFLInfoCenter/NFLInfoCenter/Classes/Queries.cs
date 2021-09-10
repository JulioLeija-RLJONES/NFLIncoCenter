using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace NFLInfoCenter.Classes
{
    public static class Queries
    {

        /// <summary>
        /// Receives a name representing the file name containing the desired query statement.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A SQL statement.</returns>
        public static string getQuery(string name)
        {            
            string path = AppContext.BaseDirectory;
            path = path.Replace("NFLInfoCenter.exe", "");
            string[] files = Directory.GetFiles(path + "\\Queries\\");
            string sql = "";
            foreach (string file in files)
            {
                if (Path.GetFileName(file) == name + ".txt" )
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
                Console.WriteLine("query obtained");
            }
            return sql;
        }
    }
}

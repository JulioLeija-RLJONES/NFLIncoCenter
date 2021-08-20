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

        public static string getQuery(string name)
        {
            //Console.WriteLine("query name: " + name);
            //string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Queries\\");
            //string path = System.Windows.Forms.Application.ExecutablePath;
            string path = AppContext.BaseDirectory;
            path = path.Replace("NFLInfoCenter.exe", "");

            string[] files = Directory.GetFiles(path + "\\Queries\\");
            string sql = "";

            foreach (string file in files)
            {
                //Console.WriteLine("file name: " + file.ToString());
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
            //Console.WriteLine(sql);

            return sql;
        }
    }
}

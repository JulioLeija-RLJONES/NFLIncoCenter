using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NFLInfoCenter.Forms;

namespace NFLInfoCenter
{
    static class Program
    {
       

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FrmMenu main_menu_X = new FrmMenu();
            try
            {
                Application.Run(main_menu_X);
            }
            catch(System.Reflection.TargetInvocationException Ex)
            {
                
                
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NFLInfoCenter.Classes
{
    public static class Tips
    {
        public static void customizeToolTip(ToolTip tip)
        {
            tip.OwnerDraw = true;
            tip.InitialDelay = 5000;
            tip.ShowAlways = true;
            tip.BackColor = Color.Black;
            tip.ForeColor = Color.Lime;
        }

   

    }

}

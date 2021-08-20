using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NFLInfoCenter.Classes;
using System.Diagnostics;

namespace NFLInfoCenter.Forms
{
    public partial class FrmCloseMenu : Form
    {
        private Form commingFrom;
        private Form main;
        private bool closeFlag = false;
        public FrmCloseMenu(Form main, Form commingFrom)
        {
            InitializeComponent();

            this.commingFrom = commingFrom;
            this.main = main;
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            commingFrom.Close();
            //main.Show();
            System.Threading.Thread.Sleep(1000);
            MsgTypes.printme(MsgTypes.msg_success, "closing nfl infocenter.", this);
            killAllSubProcesses();
            System.Threading.Thread.Sleep(1000);
            main.Close();

            this.Close();
        }

        private void FrmCloseMenu_Load(object sender, EventArgs e)
        {
            setLocation();
            MsgTypes.printme(MsgTypes.msg_success, "closing tool", this);
            timer1.Enabled = true;
        }

        #region Cosmetics
        private void setLocation()
        {
            if (Taskbar.Position.ToString() == "Bottom")
            {
                this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - (int)(this.Width * 1.01),
                                          (int)(Taskbar.CurrentBounds.Y - this.Height * 1.05));
            }
            else
            {

            }
        }
        #endregion

        private void FrmCloseMenu_MouseLeave(object sender, EventArgs e)
        {
            closeFlag = true;
        }

        private void buttonQuit_MouseEnter(object sender, EventArgs e)
        {
            closeFlag = false;
        }

        private void prompt_MouseEnter(object sender, EventArgs e)
        {
            closeFlag = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (closeFlag)
            {
                this.Close();
            }
        }
        public void killAllSubProcesses()
        {
            Process[] processes = Process.GetProcessesByName("NFLInfoCenter");
            for (int i = 0; i < processes.Length; i++)
            {
                processes[i].Kill();
            }
        }
    }
}

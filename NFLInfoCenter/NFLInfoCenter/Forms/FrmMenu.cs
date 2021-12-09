using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using NFLInfoCenter.Classes;

namespace NFLInfoCenter.Forms
{
    public partial class FrmMenu : Form
    {
        private int msg_success = 1;
        private int msg_failure = 2;
        private int msg_nottype = 0;

        FrmReceiptsPrinter printer;

        private Color backColor = Color.FromArgb(39, 47, 63);
        private Color highlightControl = Color.FromArgb(83, 130, 173);

        public FrmMenu()
        {
            InitializeComponent();
        }

        #region FormSetup
        public void initForm()
        {
            this.BackColor = backColor;
            prompt.BackColor = backColor;

            setupToolTips();

            if (!isDebugMode() && System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                labelVersion.Text = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            else
            {
                labelVersion.Text = versionKeeper();
            }

        }
        public void setupToolTips()
        {
            Tips.customizeToolTip(tip);

            tip.SetToolTip(this.pictureBoxCounterAccess, "Click to open Piece Count by workstation tool");
            tip.SetToolTip(this.pictureBoxGalleryAccess, "Click to open Picture Capture tool");
            tip.SetToolTip(this.dataViewAccess, "Click to open serial and order traceability tool");
        }
        public string versionKeeper()
        {
            string[] version = { "version: dec 9 2021",
                                "Solution modified to remove db_elptest in azure dependency",
                                "Adding StandAlone Installer project to solution",
                                "Adding manual versioning keeper."};
            return version[0];
        }

        #endregion

        #region Logic
        public bool isToolOpen()
        {
            Process[] processes= Process.GetProcessesByName("NFLInfoCenter");
           for(int i = 0;i< processes.Length; i++)
            {
                Console.WriteLine("process " + processes[i]);
            }
            if (processes.Length > 1)
            {
                return true;
            }
            return false;
        }
        public void AddApplicationToStartup()
        {
            if (!checkIfStartupSet())
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.SetValue("NFLInfoCenter", "\"" + Application.ExecutablePath + "\"");
                }
                Console.WriteLine("application added to startup");
                MsgTypes.printme(MsgTypes.msg_success, "application added to startup", this);
            }
        }
        public bool checkIfStartupSet()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {


                //MsgTypes.printme(msg_success, "startup  value: " + key.GetValue("NFLInfoCenter").ToString(),this);
                if (key.GetValue("NFLInfoCenter") ==  null)
                {
                    return false;
                }
                else
                {
                    MsgTypes.printme(msg_success, "application startup set.", this);
                    return true;
                }
            }
        }
        public bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                {
                    MsgTypes.printme(MsgTypes.msg_success, "connection available", this);
                    return true;
                }
            }
            catch
            {
               MsgTypes.printme(MsgTypes.msg_success, "no connection", this);
                return false;
            }
        }
        #endregion


        #region Actions
        public async Task<int> ActionLaunchPrinter()
        {
            int startattempts = 0;
            if (CheckForInternetConnection())
            {
                MsgTypes.printme(MsgTypes.msg_success, "loading printer tool...", this);
                printer = new FrmReceiptsPrinter(this);

                if (printer.IsDisposed)
                {
                    startattempts += 1;
                    MsgTypes.printme(MsgTypes.msg_failure, "Printer did not start and was disposed. attempts: " + startattempts, this);
                    //timer1.Enabled = true;
                    await ActionLaunchPrinter();
                    return 1;
                }
                else
                {
                    MsgTypes.printme(MsgTypes.msg_success, "printer tool up and running.", this);
                    return 1;
                }
            }
            else
            {
                timer1.Enabled = true;
                MsgTypes.printme(msg_failure, "initiating reconnection...", this);
                return 1;
            }
        }
        #endregion


        #region Controls
        private void dataViewAccess_MouseClick(object sender, MouseEventArgs e)
        {
            MsgTypes.printme(MsgTypes.msg_success, "loading data view tool...",this);
            FrmDataView dataview = new FrmDataView(this);
            dataview.Show();
            this.Hide();
        }
        private void pictureBoxGalleryAccess_Click(object sender, EventArgs e)
        {
            MsgTypes.printme(MsgTypes.msg_success, "loading gallery tool...",this);
            FrmPictureViewer viewer = new FrmPictureViewer(this);
            viewer.Show();
            this.Hide();
        }
        private void pictureBoxCounterAccess_Click(object sender, EventArgs e)
        {
            MsgTypes.printme(MsgTypes.msg_success, "loading counter tool...",this);
            FrmReceiptCount counter = new FrmReceiptCount(this);
            counter.Show();
            this.Hide();

        }
        private void pictureBoxPrinterView_Click(object sender, EventArgs e)
        {
            MsgTypes.printme(MsgTypes.msg_success, "loading printer tool...", this);
            
            printer.Show();

            this.WindowState = FormWindowState.Minimized;

        }
        private void pictureBoxCounterAccess_MouseEnter(object sender, EventArgs e)
        {
            hoverButtonEffect(pictureBoxCounterAccess);
        }
        private void pictureBoxCounterAccess_MouseLeave(object sender, EventArgs e)
        {
            resetButtonColor(pictureBoxCounterAccess);
        }
        private void dataViewAccess_MouseEnter(object sender, EventArgs e)
        {
            hoverButtonEffect(dataViewAccess);
        }
        private void dataViewAccess_MouseLeave(object sender, EventArgs e)
        {
            resetButtonColor(dataViewAccess);
        }
        private void pictureBoxGalleryAccess_MouseEnter(object sender, EventArgs e)
        {
            hoverButtonEffect(pictureBoxGalleryAccess);
        }
        private void pictureBoxGalleryAccess_MouseLeave(object sender, EventArgs e)
        {
            resetButtonColor(pictureBoxGalleryAccess);
        }
        private void pictureBoxPrinterView_MouseEnter(object sender, EventArgs e)
        {
            CustomEffects effects = new CustomEffects(this);

            effects.hoverButtonEffect(this, pictureBoxPrinterView,
                                     new Bitmap(Properties.Resources.printerImage),
                                     new Bitmap(Properties.Resources.printerImageHighlighted));

        }
        private void pictureBoxPrinterView_MouseLeave(object sender, EventArgs e)
        {
            CustomEffects effects = new CustomEffects(this);

            effects.resetButtonColor(this,
                                    pictureBoxPrinterView,
                                    new Bitmap(Properties.Resources.printerImage),
                                    new Bitmap(Properties.Resources.printerImageHighlighted)); 
        }
        private async void AppMenu_Load(object sender, EventArgs e)
        {
            
            MsgTypes.printme(MsgTypes.msg_success,"application executable path: " + Application.ExecutablePath,this);
            initForm();
            resizeLayout();
            setLocation();


            printme(msg_nottype, "welcome to nfl info center.");
         

            AddApplicationToStartup();


            if (isToolOpen())
            {
                //MessageBox.Show("the tool is already open");
                this.Dispose();
            }
            else
            {
                await ActionLaunchPrinter();
            }
            //MsgTypes.printme(msg_failure, "is debug mode: " + isDebugMode().ToString(), this);

            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            Console.WriteLine("*****************************************************");
            Console.WriteLine("*****************************************************");
            foreach (var section in configFile.Sections)
            {
                Console.WriteLine("section " + section.ToString());
                
            }
            


        }
        private void AppMenu_Resize(object sender, EventArgs e)
        {
            resizeLayout();
        }
        private void resizeLayout()
        {
           

            
        }
        private void setLocation()
        {
            if(Taskbar.Position.ToString() == "Bottom")
            {
                this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - (int)(this.Width*1.01),
                                          (int)(Taskbar.CurrentBounds.Y - this.Height*1.05));
            }
            else
            {

            }
        }
        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void buttonMaximize_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }
        #endregion


        #region Debug
       public bool isDebugMode()
        {
            if (Debugger.IsAttached)
            {
                // Since there is a debugger attached, assume we are running from the IDE
                return true;
            }
            else
            {
                return false;
                // Assume we aren't running from the IDE
            }
        }
        public void printme(int messageType, string message)
        {
            switch (messageType)
            {
                case 0:
                    prompt.AppendText(message + System.Environment.NewLine);
                    prompt.ScrollToCaret();
                    break;
                case 1:
                    prompt.AppendText("success >> " + message + System.Environment.NewLine);
                    prompt.ScrollToCaret();
                    break;
                case 2:
                    prompt.AppendText("failure >> " + message + System.Environment.NewLine);
                    prompt.ScrollToCaret();
                    break;
            }
        }
      
        #endregion

  
        #region Cosmetics
        private void hoverButtonEffect(PictureBox sender)
        {
            switch (sender.Name)
            {
                case "pictureBoxGalleryAccess":
                    sender.Image = Properties.Resources.galleryImageButtonHighlighted;
                    break;
                case "pictureBoxBackToMenu":
                    sender.Image = Properties.Resources.backToMainImageHighlighted;
                    break;
                case "dataViewAccess":
                        sender.Image = Properties.Resources.dataViewHighlighted;
                    break;
                case "pictureBoxCounterAccess":
                    sender.Image = Properties.Resources.counterImageHighlighted;
                    break;
                default:
                    break;
            }

        }
        private void resetButtonColor(PictureBox sender)
        {
            switch (sender.Name)
            {
                case "pictureBoxGalleryAccess":
                    sender.Image = Properties.Resources.galleryImageButton;
                    break;
                case "pictureBoxBackToMenu":
                    sender.Image = Properties.Resources.backToMainImage;
                    break;
                case "dataViewAccess":
                    sender.Image = Properties.Resources.dataView;
                    break;
                case "pictureBoxCounterAccess":
                    sender.Image = Properties.Resources.counterImage;
                    break;
                default:
                    break;
            }

        }





        #endregion

        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel  = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckForInternetConnection())
            {
                MsgTypes.printme(MsgTypes.msg_success, "loading printer tool...", this);
                printer = new FrmReceiptsPrinter(this);
                timer1.Enabled = false;
            }
            else
            {
                MsgTypes.printme(MsgTypes.msg_failure, " still no network " + DateTime.Now.ToString(),this );
            }
        }
    }
}

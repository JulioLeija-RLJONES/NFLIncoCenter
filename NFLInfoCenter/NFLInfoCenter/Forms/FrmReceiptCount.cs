using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using NFLInfoCenter.Classes;

namespace NFLInfoCenter.Forms
{
    public partial class FrmReceiptCount : Form
    {

        private Form commingFrom;
        private DysonDB dataDB;
        private msftDB mdataDB;
        private int updateInterval = 10000;
        private int largeWidth = 1200;
        private int smallWidth = 780;

        //string version = "V1";                            // new release    
        //string version = "V2.0 June 18 2021";             // fixing errors
        //string version = "V2.1 July 15 2021";               // adding PreReceipts Count
        string version = "V2.2 July 27 2021";               // adding msft workstations

        
        SqlConnection flconn = new SqlConnection("Data Source=Airprodsec.database.windows.net;Initial Catalog=Flexlink_Air;User ID=ELPreader;Password=h@2e)$YG");
        SqlCommand flcommand;
        SqlDataReader flreader;
        Color transparent = Color.FromArgb(0, 0, 0);

        string[] dysonStations;
        string[] mstfStations;

        string hostname;


        public FrmReceiptCount(Form commingFrom)
        {
            InitializeComponent();
            this.commingFrom = commingFrom;

            dataDB = new DysonDB(this);
            dataDB.Open();

            mdataDB = new msftDB(this);
            mdataDB.Open();
        }

        private void FrmReceiptCount_Load(object sender, EventArgs e)
        {
            //Setting hostname
            this.hostname = Dns.GetHostName();
            Console.WriteLine("-host name set: " + this.hostname);

            //Creating command
            flcommand = flconn.CreateCommand();


            //Initializing workstations list.
            //dysonStations = new string[11] {"PRERECEIVING", "REC-ST1", "REC-ST2", "REC-ST3", "REC-ST4", "REC-ST5", "REC-ST6", "REC-ST7", "REC-ST8", "REC-ST9", "REC-ST10" };
            dysonStations = dataDB.getActiveStations();
            mstfStations = mdataDB.getActiveStations();

            initForm();

            MsgTypes.printme(MsgTypes.msg_success, "counter loaded", this);

        }
        public void initForm()
        {
            //Setting window location
            this.Location = new Point((int)(Screen.PrimaryScreen.Bounds.Width - this.Width),
                                      (int)(Screen.PrimaryScreen.Bounds.Height - this.Height * 1.7));

            //dyson workstations load default
            radioButtonDyson.Checked = true;

            panel_main.BackColor = transparent;

            labelVersion.Text = version;

            //Setting interval of time to update count
            timer1.Interval = updateInterval;
        }


        #region Logic
        /// <summary>
        /// Detects if user changes radio buttons to select between MSFT and Dyson options.
        /// </summary>
        private void projectChanged()
        {
            if (radioButtonDyson.Checked)
            {
                setStationsList(dysonStations);
            }
            else
            {
                setStationsList(mstfStations);
            }
        }
        /// <summary>
        /// Updates UI message with station current count.
        /// </summary>
        private void updateCount()
        {
            try
            {
                if (getStationName() == "")
                {
                    label_ReceiptsCount.Text = "SELECT WORKSTATION";
                }
                else
                {
                    if (getStationName().Substring(0, 3) == "REC")
                    {
                        MsgTypes.printme(MsgTypes.msg_success, "dyson station:" + getStationName(),this);
                        label_ReceiptsCount.Text = getStationName(true) + " RECEIPTS: " + dyson_getReceiptsCount(getStationName());
                    }
                    else if (getStationName().Contains("Stat"))
                    {
                        label_ReceiptsCount.Text = getStationName(true) + " RECEIPTS: " + msft_getReceiptsCount(getStationName());
                    }
                    else if(getStationName().Contains("PRERECEIVING"))
                    {
                        label_ReceiptsCount.Text = "PRECEIPTS: " + dyson_getReceiptsCount(getStationName());
                    }
                    else
                    {
                        label_ReceiptsCount.Text = "Select project";
                    }
                }
            }
            catch(Exception ex)
            {
                MsgTypes.printme(MsgTypes.msg_failure, ex.Message, this);
            }
        }
        #endregion

        #region Database
        /// <summary>
        /// Calls query consult from dyson flexlink database to pull reciepts from matching stationName and performed during the current hour.
        /// </summary>
        /// <param name="stationName"></param>
        /// <returns>The quantity of receipts performed by stationName during the current hour.</returns>
        private int dyson_getReceiptsCount(string stationName)
        {
            return dataDB.getStationReceiptsCount(stationName);
        }
        /// <summary>
        /// Calls query consult from msft flexlink database to pull reciepts from matching stationName and performed during the current hour.
        /// </summary>
        /// <param name="stationName"></param>
        /// <returns>The quantity of receipts performed by stationName during the current hour.</returns>
        private int msft_getReceiptsCount(string stationName)
        {
            return mdataDB.getStationReceiptsCount(stationName);
        }
        #endregion


        #region Controls
        private void radioButtonDyson_CheckedChanged(object sender, EventArgs e)
        {
            projectChanged();
        }
        private void radioButtonMSFT_CheckedChanged(object sender, EventArgs e)
        {
            projectChanged();
        }
        private void setStationsList(string[] stationsList)
        {
            comboBoxStation.Items.Clear();
            foreach(string station in stationsList)
            {
                comboBoxStation.Items.Add(station);
            }
        }
        private string getStationName(bool shortname = false)
        {
            string name = comboBoxStation.Text;

            if (name.Contains("Mr.") && shortname)
            {
                name = name.Split(' ')[2];
            }
            return name;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lbl_Test.Text = DateTime.Now.ToString();
                updateCount();
            }catch(Exception ex)
            {
                Console.WriteLine("Error ID 3: timerTick.");
            }
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            lbl_Test.Text = DateTime.Now.ToString();
            updateCount();
        }
        private void pictureBoxBackToMenu_MouseEnter(object sender, EventArgs e)
        {
            CustomEffects effects = new CustomEffects(this);

            effects.hoverButtonEffect(this,
                                    pictureBoxBackToMenu, 
                                    Properties.Resources.backToMainImage.ToString(),
                                    Properties.Resources.backToMainImageHighlighted.ToString());
        }
        private void pictureBoxBackToMenu_MouseLeave(object sender, EventArgs e)
        {
            CustomEffects effects = new CustomEffects(this);

            effects.resetButtonColor(this,
                                    pictureBoxBackToMenu,
                                    Properties.Resources.backToMainImage.ToString(),
                                    Properties.Resources.backToMainImageHighlighted.ToString());
        }
        private void pictureBoxBackToMenu_Click(object sender, EventArgs e)
        {
            commingFrom.Show();
            this.Close();
        }
        #endregion

    }
}

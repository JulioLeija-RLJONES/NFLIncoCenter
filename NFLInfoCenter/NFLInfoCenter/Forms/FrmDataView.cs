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

namespace NFLInfoCenter.Forms
{
    public partial class FrmDataView : Form
    {
        private Form commingFrom;
        private DysonDB dataDB;
        
        public FrmDataView(Form commingFrom)
        {
            InitializeComponent();
            this.commingFrom = commingFrom;
            dataDB = new DysonDB(this);
            dataDB.Open();
            
        }

        #region FormSetup
        public void initForm()
        {
            resizeLayout();

            textBoxSerialNumber.Select();

            setupToolTips();
        }
        public void setupToolTips()
        {
            Tips.customizeToolTip(tip);

            tip.SetToolTip(this.textBoxSerialNumber, "Scan serial number or type and press ENTER");
            tip.SetToolTip(this.textBoxOrderNumber, "Scan order number or type and press ENTER");
        }
        public void initDatagrids()
        {
            initPreLoadDatagrid();
        }
        public void initPreLoadDatagrid()
        {
            DataGridView dv = dataGridViewPreLoadData;
            initDefaultsDataGrid(dv);
            dv.ColumnCount = 2;
            dv.Columns[0].Name = "Pre Loaded Order";
            dv.Columns[1].Name = "Pre Loaded SN";

            foreach (DataGridViewColumn col in dv.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            labelPreloadPanel.Visible = true;
        }
        public void initOrderPreLoadDatagrid()
        {
            DataGridView dv = dataGridViewOrderPreloadData;
            initDefaultsDataGrid(dv);
            dv.ColumnCount = 4;
            dv.Columns[0].Name = "Pre Loaded Order";
            dv.Columns[1].Name = "Pre Loaded SN";
            dv.Columns[2].Name = "Pre Received On";
            dv.Columns[3].Name = "Serial PreLoaded";

            foreach (DataGridViewColumn col in dv.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            labelOrderPrealoaded.Visible = true;
        }
        public void initReceipDatagrid()
        {
            DataGridView dv = dataGridViewReceiptedData;

            initDefaultsDataGrid(dv);
            dv.ColumnCount = 6;
            dv.Columns[0].Name = "Receipted In";
            dv.Columns[1].Name = "Receipted In";
            dv.Columns[2].Name = "Scanned Date";
            dv.Columns[3].Name = "Receipt Status";
            dv.Columns[4].Name = "Tracking";
            dv.Columns[5].Name = "Putaway In";

            foreach (DataGridViewColumn col in dv.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            labelReceiptPanel.Visible = true;
        }
        public void initDefaultsDataGrid(DataGridView dv)
        {
            dv.EnableHeadersVisualStyles = false;
            dv.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dv.DefaultCellStyle.BackColor = Color.Black;
            dv.DefaultCellStyle.ForeColor = SystemColors.ButtonFace;
            dv.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ButtonFace;
            dv.DefaultCellStyle.Font = new Font("Times New Roman", 8, FontStyle.Regular);
            dv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Rows.Clear();
        }

        #endregion


        #region Logic
        private void searchSNAction()
        {
            string sn = getSN();
            List<string[]> preloadedData = dataDB.getPreLoadedData(sn);
            List<string[]> receiptedData = dataDB.getReceiptedData(sn);

            if (preloadedData.Count > 0)
            {
                //init datagrid
                initPreLoadDatagrid();
                foreach (string[] item in preloadedData)
                {
                    dataGridViewPreLoadData.Rows.Insert(0, item);
                }
            }
            else
            {
                MsgTypes.printme(MsgTypes.msg_failure, "there is no preloaded data available for sn = " + sn + ", please verify the number",this);
            }
            
            if (receiptedData.Count > 0)
            {
                //init datagrid
                initReceipDatagrid();
                foreach (string[] item in receiptedData)
                {
                    dataGridViewReceiptedData.Rows.Insert(0, item);
                }
            }
            else
            {
                MsgTypes.printme(MsgTypes.msg_failure, "there is no record of sn = " + sn + ", at receiving",this);
            }
            textBoxSerialNumber.SelectAll();
        }
        private void searchOrderAction()
        {
            string rma = getOrder();
            List<string[]> preloadedData = dataDB.getOrderPreLoadedData(rma);
           
            if (preloadedData.Count > 0)
            {
                //init datagrid
                initOrderPreLoadDatagrid();
                foreach (string[] item in preloadedData)
                {
                    dataGridViewOrderPreloadData.Rows.Insert(0, item);
                }
            }
            else
            {
                MsgTypes.printme(MsgTypes.msg_failure, "there is no preloaded data available for order = " + rma + ", please verify the number", this);
            }   
            textBoxOrderNumber.SelectAll();
        }
        #endregion

        #region Controls
        private string getSN()
        {
            return textBoxSerialNumber.Text;
        }
        private string getOrder()
        {
            return textBoxOrderNumber.Text;
        }
        private void FrmDataView_Load(object sender, EventArgs e)
        {
            initForm();
            MsgTypes.printme(MsgTypes.msg_success, "this tool is pulling data straigh from flexlink database", this, prompt);
        }
        private void pictureBoxBackToMenu_MouseEnter(object sender, EventArgs e)
        {
            hoverButtonEffect(pictureBoxBackToMenu);
        }
        private void pictureBoxBackToMenu_MouseLeave(object sender, EventArgs e)
        {
            resetButtonColor(pictureBoxBackToMenu);
        }
        private void pictureBoxBackToMenu_Click(object sender, EventArgs e)
        {
            commingFrom.Show();
            this.Close();
        }
        private void FrmDataView_FormClosing(object sender, FormClosingEventArgs e)
        {
            commingFrom.Show();
            dataDB.Dispose();
        }
        private void FrmDataView_Resize(object sender, EventArgs e)
        {
            resizeLayout();
        }
        private void textBoxSerialNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchSNAction();
            }
        }
        private void textBoxOrderNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchOrderAction();
            }
        }
        private void dataGridViewReceiptData_MouseUp(object sender, MouseEventArgs e)
        {
            dataGridViewPreLoadData.Refresh();
        }
        private void tip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }
     
        #endregion



        #region Cosmetics
        private void resizeLayout()
        {
            prompt.Width = this.Bounds.Width;
            prompt.Location = new Point(0, this.Height - prompt.Height-40);

            panelOptions.Location = new Point(this.Bounds.Width - (int)(panelOptions.Width*1.2),2);

            
        }
        private void resizeDatagrids()
        {
           
        }
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
                default:
                    break;
            }

        }




        #endregion

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NFLInfoCenter.Classes;
using System.Configuration;
using System.Threading;



namespace NFLInfoCenter.Forms
{
    public partial class FrmPictureViewer : Form
    {
        UploadFilesDB DB = new UploadFilesDB();
        Form commingFrom;
        Thread safetyThread;
        List<Receipt> playList = new List<Receipt>();
        int index;
        
      
    
        public FrmPictureViewer(Form commingFrom)
        {
            InitializeComponent();
            this.commingFrom = commingFrom;
        }

        private void FrmPictureViewer_Load(object sender, EventArgs e)
        {
            if (Networking.IsConnectedToInternet())
            {
                MsgTypes.printme(MsgTypes.msg_failure, "network connection available.", this);
                DB.Open();
            }
            else
            {
                MsgTypes.printme(MsgTypes.msg_failure, "no network connection available, working offline.", this);
            }
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            int i = 0;
            foreach (ConnectionStringSettings setting in settings)
            {
                Console.WriteLine(i + " - " + setting.Name);
                i++;
            }
            tableLayoutPanelPictureList.ColumnStyles[1].Width = 0;
            tableLayoutPanelPictureList.ColumnStyles[2].Width = 0;
            setPlayListAsync();
            resizePictures();
            timer2.Enabled = true;
            timer2.Start();
        }

     

        #region Debug
        public void printme(int messageType, string message)
        {
            switch (messageType)
            {
                case 1:
                    prompt.AppendText("Success >> " + message + System.Environment.NewLine);
                    prompt.ScrollToCaret();
                    break;
                case 2:
                    prompt.AppendText("Failure >> " + message + System.Environment.NewLine);
                    prompt.ScrollToCaret();
                    break;
            }
        }
        #endregion

        #region Logic
        private void getPicturesAction()
        {
            string crtieria = getSerachCriteria();
            if (crtieria == "")
            {
                printme(2, "please enter search criteria.");
                
                return;
            }
            var receipt = DB.getReceiptData(getSerachCriteria());
            if (receipt.Url != null)
            {
                printme(1, receipt.SerialNumber);
                printme(1, "photos in receipt: " + receipt.Url.Count);
                if (receipt.Url.Count > 30)
                {
                    printme(1, "too many images. shorting to 30 max.");
                    for(int i= 0; i <= 30; i++)
                    {
                        Gallery photo = new Gallery(this);
                        photo.Url = receipt.Url[i].ToString();
                        photo.location = new Point(0, 0);
                        photo.createPhotoAsync(this.flowLayoutPanelGallery);
                    }
                }
                else
                {
                    foreach (string url in receipt.Url)
                    {
                        Gallery photo = new Gallery(this);
                        photo.Url = url;
                        photo.location = new Point(0, 0);
                        photo.createPhotoAsync(this.flowLayoutPanelGallery);
                    }
                }
                
            }
            else
            {
                printme(2, "no receipts recovered");
            }
        }
        private void getPDFAction()
        {
            string crtieria = getSerachCriteria();
            if (crtieria == "")
            {
                printme(2, "please enter search criteria.");
                return;
            }

            var prereceipt = DB.getPreReceiptData(getSerachCriteria());
            if(prereceipt.Url != null)
            {

                printme(1, "prereceipt " + prereceipt.OrderNumber);

                foreach(string url in prereceipt.Url)
                {
                    if (url.Contains("pdf"))
                    {
                        Gallery pdf = new Gallery(this);
                        pdf.Url = url;
                        printme(1, "url: " + url);
                        pdf.createPDFViewAsync(flowLayoutPanelGallery);
                    }
                    else
                    {
                        Gallery photo = new Gallery(this);
                        photo.Url = url;
                        photo.location = new Point(0, 0);
                        photo.createPhotoAsync(this.flowLayoutPanelGallery);
                    }
                   
                }

                resizePictures();
            }
            else 
            {
                printme(2, "no prereceiving files found with given criteria:" + crtieria);
            }
        }
        private void updateGalleryAction()
        {
            flowLayoutPanelGallery.Controls.Clear();
            getPDFAction();
            getPicturesAction();
            textBoxCriteria.Select();
            textBoxCriteria.SelectAll();
        }
        private void resetForm()
        {
            flowLayoutPanelGallery.Controls.Clear();
        }
        private  async void setPlayListAsync()
        {
            if (!Networking.IsConnectedToInternet())
            {
                MsgTypes.printme(MsgTypes.msg_failure, "network is not available",this);
                return;
            }
            safetyThread = new Thread(new ThreadStart(safetyCheck));
            safetyThread.Start();
            try
            {
                if ((await DB.getPlayList()).Count > playList.Count)
                {
                    playList = await DB.getPlayList();
                    listViewReceipts.Clear();
                    foreach (Receipt receipt in playList)
                    {
                        listViewReceipts.Items.Add(receipt.fileName);
                    }
                }
                else
                {
                    setPlayListAsync();
                }
                safetyThread.Abort();
            }
            catch(Exception e)
            {
                setPlayListAsync();
            }
        }
        private async void initRoller()
        {
            if (listViewReceipts.Items.Count > 0)
            {
                for(int i= 1; i <= 10; i++  ) 
                {
                    Gallery photo = new Gallery(this);
                    photo.Url = playList[i].Url[0];
                    Console.WriteLine("url >> "+photo.Url);
                    photo.location = new Point(0, 0);
                    photo.createPhotoAsync(this.flowLayoutPanelGallery);
                    index = i;
                    this.Refresh();
                }
                printme(1, "roller initiated. index at: " + index.ToString());
            }
            else
            {
                MsgTypes.printme(MsgTypes.msg_failure, "There are no images today to display.", this);
            }
        }
        private async void rollPictures()
        {
            index += 1;

            if(index >= playList.Count)
            {
                index = 0;
            }

            Console.WriteLine(">>> current index = " + index);

            flowLayoutPanelGallery.Controls[0].Dispose();

            Gallery photo = new Gallery(this);
            photo.Url = playList[index].Url[0];
            printme(1, "Showing file: " + playList[index].Url[0]);
            printme(1, "url: " + playList[index].Url[0]);
            photo.location = new Point(0, 0);
            photo.createPhotoAsync(this.flowLayoutPanelGallery);

            listViewReceipts.SelectedItems.Clear();
            listViewReceipts.Items[index].Selected = true;
            listViewReceipts.EnsureVisible(index);
            listViewReceipts.Select();
            
            printme(1, "moving index:" + index.ToString());
        }
        private void safetyCheck()
        {
            while (true) ;
        }
        private List<string> getListImages(string folder)
        {
            List<string> list = new List<string>();
            list.AddRange(Directory.GetFiles(folder,"*.bmp"));
            list.AddRange(Directory.GetFiles(folder,"*.jpg"));
            list.AddRange(Directory.GetFiles(folder,"*.png"));
            return list;
        }
        private void loadImageList(List<string> list,ListView view)
        {
            foreach(string item in list)
            {
                view.Items.Add(Path.GetFileName(item));
            }
            labelLoadedImages.Text = "Loaded images: " + view.Items.Count;
        }
        private string nextImage()
        {
            if (listViewImages.Items.Count == 0)
            {
                MsgTypes.printme(MsgTypes.msg_failure, "no items loaded in list.", this);
                return "";
            }
            Gallery photo = new Gallery(this);
            string next;
            int cindex;

            if (listViewImages.SelectedItems.Count == 0)
            {
                cindex = 0;
            }
            else
            {
                cindex = listViewImages.SelectedItems[0].Index;
                listViewImages.SelectedItems.Clear();
                cindex += 1;
            }

            next = listViewImages.Items[cindex].Text;

            photo.Url = getImageFolder() + next;
            //MsgTypes.printme(MsgTypes.msg_success, "loading image: " + photo.Url, this);


            photo.location = new Point(0, 0);
            photo.createPhotoAsync(this.flowLayoutPanelGallery, 1.95);

            listViewImages.Items[cindex].Selected = true;
            return next;
        }
        private bool classifyImageAsync(string name, string imageclass)
        {
            string tagsFileName = getImageFolder() + "tags.tsv";
            File.AppendAllText(tagsFileName, name + "  " + imageclass + Environment.NewLine);
            return true;
        }
        


        #endregion



        #region Controls
        private void buttonNext_Click(object sender, EventArgs e)
        {
            nextImage();
          
        }
        private string getImageFolder()
        {
            return textBoxPath.Text + "\\";
        }
        private void buttonLoadImages_Click(object sender, EventArgs e)
        {
            if(getImageFolder() == "")
            {
                MsgTypes.printme(MsgTypes.msg_failure, "Set images folder.",this);
            }
            else
            {
                loadImageList(getListImages(getImageFolder()),listViewImages);
                nextImage();
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            rollPictures();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if(!checkBoxInspectionMode.Checked)
                setPlayListAsync();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            updateGalleryAction();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                updateGalleryAction();
            }
        }
        public string getSerachCriteria()
        {
            return textBoxCriteria.Text;
        }
        public void resizePictures()
        {
            foreach (Control c in flowLayoutPanelGallery.Controls)
            {
                if (checkBoxInspectionMode.Checked)
                {

                }
                else
                {
                    c.Size = new Size(Convert.ToInt32(flowLayoutPanelGallery.Width * 0.48),
                        Convert.ToInt32(flowLayoutPanelGallery.Width * 0.48 * .6));
                }
            }
        }
        private void FrmPictureViewer_Resize(object sender, EventArgs e)
        {
            resizePictures();
        }
        private void checkBoxPlayMode_CheckedChanged(object sender, EventArgs e)
        {
            flowLayoutPanelGallery.Controls.Clear();
            initRoller();

            if (checkBoxPlayMode.Checked)
            {
                
                labelPlayMode.Text = "ON";
                labelPlayMode.ForeColor = Color.Lime;
                tableLayoutPanelPictureList.ColumnStyles[2].Width = 400;

                timer1.Enabled = true;
                timer1.Start();

            }
            else
            {
                timer1.Stop();
                resetForm();
                labelPlayMode.Text = "OFF";
                labelPlayMode.ForeColor = Color.DarkGray;
                tableLayoutPanelPictureList.ColumnStyles[2].Width = 0;
                
            }
            resizePictures();
            resizePictures();
            listViewReceipts.Refresh();
        }
        private void checkBoxInspectionMode_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxInspectionMode.Checked)
            {
                tableLayoutPanelPictureList.ColumnStyles[1].Width = 400;
            }
            else
            {
                resetForm();
                tableLayoutPanelPictureList.ColumnStyles[1].Width = 0;
            }
        }
        private void pictureBoxBackToMenu_Click(object sender, EventArgs e)
        {
            printme(1, "checking for unfinished tasks.");
            if (safetyThread.IsAlive)
            {
                printme(1, "waiting for unfinished tasks to complete...");
                System.Threading.Thread.Sleep(3000);
            }
            commingFrom.Show();
            this.Close();
        }
        private void FrmPictureViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            commingFrom.Show();
            
        }
        private void pictureBoxBackToMenu_MouseEnter(object sender, EventArgs e)
        {
            hoverButtonEffect(pictureBoxBackToMenu);
        }
        private void pictureBoxBackToMenu_MouseLeave(object sender, EventArgs e)
        {
            resetButtonColor(pictureBoxBackToMenu);
        }
        private void buttonClassA_Click(object sender, EventArgs e)
        {
            string theclass = "A";
            classifyImageAsync(listViewImages.SelectedItems[0].Text, theclass);
            nextImage();
        }
        private void buttonClassB_Click(object sender, EventArgs e)
        {
            string theclass = "B";
            classifyImageAsync(listViewImages.SelectedItems[0].Text, theclass);
            nextImage();
        }
        private void buttonClassC_Click(object sender, EventArgs e)
        {
            string theclass = "C";
            classifyImageAsync(listViewImages.SelectedItems[0].Text, theclass);
            nextImage();
        }
        private void buttonClassD_Click(object sender, EventArgs e)
        {
            string theclass = "D";
            classifyImageAsync(listViewImages.SelectedItems[0].Text, theclass);
            nextImage();
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
                    sender.Image = Properties.Resources.galleryImageButtonHighlighted;
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


        #region Network
      

        #endregion


    }
}

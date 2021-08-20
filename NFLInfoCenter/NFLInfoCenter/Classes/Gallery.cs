using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using PdfiumViewer;
using System.IO;

namespace NFLInfoCenter.Classes
{
    class Gallery : Form
    {
        Form commingFrom;
        public Gallery(Form commingFrom)
        {
            this.commingFrom = commingFrom;
        }

        public PictureBox frame { get; set; }
        public Point location { get; set; }
        public PdfViewer pdf { get; set; }
        public string Url { get; set; }
        public int size { get; set; }


        public void createPhoto(FlowLayoutPanel parent)
        {
            frame = new PictureBox();

            frame.Size = new Size(Convert.ToInt32(parent.Width*.48),Convert.ToInt32(parent.Width*0.48*.6));

            frame.SizeMode = PictureBoxSizeMode.StretchImage;

            frame.Load(this.Url);

            frame.Location = this.location;

            frame.Visible = true;

            parent.Controls.Add(frame);
        }


        public async void createPhotoAsync(FlowLayoutPanel parent, double multiplyer = 1)
        {
            frame = new PictureBox();
            frame.Image = Properties.Resources.loading2;
            frame.Size = new Size(Convert.ToInt32(parent.Width * .48* multiplyer), Convert.ToInt32(parent.Width * 0.48 * .6* multiplyer));
            frame.LoadAsync(this.Url);
            frame.Location = this.location;
            frame.Visible = true;
            frame.SizeMode = PictureBoxSizeMode.StretchImage;
            frame.Refresh();
            parent.Controls.Add(frame);
            parent.ScrollControlIntoView(frame);
        }

        public async void createPDFViewAsync(FlowLayoutPanel parent)
        {
            pdf = new PdfViewer();
            string url = this.Url;
            var wc = new System.Net.WebClient();
            var stream = new MemoryStream(wc.DownloadData(url));
            PdfDocument document = PdfDocument.Load(stream);
            pdf.Document = document;
            int width = 85;
            parent.Controls.Add(pdf);
            pdf.Size= new Size(width,Convert.ToInt32(width*1.29));
            
        }


    }
}

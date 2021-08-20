using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace NFLInfoCenter.Classes
{
    class CustomEffects
    {


        private System.Windows.Forms.Form commingFrom;
        public CustomEffects(System.Windows.Forms.Form commingFrom)
        {
            this.commingFrom = commingFrom;
        }

        public void hoverButtonEffect(System.Windows.Forms.Form form,
                                       System.Windows.Forms.PictureBox sender,
                                       string normalPictureName, string higlightedPictureName)
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
        public void hoverButtonEffect(System.Windows.Forms.Form form,
                                  System.Windows.Forms.PictureBox sender,
                                  Bitmap normalPicture, Bitmap higlightedPicture)
        {
            sender.Image = higlightedPicture;
        }
        public void resetButtonColor(System.Windows.Forms.Form form,
                                       System.Windows.Forms.PictureBox sender,
                                       string normalPictureName, string higlightedPictureName)
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
        public void resetButtonColor(System.Windows.Forms.Form form,
                                    System.Windows.Forms.PictureBox sender,
                                    Bitmap normalPicture, Bitmap higlightedPicture)
        {
            sender.Image = normalPicture;
        }
    }

}

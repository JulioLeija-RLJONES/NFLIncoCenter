using System.Drawing;

namespace NFLInfoCenter.Classes
{
    /*
     *  This class is driving the hover effect over the menu picture boxes
     */
    class CustomEffects
    {
        private System.Windows.Forms.Form commingFrom;
        public CustomEffects(System.Windows.Forms.Form commingFrom)
        {
            this.commingFrom = commingFrom;
        }
        /*
         * Functionality: changes backgroud image of picturebox control given the control name
         * Note 1: uses image resoureces imported into the project.
         */
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
        /*
         * Functionality: changes backgroud image of picturebox control given the control name
         * Note 1: uses image resources imported into the project.
         */
        public void hoverButtonEffect(System.Windows.Forms.Form form,
                                  System.Windows.Forms.PictureBox sender,
                                  Bitmap normalPicture, Bitmap higlightedPicture)
        {
            sender.Image = higlightedPicture;
        }
        /*
         * Functionality: resets the control to idle
         * Note 1: uses image resources imported into the project
        */
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
        /*
         * Functionality: resets the control to idle
         * Note 1: uses image resources imported into the project
        */
        public void resetButtonColor(System.Windows.Forms.Form form,
                                    System.Windows.Forms.PictureBox sender,
                                    Bitmap normalPicture, Bitmap higlightedPicture)
        {
            sender.Image = normalPicture;
        }
    }

}

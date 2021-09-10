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

        /// <summary>
        /// Changes backgroud image of picturebox control given the control name
        /// <br/><br/> 
        /// Remarks:
        /// <br/> 
        /// <list type="number">
        /// <item>Uses images imported into the project.</item>
        /// </list>
        /// </summary>
        /// <param name="form"></param>
        /// <param name="sender"></param>
        /// <param name="normalPictureName"></param>
        /// <param name="higlightedPictureName"></param>
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
        /// <summary>
        /// changes background image of picturebox control given the control name
        /// Remarks:
        /// <br/> 
        /// <list type="number">
        /// <item>Uses images imported into the project.</item>
        /// </list>
        /// </summary>
        /// <param name="form"></param>
        /// <param name="sender"></param>
        /// <param name="normalPicture"></param>
        /// <param name="higlightedPicture"></param>
        public void hoverButtonEffect(System.Windows.Forms.Form form,
                                  System.Windows.Forms.PictureBox sender,
                                  Bitmap normalPicture, Bitmap higlightedPicture)
        {
            sender.Image = higlightedPicture;
        }
        /*
         * Functionality: 
         * Note 1: uses image resources imported into the project
        */
        /// <summary>
        /// resets the control to idle
        /// Remarks:
        /// <br/> 
        /// <list type="number">
        /// <item>Uses images imported into the project.</item>
        /// </list>
        /// </summary>
        /// <param name="form"></param>
        /// <param name="sender"></param>
        /// <param name="normalPictureName"></param>
        /// <param name="higlightedPictureName"></param>
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
        /// <summary>
        ///  resets the control to idle
        /// Remarks:
        /// <br/> 
        /// <list type="number">
        /// <item>Uses images imported into the project.</item>
        /// </list>
        /// </summary>
        /// <param name="form"></param>
        /// <param name="sender"></param>
        /// <param name="normalPicture"></param>
        /// <param name="higlightedPicture"></param>
        public void resetButtonColor(System.Windows.Forms.Form form,
                                    System.Windows.Forms.PictureBox sender,
                                    Bitmap normalPicture, Bitmap higlightedPicture)
        {
            sender.Image = normalPicture;
        }
    }

}

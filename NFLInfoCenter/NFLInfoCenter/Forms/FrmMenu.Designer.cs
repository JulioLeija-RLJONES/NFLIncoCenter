namespace NFLInfoCenter.Forms
{
    partial class FrmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.prompt = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBoxPrinterView = new System.Windows.Forms.PictureBox();
            this.pictureBoxCounterAccess = new System.Windows.Forms.PictureBox();
            this.dataViewAccess = new System.Windows.Forms.PictureBox();
            this.pictureBoxGalleryAccess = new System.Windows.Forms.PictureBox();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonMaximize = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPrinterView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCounterAccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewAccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGalleryAccess)).BeginInit();
            this.SuspendLayout();
            // 
            // prompt
            // 
            this.prompt.BackColor = System.Drawing.Color.Black;
            this.prompt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.prompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prompt.ForeColor = System.Drawing.Color.Lime;
            this.prompt.Location = new System.Drawing.Point(17, 86);
            this.prompt.Name = "prompt";
            this.prompt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.prompt.Size = new System.Drawing.Size(403, 30);
            this.prompt.TabIndex = 6;
            this.prompt.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(314, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "NFL TOOLS";
            // 
            // tip
            // 
            this.tip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.tip_Draw);
            // 
            // pictureBoxPrinterView
            // 
            this.pictureBoxPrinterView.Image = global::NFLInfoCenter.Properties.Resources.printerImage;
            this.pictureBoxPrinterView.Location = new System.Drawing.Point(9, 10);
            this.pictureBoxPrinterView.Name = "pictureBoxPrinterView";
            this.pictureBoxPrinterView.Size = new System.Drawing.Size(70, 70);
            this.pictureBoxPrinterView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPrinterView.TabIndex = 10;
            this.pictureBoxPrinterView.TabStop = false;
            this.pictureBoxPrinterView.Click += new System.EventHandler(this.pictureBoxPrinterView_Click);
            this.pictureBoxPrinterView.MouseEnter += new System.EventHandler(this.pictureBoxPrinterView_MouseEnter);
            this.pictureBoxPrinterView.MouseLeave += new System.EventHandler(this.pictureBoxPrinterView_MouseLeave);
            // 
            // pictureBoxCounterAccess
            // 
            this.pictureBoxCounterAccess.Image = global::NFLInfoCenter.Properties.Resources.counterImage;
            this.pictureBoxCounterAccess.Location = new System.Drawing.Point(237, 10);
            this.pictureBoxCounterAccess.Name = "pictureBoxCounterAccess";
            this.pictureBoxCounterAccess.Size = new System.Drawing.Size(70, 70);
            this.pictureBoxCounterAccess.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCounterAccess.TabIndex = 8;
            this.pictureBoxCounterAccess.TabStop = false;
            this.pictureBoxCounterAccess.Click += new System.EventHandler(this.pictureBoxCounterAccess_Click);
            this.pictureBoxCounterAccess.MouseEnter += new System.EventHandler(this.pictureBoxCounterAccess_MouseEnter);
            this.pictureBoxCounterAccess.MouseLeave += new System.EventHandler(this.pictureBoxCounterAccess_MouseLeave);
            // 
            // dataViewAccess
            // 
            this.dataViewAccess.Image = global::NFLInfoCenter.Properties.Resources.dataView;
            this.dataViewAccess.Location = new System.Drawing.Point(161, 10);
            this.dataViewAccess.Name = "dataViewAccess";
            this.dataViewAccess.Size = new System.Drawing.Size(70, 70);
            this.dataViewAccess.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dataViewAccess.TabIndex = 7;
            this.dataViewAccess.TabStop = false;
            this.dataViewAccess.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataViewAccess_MouseClick);
            this.dataViewAccess.MouseEnter += new System.EventHandler(this.dataViewAccess_MouseEnter);
            this.dataViewAccess.MouseLeave += new System.EventHandler(this.dataViewAccess_MouseLeave);
            // 
            // pictureBoxGalleryAccess
            // 
            this.pictureBoxGalleryAccess.Image = global::NFLInfoCenter.Properties.Resources.galleryImageButton;
            this.pictureBoxGalleryAccess.Location = new System.Drawing.Point(85, 10);
            this.pictureBoxGalleryAccess.Name = "pictureBoxGalleryAccess";
            this.pictureBoxGalleryAccess.Size = new System.Drawing.Size(70, 70);
            this.pictureBoxGalleryAccess.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGalleryAccess.TabIndex = 5;
            this.pictureBoxGalleryAccess.TabStop = false;
            this.pictureBoxGalleryAccess.Click += new System.EventHandler(this.pictureBoxGalleryAccess_Click);
            this.pictureBoxGalleryAccess.MouseEnter += new System.EventHandler(this.pictureBoxGalleryAccess_MouseEnter);
            this.pictureBoxGalleryAccess.MouseLeave += new System.EventHandler(this.pictureBoxGalleryAccess_MouseLeave);
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.BackgroundImage = global::NFLInfoCenter.Properties.Resources.minimize_1;
            this.buttonMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMinimize.FlatAppearance.BorderSize = 0;
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.Location = new System.Drawing.Point(315, 10);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(49, 43);
            this.buttonMinimize.TabIndex = 4;
            this.buttonMinimize.UseVisualStyleBackColor = true;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackgroundImage = global::NFLInfoCenter.Properties.Resources.close_1;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(373, 10);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(49, 43);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonMaximize
            // 
            this.buttonMaximize.BackgroundImage = global::NFLInfoCenter.Properties.Resources.maximize;
            this.buttonMaximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMaximize.FlatAppearance.BorderSize = 0;
            this.buttonMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaximize.Location = new System.Drawing.Point(316, 59);
            this.buttonMaximize.Name = "buttonMaximize";
            this.buttonMaximize.Size = new System.Drawing.Size(49, 43);
            this.buttonMaximize.TabIndex = 2;
            this.buttonMaximize.UseVisualStyleBackColor = true;
            this.buttonMaximize.Visible = false;
            this.buttonMaximize.Click += new System.EventHandler(this.buttonMaximize_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelVersion.Location = new System.Drawing.Point(315, 73);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(64, 12);
            this.labelVersion.TabIndex = 11;
            this.labelVersion.Text = "NFL TOOLS";
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(434, 117);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.pictureBoxPrinterView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxCounterAccess);
            this.Controls.Add(this.dataViewAccess);
            this.Controls.Add(this.prompt);
            this.Controls.Add(this.pictureBoxGalleryAccess);
            this.Controls.Add(this.buttonMinimize);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonMaximize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMenu";
            this.Text = "NFL Info Center";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMenu_FormClosing);
            this.Load += new System.EventHandler(this.AppMenu_Load);
            this.Resize += new System.EventHandler(this.AppMenu_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPrinterView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCounterAccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewAccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGalleryAccess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonMaximize;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonMinimize;
        private System.Windows.Forms.PictureBox pictureBoxGalleryAccess;
        private System.Windows.Forms.RichTextBox prompt;
        private System.Windows.Forms.PictureBox dataViewAccess;
        private System.Windows.Forms.PictureBox pictureBoxCounterAccess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.PictureBox pictureBoxPrinterView;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelVersion;
    }
}
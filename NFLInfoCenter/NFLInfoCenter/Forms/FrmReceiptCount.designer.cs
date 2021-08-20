namespace NFLInfoCenter.Forms
{
    partial class FrmReceiptCount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReceiptCount));
            this.panel_main = new System.Windows.Forms.Panel();
            this.radioButtonDyson = new System.Windows.Forms.RadioButton();
            this.radioButtonMSFT = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxBackToMenu = new System.Windows.Forms.PictureBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.comboBoxStation = new System.Windows.Forms.ComboBox();
            this.lbl_Test = new System.Windows.Forms.Label();
            this.label_ReceiptsCount = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.prompt = new System.Windows.Forms.RichTextBox();
            this.panel_main.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackToMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_main
            // 
            this.panel_main.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel_main.Controls.Add(this.radioButtonDyson);
            this.panel_main.Controls.Add(this.radioButtonMSFT);
            this.panel_main.Controls.Add(this.panel1);
            this.panel_main.Controls.Add(this.labelVersion);
            this.panel_main.Controls.Add(this.comboBoxStation);
            this.panel_main.Controls.Add(this.lbl_Test);
            this.panel_main.Controls.Add(this.label_ReceiptsCount);
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(0, 0);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(779, 71);
            this.panel_main.TabIndex = 0;
            // 
            // radioButtonDyson
            // 
            this.radioButtonDyson.AutoSize = true;
            this.radioButtonDyson.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDyson.ForeColor = System.Drawing.Color.Orchid;
            this.radioButtonDyson.Location = new System.Drawing.Point(432, 47);
            this.radioButtonDyson.Name = "radioButtonDyson";
            this.radioButtonDyson.Size = new System.Drawing.Size(74, 21);
            this.radioButtonDyson.TabIndex = 10;
            this.radioButtonDyson.TabStop = true;
            this.radioButtonDyson.Text = "Dyson";
            this.radioButtonDyson.UseVisualStyleBackColor = true;
            this.radioButtonDyson.CheckedChanged += new System.EventHandler(this.radioButtonDyson_CheckedChanged);
            // 
            // radioButtonMSFT
            // 
            this.radioButtonMSFT.AutoSize = true;
            this.radioButtonMSFT.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonMSFT.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.radioButtonMSFT.Location = new System.Drawing.Point(356, 46);
            this.radioButtonMSFT.Name = "radioButtonMSFT";
            this.radioButtonMSFT.Size = new System.Drawing.Size(70, 21);
            this.radioButtonMSFT.TabIndex = 9;
            this.radioButtonMSFT.TabStop = true;
            this.radioButtonMSFT.Text = "MSFT";
            this.radioButtonMSFT.UseVisualStyleBackColor = true;
            this.radioButtonMSFT.CheckedChanged += new System.EventHandler(this.radioButtonMSFT_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBoxBackToMenu);
            this.panel1.Location = new System.Drawing.Point(698, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(78, 63);
            this.panel1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "go menu";
            // 
            // pictureBoxBackToMenu
            // 
            this.pictureBoxBackToMenu.Image = global::NFLInfoCenter.Properties.Resources.backToMainImage;
            this.pictureBoxBackToMenu.Location = new System.Drawing.Point(17, 4);
            this.pictureBoxBackToMenu.Name = "pictureBoxBackToMenu";
            this.pictureBoxBackToMenu.Size = new System.Drawing.Size(42, 36);
            this.pictureBoxBackToMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBackToMenu.TabIndex = 6;
            this.pictureBoxBackToMenu.TabStop = false;
            this.pictureBoxBackToMenu.Click += new System.EventHandler(this.pictureBoxBackToMenu_Click);
            this.pictureBoxBackToMenu.MouseEnter += new System.EventHandler(this.pictureBoxBackToMenu_MouseEnter);
            this.pictureBoxBackToMenu.MouseLeave += new System.EventHandler(this.pictureBoxBackToMenu_MouseLeave);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.ForeColor = System.Drawing.Color.LawnGreen;
            this.labelVersion.Location = new System.Drawing.Point(9, 50);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(69, 17);
            this.labelVersion.TabIndex = 3;
            this.labelVersion.Text = "VERSION";
            // 
            // comboBoxStation
            // 
            this.comboBoxStation.BackColor = System.Drawing.SystemColors.MenuText;
            this.comboBoxStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxStation.ForeColor = System.Drawing.Color.Lime;
            this.comboBoxStation.FormattingEnabled = true;
            this.comboBoxStation.Location = new System.Drawing.Point(521, 33);
            this.comboBoxStation.Name = "comboBoxStation";
            this.comboBoxStation.Size = new System.Drawing.Size(176, 24);
            this.comboBoxStation.TabIndex = 2;
            // 
            // lbl_Test
            // 
            this.lbl_Test.AutoSize = true;
            this.lbl_Test.ForeColor = System.Drawing.Color.LawnGreen;
            this.lbl_Test.Location = new System.Drawing.Point(518, 8);
            this.lbl_Test.Name = "lbl_Test";
            this.lbl_Test.Size = new System.Drawing.Size(130, 17);
            this.lbl_Test.TabIndex = 1;
            this.lbl_Test.Text = "FETCHING DATA...";
            // 
            // label_ReceiptsCount
            // 
            this.label_ReceiptsCount.AutoSize = true;
            this.label_ReceiptsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ReceiptsCount.ForeColor = System.Drawing.Color.LawnGreen;
            this.label_ReceiptsCount.Location = new System.Drawing.Point(4, 4);
            this.label_ReceiptsCount.Name = "label_ReceiptsCount";
            this.label_ReceiptsCount.Size = new System.Drawing.Size(374, 46);
            this.label_ReceiptsCount.TabIndex = 0;
            this.label_ReceiptsCount.Text = "FETCHING DATA...";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // prompt
            // 
            this.prompt.BackColor = System.Drawing.Color.Black;
            this.prompt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.prompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prompt.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.prompt.Location = new System.Drawing.Point(154, 45);
            this.prompt.Name = "prompt";
            this.prompt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.prompt.Size = new System.Drawing.Size(195, 34);
            this.prompt.TabIndex = 11;
            this.prompt.Text = "";
            this.prompt.Visible = false;
            // 
            // FrmReceiptCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 71);
            this.Controls.Add(this.prompt);
            this.Controls.Add(this.panel_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReceiptCount";
            this.Text = "FrmReceiptCount";
            this.Load += new System.EventHandler(this.FrmReceiptCount_Load);
            this.panel_main.ResumeLayout(false);
            this.panel_main.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackToMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Label label_ReceiptsCount;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_Test;
        private System.Windows.Forms.ComboBox comboBoxStation;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxBackToMenu;
        private System.Windows.Forms.RadioButton radioButtonDyson;
        private System.Windows.Forms.RadioButton radioButtonMSFT;
        private System.Windows.Forms.RichTextBox prompt;
    }
}
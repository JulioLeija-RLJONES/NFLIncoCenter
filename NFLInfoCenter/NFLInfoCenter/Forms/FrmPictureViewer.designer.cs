namespace NFLInfoCenter.Forms
{
    partial class FrmPictureViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPictureViewer));
            this.textBoxCriteria = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGetReceipt = new System.Windows.Forms.Button();
            this.prompt = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanelGallery = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxPlayMode = new System.Windows.Forms.CheckBox();
            this.labelPlayMode = new System.Windows.Forms.Label();
            this.checkBoxInspectionMode = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxBackToMenu = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanelPictureList = new System.Windows.Forms.TableLayoutPanel();
            this.listViewReceipts = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelLoadedImages = new System.Windows.Forms.Label();
            this.listViewImages = new System.Windows.Forms.ListView();
            this.buttonClassD = new System.Windows.Forms.Button();
            this.buttonClassC = new System.Windows.Forms.Button();
            this.buttonClassB = new System.Windows.Forms.Button();
            this.buttonClassA = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonLoadImages = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.buttonNext = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackToMenu)).BeginInit();
            this.tableLayoutPanelPictureList.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCriteria
            // 
            this.textBoxCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCriteria.Location = new System.Drawing.Point(254, 13);
            this.textBoxCriteria.Name = "textBoxCriteria";
            this.textBoxCriteria.Size = new System.Drawing.Size(358, 45);
            this.textBoxCriteria.TabIndex = 0;
            this.textBoxCriteria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search Criteria";
            // 
            // buttonGetReceipt
            // 
            this.buttonGetReceipt.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonGetReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGetReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGetReceipt.Location = new System.Drawing.Point(618, 13);
            this.buttonGetReceipt.Name = "buttonGetReceipt";
            this.buttonGetReceipt.Size = new System.Drawing.Size(179, 45);
            this.buttonGetReceipt.TabIndex = 2;
            this.buttonGetReceipt.Text = "Get Files";
            this.buttonGetReceipt.UseVisualStyleBackColor = false;
            this.buttonGetReceipt.Click += new System.EventHandler(this.button1_Click);
            // 
            // prompt
            // 
            this.prompt.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.prompt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.prompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prompt.ForeColor = System.Drawing.Color.Lime;
            this.prompt.Location = new System.Drawing.Point(3, 571);
            this.prompt.Name = "prompt";
            this.prompt.Size = new System.Drawing.Size(1359, 55);
            this.prompt.TabIndex = 3;
            this.prompt.Text = "";
            // 
            // flowLayoutPanelGallery
            // 
            this.flowLayoutPanelGallery.AutoScroll = true;
            this.flowLayoutPanelGallery.AutoScrollMinSize = new System.Drawing.Size(0, 1);
            this.flowLayoutPanelGallery.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelGallery.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanelGallery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelGallery.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelGallery.Name = "flowLayoutPanelGallery";
            this.flowLayoutPanelGallery.Size = new System.Drawing.Size(553, 478);
            this.flowLayoutPanelGallery.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.prompt, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelPictureList, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.88889F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1365, 635);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.textBoxCriteria);
            this.flowLayoutPanel1.Controls.Add(this.buttonGetReceipt);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxPlayMode);
            this.flowLayoutPanel1.Controls.Add(this.labelPlayMode);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxInspectionMode);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1359, 72);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // checkBoxPlayMode
            // 
            this.checkBoxPlayMode.AutoSize = true;
            this.checkBoxPlayMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPlayMode.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.checkBoxPlayMode.Location = new System.Drawing.Point(803, 13);
            this.checkBoxPlayMode.Name = "checkBoxPlayMode";
            this.checkBoxPlayMode.Padding = new System.Windows.Forms.Padding(20, 10, 0, 0);
            this.checkBoxPlayMode.Size = new System.Drawing.Size(156, 39);
            this.checkBoxPlayMode.TabIndex = 5;
            this.checkBoxPlayMode.Text = "Play Mode";
            this.checkBoxPlayMode.UseVisualStyleBackColor = true;
            this.checkBoxPlayMode.CheckedChanged += new System.EventHandler(this.checkBoxPlayMode_CheckedChanged);
            // 
            // labelPlayMode
            // 
            this.labelPlayMode.AutoSize = true;
            this.labelPlayMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayMode.ForeColor = System.Drawing.Color.DarkGray;
            this.labelPlayMode.Location = new System.Drawing.Point(965, 10);
            this.labelPlayMode.Name = "labelPlayMode";
            this.labelPlayMode.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.labelPlayMode.Size = new System.Drawing.Size(55, 40);
            this.labelPlayMode.TabIndex = 4;
            this.labelPlayMode.Text = "OFF";
            this.labelPlayMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxInspectionMode
            // 
            this.checkBoxInspectionMode.AutoSize = true;
            this.checkBoxInspectionMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxInspectionMode.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.checkBoxInspectionMode.Location = new System.Drawing.Point(1026, 13);
            this.checkBoxInspectionMode.Name = "checkBoxInspectionMode";
            this.checkBoxInspectionMode.Padding = new System.Windows.Forms.Padding(20, 10, 0, 0);
            this.checkBoxInspectionMode.Size = new System.Drawing.Size(153, 39);
            this.checkBoxInspectionMode.TabIndex = 8;
            this.checkBoxInspectionMode.Text = "Inspection";
            this.checkBoxInspectionMode.UseVisualStyleBackColor = true;
            this.checkBoxInspectionMode.CheckedChanged += new System.EventHandler(this.checkBoxInspectionMode_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBoxBackToMenu);
            this.panel1.Location = new System.Drawing.Point(1185, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(78, 63);
            this.panel1.TabIndex = 7;
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
            this.pictureBoxBackToMenu.Location = new System.Drawing.Point(16, 3);
            this.pictureBoxBackToMenu.Name = "pictureBoxBackToMenu";
            this.pictureBoxBackToMenu.Size = new System.Drawing.Size(42, 36);
            this.pictureBoxBackToMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBackToMenu.TabIndex = 6;
            this.pictureBoxBackToMenu.TabStop = false;
            this.pictureBoxBackToMenu.Click += new System.EventHandler(this.pictureBoxBackToMenu_Click);
            this.pictureBoxBackToMenu.MouseEnter += new System.EventHandler(this.pictureBoxBackToMenu_MouseEnter);
            this.pictureBoxBackToMenu.MouseLeave += new System.EventHandler(this.pictureBoxBackToMenu_MouseLeave);
            // 
            // tableLayoutPanelPictureList
            // 
            this.tableLayoutPanelPictureList.ColumnCount = 3;
            this.tableLayoutPanelPictureList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPictureList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanelPictureList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanelPictureList.Controls.Add(this.flowLayoutPanelGallery, 0, 0);
            this.tableLayoutPanelPictureList.Controls.Add(this.listViewReceipts, 2, 0);
            this.tableLayoutPanelPictureList.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanelPictureList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPictureList.Location = new System.Drawing.Point(3, 81);
            this.tableLayoutPanelPictureList.Name = "tableLayoutPanelPictureList";
            this.tableLayoutPanelPictureList.RowCount = 1;
            this.tableLayoutPanelPictureList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPictureList.Size = new System.Drawing.Size(1359, 484);
            this.tableLayoutPanelPictureList.TabIndex = 4;
            // 
            // listViewReceipts
            // 
            this.listViewReceipts.BackColor = System.Drawing.Color.Black;
            this.listViewReceipts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewReceipts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewReceipts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewReceipts.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.listViewReceipts.HideSelection = false;
            this.listViewReceipts.Location = new System.Drawing.Point(962, 3);
            this.listViewReceipts.Name = "listViewReceipts";
            this.listViewReceipts.Size = new System.Drawing.Size(394, 478);
            this.listViewReceipts.TabIndex = 0;
            this.listViewReceipts.UseCompatibleStateImageBehavior = false;
            this.listViewReceipts.View = System.Windows.Forms.View.List;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonNext);
            this.panel2.Controls.Add(this.labelLoadedImages);
            this.panel2.Controls.Add(this.listViewImages);
            this.panel2.Controls.Add(this.buttonClassD);
            this.panel2.Controls.Add(this.buttonClassC);
            this.panel2.Controls.Add(this.buttonClassB);
            this.panel2.Controls.Add(this.buttonClassA);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.buttonLoadImages);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBoxPath);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(562, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(394, 478);
            this.panel2.TabIndex = 5;
            // 
            // labelLoadedImages
            // 
            this.labelLoadedImages.AutoSize = true;
            this.labelLoadedImages.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelLoadedImages.Location = new System.Drawing.Point(4, 377);
            this.labelLoadedImages.Name = "labelLoadedImages";
            this.labelLoadedImages.Size = new System.Drawing.Size(109, 17);
            this.labelLoadedImages.TabIndex = 10;
            this.labelLoadedImages.Tag = "";
            this.labelLoadedImages.Text = "Loaded images:";
            // 
            // listViewImages
            // 
            this.listViewImages.BackColor = System.Drawing.Color.Black;
            this.listViewImages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewImages.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.listViewImages.HideSelection = false;
            this.listViewImages.Location = new System.Drawing.Point(3, 402);
            this.listViewImages.Name = "listViewImages";
            this.listViewImages.Size = new System.Drawing.Size(388, 250);
            this.listViewImages.TabIndex = 9;
            this.listViewImages.UseCompatibleStateImageBehavior = false;
            this.listViewImages.View = System.Windows.Forms.View.List;
            // 
            // buttonClassD
            // 
            this.buttonClassD.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonClassD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClassD.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClassD.Location = new System.Drawing.Point(263, 277);
            this.buttonClassD.Name = "buttonClassD";
            this.buttonClassD.Size = new System.Drawing.Size(96, 89);
            this.buttonClassD.TabIndex = 8;
            this.buttonClassD.Text = "D";
            this.buttonClassD.UseVisualStyleBackColor = false;
            this.buttonClassD.Click += new System.EventHandler(this.buttonClassD_Click);
            // 
            // buttonClassC
            // 
            this.buttonClassC.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonClassC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClassC.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClassC.Location = new System.Drawing.Point(47, 277);
            this.buttonClassC.Name = "buttonClassC";
            this.buttonClassC.Size = new System.Drawing.Size(96, 89);
            this.buttonClassC.TabIndex = 7;
            this.buttonClassC.Text = "C";
            this.buttonClassC.UseVisualStyleBackColor = false;
            this.buttonClassC.Click += new System.EventHandler(this.buttonClassC_Click);
            // 
            // buttonClassB
            // 
            this.buttonClassB.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonClassB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClassB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClassB.Location = new System.Drawing.Point(263, 143);
            this.buttonClassB.Name = "buttonClassB";
            this.buttonClassB.Size = new System.Drawing.Size(96, 89);
            this.buttonClassB.TabIndex = 6;
            this.buttonClassB.Text = "B";
            this.buttonClassB.UseVisualStyleBackColor = false;
            this.buttonClassB.Click += new System.EventHandler(this.buttonClassB_Click);
            // 
            // buttonClassA
            // 
            this.buttonClassA.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonClassA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClassA.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClassA.Location = new System.Drawing.Point(47, 143);
            this.buttonClassA.Name = "buttonClassA";
            this.buttonClassA.Size = new System.Drawing.Size(96, 89);
            this.buttonClassA.TabIndex = 5;
            this.buttonClassA.Text = "A";
            this.buttonClassA.UseVisualStyleBackColor = false;
            this.buttonClassA.Click += new System.EventHandler(this.buttonClassA_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(163, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 4;
            this.label4.Tag = "";
            this.label4.Text = "Class Tags";
            // 
            // buttonLoadImages
            // 
            this.buttonLoadImages.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonLoadImages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoadImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadImages.Location = new System.Drawing.Point(43, 72);
            this.buttonLoadImages.Name = "buttonLoadImages";
            this.buttonLoadImages.Size = new System.Drawing.Size(187, 29);
            this.buttonLoadImages.TabIndex = 3;
            this.buttonLoadImages.Text = "Load Images";
            this.buttonLoadImages.UseVisualStyleBackColor = false;
            this.buttonLoadImages.Click += new System.EventHandler(this.buttonLoadImages_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(44, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 1;
            this.label3.Tag = "";
            this.label3.Text = "Images Folder:";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(47, 36);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(312, 22);
            this.textBoxPath.TabIndex = 0;
            this.textBoxPath.Text = "C:\\fileFinder\\488\\assets5 warehouse model\\images";
            // 
            // timer1
            // 
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 3600000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // buttonNext
            // 
            this.buttonNext.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNext.Location = new System.Drawing.Point(241, 72);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(118, 29);
            this.buttonNext.TabIndex = 11;
            this.buttonNext.Text = "next";
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // FrmPictureViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1365, 635);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPictureViewer";
            this.Text = "NFL Dyson Picture Inspector";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPictureViewer_FormClosing);
            this.Load += new System.EventHandler(this.FrmPictureViewer_Load);
            this.Resize += new System.EventHandler(this.FrmPictureViewer_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackToMenu)).EndInit();
            this.tableLayoutPanelPictureList.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCriteria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGetReceipt;
        private System.Windows.Forms.RichTextBox prompt;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelGallery;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelPlayMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPictureList;
        private System.Windows.Forms.ListView listViewReceipts;
        private System.Windows.Forms.CheckBox checkBoxPlayMode;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox pictureBoxBackToMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonLoadImages;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonClassA;
        private System.Windows.Forms.Button buttonClassB;
        private System.Windows.Forms.Button buttonClassC;
        private System.Windows.Forms.Button buttonClassD;
        private System.Windows.Forms.CheckBox checkBoxInspectionMode;
        private System.Windows.Forms.ListView listViewImages;
        private System.Windows.Forms.Label labelLoadedImages;
        private System.Windows.Forms.Button buttonNext;
    }
}
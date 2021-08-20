namespace NFLInfoCenter.Forms
{
    partial class FrmReceiptsPrinter
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReceiptsPrinter));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxExpandLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxView = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxBackToMenu = new System.Windows.Forms.PictureBox();
            this.prompt = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewReceipts = new System.Windows.Forms.ListView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.listViewQueue = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxActivatePrints = new System.Windows.Forms.CheckBox();
            this.labelLastUpdate = new System.Windows.Forms.Label();
            this.labelCollected = new System.Windows.Forms.Label();
            this.labelQueued = new System.Windows.Forms.Label();
            this.labelLoss = new System.Windows.Forms.Label();
            this.buttonManualPop = new System.Windows.Forms.Button();
            this.printer = new System.Drawing.Printing.PrintDocument();
            this.checkBoxAutomatic = new System.Windows.Forms.CheckBox();
            this.comboBoxStation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxChannel = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonSaveConfig = new System.Windows.Forms.Button();
            this.textBoxPrinterName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dataReceiptsView = new System.Windows.Forms.DataGridView();
            this.textBoxRMA = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonPullReceipts = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonPullPreReceipts = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.textBoxRMA2 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExpandLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackToMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataReceiptsView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBoxExpandLeft);
            this.panel1.Controls.Add(this.pictureBoxView);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBoxBackToMenu);
            this.panel1.Location = new System.Drawing.Point(377, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(153, 63);
            this.panel1.TabIndex = 9;
            // 
            // pictureBoxExpandLeft
            // 
            this.pictureBoxExpandLeft.Image = global::NFLInfoCenter.Properties.Resources.expand_left;
            this.pictureBoxExpandLeft.Location = new System.Drawing.Point(4, 2);
            this.pictureBoxExpandLeft.Name = "pictureBoxExpandLeft";
            this.pictureBoxExpandLeft.Size = new System.Drawing.Size(42, 40);
            this.pictureBoxExpandLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxExpandLeft.TabIndex = 9;
            this.pictureBoxExpandLeft.TabStop = false;
            this.pictureBoxExpandLeft.Click += new System.EventHandler(this.pictureBoxExpandLeft_Click);
            // 
            // pictureBoxView
            // 
            this.pictureBoxView.Image = global::NFLInfoCenter.Properties.Resources.maximize;
            this.pictureBoxView.Location = new System.Drawing.Point(51, 2);
            this.pictureBoxView.Name = "pictureBoxView";
            this.pictureBoxView.Size = new System.Drawing.Size(42, 40);
            this.pictureBoxView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxView.TabIndex = 8;
            this.pictureBoxView.TabStop = false;
            this.pictureBoxView.Click += new System.EventHandler(this.pictureBoxView_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(88, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "go menu";
            // 
            // pictureBoxBackToMenu
            // 
            this.pictureBoxBackToMenu.Image = global::NFLInfoCenter.Properties.Resources.backToMainImage;
            this.pictureBoxBackToMenu.Location = new System.Drawing.Point(99, 2);
            this.pictureBoxBackToMenu.Name = "pictureBoxBackToMenu";
            this.pictureBoxBackToMenu.Size = new System.Drawing.Size(40, 38);
            this.pictureBoxBackToMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBackToMenu.TabIndex = 6;
            this.pictureBoxBackToMenu.TabStop = false;
            this.pictureBoxBackToMenu.Click += new System.EventHandler(this.pictureBoxBackToMenu_Click);
            this.pictureBoxBackToMenu.MouseEnter += new System.EventHandler(this.pictureBoxBackToMenu_MouseEnter);
            this.pictureBoxBackToMenu.MouseLeave += new System.EventHandler(this.pictureBoxBackToMenu_MouseLeave);
            // 
            // prompt
            // 
            this.prompt.BackColor = System.Drawing.Color.Black;
            this.prompt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.prompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prompt.ForeColor = System.Drawing.Color.Lime;
            this.prompt.Location = new System.Drawing.Point(9, 625);
            this.prompt.Name = "prompt";
            this.prompt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.prompt.Size = new System.Drawing.Size(470, 83);
            this.prompt.TabIndex = 10;
            this.prompt.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Scan RMA for manual print";
            // 
            // listViewReceipts
            // 
            this.listViewReceipts.BackColor = System.Drawing.Color.Black;
            this.listViewReceipts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewReceipts.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewReceipts.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.listViewReceipts.HideSelection = false;
            this.listViewReceipts.Location = new System.Drawing.Point(8, 272);
            this.listViewReceipts.Name = "listViewReceipts";
            this.listViewReceipts.Size = new System.Drawing.Size(216, 323);
            this.listViewReceipts.TabIndex = 12;
            this.listViewReceipts.UseCompatibleStateImageBehavior = false;
            this.listViewReceipts.View = System.Windows.Forms.View.List;
            this.listViewReceipts.Click += new System.EventHandler(this.listViewReceipts_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(8, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "receitps window";
            // 
            // listViewQueue
            // 
            this.listViewQueue.BackColor = System.Drawing.Color.Black;
            this.listViewQueue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewQueue.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.listViewQueue.HideSelection = false;
            this.listViewQueue.Location = new System.Drawing.Point(236, 272);
            this.listViewQueue.Name = "listViewQueue";
            this.listViewQueue.Size = new System.Drawing.Size(215, 323);
            this.listViewQueue.TabIndex = 14;
            this.listViewQueue.UseCompatibleStateImageBehavior = false;
            this.listViewQueue.View = System.Windows.Forms.View.List;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Lime;
            this.label4.Location = new System.Drawing.Point(233, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "queue list";
            // 
            // checkBoxActivatePrints
            // 
            this.checkBoxActivatePrints.AutoSize = true;
            this.checkBoxActivatePrints.Checked = true;
            this.checkBoxActivatePrints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActivatePrints.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.checkBoxActivatePrints.Location = new System.Drawing.Point(150, 78);
            this.checkBoxActivatePrints.Name = "checkBoxActivatePrints";
            this.checkBoxActivatePrints.Size = new System.Drawing.Size(155, 21);
            this.checkBoxActivatePrints.TabIndex = 16;
            this.checkBoxActivatePrints.Text = "Activate Print Tasks";
            this.checkBoxActivatePrints.UseVisualStyleBackColor = true;
            this.checkBoxActivatePrints.CheckedChanged += new System.EventHandler(this.checkBoxActivatePrints_CheckedChanged);
            // 
            // labelLastUpdate
            // 
            this.labelLastUpdate.AutoSize = true;
            this.labelLastUpdate.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelLastUpdate.Location = new System.Drawing.Point(9, 600);
            this.labelLastUpdate.Name = "labelLastUpdate";
            this.labelLastUpdate.Size = new System.Drawing.Size(87, 17);
            this.labelLastUpdate.TabIndex = 17;
            this.labelLastUpdate.Text = "Last update:";
            // 
            // labelCollected
            // 
            this.labelCollected.AutoSize = true;
            this.labelCollected.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCollected.ForeColor = System.Drawing.Color.Lime;
            this.labelCollected.Location = new System.Drawing.Point(7, 42);
            this.labelCollected.Name = "labelCollected";
            this.labelCollected.Size = new System.Drawing.Size(78, 17);
            this.labelCollected.TabIndex = 18;
            this.labelCollected.Text = "collected:";
            // 
            // labelQueued
            // 
            this.labelQueued.AutoSize = true;
            this.labelQueued.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQueued.ForeColor = System.Drawing.Color.Lime;
            this.labelQueued.Location = new System.Drawing.Point(7, 67);
            this.labelQueued.Name = "labelQueued";
            this.labelQueued.Size = new System.Drawing.Size(67, 17);
            this.labelQueued.TabIndex = 19;
            this.labelQueued.Text = "queued:";
            // 
            // labelLoss
            // 
            this.labelLoss.AutoSize = true;
            this.labelLoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoss.ForeColor = System.Drawing.Color.Lime;
            this.labelLoss.Location = new System.Drawing.Point(7, 94);
            this.labelLoss.Name = "labelLoss";
            this.labelLoss.Size = new System.Drawing.Size(42, 17);
            this.labelLoss.TabIndex = 20;
            this.labelLoss.Text = "loss:";
            // 
            // buttonManualPop
            // 
            this.buttonManualPop.BackColor = System.Drawing.Color.DimGray;
            this.buttonManualPop.FlatAppearance.BorderSize = 0;
            this.buttonManualPop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManualPop.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManualPop.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonManualPop.Location = new System.Drawing.Point(343, 85);
            this.buttonManualPop.Name = "buttonManualPop";
            this.buttonManualPop.Size = new System.Drawing.Size(106, 26);
            this.buttonManualPop.TabIndex = 21;
            this.buttonManualPop.Text = "POP";
            this.buttonManualPop.UseVisualStyleBackColor = false;
            this.buttonManualPop.Click += new System.EventHandler(this.button1_Click);
            // 
            // printer
            // 
            this.printer.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printer_PrintPage);
            // 
            // checkBoxAutomatic
            // 
            this.checkBoxAutomatic.AutoSize = true;
            this.checkBoxAutomatic.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.checkBoxAutomatic.Location = new System.Drawing.Point(150, 110);
            this.checkBoxAutomatic.Name = "checkBoxAutomatic";
            this.checkBoxAutomatic.Size = new System.Drawing.Size(125, 21);
            this.checkBoxAutomatic.TabIndex = 23;
            this.checkBoxAutomatic.Text = "Automatic Print";
            this.checkBoxAutomatic.UseVisualStyleBackColor = true;
            // 
            // comboBoxStation
            // 
            this.comboBoxStation.BackColor = System.Drawing.SystemColors.MenuText;
            this.comboBoxStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxStation.ForeColor = System.Drawing.Color.Lime;
            this.comboBoxStation.FormattingEnabled = true;
            this.comboBoxStation.Location = new System.Drawing.Point(118, 148);
            this.comboBoxStation.Name = "comboBoxStation";
            this.comboBoxStation.Size = new System.Drawing.Size(176, 24);
            this.comboBoxStation.TabIndex = 24;
            this.comboBoxStation.SelectedIndexChanged += new System.EventHandler(this.comboBoxStation_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Lime;
            this.label5.Location = new System.Drawing.Point(7, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 17);
            this.label5.TabIndex = 25;
            this.label5.Text = "Printer Config:";
            // 
            // comboBoxChannel
            // 
            this.comboBoxChannel.BackColor = System.Drawing.SystemColors.MenuText;
            this.comboBoxChannel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxChannel.ForeColor = System.Drawing.Color.Lime;
            this.comboBoxChannel.FormattingEnabled = true;
            this.comboBoxChannel.Location = new System.Drawing.Point(118, 178);
            this.comboBoxChannel.Name = "comboBoxChannel";
            this.comboBoxChannel.Size = new System.Drawing.Size(176, 24);
            this.comboBoxChannel.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Lime;
            this.label6.Location = new System.Drawing.Point(20, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 17);
            this.label6.TabIndex = 27;
            this.label6.Text = "station:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Lime;
            this.label7.Location = new System.Drawing.Point(13, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 17);
            this.label7.TabIndex = 28;
            this.label7.Text = "channel:";
            // 
            // buttonSaveConfig
            // 
            this.buttonSaveConfig.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonSaveConfig.FlatAppearance.BorderSize = 0;
            this.buttonSaveConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveConfig.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSaveConfig.Location = new System.Drawing.Point(343, 145);
            this.buttonSaveConfig.Name = "buttonSaveConfig";
            this.buttonSaveConfig.Size = new System.Drawing.Size(104, 26);
            this.buttonSaveConfig.TabIndex = 29;
            this.buttonSaveConfig.Text = "save";
            this.buttonSaveConfig.UseVisualStyleBackColor = false;
            this.buttonSaveConfig.Click += new System.EventHandler(this.buttonSaveConfig_Click);
            // 
            // textBoxPrinterName
            // 
            this.textBoxPrinterName.BackColor = System.Drawing.SystemColors.MenuText;
            this.textBoxPrinterName.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBoxPrinterName.Location = new System.Drawing.Point(118, 211);
            this.textBoxPrinterName.Name = "textBoxPrinterName";
            this.textBoxPrinterName.Size = new System.Drawing.Size(176, 22);
            this.textBoxPrinterName.TabIndex = 30;
            this.textBoxPrinterName.TextChanged += new System.EventHandler(this.textBoxPrinterName_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Lime;
            this.label8.Location = new System.Drawing.Point(13, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 17);
            this.label8.TabIndex = 28;
            this.label8.Text = "printer name:";
            // 
            // dataReceiptsView
            // 
            this.dataReceiptsView.AllowUserToOrderColumns = true;
            this.dataReceiptsView.BackgroundColor = System.Drawing.Color.Black;
            this.dataReceiptsView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataReceiptsView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataReceiptsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataReceiptsView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataReceiptsView.GridColor = System.Drawing.Color.Black;
            this.dataReceiptsView.Location = new System.Drawing.Point(550, 108);
            this.dataReceiptsView.Name = "dataReceiptsView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataReceiptsView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataReceiptsView.RowHeadersWidth = 51;
            this.dataReceiptsView.RowTemplate.Height = 24;
            this.dataReceiptsView.Size = new System.Drawing.Size(397, 487);
            this.dataReceiptsView.TabIndex = 31;
            // 
            // textBoxRMA
            // 
            this.textBoxRMA.BackColor = System.Drawing.SystemColors.MenuText;
            this.textBoxRMA.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRMA.ForeColor = System.Drawing.Color.Lime;
            this.textBoxRMA.Location = new System.Drawing.Point(599, 27);
            this.textBoxRMA.Name = "textBoxRMA";
            this.textBoxRMA.Size = new System.Drawing.Size(176, 22);
            this.textBoxRMA.TabIndex = 30;
            this.textBoxRMA.TextChanged += new System.EventHandler(this.textBoxRMA_TextChanged);
            this.textBoxRMA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRMA_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Lime;
            this.label9.Location = new System.Drawing.Point(547, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "RMA:";
            // 
            // buttonPullReceipts
            // 
            this.buttonPullReceipts.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonPullReceipts.FlatAppearance.BorderSize = 0;
            this.buttonPullReceipts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPullReceipts.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPullReceipts.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonPullReceipts.Location = new System.Drawing.Point(781, 8);
            this.buttonPullReceipts.Name = "buttonPullReceipts";
            this.buttonPullReceipts.Size = new System.Drawing.Size(147, 26);
            this.buttonPullReceipts.TabIndex = 32;
            this.buttonPullReceipts.Text = "pull receipts";
            this.buttonPullReceipts.UseVisualStyleBackColor = false;
            this.buttonPullReceipts.Click += new System.EventHandler(this.buttonPullReceipts_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonPrint.FlatAppearance.BorderSize = 0;
            this.buttonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrint.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonPrint.Location = new System.Drawing.Point(781, 76);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(147, 26);
            this.buttonPrint.TabIndex = 33;
            this.buttonPrint.Text = "print selected";
            this.buttonPrint.UseVisualStyleBackColor = false;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonPullPreReceipts
            // 
            this.buttonPullPreReceipts.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonPullPreReceipts.FlatAppearance.BorderSize = 0;
            this.buttonPullPreReceipts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPullPreReceipts.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPullPreReceipts.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonPullPreReceipts.Location = new System.Drawing.Point(781, 42);
            this.buttonPullPreReceipts.Name = "buttonPullPreReceipts";
            this.buttonPullPreReceipts.Size = new System.Drawing.Size(147, 26);
            this.buttonPullPreReceipts.TabIndex = 34;
            this.buttonPullPreReceipts.Text = "pull prereceipts";
            this.buttonPullPreReceipts.UseVisualStyleBackColor = false;
            this.buttonPullPreReceipts.Click += new System.EventHandler(this.buttonPullPreReceipts_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "NFL Print Service ON";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // textBoxRMA2
            // 
            this.textBoxRMA2.Location = new System.Drawing.Point(220, 11);
            this.textBoxRMA2.Name = "textBoxRMA2";
            this.textBoxRMA2.Size = new System.Drawing.Size(151, 22);
            this.textBoxRMA2.TabIndex = 35;
            this.textBoxRMA2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRMA2_KeyDown);
            // 
            // FrmReceiptsPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1002, 718);
            this.Controls.Add(this.textBoxRMA2);
            this.Controls.Add(this.buttonPullPreReceipts);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.buttonPullReceipts);
            this.Controls.Add(this.dataReceiptsView);
            this.Controls.Add(this.textBoxRMA);
            this.Controls.Add(this.textBoxPrinterName);
            this.Controls.Add(this.buttonSaveConfig);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxChannel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxStation);
            this.Controls.Add(this.checkBoxAutomatic);
            this.Controls.Add(this.buttonManualPop);
            this.Controls.Add(this.labelLoss);
            this.Controls.Add(this.labelQueued);
            this.Controls.Add(this.labelCollected);
            this.Controls.Add(this.labelLastUpdate);
            this.Controls.Add(this.checkBoxActivatePrints);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listViewQueue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listViewReceipts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prompt);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReceiptsPrinter";
            this.Text = "ReceiptsPrinter";
            this.Load += new System.EventHandler(this.FrmReceiptsPrinter_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExpandLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackToMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataReceiptsView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxBackToMenu;
        private System.Windows.Forms.RichTextBox prompt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewReceipts;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listViewQueue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxActivatePrints;
        private System.Windows.Forms.Label labelLastUpdate;
        private System.Windows.Forms.Label labelCollected;
        private System.Windows.Forms.Label labelQueued;
        private System.Windows.Forms.Label labelLoss;
        private System.Windows.Forms.Button buttonManualPop;
        private System.Drawing.Printing.PrintDocument printer;
        private System.Windows.Forms.PictureBox pictureBoxView;
        private System.Windows.Forms.CheckBox checkBoxAutomatic;
        private System.Windows.Forms.ComboBox comboBoxStation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxChannel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonSaveConfig;
        private System.Windows.Forms.TextBox textBoxPrinterName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataReceiptsView;
        private System.Windows.Forms.TextBox textBoxRMA;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonPullReceipts;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.PictureBox pictureBoxExpandLeft;
        private System.Windows.Forms.Button buttonPullPreReceipts;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox textBoxRMA2;
    }
}
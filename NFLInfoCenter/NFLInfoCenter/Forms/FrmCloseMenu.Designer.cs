namespace NFLInfoCenter.Forms
{
    partial class FrmCloseMenu
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
            this.buttonQuit = new System.Windows.Forms.Button();
            this.prompt = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // buttonQuit
            // 
            this.buttonQuit.BackColor = System.Drawing.Color.Lime;
            this.buttonQuit.FlatAppearance.BorderSize = 0;
            this.buttonQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQuit.Location = new System.Drawing.Point(6, 10);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(251, 31);
            this.buttonQuit.TabIndex = 0;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = false;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            this.buttonQuit.MouseEnter += new System.EventHandler(this.buttonQuit_MouseEnter);
            // 
            // prompt
            // 
            this.prompt.BackColor = System.Drawing.Color.Black;
            this.prompt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.prompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prompt.ForeColor = System.Drawing.Color.Lime;
            this.prompt.Location = new System.Drawing.Point(3, 49);
            this.prompt.Name = "prompt";
            this.prompt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.prompt.Size = new System.Drawing.Size(266, 61);
            this.prompt.TabIndex = 1;
            this.prompt.Text = "";
            this.prompt.MouseEnter += new System.EventHandler(this.prompt_MouseEnter);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmCloseMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(269, 89);
            this.Controls.Add(this.prompt);
            this.Controls.Add(this.buttonQuit);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCloseMenu";
            this.Text = "FrmCloseMenu";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmCloseMenu_Load);
            this.MouseLeave += new System.EventHandler(this.FrmCloseMenu_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.RichTextBox prompt;
        private System.Windows.Forms.Timer timer1;
    }
}
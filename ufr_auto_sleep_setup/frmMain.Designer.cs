namespace ufr_auto_sleep_setup
{
    partial class frmMain
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusReader = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.tbDeviceSerialNr = new System.Windows.Forms.TextBox();
            this.lbDeviceSerialNr = new System.Windows.Forms.Label();
            this.tbDeviceType = new System.Windows.Forms.TextBox();
            this.lbDeviceType = new System.Windows.Forms.Label();
            this.numAutoSleepTime = new System.Windows.Forms.NumericUpDown();
            this.lbAutoSleepTime = new System.Windows.Forms.Label();
            this.btnSetAutoSleep = new System.Windows.Forms.Button();
            this.chkEnableAutoSleep = new System.Windows.Forms.CheckBox();
            this.lbSeconds = new System.Windows.Forms.Label();
            this.btnWakeUp = new System.Windows.Forms.Button();
            this.btnSleep = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoSleepTime)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.AutoSize = false;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel6,
            this.statusReader});
            this.statusStrip.Location = new System.Drawing.Point(0, 216);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(484, 22);
            this.statusStrip.TabIndex = 23;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.AutoSize = false;
            this.toolStripStatusLabel6.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(52, 17);
            this.toolStripStatusLabel6.Text = "STATUS";
            // 
            // statusReader
            // 
            this.statusReader.AutoSize = false;
            this.statusReader.Name = "statusReader";
            this.statusReader.Size = new System.Drawing.Size(360, 17);
            this.statusReader.Text = "Ok";
            this.statusReader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(329, 41);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close Reader";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(329, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(129, 23);
            this.btnOpen.TabIndex = 8;
            this.btnOpen.Text = "Open Reader";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // tbDeviceSerialNr
            // 
            this.tbDeviceSerialNr.Location = new System.Drawing.Point(104, 38);
            this.tbDeviceSerialNr.Name = "tbDeviceSerialNr";
            this.tbDeviceSerialNr.ReadOnly = true;
            this.tbDeviceSerialNr.Size = new System.Drawing.Size(196, 20);
            this.tbDeviceSerialNr.TabIndex = 3;
            // 
            // lbDeviceSerialNr
            // 
            this.lbDeviceSerialNr.AutoSize = true;
            this.lbDeviceSerialNr.Location = new System.Drawing.Point(14, 41);
            this.lbDeviceSerialNr.Name = "lbDeviceSerialNr";
            this.lbDeviceSerialNr.Size = new System.Drawing.Size(84, 13);
            this.lbDeviceSerialNr.TabIndex = 2;
            this.lbDeviceSerialNr.Text = "Device Serial Nr";
            this.lbDeviceSerialNr.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbDeviceType
            // 
            this.tbDeviceType.Location = new System.Drawing.Point(104, 12);
            this.tbDeviceType.Name = "tbDeviceType";
            this.tbDeviceType.ReadOnly = true;
            this.tbDeviceType.Size = new System.Drawing.Size(196, 20);
            this.tbDeviceType.TabIndex = 1;
            // 
            // lbDeviceType
            // 
            this.lbDeviceType.AutoSize = true;
            this.lbDeviceType.Location = new System.Drawing.Point(14, 15);
            this.lbDeviceType.MinimumSize = new System.Drawing.Size(84, 13);
            this.lbDeviceType.Name = "lbDeviceType";
            this.lbDeviceType.Size = new System.Drawing.Size(84, 13);
            this.lbDeviceType.TabIndex = 0;
            this.lbDeviceType.Text = "Device Type";
            this.lbDeviceType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numAutoSleepTime
            // 
            this.numAutoSleepTime.Enabled = false;
            this.numAutoSleepTime.Location = new System.Drawing.Point(155, 95);
            this.numAutoSleepTime.Maximum = new decimal(new int[] {
            254,
            0,
            0,
            0});
            this.numAutoSleepTime.Name = "numAutoSleepTime";
            this.numAutoSleepTime.ReadOnly = true;
            this.numAutoSleepTime.Size = new System.Drawing.Size(53, 20);
            this.numAutoSleepTime.TabIndex = 17;
            // 
            // lbAutoSleepTime
            // 
            this.lbAutoSleepTime.AutoSize = true;
            this.lbAutoSleepTime.Enabled = false;
            this.lbAutoSleepTime.Location = new System.Drawing.Point(14, 97);
            this.lbAutoSleepTime.MinimumSize = new System.Drawing.Size(84, 13);
            this.lbAutoSleepTime.Name = "lbAutoSleepTime";
            this.lbAutoSleepTime.Size = new System.Drawing.Size(135, 13);
            this.lbAutoSleepTime.TabIndex = 16;
            this.lbAutoSleepTime.Tag = "";
            this.lbAutoSleepTime.Text = "Time to enter in auto-sleep:";
            this.lbAutoSleepTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSetAutoSleep
            // 
            this.btnSetAutoSleep.Enabled = false;
            this.btnSetAutoSleep.Location = new System.Drawing.Point(329, 92);
            this.btnSetAutoSleep.Name = "btnSetAutoSleep";
            this.btnSetAutoSleep.Size = new System.Drawing.Size(129, 23);
            this.btnSetAutoSleep.TabIndex = 18;
            this.btnSetAutoSleep.Tag = "";
            this.btnSetAutoSleep.Text = "Set Auto-sleep mode";
            this.btnSetAutoSleep.UseVisualStyleBackColor = true;
            this.btnSetAutoSleep.Click += new System.EventHandler(this.btnSetAutoSleep_Click);
            // 
            // chkEnableAutoSleep
            // 
            this.chkEnableAutoSleep.AutoSize = true;
            this.chkEnableAutoSleep.Enabled = false;
            this.chkEnableAutoSleep.Location = new System.Drawing.Point(17, 72);
            this.chkEnableAutoSleep.Name = "chkEnableAutoSleep";
            this.chkEnableAutoSleep.Size = new System.Drawing.Size(140, 17);
            this.chkEnableAutoSleep.TabIndex = 24;
            this.chkEnableAutoSleep.Text = "Enable auto-sleep mode";
            this.chkEnableAutoSleep.UseVisualStyleBackColor = true;
            this.chkEnableAutoSleep.CheckedChanged += new System.EventHandler(this.chkEnableAutoSleep_CheckedChanged);
            // 
            // lbSeconds
            // 
            this.lbSeconds.AutoSize = true;
            this.lbSeconds.Enabled = false;
            this.lbSeconds.Location = new System.Drawing.Point(214, 97);
            this.lbSeconds.MinimumSize = new System.Drawing.Size(84, 13);
            this.lbSeconds.Name = "lbSeconds";
            this.lbSeconds.Size = new System.Drawing.Size(84, 13);
            this.lbSeconds.TabIndex = 25;
            this.lbSeconds.Tag = "";
            this.lbSeconds.Text = "seconds";
            this.lbSeconds.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnWakeUp
            // 
            this.btnWakeUp.Enabled = false;
            this.btnWakeUp.Location = new System.Drawing.Point(329, 177);
            this.btnWakeUp.Name = "btnWakeUp";
            this.btnWakeUp.Size = new System.Drawing.Size(129, 23);
            this.btnWakeUp.TabIndex = 26;
            this.btnWakeUp.Tag = "";
            this.btnWakeUp.Text = "Wake up";
            this.btnWakeUp.UseVisualStyleBackColor = true;
            this.btnWakeUp.Click += new System.EventHandler(this.btnWakeUp_Click);
            // 
            // btnSleep
            // 
            this.btnSleep.Enabled = false;
            this.btnSleep.Location = new System.Drawing.Point(329, 148);
            this.btnSleep.Name = "btnSleep";
            this.btnSleep.Size = new System.Drawing.Size(129, 23);
            this.btnSleep.TabIndex = 27;
            this.btnSleep.Tag = "";
            this.btnSleep.Text = "Sleep";
            this.btnSleep.UseVisualStyleBackColor = true;
            this.btnSleep.Click += new System.EventHandler(this.btnSleep_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 238);
            this.Controls.Add(this.btnSleep);
            this.Controls.Add(this.btnWakeUp);
            this.Controls.Add(this.lbSeconds);
            this.Controls.Add(this.chkEnableAutoSleep);
            this.Controls.Add(this.btnSetAutoSleep);
            this.Controls.Add(this.lbAutoSleepTime);
            this.Controls.Add(this.numAutoSleepTime);
            this.Controls.Add(this.tbDeviceSerialNr);
            this.Controls.Add(this.lbDeviceSerialNr);
            this.Controls.Add(this.tbDeviceType);
            this.Controls.Add(this.lbDeviceType);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.statusStrip);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "uFR Auto Sleep Setup v1.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoSleepTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel statusReader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox tbDeviceSerialNr;
        private System.Windows.Forms.Label lbDeviceSerialNr;
        private System.Windows.Forms.TextBox tbDeviceType;
        private System.Windows.Forms.Label lbDeviceType;
        private System.Windows.Forms.NumericUpDown numAutoSleepTime;
        private System.Windows.Forms.Label lbAutoSleepTime;
        private System.Windows.Forms.Button btnSetAutoSleep;
        private System.Windows.Forms.CheckBox chkEnableAutoSleep;
        private System.Windows.Forms.Label lbSeconds;
        private System.Windows.Forms.Button btnWakeUp;
        private System.Windows.Forms.Button btnSleep;
    }
}


namespace uFR_RGB_LED_Disp
{
    partial class Form1
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
            this.btnCardIdEx = new System.Windows.Forms.Button();
            this.tbCardType = new System.Windows.Forms.TextBox();
            this.lbCardType = new System.Windows.Forms.Label();
            this.tbCardId = new System.Windows.Forms.TextBox();
            this.lbCardId = new System.Windows.Forms.Label();
            this.tbDeviceSerialNr = new System.Windows.Forms.TextBox();
            this.lbDeviceSerialNr = new System.Windows.Forms.Label();
            this.tbDeviceType = new System.Windows.Forms.TextBox();
            this.lbDeviceType = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.AutoSize = false;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel6,
            this.statusReader});
            this.statusStrip.Location = new System.Drawing.Point(0, 436);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(700, 22);
            this.statusStrip.TabIndex = 48;
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
            this.statusReader.Size = new System.Drawing.Size(160, 17);
            this.statusReader.Text = "statusReader";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(559, 41);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 23);
            this.btnClose.TabIndex = 50;
            this.btnClose.Text = "Close Reader";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(559, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(129, 23);
            this.btnOpen.TabIndex = 49;
            this.btnOpen.Text = "Open Reader";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnCardIdEx
            // 
            this.btnCardIdEx.Location = new System.Drawing.Point(559, 70);
            this.btnCardIdEx.Name = "btnCardIdEx";
            this.btnCardIdEx.Size = new System.Drawing.Size(129, 23);
            this.btnCardIdEx.TabIndex = 51;
            this.btnCardIdEx.Tag = "100000000";
            this.btnCardIdEx.Text = "Get Card ID";
            this.btnCardIdEx.UseVisualStyleBackColor = true;
            this.btnCardIdEx.Click += new System.EventHandler(this.btnCardIdEx_Click);
            // 
            // tbCardType
            // 
            this.tbCardType.Location = new System.Drawing.Point(104, 64);
            this.tbCardType.Name = "tbCardType";
            this.tbCardType.Size = new System.Drawing.Size(196, 20);
            this.tbCardType.TabIndex = 57;
            this.tbCardType.Tag = "100000000";
            // 
            // lbCardType
            // 
            this.lbCardType.AutoSize = true;
            this.lbCardType.Location = new System.Drawing.Point(14, 67);
            this.lbCardType.MinimumSize = new System.Drawing.Size(84, 13);
            this.lbCardType.Name = "lbCardType";
            this.lbCardType.Size = new System.Drawing.Size(84, 13);
            this.lbCardType.TabIndex = 56;
            this.lbCardType.Tag = "100000000";
            this.lbCardType.Text = "Card Type";
            this.lbCardType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbCardId
            // 
            this.tbCardId.Location = new System.Drawing.Point(104, 90);
            this.tbCardId.Name = "tbCardId";
            this.tbCardId.Size = new System.Drawing.Size(196, 20);
            this.tbCardId.TabIndex = 59;
            this.tbCardId.Tag = "100000000";
            // 
            // lbCardId
            // 
            this.lbCardId.AutoSize = true;
            this.lbCardId.Location = new System.Drawing.Point(14, 93);
            this.lbCardId.MinimumSize = new System.Drawing.Size(84, 13);
            this.lbCardId.Name = "lbCardId";
            this.lbCardId.Size = new System.Drawing.Size(84, 13);
            this.lbCardId.TabIndex = 58;
            this.lbCardId.Tag = "100000000";
            this.lbCardId.Text = "Card ID";
            this.lbCardId.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbDeviceSerialNr
            // 
            this.tbDeviceSerialNr.Location = new System.Drawing.Point(104, 38);
            this.tbDeviceSerialNr.Name = "tbDeviceSerialNr";
            this.tbDeviceSerialNr.Size = new System.Drawing.Size(196, 20);
            this.tbDeviceSerialNr.TabIndex = 55;
            // 
            // lbDeviceSerialNr
            // 
            this.lbDeviceSerialNr.AutoSize = true;
            this.lbDeviceSerialNr.Location = new System.Drawing.Point(14, 41);
            this.lbDeviceSerialNr.Name = "lbDeviceSerialNr";
            this.lbDeviceSerialNr.Size = new System.Drawing.Size(84, 13);
            this.lbDeviceSerialNr.TabIndex = 54;
            this.lbDeviceSerialNr.Text = "Device Serial Nr";
            this.lbDeviceSerialNr.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbDeviceType
            // 
            this.tbDeviceType.Location = new System.Drawing.Point(104, 12);
            this.tbDeviceType.Name = "tbDeviceType";
            this.tbDeviceType.Size = new System.Drawing.Size(196, 20);
            this.tbDeviceType.TabIndex = 53;
            // 
            // lbDeviceType
            // 
            this.lbDeviceType.AutoSize = true;
            this.lbDeviceType.Location = new System.Drawing.Point(14, 15);
            this.lbDeviceType.MinimumSize = new System.Drawing.Size(84, 13);
            this.lbDeviceType.Name = "lbDeviceType";
            this.lbDeviceType.Size = new System.Drawing.Size(84, 13);
            this.lbDeviceType.TabIndex = 52;
            this.lbDeviceType.Text = "Device Type";
            this.lbDeviceType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 458);
            this.Controls.Add(this.tbCardType);
            this.Controls.Add(this.lbCardType);
            this.Controls.Add(this.tbCardId);
            this.Controls.Add(this.lbCardId);
            this.Controls.Add(this.tbDeviceSerialNr);
            this.Controls.Add(this.lbDeviceSerialNr);
            this.Controls.Add(this.tbDeviceType);
            this.Controls.Add(this.lbDeviceType);
            this.Controls.Add(this.btnCardIdEx);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.statusStrip);
            this.Name = "Form1";
            this.Text = "uFR RGB LED Display Demo v1.0";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel statusReader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnCardIdEx;
        private System.Windows.Forms.TextBox tbCardType;
        private System.Windows.Forms.Label lbCardType;
        private System.Windows.Forms.TextBox tbCardId;
        private System.Windows.Forms.Label lbCardId;
        private System.Windows.Forms.TextBox tbDeviceSerialNr;
        private System.Windows.Forms.Label lbDeviceSerialNr;
        private System.Windows.Forms.TextBox tbDeviceType;
        private System.Windows.Forms.Label lbDeviceType;
    }
}


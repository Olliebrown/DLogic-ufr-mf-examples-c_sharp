namespace NTAG_lock_bytes
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
            this.lbDeviceType = new System.Windows.Forms.Label();
            this.chkLP3 = new System.Windows.Forms.CheckBox();
            this.tbDeviceType = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.tbDeviceSerialNr = new System.Windows.Forms.TextBox();
            this.lbDeviceSerialNr = new System.Windows.Forms.Label();
            this.tbCardId = new System.Windows.Forms.TextBox();
            this.lbCardId = new System.Windows.Forms.Label();
            this.tbLockByte0 = new System.Windows.Forms.TextBox();
            this.lbLockByte0 = new System.Windows.Forms.Label();
            this.tbLockByte1 = new System.Windows.Forms.TextBox();
            this.lbLockByte1 = new System.Windows.Forms.Label();
            this.tbLockByte2 = new System.Windows.Forms.TextBox();
            this.lbLockByte2 = new System.Windows.Forms.Label();
            this.tbLockByte3 = new System.Windows.Forms.TextBox();
            this.lbLockByte3 = new System.Windows.Forms.Label();
            this.tbCardType = new System.Windows.Forms.TextBox();
            this.lbCardType = new System.Windows.Forms.Label();
            this.btnCardIdEx = new System.Windows.Forms.Button();
            this.btnPageRead = new System.Windows.Forms.Button();
            this.btnPageWrite = new System.Windows.Forms.Button();
            this.chkLP4 = new System.Windows.Forms.CheckBox();
            this.chkLP5 = new System.Windows.Forms.CheckBox();
            this.chkLP7 = new System.Windows.Forms.CheckBox();
            this.chkLP6 = new System.Windows.Forms.CheckBox();
            this.chkLP9 = new System.Windows.Forms.CheckBox();
            this.chkLP8 = new System.Windows.Forms.CheckBox();
            this.chkLP15 = new System.Windows.Forms.CheckBox();
            this.chkLP14 = new System.Windows.Forms.CheckBox();
            this.chkLP13 = new System.Windows.Forms.CheckBox();
            this.chkLP12 = new System.Windows.Forms.CheckBox();
            this.chkLP11 = new System.Windows.Forms.CheckBox();
            this.chkLP10 = new System.Windows.Forms.CheckBox();
            this.chkBL10_15 = new System.Windows.Forms.CheckBox();
            this.chkBL4_9 = new System.Windows.Forms.CheckBox();
            this.chkBL3 = new System.Windows.Forms.CheckBox();
            this.chkLP24_27 = new System.Windows.Forms.CheckBox();
            this.chkLP20_23 = new System.Windows.Forms.CheckBox();
            this.chkLP16_19 = new System.Windows.Forms.CheckBox();
            this.chkLP36_39 = new System.Windows.Forms.CheckBox();
            this.chkLP32_35 = new System.Windows.Forms.CheckBox();
            this.chkLP28_31 = new System.Windows.Forms.CheckBox();
            this.chkLP41 = new System.Windows.Forms.CheckBox();
            this.chkBL41 = new System.Windows.Forms.CheckBox();
            this.chkBL28_39 = new System.Windows.Forms.CheckBox();
            this.chkBL16_27 = new System.Windows.Forms.CheckBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusReader = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbDeviceType
            // 
            this.lbDeviceType.AutoSize = true;
            this.lbDeviceType.Location = new System.Drawing.Point(13, 15);
            this.lbDeviceType.MinimumSize = new System.Drawing.Size(84, 13);
            this.lbDeviceType.Name = "lbDeviceType";
            this.lbDeviceType.Size = new System.Drawing.Size(84, 13);
            this.lbDeviceType.TabIndex = 0;
            this.lbDeviceType.Text = "Device Type";
            this.lbDeviceType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkLP3
            // 
            this.chkLP3.AutoSize = true;
            this.chkLP3.Location = new System.Drawing.Point(497, 12);
            this.chkLP3.Name = "chkLP3";
            this.chkLP3.Size = new System.Drawing.Size(126, 17);
            this.chkLP3.TabIndex = 1;
            this.chkLP3.Tag = "6";
            this.chkLP3.Text = "LOCK PAGE 3 (OTP)";
            this.chkLP3.UseVisualStyleBackColor = true;
            // 
            // tbDeviceType
            // 
            this.tbDeviceType.Location = new System.Drawing.Point(103, 12);
            this.tbDeviceType.Name = "tbDeviceType";
            this.tbDeviceType.Size = new System.Drawing.Size(196, 20);
            this.tbDeviceType.TabIndex = 2;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(332, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(129, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open Reader";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // tbDeviceSerialNr
            // 
            this.tbDeviceSerialNr.Location = new System.Drawing.Point(103, 38);
            this.tbDeviceSerialNr.Name = "tbDeviceSerialNr";
            this.tbDeviceSerialNr.Size = new System.Drawing.Size(196, 20);
            this.tbDeviceSerialNr.TabIndex = 5;
            // 
            // lbDeviceSerialNr
            // 
            this.lbDeviceSerialNr.AutoSize = true;
            this.lbDeviceSerialNr.Location = new System.Drawing.Point(13, 41);
            this.lbDeviceSerialNr.Name = "lbDeviceSerialNr";
            this.lbDeviceSerialNr.Size = new System.Drawing.Size(84, 13);
            this.lbDeviceSerialNr.TabIndex = 4;
            this.lbDeviceSerialNr.Text = "Device Serial Nr";
            this.lbDeviceSerialNr.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbCardId
            // 
            this.tbCardId.Location = new System.Drawing.Point(103, 90);
            this.tbCardId.Name = "tbCardId";
            this.tbCardId.Size = new System.Drawing.Size(196, 20);
            this.tbCardId.TabIndex = 7;
            this.tbCardId.Tag = "1";
            // 
            // lbCardId
            // 
            this.lbCardId.AutoSize = true;
            this.lbCardId.Location = new System.Drawing.Point(13, 93);
            this.lbCardId.MinimumSize = new System.Drawing.Size(84, 13);
            this.lbCardId.Name = "lbCardId";
            this.lbCardId.Size = new System.Drawing.Size(84, 13);
            this.lbCardId.TabIndex = 6;
            this.lbCardId.Tag = "1";
            this.lbCardId.Text = "Card ID";
            this.lbCardId.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbLockByte0
            // 
            this.tbLockByte0.Location = new System.Drawing.Point(103, 116);
            this.tbLockByte0.Name = "tbLockByte0";
            this.tbLockByte0.Size = new System.Drawing.Size(49, 20);
            this.tbLockByte0.TabIndex = 9;
            this.tbLockByte0.Tag = "6";
            // 
            // lbLockByte0
            // 
            this.lbLockByte0.AutoSize = true;
            this.lbLockByte0.Location = new System.Drawing.Point(13, 119);
            this.lbLockByte0.MinimumSize = new System.Drawing.Size(84, 13);
            this.lbLockByte0.Name = "lbLockByte0";
            this.lbLockByte0.Size = new System.Drawing.Size(84, 13);
            this.lbLockByte0.TabIndex = 8;
            this.lbLockByte0.Tag = "6";
            this.lbLockByte0.Text = "Lock byte 0";
            this.lbLockByte0.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbLockByte1
            // 
            this.tbLockByte1.Location = new System.Drawing.Point(103, 142);
            this.tbLockByte1.Name = "tbLockByte1";
            this.tbLockByte1.Size = new System.Drawing.Size(49, 20);
            this.tbLockByte1.TabIndex = 11;
            this.tbLockByte1.Tag = "6";
            // 
            // lbLockByte1
            // 
            this.lbLockByte1.AutoSize = true;
            this.lbLockByte1.Location = new System.Drawing.Point(13, 145);
            this.lbLockByte1.MinimumSize = new System.Drawing.Size(84, 13);
            this.lbLockByte1.Name = "lbLockByte1";
            this.lbLockByte1.Size = new System.Drawing.Size(84, 13);
            this.lbLockByte1.TabIndex = 10;
            this.lbLockByte1.Tag = "6";
            this.lbLockByte1.Text = "Lock byte 1";
            this.lbLockByte1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbLockByte2
            // 
            this.tbLockByte2.Location = new System.Drawing.Point(103, 168);
            this.tbLockByte2.Name = "tbLockByte2";
            this.tbLockByte2.Size = new System.Drawing.Size(49, 20);
            this.tbLockByte2.TabIndex = 13;
            this.tbLockByte2.Tag = "6";
            // 
            // lbLockByte2
            // 
            this.lbLockByte2.AutoSize = true;
            this.lbLockByte2.Location = new System.Drawing.Point(13, 171);
            this.lbLockByte2.MinimumSize = new System.Drawing.Size(84, 13);
            this.lbLockByte2.Name = "lbLockByte2";
            this.lbLockByte2.Size = new System.Drawing.Size(84, 13);
            this.lbLockByte2.TabIndex = 12;
            this.lbLockByte2.Tag = "6";
            this.lbLockByte2.Text = "Lock byte 2";
            this.lbLockByte2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbLockByte3
            // 
            this.tbLockByte3.Location = new System.Drawing.Point(103, 194);
            this.tbLockByte3.Name = "tbLockByte3";
            this.tbLockByte3.Size = new System.Drawing.Size(49, 20);
            this.tbLockByte3.TabIndex = 15;
            this.tbLockByte3.Tag = "6";
            // 
            // lbLockByte3
            // 
            this.lbLockByte3.AutoSize = true;
            this.lbLockByte3.Location = new System.Drawing.Point(13, 197);
            this.lbLockByte3.MinimumSize = new System.Drawing.Size(84, 13);
            this.lbLockByte3.Name = "lbLockByte3";
            this.lbLockByte3.Size = new System.Drawing.Size(84, 13);
            this.lbLockByte3.TabIndex = 14;
            this.lbLockByte3.Tag = "6";
            this.lbLockByte3.Text = "Lock byte 3";
            this.lbLockByte3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbCardType
            // 
            this.tbCardType.Location = new System.Drawing.Point(103, 64);
            this.tbCardType.Name = "tbCardType";
            this.tbCardType.Size = new System.Drawing.Size(196, 20);
            this.tbCardType.TabIndex = 17;
            this.tbCardType.Tag = "1";
            // 
            // lbCardType
            // 
            this.lbCardType.AutoSize = true;
            this.lbCardType.Location = new System.Drawing.Point(13, 67);
            this.lbCardType.MinimumSize = new System.Drawing.Size(84, 13);
            this.lbCardType.Name = "lbCardType";
            this.lbCardType.Size = new System.Drawing.Size(84, 13);
            this.lbCardType.TabIndex = 16;
            this.lbCardType.Tag = "1";
            this.lbCardType.Text = "Card Type";
            this.lbCardType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCardIdEx
            // 
            this.btnCardIdEx.Location = new System.Drawing.Point(332, 133);
            this.btnCardIdEx.Name = "btnCardIdEx";
            this.btnCardIdEx.Size = new System.Drawing.Size(129, 23);
            this.btnCardIdEx.TabIndex = 18;
            this.btnCardIdEx.Tag = "1";
            this.btnCardIdEx.Text = "Get Card ID";
            this.btnCardIdEx.UseVisualStyleBackColor = true;
            // 
            // btnPageRead
            // 
            this.btnPageRead.Location = new System.Drawing.Point(332, 162);
            this.btnPageRead.Name = "btnPageRead";
            this.btnPageRead.Size = new System.Drawing.Size(129, 23);
            this.btnPageRead.TabIndex = 19;
            this.btnPageRead.Tag = "6";
            this.btnPageRead.Text = "Read lock bytes";
            this.btnPageRead.UseVisualStyleBackColor = true;
            // 
            // btnPageWrite
            // 
            this.btnPageWrite.Location = new System.Drawing.Point(332, 191);
            this.btnPageWrite.Name = "btnPageWrite";
            this.btnPageWrite.Size = new System.Drawing.Size(129, 23);
            this.btnPageWrite.TabIndex = 20;
            this.btnPageWrite.Tag = "6";
            this.btnPageWrite.Text = "Write lock bytes";
            this.btnPageWrite.UseVisualStyleBackColor = true;
            // 
            // chkLP4
            // 
            this.chkLP4.AutoSize = true;
            this.chkLP4.Location = new System.Drawing.Point(497, 35);
            this.chkLP4.Name = "chkLP4";
            this.chkLP4.Size = new System.Drawing.Size(95, 17);
            this.chkLP4.TabIndex = 21;
            this.chkLP4.Tag = "6";
            this.chkLP4.Text = "LOCK PAGE 4";
            this.chkLP4.UseVisualStyleBackColor = true;
            // 
            // chkLP5
            // 
            this.chkLP5.AutoSize = true;
            this.chkLP5.Location = new System.Drawing.Point(497, 58);
            this.chkLP5.Name = "chkLP5";
            this.chkLP5.Size = new System.Drawing.Size(95, 17);
            this.chkLP5.TabIndex = 22;
            this.chkLP5.Tag = "6";
            this.chkLP5.Text = "LOCK PAGE 5";
            this.chkLP5.UseVisualStyleBackColor = true;
            // 
            // chkLP7
            // 
            this.chkLP7.AutoSize = true;
            this.chkLP7.Location = new System.Drawing.Point(497, 104);
            this.chkLP7.Name = "chkLP7";
            this.chkLP7.Size = new System.Drawing.Size(95, 17);
            this.chkLP7.TabIndex = 24;
            this.chkLP7.Tag = "6";
            this.chkLP7.Text = "LOCK PAGE 7";
            this.chkLP7.UseVisualStyleBackColor = true;
            // 
            // chkLP6
            // 
            this.chkLP6.AutoSize = true;
            this.chkLP6.Location = new System.Drawing.Point(497, 81);
            this.chkLP6.Name = "chkLP6";
            this.chkLP6.Size = new System.Drawing.Size(95, 17);
            this.chkLP6.TabIndex = 23;
            this.chkLP6.Tag = "6";
            this.chkLP6.Text = "LOCK PAGE 6";
            this.chkLP6.UseVisualStyleBackColor = true;
            // 
            // chkLP9
            // 
            this.chkLP9.AutoSize = true;
            this.chkLP9.Location = new System.Drawing.Point(497, 150);
            this.chkLP9.Name = "chkLP9";
            this.chkLP9.Size = new System.Drawing.Size(95, 17);
            this.chkLP9.TabIndex = 26;
            this.chkLP9.Tag = "6";
            this.chkLP9.Text = "LOCK PAGE 9";
            this.chkLP9.UseVisualStyleBackColor = true;
            // 
            // chkLP8
            // 
            this.chkLP8.AutoSize = true;
            this.chkLP8.Location = new System.Drawing.Point(497, 127);
            this.chkLP8.Name = "chkLP8";
            this.chkLP8.Size = new System.Drawing.Size(95, 17);
            this.chkLP8.TabIndex = 25;
            this.chkLP8.Tag = "6";
            this.chkLP8.Text = "LOCK PAGE 8";
            this.chkLP8.UseVisualStyleBackColor = true;
            // 
            // chkLP15
            // 
            this.chkLP15.AutoSize = true;
            this.chkLP15.Location = new System.Drawing.Point(497, 288);
            this.chkLP15.Name = "chkLP15";
            this.chkLP15.Size = new System.Drawing.Size(101, 17);
            this.chkLP15.TabIndex = 32;
            this.chkLP15.Tag = "6";
            this.chkLP15.Text = "LOCK PAGE 15";
            this.chkLP15.UseVisualStyleBackColor = true;
            // 
            // chkLP14
            // 
            this.chkLP14.AutoSize = true;
            this.chkLP14.Location = new System.Drawing.Point(497, 265);
            this.chkLP14.Name = "chkLP14";
            this.chkLP14.Size = new System.Drawing.Size(101, 17);
            this.chkLP14.TabIndex = 31;
            this.chkLP14.Tag = "6";
            this.chkLP14.Text = "LOCK PAGE 14";
            this.chkLP14.UseVisualStyleBackColor = true;
            // 
            // chkLP13
            // 
            this.chkLP13.AutoSize = true;
            this.chkLP13.Location = new System.Drawing.Point(497, 242);
            this.chkLP13.Name = "chkLP13";
            this.chkLP13.Size = new System.Drawing.Size(101, 17);
            this.chkLP13.TabIndex = 30;
            this.chkLP13.Tag = "6";
            this.chkLP13.Text = "LOCK PAGE 13";
            this.chkLP13.UseVisualStyleBackColor = true;
            // 
            // chkLP12
            // 
            this.chkLP12.AutoSize = true;
            this.chkLP12.Location = new System.Drawing.Point(497, 219);
            this.chkLP12.Name = "chkLP12";
            this.chkLP12.Size = new System.Drawing.Size(101, 17);
            this.chkLP12.TabIndex = 29;
            this.chkLP12.Tag = "6";
            this.chkLP12.Text = "LOCK PAGE 12";
            this.chkLP12.UseVisualStyleBackColor = true;
            // 
            // chkLP11
            // 
            this.chkLP11.AutoSize = true;
            this.chkLP11.Location = new System.Drawing.Point(497, 196);
            this.chkLP11.Name = "chkLP11";
            this.chkLP11.Size = new System.Drawing.Size(101, 17);
            this.chkLP11.TabIndex = 28;
            this.chkLP11.Tag = "6";
            this.chkLP11.Text = "LOCK PAGE 11";
            this.chkLP11.UseVisualStyleBackColor = true;
            // 
            // chkLP10
            // 
            this.chkLP10.AutoSize = true;
            this.chkLP10.Location = new System.Drawing.Point(497, 173);
            this.chkLP10.Name = "chkLP10";
            this.chkLP10.Size = new System.Drawing.Size(101, 17);
            this.chkLP10.TabIndex = 27;
            this.chkLP10.Tag = "6";
            this.chkLP10.Text = "LOCK PAGE 10";
            this.chkLP10.UseVisualStyleBackColor = true;
            // 
            // chkBL10_15
            // 
            this.chkBL10_15.AutoSize = true;
            this.chkBL10_15.Location = new System.Drawing.Point(645, 57);
            this.chkBL10_15.Name = "chkBL10_15";
            this.chkBL10_15.Size = new System.Drawing.Size(147, 17);
            this.chkBL10_15.TabIndex = 35;
            this.chkBL10_15.Tag = "6";
            this.chkBL10_15.Text = "BLOCK LOCKING 10 - 15";
            this.chkBL10_15.UseVisualStyleBackColor = true;
            // 
            // chkBL4_9
            // 
            this.chkBL4_9.AutoSize = true;
            this.chkBL4_9.Location = new System.Drawing.Point(645, 34);
            this.chkBL4_9.Name = "chkBL4_9";
            this.chkBL4_9.Size = new System.Drawing.Size(135, 17);
            this.chkBL4_9.TabIndex = 34;
            this.chkBL4_9.Tag = "6";
            this.chkBL4_9.Text = "BLOCK LOCKING 4 - 9";
            this.chkBL4_9.UseVisualStyleBackColor = true;
            // 
            // chkBL3
            // 
            this.chkBL3.AutoSize = true;
            this.chkBL3.Location = new System.Drawing.Point(645, 11);
            this.chkBL3.Name = "chkBL3";
            this.chkBL3.Size = new System.Drawing.Size(120, 17);
            this.chkBL3.TabIndex = 33;
            this.chkBL3.Tag = "6";
            this.chkBL3.Text = "BLOCK LOCKING 3";
            this.chkBL3.UseVisualStyleBackColor = true;
            // 
            // chkLP24_27
            // 
            this.chkLP24_27.AutoSize = true;
            this.chkLP24_27.Location = new System.Drawing.Point(809, 58);
            this.chkLP24_27.Name = "chkLP24_27";
            this.chkLP24_27.Size = new System.Drawing.Size(122, 17);
            this.chkLP24_27.TabIndex = 38;
            this.chkLP24_27.Tag = "2";
            this.chkLP24_27.Text = "LOCK PAGE 24 - 27";
            this.chkLP24_27.UseVisualStyleBackColor = true;
            // 
            // chkLP20_23
            // 
            this.chkLP20_23.AutoSize = true;
            this.chkLP20_23.Location = new System.Drawing.Point(809, 35);
            this.chkLP20_23.Name = "chkLP20_23";
            this.chkLP20_23.Size = new System.Drawing.Size(122, 17);
            this.chkLP20_23.TabIndex = 37;
            this.chkLP20_23.Tag = "2";
            this.chkLP20_23.Text = "LOCK PAGE 20 - 23";
            this.chkLP20_23.UseVisualStyleBackColor = true;
            // 
            // chkLP16_19
            // 
            this.chkLP16_19.AutoSize = true;
            this.chkLP16_19.Location = new System.Drawing.Point(809, 12);
            this.chkLP16_19.Name = "chkLP16_19";
            this.chkLP16_19.Size = new System.Drawing.Size(122, 17);
            this.chkLP16_19.TabIndex = 36;
            this.chkLP16_19.Tag = "2";
            this.chkLP16_19.Text = "LOCK PAGE 16 - 19";
            this.chkLP16_19.UseVisualStyleBackColor = true;
            // 
            // chkLP36_39
            // 
            this.chkLP36_39.AutoSize = true;
            this.chkLP36_39.Location = new System.Drawing.Point(809, 127);
            this.chkLP36_39.Name = "chkLP36_39";
            this.chkLP36_39.Size = new System.Drawing.Size(122, 17);
            this.chkLP36_39.TabIndex = 41;
            this.chkLP36_39.Tag = "2";
            this.chkLP36_39.Text = "LOCK PAGE 36 - 39";
            this.chkLP36_39.UseVisualStyleBackColor = true;
            // 
            // chkLP32_35
            // 
            this.chkLP32_35.AutoSize = true;
            this.chkLP32_35.Location = new System.Drawing.Point(809, 104);
            this.chkLP32_35.Name = "chkLP32_35";
            this.chkLP32_35.Size = new System.Drawing.Size(122, 17);
            this.chkLP32_35.TabIndex = 40;
            this.chkLP32_35.Tag = "2";
            this.chkLP32_35.Text = "LOCK PAGE 32 - 35";
            this.chkLP32_35.UseVisualStyleBackColor = true;
            // 
            // chkLP28_31
            // 
            this.chkLP28_31.AutoSize = true;
            this.chkLP28_31.Location = new System.Drawing.Point(809, 81);
            this.chkLP28_31.Name = "chkLP28_31";
            this.chkLP28_31.Size = new System.Drawing.Size(122, 17);
            this.chkLP28_31.TabIndex = 39;
            this.chkLP28_31.Tag = "2";
            this.chkLP28_31.Text = "LOCK PAGE 28 - 31";
            this.chkLP28_31.UseVisualStyleBackColor = true;
            // 
            // chkLP41
            // 
            this.chkLP41.AutoSize = true;
            this.chkLP41.Location = new System.Drawing.Point(809, 150);
            this.chkLP41.Name = "chkLP41";
            this.chkLP41.Size = new System.Drawing.Size(126, 17);
            this.chkLP41.TabIndex = 42;
            this.chkLP41.Tag = "2";
            this.chkLP41.Text = "LOCK CNT PAGE 41";
            this.chkLP41.UseVisualStyleBackColor = true;
            // 
            // chkBL41
            // 
            this.chkBL41.AutoSize = true;
            this.chkBL41.Location = new System.Drawing.Point(809, 288);
            this.chkBL41.Name = "chkBL41";
            this.chkBL41.Size = new System.Drawing.Size(151, 17);
            this.chkBL41.TabIndex = 45;
            this.chkBL41.Tag = "2";
            this.chkBL41.Text = "BLOCK LOCKING CNT 41";
            this.chkBL41.UseVisualStyleBackColor = true;
            // 
            // chkBL28_39
            // 
            this.chkBL28_39.AutoSize = true;
            this.chkBL28_39.Location = new System.Drawing.Point(809, 265);
            this.chkBL28_39.Name = "chkBL28_39";
            this.chkBL28_39.Size = new System.Drawing.Size(147, 17);
            this.chkBL28_39.TabIndex = 44;
            this.chkBL28_39.Tag = "2";
            this.chkBL28_39.Text = "BLOCK LOCKING 28 - 39";
            this.chkBL28_39.UseVisualStyleBackColor = true;
            // 
            // chkBL16_27
            // 
            this.chkBL16_27.AutoSize = true;
            this.chkBL16_27.Location = new System.Drawing.Point(809, 242);
            this.chkBL16_27.Name = "chkBL16_27";
            this.chkBL16_27.Size = new System.Drawing.Size(147, 17);
            this.chkBL16_27.TabIndex = 43;
            this.chkBL16_27.Tag = "2";
            this.chkBL16_27.Text = "BLOCK LOCKING 16 - 27";
            this.chkBL16_27.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.AutoSize = false;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel6,
            this.statusReader});
            this.statusStrip.Location = new System.Drawing.Point(0, 307);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(969, 22);
            this.statusStrip.TabIndex = 46;
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
            this.btnClose.Location = new System.Drawing.Point(332, 41);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 23);
            this.btnClose.TabIndex = 47;
            this.btnClose.Text = "Close Reader";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 329);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.chkBL41);
            this.Controls.Add(this.chkBL28_39);
            this.Controls.Add(this.chkBL16_27);
            this.Controls.Add(this.chkLP41);
            this.Controls.Add(this.chkLP36_39);
            this.Controls.Add(this.chkLP32_35);
            this.Controls.Add(this.chkLP28_31);
            this.Controls.Add(this.chkLP24_27);
            this.Controls.Add(this.chkLP20_23);
            this.Controls.Add(this.chkLP16_19);
            this.Controls.Add(this.chkBL10_15);
            this.Controls.Add(this.chkBL4_9);
            this.Controls.Add(this.chkBL3);
            this.Controls.Add(this.chkLP15);
            this.Controls.Add(this.chkLP14);
            this.Controls.Add(this.chkLP13);
            this.Controls.Add(this.chkLP12);
            this.Controls.Add(this.chkLP11);
            this.Controls.Add(this.chkLP10);
            this.Controls.Add(this.chkLP9);
            this.Controls.Add(this.chkLP8);
            this.Controls.Add(this.chkLP7);
            this.Controls.Add(this.chkLP6);
            this.Controls.Add(this.chkLP5);
            this.Controls.Add(this.chkLP4);
            this.Controls.Add(this.btnPageWrite);
            this.Controls.Add(this.btnPageRead);
            this.Controls.Add(this.btnCardIdEx);
            this.Controls.Add(this.tbCardType);
            this.Controls.Add(this.lbCardType);
            this.Controls.Add(this.tbLockByte3);
            this.Controls.Add(this.lbLockByte3);
            this.Controls.Add(this.tbLockByte2);
            this.Controls.Add(this.lbLockByte2);
            this.Controls.Add(this.tbLockByte1);
            this.Controls.Add(this.lbLockByte1);
            this.Controls.Add(this.tbLockByte0);
            this.Controls.Add(this.lbLockByte0);
            this.Controls.Add(this.tbCardId);
            this.Controls.Add(this.lbCardId);
            this.Controls.Add(this.tbDeviceSerialNr);
            this.Controls.Add(this.lbDeviceSerialNr);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.tbDeviceType);
            this.Controls.Add(this.chkLP3);
            this.Controls.Add(this.lbDeviceType);
            this.Name = "frmMain";
            this.Tag = "";
            this.Text = "Lock bytes manipulator for NTAG203 and MIFARE ULTRALIGHT ver 1.0";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDeviceType;
        private System.Windows.Forms.CheckBox chkLP3;
        private System.Windows.Forms.TextBox tbDeviceType;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox tbDeviceSerialNr;
        private System.Windows.Forms.Label lbDeviceSerialNr;
        private System.Windows.Forms.TextBox tbCardId;
        private System.Windows.Forms.Label lbCardId;
        private System.Windows.Forms.TextBox tbLockByte0;
        private System.Windows.Forms.Label lbLockByte0;
        private System.Windows.Forms.TextBox tbLockByte1;
        private System.Windows.Forms.Label lbLockByte1;
        private System.Windows.Forms.TextBox tbLockByte2;
        private System.Windows.Forms.Label lbLockByte2;
        private System.Windows.Forms.TextBox tbLockByte3;
        private System.Windows.Forms.Label lbLockByte3;
        private System.Windows.Forms.TextBox tbCardType;
        private System.Windows.Forms.Label lbCardType;
        private System.Windows.Forms.Button btnCardIdEx;
        private System.Windows.Forms.Button btnPageRead;
        private System.Windows.Forms.Button btnPageWrite;
        private System.Windows.Forms.CheckBox chkLP4;
        private System.Windows.Forms.CheckBox chkLP5;
        private System.Windows.Forms.CheckBox chkLP7;
        private System.Windows.Forms.CheckBox chkLP6;
        private System.Windows.Forms.CheckBox chkLP9;
        private System.Windows.Forms.CheckBox chkLP8;
        private System.Windows.Forms.CheckBox chkLP15;
        private System.Windows.Forms.CheckBox chkLP14;
        private System.Windows.Forms.CheckBox chkLP13;
        private System.Windows.Forms.CheckBox chkLP12;
        private System.Windows.Forms.CheckBox chkLP11;
        private System.Windows.Forms.CheckBox chkLP10;
        private System.Windows.Forms.CheckBox chkBL10_15;
        private System.Windows.Forms.CheckBox chkBL4_9;
        private System.Windows.Forms.CheckBox chkBL3;
        private System.Windows.Forms.CheckBox chkLP24_27;
        private System.Windows.Forms.CheckBox chkLP20_23;
        private System.Windows.Forms.CheckBox chkLP16_19;
        private System.Windows.Forms.CheckBox chkLP36_39;
        private System.Windows.Forms.CheckBox chkLP32_35;
        private System.Windows.Forms.CheckBox chkLP28_31;
        private System.Windows.Forms.CheckBox chkLP41;
        private System.Windows.Forms.CheckBox chkBL41;
        private System.Windows.Forms.CheckBox chkBL28_39;
        private System.Windows.Forms.CheckBox chkBL16_27;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel statusReader;
        private System.Windows.Forms.Button btnClose;
    }
}


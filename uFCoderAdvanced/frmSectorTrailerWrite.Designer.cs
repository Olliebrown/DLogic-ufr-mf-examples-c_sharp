namespace Mifare
{
    partial class frmSectorTrailerWrite
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
            this.pnlErr_expl = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlAuth = new System.Windows.Forms.Panel();
            this.lblPKKey = new System.Windows.Forms.Label();
            this.cboKeyIndex = new System.Windows.Forms.ComboBox();
            this.lblKeyIndex = new System.Windows.Forms.Label();
            this.rbAUTH1B = new System.Windows.Forms.RadioButton();
            this.rbAUTH1A = new System.Windows.Forms.RadioButton();
            this.lblHeader = new System.Windows.Forms.Label();
            this.stbFunctionError = new System.Windows.Forms.StatusStrip();
            this.pnlFunct_error = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlErr_code = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlBoth_key = new System.Windows.Forms.Panel();
            this.pnlKeyB = new System.Windows.Forms.Panel();
            this.chkHexKeyB = new System.Windows.Forms.CheckBox();
            this.lblKeyB = new System.Windows.Forms.Label();
            this.pnlKeyA = new System.Windows.Forms.Panel();
            this.chkHexKeyA = new System.Windows.Forms.CheckBox();
            this.lblKeyA = new System.Windows.Forms.Label();
            this.pgSectorTrailerWrite = new System.Windows.Forms.TabControl();
            this.tabSectorTrailerWrite = new System.Windows.Forms.TabPage();
            this.txtSTWBlockOrSectorAddress = new System.Windows.Forms.TextBox();
            this.btnSTWWrite = new System.Windows.Forms.Button();
            this.txtSTWTrailerByte9 = new System.Windows.Forms.TextBox();
            this.lblSTWTrailerByte9 = new System.Windows.Forms.Label();
            this.cboSTWTrailerAccessBits = new System.Windows.Forms.ComboBox();
            this.lblSTWTrailerAccessBits = new System.Windows.Forms.Label();
            this.cboSTWAccessBits2 = new System.Windows.Forms.ComboBox();
            this.lblSTWAccessBits2 = new System.Windows.Forms.Label();
            this.cboSTWAccessBits1 = new System.Windows.Forms.ComboBox();
            this.lblSTWAccessBits1 = new System.Windows.Forms.Label();
            this.lblSTWBlockOrSectorAddress = new System.Windows.Forms.Label();
            this.cboSTWAccessBits0 = new System.Windows.Forms.ComboBox();
            this.lblSTWAccessBits0 = new System.Windows.Forms.Label();
            this.cboSTWAddressingMode = new System.Windows.Forms.ComboBox();
            this.lblSTWAddressingMode = new System.Windows.Forms.Label();
            this.tabSectorTrailerWriteAKM1 = new System.Windows.Forms.TabPage();
            this.txtSTWBlockOrSectorAddressAKM1 = new System.Windows.Forms.TextBox();
            this.btnSTWWriteAKM1 = new System.Windows.Forms.Button();
            this.txtSTWTrailerByte9AKM1 = new System.Windows.Forms.TextBox();
            this.lblSTWTrailerByte9AKM1 = new System.Windows.Forms.Label();
            this.cboSTWTrailerAccessBitsAKM1 = new System.Windows.Forms.ComboBox();
            this.lblSTWTrailerAccessBitsAKM1 = new System.Windows.Forms.Label();
            this.cboSTWAccessBits2AKM1 = new System.Windows.Forms.ComboBox();
            this.lblSTWAccessBits2AKM1 = new System.Windows.Forms.Label();
            this.cboSTWAccessBits1AKM1 = new System.Windows.Forms.ComboBox();
            this.lblSTWAccessBits1AKM1 = new System.Windows.Forms.Label();
            this.lblSTWBlockOrSectorAddressAKM1 = new System.Windows.Forms.Label();
            this.cboSTWAccessBits0AKM1 = new System.Windows.Forms.ComboBox();
            this.lblSTWAccessBits0AKM1 = new System.Windows.Forms.Label();
            this.cboSTWAddressingModeAKM1 = new System.Windows.Forms.ComboBox();
            this.lblSTWAddressingModeAKM1 = new System.Windows.Forms.Label();
            this.tabSectorTrailerWriteAKM2 = new System.Windows.Forms.TabPage();
            this.txtSTWBlockOrSectorAddressAKM2 = new System.Windows.Forms.TextBox();
            this.btnSTWWriteAKM2 = new System.Windows.Forms.Button();
            this.txtSTWTrailerByte9AKM2 = new System.Windows.Forms.TextBox();
            this.lblSTWTrailerByte9AKM2 = new System.Windows.Forms.Label();
            this.cboSTWTrailerAccessBitsAKM2 = new System.Windows.Forms.ComboBox();
            this.lblSTWTrailerAccessBitsAKM2 = new System.Windows.Forms.Label();
            this.cboSTWAccessBits2AKM2 = new System.Windows.Forms.ComboBox();
            this.lblSTWAccessBits2AKM2 = new System.Windows.Forms.Label();
            this.cboSTWAccessBits1AKM2 = new System.Windows.Forms.ComboBox();
            this.lblSTWAccessBits1AKM2 = new System.Windows.Forms.Label();
            this.lblSTWBlockOrSectorAddressAKM2 = new System.Windows.Forms.Label();
            this.cboSTWAccessBits0AKM2 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboSTWAddressingModeAKM2 = new System.Windows.Forms.ComboBox();
            this.lblSTWAddressingModeAKM2 = new System.Windows.Forms.Label();
            this.tabSectorTrailerWritePK = new System.Windows.Forms.TabPage();
            this.txtSTWBlockOrSectorAddressPK = new System.Windows.Forms.TextBox();
            this.btnSTWWritePK = new System.Windows.Forms.Button();
            this.txtSTWTrailerByte9PK = new System.Windows.Forms.TextBox();
            this.lblSTWTrailerByte9PK = new System.Windows.Forms.Label();
            this.cboSTWTrailerAccessBitsPK = new System.Windows.Forms.ComboBox();
            this.lblSTWTrailerAccessBitsPK = new System.Windows.Forms.Label();
            this.cboSTWAccessBits2PK = new System.Windows.Forms.ComboBox();
            this.lblSTWAccessBits2PK = new System.Windows.Forms.Label();
            this.cboSTWAccessBits1PK = new System.Windows.Forms.ComboBox();
            this.lblSTWAccessBits1PK = new System.Windows.Forms.Label();
            this.lblSTWBlockOrSectorAddressPK = new System.Windows.Forms.Label();
            this.cboSTWAccessBits0PK = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cboSTWAddressingModePK = new System.Windows.Forms.ComboBox();
            this.lblSTWAddressingModePK = new System.Windows.Forms.Label();
            this.pnlAuth.SuspendLayout();
            this.stbFunctionError.SuspendLayout();
            this.pnlBoth_key.SuspendLayout();
            this.pnlKeyB.SuspendLayout();
            this.pnlKeyA.SuspendLayout();
            this.pgSectorTrailerWrite.SuspendLayout();
            this.tabSectorTrailerWrite.SuspendLayout();
            this.tabSectorTrailerWriteAKM1.SuspendLayout();
            this.tabSectorTrailerWriteAKM2.SuspendLayout();
            this.tabSectorTrailerWritePK.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlErr_expl
            // 
            this.pnlErr_expl.Name = "pnlErr_expl";
            this.pnlErr_expl.Size = new System.Drawing.Size(334, 17);
            this.pnlErr_expl.Spring = true;
            this.pnlErr_expl.Text = " ";
            // 
            // pnlAuth
            // 
            this.pnlAuth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAuth.Controls.Add(this.lblPKKey);
            this.pnlAuth.Controls.Add(this.cboKeyIndex);
            this.pnlAuth.Controls.Add(this.lblKeyIndex);
            this.pnlAuth.Controls.Add(this.rbAUTH1B);
            this.pnlAuth.Controls.Add(this.rbAUTH1A);
            this.pnlAuth.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAuth.Location = new System.Drawing.Point(0, 27);
            this.pnlAuth.Name = "pnlAuth";
            this.pnlAuth.Size = new System.Drawing.Size(533, 30);
            this.pnlAuth.TabIndex = 22;
            // 
            // lblPKKey
            // 
            this.lblPKKey.AutoSize = true;
            this.lblPKKey.Location = new System.Drawing.Point(303, 8);
            this.lblPKKey.Name = "lblPKKey";
            this.lblPKKey.Size = new System.Drawing.Size(48, 13);
            this.lblPKKey.TabIndex = 4;
            this.lblPKKey.Text = "PK Key";
            // 
            // cboKeyIndex
            // 
            this.cboKeyIndex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboKeyIndex.FormattingEnabled = true;
            this.cboKeyIndex.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cboKeyIndex.Location = new System.Drawing.Point(255, 4);
            this.cboKeyIndex.MaxDropDownItems = 15;
            this.cboKeyIndex.Name = "cboKeyIndex";
            this.cboKeyIndex.Size = new System.Drawing.Size(40, 21);
            this.cboKeyIndex.TabIndex = 3;
            // 
            // lblKeyIndex
            // 
            this.lblKeyIndex.AutoSize = true;
            this.lblKeyIndex.Location = new System.Drawing.Point(183, 8);
            this.lblKeyIndex.Name = "lblKeyIndex";
            this.lblKeyIndex.Size = new System.Drawing.Size(66, 13);
            this.lblKeyIndex.TabIndex = 2;
            this.lblKeyIndex.Text = "Key Index";
            // 
            // rbAUTH1B
            // 
            this.rbAUTH1B.AutoSize = true;
            this.rbAUTH1B.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAUTH1B.Location = new System.Drawing.Point(97, 6);
            this.rbAUTH1B.Name = "rbAUTH1B";
            this.rbAUTH1B.Size = new System.Drawing.Size(80, 17);
            this.rbAUTH1B.TabIndex = 1;
            this.rbAUTH1B.Text = "AUTH 1B";
            this.rbAUTH1B.UseVisualStyleBackColor = true;
            // 
            // rbAUTH1A
            // 
            this.rbAUTH1A.AutoSize = true;
            this.rbAUTH1A.Checked = true;
            this.rbAUTH1A.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAUTH1A.Location = new System.Drawing.Point(10, 6);
            this.rbAUTH1A.Name = "rbAUTH1A";
            this.rbAUTH1A.Size = new System.Drawing.Size(81, 17);
            this.rbAUTH1A.TabIndex = 0;
            this.rbAUTH1A.TabStop = true;
            this.rbAUTH1A.Text = "AUTH 1A";
            this.rbAUTH1A.UseVisualStyleBackColor = true;
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.White;
            this.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(533, 27);
            this.lblHeader.TabIndex = 21;
            this.lblHeader.Text = "Sector Trailer Write(AKM1,AKM2,PK)";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stbFunctionError
            // 
            this.stbFunctionError.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.stbFunctionError.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pnlFunct_error,
            this.pnlErr_code,
            this.pnlErr_expl});
            this.stbFunctionError.Location = new System.Drawing.Point(0, 354);
            this.stbFunctionError.Name = "stbFunctionError";
            this.stbFunctionError.Padding = new System.Windows.Forms.Padding(1, 0, 26, 0);
            this.stbFunctionError.Size = new System.Drawing.Size(533, 22);
            this.stbFunctionError.SizingGrip = false;
            this.stbFunctionError.TabIndex = 20;
            this.stbFunctionError.Text = " ";
            // 
            // pnlFunct_error
            // 
            this.pnlFunct_error.AutoSize = false;
            this.pnlFunct_error.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.pnlFunct_error.Name = "pnlFunct_error";
            this.pnlFunct_error.Size = new System.Drawing.Size(122, 17);
            this.pnlFunct_error.Text = "Function Error:";
            // 
            // pnlErr_code
            // 
            this.pnlErr_code.AutoSize = false;
            this.pnlErr_code.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.pnlErr_code.Name = "pnlErr_code";
            this.pnlErr_code.Size = new System.Drawing.Size(50, 17);
            // 
            // pnlBoth_key
            // 
            this.pnlBoth_key.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBoth_key.Controls.Add(this.pnlKeyB);
            this.pnlBoth_key.Controls.Add(this.pnlKeyA);
            this.pnlBoth_key.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBoth_key.Location = new System.Drawing.Point(0, 57);
            this.pnlBoth_key.Name = "pnlBoth_key";
            this.pnlBoth_key.Size = new System.Drawing.Size(533, 83);
            this.pnlBoth_key.TabIndex = 24;
            // 
            // pnlKeyB
            // 
            this.pnlKeyB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlKeyB.Controls.Add(this.chkHexKeyB);
            this.pnlKeyB.Controls.Add(this.lblKeyB);
            this.pnlKeyB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKeyB.Location = new System.Drawing.Point(266, 0);
            this.pnlKeyB.Name = "pnlKeyB";
            this.pnlKeyB.Size = new System.Drawing.Size(265, 81);
            this.pnlKeyB.TabIndex = 1;
            // 
            // chkHexKeyB
            // 
            this.chkHexKeyB.AutoSize = true;
            this.chkHexKeyB.Location = new System.Drawing.Point(36, 55);
            this.chkHexKeyB.Name = "chkHexKeyB";
            this.chkHexKeyB.Size = new System.Drawing.Size(48, 17);
            this.chkHexKeyB.TabIndex = 3;
            this.chkHexKeyB.Text = "Hex";
            this.chkHexKeyB.UseVisualStyleBackColor = true;
            this.chkHexKeyB.Click += new System.EventHandler(this.chkHexKeyB_Click);
            // 
            // lblKeyB
            // 
            this.lblKeyB.BackColor = System.Drawing.Color.White;
            this.lblKeyB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyB.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKeyB.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyB.Location = new System.Drawing.Point(0, 0);
            this.lblKeyB.Name = "lblKeyB";
            this.lblKeyB.Size = new System.Drawing.Size(261, 17);
            this.lblKeyB.TabIndex = 1;
            this.lblKeyB.Text = "KEY B";
            this.lblKeyB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlKeyA
            // 
            this.pnlKeyA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlKeyA.Controls.Add(this.chkHexKeyA);
            this.pnlKeyA.Controls.Add(this.lblKeyA);
            this.pnlKeyA.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlKeyA.Location = new System.Drawing.Point(0, 0);
            this.pnlKeyA.Name = "pnlKeyA";
            this.pnlKeyA.Size = new System.Drawing.Size(266, 81);
            this.pnlKeyA.TabIndex = 0;
            // 
            // chkHexKeyA
            // 
            this.chkHexKeyA.AutoSize = true;
            this.chkHexKeyA.Location = new System.Drawing.Point(33, 55);
            this.chkHexKeyA.Name = "chkHexKeyA";
            this.chkHexKeyA.Size = new System.Drawing.Size(48, 17);
            this.chkHexKeyA.TabIndex = 1;
            this.chkHexKeyA.Text = "Hex";
            this.chkHexKeyA.UseVisualStyleBackColor = true;
            this.chkHexKeyA.Click += new System.EventHandler(this.chkHexKeyA_Click);
            // 
            // lblKeyA
            // 
            this.lblKeyA.BackColor = System.Drawing.Color.White;
            this.lblKeyA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyA.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKeyA.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyA.Location = new System.Drawing.Point(0, 0);
            this.lblKeyA.Name = "lblKeyA";
            this.lblKeyA.Size = new System.Drawing.Size(262, 17);
            this.lblKeyA.TabIndex = 0;
            this.lblKeyA.Text = "KEY A";
            this.lblKeyA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pgSectorTrailerWrite
            // 
            this.pgSectorTrailerWrite.Controls.Add(this.tabSectorTrailerWrite);
            this.pgSectorTrailerWrite.Controls.Add(this.tabSectorTrailerWriteAKM1);
            this.pgSectorTrailerWrite.Controls.Add(this.tabSectorTrailerWriteAKM2);
            this.pgSectorTrailerWrite.Controls.Add(this.tabSectorTrailerWritePK);
            this.pgSectorTrailerWrite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgSectorTrailerWrite.Location = new System.Drawing.Point(0, 140);
            this.pgSectorTrailerWrite.Name = "pgSectorTrailerWrite";
            this.pgSectorTrailerWrite.SelectedIndex = 0;
            this.pgSectorTrailerWrite.Size = new System.Drawing.Size(533, 214);
            this.pgSectorTrailerWrite.TabIndex = 25;
            // 
            // tabSectorTrailerWrite
            // 
            this.tabSectorTrailerWrite.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabSectorTrailerWrite.Controls.Add(this.txtSTWBlockOrSectorAddress);
            this.tabSectorTrailerWrite.Controls.Add(this.btnSTWWrite);
            this.tabSectorTrailerWrite.Controls.Add(this.txtSTWTrailerByte9);
            this.tabSectorTrailerWrite.Controls.Add(this.lblSTWTrailerByte9);
            this.tabSectorTrailerWrite.Controls.Add(this.cboSTWTrailerAccessBits);
            this.tabSectorTrailerWrite.Controls.Add(this.lblSTWTrailerAccessBits);
            this.tabSectorTrailerWrite.Controls.Add(this.cboSTWAccessBits2);
            this.tabSectorTrailerWrite.Controls.Add(this.lblSTWAccessBits2);
            this.tabSectorTrailerWrite.Controls.Add(this.cboSTWAccessBits1);
            this.tabSectorTrailerWrite.Controls.Add(this.lblSTWAccessBits1);
            this.tabSectorTrailerWrite.Controls.Add(this.lblSTWBlockOrSectorAddress);
            this.tabSectorTrailerWrite.Controls.Add(this.cboSTWAccessBits0);
            this.tabSectorTrailerWrite.Controls.Add(this.lblSTWAccessBits0);
            this.tabSectorTrailerWrite.Controls.Add(this.cboSTWAddressingMode);
            this.tabSectorTrailerWrite.Controls.Add(this.lblSTWAddressingMode);
            this.tabSectorTrailerWrite.Location = new System.Drawing.Point(4, 22);
            this.tabSectorTrailerWrite.Name = "tabSectorTrailerWrite";
            this.tabSectorTrailerWrite.Padding = new System.Windows.Forms.Padding(3);
            this.tabSectorTrailerWrite.Size = new System.Drawing.Size(525, 188);
            this.tabSectorTrailerWrite.TabIndex = 0;
            this.tabSectorTrailerWrite.Text = "SectorTrailerWrite";
            this.tabSectorTrailerWrite.UseVisualStyleBackColor = true;
            // 
            // txtSTWBlockOrSectorAddress
            // 
            this.txtSTWBlockOrSectorAddress.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSTWBlockOrSectorAddress.Location = new System.Drawing.Point(198, 51);
            this.txtSTWBlockOrSectorAddress.MaxLength = 3;
            this.txtSTWBlockOrSectorAddress.Name = "txtSTWBlockOrSectorAddress";
            this.txtSTWBlockOrSectorAddress.Size = new System.Drawing.Size(40, 26);
            this.txtSTWBlockOrSectorAddress.TabIndex = 2;
            this.txtSTWBlockOrSectorAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSTWWrite
            // 
            this.btnSTWWrite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSTWWrite.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSTWWrite.Location = new System.Drawing.Point(283, 87);
            this.btnSTWWrite.Name = "btnSTWWrite";
            this.btnSTWWrite.Size = new System.Drawing.Size(179, 81);
            this.btnSTWWrite.TabIndex = 14;
            this.btnSTWWrite.Text = "WRITE";
            this.btnSTWWrite.UseVisualStyleBackColor = true;
            this.btnSTWWrite.Click += new System.EventHandler(this.btnSTWWrite_Click);
            // 
            // txtSTWTrailerByte9
            // 
            this.txtSTWTrailerByte9.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSTWTrailerByte9.Location = new System.Drawing.Point(424, 49);
            this.txtSTWTrailerByte9.Name = "txtSTWTrailerByte9";
            this.txtSTWTrailerByte9.Size = new System.Drawing.Size(39, 24);
            this.txtSTWTrailerByte9.TabIndex = 7;
            this.txtSTWTrailerByte9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSTWTrailerByte9
            // 
            this.lblSTWTrailerByte9.AutoSize = true;
            this.lblSTWTrailerByte9.Location = new System.Drawing.Point(279, 54);
            this.lblSTWTrailerByte9.Name = "lblSTWTrailerByte9";
            this.lblSTWTrailerByte9.Size = new System.Drawing.Size(85, 13);
            this.lblSTWTrailerByte9.TabIndex = 12;
            this.lblSTWTrailerByte9.Text = "Trailer Byte 9";
            // 
            // cboSTWTrailerAccessBits
            // 
            this.cboSTWTrailerAccessBits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboSTWTrailerAccessBits.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSTWTrailerAccessBits.FormattingEnabled = true;
            this.cboSTWTrailerAccessBits.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cboSTWTrailerAccessBits.Location = new System.Drawing.Point(424, 19);
            this.cboSTWTrailerAccessBits.Name = "cboSTWTrailerAccessBits";
            this.cboSTWTrailerAccessBits.Size = new System.Drawing.Size(39, 24);
            this.cboSTWTrailerAccessBits.TabIndex = 6;
            // 
            // lblSTWTrailerAccessBits
            // 
            this.lblSTWTrailerAccessBits.AutoSize = true;
            this.lblSTWTrailerAccessBits.Location = new System.Drawing.Point(279, 24);
            this.lblSTWTrailerAccessBits.Name = "lblSTWTrailerAccessBits";
            this.lblSTWTrailerAccessBits.Size = new System.Drawing.Size(112, 13);
            this.lblSTWTrailerAccessBits.TabIndex = 10;
            this.lblSTWTrailerAccessBits.Text = "Trailer Access Bits";
            // 
            // cboSTWAccessBits2
            // 
            this.cboSTWAccessBits2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboSTWAccessBits2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSTWAccessBits2.FormattingEnabled = true;
            this.cboSTWAccessBits2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cboSTWAccessBits2.Location = new System.Drawing.Point(198, 145);
            this.cboSTWAccessBits2.Name = "cboSTWAccessBits2";
            this.cboSTWAccessBits2.Size = new System.Drawing.Size(39, 24);
            this.cboSTWAccessBits2.TabIndex = 5;
            // 
            // lblSTWAccessBits2
            // 
            this.lblSTWAccessBits2.AutoSize = true;
            this.lblSTWAccessBits2.Location = new System.Drawing.Point(53, 150);
            this.lblSTWAccessBits2.Name = "lblSTWAccessBits2";
            this.lblSTWAccessBits2.Size = new System.Drawing.Size(82, 13);
            this.lblSTWAccessBits2.TabIndex = 8;
            this.lblSTWAccessBits2.Text = "Access Bits 2";
            // 
            // cboSTWAccessBits1
            // 
            this.cboSTWAccessBits1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboSTWAccessBits1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSTWAccessBits1.FormattingEnabled = true;
            this.cboSTWAccessBits1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cboSTWAccessBits1.Location = new System.Drawing.Point(198, 115);
            this.cboSTWAccessBits1.Name = "cboSTWAccessBits1";
            this.cboSTWAccessBits1.Size = new System.Drawing.Size(39, 24);
            this.cboSTWAccessBits1.TabIndex = 4;
            // 
            // lblSTWAccessBits1
            // 
            this.lblSTWAccessBits1.AutoSize = true;
            this.lblSTWAccessBits1.Location = new System.Drawing.Point(53, 120);
            this.lblSTWAccessBits1.Name = "lblSTWAccessBits1";
            this.lblSTWAccessBits1.Size = new System.Drawing.Size(82, 13);
            this.lblSTWAccessBits1.TabIndex = 6;
            this.lblSTWAccessBits1.Text = "Access Bits 1";
            // 
            // lblSTWBlockOrSectorAddress
            // 
            this.lblSTWBlockOrSectorAddress.AutoSize = true;
            this.lblSTWBlockOrSectorAddress.Location = new System.Drawing.Point(53, 54);
            this.lblSTWBlockOrSectorAddress.Name = "lblSTWBlockOrSectorAddress";
            this.lblSTWBlockOrSectorAddress.Size = new System.Drawing.Size(145, 13);
            this.lblSTWBlockOrSectorAddress.TabIndex = 4;
            this.lblSTWBlockOrSectorAddress.Text = "Block or Sector Address";
            // 
            // cboSTWAccessBits0
            // 
            this.cboSTWAccessBits0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboSTWAccessBits0.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSTWAccessBits0.FormattingEnabled = true;
            this.cboSTWAccessBits0.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cboSTWAccessBits0.Location = new System.Drawing.Point(198, 85);
            this.cboSTWAccessBits0.Name = "cboSTWAccessBits0";
            this.cboSTWAccessBits0.Size = new System.Drawing.Size(39, 24);
            this.cboSTWAccessBits0.TabIndex = 3;
            // 
            // lblSTWAccessBits0
            // 
            this.lblSTWAccessBits0.AutoSize = true;
            this.lblSTWAccessBits0.Location = new System.Drawing.Point(53, 90);
            this.lblSTWAccessBits0.Name = "lblSTWAccessBits0";
            this.lblSTWAccessBits0.Size = new System.Drawing.Size(82, 13);
            this.lblSTWAccessBits0.TabIndex = 2;
            this.lblSTWAccessBits0.Text = "Access Bits 0";
            // 
            // cboSTWAddressingMode
            // 
            this.cboSTWAddressingMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboSTWAddressingMode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSTWAddressingMode.FormattingEnabled = true;
            this.cboSTWAddressingMode.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cboSTWAddressingMode.Location = new System.Drawing.Point(198, 19);
            this.cboSTWAddressingMode.Name = "cboSTWAddressingMode";
            this.cboSTWAddressingMode.Size = new System.Drawing.Size(39, 24);
            this.cboSTWAddressingMode.TabIndex = 1;
            // 
            // lblSTWAddressingMode
            // 
            this.lblSTWAddressingMode.AutoSize = true;
            this.lblSTWAddressingMode.Location = new System.Drawing.Point(53, 24);
            this.lblSTWAddressingMode.Name = "lblSTWAddressingMode";
            this.lblSTWAddressingMode.Size = new System.Drawing.Size(104, 13);
            this.lblSTWAddressingMode.TabIndex = 0;
            this.lblSTWAddressingMode.Text = "Addressing Mode";
            // 
            // tabSectorTrailerWriteAKM1
            // 
            this.tabSectorTrailerWriteAKM1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabSectorTrailerWriteAKM1.Controls.Add(this.txtSTWBlockOrSectorAddressAKM1);
            this.tabSectorTrailerWriteAKM1.Controls.Add(this.btnSTWWriteAKM1);
            this.tabSectorTrailerWriteAKM1.Controls.Add(this.txtSTWTrailerByte9AKM1);
            this.tabSectorTrailerWriteAKM1.Controls.Add(this.lblSTWTrailerByte9AKM1);
            this.tabSectorTrailerWriteAKM1.Controls.Add(this.cboSTWTrailerAccessBitsAKM1);
            this.tabSectorTrailerWriteAKM1.Controls.Add(this.lblSTWTrailerAccessBitsAKM1);
            this.tabSectorTrailerWriteAKM1.Controls.Add(this.cboSTWAccessBits2AKM1);
            this.tabSectorTrailerWriteAKM1.Controls.Add(this.lblSTWAccessBits2AKM1);
            this.tabSectorTrailerWriteAKM1.Controls.Add(this.cboSTWAccessBits1AKM1);
            this.tabSectorTrailerWriteAKM1.Controls.Add(this.lblSTWAccessBits1AKM1);
            this.tabSectorTrailerWriteAKM1.Controls.Add(this.lblSTWBlockOrSectorAddressAKM1);
            this.tabSectorTrailerWriteAKM1.Controls.Add(this.cboSTWAccessBits0AKM1);
            this.tabSectorTrailerWriteAKM1.Controls.Add(this.lblSTWAccessBits0AKM1);
            this.tabSectorTrailerWriteAKM1.Controls.Add(this.cboSTWAddressingModeAKM1);
            this.tabSectorTrailerWriteAKM1.Controls.Add(this.lblSTWAddressingModeAKM1);
            this.tabSectorTrailerWriteAKM1.Location = new System.Drawing.Point(4, 22);
            this.tabSectorTrailerWriteAKM1.Name = "tabSectorTrailerWriteAKM1";
            this.tabSectorTrailerWriteAKM1.Padding = new System.Windows.Forms.Padding(3);
            this.tabSectorTrailerWriteAKM1.Size = new System.Drawing.Size(525, 188);
            this.tabSectorTrailerWriteAKM1.TabIndex = 1;
            this.tabSectorTrailerWriteAKM1.Text = "SectorTrailerWrite_AKM1";
            this.tabSectorTrailerWriteAKM1.UseVisualStyleBackColor = true;
            // 
            // txtSTWBlockOrSectorAddressAKM1
            // 
            this.txtSTWBlockOrSectorAddressAKM1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSTWBlockOrSectorAddressAKM1.Location = new System.Drawing.Point(199, 45);
            this.txtSTWBlockOrSectorAddressAKM1.MaxLength = 3;
            this.txtSTWBlockOrSectorAddressAKM1.Name = "txtSTWBlockOrSectorAddressAKM1";
            this.txtSTWBlockOrSectorAddressAKM1.Size = new System.Drawing.Size(40, 26);
            this.txtSTWBlockOrSectorAddressAKM1.TabIndex = 1;
            this.txtSTWBlockOrSectorAddressAKM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSTWWriteAKM1
            // 
            this.btnSTWWriteAKM1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSTWWriteAKM1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSTWWriteAKM1.Location = new System.Drawing.Point(285, 85);
            this.btnSTWWriteAKM1.Name = "btnSTWWriteAKM1";
            this.btnSTWWriteAKM1.Size = new System.Drawing.Size(179, 81);
            this.btnSTWWriteAKM1.TabIndex = 29;
            this.btnSTWWriteAKM1.Text = "WRITE";
            this.btnSTWWriteAKM1.UseVisualStyleBackColor = true;
            this.btnSTWWriteAKM1.Click += new System.EventHandler(this.btnSTWWriteAKM1_Click);
            // 
            // txtSTWTrailerByte9AKM1
            // 
            this.txtSTWTrailerByte9AKM1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSTWTrailerByte9AKM1.Location = new System.Drawing.Point(426, 47);
            this.txtSTWTrailerByte9AKM1.Name = "txtSTWTrailerByte9AKM1";
            this.txtSTWTrailerByte9AKM1.Size = new System.Drawing.Size(39, 24);
            this.txtSTWTrailerByte9AKM1.TabIndex = 6;
            this.txtSTWTrailerByte9AKM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSTWTrailerByte9AKM1
            // 
            this.lblSTWTrailerByte9AKM1.AutoSize = true;
            this.lblSTWTrailerByte9AKM1.Location = new System.Drawing.Point(281, 52);
            this.lblSTWTrailerByte9AKM1.Name = "lblSTWTrailerByte9AKM1";
            this.lblSTWTrailerByte9AKM1.Size = new System.Drawing.Size(85, 13);
            this.lblSTWTrailerByte9AKM1.TabIndex = 28;
            this.lblSTWTrailerByte9AKM1.Text = "Trailer Byte 9";
            // 
            // cboSTWTrailerAccessBitsAKM1
            // 
            this.cboSTWTrailerAccessBitsAKM1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboSTWTrailerAccessBitsAKM1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSTWTrailerAccessBitsAKM1.FormattingEnabled = true;
            this.cboSTWTrailerAccessBitsAKM1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cboSTWTrailerAccessBitsAKM1.Location = new System.Drawing.Point(426, 17);
            this.cboSTWTrailerAccessBitsAKM1.Name = "cboSTWTrailerAccessBitsAKM1";
            this.cboSTWTrailerAccessBitsAKM1.Size = new System.Drawing.Size(39, 24);
            this.cboSTWTrailerAccessBitsAKM1.TabIndex = 5;
            // 
            // lblSTWTrailerAccessBitsAKM1
            // 
            this.lblSTWTrailerAccessBitsAKM1.AutoSize = true;
            this.lblSTWTrailerAccessBitsAKM1.Location = new System.Drawing.Point(281, 22);
            this.lblSTWTrailerAccessBitsAKM1.Name = "lblSTWTrailerAccessBitsAKM1";
            this.lblSTWTrailerAccessBitsAKM1.Size = new System.Drawing.Size(112, 13);
            this.lblSTWTrailerAccessBitsAKM1.TabIndex = 27;
            this.lblSTWTrailerAccessBitsAKM1.Text = "Trailer Access Bits";
            // 
            // cboSTWAccessBits2AKM1
            // 
            this.cboSTWAccessBits2AKM1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboSTWAccessBits2AKM1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSTWAccessBits2AKM1.FormattingEnabled = true;
            this.cboSTWAccessBits2AKM1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cboSTWAccessBits2AKM1.Location = new System.Drawing.Point(200, 143);
            this.cboSTWAccessBits2AKM1.Name = "cboSTWAccessBits2AKM1";
            this.cboSTWAccessBits2AKM1.Size = new System.Drawing.Size(39, 24);
            this.cboSTWAccessBits2AKM1.TabIndex = 4;
            // 
            // lblSTWAccessBits2AKM1
            // 
            this.lblSTWAccessBits2AKM1.AutoSize = true;
            this.lblSTWAccessBits2AKM1.Location = new System.Drawing.Point(55, 148);
            this.lblSTWAccessBits2AKM1.Name = "lblSTWAccessBits2AKM1";
            this.lblSTWAccessBits2AKM1.Size = new System.Drawing.Size(82, 13);
            this.lblSTWAccessBits2AKM1.TabIndex = 26;
            this.lblSTWAccessBits2AKM1.Text = "Access Bits 2";
            // 
            // cboSTWAccessBits1AKM1
            // 
            this.cboSTWAccessBits1AKM1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboSTWAccessBits1AKM1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSTWAccessBits1AKM1.FormattingEnabled = true;
            this.cboSTWAccessBits1AKM1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cboSTWAccessBits1AKM1.Location = new System.Drawing.Point(200, 113);
            this.cboSTWAccessBits1AKM1.Name = "cboSTWAccessBits1AKM1";
            this.cboSTWAccessBits1AKM1.Size = new System.Drawing.Size(39, 24);
            this.cboSTWAccessBits1AKM1.TabIndex = 3;
            // 
            // lblSTWAccessBits1AKM1
            // 
            this.lblSTWAccessBits1AKM1.AutoSize = true;
            this.lblSTWAccessBits1AKM1.Location = new System.Drawing.Point(55, 118);
            this.lblSTWAccessBits1AKM1.Name = "lblSTWAccessBits1AKM1";
            this.lblSTWAccessBits1AKM1.Size = new System.Drawing.Size(82, 13);
            this.lblSTWAccessBits1AKM1.TabIndex = 23;
            this.lblSTWAccessBits1AKM1.Text = "Access Bits 1";
            // 
            // lblSTWBlockOrSectorAddressAKM1
            // 
            this.lblSTWBlockOrSectorAddressAKM1.AutoSize = true;
            this.lblSTWBlockOrSectorAddressAKM1.Location = new System.Drawing.Point(55, 52);
            this.lblSTWBlockOrSectorAddressAKM1.Name = "lblSTWBlockOrSectorAddressAKM1";
            this.lblSTWBlockOrSectorAddressAKM1.Size = new System.Drawing.Size(145, 13);
            this.lblSTWBlockOrSectorAddressAKM1.TabIndex = 21;
            this.lblSTWBlockOrSectorAddressAKM1.Text = "Block or Sector Address";
            // 
            // cboSTWAccessBits0AKM1
            // 
            this.cboSTWAccessBits0AKM1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboSTWAccessBits0AKM1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSTWAccessBits0AKM1.FormattingEnabled = true;
            this.cboSTWAccessBits0AKM1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cboSTWAccessBits0AKM1.Location = new System.Drawing.Point(200, 83);
            this.cboSTWAccessBits0AKM1.Name = "cboSTWAccessBits0AKM1";
            this.cboSTWAccessBits0AKM1.Size = new System.Drawing.Size(39, 24);
            this.cboSTWAccessBits0AKM1.TabIndex = 2;
            // 
            // lblSTWAccessBits0AKM1
            // 
            this.lblSTWAccessBits0AKM1.AutoSize = true;
            this.lblSTWAccessBits0AKM1.Location = new System.Drawing.Point(55, 88);
            this.lblSTWAccessBits0AKM1.Name = "lblSTWAccessBits0AKM1";
            this.lblSTWAccessBits0AKM1.Size = new System.Drawing.Size(82, 13);
            this.lblSTWAccessBits0AKM1.TabIndex = 18;
            this.lblSTWAccessBits0AKM1.Text = "Access Bits 0";
            // 
            // cboSTWAddressingModeAKM1
            // 
            this.cboSTWAddressingModeAKM1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboSTWAddressingModeAKM1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSTWAddressingModeAKM1.FormattingEnabled = true;
            this.cboSTWAddressingModeAKM1.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cboSTWAddressingModeAKM1.Location = new System.Drawing.Point(200, 17);
            this.cboSTWAddressingModeAKM1.Name = "cboSTWAddressingModeAKM1";
            this.cboSTWAddressingModeAKM1.Size = new System.Drawing.Size(39, 24);
            this.cboSTWAddressingModeAKM1.TabIndex = 0;
            // 
            // lblSTWAddressingModeAKM1
            // 
            this.lblSTWAddressingModeAKM1.AutoSize = true;
            this.lblSTWAddressingModeAKM1.Location = new System.Drawing.Point(55, 22);
            this.lblSTWAddressingModeAKM1.Name = "lblSTWAddressingModeAKM1";
            this.lblSTWAddressingModeAKM1.Size = new System.Drawing.Size(104, 13);
            this.lblSTWAddressingModeAKM1.TabIndex = 15;
            this.lblSTWAddressingModeAKM1.Text = "Addressing Mode";
            // 
            // tabSectorTrailerWriteAKM2
            // 
            this.tabSectorTrailerWriteAKM2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabSectorTrailerWriteAKM2.Controls.Add(this.txtSTWBlockOrSectorAddressAKM2);
            this.tabSectorTrailerWriteAKM2.Controls.Add(this.btnSTWWriteAKM2);
            this.tabSectorTrailerWriteAKM2.Controls.Add(this.txtSTWTrailerByte9AKM2);
            this.tabSectorTrailerWriteAKM2.Controls.Add(this.lblSTWTrailerByte9AKM2);
            this.tabSectorTrailerWriteAKM2.Controls.Add(this.cboSTWTrailerAccessBitsAKM2);
            this.tabSectorTrailerWriteAKM2.Controls.Add(this.lblSTWTrailerAccessBitsAKM2);
            this.tabSectorTrailerWriteAKM2.Controls.Add(this.cboSTWAccessBits2AKM2);
            this.tabSectorTrailerWriteAKM2.Controls.Add(this.lblSTWAccessBits2AKM2);
            this.tabSectorTrailerWriteAKM2.Controls.Add(this.cboSTWAccessBits1AKM2);
            this.tabSectorTrailerWriteAKM2.Controls.Add(this.lblSTWAccessBits1AKM2);
            this.tabSectorTrailerWriteAKM2.Controls.Add(this.lblSTWBlockOrSectorAddressAKM2);
            this.tabSectorTrailerWriteAKM2.Controls.Add(this.cboSTWAccessBits0AKM2);
            this.tabSectorTrailerWriteAKM2.Controls.Add(this.label13);
            this.tabSectorTrailerWriteAKM2.Controls.Add(this.cboSTWAddressingModeAKM2);
            this.tabSectorTrailerWriteAKM2.Controls.Add(this.lblSTWAddressingModeAKM2);
            this.tabSectorTrailerWriteAKM2.Location = new System.Drawing.Point(4, 22);
            this.tabSectorTrailerWriteAKM2.Name = "tabSectorTrailerWriteAKM2";
            this.tabSectorTrailerWriteAKM2.Padding = new System.Windows.Forms.Padding(3);
            this.tabSectorTrailerWriteAKM2.Size = new System.Drawing.Size(525, 188);
            this.tabSectorTrailerWriteAKM2.TabIndex = 2;
            this.tabSectorTrailerWriteAKM2.Text = "SectorTrailerWrite_AKM2";
            this.tabSectorTrailerWriteAKM2.UseVisualStyleBackColor = true;
            // 
            // txtSTWBlockOrSectorAddressAKM2
            // 
            this.txtSTWBlockOrSectorAddressAKM2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSTWBlockOrSectorAddressAKM2.Location = new System.Drawing.Point(200, 47);
            this.txtSTWBlockOrSectorAddressAKM2.MaxLength = 3;
            this.txtSTWBlockOrSectorAddressAKM2.Name = "txtSTWBlockOrSectorAddressAKM2";
            this.txtSTWBlockOrSectorAddressAKM2.Size = new System.Drawing.Size(40, 26);
            this.txtSTWBlockOrSectorAddressAKM2.TabIndex = 1;
            this.txtSTWBlockOrSectorAddressAKM2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSTWWriteAKM2
            // 
            this.btnSTWWriteAKM2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSTWWriteAKM2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSTWWriteAKM2.Location = new System.Drawing.Point(285, 85);
            this.btnSTWWriteAKM2.Name = "btnSTWWriteAKM2";
            this.btnSTWWriteAKM2.Size = new System.Drawing.Size(179, 81);
            this.btnSTWWriteAKM2.TabIndex = 29;
            this.btnSTWWriteAKM2.Text = "WRITE";
            this.btnSTWWriteAKM2.UseVisualStyleBackColor = true;
            this.btnSTWWriteAKM2.Click += new System.EventHandler(this.btnSTWWriteAKM2_Click);
            // 
            // txtSTWTrailerByte9AKM2
            // 
            this.txtSTWTrailerByte9AKM2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSTWTrailerByte9AKM2.Location = new System.Drawing.Point(426, 47);
            this.txtSTWTrailerByte9AKM2.Name = "txtSTWTrailerByte9AKM2";
            this.txtSTWTrailerByte9AKM2.Size = new System.Drawing.Size(39, 24);
            this.txtSTWTrailerByte9AKM2.TabIndex = 6;
            this.txtSTWTrailerByte9AKM2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSTWTrailerByte9AKM2
            // 
            this.lblSTWTrailerByte9AKM2.AutoSize = true;
            this.lblSTWTrailerByte9AKM2.Location = new System.Drawing.Point(281, 52);
            this.lblSTWTrailerByte9AKM2.Name = "lblSTWTrailerByte9AKM2";
            this.lblSTWTrailerByte9AKM2.Size = new System.Drawing.Size(85, 13);
            this.lblSTWTrailerByte9AKM2.TabIndex = 28;
            this.lblSTWTrailerByte9AKM2.Text = "Trailer Byte 9";
            // 
            // cboSTWTrailerAccessBitsAKM2
            // 
            this.cboSTWTrailerAccessBitsAKM2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboSTWTrailerAccessBitsAKM2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSTWTrailerAccessBitsAKM2.FormattingEnabled = true;
            this.cboSTWTrailerAccessBitsAKM2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cboSTWTrailerAccessBitsAKM2.Location = new System.Drawing.Point(426, 17);
            this.cboSTWTrailerAccessBitsAKM2.Name = "cboSTWTrailerAccessBitsAKM2";
            this.cboSTWTrailerAccessBitsAKM2.Size = new System.Drawing.Size(39, 24);
            this.cboSTWTrailerAccessBitsAKM2.TabIndex = 5;
            // 
            // lblSTWTrailerAccessBitsAKM2
            // 
            this.lblSTWTrailerAccessBitsAKM2.AutoSize = true;
            this.lblSTWTrailerAccessBitsAKM2.Location = new System.Drawing.Point(281, 22);
            this.lblSTWTrailerAccessBitsAKM2.Name = "lblSTWTrailerAccessBitsAKM2";
            this.lblSTWTrailerAccessBitsAKM2.Size = new System.Drawing.Size(112, 13);
            this.lblSTWTrailerAccessBitsAKM2.TabIndex = 27;
            this.lblSTWTrailerAccessBitsAKM2.Text = "Trailer Access Bits";
            // 
            // cboSTWAccessBits2AKM2
            // 
            this.cboSTWAccessBits2AKM2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboSTWAccessBits2AKM2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSTWAccessBits2AKM2.FormattingEnabled = true;
            this.cboSTWAccessBits2AKM2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cboSTWAccessBits2AKM2.Location = new System.Drawing.Point(200, 143);
            this.cboSTWAccessBits2AKM2.Name = "cboSTWAccessBits2AKM2";
            this.cboSTWAccessBits2AKM2.Size = new System.Drawing.Size(39, 24);
            this.cboSTWAccessBits2AKM2.TabIndex = 4;
            // 
            // lblSTWAccessBits2AKM2
            // 
            this.lblSTWAccessBits2AKM2.AutoSize = true;
            this.lblSTWAccessBits2AKM2.Location = new System.Drawing.Point(55, 148);
            this.lblSTWAccessBits2AKM2.Name = "lblSTWAccessBits2AKM2";
            this.lblSTWAccessBits2AKM2.Size = new System.Drawing.Size(82, 13);
            this.lblSTWAccessBits2AKM2.TabIndex = 26;
            this.lblSTWAccessBits2AKM2.Text = "Access Bits 2";
            // 
            // cboSTWAccessBits1AKM2
            // 
            this.cboSTWAccessBits1AKM2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboSTWAccessBits1AKM2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSTWAccessBits1AKM2.FormattingEnabled = true;
            this.cboSTWAccessBits1AKM2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cboSTWAccessBits1AKM2.Location = new System.Drawing.Point(200, 113);
            this.cboSTWAccessBits1AKM2.Name = "cboSTWAccessBits1AKM2";
            this.cboSTWAccessBits1AKM2.Size = new System.Drawing.Size(39, 24);
            this.cboSTWAccessBits1AKM2.TabIndex = 3;
            // 
            // lblSTWAccessBits1AKM2
            // 
            this.lblSTWAccessBits1AKM2.AutoSize = true;
            this.lblSTWAccessBits1AKM2.Location = new System.Drawing.Point(55, 118);
            this.lblSTWAccessBits1AKM2.Name = "lblSTWAccessBits1AKM2";
            this.lblSTWAccessBits1AKM2.Size = new System.Drawing.Size(82, 13);
            this.lblSTWAccessBits1AKM2.TabIndex = 23;
            this.lblSTWAccessBits1AKM2.Text = "Access Bits 1";
            // 
            // lblSTWBlockOrSectorAddressAKM2
            // 
            this.lblSTWBlockOrSectorAddressAKM2.AutoSize = true;
            this.lblSTWBlockOrSectorAddressAKM2.Location = new System.Drawing.Point(55, 52);
            this.lblSTWBlockOrSectorAddressAKM2.Name = "lblSTWBlockOrSectorAddressAKM2";
            this.lblSTWBlockOrSectorAddressAKM2.Size = new System.Drawing.Size(145, 13);
            this.lblSTWBlockOrSectorAddressAKM2.TabIndex = 21;
            this.lblSTWBlockOrSectorAddressAKM2.Text = "Block or Sector Address";
            // 
            // cboSTWAccessBits0AKM2
            // 
            this.cboSTWAccessBits0AKM2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboSTWAccessBits0AKM2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSTWAccessBits0AKM2.FormattingEnabled = true;
            this.cboSTWAccessBits0AKM2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cboSTWAccessBits0AKM2.Location = new System.Drawing.Point(200, 83);
            this.cboSTWAccessBits0AKM2.Name = "cboSTWAccessBits0AKM2";
            this.cboSTWAccessBits0AKM2.Size = new System.Drawing.Size(39, 24);
            this.cboSTWAccessBits0AKM2.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(55, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Access Bits 0";
            // 
            // cboSTWAddressingModeAKM2
            // 
            this.cboSTWAddressingModeAKM2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboSTWAddressingModeAKM2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSTWAddressingModeAKM2.FormattingEnabled = true;
            this.cboSTWAddressingModeAKM2.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cboSTWAddressingModeAKM2.Location = new System.Drawing.Point(200, 17);
            this.cboSTWAddressingModeAKM2.Name = "cboSTWAddressingModeAKM2";
            this.cboSTWAddressingModeAKM2.Size = new System.Drawing.Size(39, 24);
            this.cboSTWAddressingModeAKM2.TabIndex = 0;
            // 
            // lblSTWAddressingModeAKM2
            // 
            this.lblSTWAddressingModeAKM2.AutoSize = true;
            this.lblSTWAddressingModeAKM2.Location = new System.Drawing.Point(55, 22);
            this.lblSTWAddressingModeAKM2.Name = "lblSTWAddressingModeAKM2";
            this.lblSTWAddressingModeAKM2.Size = new System.Drawing.Size(104, 13);
            this.lblSTWAddressingModeAKM2.TabIndex = 15;
            this.lblSTWAddressingModeAKM2.Text = "Addressing Mode";
            // 
            // tabSectorTrailerWritePK
            // 
            this.tabSectorTrailerWritePK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabSectorTrailerWritePK.Controls.Add(this.txtSTWBlockOrSectorAddressPK);
            this.tabSectorTrailerWritePK.Controls.Add(this.btnSTWWritePK);
            this.tabSectorTrailerWritePK.Controls.Add(this.txtSTWTrailerByte9PK);
            this.tabSectorTrailerWritePK.Controls.Add(this.lblSTWTrailerByte9PK);
            this.tabSectorTrailerWritePK.Controls.Add(this.cboSTWTrailerAccessBitsPK);
            this.tabSectorTrailerWritePK.Controls.Add(this.lblSTWTrailerAccessBitsPK);
            this.tabSectorTrailerWritePK.Controls.Add(this.cboSTWAccessBits2PK);
            this.tabSectorTrailerWritePK.Controls.Add(this.lblSTWAccessBits2PK);
            this.tabSectorTrailerWritePK.Controls.Add(this.cboSTWAccessBits1PK);
            this.tabSectorTrailerWritePK.Controls.Add(this.lblSTWAccessBits1PK);
            this.tabSectorTrailerWritePK.Controls.Add(this.lblSTWBlockOrSectorAddressPK);
            this.tabSectorTrailerWritePK.Controls.Add(this.cboSTWAccessBits0PK);
            this.tabSectorTrailerWritePK.Controls.Add(this.label20);
            this.tabSectorTrailerWritePK.Controls.Add(this.cboSTWAddressingModePK);
            this.tabSectorTrailerWritePK.Controls.Add(this.lblSTWAddressingModePK);
            this.tabSectorTrailerWritePK.Location = new System.Drawing.Point(4, 22);
            this.tabSectorTrailerWritePK.Name = "tabSectorTrailerWritePK";
            this.tabSectorTrailerWritePK.Padding = new System.Windows.Forms.Padding(3);
            this.tabSectorTrailerWritePK.Size = new System.Drawing.Size(525, 188);
            this.tabSectorTrailerWritePK.TabIndex = 3;
            this.tabSectorTrailerWritePK.Text = "SectorTrailerWrite_PK";
            this.tabSectorTrailerWritePK.UseVisualStyleBackColor = true;
            // 
            // txtSTWBlockOrSectorAddressPK
            // 
            this.txtSTWBlockOrSectorAddressPK.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSTWBlockOrSectorAddressPK.Location = new System.Drawing.Point(200, 47);
            this.txtSTWBlockOrSectorAddressPK.MaxLength = 3;
            this.txtSTWBlockOrSectorAddressPK.Name = "txtSTWBlockOrSectorAddressPK";
            this.txtSTWBlockOrSectorAddressPK.Size = new System.Drawing.Size(40, 26);
            this.txtSTWBlockOrSectorAddressPK.TabIndex = 1;
            this.txtSTWBlockOrSectorAddressPK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSTWWritePK
            // 
            this.btnSTWWritePK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSTWWritePK.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSTWWritePK.Location = new System.Drawing.Point(285, 85);
            this.btnSTWWritePK.Name = "btnSTWWritePK";
            this.btnSTWWritePK.Size = new System.Drawing.Size(179, 81);
            this.btnSTWWritePK.TabIndex = 29;
            this.btnSTWWritePK.Text = "WRITE";
            this.btnSTWWritePK.UseVisualStyleBackColor = true;
            this.btnSTWWritePK.Click += new System.EventHandler(this.btnSTWWritePK_Click);
            // 
            // txtSTWTrailerByte9PK
            // 
            this.txtSTWTrailerByte9PK.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSTWTrailerByte9PK.Location = new System.Drawing.Point(426, 47);
            this.txtSTWTrailerByte9PK.Name = "txtSTWTrailerByte9PK";
            this.txtSTWTrailerByte9PK.Size = new System.Drawing.Size(39, 24);
            this.txtSTWTrailerByte9PK.TabIndex = 6;
            this.txtSTWTrailerByte9PK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSTWTrailerByte9PK
            // 
            this.lblSTWTrailerByte9PK.AutoSize = true;
            this.lblSTWTrailerByte9PK.Location = new System.Drawing.Point(281, 52);
            this.lblSTWTrailerByte9PK.Name = "lblSTWTrailerByte9PK";
            this.lblSTWTrailerByte9PK.Size = new System.Drawing.Size(85, 13);
            this.lblSTWTrailerByte9PK.TabIndex = 28;
            this.lblSTWTrailerByte9PK.Text = "Trailer Byte 9";
            // 
            // cboSTWTrailerAccessBitsPK
            // 
            this.cboSTWTrailerAccessBitsPK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboSTWTrailerAccessBitsPK.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSTWTrailerAccessBitsPK.FormattingEnabled = true;
            this.cboSTWTrailerAccessBitsPK.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cboSTWTrailerAccessBitsPK.Location = new System.Drawing.Point(426, 17);
            this.cboSTWTrailerAccessBitsPK.Name = "cboSTWTrailerAccessBitsPK";
            this.cboSTWTrailerAccessBitsPK.Size = new System.Drawing.Size(39, 24);
            this.cboSTWTrailerAccessBitsPK.TabIndex = 5;
            // 
            // lblSTWTrailerAccessBitsPK
            // 
            this.lblSTWTrailerAccessBitsPK.AutoSize = true;
            this.lblSTWTrailerAccessBitsPK.Location = new System.Drawing.Point(281, 22);
            this.lblSTWTrailerAccessBitsPK.Name = "lblSTWTrailerAccessBitsPK";
            this.lblSTWTrailerAccessBitsPK.Size = new System.Drawing.Size(112, 13);
            this.lblSTWTrailerAccessBitsPK.TabIndex = 27;
            this.lblSTWTrailerAccessBitsPK.Text = "Trailer Access Bits";
            // 
            // cboSTWAccessBits2PK
            // 
            this.cboSTWAccessBits2PK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboSTWAccessBits2PK.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSTWAccessBits2PK.FormattingEnabled = true;
            this.cboSTWAccessBits2PK.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cboSTWAccessBits2PK.Location = new System.Drawing.Point(200, 143);
            this.cboSTWAccessBits2PK.Name = "cboSTWAccessBits2PK";
            this.cboSTWAccessBits2PK.Size = new System.Drawing.Size(39, 24);
            this.cboSTWAccessBits2PK.TabIndex = 4;
            // 
            // lblSTWAccessBits2PK
            // 
            this.lblSTWAccessBits2PK.AutoSize = true;
            this.lblSTWAccessBits2PK.Location = new System.Drawing.Point(55, 148);
            this.lblSTWAccessBits2PK.Name = "lblSTWAccessBits2PK";
            this.lblSTWAccessBits2PK.Size = new System.Drawing.Size(82, 13);
            this.lblSTWAccessBits2PK.TabIndex = 26;
            this.lblSTWAccessBits2PK.Text = "Access Bits 2";
            // 
            // cboSTWAccessBits1PK
            // 
            this.cboSTWAccessBits1PK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboSTWAccessBits1PK.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSTWAccessBits1PK.FormattingEnabled = true;
            this.cboSTWAccessBits1PK.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cboSTWAccessBits1PK.Location = new System.Drawing.Point(200, 113);
            this.cboSTWAccessBits1PK.Name = "cboSTWAccessBits1PK";
            this.cboSTWAccessBits1PK.Size = new System.Drawing.Size(39, 24);
            this.cboSTWAccessBits1PK.TabIndex = 3;
            // 
            // lblSTWAccessBits1PK
            // 
            this.lblSTWAccessBits1PK.AutoSize = true;
            this.lblSTWAccessBits1PK.Location = new System.Drawing.Point(55, 118);
            this.lblSTWAccessBits1PK.Name = "lblSTWAccessBits1PK";
            this.lblSTWAccessBits1PK.Size = new System.Drawing.Size(82, 13);
            this.lblSTWAccessBits1PK.TabIndex = 23;
            this.lblSTWAccessBits1PK.Text = "Access Bits 1";
            // 
            // lblSTWBlockOrSectorAddressPK
            // 
            this.lblSTWBlockOrSectorAddressPK.AutoSize = true;
            this.lblSTWBlockOrSectorAddressPK.Location = new System.Drawing.Point(55, 52);
            this.lblSTWBlockOrSectorAddressPK.Name = "lblSTWBlockOrSectorAddressPK";
            this.lblSTWBlockOrSectorAddressPK.Size = new System.Drawing.Size(145, 13);
            this.lblSTWBlockOrSectorAddressPK.TabIndex = 21;
            this.lblSTWBlockOrSectorAddressPK.Text = "Block or Sector Address";
            // 
            // cboSTWAccessBits0PK
            // 
            this.cboSTWAccessBits0PK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboSTWAccessBits0PK.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSTWAccessBits0PK.FormattingEnabled = true;
            this.cboSTWAccessBits0PK.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cboSTWAccessBits0PK.Location = new System.Drawing.Point(200, 83);
            this.cboSTWAccessBits0PK.Name = "cboSTWAccessBits0PK";
            this.cboSTWAccessBits0PK.Size = new System.Drawing.Size(39, 24);
            this.cboSTWAccessBits0PK.TabIndex = 2;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(55, 88);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(82, 13);
            this.label20.TabIndex = 18;
            this.label20.Text = "Access Bits 0";
            // 
            // cboSTWAddressingModePK
            // 
            this.cboSTWAddressingModePK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboSTWAddressingModePK.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSTWAddressingModePK.FormattingEnabled = true;
            this.cboSTWAddressingModePK.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cboSTWAddressingModePK.Location = new System.Drawing.Point(200, 17);
            this.cboSTWAddressingModePK.Name = "cboSTWAddressingModePK";
            this.cboSTWAddressingModePK.Size = new System.Drawing.Size(39, 24);
            this.cboSTWAddressingModePK.TabIndex = 0;
            // 
            // lblSTWAddressingModePK
            // 
            this.lblSTWAddressingModePK.AutoSize = true;
            this.lblSTWAddressingModePK.Location = new System.Drawing.Point(55, 22);
            this.lblSTWAddressingModePK.Name = "lblSTWAddressingModePK";
            this.lblSTWAddressingModePK.Size = new System.Drawing.Size(104, 13);
            this.lblSTWAddressingModePK.TabIndex = 15;
            this.lblSTWAddressingModePK.Text = "Addressing Mode";
            // 
            // frmSectorTrailerWrite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 376);
            this.Controls.Add(this.pgSectorTrailerWrite);
            this.Controls.Add(this.pnlBoth_key);
            this.Controls.Add(this.pnlAuth);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.stbFunctionError);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSectorTrailerWrite";
            this.Text = "frmSectorTrailerWrite";
            this.Load += new System.EventHandler(this.frmSectorTrailerWrite_Load);
            this.pnlAuth.ResumeLayout(false);
            this.pnlAuth.PerformLayout();
            this.stbFunctionError.ResumeLayout(false);
            this.stbFunctionError.PerformLayout();
            this.pnlBoth_key.ResumeLayout(false);
            this.pnlKeyB.ResumeLayout(false);
            this.pnlKeyB.PerformLayout();
            this.pnlKeyA.ResumeLayout(false);
            this.pnlKeyA.PerformLayout();
            this.pgSectorTrailerWrite.ResumeLayout(false);
            this.tabSectorTrailerWrite.ResumeLayout(false);
            this.tabSectorTrailerWrite.PerformLayout();
            this.tabSectorTrailerWriteAKM1.ResumeLayout(false);
            this.tabSectorTrailerWriteAKM1.PerformLayout();
            this.tabSectorTrailerWriteAKM2.ResumeLayout(false);
            this.tabSectorTrailerWriteAKM2.PerformLayout();
            this.tabSectorTrailerWritePK.ResumeLayout(false);
            this.tabSectorTrailerWritePK.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel pnlErr_expl;
        private System.Windows.Forms.Panel pnlAuth;
        private System.Windows.Forms.Label lblPKKey;
        private System.Windows.Forms.ComboBox cboKeyIndex;
        private System.Windows.Forms.Label lblKeyIndex;
        private System.Windows.Forms.RadioButton rbAUTH1B;
        private System.Windows.Forms.RadioButton rbAUTH1A;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.StatusStrip stbFunctionError;
        private System.Windows.Forms.ToolStripStatusLabel pnlFunct_error;
        private System.Windows.Forms.ToolStripStatusLabel pnlErr_code;
        private System.Windows.Forms.Panel pnlBoth_key;
        private System.Windows.Forms.Panel pnlKeyB;
        private System.Windows.Forms.Panel pnlKeyA;
        private System.Windows.Forms.TabControl pgSectorTrailerWrite;
        private System.Windows.Forms.TabPage tabSectorTrailerWrite;
        private System.Windows.Forms.TabPage tabSectorTrailerWriteAKM1;
        private System.Windows.Forms.Label lblKeyB;
        private System.Windows.Forms.Label lblKeyA;
        private System.Windows.Forms.CheckBox chkHexKeyA;
        private System.Windows.Forms.CheckBox chkHexKeyB;
        private System.Windows.Forms.Label lblSTWBlockOrSectorAddress;
        private System.Windows.Forms.ComboBox cboSTWAccessBits0;
        private System.Windows.Forms.Label lblSTWAccessBits0;
        private System.Windows.Forms.ComboBox cboSTWAddressingMode;
        private System.Windows.Forms.Label lblSTWAddressingMode;
        private System.Windows.Forms.TextBox txtSTWTrailerByte9;
        private System.Windows.Forms.Label lblSTWTrailerByte9;
        private System.Windows.Forms.ComboBox cboSTWTrailerAccessBits;
        private System.Windows.Forms.Label lblSTWTrailerAccessBits;
        private System.Windows.Forms.ComboBox cboSTWAccessBits2;
        private System.Windows.Forms.Label lblSTWAccessBits2;
        private System.Windows.Forms.ComboBox cboSTWAccessBits1;
        private System.Windows.Forms.Label lblSTWAccessBits1;
        private System.Windows.Forms.Button btnSTWWrite;
        private System.Windows.Forms.Button btnSTWWriteAKM1;
        private System.Windows.Forms.TextBox txtSTWTrailerByte9AKM1;
        private System.Windows.Forms.Label lblSTWTrailerByte9AKM1;
        private System.Windows.Forms.ComboBox cboSTWTrailerAccessBitsAKM1;
        private System.Windows.Forms.Label lblSTWTrailerAccessBitsAKM1;
        private System.Windows.Forms.ComboBox cboSTWAccessBits2AKM1;
        private System.Windows.Forms.Label lblSTWAccessBits2AKM1;
        private System.Windows.Forms.ComboBox cboSTWAccessBits1AKM1;
        private System.Windows.Forms.Label lblSTWAccessBits1AKM1;
        private System.Windows.Forms.Label lblSTWBlockOrSectorAddressAKM1;
        private System.Windows.Forms.ComboBox cboSTWAccessBits0AKM1;
        private System.Windows.Forms.Label lblSTWAccessBits0AKM1;
        private System.Windows.Forms.ComboBox cboSTWAddressingModeAKM1;
        private System.Windows.Forms.Label lblSTWAddressingModeAKM1;
        private System.Windows.Forms.TabPage tabSectorTrailerWriteAKM2;
        private System.Windows.Forms.Button btnSTWWriteAKM2;
        private System.Windows.Forms.TextBox txtSTWTrailerByte9AKM2;
        private System.Windows.Forms.Label lblSTWTrailerByte9AKM2;
        private System.Windows.Forms.ComboBox cboSTWTrailerAccessBitsAKM2;
        private System.Windows.Forms.Label lblSTWTrailerAccessBitsAKM2;
        private System.Windows.Forms.ComboBox cboSTWAccessBits2AKM2;
        private System.Windows.Forms.Label lblSTWAccessBits2AKM2;
        private System.Windows.Forms.ComboBox cboSTWAccessBits1AKM2;
        private System.Windows.Forms.Label lblSTWAccessBits1AKM2;
        private System.Windows.Forms.Label lblSTWBlockOrSectorAddressAKM2;
        private System.Windows.Forms.ComboBox cboSTWAccessBits0AKM2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboSTWAddressingModeAKM2;
        private System.Windows.Forms.Label lblSTWAddressingModeAKM2;
        private System.Windows.Forms.TabPage tabSectorTrailerWritePK;
        private System.Windows.Forms.Button btnSTWWritePK;
        private System.Windows.Forms.TextBox txtSTWTrailerByte9PK;
        private System.Windows.Forms.Label lblSTWTrailerByte9PK;
        private System.Windows.Forms.ComboBox cboSTWTrailerAccessBitsPK;
        private System.Windows.Forms.Label lblSTWTrailerAccessBitsPK;
        private System.Windows.Forms.ComboBox cboSTWAccessBits2PK;
        private System.Windows.Forms.Label lblSTWAccessBits2PK;
        private System.Windows.Forms.ComboBox cboSTWAccessBits1PK;
        private System.Windows.Forms.Label lblSTWAccessBits1PK;
        private System.Windows.Forms.Label lblSTWBlockOrSectorAddressPK;
        private System.Windows.Forms.ComboBox cboSTWAccessBits0PK;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cboSTWAddressingModePK;
        private System.Windows.Forms.Label lblSTWAddressingModePK;
        private System.Windows.Forms.TextBox txtSTWBlockOrSectorAddress;
        private System.Windows.Forms.TextBox txtSTWBlockOrSectorAddressAKM1;
        private System.Windows.Forms.TextBox txtSTWBlockOrSectorAddressAKM2;
        private System.Windows.Forms.TextBox txtSTWBlockOrSectorAddressPK;
    }
}
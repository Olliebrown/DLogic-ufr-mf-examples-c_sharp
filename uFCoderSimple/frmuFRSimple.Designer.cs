namespace uFRSimple
{
    partial class frmuFRSimpleImplementation
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
            this.stbCardStatus = new System.Windows.Forms.StatusStrip();
            this.pnlCard_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlError_code = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlError_explain = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuMeniItem = new System.Windows.Forms.MenuStrip();
            this.mniExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlReader = new System.Windows.Forms.Panel();
            this.btnReaderUISignal = new System.Windows.Forms.Button();
            this.cboLightMode = new System.Windows.Forms.ComboBox();
            this.lblSoundMode = new System.Windows.Forms.Label();
            this.cboSoundMode = new System.Windows.Forms.ComboBox();
            this.lblLightMode = new System.Windows.Forms.Label();
            this.pnlSep = new System.Windows.Forms.Panel();
            this.txtCardSerial = new System.Windows.Forms.TextBox();
            this.lblCardSerial = new System.Windows.Forms.Label();
            this.txtCardType = new System.Windows.Forms.TextBox();
            this.lblCardType = new System.Windows.Forms.Label();
            this.txtReaderSerial = new System.Windows.Forms.TextBox();
            this.lblReaderSerial = new System.Windows.Forms.Label();
            this.txtReaderType = new System.Windows.Forms.TextBox();
            this.lblReaderType = new System.Windows.Forms.Label();
            this.stbReader = new System.Windows.Forms.StatusStrip();
            this.pnlConnected = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlReader_error_code = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlReader_err_explain = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKeyIndex = new System.Windows.Forms.Label();
            this.txtReaderKeyIndex = new System.Windows.Forms.TextBox();
            this.pnlFormat = new System.Windows.Forms.Panel();
            this.pgKeys = new System.Windows.Forms.TabControl();
            this.tabNewCardKeys = new System.Windows.Forms.TabPage();
            this.chkCardKeysHex = new System.Windows.Forms.CheckBox();
            this.lblKeyB = new System.Windows.Forms.Label();
            this.lblKeyA = new System.Windows.Forms.Label();
            this.pnlCardKeys = new System.Windows.Forms.Panel();
            this.txtSectorFormatted = new System.Windows.Forms.TextBox();
            this.lblSectorFormatted = new System.Windows.Forms.Label();
            this.btnFormatCard = new System.Windows.Forms.Button();
            this.tabNewReaderKey = new System.Windows.Forms.TabPage();
            this.pnlReaderKey = new System.Windows.Forms.Panel();
            this.chkReaderKeyHex = new System.Windows.Forms.CheckBox();
            this.btnEnterReaderKey = new System.Windows.Forms.Button();
            this.pnlAuth = new System.Windows.Forms.Panel();
            this.rbAUTH1B = new System.Windows.Forms.RadioButton();
            this.rbAUTH1A = new System.Windows.Forms.RadioButton();
            this.stbFunction_error = new System.Windows.Forms.StatusStrip();
            this.pnlFunction = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlFError_code = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlFError_explain = new System.Windows.Forms.ToolStripStatusLabel();
            this.pgLinearReadWrite = new System.Windows.Forms.TabControl();
            this.tabLinearRead = new System.Windows.Forms.TabPage();
            this.txtReadBytes = new System.Windows.Forms.TextBox();
            this.lblReadBytes = new System.Windows.Forms.Label();
            this.btnLinearRead = new System.Windows.Forms.Button();
            this.txtReadDataLength = new System.Windows.Forms.TextBox();
            this.lblReadDataLength = new System.Windows.Forms.Label();
            this.txtReadLinearAddress = new System.Windows.Forms.TextBox();
            this.lblLinearAddress = new System.Windows.Forms.Label();
            this.txtReadData = new System.Windows.Forms.RichTextBox();
            this.lblReadData = new System.Windows.Forms.Label();
            this.tabLinearWrite = new System.Windows.Forms.TabPage();
            this.txtBytesWritten = new System.Windows.Forms.TextBox();
            this.lblBytesWritten = new System.Windows.Forms.Label();
            this.btnWriteData = new System.Windows.Forms.Button();
            this.txtWriteDataLength = new System.Windows.Forms.TextBox();
            this.lblWriteDataLength = new System.Windows.Forms.Label();
            this.txtWriteLinearAddress = new System.Windows.Forms.TextBox();
            this.lblWriteLinearAddress = new System.Windows.Forms.Label();
            this.txtWriteData = new System.Windows.Forms.RichTextBox();
            this.lblWriteData = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.stbCardStatus.SuspendLayout();
            this.mnuMeniItem.SuspendLayout();
            this.pnlReader.SuspendLayout();
            this.stbReader.SuspendLayout();
            this.pnlFormat.SuspendLayout();
            this.pgKeys.SuspendLayout();
            this.tabNewCardKeys.SuspendLayout();
            this.tabNewReaderKey.SuspendLayout();
            this.pnlAuth.SuspendLayout();
            this.stbFunction_error.SuspendLayout();
            this.pgLinearReadWrite.SuspendLayout();
            this.tabLinearRead.SuspendLayout();
            this.tabLinearWrite.SuspendLayout();
            this.SuspendLayout();
            // 
            // stbCardStatus
            // 
            this.stbCardStatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stbCardStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pnlCard_status,
            this.pnlError_code,
            this.pnlError_explain});
            this.stbCardStatus.Location = new System.Drawing.Point(0, 640);
            this.stbCardStatus.Name = "stbCardStatus";
            this.stbCardStatus.Size = new System.Drawing.Size(504, 22);
            this.stbCardStatus.SizingGrip = false;
            this.stbCardStatus.TabIndex = 0;
            // 
            // pnlCard_status
            // 
            this.pnlCard_status.AutoSize = false;
            this.pnlCard_status.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.pnlCard_status.Name = "pnlCard_status";
            this.pnlCard_status.Size = new System.Drawing.Size(120, 17);
            this.pnlCard_status.Text = "CARD STATUS:";
            // 
            // pnlError_code
            // 
            this.pnlError_code.AutoSize = false;
            this.pnlError_code.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.pnlError_code.Name = "pnlError_code";
            this.pnlError_code.Size = new System.Drawing.Size(50, 17);
            this.pnlError_code.Text = " ";
            // 
            // pnlError_explain
            // 
            this.pnlError_explain.Name = "pnlError_explain";
            this.pnlError_explain.Size = new System.Drawing.Size(319, 17);
            this.pnlError_explain.Spring = true;
            this.pnlError_explain.Text = " ";
            // 
            // mnuMeniItem
            // 
            this.mnuMeniItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniExitItem});
            this.mnuMeniItem.Location = new System.Drawing.Point(0, 0);
            this.mnuMeniItem.Name = "mnuMeniItem";
            this.mnuMeniItem.Size = new System.Drawing.Size(504, 24);
            this.mnuMeniItem.TabIndex = 1;
            this.mnuMeniItem.Text = "menuStrip1";
            // 
            // mniExitItem
            // 
            this.mniExitItem.Name = "mniExitItem";
            this.mniExitItem.Size = new System.Drawing.Size(37, 20);
            this.mniExitItem.Text = "Exit";
            this.mniExitItem.Click += new System.EventHandler(this.mniExitItem_Click);
            // 
            // pnlReader
            // 
            this.pnlReader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlReader.Controls.Add(this.btnReaderUISignal);
            this.pnlReader.Controls.Add(this.cboLightMode);
            this.pnlReader.Controls.Add(this.lblSoundMode);
            this.pnlReader.Controls.Add(this.cboSoundMode);
            this.pnlReader.Controls.Add(this.lblLightMode);
            this.pnlReader.Controls.Add(this.pnlSep);
            this.pnlReader.Controls.Add(this.txtCardSerial);
            this.pnlReader.Controls.Add(this.lblCardSerial);
            this.pnlReader.Controls.Add(this.txtCardType);
            this.pnlReader.Controls.Add(this.lblCardType);
            this.pnlReader.Controls.Add(this.txtReaderSerial);
            this.pnlReader.Controls.Add(this.lblReaderSerial);
            this.pnlReader.Controls.Add(this.txtReaderType);
            this.pnlReader.Controls.Add(this.lblReaderType);
            this.pnlReader.Controls.Add(this.stbReader);
            this.pnlReader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReader.Location = new System.Drawing.Point(0, 24);
            this.pnlReader.Name = "pnlReader";
            this.pnlReader.Size = new System.Drawing.Size(504, 189);
            this.pnlReader.TabIndex = 2;
            // 
            // btnReaderUISignal
            // 
            this.btnReaderUISignal.BackColor = System.Drawing.Color.White;
            this.btnReaderUISignal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReaderUISignal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnReaderUISignal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReaderUISignal.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReaderUISignal.Location = new System.Drawing.Point(297, 95);
            this.btnReaderUISignal.Name = "btnReaderUISignal";
            this.btnReaderUISignal.Size = new System.Drawing.Size(140, 48);
            this.btnReaderUISignal.TabIndex = 15;
            this.btnReaderUISignal.Text = "READER UI SIGNAL";
            this.btnReaderUISignal.UseVisualStyleBackColor = false;
            this.btnReaderUISignal.Click += new System.EventHandler(this.btnReaderUISignal_Click);
            // 
            // cboLightMode
            // 
            this.cboLightMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboLightMode.FormattingEnabled = true;
            this.cboLightMode.Items.AddRange(new object[] {
            "None",
            "Long Green",
            "LongRed",
            "Alternation",
            "Flash"});
            this.cboLightMode.Location = new System.Drawing.Point(116, 95);
            this.cboLightMode.Name = "cboLightMode";
            this.cboLightMode.Size = new System.Drawing.Size(116, 21);
            this.cboLightMode.TabIndex = 14;
            // 
            // lblSoundMode
            // 
            this.lblSoundMode.AutoSize = true;
            this.lblSoundMode.Location = new System.Drawing.Point(23, 125);
            this.lblSoundMode.Name = "lblSoundMode";
            this.lblSoundMode.Size = new System.Drawing.Size(77, 13);
            this.lblSoundMode.TabIndex = 13;
            this.lblSoundMode.Text = "Sound Mode";
            // 
            // cboSoundMode
            // 
            this.cboSoundMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboSoundMode.FormattingEnabled = true;
            this.cboSoundMode.Items.AddRange(new object[] {
            "None",
            "Short",
            "Long",
            "Double Short",
            "Tripple Short",
            "Tripplet Melody"});
            this.cboSoundMode.Location = new System.Drawing.Point(116, 122);
            this.cboSoundMode.Name = "cboSoundMode";
            this.cboSoundMode.Size = new System.Drawing.Size(116, 21);
            this.cboSoundMode.TabIndex = 12;
            // 
            // lblLightMode
            // 
            this.lblLightMode.AutoSize = true;
            this.lblLightMode.Location = new System.Drawing.Point(23, 98);
            this.lblLightMode.Name = "lblLightMode";
            this.lblLightMode.Size = new System.Drawing.Size(68, 13);
            this.lblLightMode.TabIndex = 11;
            this.lblLightMode.Text = "Light Mode";
            // 
            // pnlSep
            // 
            this.pnlSep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSep.Location = new System.Drawing.Point(23, 76);
            this.pnlSep.Name = "pnlSep";
            this.pnlSep.Size = new System.Drawing.Size(453, 5);
            this.pnlSep.TabIndex = 10;
            // 
            // txtCardSerial
            // 
            this.txtCardSerial.BackColor = System.Drawing.Color.White;
            this.txtCardSerial.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardSerial.Location = new System.Drawing.Point(361, 46);
            this.txtCardSerial.Name = "txtCardSerial";
            this.txtCardSerial.ReadOnly = true;
            this.txtCardSerial.Size = new System.Drawing.Size(116, 24);
            this.txtCardSerial.TabIndex = 9;
            this.txtCardSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCardSerial
            // 
            this.lblCardSerial.AutoSize = true;
            this.lblCardSerial.Location = new System.Drawing.Point(263, 50);
            this.lblCardSerial.Name = "lblCardSerial";
            this.lblCardSerial.Size = new System.Drawing.Size(72, 13);
            this.lblCardSerial.TabIndex = 8;
            this.lblCardSerial.Text = "Card Serial";
            // 
            // txtCardType
            // 
            this.txtCardType.BackColor = System.Drawing.Color.White;
            this.txtCardType.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardType.Location = new System.Drawing.Point(361, 19);
            this.txtCardType.Name = "txtCardType";
            this.txtCardType.ReadOnly = true;
            this.txtCardType.Size = new System.Drawing.Size(116, 24);
            this.txtCardType.TabIndex = 7;
            this.txtCardType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCardType
            // 
            this.lblCardType.AutoSize = true;
            this.lblCardType.Location = new System.Drawing.Point(263, 23);
            this.lblCardType.Name = "lblCardType";
            this.lblCardType.Size = new System.Drawing.Size(67, 13);
            this.lblCardType.TabIndex = 6;
            this.lblCardType.Text = "Card Type";
            // 
            // txtReaderSerial
            // 
            this.txtReaderSerial.BackColor = System.Drawing.Color.White;
            this.txtReaderSerial.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReaderSerial.Location = new System.Drawing.Point(116, 46);
            this.txtReaderSerial.Name = "txtReaderSerial";
            this.txtReaderSerial.ReadOnly = true;
            this.txtReaderSerial.Size = new System.Drawing.Size(116, 24);
            this.txtReaderSerial.TabIndex = 5;
            this.txtReaderSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblReaderSerial
            // 
            this.lblReaderSerial.AutoSize = true;
            this.lblReaderSerial.Location = new System.Drawing.Point(18, 50);
            this.lblReaderSerial.Name = "lblReaderSerial";
            this.lblReaderSerial.Size = new System.Drawing.Size(85, 13);
            this.lblReaderSerial.TabIndex = 4;
            this.lblReaderSerial.Text = "Reader Serial";
            // 
            // txtReaderType
            // 
            this.txtReaderType.BackColor = System.Drawing.Color.White;
            this.txtReaderType.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReaderType.Location = new System.Drawing.Point(116, 19);
            this.txtReaderType.Name = "txtReaderType";
            this.txtReaderType.ReadOnly = true;
            this.txtReaderType.Size = new System.Drawing.Size(116, 24);
            this.txtReaderType.TabIndex = 3;
            this.txtReaderType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblReaderType
            // 
            this.lblReaderType.AutoSize = true;
            this.lblReaderType.Location = new System.Drawing.Point(18, 23);
            this.lblReaderType.Name = "lblReaderType";
            this.lblReaderType.Size = new System.Drawing.Size(80, 13);
            this.lblReaderType.TabIndex = 2;
            this.lblReaderType.Text = "Reader Type";
            // 
            // stbReader
            // 
            this.stbReader.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stbReader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pnlConnected,
            this.pnlReader_error_code,
            this.pnlReader_err_explain});
            this.stbReader.Location = new System.Drawing.Point(0, 163);
            this.stbReader.Name = "stbReader";
            this.stbReader.Size = new System.Drawing.Size(500, 22);
            this.stbReader.SizingGrip = false;
            this.stbReader.TabIndex = 1;
            // 
            // pnlConnected
            // 
            this.pnlConnected.AutoSize = false;
            this.pnlConnected.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.pnlConnected.Name = "pnlConnected";
            this.pnlConnected.Size = new System.Drawing.Size(120, 17);
            this.pnlConnected.Text = " ";
            // 
            // pnlReader_error_code
            // 
            this.pnlReader_error_code.AutoSize = false;
            this.pnlReader_error_code.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.pnlReader_error_code.Name = "pnlReader_error_code";
            this.pnlReader_error_code.Size = new System.Drawing.Size(50, 17);
            this.pnlReader_error_code.Text = " ";
            // 
            // pnlReader_err_explain
            // 
            this.pnlReader_err_explain.Name = "pnlReader_err_explain";
            this.pnlReader_err_explain.Size = new System.Drawing.Size(315, 17);
            this.pnlReader_err_explain.Spring = true;
            this.pnlReader_err_explain.Text = " ";
            // 
            // lblKeyIndex
            // 
            this.lblKeyIndex.AutoSize = true;
            this.lblKeyIndex.Location = new System.Drawing.Point(143, 58);
            this.lblKeyIndex.Name = "lblKeyIndex";
            this.lblKeyIndex.Size = new System.Drawing.Size(66, 13);
            this.lblKeyIndex.TabIndex = 17;
            this.lblKeyIndex.Text = "Key Index";
            // 
            // txtReaderKeyIndex
            // 
            this.txtReaderKeyIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReaderKeyIndex.Enabled = false;
            this.txtReaderKeyIndex.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReaderKeyIndex.Location = new System.Drawing.Point(230, 51);
            this.txtReaderKeyIndex.Name = "txtReaderKeyIndex";
            this.txtReaderKeyIndex.ReadOnly = true;
            this.txtReaderKeyIndex.Size = new System.Drawing.Size(35, 27);
            this.txtReaderKeyIndex.TabIndex = 16;
            this.txtReaderKeyIndex.Text = "0";
            this.txtReaderKeyIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtReaderKeyIndex.WordWrap = false;
            // 
            // pnlFormat
            // 
            this.pnlFormat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlFormat.Controls.Add(this.pgKeys);
            this.pnlFormat.Controls.Add(this.pnlAuth);
            this.pnlFormat.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFormat.Location = new System.Drawing.Point(0, 213);
            this.pnlFormat.Name = "pnlFormat";
            this.pnlFormat.Size = new System.Drawing.Size(504, 160);
            this.pnlFormat.TabIndex = 3;
            // 
            // pgKeys
            // 
            this.pgKeys.Controls.Add(this.tabNewCardKeys);
            this.pgKeys.Controls.Add(this.tabNewReaderKey);
            this.pgKeys.Location = new System.Drawing.Point(19, 29);
            this.pgKeys.Name = "pgKeys";
            this.pgKeys.SelectedIndex = 0;
            this.pgKeys.Size = new System.Drawing.Size(457, 118);
            this.pgKeys.TabIndex = 8;
           
            // 
            // tabNewCardKeys
            // 
            this.tabNewCardKeys.Controls.Add(this.chkCardKeysHex);
            this.tabNewCardKeys.Controls.Add(this.lblKeyB);
            this.tabNewCardKeys.Controls.Add(this.lblKeyA);
            this.tabNewCardKeys.Controls.Add(this.pnlCardKeys);
            this.tabNewCardKeys.Controls.Add(this.txtSectorFormatted);
            this.tabNewCardKeys.Controls.Add(this.lblSectorFormatted);
            this.tabNewCardKeys.Controls.Add(this.btnFormatCard);
            this.tabNewCardKeys.Location = new System.Drawing.Point(4, 22);
            this.tabNewCardKeys.Name = "tabNewCardKeys";
            this.tabNewCardKeys.Padding = new System.Windows.Forms.Padding(3);
            this.tabNewCardKeys.Size = new System.Drawing.Size(449, 92);
            this.tabNewCardKeys.TabIndex = 0;
            this.tabNewCardKeys.Text = "New Card Keys";
            this.tabNewCardKeys.UseVisualStyleBackColor = true;
            // 
            // chkCardKeysHex
            // 
            this.chkCardKeysHex.AutoSize = true;
            this.chkCardKeysHex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkCardKeysHex.Location = new System.Drawing.Point(75, 65);
            this.chkCardKeysHex.Name = "chkCardKeysHex";
            this.chkCardKeysHex.Size = new System.Drawing.Size(48, 17);
            this.chkCardKeysHex.TabIndex = 15;
            this.chkCardKeysHex.Text = "Hex";
            this.chkCardKeysHex.UseVisualStyleBackColor = true;
            this.chkCardKeysHex.Click += new System.EventHandler(this.chkCardKeysHex_Click);
            // 
            // lblKeyB
            // 
            this.lblKeyB.AutoSize = true;
            this.lblKeyB.Location = new System.Drawing.Point(24, 47);
            this.lblKeyB.Name = "lblKeyB";
            this.lblKeyB.Size = new System.Drawing.Size(41, 13);
            this.lblKeyB.TabIndex = 14;
            this.lblKeyB.Text = "Key B";
            // 
            // lblKeyA
            // 
            this.lblKeyA.AutoSize = true;
            this.lblKeyA.Location = new System.Drawing.Point(24, 23);
            this.lblKeyA.Name = "lblKeyA";
            this.lblKeyA.Size = new System.Drawing.Size(41, 13);
            this.lblKeyA.TabIndex = 13;
            this.lblKeyA.Text = "Key A";
            // 
            // pnlCardKeys
            // 
            this.pnlCardKeys.Location = new System.Drawing.Point(72, 8);
            this.pnlCardKeys.Name = "pnlCardKeys";
            this.pnlCardKeys.Size = new System.Drawing.Size(226, 54);
            this.pnlCardKeys.TabIndex = 10;
            // 
            // txtSectorFormatted
            // 
            this.txtSectorFormatted.BackColor = System.Drawing.Color.DarkGray;
            this.txtSectorFormatted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSectorFormatted.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSectorFormatted.Location = new System.Drawing.Point(392, 62);
            this.txtSectorFormatted.Name = "txtSectorFormatted";
            this.txtSectorFormatted.ReadOnly = true;
            this.txtSectorFormatted.Size = new System.Drawing.Size(41, 24);
            this.txtSectorFormatted.TabIndex = 9;
            this.txtSectorFormatted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSectorFormatted
            // 
            this.lblSectorFormatted.AutoSize = true;
            this.lblSectorFormatted.Location = new System.Drawing.Point(266, 65);
            this.lblSectorFormatted.Name = "lblSectorFormatted";
            this.lblSectorFormatted.Size = new System.Drawing.Size(112, 13);
            this.lblSectorFormatted.TabIndex = 8;
            this.lblSectorFormatted.Text = "Sectors Formatted";
            // 
            // btnFormatCard
            // 
            this.btnFormatCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFormatCard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnFormatCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormatCard.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormatCard.Location = new System.Drawing.Point(304, 8);
            this.btnFormatCard.Name = "btnFormatCard";
            this.btnFormatCard.Size = new System.Drawing.Size(129, 43);
            this.btnFormatCard.TabIndex = 7;
            this.btnFormatCard.Text = "FORMAT CARD";
            this.btnFormatCard.UseVisualStyleBackColor = true;
            this.btnFormatCard.Click += new System.EventHandler(this.btnFormatCard_Click);
            // 
            // tabNewReaderKey
            // 
            this.tabNewReaderKey.Controls.Add(this.pnlReaderKey);
            this.tabNewReaderKey.Controls.Add(this.txtReaderKeyIndex);
            this.tabNewReaderKey.Controls.Add(this.lblKeyIndex);
            this.tabNewReaderKey.Controls.Add(this.chkReaderKeyHex);
            this.tabNewReaderKey.Controls.Add(this.btnEnterReaderKey);
            this.tabNewReaderKey.Location = new System.Drawing.Point(4, 22);
            this.tabNewReaderKey.Name = "tabNewReaderKey";
            this.tabNewReaderKey.Padding = new System.Windows.Forms.Padding(3);
            this.tabNewReaderKey.Size = new System.Drawing.Size(449, 92);
            this.tabNewReaderKey.TabIndex = 1;
            this.tabNewReaderKey.Text = "New Reader Key";
            this.tabNewReaderKey.UseVisualStyleBackColor = true;
            // 
            // pnlReaderKey
            // 
            this.pnlReaderKey.Location = new System.Drawing.Point(13, 6);
            this.pnlReaderKey.Name = "pnlReaderKey";
            this.pnlReaderKey.Size = new System.Drawing.Size(284, 36);
            this.pnlReaderKey.TabIndex = 18;
            // 
            // chkReaderKeyHex
            // 
            this.chkReaderKeyHex.AutoSize = true;
            this.chkReaderKeyHex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkReaderKeyHex.Location = new System.Drawing.Point(66, 57);
            this.chkReaderKeyHex.Name = "chkReaderKeyHex";
            this.chkReaderKeyHex.Size = new System.Drawing.Size(48, 17);
            this.chkReaderKeyHex.TabIndex = 14;
            this.chkReaderKeyHex.Text = "Hex";
            this.chkReaderKeyHex.UseVisualStyleBackColor = true;
            this.chkReaderKeyHex.Click += new System.EventHandler(this.chkReaderKeyHex_Click);
            // 
            // btnEnterReaderKey
            // 
            this.btnEnterReaderKey.BackColor = System.Drawing.Color.White;
            this.btnEnterReaderKey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnterReaderKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnEnterReaderKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnterReaderKey.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnterReaderKey.Location = new System.Drawing.Point(303, 22);
            this.btnEnterReaderKey.Name = "btnEnterReaderKey";
            this.btnEnterReaderKey.Size = new System.Drawing.Size(129, 43);
            this.btnEnterReaderKey.TabIndex = 13;
            this.btnEnterReaderKey.Text = "Format Card Keys";
            this.btnEnterReaderKey.UseVisualStyleBackColor = false;
            this.btnEnterReaderKey.Click += new System.EventHandler(this.btnEnterReaderKey_Click);
            // 
            // pnlAuth
            // 
            this.pnlAuth.BackColor = System.Drawing.Color.White;
            this.pnlAuth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuth.Controls.Add(this.rbAUTH1B);
            this.pnlAuth.Controls.Add(this.rbAUTH1A);
            this.pnlAuth.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAuth.Location = new System.Drawing.Point(0, 0);
            this.pnlAuth.Name = "pnlAuth";
            this.pnlAuth.Size = new System.Drawing.Size(500, 27);
            this.pnlAuth.TabIndex = 0;
            // 
            // rbAUTH1B
            // 
            this.rbAUTH1B.AutoSize = true;
            this.rbAUTH1B.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAUTH1B.Location = new System.Drawing.Point(296, 5);
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
            this.rbAUTH1A.Location = new System.Drawing.Point(115, 5);
            this.rbAUTH1A.Name = "rbAUTH1A";
            this.rbAUTH1A.Size = new System.Drawing.Size(81, 17);
            this.rbAUTH1A.TabIndex = 0;
            this.rbAUTH1A.TabStop = true;
            this.rbAUTH1A.Text = "AUTH 1A";
            this.rbAUTH1A.UseVisualStyleBackColor = true;
            // 
            // stbFunction_error
            // 
            this.stbFunction_error.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stbFunction_error.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pnlFunction,
            this.pnlFError_code,
            this.pnlFError_explain});
            this.stbFunction_error.Location = new System.Drawing.Point(0, 618);
            this.stbFunction_error.Name = "stbFunction_error";
            this.stbFunction_error.Size = new System.Drawing.Size(504, 22);
            this.stbFunction_error.SizingGrip = false;
            this.stbFunction_error.TabIndex = 5;
            // 
            // pnlFunction
            // 
            this.pnlFunction.AutoSize = false;
            this.pnlFunction.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.pnlFunction.Name = "pnlFunction";
            this.pnlFunction.Size = new System.Drawing.Size(120, 17);
            this.pnlFunction.Text = "Function Error:";
            // 
            // pnlFError_code
            // 
            this.pnlFError_code.AutoSize = false;
            this.pnlFError_code.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.pnlFError_code.Name = "pnlFError_code";
            this.pnlFError_code.Size = new System.Drawing.Size(50, 17);
            this.pnlFError_code.Text = " ";
            // 
            // pnlFError_explain
            // 
            this.pnlFError_explain.Name = "pnlFError_explain";
            this.pnlFError_explain.Size = new System.Drawing.Size(319, 17);
            this.pnlFError_explain.Spring = true;
            this.pnlFError_explain.Text = " ";
            // 
            // pgLinearReadWrite
            // 
            this.pgLinearReadWrite.Controls.Add(this.tabLinearRead);
            this.pgLinearReadWrite.Controls.Add(this.tabLinearWrite);
            this.pgLinearReadWrite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgLinearReadWrite.Location = new System.Drawing.Point(0, 373);
            this.pgLinearReadWrite.Name = "pgLinearReadWrite";
            this.pgLinearReadWrite.SelectedIndex = 0;
            this.pgLinearReadWrite.Size = new System.Drawing.Size(504, 245);
            this.pgLinearReadWrite.TabIndex = 6;
            // 
            // tabLinearRead
            // 
            this.tabLinearRead.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabLinearRead.Controls.Add(this.txtReadBytes);
            this.tabLinearRead.Controls.Add(this.lblReadBytes);
            this.tabLinearRead.Controls.Add(this.btnLinearRead);
            this.tabLinearRead.Controls.Add(this.txtReadDataLength);
            this.tabLinearRead.Controls.Add(this.lblReadDataLength);
            this.tabLinearRead.Controls.Add(this.txtReadLinearAddress);
            this.tabLinearRead.Controls.Add(this.lblLinearAddress);
            this.tabLinearRead.Controls.Add(this.txtReadData);
            this.tabLinearRead.Controls.Add(this.lblReadData);
            this.tabLinearRead.Location = new System.Drawing.Point(4, 22);
            this.tabLinearRead.Name = "tabLinearRead";
            this.tabLinearRead.Padding = new System.Windows.Forms.Padding(3);
            this.tabLinearRead.Size = new System.Drawing.Size(496, 219);
            this.tabLinearRead.TabIndex = 0;
            this.tabLinearRead.Text = "Linear Read";
            this.tabLinearRead.UseVisualStyleBackColor = true;
            // 
            // txtReadBytes
            // 
            this.txtReadBytes.BackColor = System.Drawing.Color.Silver;
            this.txtReadBytes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReadBytes.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReadBytes.Location = new System.Drawing.Point(277, 168);
            this.txtReadBytes.MaxLength = 3;
            this.txtReadBytes.Name = "txtReadBytes";
            this.txtReadBytes.ReadOnly = true;
            this.txtReadBytes.Size = new System.Drawing.Size(40, 22);
            this.txtReadBytes.TabIndex = 9;
            this.txtReadBytes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblReadBytes
            // 
            this.lblReadBytes.AutoSize = true;
            this.lblReadBytes.Location = new System.Drawing.Point(188, 171);
            this.lblReadBytes.Name = "lblReadBytes";
            this.lblReadBytes.Size = new System.Drawing.Size(72, 13);
            this.lblReadBytes.TabIndex = 8;
            this.lblReadBytes.Text = "Read Bytes";
            // 
            // btnLinearRead
            // 
            this.btnLinearRead.BackColor = System.Drawing.Color.White;
            this.btnLinearRead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLinearRead.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnLinearRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLinearRead.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLinearRead.Location = new System.Drawing.Point(338, 154);
            this.btnLinearRead.Name = "btnLinearRead";
            this.btnLinearRead.Size = new System.Drawing.Size(134, 47);
            this.btnLinearRead.TabIndex = 5;
            this.btnLinearRead.Text = "LINEAR READ";
            this.btnLinearRead.UseVisualStyleBackColor = false;
            this.btnLinearRead.Click += new System.EventHandler(this.btnLinearRead_Click);
            // 
            // txtReadDataLength
            // 
            this.txtReadDataLength.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReadDataLength.Location = new System.Drawing.Point(127, 180);
            this.txtReadDataLength.MaxLength = 3;
            this.txtReadDataLength.Name = "txtReadDataLength";
            this.txtReadDataLength.Size = new System.Drawing.Size(40, 22);
            this.txtReadDataLength.TabIndex = 4;
            this.txtReadDataLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblReadDataLength
            // 
            this.lblReadDataLength.AutoSize = true;
            this.lblReadDataLength.Location = new System.Drawing.Point(20, 182);
            this.lblReadDataLength.Name = "lblReadDataLength";
            this.lblReadDataLength.Size = new System.Drawing.Size(76, 13);
            this.lblReadDataLength.TabIndex = 4;
            this.lblReadDataLength.Text = "Data Length";
            // 
            // txtReadLinearAddress
            // 
            this.txtReadLinearAddress.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReadLinearAddress.Location = new System.Drawing.Point(127, 152);
            this.txtReadLinearAddress.MaxLength = 3;
            this.txtReadLinearAddress.Name = "txtReadLinearAddress";
            this.txtReadLinearAddress.Size = new System.Drawing.Size(40, 22);
            this.txtReadLinearAddress.TabIndex = 3;
            this.txtReadLinearAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLinearAddress
            // 
            this.lblLinearAddress.AutoSize = true;
            this.lblLinearAddress.Location = new System.Drawing.Point(20, 154);
            this.lblLinearAddress.Name = "lblLinearAddress";
            this.lblLinearAddress.Size = new System.Drawing.Size(92, 13);
            this.lblLinearAddress.TabIndex = 2;
            this.lblLinearAddress.Text = "Linear Address";
            // 
            // txtReadData
            // 
            this.txtReadData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReadData.Location = new System.Drawing.Point(20, 30);
            this.txtReadData.Name = "txtReadData";
            this.txtReadData.ReadOnly = true;
            this.txtReadData.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtReadData.Size = new System.Drawing.Size(452, 118);
            this.txtReadData.TabIndex = 1;
            this.txtReadData.Text = "";
            // 
            // lblReadData
            // 
            this.lblReadData.AutoSize = true;
            this.lblReadData.Location = new System.Drawing.Point(17, 12);
            this.lblReadData.Name = "lblReadData";
            this.lblReadData.Size = new System.Drawing.Size(67, 13);
            this.lblReadData.TabIndex = 0;
            this.lblReadData.Text = "Read Data";
            // 
            // tabLinearWrite
            // 
            this.tabLinearWrite.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabLinearWrite.Controls.Add(this.txtBytesWritten);
            this.tabLinearWrite.Controls.Add(this.lblBytesWritten);
            this.tabLinearWrite.Controls.Add(this.btnWriteData);
            this.tabLinearWrite.Controls.Add(this.txtWriteDataLength);
            this.tabLinearWrite.Controls.Add(this.lblWriteDataLength);
            this.tabLinearWrite.Controls.Add(this.txtWriteLinearAddress);
            this.tabLinearWrite.Controls.Add(this.lblWriteLinearAddress);
            this.tabLinearWrite.Controls.Add(this.txtWriteData);
            this.tabLinearWrite.Controls.Add(this.lblWriteData);
            this.tabLinearWrite.Location = new System.Drawing.Point(4, 22);
            this.tabLinearWrite.Name = "tabLinearWrite";
            this.tabLinearWrite.Padding = new System.Windows.Forms.Padding(3);
            this.tabLinearWrite.Size = new System.Drawing.Size(496, 219);
            this.tabLinearWrite.TabIndex = 1;
            this.tabLinearWrite.Text = "Linear Write";
            this.tabLinearWrite.UseVisualStyleBackColor = true;
            // 
            // txtBytesWritten
            // 
            this.txtBytesWritten.BackColor = System.Drawing.Color.Silver;
            this.txtBytesWritten.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBytesWritten.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBytesWritten.Location = new System.Drawing.Point(277, 168);
            this.txtBytesWritten.MaxLength = 3;
            this.txtBytesWritten.Name = "txtBytesWritten";
            this.txtBytesWritten.ReadOnly = true;
            this.txtBytesWritten.Size = new System.Drawing.Size(40, 22);
            this.txtBytesWritten.TabIndex = 14;
            this.txtBytesWritten.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBytesWritten
            // 
            this.lblBytesWritten.AutoSize = true;
            this.lblBytesWritten.Location = new System.Drawing.Point(188, 171);
            this.lblBytesWritten.Name = "lblBytesWritten";
            this.lblBytesWritten.Size = new System.Drawing.Size(84, 13);
            this.lblBytesWritten.TabIndex = 13;
            this.lblBytesWritten.Text = "Bytes Written";
            // 
            // btnWriteData
            // 
            this.btnWriteData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWriteData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnWriteData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWriteData.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWriteData.Location = new System.Drawing.Point(338, 154);
            this.btnWriteData.Name = "btnWriteData";
            this.btnWriteData.Size = new System.Drawing.Size(134, 47);
            this.btnWriteData.TabIndex = 4;
            this.btnWriteData.Text = "LINEAR WRITE";
            this.btnWriteData.UseVisualStyleBackColor = true;
            this.btnWriteData.Click += new System.EventHandler(this.btnWriteData_Click);
            // 
            // txtWriteDataLength
            // 
            this.txtWriteDataLength.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWriteDataLength.Location = new System.Drawing.Point(127, 180);
            this.txtWriteDataLength.MaxLength = 3;
            this.txtWriteDataLength.Name = "txtWriteDataLength";
            this.txtWriteDataLength.Size = new System.Drawing.Size(40, 22);
            this.txtWriteDataLength.TabIndex = 3;
            this.txtWriteDataLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblWriteDataLength
            // 
            this.lblWriteDataLength.AutoSize = true;
            this.lblWriteDataLength.Location = new System.Drawing.Point(20, 182);
            this.lblWriteDataLength.Name = "lblWriteDataLength";
            this.lblWriteDataLength.Size = new System.Drawing.Size(76, 13);
            this.lblWriteDataLength.TabIndex = 12;
            this.lblWriteDataLength.Text = "Data Length";
            // 
            // txtWriteLinearAddress
            // 
            this.txtWriteLinearAddress.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWriteLinearAddress.Location = new System.Drawing.Point(127, 152);
            this.txtWriteLinearAddress.MaxLength = 3;
            this.txtWriteLinearAddress.Name = "txtWriteLinearAddress";
            this.txtWriteLinearAddress.Size = new System.Drawing.Size(40, 22);
            this.txtWriteLinearAddress.TabIndex = 2;
            this.txtWriteLinearAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblWriteLinearAddress
            // 
            this.lblWriteLinearAddress.AutoSize = true;
            this.lblWriteLinearAddress.Location = new System.Drawing.Point(20, 154);
            this.lblWriteLinearAddress.Name = "lblWriteLinearAddress";
            this.lblWriteLinearAddress.Size = new System.Drawing.Size(92, 13);
            this.lblWriteLinearAddress.TabIndex = 10;
            this.lblWriteLinearAddress.Text = "Linear Address";
            // 
            // txtWriteData
            // 
            this.txtWriteData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWriteData.Location = new System.Drawing.Point(20, 30);
            this.txtWriteData.Name = "txtWriteData";
            this.txtWriteData.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtWriteData.Size = new System.Drawing.Size(452, 118);
            this.txtWriteData.TabIndex = 1;
            this.txtWriteData.Text = "";
            // 
            // lblWriteData
            // 
            this.lblWriteData.AutoSize = true;
            this.lblWriteData.Location = new System.Drawing.Point(17, 12);
            this.lblWriteData.Name = "lblWriteData";
            this.lblWriteData.Size = new System.Drawing.Size(68, 13);
            this.lblWriteData.TabIndex = 8;
            this.lblWriteData.Text = "Write Data";
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 500;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // frmuFRSimpleImplementation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 662);
            this.Controls.Add(this.pgLinearReadWrite);
            this.Controls.Add(this.stbFunction_error);
            this.Controls.Add(this.pnlFormat);
            this.Controls.Add(this.pnlReader);
            this.Controls.Add(this.stbCardStatus);
            this.Controls.Add(this.mnuMeniItem);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.mnuMeniItem;
            this.MaximizeBox = false;
            this.Name = "frmuFRSimpleImplementation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "uFR  Simple ";
            this.Load += new System.EventHandler(this.frmuFRCoderSimpleImplementation_Load);
            this.stbCardStatus.ResumeLayout(false);
            this.stbCardStatus.PerformLayout();
            this.mnuMeniItem.ResumeLayout(false);
            this.mnuMeniItem.PerformLayout();
            this.pnlReader.ResumeLayout(false);
            this.pnlReader.PerformLayout();
            this.stbReader.ResumeLayout(false);
            this.stbReader.PerformLayout();
            this.pnlFormat.ResumeLayout(false);
            this.pgKeys.ResumeLayout(false);
            this.tabNewCardKeys.ResumeLayout(false);
            this.tabNewCardKeys.PerformLayout();
            this.tabNewReaderKey.ResumeLayout(false);
            this.tabNewReaderKey.PerformLayout();
            this.pnlAuth.ResumeLayout(false);
            this.pnlAuth.PerformLayout();
            this.stbFunction_error.ResumeLayout(false);
            this.stbFunction_error.PerformLayout();
            this.pgLinearReadWrite.ResumeLayout(false);
            this.tabLinearRead.ResumeLayout(false);
            this.tabLinearRead.PerformLayout();
            this.tabLinearWrite.ResumeLayout(false);
            this.tabLinearWrite.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stbCardStatus;
        private System.Windows.Forms.ToolStripStatusLabel pnlCard_status;
        private System.Windows.Forms.ToolStripStatusLabel pnlError_code;
        private System.Windows.Forms.ToolStripStatusLabel pnlError_explain;
        private System.Windows.Forms.MenuStrip mnuMeniItem;
        private System.Windows.Forms.ToolStripMenuItem mniExitItem;
        private System.Windows.Forms.Panel pnlReader;
        private System.Windows.Forms.StatusStrip stbReader;
        private System.Windows.Forms.ToolStripStatusLabel pnlConnected;
        private System.Windows.Forms.ToolStripStatusLabel pnlReader_error_code;
        private System.Windows.Forms.ToolStripStatusLabel pnlReader_err_explain;
        private System.Windows.Forms.TextBox txtCardSerial;
        private System.Windows.Forms.Label lblCardSerial;
        private System.Windows.Forms.TextBox txtCardType;
        private System.Windows.Forms.Label lblCardType;
        private System.Windows.Forms.TextBox txtReaderSerial;
        private System.Windows.Forms.Label lblReaderSerial;
        private System.Windows.Forms.TextBox txtReaderType;
        private System.Windows.Forms.Label lblReaderType;
        private System.Windows.Forms.ComboBox cboLightMode;
        private System.Windows.Forms.Label lblSoundMode;
        private System.Windows.Forms.ComboBox cboSoundMode;
        private System.Windows.Forms.Label lblLightMode;
        private System.Windows.Forms.Panel pnlSep;
        private System.Windows.Forms.Label lblKeyIndex;
        private System.Windows.Forms.TextBox txtReaderKeyIndex;
        private System.Windows.Forms.Button btnReaderUISignal;
        private System.Windows.Forms.Panel pnlFormat;
        private System.Windows.Forms.Panel pnlAuth;
        private System.Windows.Forms.RadioButton rbAUTH1B;
        private System.Windows.Forms.RadioButton rbAUTH1A;
        private System.Windows.Forms.StatusStrip stbFunction_error;
        private System.Windows.Forms.ToolStripStatusLabel pnlFunction;
        private System.Windows.Forms.ToolStripStatusLabel pnlFError_code;
        private System.Windows.Forms.ToolStripStatusLabel pnlFError_explain;
        private System.Windows.Forms.TabControl pgLinearReadWrite;
        private System.Windows.Forms.TabPage tabLinearRead;
        private System.Windows.Forms.TabPage tabLinearWrite;
        private System.Windows.Forms.Label lblLinearAddress;
        private System.Windows.Forms.RichTextBox txtReadData;
        private System.Windows.Forms.Label lblReadData;
        private System.Windows.Forms.Button btnLinearRead;
        private System.Windows.Forms.TextBox txtReadDataLength;
        private System.Windows.Forms.Label lblReadDataLength;
        private System.Windows.Forms.TextBox txtReadLinearAddress;
        private System.Windows.Forms.Button btnWriteData;
        private System.Windows.Forms.TextBox txtWriteDataLength;
        private System.Windows.Forms.Label lblWriteDataLength;
        private System.Windows.Forms.TextBox txtWriteLinearAddress;
        private System.Windows.Forms.Label lblWriteLinearAddress;
        private System.Windows.Forms.RichTextBox txtWriteData;
        private System.Windows.Forms.Label lblWriteData;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.TextBox txtReadBytes;
        private System.Windows.Forms.Label lblReadBytes;
        private System.Windows.Forms.TextBox txtBytesWritten;
        private System.Windows.Forms.Label lblBytesWritten;
        private System.Windows.Forms.TabControl pgKeys;
        private System.Windows.Forms.TabPage tabNewCardKeys;
        private System.Windows.Forms.TextBox txtSectorFormatted;
        private System.Windows.Forms.Label lblSectorFormatted;
        private System.Windows.Forms.Button btnFormatCard;
        private System.Windows.Forms.TabPage tabNewReaderKey;
        private System.Windows.Forms.CheckBox chkReaderKeyHex;
        private System.Windows.Forms.Button btnEnterReaderKey;
        private System.Windows.Forms.CheckBox chkCardKeysHex;
        private System.Windows.Forms.Label lblKeyB;
        private System.Windows.Forms.Label lblKeyA;
        private System.Windows.Forms.Panel pnlCardKeys;
        private System.Windows.Forms.Panel pnlReaderKey;
    }
}


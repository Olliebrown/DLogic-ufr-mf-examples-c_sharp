namespace uFRSimple
{
    partial class frmuFrSimple
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
            this.txtCardSerial = new System.Windows.Forms.TextBox();
            this.lblUID = new System.Windows.Forms.Label();
            this.txtUIDSize = new System.Windows.Forms.TextBox();
            this.lblUIDSize = new System.Windows.Forms.Label();
            this.btnReaderUISignal = new System.Windows.Forms.Button();
            this.cboLightMode = new System.Windows.Forms.ComboBox();
            this.lblSoundMode = new System.Windows.Forms.Label();
            this.cboSoundMode = new System.Windows.Forms.ComboBox();
            this.lblLightMode = new System.Windows.Forms.Label();
            this.pnlSep = new System.Windows.Forms.Panel();
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
            this.linkLabel_nfc = new System.Windows.Forms.LinkLabel();
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
            this.stbFunction = new System.Windows.Forms.StatusStrip();
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
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOpenArg = new System.Windows.Forms.TextBox();
            this.txtPortInterface = new System.Windows.Forms.TextBox();
            this.txtPortName = new System.Windows.Forms.TextBox();
            this.txtReaderTypeEx = new System.Windows.Forms.TextBox();
            this.labelOpenArg = new System.Windows.Forms.Label();
            this.labelPortInterface = new System.Windows.Forms.Label();
            this.labelPortName = new System.Windows.Forms.Label();
            this.labelReaderTypeEx = new System.Windows.Forms.Label();
            this.checkAdvanced = new System.Windows.Forms.CheckBox();
            this.btnReaderOpen = new System.Windows.Forms.Button();
            this.stbCardStatus.SuspendLayout();
            this.mnuMeniItem.SuspendLayout();
            this.pnlReader.SuspendLayout();
            this.stbReader.SuspendLayout();
            this.pnlFormat.SuspendLayout();
            this.pgKeys.SuspendLayout();
            this.tabNewCardKeys.SuspendLayout();
            this.tabNewReaderKey.SuspendLayout();
            this.pnlAuth.SuspendLayout();
            this.stbFunction.SuspendLayout();
            this.pgLinearReadWrite.SuspendLayout();
            this.tabLinearRead.SuspendLayout();
            this.tabLinearWrite.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // stbCardStatus
            // 
            this.stbCardStatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stbCardStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pnlCard_status,
            this.pnlError_code,
            this.pnlError_explain});
            this.stbCardStatus.Location = new System.Drawing.Point(0, 758);
            this.stbCardStatus.Name = "stbCardStatus";
            this.stbCardStatus.Size = new System.Drawing.Size(577, 22);
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
            this.pnlError_explain.Size = new System.Drawing.Size(392, 17);
            this.pnlError_explain.Spring = true;
            this.pnlError_explain.Text = " ";
            // 
            // mnuMeniItem
            // 
            this.mnuMeniItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniExitItem});
            this.mnuMeniItem.Location = new System.Drawing.Point(0, 0);
            this.mnuMeniItem.Name = "mnuMeniItem";
            this.mnuMeniItem.Size = new System.Drawing.Size(577, 24);
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
            this.pnlReader.Controls.Add(this.txtCardSerial);
            this.pnlReader.Controls.Add(this.lblUID);
            this.pnlReader.Controls.Add(this.txtUIDSize);
            this.pnlReader.Controls.Add(this.lblUIDSize);
            this.pnlReader.Controls.Add(this.btnReaderUISignal);
            this.pnlReader.Controls.Add(this.cboLightMode);
            this.pnlReader.Controls.Add(this.lblSoundMode);
            this.pnlReader.Controls.Add(this.cboSoundMode);
            this.pnlReader.Controls.Add(this.lblLightMode);
            this.pnlReader.Controls.Add(this.pnlSep);
            this.pnlReader.Controls.Add(this.txtCardType);
            this.pnlReader.Controls.Add(this.lblCardType);
            this.pnlReader.Controls.Add(this.txtReaderSerial);
            this.pnlReader.Controls.Add(this.lblReaderSerial);
            this.pnlReader.Controls.Add(this.txtReaderType);
            this.pnlReader.Controls.Add(this.lblReaderType);
            this.pnlReader.Controls.Add(this.stbReader);
            this.pnlReader.Location = new System.Drawing.Point(6, 143);
            this.pnlReader.Name = "pnlReader";
            this.pnlReader.Size = new System.Drawing.Size(528, 181);
            this.pnlReader.TabIndex = 2;
            // 
            // txtCardSerial
            // 
            this.txtCardSerial.BackColor = System.Drawing.Color.White;
            this.txtCardSerial.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardSerial.Location = new System.Drawing.Point(357, 38);
            this.txtCardSerial.Name = "txtCardSerial";
            this.txtCardSerial.ReadOnly = true;
            this.txtCardSerial.Size = new System.Drawing.Size(145, 21);
            this.txtCardSerial.TabIndex = 19;
            this.txtCardSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.Location = new System.Drawing.Point(281, 41);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(72, 13);
            this.lblUID.TabIndex = 18;
            this.lblUID.Text = "Card Serial";
            // 
            // txtUIDSize
            // 
            this.txtUIDSize.BackColor = System.Drawing.Color.White;
            this.txtUIDSize.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUIDSize.Location = new System.Drawing.Point(464, 10);
            this.txtUIDSize.Name = "txtUIDSize";
            this.txtUIDSize.ReadOnly = true;
            this.txtUIDSize.Size = new System.Drawing.Size(38, 21);
            this.txtUIDSize.TabIndex = 17;
            this.txtUIDSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.txtUIDSize, "Card UID Size");
            // 
            // lblUIDSize
            // 
            this.lblUIDSize.AutoSize = true;
            this.lblUIDSize.Location = new System.Drawing.Point(401, 13);
            this.lblUIDSize.Name = "lblUIDSize";
            this.lblUIDSize.Size = new System.Drawing.Size(57, 13);
            this.lblUIDSize.TabIndex = 16;
            this.lblUIDSize.Text = "UID Size";
            // 
            // btnReaderUISignal
            // 
            this.btnReaderUISignal.BackColor = System.Drawing.Color.White;
            this.btnReaderUISignal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReaderUISignal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnReaderUISignal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReaderUISignal.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReaderUISignal.Location = new System.Drawing.Point(335, 92);
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
            this.cboLightMode.Location = new System.Drawing.Point(154, 92);
            this.cboLightMode.Name = "cboLightMode";
            this.cboLightMode.Size = new System.Drawing.Size(116, 21);
            this.cboLightMode.TabIndex = 14;
            // 
            // lblSoundMode
            // 
            this.lblSoundMode.AutoSize = true;
            this.lblSoundMode.Location = new System.Drawing.Point(61, 122);
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
            this.cboSoundMode.Location = new System.Drawing.Point(154, 119);
            this.cboSoundMode.Name = "cboSoundMode";
            this.cboSoundMode.Size = new System.Drawing.Size(116, 21);
            this.cboSoundMode.TabIndex = 12;
            // 
            // lblLightMode
            // 
            this.lblLightMode.AutoSize = true;
            this.lblLightMode.Location = new System.Drawing.Point(61, 95);
            this.lblLightMode.Name = "lblLightMode";
            this.lblLightMode.Size = new System.Drawing.Size(68, 13);
            this.lblLightMode.TabIndex = 11;
            this.lblLightMode.Text = "Light Mode";
            // 
            // pnlSep
            // 
            this.pnlSep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSep.Location = new System.Drawing.Point(24, 67);
            this.pnlSep.Name = "pnlSep";
            this.pnlSep.Size = new System.Drawing.Size(478, 5);
            this.pnlSep.TabIndex = 10;
            // 
            // txtCardType
            // 
            this.txtCardType.BackColor = System.Drawing.Color.White;
            this.txtCardType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardType.Location = new System.Drawing.Point(357, 10);
            this.txtCardType.Name = "txtCardType";
            this.txtCardType.ReadOnly = true;
            this.txtCardType.Size = new System.Drawing.Size(38, 21);
            this.txtCardType.TabIndex = 7;
            this.txtCardType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCardType
            // 
            this.lblCardType.AutoSize = true;
            this.lblCardType.Location = new System.Drawing.Point(281, 14);
            this.lblCardType.Name = "lblCardType";
            this.lblCardType.Size = new System.Drawing.Size(66, 13);
            this.lblCardType.TabIndex = 6;
            this.lblCardType.Text = "Card Type";
            // 
            // txtReaderSerial
            // 
            this.txtReaderSerial.BackColor = System.Drawing.Color.White;
            this.txtReaderSerial.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReaderSerial.Location = new System.Drawing.Point(119, 37);
            this.txtReaderSerial.Name = "txtReaderSerial";
            this.txtReaderSerial.ReadOnly = true;
            this.txtReaderSerial.Size = new System.Drawing.Size(102, 21);
            this.txtReaderSerial.TabIndex = 5;
            this.txtReaderSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblReaderSerial
            // 
            this.lblReaderSerial.AutoSize = true;
            this.lblReaderSerial.Location = new System.Drawing.Point(21, 41);
            this.lblReaderSerial.Name = "lblReaderSerial";
            this.lblReaderSerial.Size = new System.Drawing.Size(85, 13);
            this.lblReaderSerial.TabIndex = 4;
            this.lblReaderSerial.Text = "Reader Serial";
            // 
            // txtReaderType
            // 
            this.txtReaderType.BackColor = System.Drawing.Color.White;
            this.txtReaderType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReaderType.Location = new System.Drawing.Point(119, 10);
            this.txtReaderType.Name = "txtReaderType";
            this.txtReaderType.ReadOnly = true;
            this.txtReaderType.Size = new System.Drawing.Size(102, 21);
            this.txtReaderType.TabIndex = 3;
            this.txtReaderType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblReaderType
            // 
            this.lblReaderType.AutoSize = true;
            this.lblReaderType.Location = new System.Drawing.Point(21, 14);
            this.lblReaderType.Name = "lblReaderType";
            this.lblReaderType.Size = new System.Drawing.Size(79, 13);
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
            this.stbReader.Location = new System.Drawing.Point(0, 155);
            this.stbReader.Name = "stbReader";
            this.stbReader.Size = new System.Drawing.Size(524, 22);
            this.stbReader.SizingGrip = false;
            this.stbReader.TabIndex = 1;
            // 
            // pnlConnected
            // 
            this.pnlConnected.AutoSize = false;
            this.pnlConnected.BackColor = System.Drawing.Color.LightGray;
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
            this.pnlReader_err_explain.Size = new System.Drawing.Size(339, 17);
            this.pnlReader_err_explain.Spring = true;
            this.pnlReader_err_explain.Text = " ";
            // 
            // linkLabel_nfc
            // 
            this.linkLabel_nfc.AutoSize = true;
            this.linkLabel_nfc.Location = new System.Drawing.Point(306, 32);
            this.linkLabel_nfc.Name = "linkLabel_nfc";
            this.linkLabel_nfc.Size = new System.Drawing.Size(254, 13);
            this.linkLabel_nfc.TabIndex = 20;
            this.linkLabel_nfc.TabStop = true;
            this.linkLabel_nfc.Text = "http://www.d-logic.net/nfc-rfid-reader-sdk/";
            this.linkLabel_nfc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_nfc_LinkClicked);
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
            this.txtReaderKeyIndex.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReaderKeyIndex.Location = new System.Drawing.Point(230, 51);
            this.txtReaderKeyIndex.Name = "txtReaderKeyIndex";
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
            this.pnlFormat.Location = new System.Drawing.Point(6, 325);
            this.pnlFormat.Name = "pnlFormat";
            this.pnlFormat.Size = new System.Drawing.Size(528, 174);
            this.pnlFormat.TabIndex = 3;
            // 
            // pgKeys
            // 
            this.pgKeys.Controls.Add(this.tabNewCardKeys);
            this.pgKeys.Controls.Add(this.tabNewReaderKey);
            this.pgKeys.Location = new System.Drawing.Point(27, 33);
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
            this.pnlAuth.Size = new System.Drawing.Size(524, 27);
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
            // stbFunction
            // 
            this.stbFunction.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stbFunction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pnlFunction,
            this.pnlFError_code,
            this.pnlFError_explain});
            this.stbFunction.Location = new System.Drawing.Point(0, 736);
            this.stbFunction.Name = "stbFunction";
            this.stbFunction.Size = new System.Drawing.Size(577, 22);
            this.stbFunction.SizingGrip = false;
            this.stbFunction.TabIndex = 5;
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
            this.pnlFError_explain.Size = new System.Drawing.Size(392, 17);
            this.pnlFError_explain.Spring = true;
            this.pnlFError_explain.Text = " ";
            // 
            // pgLinearReadWrite
            // 
            this.pgLinearReadWrite.Controls.Add(this.tabLinearRead);
            this.pgLinearReadWrite.Controls.Add(this.tabLinearWrite);
            this.pgLinearReadWrite.Location = new System.Drawing.Point(4, 501);
            this.pgLinearReadWrite.Name = "pgLinearReadWrite";
            this.pgLinearReadWrite.SelectedIndex = 0;
            this.pgLinearReadWrite.Size = new System.Drawing.Size(528, 232);
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
            this.tabLinearRead.Size = new System.Drawing.Size(520, 206);
            this.tabLinearRead.TabIndex = 0;
            this.tabLinearRead.Text = "Linear Read";
            this.tabLinearRead.UseVisualStyleBackColor = true;
            // 
            // txtReadBytes
            // 
            this.txtReadBytes.BackColor = System.Drawing.Color.Silver;
            this.txtReadBytes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReadBytes.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReadBytes.Location = new System.Drawing.Point(264, 159);
            this.txtReadBytes.MaxLength = 5;
            this.txtReadBytes.Name = "txtReadBytes";
            this.txtReadBytes.ReadOnly = true;
            this.txtReadBytes.Size = new System.Drawing.Size(45, 22);
            this.txtReadBytes.TabIndex = 9;
            this.txtReadBytes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblReadBytes
            // 
            this.lblReadBytes.AutoSize = true;
            this.lblReadBytes.Location = new System.Drawing.Point(175, 162);
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
            this.btnLinearRead.Location = new System.Drawing.Point(325, 145);
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
            this.txtReadDataLength.Location = new System.Drawing.Point(114, 171);
            this.txtReadDataLength.MaxLength = 5;
            this.txtReadDataLength.Name = "txtReadDataLength";
            this.txtReadDataLength.Size = new System.Drawing.Size(45, 22);
            this.txtReadDataLength.TabIndex = 4;
            this.txtReadDataLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblReadDataLength
            // 
            this.lblReadDataLength.AutoSize = true;
            this.lblReadDataLength.Location = new System.Drawing.Point(7, 173);
            this.lblReadDataLength.Name = "lblReadDataLength";
            this.lblReadDataLength.Size = new System.Drawing.Size(76, 13);
            this.lblReadDataLength.TabIndex = 4;
            this.lblReadDataLength.Text = "Data Length";
            // 
            // txtReadLinearAddress
            // 
            this.txtReadLinearAddress.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReadLinearAddress.Location = new System.Drawing.Point(114, 143);
            this.txtReadLinearAddress.MaxLength = 5;
            this.txtReadLinearAddress.Name = "txtReadLinearAddress";
            this.txtReadLinearAddress.Size = new System.Drawing.Size(45, 22);
            this.txtReadLinearAddress.TabIndex = 3;
            this.txtReadLinearAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLinearAddress
            // 
            this.lblLinearAddress.AutoSize = true;
            this.lblLinearAddress.Location = new System.Drawing.Point(7, 145);
            this.lblLinearAddress.Name = "lblLinearAddress";
            this.lblLinearAddress.Size = new System.Drawing.Size(92, 13);
            this.lblLinearAddress.TabIndex = 2;
            this.lblLinearAddress.Text = "Linear Address";
            // 
            // txtReadData
            // 
            this.txtReadData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReadData.Location = new System.Drawing.Point(7, 21);
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
            this.lblReadData.Location = new System.Drawing.Point(4, 3);
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
            this.tabLinearWrite.Size = new System.Drawing.Size(520, 206);
            this.tabLinearWrite.TabIndex = 1;
            this.tabLinearWrite.Text = "Linear Write";
            this.tabLinearWrite.UseVisualStyleBackColor = true;
            // 
            // txtBytesWritten
            // 
            this.txtBytesWritten.BackColor = System.Drawing.Color.Silver;
            this.txtBytesWritten.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBytesWritten.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBytesWritten.Location = new System.Drawing.Point(266, 159);
            this.txtBytesWritten.MaxLength = 5;
            this.txtBytesWritten.Name = "txtBytesWritten";
            this.txtBytesWritten.ReadOnly = true;
            this.txtBytesWritten.Size = new System.Drawing.Size(45, 22);
            this.txtBytesWritten.TabIndex = 14;
            this.txtBytesWritten.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBytesWritten
            // 
            this.lblBytesWritten.AutoSize = true;
            this.lblBytesWritten.Location = new System.Drawing.Point(177, 162);
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
            this.btnWriteData.Location = new System.Drawing.Point(327, 145);
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
            this.txtWriteDataLength.Location = new System.Drawing.Point(116, 171);
            this.txtWriteDataLength.MaxLength = 5;
            this.txtWriteDataLength.Name = "txtWriteDataLength";
            this.txtWriteDataLength.Size = new System.Drawing.Size(45, 22);
            this.txtWriteDataLength.TabIndex = 3;
            this.txtWriteDataLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblWriteDataLength
            // 
            this.lblWriteDataLength.AutoSize = true;
            this.lblWriteDataLength.Location = new System.Drawing.Point(9, 173);
            this.lblWriteDataLength.Name = "lblWriteDataLength";
            this.lblWriteDataLength.Size = new System.Drawing.Size(76, 13);
            this.lblWriteDataLength.TabIndex = 12;
            this.lblWriteDataLength.Text = "Data Length";
            // 
            // txtWriteLinearAddress
            // 
            this.txtWriteLinearAddress.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWriteLinearAddress.Location = new System.Drawing.Point(116, 143);
            this.txtWriteLinearAddress.MaxLength = 5;
            this.txtWriteLinearAddress.Name = "txtWriteLinearAddress";
            this.txtWriteLinearAddress.Size = new System.Drawing.Size(45, 22);
            this.txtWriteLinearAddress.TabIndex = 2;
            this.txtWriteLinearAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblWriteLinearAddress
            // 
            this.lblWriteLinearAddress.AutoSize = true;
            this.lblWriteLinearAddress.Location = new System.Drawing.Point(9, 145);
            this.lblWriteLinearAddress.Name = "lblWriteLinearAddress";
            this.lblWriteLinearAddress.Size = new System.Drawing.Size(92, 13);
            this.lblWriteLinearAddress.TabIndex = 10;
            this.lblWriteLinearAddress.Text = "Linear Address";
            // 
            // txtWriteData
            // 
            this.txtWriteData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWriteData.Location = new System.Drawing.Point(9, 21);
            this.txtWriteData.Name = "txtWriteData";
            this.txtWriteData.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtWriteData.Size = new System.Drawing.Size(452, 118);
            this.txtWriteData.TabIndex = 1;
            this.txtWriteData.Text = "";
            this.txtWriteData.TextChanged += new System.EventHandler(this.txtWriteData_TextChanged);
            // 
            // lblWriteData
            // 
            this.lblWriteData.AutoSize = true;
            this.lblWriteData.Location = new System.Drawing.Point(6, 3);
            this.lblWriteData.Name = "lblWriteData";
            this.lblWriteData.Size = new System.Drawing.Size(68, 13);
            this.lblWriteData.TabIndex = 8;
            this.lblWriteData.Text = "Write Data";
            // 
            // Timer
            // 
            this.Timer.Interval = 250;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabel_nfc);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.checkAdvanced);
            this.groupBox1.Controls.Add(this.btnReaderOpen);
            this.groupBox1.Location = new System.Drawing.Point(4, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(567, 110);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reader Open";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtOpenArg);
            this.groupBox2.Controls.Add(this.txtPortInterface);
            this.groupBox2.Controls.Add(this.txtPortName);
            this.groupBox2.Controls.Add(this.txtReaderTypeEx);
            this.groupBox2.Controls.Add(this.labelOpenArg);
            this.groupBox2.Controls.Add(this.labelPortInterface);
            this.groupBox2.Controls.Add(this.labelPortName);
            this.groupBox2.Controls.Add(this.labelReaderTypeEx);
            this.groupBox2.Location = new System.Drawing.Point(6, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(569, 47);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Advanced options";
            // 
            // txtOpenArg
            // 
            this.txtOpenArg.Enabled = false;
            this.txtOpenArg.Location = new System.Drawing.Point(486, 15);
            this.txtOpenArg.Name = "txtOpenArg";
            this.txtOpenArg.Size = new System.Drawing.Size(68, 21);
            this.txtOpenArg.TabIndex = 7;
            // 
            // txtPortInterface
            // 
            this.txtPortInterface.Enabled = false;
            this.txtPortInterface.Location = new System.Drawing.Point(399, 15);
            this.txtPortInterface.Name = "txtPortInterface";
            this.txtPortInterface.Size = new System.Drawing.Size(43, 21);
            this.txtPortInterface.TabIndex = 6;
            // 
            // txtPortName
            // 
            this.txtPortName.Enabled = false;
            this.txtPortName.Location = new System.Drawing.Point(196, 15);
            this.txtPortName.Name = "txtPortName";
            this.txtPortName.Size = new System.Drawing.Size(102, 21);
            this.txtPortName.TabIndex = 5;
            // 
            // txtReaderTypeEx
            // 
            this.txtReaderTypeEx.Enabled = false;
            this.txtReaderTypeEx.Location = new System.Drawing.Point(92, 15);
            this.txtReaderTypeEx.Name = "txtReaderTypeEx";
            this.txtReaderTypeEx.Size = new System.Drawing.Size(24, 21);
            this.txtReaderTypeEx.TabIndex = 4;
            // 
            // labelOpenArg
            // 
            this.labelOpenArg.AutoSize = true;
            this.labelOpenArg.Enabled = false;
            this.labelOpenArg.Location = new System.Drawing.Point(448, 18);
            this.labelOpenArg.Name = "labelOpenArg";
            this.labelOpenArg.Size = new System.Drawing.Size(32, 13);
            this.labelOpenArg.TabIndex = 3;
            this.labelOpenArg.Text = "Arg:";
            // 
            // labelPortInterface
            // 
            this.labelPortInterface.AutoSize = true;
            this.labelPortInterface.Enabled = false;
            this.labelPortInterface.Location = new System.Drawing.Point(304, 18);
            this.labelPortInterface.Name = "labelPortInterface";
            this.labelPortInterface.Size = new System.Drawing.Size(89, 13);
            this.labelPortInterface.TabIndex = 2;
            this.labelPortInterface.Text = "Port interface:";
            // 
            // labelPortName
            // 
            this.labelPortName.AutoSize = true;
            this.labelPortName.Enabled = false;
            this.labelPortName.Location = new System.Drawing.Point(119, 18);
            this.labelPortName.Name = "labelPortName";
            this.labelPortName.Size = new System.Drawing.Size(71, 13);
            this.labelPortName.TabIndex = 1;
            this.labelPortName.Text = "Port name:";
            // 
            // labelReaderTypeEx
            // 
            this.labelReaderTypeEx.AutoSize = true;
            this.labelReaderTypeEx.Enabled = false;
            this.labelReaderTypeEx.Location = new System.Drawing.Point(5, 18);
            this.labelReaderTypeEx.Name = "labelReaderTypeEx";
            this.labelReaderTypeEx.Size = new System.Drawing.Size(82, 13);
            this.labelReaderTypeEx.TabIndex = 0;
            this.labelReaderTypeEx.Text = "Reader type:";
            // 
            // checkAdvanced
            // 
            this.checkAdvanced.AutoSize = true;
            this.checkAdvanced.Location = new System.Drawing.Point(117, 31);
            this.checkAdvanced.Name = "checkAdvanced";
            this.checkAdvanced.Size = new System.Drawing.Size(152, 17);
            this.checkAdvanced.TabIndex = 1;
            this.checkAdvanced.Text = "Use Advanced options";
            this.checkAdvanced.UseVisualStyleBackColor = true;
            this.checkAdvanced.CheckedChanged += new System.EventHandler(this.checkAdvanced_CheckedChanged);
            // 
            // btnReaderOpen
            // 
            this.btnReaderOpen.Location = new System.Drawing.Point(6, 20);
            this.btnReaderOpen.Name = "btnReaderOpen";
            this.btnReaderOpen.Size = new System.Drawing.Size(105, 37);
            this.btnReaderOpen.TabIndex = 0;
            this.btnReaderOpen.Text = "Reader Open";
            this.btnReaderOpen.UseVisualStyleBackColor = true;
            this.btnReaderOpen.Click += new System.EventHandler(this.btnReaderOpen_Click);
            // 
            // frmuFrSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 780);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pgLinearReadWrite);
            this.Controls.Add(this.stbFunction);
            this.Controls.Add(this.pnlFormat);
            this.Controls.Add(this.pnlReader);
            this.Controls.Add(this.stbCardStatus);
            this.Controls.Add(this.mnuMeniItem);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.mnuMeniItem;
            this.MaximizeBox = false;
            this.Name = "frmuFrSimple";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "uFr  Simple ";
            this.Load += new System.EventHandler(this.frmuFrSimple_Load);
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
            this.stbFunction.ResumeLayout(false);
            this.stbFunction.PerformLayout();
            this.pgLinearReadWrite.ResumeLayout(false);
            this.tabLinearRead.ResumeLayout(false);
            this.tabLinearRead.PerformLayout();
            this.tabLinearWrite.ResumeLayout(false);
            this.tabLinearWrite.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.StatusStrip stbFunction;
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
        private System.Windows.Forms.TextBox txtUIDSize;
        private System.Windows.Forms.Label lblUIDSize;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TextBox txtCardSerial;
        private System.Windows.Forms.Label lblUID;
        private System.Windows.Forms.LinkLabel linkLabel_nfc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtOpenArg;
        private System.Windows.Forms.TextBox txtPortInterface;
        private System.Windows.Forms.TextBox txtPortName;
        private System.Windows.Forms.TextBox txtReaderTypeEx;
        private System.Windows.Forms.Label labelOpenArg;
        private System.Windows.Forms.Label labelPortInterface;
        private System.Windows.Forms.Label labelPortName;
        private System.Windows.Forms.Label labelReaderTypeEx;
        private System.Windows.Forms.CheckBox checkAdvanced;
        private System.Windows.Forms.Button btnReaderOpen;
    }
}


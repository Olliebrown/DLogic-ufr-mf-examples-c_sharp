namespace uFrAdvance
{
    partial class frmuFrAdvance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            this.stbCard = new System.Windows.Forms.StatusStrip();
            this.pnlCardStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.stbErrCode = new System.Windows.Forms.ToolStripStatusLabel();
            this.stbErr_explain = new System.Windows.Forms.ToolStripStatusLabel();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.mnuMeni = new System.Windows.Forms.MenuStrip();
            this.mnuFunctionsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLinearReadWriteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SEP0 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBlockReadWriteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBlockInSectorReadWriteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SEP1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuValueBlockReadWriteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuValueBlockIncrDecrItems = new System.Windows.Forms.ToolStripMenuItem();
            this.SEP2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuValueBlockInSectorReadWrite = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuValueBlockInSectorIncrDecrItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SEP4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSectorTrailerWriteItems = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLinearFormatCardItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SEP3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuHardwareFirmwareVersionItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewAllItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlReader = new System.Windows.Forms.Panel();
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
            this.llblNfcSdk = new System.Windows.Forms.LinkLabel();
            this.checkAdvanced = new System.Windows.Forms.CheckBox();
            this.btnReaderOpen = new System.Windows.Forms.Button();
            this.txtCardSerial = new System.Windows.Forms.TextBox();
            this.lblUID = new System.Windows.Forms.Label();
            this.txtUIDSize = new System.Windows.Forms.TextBox();
            this.lblUIDSize = new System.Windows.Forms.Label();
            this.pgReaderUserData = new System.Windows.Forms.TabControl();
            this.pnlReaderKey = new System.Windows.Forms.TabPage();
            this.lblKeyIndex = new System.Windows.Forms.Label();
            this.btnReaderKeyWrite = new System.Windows.Forms.Button();
            this.cboKeyIndex = new System.Windows.Forms.ComboBox();
            this.chkHex = new System.Windows.Forms.CheckBox();
            this.tabUserData = new System.Windows.Forms.TabPage();
            this.btnWriteUserData = new System.Windows.Forms.Button();
            this.txtNewUserData = new System.Windows.Forms.TextBox();
            this.lblNewUserData = new System.Windows.Forms.Label();
            this.txtUserData = new System.Windows.Forms.TextBox();
            this.lblUserData = new System.Windows.Forms.Label();
            this.stbReader = new System.Windows.Forms.StatusStrip();
            this.pnlConn = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlErr_code = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlErr_expl = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSoftRestart = new System.Windows.Forms.Button();
            this.btnReaderReset = new System.Windows.Forms.Button();
            this.btnReaderUISignal = new System.Windows.Forms.Button();
            this.lblSoundMode = new System.Windows.Forms.Label();
            this.cboSoundMode = new System.Windows.Forms.ComboBox();
            this.lblLightMode = new System.Windows.Forms.Label();
            this.cboLightMode = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCardType = new System.Windows.Forms.TextBox();
            this.lblCardType = new System.Windows.Forms.Label();
            this.txtReaderSerial = new System.Windows.Forms.TextBox();
            this.lblReaderSerial = new System.Windows.Forms.Label();
            this.txtReaderType = new System.Windows.Forms.TextBox();
            this.lblReaderType = new System.Windows.Forms.Label();
            this.pnlConteiner = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.stbCard.SuspendLayout();
            this.mnuMeni.SuspendLayout();
            this.pnlReader.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pgReaderUserData.SuspendLayout();
            this.pnlReaderKey.SuspendLayout();
            this.tabUserData.SuspendLayout();
            this.stbReader.SuspendLayout();
            this.SuspendLayout();
            // 
            // stbCard
            // 
            this.stbCard.BackColor = System.Drawing.SystemColors.Control;
            this.stbCard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pnlCardStatus,
            this.stbErrCode,
            this.stbErr_explain});
            this.stbCard.Location = new System.Drawing.Point(0, 779);
            this.stbCard.Name = "stbCard";
            this.stbCard.Size = new System.Drawing.Size(569, 22);
            this.stbCard.SizingGrip = false;
            this.stbCard.TabIndex = 0;
            this.stbCard.Text = " ";
            // 
            // pnlCardStatus
            // 
            this.pnlCardStatus.AutoSize = false;
            this.pnlCardStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.pnlCardStatus.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.pnlCardStatus.Name = "pnlCardStatus";
            this.pnlCardStatus.Size = new System.Drawing.Size(122, 17);
            this.pnlCardStatus.Text = "CARD STATUS";
            // 
            // stbErrCode
            // 
            this.stbErrCode.AutoSize = false;
            this.stbErrCode.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.stbErrCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stbErrCode.Name = "stbErrCode";
            this.stbErrCode.Size = new System.Drawing.Size(50, 17);
            this.stbErrCode.Text = " ";
            // 
            // stbErr_explain
            // 
            this.stbErr_explain.BackColor = System.Drawing.SystemColors.Control;
            this.stbErr_explain.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.stbErr_explain.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stbErr_explain.Name = "stbErr_explain";
            this.stbErr_explain.Size = new System.Drawing.Size(382, 17);
            this.stbErr_explain.Spring = true;
            this.stbErr_explain.Text = " ";
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 500;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // mnuMeni
            // 
            this.mnuMeni.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.mnuMeni.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFunctionsItem,
            this.mnuViewAllItem});
            this.mnuMeni.Location = new System.Drawing.Point(0, 0);
            this.mnuMeni.Name = "mnuMeni";
            this.mnuMeni.Size = new System.Drawing.Size(569, 24);
            this.mnuMeni.TabIndex = 3;
            // 
            // mnuFunctionsItem
            // 
            this.mnuFunctionsItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLinearReadWriteItem,
            this.SEP0,
            this.mnuBlockReadWriteItem,
            this.mnuBlockInSectorReadWriteItem,
            this.SEP1,
            this.mnuValueBlockReadWriteItem,
            this.mnuValueBlockIncrDecrItems,
            this.SEP2,
            this.mnuValueBlockInSectorReadWrite,
            this.mnuValueBlockInSectorIncrDecrItem,
            this.SEP4,
            this.mnuSectorTrailerWriteItems,
            this.mnuLinearFormatCardItem,
            this.SEP3,
            this.mnuHardwareFirmwareVersionItem,
            this.toolStripSeparator1,
            this.mnuExitItem});
            this.mnuFunctionsItem.Name = "mnuFunctionsItem";
            this.mnuFunctionsItem.Size = new System.Drawing.Size(72, 20);
            this.mnuFunctionsItem.Text = "Functions";
            // 
            // mnuLinearReadWriteItem
            // 
            this.mnuLinearReadWriteItem.Name = "mnuLinearReadWriteItem";
            this.mnuLinearReadWriteItem.Size = new System.Drawing.Size(316, 22);
            this.mnuLinearReadWriteItem.Text = "Linear Read/Write";
            this.mnuLinearReadWriteItem.Click += new System.EventHandler(this.linearReadWriteToolStripMenuItem_Click);
            // 
            // SEP0
            // 
            this.SEP0.Name = "SEP0";
            this.SEP0.Size = new System.Drawing.Size(313, 6);
            // 
            // mnuBlockReadWriteItem
            // 
            this.mnuBlockReadWriteItem.Name = "mnuBlockReadWriteItem";
            this.mnuBlockReadWriteItem.Size = new System.Drawing.Size(316, 22);
            this.mnuBlockReadWriteItem.Text = "Block Read/Write";
            this.mnuBlockReadWriteItem.Click += new System.EventHandler(this.mnuBlockReadWriteItem_Click);
            // 
            // mnuBlockInSectorReadWriteItem
            // 
            this.mnuBlockInSectorReadWriteItem.Name = "mnuBlockInSectorReadWriteItem";
            this.mnuBlockInSectorReadWriteItem.Size = new System.Drawing.Size(316, 22);
            this.mnuBlockInSectorReadWriteItem.Text = "BlockInSector Read/Write";
            this.mnuBlockInSectorReadWriteItem.Click += new System.EventHandler(this.mnuBlockInSectorReadWriteItem_Click);
            // 
            // SEP1
            // 
            this.SEP1.Name = "SEP1";
            this.SEP1.Size = new System.Drawing.Size(313, 6);
            // 
            // mnuValueBlockReadWriteItem
            // 
            this.mnuValueBlockReadWriteItem.Name = "mnuValueBlockReadWriteItem";
            this.mnuValueBlockReadWriteItem.Size = new System.Drawing.Size(316, 22);
            this.mnuValueBlockReadWriteItem.Text = "ValueBlock Read/Write";
            this.mnuValueBlockReadWriteItem.Click += new System.EventHandler(this.mnuValueBlockReadWriteItem_Click);
            // 
            // mnuValueBlockIncrDecrItems
            // 
            this.mnuValueBlockIncrDecrItems.Name = "mnuValueBlockIncrDecrItems";
            this.mnuValueBlockIncrDecrItems.Size = new System.Drawing.Size(316, 22);
            this.mnuValueBlockIncrDecrItems.Text = "ValueBlock Increment/Decrement";
            this.mnuValueBlockIncrDecrItems.Click += new System.EventHandler(this.mnuValueBlockIncrDecrItems_Click);
            // 
            // SEP2
            // 
            this.SEP2.Name = "SEP2";
            this.SEP2.Size = new System.Drawing.Size(313, 6);
            // 
            // mnuValueBlockInSectorReadWrite
            // 
            this.mnuValueBlockInSectorReadWrite.Name = "mnuValueBlockInSectorReadWrite";
            this.mnuValueBlockInSectorReadWrite.Size = new System.Drawing.Size(316, 22);
            this.mnuValueBlockInSectorReadWrite.Text = "ValueBlockInSector Read/Write";
            this.mnuValueBlockInSectorReadWrite.Click += new System.EventHandler(this.mnuValueBlockInSectorReadWrite_Click);
            // 
            // mnuValueBlockInSectorIncrDecrItem
            // 
            this.mnuValueBlockInSectorIncrDecrItem.Name = "mnuValueBlockInSectorIncrDecrItem";
            this.mnuValueBlockInSectorIncrDecrItem.Size = new System.Drawing.Size(316, 22);
            this.mnuValueBlockInSectorIncrDecrItem.Text = "ValueBlockInSector Increment/Decrement";
            this.mnuValueBlockInSectorIncrDecrItem.Click += new System.EventHandler(this.mnuValueBlockInSectorIncrDecrItem_Click);
            // 
            // SEP4
            // 
            this.SEP4.Name = "SEP4";
            this.SEP4.Size = new System.Drawing.Size(313, 6);
            // 
            // mnuSectorTrailerWriteItems
            // 
            this.mnuSectorTrailerWriteItems.Name = "mnuSectorTrailerWriteItems";
            this.mnuSectorTrailerWriteItems.Size = new System.Drawing.Size(316, 22);
            this.mnuSectorTrailerWriteItems.Text = "Sector Trailer Write";
            this.mnuSectorTrailerWriteItems.Click += new System.EventHandler(this.mnuSectorTrailerWriteItems_Click);
            // 
            // mnuLinearFormatCardItem
            // 
            this.mnuLinearFormatCardItem.Name = "mnuLinearFormatCardItem";
            this.mnuLinearFormatCardItem.Size = new System.Drawing.Size(316, 22);
            this.mnuLinearFormatCardItem.Text = "Linear Format Card";
            this.mnuLinearFormatCardItem.Click += new System.EventHandler(this.mnuLinearFormatCardItem_Click);
            // 
            // SEP3
            // 
            this.SEP3.Name = "SEP3";
            this.SEP3.Size = new System.Drawing.Size(313, 6);
            // 
            // mnuHardwareFirmwareVersionItem
            // 
            this.mnuHardwareFirmwareVersionItem.Name = "mnuHardwareFirmwareVersionItem";
            this.mnuHardwareFirmwareVersionItem.Size = new System.Drawing.Size(316, 22);
            this.mnuHardwareFirmwareVersionItem.Text = "Reader Hardware/Firmware Version";
            this.mnuHardwareFirmwareVersionItem.Click += new System.EventHandler(this.mnuHardwareFirmwareVersionItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(313, 6);
            // 
            // mnuExitItem
            // 
            this.mnuExitItem.Name = "mnuExitItem";
            this.mnuExitItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mnuExitItem.Size = new System.Drawing.Size(316, 22);
            this.mnuExitItem.Text = "EXIT";
            this.mnuExitItem.Click += new System.EventHandler(this.mnuExitItem_Click);
            // 
            // mnuViewAllItem
            // 
            this.mnuViewAllItem.Name = "mnuViewAllItem";
            this.mnuViewAllItem.Size = new System.Drawing.Size(64, 20);
            this.mnuViewAllItem.Text = "View All";
            this.mnuViewAllItem.Click += new System.EventHandler(this.mnuViewAllItem_Click_1);
            // 
            // pnlReader
            // 
            this.pnlReader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReader.Controls.Add(this.groupBox1);
            this.pnlReader.Controls.Add(this.txtCardSerial);
            this.pnlReader.Controls.Add(this.lblUID);
            this.pnlReader.Controls.Add(this.txtUIDSize);
            this.pnlReader.Controls.Add(this.lblUIDSize);
            this.pnlReader.Controls.Add(this.pgReaderUserData);
            this.pnlReader.Controls.Add(this.stbReader);
            this.pnlReader.Controls.Add(this.btnSoftRestart);
            this.pnlReader.Controls.Add(this.btnReaderReset);
            this.pnlReader.Controls.Add(this.btnReaderUISignal);
            this.pnlReader.Controls.Add(this.lblSoundMode);
            this.pnlReader.Controls.Add(this.cboSoundMode);
            this.pnlReader.Controls.Add(this.lblLightMode);
            this.pnlReader.Controls.Add(this.cboLightMode);
            this.pnlReader.Controls.Add(this.panel1);
            this.pnlReader.Controls.Add(this.txtCardType);
            this.pnlReader.Controls.Add(this.lblCardType);
            this.pnlReader.Controls.Add(this.txtReaderSerial);
            this.pnlReader.Controls.Add(this.lblReaderSerial);
            this.pnlReader.Controls.Add(this.txtReaderType);
            this.pnlReader.Controls.Add(this.lblReaderType);
            this.pnlReader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReader.Location = new System.Drawing.Point(0, 24);
            this.pnlReader.Name = "pnlReader";
            this.pnlReader.Size = new System.Drawing.Size(569, 370);
            this.pnlReader.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.llblNfcSdk);
            this.groupBox1.Controls.Add(this.checkAdvanced);
            this.groupBox1.Controls.Add(this.btnReaderOpen);
            this.groupBox1.Location = new System.Drawing.Point(3, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(567, 110);
            this.groupBox1.TabIndex = 39;
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
            // llblNfcSdk
            // 
            this.llblNfcSdk.AutoSize = true;
            this.llblNfcSdk.Location = new System.Drawing.Point(275, 32);
            this.llblNfcSdk.Name = "llblNfcSdk";
            this.llblNfcSdk.Size = new System.Drawing.Size(254, 13);
            this.llblNfcSdk.TabIndex = 22;
            this.llblNfcSdk.TabStop = true;
            this.llblNfcSdk.Text = "http://www.d-logic.net/nfc-rfid-reader-sdk/";
            this.llblNfcSdk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblNfcSdk_LinkClicked);
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
            this.checkAdvanced.CheckedChanged += new System.EventHandler(this.chkAdvanced_CheckedChanged);
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
            // txtCardSerial
            // 
            this.txtCardSerial.BackColor = System.Drawing.Color.White;
            this.txtCardSerial.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardSerial.Location = new System.Drawing.Point(359, 140);
            this.txtCardSerial.Name = "txtCardSerial";
            this.txtCardSerial.ReadOnly = true;
            this.txtCardSerial.Size = new System.Drawing.Size(152, 21);
            this.txtCardSerial.TabIndex = 21;
            this.txtCardSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.Location = new System.Drawing.Point(286, 143);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(72, 13);
            this.lblUID.TabIndex = 20;
            this.lblUID.Text = "Card Serial";
            // 
            // txtUIDSize
            // 
            this.txtUIDSize.BackColor = System.Drawing.Color.White;
            this.txtUIDSize.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUIDSize.Location = new System.Drawing.Point(473, 113);
            this.txtUIDSize.Name = "txtUIDSize";
            this.txtUIDSize.ReadOnly = true;
            this.txtUIDSize.Size = new System.Drawing.Size(38, 21);
            this.txtUIDSize.TabIndex = 19;
            this.txtUIDSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.txtUIDSize, "Card UID Size");
            // 
            // lblUIDSize
            // 
            this.lblUIDSize.AutoSize = true;
            this.lblUIDSize.Location = new System.Drawing.Point(410, 117);
            this.lblUIDSize.Name = "lblUIDSize";
            this.lblUIDSize.Size = new System.Drawing.Size(57, 13);
            this.lblUIDSize.TabIndex = 18;
            this.lblUIDSize.Text = "UID Size";
            // 
            // pgReaderUserData
            // 
            this.pgReaderUserData.Controls.Add(this.pnlReaderKey);
            this.pgReaderUserData.Controls.Add(this.tabUserData);
            this.pgReaderUserData.Location = new System.Drawing.Point(15, 243);
            this.pgReaderUserData.Name = "pgReaderUserData";
            this.pgReaderUserData.SelectedIndex = 0;
            this.pgReaderUserData.Size = new System.Drawing.Size(509, 96);
            this.pgReaderUserData.TabIndex = 0;
            // 
            // pnlReaderKey
            // 
            this.pnlReaderKey.Controls.Add(this.lblKeyIndex);
            this.pnlReaderKey.Controls.Add(this.btnReaderKeyWrite);
            this.pnlReaderKey.Controls.Add(this.cboKeyIndex);
            this.pnlReaderKey.Controls.Add(this.chkHex);
            this.pnlReaderKey.Location = new System.Drawing.Point(4, 22);
            this.pnlReaderKey.Name = "pnlReaderKey";
            this.pnlReaderKey.Padding = new System.Windows.Forms.Padding(3);
            this.pnlReaderKey.Size = new System.Drawing.Size(501, 70);
            this.pnlReaderKey.TabIndex = 0;
            this.pnlReaderKey.Text = "Reader Key";
            this.pnlReaderKey.UseVisualStyleBackColor = true;
            // 
            // lblKeyIndex
            // 
            this.lblKeyIndex.AutoSize = true;
            this.lblKeyIndex.Location = new System.Drawing.Point(269, 9);
            this.lblKeyIndex.Name = "lblKeyIndex";
            this.lblKeyIndex.Size = new System.Drawing.Size(66, 13);
            this.lblKeyIndex.TabIndex = 34;
            this.lblKeyIndex.Text = "Key Index";
            // 
            // btnReaderKeyWrite
            // 
            this.btnReaderKeyWrite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReaderKeyWrite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReaderKeyWrite.Location = new System.Drawing.Point(354, 9);
            this.btnReaderKeyWrite.Name = "btnReaderKeyWrite";
            this.btnReaderKeyWrite.Size = new System.Drawing.Size(138, 50);
            this.btnReaderKeyWrite.TabIndex = 33;
            this.btnReaderKeyWrite.Text = "Reader Key Write";
            this.btnReaderKeyWrite.UseVisualStyleBackColor = true;
            this.btnReaderKeyWrite.Click += new System.EventHandler(this.btnReaderKeyWrite_Click);
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
            this.cboKeyIndex.Location = new System.Drawing.Point(285, 38);
            this.cboKeyIndex.MaxDropDownItems = 15;
            this.cboKeyIndex.Name = "cboKeyIndex";
            this.cboKeyIndex.Size = new System.Drawing.Size(38, 21);
            this.cboKeyIndex.TabIndex = 32;
            // 
            // chkHex
            // 
            this.chkHex.AutoSize = true;
            this.chkHex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkHex.Location = new System.Drawing.Point(30, 42);
            this.chkHex.Name = "chkHex";
            this.chkHex.Size = new System.Drawing.Size(48, 17);
            this.chkHex.TabIndex = 31;
            this.chkHex.Text = "Hex";
            this.chkHex.UseVisualStyleBackColor = true;
            this.chkHex.CheckedChanged += new System.EventHandler(this.chkHex_CheckedChanged);
            // 
            // tabUserData
            // 
            this.tabUserData.Controls.Add(this.btnWriteUserData);
            this.tabUserData.Controls.Add(this.txtNewUserData);
            this.tabUserData.Controls.Add(this.lblNewUserData);
            this.tabUserData.Controls.Add(this.txtUserData);
            this.tabUserData.Controls.Add(this.lblUserData);
            this.tabUserData.Location = new System.Drawing.Point(4, 22);
            this.tabUserData.Name = "tabUserData";
            this.tabUserData.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserData.Size = new System.Drawing.Size(501, 70);
            this.tabUserData.TabIndex = 1;
            this.tabUserData.Text = "Write User Data";
            this.tabUserData.UseVisualStyleBackColor = true;
            // 
            // btnWriteUserData
            // 
            this.btnWriteUserData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWriteUserData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWriteUserData.Location = new System.Drawing.Point(342, 17);
            this.btnWriteUserData.Name = "btnWriteUserData";
            this.btnWriteUserData.Size = new System.Drawing.Size(153, 34);
            this.btnWriteUserData.TabIndex = 27;
            this.btnWriteUserData.Text = "Write User Data";
            this.btnWriteUserData.UseVisualStyleBackColor = true;
            this.btnWriteUserData.Click += new System.EventHandler(this.btnWriteUserData_Click);
            // 
            // txtNewUserData
            // 
            this.txtNewUserData.BackColor = System.Drawing.Color.White;
            this.txtNewUserData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewUserData.Location = new System.Drawing.Point(177, 30);
            this.txtNewUserData.MaxLength = 16;
            this.txtNewUserData.Name = "txtNewUserData";
            this.txtNewUserData.Size = new System.Drawing.Size(143, 21);
            this.txtNewUserData.TabIndex = 26;
            this.txtNewUserData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNewUserData
            // 
            this.lblNewUserData.AutoSize = true;
            this.lblNewUserData.Location = new System.Drawing.Point(174, 14);
            this.lblNewUserData.Name = "lblNewUserData";
            this.lblNewUserData.Size = new System.Drawing.Size(92, 13);
            this.lblNewUserData.TabIndex = 25;
            this.lblNewUserData.Text = "New User Data";
            // 
            // txtUserData
            // 
            this.txtUserData.BackColor = System.Drawing.Color.LightGray;
            this.txtUserData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserData.Location = new System.Drawing.Point(27, 30);
            this.txtUserData.Name = "txtUserData";
            this.txtUserData.ReadOnly = true;
            this.txtUserData.Size = new System.Drawing.Size(144, 21);
            this.txtUserData.TabIndex = 24;
            this.txtUserData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblUserData
            // 
            this.lblUserData.AutoSize = true;
            this.lblUserData.Location = new System.Drawing.Point(24, 14);
            this.lblUserData.Name = "lblUserData";
            this.lblUserData.Size = new System.Drawing.Size(64, 13);
            this.lblUserData.TabIndex = 23;
            this.lblUserData.Text = "User Data";
            // 
            // stbReader
            // 
            this.stbReader.BackColor = System.Drawing.SystemColors.Control;
            this.stbReader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pnlConn,
            this.pnlErr_code,
            this.pnlErr_expl});
            this.stbReader.Location = new System.Drawing.Point(0, 346);
            this.stbReader.Name = "stbReader";
            this.stbReader.Size = new System.Drawing.Size(567, 22);
            this.stbReader.SizingGrip = false;
            this.stbReader.TabIndex = 17;
            this.stbReader.Text = " ";
            // 
            // pnlConn
            // 
            this.pnlConn.AutoSize = false;
            this.pnlConn.BackColor = System.Drawing.SystemColors.Control;
            this.pnlConn.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.pnlConn.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.pnlConn.Name = "pnlConn";
            this.pnlConn.Size = new System.Drawing.Size(122, 17);
            this.pnlConn.Text = " ";
            // 
            // pnlErr_code
            // 
            this.pnlErr_code.AutoSize = false;
            this.pnlErr_code.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.pnlErr_code.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlErr_code.Name = "pnlErr_code";
            this.pnlErr_code.Size = new System.Drawing.Size(50, 17);
            this.pnlErr_code.Text = " ";
            // 
            // pnlErr_expl
            // 
            this.pnlErr_expl.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.pnlErr_expl.Name = "pnlErr_expl";
            this.pnlErr_expl.Size = new System.Drawing.Size(380, 17);
            this.pnlErr_expl.Spring = true;
            this.pnlErr_expl.Text = " ";
            // 
            // btnSoftRestart
            // 
            this.btnSoftRestart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSoftRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoftRestart.Location = new System.Drawing.Point(368, 214);
            this.btnSoftRestart.Name = "btnSoftRestart";
            this.btnSoftRestart.Size = new System.Drawing.Size(151, 29);
            this.btnSoftRestart.TabIndex = 15;
            this.btnSoftRestart.Text = "Soft Restart";
            this.btnSoftRestart.UseVisualStyleBackColor = true;
            this.btnSoftRestart.Click += new System.EventHandler(this.btnSoftRestart_Click);
            // 
            // btnReaderReset
            // 
            this.btnReaderReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReaderReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReaderReset.Location = new System.Drawing.Point(368, 182);
            this.btnReaderReset.Name = "btnReaderReset";
            this.btnReaderReset.Size = new System.Drawing.Size(151, 31);
            this.btnReaderReset.TabIndex = 14;
            this.btnReaderReset.Text = "Reader Reset";
            this.btnReaderReset.UseVisualStyleBackColor = true;
            this.btnReaderReset.Click += new System.EventHandler(this.btnReaderReset_Click);
            // 
            // btnReaderUISignal
            // 
            this.btnReaderUISignal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReaderUISignal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReaderUISignal.Location = new System.Drawing.Point(234, 185);
            this.btnReaderUISignal.Name = "btnReaderUISignal";
            this.btnReaderUISignal.Size = new System.Drawing.Size(126, 48);
            this.btnReaderUISignal.TabIndex = 13;
            this.btnReaderUISignal.Text = "Reader UI Signal";
            this.btnReaderUISignal.UseVisualStyleBackColor = true;
            this.btnReaderUISignal.Click += new System.EventHandler(this.btnReaderUISignal_Click);
            // 
            // lblSoundMode
            // 
            this.lblSoundMode.AutoSize = true;
            this.lblSoundMode.Location = new System.Drawing.Point(17, 217);
            this.lblSoundMode.Name = "lblSoundMode";
            this.lblSoundMode.Size = new System.Drawing.Size(77, 13);
            this.lblSoundMode.TabIndex = 12;
            this.lblSoundMode.Text = "Sound Mode";
            // 
            // cboSoundMode
            // 
            this.cboSoundMode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboSoundMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboSoundMode.FormattingEnabled = true;
            this.cboSoundMode.Items.AddRange(new object[] {
            "None",
            "Short",
            "Long",
            "Double Short",
            "Tripple Short",
            "Tripplet Melody"});
            this.cboSoundMode.Location = new System.Drawing.Point(102, 214);
            this.cboSoundMode.Name = "cboSoundMode";
            this.cboSoundMode.Size = new System.Drawing.Size(126, 21);
            this.cboSoundMode.TabIndex = 11;
            // 
            // lblLightMode
            // 
            this.lblLightMode.AutoSize = true;
            this.lblLightMode.Location = new System.Drawing.Point(16, 191);
            this.lblLightMode.Name = "lblLightMode";
            this.lblLightMode.Size = new System.Drawing.Size(68, 13);
            this.lblLightMode.TabIndex = 10;
            this.lblLightMode.Text = "Light Mode";
            // 
            // cboLightMode
            // 
            this.cboLightMode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboLightMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboLightMode.FormattingEnabled = true;
            this.cboLightMode.Items.AddRange(new object[] {
            "None",
            "Long Green",
            "LongRed",
            "Alternation",
            "Flash"});
            this.cboLightMode.Location = new System.Drawing.Point(102, 187);
            this.cboLightMode.Name = "cboLightMode";
            this.cboLightMode.Size = new System.Drawing.Size(126, 21);
            this.cboLightMode.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(15, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 4);
            this.panel1.TabIndex = 8;
            // 
            // txtCardType
            // 
            this.txtCardType.BackColor = System.Drawing.Color.White;
            this.txtCardType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardType.Location = new System.Drawing.Point(359, 112);
            this.txtCardType.Name = "txtCardType";
            this.txtCardType.ReadOnly = true;
            this.txtCardType.Size = new System.Drawing.Size(38, 21);
            this.txtCardType.TabIndex = 5;
            this.txtCardType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCardType
            // 
            this.lblCardType.AutoSize = true;
            this.lblCardType.Location = new System.Drawing.Point(286, 116);
            this.lblCardType.Name = "lblCardType";
            this.lblCardType.Size = new System.Drawing.Size(66, 13);
            this.lblCardType.TabIndex = 4;
            this.lblCardType.Text = "Card Type";
            // 
            // txtReaderSerial
            // 
            this.txtReaderSerial.BackColor = System.Drawing.Color.White;
            this.txtReaderSerial.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReaderSerial.Location = new System.Drawing.Point(107, 141);
            this.txtReaderSerial.Name = "txtReaderSerial";
            this.txtReaderSerial.ReadOnly = true;
            this.txtReaderSerial.Size = new System.Drawing.Size(126, 21);
            this.txtReaderSerial.TabIndex = 3;
            this.txtReaderSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblReaderSerial
            // 
            this.lblReaderSerial.AutoSize = true;
            this.lblReaderSerial.Location = new System.Drawing.Point(16, 143);
            this.lblReaderSerial.Name = "lblReaderSerial";
            this.lblReaderSerial.Size = new System.Drawing.Size(85, 13);
            this.lblReaderSerial.TabIndex = 2;
            this.lblReaderSerial.Text = "Reader Serial";
            // 
            // txtReaderType
            // 
            this.txtReaderType.BackColor = System.Drawing.Color.White;
            this.txtReaderType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReaderType.Location = new System.Drawing.Point(107, 113);
            this.txtReaderType.Name = "txtReaderType";
            this.txtReaderType.ReadOnly = true;
            this.txtReaderType.Size = new System.Drawing.Size(126, 21);
            this.txtReaderType.TabIndex = 1;
            this.txtReaderType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblReaderType
            // 
            this.lblReaderType.AutoSize = true;
            this.lblReaderType.Location = new System.Drawing.Point(17, 116);
            this.lblReaderType.Name = "lblReaderType";
            this.lblReaderType.Size = new System.Drawing.Size(79, 13);
            this.lblReaderType.TabIndex = 0;
            this.lblReaderType.Text = "Reader Type";
            // 
            // pnlConteiner
            // 
            this.pnlConteiner.AutoScroll = true;
            this.pnlConteiner.Location = new System.Drawing.Point(1, 396);
            this.pnlConteiner.Name = "pnlConteiner";
            this.pnlConteiner.Size = new System.Drawing.Size(567, 376);
            this.pnlConteiner.TabIndex = 5;
            // 
            // frmuFrAdvance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(569, 801);
            this.Controls.Add(this.pnlConteiner);
            this.Controls.Add(this.pnlReader);
            this.Controls.Add(this.stbCard);
            this.Controls.Add(this.mnuMeni);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MainMenuStrip = this.mnuMeni;
            this.MaximizeBox = false;
            this.Name = "frmuFrAdvance";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "uFr Advanced";
            this.Load += new System.EventHandler(this.frmuFrAdvance_Load);
            this.stbCard.ResumeLayout(false);
            this.stbCard.PerformLayout();
            this.mnuMeni.ResumeLayout(false);
            this.mnuMeni.PerformLayout();
            this.pnlReader.ResumeLayout(false);
            this.pnlReader.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pgReaderUserData.ResumeLayout(false);
            this.pnlReaderKey.ResumeLayout(false);
            this.pnlReaderKey.PerformLayout();
            this.tabUserData.ResumeLayout(false);
            this.tabUserData.PerformLayout();
            this.stbReader.ResumeLayout(false);
            this.stbReader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stbCard;
        private System.Windows.Forms.ToolStripStatusLabel pnlCardStatus;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.MenuStrip mnuMeni;
        private System.Windows.Forms.ToolStripMenuItem mnuFunctionsItem;
        private System.Windows.Forms.ToolStripMenuItem mnuLinearReadWriteItem;
        private System.Windows.Forms.Panel pnlReader;
        private System.Windows.Forms.TextBox txtReaderType;
        private System.Windows.Forms.Label lblReaderType;
        private System.Windows.Forms.TextBox txtReaderSerial;
        private System.Windows.Forms.Label lblReaderSerial;
        private System.Windows.Forms.ToolStripStatusLabel stbErrCode;
        private System.Windows.Forms.ToolStripStatusLabel stbErr_explain;
        private System.Windows.Forms.TextBox txtCardType;
        private System.Windows.Forms.Label lblCardType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboLightMode;
        private System.Windows.Forms.Label lblLightMode;
        private System.Windows.Forms.Button btnReaderUISignal;
        private System.Windows.Forms.Label lblSoundMode;
        private System.Windows.Forms.ComboBox cboSoundMode;
        private System.Windows.Forms.Button btnSoftRestart;
        private System.Windows.Forms.Button btnReaderReset;
        private System.Windows.Forms.StatusStrip stbReader;
        private System.Windows.Forms.ToolStripStatusLabel pnlConn;
        private System.Windows.Forms.ToolStripStatusLabel pnlErr_code;
        private System.Windows.Forms.ToolStripStatusLabel pnlErr_expl;
        private System.Windows.Forms.ToolStripSeparator SEP1;
        private System.Windows.Forms.ToolStripMenuItem mnuExitItem;
        private System.Windows.Forms.ToolStripMenuItem mnuBlockReadWriteItem;
        private System.Windows.Forms.ToolStripSeparator SEP0;
        private System.Windows.Forms.Panel pnlConteiner;
        private System.Windows.Forms.ToolStripMenuItem mnuBlockInSectorReadWriteItem;
        private System.Windows.Forms.ToolStripMenuItem mnuValueBlockReadWriteItem;
        private System.Windows.Forms.ToolStripSeparator SEP2;
        private System.Windows.Forms.ToolStripMenuItem mnuValueBlockIncrDecrItems;
        private System.Windows.Forms.ToolStripMenuItem mnuValueBlockInSectorReadWrite;
        private System.Windows.Forms.ToolStripSeparator SEP3;
        private System.Windows.Forms.ToolStripMenuItem mnuValueBlockInSectorIncrDecrItem;
        private System.Windows.Forms.ToolStripSeparator SEP4;
        private System.Windows.Forms.ToolStripMenuItem mnuSectorTrailerWriteItems;
        private System.Windows.Forms.ToolStripMenuItem mnuLinearFormatCardItem;
        private System.Windows.Forms.ToolStripMenuItem mnuViewAllItem;
        private System.Windows.Forms.TabControl pgReaderUserData;
        private System.Windows.Forms.TabPage pnlReaderKey;
        private System.Windows.Forms.Label lblKeyIndex;
        private System.Windows.Forms.Button btnReaderKeyWrite;
        private System.Windows.Forms.ComboBox cboKeyIndex;
        private System.Windows.Forms.CheckBox chkHex;
        private System.Windows.Forms.TabPage tabUserData;
        private System.Windows.Forms.Button btnWriteUserData;
        private System.Windows.Forms.TextBox txtNewUserData;
        private System.Windows.Forms.Label lblNewUserData;
        private System.Windows.Forms.TextBox txtUserData;
        private System.Windows.Forms.Label lblUserData;
        private System.Windows.Forms.TextBox txtUIDSize;
        private System.Windows.Forms.Label lblUIDSize;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TextBox txtCardSerial;
        private System.Windows.Forms.Label lblUID;
        private System.Windows.Forms.ToolStripMenuItem mnuHardwareFirmwareVersionItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.LinkLabel llblNfcSdk;
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


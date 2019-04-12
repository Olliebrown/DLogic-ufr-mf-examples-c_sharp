namespace uFRSimplest
{
    partial class frmuFRSimplest
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
            this.stbConnected = new System.Windows.Forms.StatusStrip();
            this.pnlConnected = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlError_code = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlError_expl = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuuFRCoderSimplestItem = new System.Windows.Forms.MenuStrip();
            this.mnuExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFormatCard = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.stbFunctionError = new System.Windows.Forms.StatusStrip();
            this.pnlFunct_error = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlErr_codes = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlErr_explain = new System.Windows.Forms.ToolStripStatusLabel();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.btnLinearWrite = new System.Windows.Forms.Button();
            this.lblWriteData = new System.Windows.Forms.Label();
            this.txtWriteData = new System.Windows.Forms.TextBox();
            this.stbCardStatus = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtCardType = new System.Windows.Forms.TextBox();
            this.lblCardType = new System.Windows.Forms.Label();
            this.lblUIDSize = new System.Windows.Forms.Label();
            this.txtUIDSize = new System.Windows.Forms.TextBox();
            this.btnLinearRead = new System.Windows.Forms.Button();
            this.lblReadData = new System.Windows.Forms.Label();
            this.txtReadData = new System.Windows.Forms.TextBox();
            this.txtCardUID = new System.Windows.Forms.TextBox();
            this.lblCardUID = new System.Windows.Forms.Label();
            this.linkLabel_nfc = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOpenArg = new System.Windows.Forms.TextBox();
            this.txtPortInterface = new System.Windows.Forms.TextBox();
            this.txtPortName = new System.Windows.Forms.TextBox();
            this.txtReaderType = new System.Windows.Forms.TextBox();
            this.labelOpenArg = new System.Windows.Forms.Label();
            this.labelPortInterface = new System.Windows.Forms.Label();
            this.labelPortName = new System.Windows.Forms.Label();
            this.labelReaderType = new System.Windows.Forms.Label();
            this.checkAdvanced = new System.Windows.Forms.CheckBox();
            this.btnReaderOpen = new System.Windows.Forms.Button();
            this.stbConnected.SuspendLayout();
            this.mnuuFRCoderSimplestItem.SuspendLayout();
            this.stbFunctionError.SuspendLayout();
            this.stbCardStatus.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // stbConnected
            // 
            this.stbConnected.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.stbConnected.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pnlConnected,
            this.pnlError_code,
            this.pnlError_expl});
            this.stbConnected.Location = new System.Drawing.Point(0, 582);
            this.stbConnected.Name = "stbConnected";
            this.stbConnected.Size = new System.Drawing.Size(531, 22);
            this.stbConnected.SizingGrip = false;
            this.stbConnected.TabIndex = 0;
            this.stbConnected.Text = "statusStrip1";
            // 
            // pnlConnected
            // 
            this.pnlConnected.AutoSize = false;
            this.pnlConnected.BackColor = System.Drawing.Color.Silver;
            this.pnlConnected.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.pnlConnected.Name = "pnlConnected";
            this.pnlConnected.Size = new System.Drawing.Size(120, 17);
            // 
            // pnlError_code
            // 
            this.pnlError_code.AutoSize = false;
            this.pnlError_code.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.pnlError_code.Name = "pnlError_code";
            this.pnlError_code.Size = new System.Drawing.Size(50, 17);
            this.pnlError_code.Text = " ";
            // 
            // pnlError_expl
            // 
            this.pnlError_expl.Name = "pnlError_expl";
            this.pnlError_expl.Size = new System.Drawing.Size(346, 17);
            this.pnlError_expl.Spring = true;
            this.pnlError_expl.Text = " ";
            // 
            // mnuuFRCoderSimplestItem
            // 
            this.mnuuFRCoderSimplestItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExitItem});
            this.mnuuFRCoderSimplestItem.Location = new System.Drawing.Point(0, 0);
            this.mnuuFRCoderSimplestItem.Name = "mnuuFRCoderSimplestItem";
            this.mnuuFRCoderSimplestItem.Size = new System.Drawing.Size(531, 24);
            this.mnuuFRCoderSimplestItem.TabIndex = 1;
            this.mnuuFRCoderSimplestItem.Text = "menuStrip1";
            // 
            // mnuExitItem
            // 
            this.mnuExitItem.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.mnuExitItem.Name = "mnuExitItem";
            this.mnuExitItem.Size = new System.Drawing.Size(40, 20);
            this.mnuExitItem.Text = "Exit";
            this.mnuExitItem.Click += new System.EventHandler(this.mnuExitItem_Click);
            // 
            // btnFormatCard
            // 
            this.btnFormatCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFormatCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormatCard.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormatCard.Location = new System.Drawing.Point(277, 205);
            this.btnFormatCard.Name = "btnFormatCard";
            this.btnFormatCard.Size = new System.Drawing.Size(223, 46);
            this.btnFormatCard.TabIndex = 8;
            this.btnFormatCard.Text = "FORMAT CARD";
            this.btnFormatCard.UseVisualStyleBackColor = true;
            this.btnFormatCard.Click += new System.EventHandler(this.btnFormatCard_Click);
            // 
            // Timer
            // 
            this.Timer.Interval = 200;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // stbFunctionError
            // 
            this.stbFunctionError.AutoSize = false;
            this.stbFunctionError.Dock = System.Windows.Forms.DockStyle.None;
            this.stbFunctionError.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.stbFunctionError.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pnlFunct_error,
            this.pnlErr_codes,
            this.pnlErr_explain});
            this.stbFunctionError.Location = new System.Drawing.Point(0, 536);
            this.stbFunctionError.Name = "stbFunctionError";
            this.stbFunctionError.Size = new System.Drawing.Size(531, 22);
            this.stbFunctionError.SizingGrip = false;
            this.stbFunctionError.TabIndex = 13;
            this.stbFunctionError.Text = "statusStrip1";
            // 
            // pnlFunct_error
            // 
            this.pnlFunct_error.AutoSize = false;
            this.pnlFunct_error.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.pnlFunct_error.Name = "pnlFunct_error";
            this.pnlFunct_error.Size = new System.Drawing.Size(120, 17);
            this.pnlFunct_error.Text = "Function Error";
            // 
            // pnlErr_codes
            // 
            this.pnlErr_codes.AutoSize = false;
            this.pnlErr_codes.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.pnlErr_codes.Name = "pnlErr_codes";
            this.pnlErr_codes.Size = new System.Drawing.Size(50, 17);
            this.pnlErr_codes.Text = " ";
            // 
            // pnlErr_explain
            // 
            this.pnlErr_explain.Name = "pnlErr_explain";
            this.pnlErr_explain.Size = new System.Drawing.Size(346, 17);
            this.pnlErr_explain.Spring = true;
            this.pnlErr_explain.Text = " ";
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(0, 517);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(545, 14);
            this.pBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pBar.TabIndex = 14;
            this.pBar.UseWaitCursor = true;
            this.pBar.Visible = false;
            // 
            // btnLinearWrite
            // 
            this.btnLinearWrite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLinearWrite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLinearWrite.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLinearWrite.Location = new System.Drawing.Point(31, 472);
            this.btnLinearWrite.Name = "btnLinearWrite";
            this.btnLinearWrite.Size = new System.Drawing.Size(223, 40);
            this.btnLinearWrite.TabIndex = 7;
            this.btnLinearWrite.Text = "LINEAR WRITE";
            this.btnLinearWrite.UseVisualStyleBackColor = true;
            this.btnLinearWrite.Click += new System.EventHandler(this.btnLinearWrite_Click);
            // 
            // lblWriteData
            // 
            this.lblWriteData.AutoSize = true;
            this.lblWriteData.Location = new System.Drawing.Point(28, 261);
            this.lblWriteData.Name = "lblWriteData";
            this.lblWriteData.Size = new System.Drawing.Size(68, 13);
            this.lblWriteData.TabIndex = 16;
            this.lblWriteData.Text = "Write Data";
            // 
            // txtWriteData
            // 
            this.txtWriteData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWriteData.Location = new System.Drawing.Point(31, 281);
            this.txtWriteData.Multiline = true;
            this.txtWriteData.Name = "txtWriteData";
            this.txtWriteData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWriteData.Size = new System.Drawing.Size(241, 185);
            this.txtWriteData.TabIndex = 15;
            // 
            // stbCardStatus
            // 
            this.stbCardStatus.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.stbCardStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.stbCardStatus.Location = new System.Drawing.Point(0, 560);
            this.stbCardStatus.Name = "stbCardStatus";
            this.stbCardStatus.Size = new System.Drawing.Size(531, 22);
            this.stbCardStatus.SizingGrip = false;
            this.stbCardStatus.TabIndex = 18;
            this.stbCardStatus.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(120, 17);
            this.toolStripStatusLabel1.Text = "CARD STATUS";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatusLabel2.Text = " ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(346, 17);
            this.toolStripStatusLabel3.Spring = true;
            this.toolStripStatusLabel3.Text = " ";
            // 
            // txtCardType
            // 
            this.txtCardType.BackColor = System.Drawing.Color.White;
            this.txtCardType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardType.Location = new System.Drawing.Point(101, 208);
            this.txtCardType.Name = "txtCardType";
            this.txtCardType.ReadOnly = true;
            this.txtCardType.Size = new System.Drawing.Size(41, 21);
            this.txtCardType.TabIndex = 20;
            this.txtCardType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCardType
            // 
            this.lblCardType.AutoSize = true;
            this.lblCardType.Location = new System.Drawing.Point(28, 210);
            this.lblCardType.Name = "lblCardType";
            this.lblCardType.Size = new System.Drawing.Size(66, 13);
            this.lblCardType.TabIndex = 19;
            this.lblCardType.Text = "Card Type";
            // 
            // lblUIDSize
            // 
            this.lblUIDSize.AutoSize = true;
            this.lblUIDSize.Location = new System.Drawing.Point(148, 210);
            this.lblUIDSize.Name = "lblUIDSize";
            this.lblUIDSize.Size = new System.Drawing.Size(57, 13);
            this.lblUIDSize.TabIndex = 24;
            this.lblUIDSize.Text = "UID Size";
            // 
            // txtUIDSize
            // 
            this.txtUIDSize.BackColor = System.Drawing.Color.White;
            this.txtUIDSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUIDSize.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUIDSize.Location = new System.Drawing.Point(212, 208);
            this.txtUIDSize.Name = "txtUIDSize";
            this.txtUIDSize.ReadOnly = true;
            this.txtUIDSize.Size = new System.Drawing.Size(41, 21);
            this.txtUIDSize.TabIndex = 27;
            this.txtUIDSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnLinearRead
            // 
            this.btnLinearRead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLinearRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLinearRead.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLinearRead.Location = new System.Drawing.Point(277, 472);
            this.btnLinearRead.Name = "btnLinearRead";
            this.btnLinearRead.Size = new System.Drawing.Size(223, 40);
            this.btnLinearRead.TabIndex = 6;
            this.btnLinearRead.Text = "LINEAR READ";
            this.btnLinearRead.UseVisualStyleBackColor = true;
            this.btnLinearRead.Click += new System.EventHandler(this.btnLinearRead_Click);
            // 
            // lblReadData
            // 
            this.lblReadData.AutoSize = true;
            this.lblReadData.Location = new System.Drawing.Point(274, 261);
            this.lblReadData.Name = "lblReadData";
            this.lblReadData.Size = new System.Drawing.Size(67, 13);
            this.lblReadData.TabIndex = 29;
            this.lblReadData.Text = "Read Data";
            // 
            // txtReadData
            // 
            this.txtReadData.BackColor = System.Drawing.Color.LightGray;
            this.txtReadData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReadData.Location = new System.Drawing.Point(277, 281);
            this.txtReadData.Multiline = true;
            this.txtReadData.Name = "txtReadData";
            this.txtReadData.ReadOnly = true;
            this.txtReadData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReadData.Size = new System.Drawing.Size(241, 185);
            this.txtReadData.TabIndex = 28;
            // 
            // txtCardUID
            // 
            this.txtCardUID.BackColor = System.Drawing.Color.White;
            this.txtCardUID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardUID.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardUID.Location = new System.Drawing.Point(101, 233);
            this.txtCardUID.Name = "txtCardUID";
            this.txtCardUID.ReadOnly = true;
            this.txtCardUID.Size = new System.Drawing.Size(152, 21);
            this.txtCardUID.TabIndex = 32;
            this.txtCardUID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCardUID
            // 
            this.lblCardUID.AutoSize = true;
            this.lblCardUID.Location = new System.Drawing.Point(29, 238);
            this.lblCardUID.Name = "lblCardUID";
            this.lblCardUID.Size = new System.Drawing.Size(61, 13);
            this.lblCardUID.TabIndex = 31;
            this.lblCardUID.Text = "Card UID";
            // 
            // linkLabel_nfc
            // 
            this.linkLabel_nfc.AutoSize = true;
            this.linkLabel_nfc.Location = new System.Drawing.Point(30, 35);
            this.linkLabel_nfc.Name = "linkLabel_nfc";
            this.linkLabel_nfc.Size = new System.Drawing.Size(254, 13);
            this.linkLabel_nfc.TabIndex = 33;
            this.linkLabel_nfc.TabStop = true;
            this.linkLabel_nfc.Text = "http://www.d-logic.net/nfc-rfid-reader-sdk/";
            this.linkLabel_nfc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_nfc_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.checkAdvanced);
            this.groupBox1.Controls.Add(this.btnReaderOpen);
            this.groupBox1.Location = new System.Drawing.Point(31, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 148);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reader Open";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtOpenArg);
            this.groupBox2.Controls.Add(this.txtPortInterface);
            this.groupBox2.Controls.Add(this.txtPortName);
            this.groupBox2.Controls.Add(this.txtReaderType);
            this.groupBox2.Controls.Add(this.labelOpenArg);
            this.groupBox2.Controls.Add(this.labelPortInterface);
            this.groupBox2.Controls.Add(this.labelPortName);
            this.groupBox2.Controls.Add(this.labelReaderType);
            this.groupBox2.Location = new System.Drawing.Point(214, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 132);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Advanced options";
            // 
            // txtOpenArg
            // 
            this.txtOpenArg.Enabled = false;
            this.txtOpenArg.Location = new System.Drawing.Point(93, 101);
            this.txtOpenArg.Name = "txtOpenArg";
            this.txtOpenArg.Size = new System.Drawing.Size(151, 21);
            this.txtOpenArg.TabIndex = 7;
            // 
            // txtPortInterface
            // 
            this.txtPortInterface.Enabled = false;
            this.txtPortInterface.Location = new System.Drawing.Point(93, 73);
            this.txtPortInterface.Name = "txtPortInterface";
            this.txtPortInterface.Size = new System.Drawing.Size(43, 21);
            this.txtPortInterface.TabIndex = 6;
            // 
            // txtPortName
            // 
            this.txtPortName.Enabled = false;
            this.txtPortName.Location = new System.Drawing.Point(93, 45);
            this.txtPortName.Name = "txtPortName";
            this.txtPortName.Size = new System.Drawing.Size(151, 21);
            this.txtPortName.TabIndex = 5;
            // 
            // txtReaderType
            // 
            this.txtReaderType.Enabled = false;
            this.txtReaderType.Location = new System.Drawing.Point(93, 15);
            this.txtReaderType.Name = "txtReaderType";
            this.txtReaderType.Size = new System.Drawing.Size(43, 21);
            this.txtReaderType.TabIndex = 4;
            // 
            // labelOpenArg
            // 
            this.labelOpenArg.AutoSize = true;
            this.labelOpenArg.Enabled = false;
            this.labelOpenArg.Location = new System.Drawing.Point(6, 104);
            this.labelOpenArg.Name = "labelOpenArg";
            this.labelOpenArg.Size = new System.Drawing.Size(32, 13);
            this.labelOpenArg.TabIndex = 3;
            this.labelOpenArg.Text = "Arg:";
            // 
            // labelPortInterface
            // 
            this.labelPortInterface.AutoSize = true;
            this.labelPortInterface.Enabled = false;
            this.labelPortInterface.Location = new System.Drawing.Point(6, 76);
            this.labelPortInterface.Name = "labelPortInterface";
            this.labelPortInterface.Size = new System.Drawing.Size(89, 13);
            this.labelPortInterface.TabIndex = 2;
            this.labelPortInterface.Text = "Port interface:";
            // 
            // labelPortName
            // 
            this.labelPortName.AutoSize = true;
            this.labelPortName.Enabled = false;
            this.labelPortName.Location = new System.Drawing.Point(6, 48);
            this.labelPortName.Name = "labelPortName";
            this.labelPortName.Size = new System.Drawing.Size(71, 13);
            this.labelPortName.TabIndex = 1;
            this.labelPortName.Text = "Port name:";
            // 
            // labelReaderType
            // 
            this.labelReaderType.AutoSize = true;
            this.labelReaderType.Enabled = false;
            this.labelReaderType.Location = new System.Drawing.Point(6, 18);
            this.labelReaderType.Name = "labelReaderType";
            this.labelReaderType.Size = new System.Drawing.Size(82, 13);
            this.labelReaderType.TabIndex = 0;
            this.labelReaderType.Text = "Reader type:";
            // 
            // checkAdvanced
            // 
            this.checkAdvanced.AutoSize = true;
            this.checkAdvanced.Location = new System.Drawing.Point(6, 85);
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
            this.btnReaderOpen.Size = new System.Drawing.Size(105, 55);
            this.btnReaderOpen.TabIndex = 0;
            this.btnReaderOpen.Text = "Reader Open";
            this.btnReaderOpen.UseVisualStyleBackColor = true;
            this.btnReaderOpen.Click += new System.EventHandler(this.btnReaderOpen_Click);
            // 
            // frmuFRSimplest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 604);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.linkLabel_nfc);
            this.Controls.Add(this.txtCardUID);
            this.Controls.Add(this.lblCardUID);
            this.Controls.Add(this.btnLinearRead);
            this.Controls.Add(this.lblReadData);
            this.Controls.Add(this.txtReadData);
            this.Controls.Add(this.txtUIDSize);
            this.Controls.Add(this.lblUIDSize);
            this.Controls.Add(this.txtCardType);
            this.Controls.Add(this.lblCardType);
            this.Controls.Add(this.pBar);
            this.Controls.Add(this.stbCardStatus);
            this.Controls.Add(this.btnLinearWrite);
            this.Controls.Add(this.lblWriteData);
            this.Controls.Add(this.txtWriteData);
            this.Controls.Add(this.stbFunctionError);
            this.Controls.Add(this.btnFormatCard);
            this.Controls.Add(this.stbConnected);
            this.Controls.Add(this.mnuuFRCoderSimplestItem);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.mnuuFRCoderSimplestItem;
            this.MaximizeBox = false;
            this.Name = "frmuFRSimplest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "uFr Simplest";
            this.Load += new System.EventHandler(this.frmuFRSimplest_Load);
            this.stbConnected.ResumeLayout(false);
            this.stbConnected.PerformLayout();
            this.mnuuFRCoderSimplestItem.ResumeLayout(false);
            this.mnuuFRCoderSimplestItem.PerformLayout();
            this.stbFunctionError.ResumeLayout(false);
            this.stbFunctionError.PerformLayout();
            this.stbCardStatus.ResumeLayout(false);
            this.stbCardStatus.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stbConnected;
        private System.Windows.Forms.MenuStrip mnuuFRCoderSimplestItem;
        private System.Windows.Forms.ToolStripMenuItem mnuExitItem;
        private System.Windows.Forms.Button btnFormatCard;
        private System.Windows.Forms.ToolStripStatusLabel pnlConnected;
        private System.Windows.Forms.ToolStripStatusLabel pnlError_code;
        private System.Windows.Forms.ToolStripStatusLabel pnlError_expl;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.StatusStrip stbFunctionError;
        private System.Windows.Forms.ToolStripStatusLabel pnlFunct_error;
        private System.Windows.Forms.ToolStripStatusLabel pnlErr_codes;
        private System.Windows.Forms.ToolStripStatusLabel pnlErr_explain;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Button btnLinearWrite;
        private System.Windows.Forms.Label lblWriteData;
        private System.Windows.Forms.TextBox txtWriteData;
        private System.Windows.Forms.StatusStrip stbCardStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.TextBox txtCardType;
        private System.Windows.Forms.Label lblCardType;
        private System.Windows.Forms.Label lblUIDSize;
        private System.Windows.Forms.TextBox txtUIDSize;
        private System.Windows.Forms.Button btnLinearRead;
        private System.Windows.Forms.Label lblReadData;
        private System.Windows.Forms.TextBox txtReadData;
        private System.Windows.Forms.TextBox txtCardUID;
        private System.Windows.Forms.Label lblCardUID;
        private System.Windows.Forms.LinkLabel linkLabel_nfc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtOpenArg;
        private System.Windows.Forms.TextBox txtPortInterface;
        private System.Windows.Forms.TextBox txtPortName;
        private System.Windows.Forms.TextBox txtReaderType;
        private System.Windows.Forms.Label labelOpenArg;
        private System.Windows.Forms.Label labelPortInterface;
        private System.Windows.Forms.Label labelPortName;
        private System.Windows.Forms.Label labelReaderType;
        private System.Windows.Forms.CheckBox checkAdvanced;
        private System.Windows.Forms.Button btnReaderOpen;
    }
}


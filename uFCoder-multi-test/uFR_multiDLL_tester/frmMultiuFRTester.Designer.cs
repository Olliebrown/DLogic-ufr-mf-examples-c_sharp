namespace uFR_multiDLL_tester
{
    partial class frmMultiuFRTester
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
            this.gbAction = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bCloseByIdx = new System.Windows.Forms.Button();
            this.bOpenByIdx = new System.Windows.Forms.Button();
            this.bGetInfo = new System.Windows.Forms.Button();
            this.bGetCount = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.eFileNameDetectedCard = new System.Windows.Forms.TextBox();
            this.cbPollReaders = new System.Windows.Forms.CheckBox();
            this.bCloseAll = new System.Windows.Forms.Button();
            this.bOpenAll = new System.Windows.Forms.Button();
            this.gbRdWr = new System.Windows.Forms.GroupBox();
            this.btReadData = new System.Windows.Forms.Button();
            this.btWriteData = new System.Windows.Forms.Button();
            this.eData = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.eBlockSec = new System.Windows.Forms.ComboBox();
            this.eSector = new System.Windows.Forms.ComboBox();
            this.eBlock = new System.Windows.Forms.TextBox();
            this.eReader = new System.Windows.Forms.TextBox();
            this.memoDebug = new System.Windows.Forms.RichTextBox();
            this.memoDetected = new System.Windows.Forms.RichTextBox();
            this.gridReader = new System.Windows.Forms.DataGridView();
            this.timerPoll = new System.Windows.Forms.Timer(this.components);
            this.gbAction.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbRdWr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReader)).BeginInit();
            this.SuspendLayout();
            // 
            // gbAction
            // 
            this.gbAction.Controls.Add(this.groupBox2);
            this.gbAction.Controls.Add(this.groupBox3);
            this.gbAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbAction.Location = new System.Drawing.Point(0, 0);
            this.gbAction.Name = "gbAction";
            this.gbAction.Size = new System.Drawing.Size(630, 113);
            this.gbAction.TabIndex = 0;
            this.gbAction.TabStop = false;
            this.gbAction.Text = "Action";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bCloseByIdx);
            this.groupBox2.Controls.Add(this.bOpenByIdx);
            this.groupBox2.Controls.Add(this.bGetInfo);
            this.groupBox2.Controls.Add(this.bGetCount);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(624, 46);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Single Action";
            // 
            // bCloseByIdx
            // 
            this.bCloseByIdx.Location = new System.Drawing.Point(320, 19);
            this.bCloseByIdx.Name = "bCloseByIdx";
            this.bCloseByIdx.Size = new System.Drawing.Size(130, 23);
            this.bCloseByIdx.TabIndex = 3;
            this.bCloseByIdx.Text = "end) Close by Index";
            this.bCloseByIdx.UseVisualStyleBackColor = true;
            this.bCloseByIdx.Click += new System.EventHandler(this.bCloseByIdx_Click);
            // 
            // bOpenByIdx
            // 
            this.bOpenByIdx.Location = new System.Drawing.Point(184, 19);
            this.bOpenByIdx.Name = "bOpenByIdx";
            this.bOpenByIdx.Size = new System.Drawing.Size(130, 23);
            this.bOpenByIdx.TabIndex = 2;
            this.bOpenByIdx.Text = "3) Open by Index";
            this.bOpenByIdx.UseVisualStyleBackColor = true;
            this.bOpenByIdx.Click += new System.EventHandler(this.bOpenByIdx_Click);
            // 
            // bGetInfo
            // 
            this.bGetInfo.Location = new System.Drawing.Point(87, 19);
            this.bGetInfo.Name = "bGetInfo";
            this.bGetInfo.Size = new System.Drawing.Size(75, 23);
            this.bGetInfo.TabIndex = 1;
            this.bGetInfo.Text = "2) Get Info";
            this.bGetInfo.UseVisualStyleBackColor = true;
            this.bGetInfo.Click += new System.EventHandler(this.bGetInfo_Click);
            // 
            // bGetCount
            // 
            this.bGetCount.Location = new System.Drawing.Point(6, 19);
            this.bGetCount.Name = "bGetCount";
            this.bGetCount.Size = new System.Drawing.Size(75, 23);
            this.bGetCount.TabIndex = 0;
            this.bGetCount.Text = "1) Get Count";
            this.bGetCount.UseVisualStyleBackColor = true;
            this.bGetCount.Click += new System.EventHandler(this.bGetCount_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.eFileNameDetectedCard);
            this.groupBox3.Controls.Add(this.cbPollReaders);
            this.groupBox3.Controls.Add(this.bCloseAll);
            this.groupBox3.Controls.Add(this.bOpenAll);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(624, 46);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Multi Action";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(376, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "File name:";
            // 
            // eFileNameDetectedCard
            // 
            this.eFileNameDetectedCard.Location = new System.Drawing.Point(437, 16);
            this.eFileNameDetectedCard.Name = "eFileNameDetectedCard";
            this.eFileNameDetectedCard.Size = new System.Drawing.Size(184, 20);
            this.eFileNameDetectedCard.TabIndex = 13;
            this.eFileNameDetectedCard.Text = "detected_card_date___.txt";
            // 
            // cbPollReaders
            // 
            this.cbPollReaders.AutoSize = true;
            this.cbPollReaders.Checked = true;
            this.cbPollReaders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPollReaders.Location = new System.Drawing.Point(234, 23);
            this.cbPollReaders.Name = "cbPollReaders";
            this.cbPollReaders.Size = new System.Drawing.Size(136, 17);
            this.cbPollReaders.TabIndex = 3;
            this.cbPollReaders.Text = "Enable Polling Readers";
            this.cbPollReaders.UseVisualStyleBackColor = true;
            this.cbPollReaders.CheckedChanged += new System.EventHandler(this.cbPollReaders_CheckedChanged);
            // 
            // bCloseAll
            // 
            this.bCloseAll.Enabled = false;
            this.bCloseAll.Location = new System.Drawing.Point(116, 19);
            this.bCloseAll.Name = "bCloseAll";
            this.bCloseAll.Size = new System.Drawing.Size(104, 23);
            this.bCloseAll.TabIndex = 1;
            this.bCloseAll.Text = "Close All Readers";
            this.bCloseAll.UseVisualStyleBackColor = true;
            this.bCloseAll.Click += new System.EventHandler(this.bCloseAll_Click);
            // 
            // bOpenAll
            // 
            this.bOpenAll.Location = new System.Drawing.Point(6, 19);
            this.bOpenAll.Name = "bOpenAll";
            this.bOpenAll.Size = new System.Drawing.Size(104, 23);
            this.bOpenAll.TabIndex = 0;
            this.bOpenAll.Text = "Open All Readers";
            this.bOpenAll.UseVisualStyleBackColor = true;
            this.bOpenAll.Click += new System.EventHandler(this.bOpenAll_Click);
            // 
            // gbRdWr
            // 
            this.gbRdWr.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbRdWr.Controls.Add(this.btReadData);
            this.gbRdWr.Controls.Add(this.btWriteData);
            this.gbRdWr.Controls.Add(this.eData);
            this.gbRdWr.Controls.Add(this.label5);
            this.gbRdWr.Controls.Add(this.label4);
            this.gbRdWr.Controls.Add(this.label3);
            this.gbRdWr.Controls.Add(this.label2);
            this.gbRdWr.Controls.Add(this.label1);
            this.gbRdWr.Controls.Add(this.eBlockSec);
            this.gbRdWr.Controls.Add(this.eSector);
            this.gbRdWr.Controls.Add(this.eBlock);
            this.gbRdWr.Controls.Add(this.eReader);
            this.gbRdWr.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbRdWr.Location = new System.Drawing.Point(0, 113);
            this.gbRdWr.Name = "gbRdWr";
            this.gbRdWr.Size = new System.Drawing.Size(630, 59);
            this.gbRdWr.TabIndex = 3;
            this.gbRdWr.TabStop = false;
            this.gbRdWr.Text = "Single Read/Write  ( first select Reader from Table above )";
            // 
            // btReadData
            // 
            this.btReadData.Location = new System.Drawing.Point(549, 28);
            this.btReadData.Name = "btReadData";
            this.btReadData.Size = new System.Drawing.Size(75, 23);
            this.btReadData.TabIndex = 23;
            this.btReadData.Text = "Read Data";
            this.btReadData.UseVisualStyleBackColor = true;
            this.btReadData.Click += new System.EventHandler(this.btReadData_Click);
            // 
            // btWriteData
            // 
            this.btWriteData.Location = new System.Drawing.Point(440, 28);
            this.btWriteData.Name = "btWriteData";
            this.btWriteData.Size = new System.Drawing.Size(75, 23);
            this.btWriteData.TabIndex = 22;
            this.btWriteData.Text = "Write Data";
            this.btWriteData.UseVisualStyleBackColor = true;
            this.btWriteData.Click += new System.EventHandler(this.btWriteData_Click);
            // 
            // eData
            // 
            this.eData.Location = new System.Drawing.Point(287, 31);
            this.eData.MaxLength = 16;
            this.eData.Name = "eData";
            this.eData.Size = new System.Drawing.Size(100, 20);
            this.eData.TabIndex = 21;
            this.eData.Text = "max 16 chars";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(284, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Block data content";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Block";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Block in Sec";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Sector";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Reader List";
            // 
            // eBlockSec
            // 
            this.eBlockSec.FormattingEnabled = true;
            this.eBlockSec.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.eBlockSec.Location = new System.Drawing.Point(131, 31);
            this.eBlockSec.Name = "eBlockSec";
            this.eBlockSec.Size = new System.Drawing.Size(35, 21);
            this.eBlockSec.TabIndex = 15;
            this.eBlockSec.SelectedIndexChanged += new System.EventHandler(this.eBlockSec_SelectedIndexChanged);
            // 
            // eSector
            // 
            this.eSector.FormattingEnabled = true;
            this.eSector.Items.AddRange(new object[] {
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
            "15"});
            this.eSector.Location = new System.Drawing.Point(90, 31);
            this.eSector.Name = "eSector";
            this.eSector.Size = new System.Drawing.Size(35, 21);
            this.eSector.TabIndex = 14;
            this.eSector.SelectedIndexChanged += new System.EventHandler(this.eSector_SelectedIndexChanged);
            // 
            // eBlock
            // 
            this.eBlock.Enabled = false;
            this.eBlock.Location = new System.Drawing.Point(201, 31);
            this.eBlock.Name = "eBlock";
            this.eBlock.Size = new System.Drawing.Size(58, 20);
            this.eBlock.TabIndex = 13;
            this.eBlock.Text = "0";
            // 
            // eReader
            // 
            this.eReader.Location = new System.Drawing.Point(9, 32);
            this.eReader.Name = "eReader";
            this.eReader.Size = new System.Drawing.Size(61, 20);
            this.eReader.TabIndex = 12;
            this.eReader.Text = "0";
            // 
            // memoDebug
            // 
            this.memoDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoDebug.HideSelection = false;
            this.memoDebug.Location = new System.Drawing.Point(0, 482);
            this.memoDebug.Name = "memoDebug";
            this.memoDebug.Size = new System.Drawing.Size(630, 179);
            this.memoDebug.TabIndex = 7;
            this.memoDebug.Text = "debug information";
            // 
            // memoDetected
            // 
            this.memoDetected.Dock = System.Windows.Forms.DockStyle.Top;
            this.memoDetected.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.memoDetected.HideSelection = false;
            this.memoDetected.Location = new System.Drawing.Point(0, 322);
            this.memoDetected.Name = "memoDetected";
            this.memoDetected.Size = new System.Drawing.Size(630, 160);
            this.memoDetected.TabIndex = 6;
            this.memoDetected.Text = "date       time     | reader     | UID (size)               |  CardType\n---------" +
    "-----------+------------+--------------------------+-------------";
            // 
            // gridReader
            // 
            this.gridReader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReader.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridReader.Location = new System.Drawing.Point(0, 172);
            this.gridReader.Name = "gridReader";
            this.gridReader.ReadOnly = true;
            this.gridReader.Size = new System.Drawing.Size(630, 150);
            this.gridReader.TabIndex = 12;
            this.gridReader.SelectionChanged += new System.EventHandler(this.gridReader_SelectionChanged);
            // 
            // timerPoll
            // 
            this.timerPoll.Enabled = true;
            this.timerPoll.Tick += new System.EventHandler(this.timerPoll_Tick);
            // 
            // frmMultiuFRTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 661);
            this.Controls.Add(this.memoDebug);
            this.Controls.Add(this.memoDetected);
            this.Controls.Add(this.gridReader);
            this.Controls.Add(this.gbRdWr);
            this.Controls.Add(this.gbAction);
            this.Name = "frmMultiuFRTester";
            this.Text = "Tester uFCoder DLL - multi readers v2.1";
            this.Load += new System.EventHandler(this.frmMultiuFRTester_Load);
            this.gbAction.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbRdWr.ResumeLayout(false);
            this.gbRdWr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAction;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbPollReaders;
        private System.Windows.Forms.Button bCloseAll;
        private System.Windows.Forms.Button bOpenAll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bCloseByIdx;
        private System.Windows.Forms.Button bOpenByIdx;
        private System.Windows.Forms.Button bGetInfo;
        private System.Windows.Forms.Button bGetCount;
        private System.Windows.Forms.TextBox eFileNameDetectedCard;
        private System.Windows.Forms.GroupBox gbRdWr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox eBlockSec;
        private System.Windows.Forms.ComboBox eSector;
        private System.Windows.Forms.TextBox eBlock;
        private System.Windows.Forms.TextBox eReader;
        private System.Windows.Forms.Button btReadData;
        private System.Windows.Forms.Button btWriteData;
        private System.Windows.Forms.TextBox eData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox memoDebug;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView gridReader;
        private System.Windows.Forms.RichTextBox memoDetected;
        private System.Windows.Forms.Timer timerPoll;
    }
}


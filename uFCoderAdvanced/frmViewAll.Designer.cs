namespace uFrAdvance
{
    partial class frmViewAll
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.stbFunctionError = new System.Windows.Forms.StatusStrip();
            this.pnlFunct_error = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlErr_code = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlErr_expl = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlReadCard = new System.Windows.Forms.Panel();
            this.lblKeyIndex = new System.Windows.Forms.Label();
            this.cboKeyIndex = new System.Windows.Forms.ComboBox();
            this.pnlAUTH = new System.Windows.Forms.Panel();
            this.rbAUTH1B = new System.Windows.Forms.RadioButton();
            this.rbAUTH1A = new System.Windows.Forms.RadioButton();
            this.rbAscii = new System.Windows.Forms.RadioButton();
            this.rbHex = new System.Windows.Forms.RadioButton();
            this.btnReadCard = new System.Windows.Forms.Button();
            this.lvViewAll = new System.Windows.Forms.ListView();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.stbFunctionError.SuspendLayout();
            this.pnlReadCard.SuspendLayout();
            this.pnlAUTH.SuspendLayout();
            this.SuspendLayout();
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
            this.lblHeader.TabIndex = 23;
            this.lblHeader.Text = "View All";
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
            this.stbFunctionError.Padding = new System.Windows.Forms.Padding(1, 0, 30, 0);
            this.stbFunctionError.Size = new System.Drawing.Size(533, 22);
            this.stbFunctionError.SizingGrip = false;
            this.stbFunctionError.TabIndex = 22;
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
            // pnlErr_expl
            // 
            this.pnlErr_expl.Name = "pnlErr_expl";
            this.pnlErr_expl.Size = new System.Drawing.Size(330, 17);
            this.pnlErr_expl.Spring = true;
            this.pnlErr_expl.Text = " ";
            // 
            // pnlReadCard
            // 
            this.pnlReadCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReadCard.Controls.Add(this.pBar);
            this.pnlReadCard.Controls.Add(this.lblKeyIndex);
            this.pnlReadCard.Controls.Add(this.cboKeyIndex);
            this.pnlReadCard.Controls.Add(this.pnlAUTH);
            this.pnlReadCard.Controls.Add(this.rbAscii);
            this.pnlReadCard.Controls.Add(this.rbHex);
            this.pnlReadCard.Controls.Add(this.btnReadCard);
            this.pnlReadCard.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlReadCard.Location = new System.Drawing.Point(0, 292);
            this.pnlReadCard.Name = "pnlReadCard";
            this.pnlReadCard.Size = new System.Drawing.Size(533, 62);
            this.pnlReadCard.TabIndex = 25;
            // 
            // lblKeyIndex
            // 
            this.lblKeyIndex.AutoSize = true;
            this.lblKeyIndex.Location = new System.Drawing.Point(196, 10);
            this.lblKeyIndex.Name = "lblKeyIndex";
            this.lblKeyIndex.Size = new System.Drawing.Size(66, 13);
            this.lblKeyIndex.TabIndex = 35;
            this.lblKeyIndex.Text = "Key Index";
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
            this.cboKeyIndex.Location = new System.Drawing.Point(208, 30);
            this.cboKeyIndex.MaxDropDownItems = 15;
            this.cboKeyIndex.Name = "cboKeyIndex";
            this.cboKeyIndex.Size = new System.Drawing.Size(38, 21);
            this.cboKeyIndex.TabIndex = 33;
            this.cboKeyIndex.Text = "0";
            // 
            // pnlAUTH
            // 
            this.pnlAUTH.Controls.Add(this.rbAUTH1B);
            this.pnlAUTH.Controls.Add(this.rbAUTH1A);
            this.pnlAUTH.Location = new System.Drawing.Point(11, 5);
            this.pnlAUTH.Name = "pnlAUTH";
            this.pnlAUTH.Size = new System.Drawing.Size(142, 47);
            this.pnlAUTH.TabIndex = 5;
            // 
            // rbAUTH1B
            // 
            this.rbAUTH1B.AutoSize = true;
            this.rbAUTH1B.Location = new System.Drawing.Point(34, 26);
            this.rbAUTH1B.Name = "rbAUTH1B";
            this.rbAUTH1B.Size = new System.Drawing.Size(75, 17);
            this.rbAUTH1B.TabIndex = 6;
            this.rbAUTH1B.Text = "AUTH 1B";
            this.rbAUTH1B.UseVisualStyleBackColor = true;
            // 
            // rbAUTH1A
            // 
            this.rbAUTH1A.AutoSize = true;
            this.rbAUTH1A.Checked = true;
            this.rbAUTH1A.Location = new System.Drawing.Point(34, 3);
            this.rbAUTH1A.Name = "rbAUTH1A";
            this.rbAUTH1A.Size = new System.Drawing.Size(75, 17);
            this.rbAUTH1A.TabIndex = 5;
            this.rbAUTH1A.TabStop = true;
            this.rbAUTH1A.Text = "AUTH 1A";
            this.rbAUTH1A.UseVisualStyleBackColor = true;
            // 
            // rbAscii
            // 
            this.rbAscii.AutoSize = true;
            this.rbAscii.Checked = true;
            this.rbAscii.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbAscii.Location = new System.Drawing.Point(298, 8);
            this.rbAscii.Name = "rbAscii";
            this.rbAscii.Size = new System.Drawing.Size(51, 17);
            this.rbAscii.TabIndex = 2;
            this.rbAscii.TabStop = true;
            this.rbAscii.Text = "Ascii";
            this.rbAscii.UseVisualStyleBackColor = true;
            // 
            // rbHex
            // 
            this.rbHex.AutoSize = true;
            this.rbHex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbHex.Location = new System.Drawing.Point(298, 31);
            this.rbHex.Name = "rbHex";
            this.rbHex.Size = new System.Drawing.Size(47, 17);
            this.rbHex.TabIndex = 1;
            this.rbHex.Text = "Hex";
            this.rbHex.UseVisualStyleBackColor = true;
            // 
            // btnReadCard
            // 
            this.btnReadCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReadCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadCard.Location = new System.Drawing.Point(376, 8);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(144, 35);
            this.btnReadCard.TabIndex = 0;
            this.btnReadCard.Text = "READ CARD";
            this.btnReadCard.UseVisualStyleBackColor = true;
            this.btnReadCard.Click += new System.EventHandler(this.btnReadCard_Click);
            // 
            // lvViewAll
            // 
            this.lvViewAll.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvViewAll.BackColor = System.Drawing.Color.White;
            this.lvViewAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvViewAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvViewAll.FullRowSelect = true;
            this.lvViewAll.GridLines = true;
            this.lvViewAll.Location = new System.Drawing.Point(0, 27);
            this.lvViewAll.MultiSelect = false;
            this.lvViewAll.Name = "lvViewAll";
            this.lvViewAll.Size = new System.Drawing.Size(533, 265);
            this.lvViewAll.TabIndex = 26;
            this.lvViewAll.UseCompatibleStateImageBehavior = false;
            this.lvViewAll.View = System.Windows.Forms.View.Details;
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(376, 46);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(144, 11);
            this.pBar.TabIndex = 36;
            this.pBar.Visible = false;
            // 
            // frmViewAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 376);
            this.Controls.Add(this.lvViewAll);
            this.Controls.Add(this.pnlReadCard);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.stbFunctionError);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmViewAll";
            this.Text = "frmViewAll";
            this.Load += new System.EventHandler(this.frmViewAll_Load);
            this.stbFunctionError.ResumeLayout(false);
            this.stbFunctionError.PerformLayout();
            this.pnlReadCard.ResumeLayout(false);
            this.pnlReadCard.PerformLayout();
            this.pnlAUTH.ResumeLayout(false);
            this.pnlAUTH.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.StatusStrip stbFunctionError;
        private System.Windows.Forms.ToolStripStatusLabel pnlFunct_error;
        private System.Windows.Forms.ToolStripStatusLabel pnlErr_code;
        private System.Windows.Forms.ToolStripStatusLabel pnlErr_expl;
        private System.Windows.Forms.Panel pnlReadCard;
        private System.Windows.Forms.Button btnReadCard;
        private System.Windows.Forms.ListView lvViewAll;
        private System.Windows.Forms.RadioButton rbAscii;
        private System.Windows.Forms.RadioButton rbHex;
        private System.Windows.Forms.Panel pnlAUTH;
        private System.Windows.Forms.RadioButton rbAUTH1B;
        private System.Windows.Forms.RadioButton rbAUTH1A;
        private System.Windows.Forms.ComboBox cboKeyIndex;
        private System.Windows.Forms.Label lblKeyIndex;
        private System.Windows.Forms.ProgressBar pBar;
    }
}
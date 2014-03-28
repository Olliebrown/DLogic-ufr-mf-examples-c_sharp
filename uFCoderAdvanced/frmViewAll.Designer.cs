﻿namespace Mifare
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReadCard = new System.Windows.Forms.Button();
            this.lvViewAll = new System.Windows.Forms.ListView();
            this.rbHex = new System.Windows.Forms.RadioButton();
            this.rbAscii = new System.Windows.Forms.RadioButton();
            this.stbFunctionError.SuspendLayout();
            this.panel1.SuspendLayout();
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rbAscii);
            this.panel1.Controls.Add(this.rbHex);
            this.panel1.Controls.Add(this.btnReadCard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 310);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(533, 44);
            this.panel1.TabIndex = 25;
            // 
            // btnReadCard
            // 
            this.btnReadCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReadCard.Location = new System.Drawing.Point(378, 5);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(144, 31);
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
            this.lvViewAll.HoverSelection = true;
            this.lvViewAll.Location = new System.Drawing.Point(0, 27);
            this.lvViewAll.MultiSelect = false;
            this.lvViewAll.Name = "lvViewAll";
            this.lvViewAll.Size = new System.Drawing.Size(533, 283);
            this.lvViewAll.TabIndex = 26;
            this.lvViewAll.UseCompatibleStateImageBehavior = false;
            this.lvViewAll.View = System.Windows.Forms.View.Details;
            // 
            // rbHex
            // 
            this.rbHex.AutoSize = true;
            this.rbHex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbHex.Location = new System.Drawing.Point(123, 12);
            this.rbHex.Name = "rbHex";
            this.rbHex.Size = new System.Drawing.Size(47, 17);
            this.rbHex.TabIndex = 1;
            this.rbHex.Text = "Hex";
            this.rbHex.UseVisualStyleBackColor = true;
            // 
            // rbAscii
            // 
            this.rbAscii.AutoSize = true;
            this.rbAscii.Checked = true;
            this.rbAscii.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbAscii.Location = new System.Drawing.Point(242, 12);
            this.rbAscii.Name = "rbAscii";
            this.rbAscii.Size = new System.Drawing.Size(51, 17);
            this.rbAscii.TabIndex = 2;
            this.rbAscii.TabStop = true;
            this.rbAscii.Text = "Ascii";
            this.rbAscii.UseVisualStyleBackColor = true;
            // 
            // frmViewAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 376);
            this.Controls.Add(this.lvViewAll);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.stbFunctionError);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmViewAll";
            this.Text = "frmViewAll";
            this.Load += new System.EventHandler(this.frmViewAll_Load);
            this.stbFunctionError.ResumeLayout(false);
            this.stbFunctionError.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.StatusStrip stbFunctionError;
        private System.Windows.Forms.ToolStripStatusLabel pnlFunct_error;
        private System.Windows.Forms.ToolStripStatusLabel pnlErr_code;
        private System.Windows.Forms.ToolStripStatusLabel pnlErr_expl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReadCard;
        private System.Windows.Forms.ListView lvViewAll;
        private System.Windows.Forms.RadioButton rbAscii;
        private System.Windows.Forms.RadioButton rbHex;
    }
}
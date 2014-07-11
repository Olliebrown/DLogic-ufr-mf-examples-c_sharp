namespace Mifare
{
    partial class frmLinearReadWrite
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
            this.btnLinearWrite = new System.Windows.Forms.Button();
            this.txtLinearWrite_text = new System.Windows.Forms.TextBox();
            this.txtLinearWrite_address = new System.Windows.Forms.TextBox();
            this.txtLinearWrite_length = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
         
          
            // frmLinearReadWrite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 7F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 473, 298 );
            this.Controls.Add( this.txtLinearWrite_length );
            this.Controls.Add( this.txtLinearWrite_address );
            this.Controls.Add( this.txtLinearWrite_text );
            this.Controls.Add( this.btnLinearWrite );
            this.Font = new System.Drawing.Font( "Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "frmLinearReadWrite";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Linear Read/Write AKM1,AKM2,PK";
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLinearWrite;
        private System.Windows.Forms.TextBox txtLinearWrite_text;
        private System.Windows.Forms.TextBox txtLinearWrite_address;
        private System.Windows.Forms.TextBox txtLinearWrite_length;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Text.RegularExpressions;


namespace Mifare
{
    using DL_STATUS = System.UInt32;
    
    public partial class frmuFrAdvance : Form
    {

        const byte       DL_OK = 0,
                         RES_OK_LIGHT = 4,
                         RES_OK_SOUND = 4,
                         ERR_LIGHT = 2,
                         ERR_SOUND = 2;
        const int        MAX_BYTES = 752;
        
        private DL_STATUS result;
        private Boolean CONN = false;

      /*
        public bool reader_stop = false,
                     thread_start = false,
                     functionOn = false;

        public void ReaderOff()
        {
            reader_stop = true;
        }
        public void ReaderOn()
        {
            reader_stop = false;
        }

     */

        Globals GL = new Globals();
        public frmuFrAdvance()
        {
            InitializeComponent();

        }
        void ShowForm(System.Windows.Forms.Form my_form)
        {
            //my_form = new Form();
            my_form.TopLevel = false;
            my_form.Dock = DockStyle.Fill;
            my_form.Show();
            pnlConteiner.Controls.Add(my_form);
            my_form.BringToFront();
        }
        
        private void MainThread()
        {
            new Globals().ReaderStart = true;
            ulong reader_type = 0;
            ulong reader_serial = 0;
            byte card_type = 0;
            ulong card_serial = 0;
            byte[] user_data = new byte[16];
            if (!CONN)
            {
                result = ufCoder1x.ReaderOpen();
                if (result == DL_OK)
                {
                    pnlConn.Text = "CONNECTED";
                    CONN = true;
                    GL.ERRORS_CODE(result, this.stbReader);
                }
                else
                {
                    pnlConn.Text = "NOT CONNECTED";
                    txtReaderType.Text = "";
                    txtReaderSerial.Text = "";
                    txtCardType.Text = "";
                    txtCardSerial.Text = "";
                    GL.ERRORS_CODE(result, this.stbReader);
                }

            }
            if (CONN)
            {
                unsafe
                {
                    if ((result = ufCoder1x.GetReaderType(&reader_type)) == DL_OK)
                    {
                        txtReaderType.Text = "0x" + reader_type.ToString("X");
                        if ((result = ufCoder1x.GetReaderSerialNumber(&reader_serial)) == DL_OK)
                        {
                            txtReaderSerial.Text = "0x" + reader_serial.ToString("X");
                        }

                        if ((result = ufCoder1x.GetCardId(&card_type, &card_serial)) == DL_OK)
                        {
                            txtCardType.Text = "0x" + card_type.ToString("X2");
                            txtCardSerial.Text = "0x" + card_serial.ToString("X");
                            GL.ERRORS_CODE(result, this.stbCard);
                        }
                        else
                        {
                            txtCardSerial.Text = "";
                            txtCardType.Text = "";
                            GL.ERRORS_CODE(result, this.stbCard);
                        }

                        fixed (byte* PData = user_data)
                        {
                            result = ufCoder1x.ReadUserData(PData);
                        }
                        if (result == DL_OK)
                            txtUserData.Text = System.Text.Encoding.ASCII.GetString(user_data);
                        else
                            txtUserData.Text = "";

                    }
                    else
                    {
                        CONN = false;
                        ufCoder1x.ReaderClose();
                    }
                }
            }
            new Globals().ReaderStart = true;
 }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!new Globals().FunctionStart)
                MainThread();
        }

        private void frmMifare_Load(object sender, EventArgs e)
        {
            cboLightMode.SelectedItem = cboLightMode.Items[0];
            cboSoundMode.SelectedItem = cboSoundMode.Items[0];
            cboKeyIndex.SelectedItem = cboKeyIndex.Items[0];
            frmLinearReadWrite LinearReadWrite = new frmLinearReadWrite();
            ShowForm(LinearReadWrite);

            for (int br = 0; br < 6; br++)
            {
                System.Windows.Forms.TextBox RB = new TextBox();
                RB.Width = 31;
                RB.Height = 21;
                RB.Location = new Point(21 + (RB.Width * br + 2), 17);
                RB.Name = "txtReaderKey";
                RB.Text = "255";
                RB.MaxLength = 3;
                RB.Font = new Font("Verdana", 8, FontStyle.Bold);
                RB.KeyPress += new KeyPressEventHandler(RB_KeyPress);
                RB.Leave += new EventHandler(RB_Leave);
                RB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                pnlReaderKey.Controls.Add(RB);
            }
        }

        void Check_values(object sender)
        {
            
            TextBox TB = (TextBox)sender;
            if (TB.Text.Trim() == String.Empty)
            {
                TB.Focus();                
                TB.Undo();
            }

            if (chkHex.Checked) return;

            if (System.Convert.ToInt16(TB.Text) > 255)
            {
                MessageBox.Show("Wrong entry !\nYou must enter the numeric value of less than 255.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TB.Undo();
                TB.Focus();
                TB.SelectAll();
                //TB = null;
            }
        }
        void RB_Leave(object sender, EventArgs e)
        {
            Check_values(sender);

        }


        void RB_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox TB = (TextBox)sender;
            if (e.KeyChar == (char)Keys.Back) return;
            
            if (chkHex.Checked)
            {
               
                TB.MaxLength = 2;
                if (Regex.IsMatch(e.KeyChar.ToString(), "[^a-fA-F0-9]")) e.Handled = true;
            }
            else
            {
                TB.MaxLength = 3;
                if (Regex.IsMatch(e.KeyChar.ToString(), "[^0-9]")) e.Handled = true;
            }
           
        }

        private void btnReaderUISignal_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;
            GL.FunctionStart = true;
                ufCoder1x.ReaderUISignal(cboLightMode.SelectedIndex, cboSoundMode.SelectedIndex);
            GL.FunctionStart = false;
            GL = null;
        }

        private void btnWriteUserData_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;
            try
            {
                GL.FunctionStart = true;
                if (txtNewUserData.Text == String.Empty)
                {
                    MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNewUserData.Focus();
                    return;
                }

                byte[] new_user_data = new byte[16];
                string str = txtNewUserData.Text;
                new_user_data = System.Text.Encoding.ASCII.GetBytes(str);
                unsafe
                {
                    fixed (byte* PData = new_user_data)
                    {
                        result = ufCoder1x.WriteUserData(PData);
                    }
                }
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    GL.ERRORS_CODE(result, this.stbReader);

                }
                else
                {
                    ufCoder1x.ReaderUISignal(ERR_SOUND, ERR_SOUND);
                    GL.ERRORS_CODE(result, this.stbReader);
                }

            }
            finally
            {
                GL.FunctionStart = false;
                GL = null;
            }
        }

        private void btnReaderReset_Click(object sender, EventArgs e)
        {
            
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;
            try
            {
                GL.FunctionStart = true;
                result = ufCoder1x.ReaderReset();
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);                   
                }
                else
                {
                    ufCoder1x.ReaderUISignal(ERR_SOUND, ERR_SOUND);                  
                }
            }
            finally
            {
                GL.FunctionStart = false;
                GL = null;
            }
        }

        private void btnSoftRestart_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;
            try
            {
                GL.FunctionStart = true;
                result = ufCoder1x.ReaderSoftRestart();
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);                    
                }
                else
                {
                    ufCoder1x.ReaderUISignal(ERR_SOUND, ERR_SOUND);                    
                }            
           }
            finally
            {
                GL.FunctionStart = false;
                GL = null;
            }
        }



        private void chkHex_CheckedChanged(object sender, EventArgs e)
        {

            switch (chkHex.Checked)
            {
                case true:

                    for (int i = 0; i <= pnlReaderKey.Controls.Count - 1; i++)
                    {
                        if (pnlReaderKey.Controls[i].Name == "txtReaderKey")
                        {

                            pnlReaderKey.Controls[i].Text = Convert.ToInt32(pnlReaderKey.Controls[i].Text).ToString("X");
                        }
                    }
                    break;
                case false:
                    for (int i = 0; i <= pnlReaderKey.Controls.Count - 1; i++)
                    {
                        if (pnlReaderKey.Controls[i].Name == "txtReaderKey")
                        {

                            pnlReaderKey.Controls[i].Text = int.Parse(pnlReaderKey.Controls[i].Text, System.Globalization.NumberStyles.HexNumber).ToString();
                        }
                    }
                    break;
            }
        }

        private void btnReaderKeyWrite_Click(object sender, EventArgs e)
        {
             Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;
            try
            {
                GL.FunctionStart = true;

            byte key_index = System.Convert.ToByte(cboKeyIndex.Text);
            byte[] reader_key = new byte[6];
            byte count = 0;

            foreach (Control ctrl in pnlReaderKey.Controls)
            {
                if (ctrl.Name == "txtReaderKey")
                {
                    if (!chkHex.Checked)
                        reader_key[count] = Convert.ToByte(ctrl.Text);
                    else
                        reader_key[count] = Convert.ToByte(int.Parse(ctrl.Text, System.Globalization.NumberStyles.HexNumber).ToString());
                    count++;
                }
            }
            unsafe
            {
                fixed (byte* PData = reader_key)
                {
                    result = ufCoder1x.ReaderKeyWrite(PData, key_index);
                }
            }
            if (result == DL_OK)
            {
                ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);                
                GL.ERRORS_CODE(result, this.stbReader);                
            }
            else
            {
                ufCoder1x.ReaderUISignal(ERR_SOUND, ERR_SOUND);                
                GL.ERRORS_CODE(result, this.stbReader);                
            }
            }
            finally
            {
                GL.FunctionStart = false;
                GL = null;
            }
    }


        private void mnuExitItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuBlockReadWriteItem_Click(object sender, EventArgs e)
        {

            frmBlockReadWrite BlockReadWrite = new frmBlockReadWrite();
            ShowForm(BlockReadWrite);

        }

        private void linearReadWriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLinearReadWrite LinearReadWrite = new frmLinearReadWrite();
            ShowForm(LinearReadWrite);
        }

        private void mnuBlockInSectorReadWriteItem_Click(object sender, EventArgs e)
        {
            frmBlockInSectorReadWrite BlockInSectorReadWrite = new frmBlockInSectorReadWrite();
            ShowForm(BlockInSectorReadWrite);
        }

        private void mnuValueBlockReadWriteItem_Click(object sender, EventArgs e)
        {
            frmValueBlockReadWrite ValueBlockReadWrite = new frmValueBlockReadWrite();
            ShowForm(ValueBlockReadWrite);
        }

        private void mnuValueBlockIncrDecrItems_Click(object sender, EventArgs e)
        {
            frmValueBlockIncrDecr ValueBlockIncrDecr = new frmValueBlockIncrDecr();
            ShowForm(ValueBlockIncrDecr);
        }

        private void mnuValueBlockInSectorReadWrite_Click(object sender, EventArgs e)
        {
            frmValueBlockInSectorReadWrite ValueBlockInSectorReadWrite = new frmValueBlockInSectorReadWrite();
            ShowForm(ValueBlockInSectorReadWrite);
        }

        private void mnuValueBlockInSectorIncrDecrItem_Click(object sender, EventArgs e)
        {
            frmValueBlockInSectorIncremDecrem ValueBlockInSectorIncDecr = new frmValueBlockInSectorIncremDecrem();
            ShowForm(ValueBlockInSectorIncDecr);
        }

        private void mnuSectorTrailerWriteItems_Click(object sender, EventArgs e)
        {
            frmSectorTrailerWrite SectorTrailerWrite = new frmSectorTrailerWrite();
            ShowForm(SectorTrailerWrite);
        }



        private void mnuLinearFormatCardItem_Click(object sender, EventArgs e)
        {
            frmLinearFormatCard LinearFormatCard = new frmLinearFormatCard();
            ShowForm(LinearFormatCard);
        }

        private void mnuViewAllItem_Click_1(object sender, EventArgs e)
        {
            frmViewAll ViewAll = new frmViewAll();
            ShowForm(ViewAll);
        }

       















    }
}

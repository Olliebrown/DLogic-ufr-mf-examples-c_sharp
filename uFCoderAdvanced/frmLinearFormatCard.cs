using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Mifare
{
    public partial class frmLinearFormatCard : Form
    {
        public frmLinearFormatCard()
        {
            InitializeComponent();
           
        }
        private UInt32 result;
        private CheckBox HEX_BOX_CHECKED = new CheckBox();
        byte[] key_a = new byte[6];
        byte[] key_b = new byte[6];
        const byte AUTH1A = 96,
                   AUTH1B = 97,
                   DL_OK = 0,
                   RES_OK_LIGHT = 4,
                   RES_OK_SOUND = 4,
                   ERR_LIGHT = 2,
                   ERR_SOUND = 2;
        const string
                    CONVERT_ERROR = "You may enter only whole decimal number !";

        void HexKey_clicked(CheckBox hex_checkbox, string name_of_key, Panel panel_container)
        {
            switch (hex_checkbox.Checked)
            {
                case true:
                    foreach (Control ctrl in panel_container.Controls)
                    {
                        if (ctrl.Name == name_of_key)
                        {
                            ctrl.Text = Convert.ToByte(ctrl.Text).ToString("X");
                        }
                    }
                    break;
                case false:
                    foreach (Control ctrl in panel_container.Controls)
                    {
                        if (ctrl.Name == name_of_key)
                        {
                            ctrl.Text = int.Parse(ctrl.Text, System.Globalization.NumberStyles.HexNumber).ToString();
                        }
                    }
                    break;
            }
        }

        void CreateKey(byte key_height, byte key_width, int key_top, int key_left, string key_name, byte number_key, Boolean key_readonly, Panel pnlContainer)
        {
            for (byte br = 0; br < number_key; ++br)
            {
                System.Windows.Forms.TextBox KBox = new TextBox();
                KBox.Height = key_height;
                KBox.Width = key_width;
                KBox.Location = new System.Drawing.Point(key_left + (key_width * br + 2), key_top);
                KBox.Name = key_name;
                KBox.Text = "255";
                KBox.Font = new Font("Verdana", 8, FontStyle.Bold);
                KBox.ReadOnly = key_readonly;
                KBox.KeyPress += new KeyPressEventHandler(KBox_KeyPress);
                KBox.Leave += new EventHandler(KBox_Leave);
                KBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                pnlContainer.Controls.Add(KBox);
            }
        }


        void Check_value(object sender)
        {
              
            TextBox TB = (TextBox)sender;

            HEX_BOX_CHECKED = TB.Name == "txtKeyA" ? chkHexKeyA : chkHexKeyB;
            if (TB.Text.Trim() == String.Empty)
            {
                TB.Undo();
                TB.Focus();
                TB.SelectAll();
                return;
            }
           if (HEX_BOX_CHECKED.Checked) return;
            
                if (System.Convert.ToInt16(TB.Text) > 255)
                {
                    MessageBox.Show("Wrong entry !\nYou must enter the numeric value of less than 255.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TB.Undo();
                    TB.Focus();
                    TB.SelectAll();
                }
              
        }

        void KBox_Leave(object sender, EventArgs e)
        {
            Check_value(sender);

        }

        void KBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox TB = (TextBox)sender;
            if (e.KeyChar == (char)Keys.Back) return;
            
            if (TB.Name == "txtKeyA")
            {
                HEX_BOX_CHECKED = chkHexKeyA;
                TB.MaxLength = 3;
                if (chkHexKeyA.Checked)
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
            if (TB.Name == "txtKeyB")
            {
                HEX_BOX_CHECKED = chkHexKeyB;
                TB.MaxLength = 3;
                if (chkHexKeyB.Checked)
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
        }

        void WriteKeyAB()
        {
           
            byte count = 0;
            foreach (Control ctrl in pnlKeyA.Controls)
            {
                if (ctrl.Name == "txtKeyA")
                {
                    if (!chkHexKeyA.Checked)
                        key_a[count] = System.Convert.ToByte(ctrl.Text);
                    else
                        key_a[count] = System.Convert.ToByte(int.Parse(ctrl.Text, System.Globalization.NumberStyles.HexNumber));
                    count++;
                }
            }
            count = 0;
            foreach (Control ctrl in pnlKeyB.Controls)
            {
                if (ctrl.Name == "txtKeyB")
                {
                    if (!chkHexKeyB.Checked)
                        key_b[count] = System.Convert.ToByte(ctrl.Text);
                    else
                        key_b[count] = System.Convert.ToByte(int.Parse(ctrl.Text, System.Globalization.NumberStyles.HexNumber));
                    count++;
                }
            }
        }

        private void frmLinearFormatCard_Load(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            cboKeyIndex.SelectedItem = cboKeyIndex.Items[0];
            GL.CreatePKKey(21, 31, 4, 350, "txtPKKey", 6, false, pnlAuth);
            GL = null;
            CreateKey(21, 31, 29, 30, "txtKeyA", 6, false, pnlKeyA);
            CreateKey(21, 31, 29, 32, "txtKeyB", 6, false, pnlKeyB);
        }
      
        private void chkHexKeyB_Click_1(object sender, EventArgs e)
        {
           HexKey_clicked(chkHexKeyB, "txtKeyB", pnlKeyB);
        }

        private void chkHexKeyA_Click_1(object sender, EventArgs e)
        {
          HexKey_clicked(chkHexKeyA, "txtKeyA", pnlKeyA);
        }

        private void btnFormat_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte block_access_bits = 0;
            byte sector_trailer_access_bits = 0;
            byte trailer_byte_9 = 0;
            byte sectors_formatted = 0;
            byte auth_mode = 0;
            byte key_index = 0;
            try
            {
                GL.FunctionStart = true;
                if (cboBlockAccessBits.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ACCESS BITS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboBlockAccessBits.Focus();
                    return;

                }
                if (cboSectorTrailerAccessBits.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR TRAILER ACCESS BITS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSectorTrailerAccessBits.Focus();
                    return;

                }
                if (txtSectorTrailerByte9.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR TRAILER BYTE 9 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSectorTrailerByte9.Focus();
                    return;
                }
                key_index = System.Convert.ToByte(cboKeyIndex.Text);
               
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                block_access_bits = System.Convert.ToByte(cboBlockAccessBits.Text);
                 sector_trailer_access_bits = System.Convert.ToByte (cboSectorTrailerAccessBits.Text) ;
                 trailer_byte_9 = System.Convert.ToByte(txtSectorTrailerByte9.Text);
               
                WriteKeyAB();
                unsafe
                {
                    fixed (byte* KEY_A = key_a, KEY_B = key_b)
                        result = ufCoder1x.LinearFormatCard(KEY_A, block_access_bits, sector_trailer_access_bits, trailer_byte_9, KEY_B,&sectors_formatted, auth_mode, key_index);
                }
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    txtSectorsFormatted.Text = System.Convert.ToString(sectors_formatted);                
                    GL.ERRORS_CODE(result, stbFunctionError);
                    
                }
                else
                {
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);
                    txtSectorsFormatted.Text = System.Convert.ToString(sectors_formatted);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show(CONVERT_ERROR, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GL.FunctionStart = false;
                GL = null;
            }        
            
        }

        private void btnFormatAKM1_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            try
            {
                GL.FunctionStart = true;
                if (cboBlockAccessBitsAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ACCESS BITS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboBlockAccessBitsAKM1.Focus();
                    return;

                }
                if (cboSectorTrailerAccessBitsAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR TRAILER ACCESS BITS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSectorTrailerAccessBitsAKM1.Focus();
                    return;

                }
                if (txtSectorTrailerByte9AKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR TRAILER BYTE 9 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSectorTrailerByte9AKM1.Focus();
                    return;
                }
                
                byte auth_mode = 0;
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                byte block_access_bits = System.Convert.ToByte(cboBlockAccessBitsAKM1.Text);
                byte sector_trailer_access_bits = System.Convert.ToByte(cboSectorTrailerAccessBitsAKM1.Text);
                byte trailer_byte_9 = System.Convert.ToByte(txtSectorTrailerByte9AKM1.Text);
                byte sectors_formatted = 0;
                WriteKeyAB();
                unsafe
                {
                    fixed (byte* KEY_A = key_a, KEY_B = key_b)
                        result = ufCoder1x.LinearFormatCard_AKM1(KEY_A, block_access_bits, sector_trailer_access_bits, trailer_byte_9, KEY_B, &sectors_formatted, auth_mode);
                }
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    txtSectorsFormattedAKM1.Text = System.Convert.ToString(sectors_formatted);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
                else
                {
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);
                    txtSectorsFormattedAKM1.Text = System.Convert.ToString(sectors_formatted);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show(CONVERT_ERROR, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GL.FunctionStart = false;
                GL = null;
            }        
        }

        private void btnFormatAKM2_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            try
            {
                GL.FunctionStart = true;
                if (cboBlockAccessBitsAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ACCESS BITS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboBlockAccessBitsAKM2.Focus();
                    return;

                }
                if (cboSectorTrailerAccessBitsAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR TRAILER ACCESS BITS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSectorTrailerAccessBitsAKM2.Focus();
                    return;

                }
                if (txtSectorTrailerByte9AKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR TRAILER BYTE 9 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSectorTrailerByte9AKM2.Focus();
                    return;
                }

                byte auth_mode = 0;
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                byte block_access_bits = System.Convert.ToByte(cboBlockAccessBitsAKM2.Text);
                byte sector_trailer_access_bits = System.Convert.ToByte(cboSectorTrailerAccessBitsAKM2.Text);
                byte trailer_byte_9 = System.Convert.ToByte(txtSectorTrailerByte9AKM2.Text);
                byte sectors_formatted = 0;
                WriteKeyAB();
                unsafe
                {
                    fixed (byte* KEY_A = key_a, KEY_B = key_b)
                        result = ufCoder1x.LinearFormatCard_AKM2(KEY_A, block_access_bits, sector_trailer_access_bits, trailer_byte_9, KEY_B, &sectors_formatted, auth_mode);
                }
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    txtSectorsFormattedAKM2.Text = System.Convert.ToString(sectors_formatted);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
                else
                {
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);
                    txtSectorsFormattedAKM2.Text = System.Convert.ToString(sectors_formatted);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show(CONVERT_ERROR, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GL.FunctionStart = false;
                GL = null;
            }          
        }

        private void btnFormatPK_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            try
            {
                GL.FunctionStart = true;
                if (cboBlockAccessBitsPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ACCESS BITS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboBlockAccessBitsPK.Focus();
                    return;

                }
                if (cboSectorTrailerAccessBitsPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR TRAILER ACCESS BITS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSectorTrailerAccessBitsPK.Focus();
                    return;

                }
                if (txtSectorTrailerByte9PK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR TRAILER BYTE 9 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSectorTrailerByte9PK.Focus();
                    return;
                }
                byte[] pk_key = new byte[6];
                byte count = 0;
                foreach (Control ctrl in pnlAuth.Controls)
                {
                    if (ctrl.Name == "txtPKKey")
                    {
                        pk_key[count] = System.Convert.ToByte(ctrl.Text);
                        count++;
                    }
                }
                byte auth_mode = 0;
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                byte block_access_bits = System.Convert.ToByte(cboBlockAccessBitsPK.Text);
                byte sector_trailer_access_bits = System.Convert.ToByte(cboSectorTrailerAccessBitsPK.Text);
                byte trailer_byte_9 = System.Convert.ToByte(txtSectorTrailerByte9PK.Text);
                byte sectors_formatted = 0;
                WriteKeyAB();
                unsafe
                {
                    fixed (byte* KEY_A = key_a, KEY_B = key_b,PK_KEY=pk_key)
                        result = ufCoder1x.LinearFormatCard_PK(KEY_A, block_access_bits, sector_trailer_access_bits, trailer_byte_9, KEY_B, &sectors_formatted, auth_mode,PK_KEY);
                }
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    txtSectorsFormattedPK.Text = System.Convert.ToString(sectors_formatted);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
                else
                {
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);
                    txtSectorsFormattedPK.Text = System.Convert.ToString(sectors_formatted);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show(CONVERT_ERROR, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GL.FunctionStart = false;
                GL = null;
            }          
        }

        private void chkHexKeyA_CheckedChanged(object sender, EventArgs e)
        {

        }

        
    }
}

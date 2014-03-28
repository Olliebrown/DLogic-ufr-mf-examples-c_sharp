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
    public partial class frmSectorTrailerWrite : Form
    {
        public frmSectorTrailerWrite()
        {
            InitializeComponent();
        }
        private UInt32 result;
        private CheckBox HEX_BOX_CHECKED = new CheckBox();
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
            TextBox TB=(TextBox)sender;
            if (e.KeyChar == (char)Keys.Back) return;
            if (TB.Name == "txtKeyA")
            {
                HEX_BOX_CHECKED = chkHexKeyA;
                
                if (chkHexKeyA.Checked)
                {
                    if (e.KeyChar == (char)Keys.Back) return;
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
                
                if (chkHexKeyB.Checked)
                {
                    // if (e.KeyChar == (char)Keys.Back) return;
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
        private void frmSectorTrailerWrite_Load(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            cboKeyIndex.SelectedItem = cboKeyIndex.Items[0];
            GL.CreatePKKey(21, 31, 4, 350, "txtPKKey", 6, false, pnlAuth);
            GL = null;
            CreateKey(21, 31, 29, 30, "txtKeyA", 6, false, pnlKeyA);
            CreateKey(21, 31, 29, 32, "txtKeyB", 6, false, pnlKeyB);
        }

        private void chkDefaultKeyA_Click(object sender, EventArgs e)
        {
           // DefaultKey_clicked(chkHexKeyA, chkDefaultKeyA, "txtKeyA", pnlKeyA);
        }

        private void chkHexKeyA_Click(object sender, EventArgs e)
        {
            HexKey_clicked(chkHexKeyA, "txtKeyA", pnlKeyA);
        }

        private void chkHexKeyB_Click(object sender, EventArgs e)
        {
            HexKey_clicked(chkHexKeyB, "txtKeyB", pnlKeyB);
        }

        private void btnSTWWrite_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte auth_mode = 0;
            try
            {
                GL.FunctionStart = true;
                if (cboSTWAddressingMode.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter ADDRESSING MODE !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAddressingMode.Focus();
                    return;
                }
                if (txtSTWBlockOrSectorAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK OR SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSTWBlockOrSectorAddress.Focus();
                    return;
                }
                if (cboSTWAccessBits0.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ACCESS BITS 0 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAccessBits0.Focus();
                    return;
                }
                if (cboSTWAccessBits1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ACCESS BITS 1 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAccessBits1.Focus();
                    return;
                }
                if (cboSTWAccessBits2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ACCESS BITS 2 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAccessBits2.Focus();
                    return;
                }
                if (cboSTWTrailerAccessBits.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter TRAILER ACCESS BITS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWTrailerAccessBits.Focus();
                    return;
                }
                
                if (txtSTWTrailerByte9.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter TRAILER BYTE 9 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSTWTrailerByte9.Focus();
                    return;
                }

                byte block_access_bits0 = System.Convert.ToByte(cboSTWAccessBits0.Text);
                byte block_access_bits1 = System.Convert.ToByte(cboSTWAccessBits1.Text);
                byte block_access_bits2 = System.Convert.ToByte(cboSTWAccessBits2.Text);
                byte trailer_access_bits = System.Convert.ToByte(cboSTWTrailerAccessBits.Text);
                byte addressing_mode = System.Convert.ToByte(cboSTWAddressingMode.Text);
                byte block_or_sector = System.Convert.ToByte(txtSTWBlockOrSectorAddress.Text);
                byte trailer_access_bits_9 = System.Convert.ToByte(txtSTWTrailerByte9.Text);

                byte key_index = System.Convert.ToByte(cboKeyIndex.Text);
                
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                byte[] key_a = new byte[6];
                byte[] key_b = new byte[6];
                byte count = 0;
                foreach (Control ctrl in pnlKeyA.Controls)
                {
                    if (ctrl.Name == "txtKeyA")
                    {
                        if (!chkHexKeyA.Checked)
                        key_a[count] = System.Convert.ToByte(ctrl.Text);
                        else
                            key_a[count] =System.Convert.ToByte(int.Parse(ctrl.Text, System.Globalization.NumberStyles.HexNumber));
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
                unsafe
                {
                    fixed (byte* PK_KEY_A = key_a, PK_KEY_B = key_b)
                    result = ufCoder1x.SectorTrailerWrite(addressing_mode, block_or_sector, PK_KEY_A, block_access_bits0, block_access_bits1, block_access_bits2, trailer_access_bits, trailer_access_bits_9, PK_KEY_B, auth_mode, key_index);
                }
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
                else
                {
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(CONVERT_ERROR, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GL.FunctionStart = false;
                GL = null;
            }          
        }

        private void btnSTWWriteAKM1_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte auth_mode = 0;
            try
            {
                GL.FunctionStart = true;
                if (cboSTWAddressingModeAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter ADDRESSING MODE !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAddressingModeAKM1.Focus();
                    return;
                }
                if (txtSTWBlockOrSectorAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK OR SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSTWBlockOrSectorAddressAKM1.Focus();
                    return;
                }
                if (cboSTWAccessBits0AKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ACCESS BITS 0 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAccessBits0AKM1.Focus();
                    return;
                }
                if (cboSTWAccessBits1AKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ACCESS BITS 1 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAccessBits1AKM1.Focus();
                    return;
                }
                if (cboSTWAccessBits2AKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ACCESS BITS 2 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAccessBits2AKM1.Focus();
                    return;
                }
                if (cboSTWTrailerAccessBitsAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter TRAILER ACCESS BITS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWTrailerAccessBitsAKM1.Focus();
                    return;
                }
               
                if (txtSTWTrailerByte9AKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter TRAILER BYTE 9 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSTWTrailerByte9AKM1.Focus();
                    return;
                }
                byte block_access_bits0 = System.Convert.ToByte(cboSTWAccessBits0AKM1.Text);
                byte block_access_bits1 = System.Convert.ToByte(cboSTWAccessBits1AKM1.Text);
                byte block_access_bits2 = System.Convert.ToByte(cboSTWAccessBits2AKM1.Text);
                byte trailer_access_bits = System.Convert.ToByte(cboSTWTrailerAccessBitsAKM1.Text);
                byte addressing_mode = System.Convert.ToByte(cboSTWAddressingModeAKM1.Text);
                byte block_or_sector = System.Convert.ToByte(txtSTWBlockOrSectorAddressAKM1.Text);
                byte trailer_access_bits_9 = System.Convert.ToByte(txtSTWTrailerByte9AKM1.Text);
               
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                byte[] key_a = new byte[6];
                byte[] key_b = new byte[6];
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
                unsafe
                {
                    fixed (byte* PK_KEY_A = key_a, PK_KEY_B = key_b)
                        result = ufCoder1x.SectorTrailerWrite_AKM1(addressing_mode, block_or_sector, PK_KEY_A, block_access_bits0, block_access_bits1, block_access_bits2, trailer_access_bits, trailer_access_bits_9, PK_KEY_B, auth_mode);
                }
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
                else
                {
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(CONVERT_ERROR, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GL.FunctionStart = false;
                GL = null;
            }          

        }

        private void btnSTWWriteAKM2_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte auth_mode = 0;
            try
            {
                GL.FunctionStart = true;
                if (cboSTWAddressingModeAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter ADDRESSING MODE !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAddressingModeAKM2.Focus();
                    return;
                }
                if (txtSTWBlockOrSectorAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK OR SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSTWBlockOrSectorAddressAKM2.Focus();
                    return;
                }
                if (cboSTWAccessBits0AKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ACCESS BITS 0 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAccessBits0AKM2.Focus();
                    return;
                }
                if (cboSTWAccessBits1AKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ACCESS BITS 1 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAccessBits1AKM2.Focus();
                    return;
                }
                if (cboSTWAccessBits2AKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ACCESS BITS 2 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAccessBits2AKM2.Focus();
                    return;
                }
                if (cboSTWTrailerAccessBitsAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter TRAILER ACCESS BITS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWTrailerAccessBitsAKM2.Focus();
                    return;
                }
                
                if (txtSTWTrailerByte9AKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter TRAILER BYTE 9 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSTWTrailerByte9AKM2.Focus();
                    return;
                }
                byte block_access_bits0 = System.Convert.ToByte(cboSTWAccessBits0AKM2.Text);
                byte block_access_bits1 = System.Convert.ToByte(cboSTWAccessBits1AKM2.Text);
                byte block_access_bits2 = System.Convert.ToByte(cboSTWAccessBits2AKM2.Text);
                byte trailer_access_bits = System.Convert.ToByte(cboSTWTrailerAccessBitsAKM2.Text);
                byte addressing_mode = System.Convert.ToByte(cboSTWAddressingModeAKM2.Text);
                byte block_or_sector = System.Convert.ToByte(txtSTWBlockOrSectorAddressAKM2.Text);
                byte trailer_access_bits_9 = System.Convert.ToByte(txtSTWTrailerByte9AKM2.Text);
               
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                byte[] key_a = new byte[6];
                byte[] key_b = new byte[6];
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
                unsafe
                {
                    fixed (byte* PK_KEY_A = key_a, PK_KEY_B = key_b)
                        result = ufCoder1x.SectorTrailerWrite_AKM2(addressing_mode, block_or_sector, PK_KEY_A, block_access_bits0, block_access_bits1, block_access_bits2, trailer_access_bits, trailer_access_bits_9, PK_KEY_B, auth_mode);
                }
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
                else
                {
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(CONVERT_ERROR, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GL.FunctionStart = false;
                GL = null;
            }          
        }

        private void btnSTWWritePK_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte auth_mode = 0;
            try
            {
                GL.FunctionStart = true;
                if (cboSTWAddressingModePK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter ADDRESSING MODE !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAddressingModePK.Focus();
                    return;
                }
                if (txtSTWBlockOrSectorAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK OR SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSTWBlockOrSectorAddressPK.Focus();
                    return;
                }
                if (cboSTWAccessBits0PK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ACCESS BITS 0 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAccessBits0PK.Focus();
                    return;
                }
                if (cboSTWAccessBits1PK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ACCESS BITS 1 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAccessBits1PK.Focus();
                    return;
                }
                if (cboSTWAccessBits2PK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ACCESS BITS 2 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAccessBits2PK.Focus();
                    return;
                }
                if (cboSTWTrailerAccessBitsPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter TRAILER ACCESS BITS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWTrailerAccessBitsPK.Focus();
                    return;
                }
                
                if (txtSTWTrailerByte9PK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter TRAILER BYTE 9 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSTWTrailerByte9PK.Focus();
                    return;
                }
                byte block_access_bits0 = System.Convert.ToByte(cboSTWAccessBits0PK.Text);
                byte block_access_bits1 = System.Convert.ToByte(cboSTWAccessBits1PK.Text);
                byte block_access_bits2 = System.Convert.ToByte(cboSTWAccessBits2PK.Text);
                byte trailer_access_bits = System.Convert.ToByte(cboSTWTrailerAccessBitsPK.Text);
                byte addressing_mode = System.Convert.ToByte(cboSTWAddressingModePK.Text);
                byte block_or_sector = System.Convert.ToByte(txtSTWBlockOrSectorAddressPK.Text);
                byte trailer_byte_9 = System.Convert.ToByte(txtSTWTrailerByte9PK.Text);
               
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                byte[] key_a = new byte[6];
                byte[] key_b = new byte[6];
                byte count = 0;
                byte[] pk_key = new byte[6];
                foreach (Control ctrl in pnlAuth.Controls)
                {
                    if (ctrl.Name == "txtPKKey")
                    {
                        pk_key[count] = System.Convert.ToByte(ctrl.Text);
                        count++;
                    }
                }
                count = 0;
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
                unsafe
                {
                    fixed (byte* PK_KEY_A = key_a, PK_KEY_B = key_b,PK_KEY=pk_key)
                        result = ufCoder1x.SectorTrailerWrite_PK(addressing_mode, block_or_sector, PK_KEY_A, block_access_bits0, block_access_bits1, block_access_bits2, trailer_access_bits, trailer_byte_9, PK_KEY_B, auth_mode,PK_KEY);
                }
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
                else
                {
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(CONVERT_ERROR, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GL.FunctionStart = false;
                GL = null;
            }          

        }

        

      
    }
}

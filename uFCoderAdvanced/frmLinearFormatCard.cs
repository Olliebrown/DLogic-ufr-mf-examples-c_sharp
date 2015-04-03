using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace uFrAdvance
{
    using DL_STATUS = System.UInt32;
    public partial class frmLinearFormatCard : Form
    {
        private
             Globals GL = new Globals();
        public frmLinearFormatCard()
        {
            InitializeComponent();
           
        }

         //authenticate
        const byte MIFARE_AUTHENT1A = 0x60,
                   MIFARE_AUTHENT1B = 0x61;

        const byte DL_OK            = 0x00;
                   

        //for error                    
        const byte FRES_OK_LIGHT    = 0x04,
                   FRES_OK_SOUND    = 0x00,
                   FERR_LIGHT       = 0x02,
                   FERR_SOUND       = 0x00;

        const string
                     CONVERT_ERROR = "You may enter only whole decimal number !";

        
        private CheckBox HEX_BOX_CHECKED = new CheckBox();
                
        

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

        private byte[] WriteKeyAB(Panel pnlKey, CheckBox chkKey, string sKeyName)
        {
            byte bCounter = 0;
            byte[] baKey = new byte[6];
            foreach (Control cControl in pnlKey.Controls)
            {
                if (cControl.Name == sKeyName)
                {
                    if (!chkKey.Checked)
                        baKey[bCounter] = System.Convert.ToByte(cControl.Text);
                    else
                        baKey[bCounter] = System.Convert.ToByte(int.Parse(cControl.Text, System.Globalization.NumberStyles.HexNumber));
                    bCounter++;
                }
            }
            return baKey;
        }

        private void frmLinearFormatCard_Load(object sender, EventArgs e)
        {
             
            cboKeyIndex.SelectedItem = cboKeyIndex.Items[0];
            GL.CreatePKKey(21, 31, 4, 350, "txtPKKey", 6, false, pnlAuth);            
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
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn                 = true;
                DL_STATUS iFResult;        
                byte bBlockAccessBits         = 0;
                byte bSectorTrailerAccessBits = 0;
                byte bTrailerByte9            = 0;
                byte bSectorsFormatted        = 0;
                byte bKeyIndex                = 0;
                byte bAuthMode                = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                byte[] baKeyA                 = new byte[6];
                byte[] baKeyB                 = new byte[6];
            
                if (cboBlockAccessBits.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ACCESS BITS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboBlockAccessBits.Focus();
                    return;

                }
                if (cboSectorTrailerAccessBits.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR TRAILER ACCESS BITS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSectorTrailerAccessBits.Focus();
                    return;

                }
                if (txtSectorTrailerByte9.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR TRAILER BYTE 9 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSectorTrailerByte9.Focus();
                    return;
                }

                 bKeyIndex                = System.Convert.ToByte(cboKeyIndex.Text);                               
                 bBlockAccessBits         = System.Convert.ToByte(cboBlockAccessBits.Text);
                 bSectorTrailerAccessBits = System.Convert.ToByte (cboSectorTrailerAccessBits.Text) ;
                 bTrailerByte9            = System.Convert.ToByte(txtSectorTrailerByte9.Text);
               
                 baKeyA = WriteKeyAB(pnlKeyA, chkHexKeyA, "txtKeyA");
                 baKeyB = WriteKeyAB(pnlKeyB, chkHexKeyB, "txtKeyB");
                unsafe
                {
                    fixed (byte* PKEY_A = baKeyA, 
                                 PKEY_B = baKeyB)
                        iFResult = uFCoder.LinearFormatCard(PKEY_A, bBlockAccessBits, bSectorTrailerAccessBits, bTrailerByte9, PKEY_B,&bSectorsFormatted, 
                                                              bAuthMode, bKeyIndex);
                }
                if (iFResult == DL_OK)
                {
                    txtSectorsFormatted.Text = System.Convert.ToString(bSectorsFormatted);
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }
                else
                {
                    txtSectorsFormatted.Text = System.Convert.ToString(bSectorsFormatted);
                    uFCoder.ReaderUISignal(FERR_LIGHT, FERR_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                } 
            }
            catch (System.FormatException)
            {
                MessageBox.Show(CONVERT_ERROR, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GL.FunctionOn=false;
                 
            }        
            
        }

        private void btnFormatAKM1_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn                 = true;
                DL_STATUS iFResult;        
                byte bBlockAccessBits         = 0;
                byte bSectorTrailerAccessBits = 0;
                byte bTrailerByte9            = 0;
                byte bSectorsFormatted        = 0;                
                byte bAuthMode                = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                byte[] baKeyA                 = new byte[6];
                byte[] baKeyB                 = new byte[6];

                if (cboBlockAccessBitsAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ACCESS BITS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboBlockAccessBitsAKM1.Focus();
                    return;

                }
                if (cboSectorTrailerAccessBitsAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR TRAILER ACCESS BITS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSectorTrailerAccessBitsAKM1.Focus();
                    return;

                }
                if (txtSectorTrailerByte9AKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR TRAILER BYTE 9 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSectorTrailerByte9AKM1.Focus();
                    return;
                }
                
               
                 bBlockAccessBits         = System.Convert.ToByte(cboBlockAccessBitsAKM1.Text);
                 bSectorTrailerAccessBits = System.Convert.ToByte(cboSectorTrailerAccessBitsAKM1.Text);
                 bTrailerByte9            = System.Convert.ToByte(txtSectorTrailerByte9AKM1.Text);
                 bSectorsFormatted        = 0;

                 baKeyA = WriteKeyAB(pnlKeyA, chkHexKeyA, "txtKeyA");
                 baKeyB = WriteKeyAB(pnlKeyB, chkHexKeyB, "txtKeyB");
                unsafe
                {
                    fixed (byte* PKEY_A = baKeyA, 
                                 PKEY_B = baKeyB)
                    iFResult = uFCoder.LinearFormatCard_AKM1(PKEY_A, bBlockAccessBits, bSectorTrailerAccessBits, bTrailerByte9, PKEY_B, &bSectorsFormatted, bAuthMode);
                }
                if (iFResult == DL_OK)
                {
                    txtSectorsFormattedAKM1.Text = System.Convert.ToString(bSectorsFormatted);
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }
                else
                {
                    txtSectorsFormattedAKM1.Text = System.Convert.ToString(bSectorsFormatted);
                    uFCoder.ReaderUISignal(FERR_LIGHT, FERR_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                } 
            }
            catch (System.FormatException)
            {
                MessageBox.Show(CONVERT_ERROR, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GL.FunctionOn=false;
                 
            }        
        }

        private void btnFormatAKM2_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn                 = true;
                DL_STATUS iFResult;
                byte bBlockAccessBits         = 0;
                byte bSectorTrailerAccessBits = 0;
                byte bTrailerByte9            = 0;
                byte bSectorsFormatted        = 0;                
                byte bAuthMode                = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                byte[] baKeyA                 = new byte[6];
                byte[] baKeyB                 = new byte[6];

                if (cboBlockAccessBitsAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ACCESS BITS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboBlockAccessBitsAKM2.Focus();
                    return;

                }
                if (cboSectorTrailerAccessBitsAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR TRAILER ACCESS BITS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSectorTrailerAccessBitsAKM2.Focus();
                    return;

                }
                if (txtSectorTrailerByte9AKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR TRAILER BYTE 9 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSectorTrailerByte9AKM2.Focus();
                    return;
                }
               
                bBlockAccessBits         = System.Convert.ToByte(cboBlockAccessBitsAKM2.Text);
                bSectorTrailerAccessBits = System.Convert.ToByte(cboSectorTrailerAccessBitsAKM2.Text);
                bTrailerByte9            = System.Convert.ToByte(txtSectorTrailerByte9AKM2.Text);
                bSectorsFormatted        = 0;

                baKeyA = WriteKeyAB(pnlKeyA, chkHexKeyA, "txtKeyA");
                baKeyB = WriteKeyAB(pnlKeyB, chkHexKeyB, "txtKeyB");
                unsafe
                {
                    fixed (byte* PKEY_A = baKeyA, 
                                 PKEY_B = baKeyB)
                    iFResult = uFCoder.LinearFormatCard_AKM2(PKEY_A, bBlockAccessBits, bSectorTrailerAccessBits, bTrailerByte9, PKEY_B, &bSectorsFormatted, bAuthMode);
                }
                if (iFResult == DL_OK)
                {
                    txtSectorsFormattedAKM2.Text = System.Convert.ToString(bSectorsFormatted);
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }
                else
                {
                    txtSectorsFormattedAKM2.Text = System.Convert.ToString(bSectorsFormatted);
                    uFCoder.ReaderUISignal(FERR_LIGHT, FERR_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                } 
            }
            catch (System.FormatException)
            {
                MessageBox.Show(CONVERT_ERROR, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GL.FunctionOn=false;
                 
            }          
        }

        private void btnFormatPK_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn                 = true;
                DL_STATUS iFResult;
                byte bBlockAccessBits         = 0;
                byte bSectorTrailerAccessBits = 0;
                byte bTrailerByte9            = 0;
                byte bSectorsFormatted        = 0;
                byte[] baPKKey                = new byte[6];
                byte bCounter                 = 0;
                byte bAuthMode                = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                byte[] baKeyA                 = new byte[6];
                byte[] baKeyB                 = new byte[6];

                if (cboBlockAccessBitsPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ACCESS BITS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboBlockAccessBitsPK.Focus();
                    return;

                }
                if (cboSectorTrailerAccessBitsPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR TRAILER ACCESS BITS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSectorTrailerAccessBitsPK.Focus();
                    return;

                }
                if (txtSectorTrailerByte9PK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR TRAILER BYTE 9 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSectorTrailerByte9PK.Focus();
                    return;
                }
                
                foreach (Control ctrl in pnlAuth.Controls)
                {
                    if (ctrl.Name == "txtPKKey")
                    {
                        baPKKey[bCounter] = System.Convert.ToByte(ctrl.Text);
                        bCounter++;
                    }
                }
                
                bBlockAccessBits         = System.Convert.ToByte(cboBlockAccessBitsPK.Text);
                bSectorTrailerAccessBits = System.Convert.ToByte(cboSectorTrailerAccessBitsPK.Text);
                bTrailerByte9            = System.Convert.ToByte(txtSectorTrailerByte9PK.Text);
                bSectorsFormatted        = 0;

                baKeyA = WriteKeyAB(pnlKeyA, chkHexKeyA, "txtKeyA");
                baKeyB = WriteKeyAB(pnlKeyB, chkHexKeyB, "txtKeyB");
                
                unsafe
                {
                    fixed (byte* PKEY_A  = baKeyA, 
                                 PKEY_B  = baKeyB,
                                 PPKEY   = baPKKey)
                    iFResult = uFCoder.LinearFormatCard_PK(PKEY_A, bBlockAccessBits, bSectorTrailerAccessBits, bTrailerByte9, PKEY_B, &bSectorsFormatted,
                                                             bAuthMode,PPKEY);
                }
                if (iFResult == DL_OK)
                {
                    txtSectorsFormattedPK.Text = System.Convert.ToString(bSectorsFormatted);
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }
                else
                {
                    txtSectorsFormattedPK.Text = System.Convert.ToString(bSectorsFormatted);
                    uFCoder.ReaderUISignal(FERR_LIGHT, FERR_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                } 
            }
            catch (System.FormatException)
            {
                MessageBox.Show(CONVERT_ERROR, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GL.FunctionOn=false;
                 
            }          
        }

        private void chkHexKeyA_CheckedChanged(object sender, EventArgs e)
        {

        }

        
    }
}

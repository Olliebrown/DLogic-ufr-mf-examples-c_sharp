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
    public partial class frmSectorTrailerWrite : Form
    {
        private
              Globals GL = new Globals();
        public frmSectorTrailerWrite()
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
        
        const string CONVERT_ERROR = "You may enter only whole decimal number !";
        
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
             
            cboKeyIndex.SelectedItem = cboKeyIndex.Items[0];
            GL.CreatePKKey(21, 31, 4, 350, "txtPKKey", 6, false, pnlAuth);            
            CreateKey(21, 31, 29, 30, "txtKeyA", 6, false, pnlKeyA);
            CreateKey(21, 31, 29, 32, "txtKeyB", 6, false, pnlKeyB);
             
        }

       

        private void chkHexKeyA_Click(object sender, EventArgs e)
        {
            HexKey_clicked(chkHexKeyA, "txtKeyA", pnlKeyA);
        }

        private void chkHexKeyB_Click(object sender, EventArgs e)
        {
            HexKey_clicked(chkHexKeyB, "txtKeyB", pnlKeyB);
        }

        private byte[] WriteKeyAB(Panel pnlKey,CheckBox chkKey,string sKeyName)
        {
            byte bCounter = 0;
            byte [] baKey=new byte[6];
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



        private void btnSTWWrite_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn                 = true;
                DL_STATUS iFResult;
                byte bBlockAccessBits0        = 0;
                byte bBlockAccessBits1        = 0;
                byte bBlockAccessBits2        = 0;
                byte bSectorTrailerAccessBits = 0;
                byte bAddressingMode          = 0;
                byte bBlockOrSector           = 0;
                byte bTrailerAccessBits9      = 0;                                                               
                byte bKeyIndex                = 0;                
                byte bAuthMode                = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                byte[] baKeyA                 = new byte[6];
                byte[] baKeyB                 = new byte[6];
                      
                if (cboSTWAddressingMode.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the ADDRESSING MODE !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAddressingMode.Focus();
                    return;
                }
                if (txtSTWBlockOrSectorAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK OR SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSTWBlockOrSectorAddress.Focus();
                    return;
                }
                if (cboSTWAccessBits0.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ACCESS BITS 0 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAccessBits0.Focus();
                    return;
                }
                if (cboSTWAccessBits1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ACCESS BITS 1 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAccessBits1.Focus();
                    return;
                }
                if (cboSTWAccessBits2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ACCESS BITS 2 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAccessBits2.Focus();
                    return;
                }
                if (cboSTWTrailerAccessBits.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the TRAILER ACCESS BITS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWTrailerAccessBits.Focus();
                    return;
                }
                
                if (txtSTWTrailerByte9.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the TRAILER BYTE 9 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSTWTrailerByte9.Focus();
                    return;
                }

                bAddressingMode          = System.Convert.ToByte(cboSTWAddressingMode.Text);
                bBlockAccessBits0        = System.Convert.ToByte(cboSTWAccessBits0.Text);
                bBlockAccessBits1        = System.Convert.ToByte(cboSTWAccessBits1.Text);
                bBlockAccessBits2        = System.Convert.ToByte(cboSTWAccessBits2.Text);
                bBlockOrSector           = System.Convert.ToByte(txtSTWBlockOrSectorAddress.Text);
                bSectorTrailerAccessBits = System.Convert.ToByte(cboSTWTrailerAccessBits.Text);                                
                bTrailerAccessBits9      = System.Convert.ToByte(txtSTWTrailerByte9.Text);
                bKeyIndex                = System.Convert.ToByte(cboKeyIndex.Text);
                
                baKeyA = WriteKeyAB(pnlKeyA,chkHexKeyA,"txtKeyA");
                baKeyB = WriteKeyAB(pnlKeyB,chkHexKeyB,"txtKeyB");                             
                unsafe
                {
                    fixed (byte* PKEY_A = baKeyA, 
                                 PKEY_B = baKeyB)
                    iFResult = uFCoder1x.SectorTrailerWrite(bAddressingMode, bBlockOrSector, PKEY_A, bBlockAccessBits0, bBlockAccessBits1, bBlockAccessBits2, 
                                                            bSectorTrailerAccessBits, bTrailerAccessBits9, PKEY_B, bAuthMode, bKeyIndex);
                }
                if (iFResult == DL_OK)
                {                    
                    uFCoder1x.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }
                else
                {                    
                    uFCoder1x.ReaderUISignal(FERR_LIGHT, FERR_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                } 
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(CONVERT_ERROR, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GL.FunctionOn=false;
                 
            }          
        }

        private void btnSTWWriteAKM1_Click(object sender, EventArgs e)
        {
            
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn                 = true;
                DL_STATUS iFResult;
                byte bBlockAccessBits0        = 0;
                byte bBlockAccessBits1        = 0;
                byte bBlockAccessBits2        = 0;
                byte bSectorTrailerAccessBits = 0;
                byte bAddressingMode          = 0;
                byte bBlockOrSector           = 0;
                byte bTrailerAccessBits9      = 0;                                                                                               
                byte bAuthMode                = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                byte[] baKeyA                 = new byte[6];
                byte[] baKeyB                 = new byte[6];

                if (cboSTWAddressingModeAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the ADDRESSING MODE !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAddressingModeAKM1.Focus();
                    return;
                }
                if (txtSTWBlockOrSectorAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK OR SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSTWBlockOrSectorAddressAKM1.Focus();
                    return;
                }
                if (cboSTWAccessBits0AKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ACCESS BITS 0 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAccessBits0AKM1.Focus();
                    return;
                }
                if (cboSTWAccessBits1AKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ACCESS BITS 1 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAccessBits1AKM1.Focus();
                    return;
                }
                if (cboSTWAccessBits2AKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ACCESS BITS 2 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAccessBits2AKM1.Focus();
                    return;
                }
                if (cboSTWTrailerAccessBitsAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the TRAILER ACCESS BITS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWTrailerAccessBitsAKM1.Focus();
                    return;
                }
               
                if (txtSTWTrailerByte9AKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the TRAILER BYTE 9 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSTWTrailerByte9AKM1.Focus();
                    return;
                }
                bAddressingMode          = System.Convert.ToByte(cboSTWAddressingModeAKM1.Text);
                bBlockOrSector           = System.Convert.ToByte(txtSTWBlockOrSectorAddressAKM1.Text);
                bBlockAccessBits0        = System.Convert.ToByte(cboSTWAccessBits0AKM1.Text);
                bBlockAccessBits1        = System.Convert.ToByte(cboSTWAccessBits1AKM1.Text);
                bBlockAccessBits2        = System.Convert.ToByte(cboSTWAccessBits2AKM1.Text);
                bSectorTrailerAccessBits = System.Convert.ToByte(cboSTWTrailerAccessBitsAKM1.Text);                                
                bTrailerAccessBits9      = System.Convert.ToByte(txtSTWTrailerByte9AKM1.Text);
               
                baKeyA  = WriteKeyAB(pnlKeyA,chkHexKeyA,"txtKeyA");
                baKeyB  = WriteKeyAB(pnlKeyB,chkHexKeyB,"txtKeyB");
                               
                unsafe
                {
                    fixed (byte* PKEY_A = baKeyA,
                                 PKEY_B = baKeyB)
                    iFResult = uFCoder1x.SectorTrailerWrite_AKM1(bAddressingMode, bBlockOrSector, PKEY_A, bBlockAccessBits0, bBlockAccessBits1, bBlockAccessBits2,
                                                                 bSectorTrailerAccessBits, bTrailerAccessBits9, PKEY_B, bAuthMode);
                }
                if (iFResult == DL_OK)
                {
                    uFCoder1x.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }
                else
                {
                    uFCoder1x.ReaderUISignal(FERR_LIGHT, FERR_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                } 
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(CONVERT_ERROR, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GL.FunctionOn=false;
                 
            }          

        }

        private void btnSTWWriteAKM2_Click(object sender, EventArgs e)
        {
            
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn                 = true;
                DL_STATUS iFResult;
                byte bBlockAccessBits0        = 0;
                byte bBlockAccessBits1        = 0;
                byte bBlockAccessBits2        = 0;
                byte bSectorTrailerAccessBits = 0;
                byte bAddressingMode          = 0;
                byte bBlockOrSector           = 0;
                byte bTrailerAccessBits9      = 0;                                                                                               
                byte bAuthMode                = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                byte[] baKeyA                 = new byte[6];
                byte[] baKeyB                 = new byte[6];

                if (cboSTWAddressingModeAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the ADDRESSING MODE !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAddressingModeAKM2.Focus();
                    return;
                }
                if (txtSTWBlockOrSectorAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK OR SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSTWBlockOrSectorAddressAKM2.Focus();
                    return;
                }
                if (cboSTWAccessBits0AKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ACCESS BITS 0 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAccessBits0AKM2.Focus();
                    return;
                }
                if (cboSTWAccessBits1AKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ACCESS BITS 1 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAccessBits1AKM2.Focus();
                    return;
                }
                if (cboSTWAccessBits2AKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ACCESS BITS 2 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAccessBits2AKM2.Focus();
                    return;
                }
                if (cboSTWTrailerAccessBitsAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the TRAILER ACCESS BITS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWTrailerAccessBitsAKM2.Focus();
                    return;
                }
                
                if (txtSTWTrailerByte9AKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the TRAILER BYTE 9 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSTWTrailerByte9AKM2.Focus();
                    return;
                }

                bAddressingMode          = System.Convert.ToByte(cboSTWAddressingModeAKM2.Text);
                bBlockOrSector           = System.Convert.ToByte(txtSTWBlockOrSectorAddressAKM2.Text);
                bBlockAccessBits0        = System.Convert.ToByte(cboSTWAccessBits0AKM2.Text);
                bBlockAccessBits1        = System.Convert.ToByte(cboSTWAccessBits1AKM2.Text);
                bBlockAccessBits2        = System.Convert.ToByte(cboSTWAccessBits2AKM2.Text);
                bSectorTrailerAccessBits = System.Convert.ToByte(cboSTWTrailerAccessBitsAKM2.Text);                                
                bTrailerAccessBits9      = System.Convert.ToByte(txtSTWTrailerByte9AKM2.Text);

                baKeyA = WriteKeyAB(pnlKeyA, chkHexKeyA, "txtKeyA");
                baKeyB = WriteKeyAB(pnlKeyB, chkHexKeyB, "txtKeyB");
                unsafe
                {
                    fixed (byte* PKEY_A = baKeyA, 
                                 PKEY_B = baKeyB)
                    iFResult = uFCoder1x.SectorTrailerWrite_AKM2(bAddressingMode, bBlockOrSector, PKEY_A, bBlockAccessBits0, bBlockAccessBits1, bBlockAccessBits2,
                                                                 bSectorTrailerAccessBits, bTrailerAccessBits9, PKEY_B, bAuthMode);
                }
                if (iFResult == DL_OK)
                {
                    uFCoder1x.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }
                else
                {
                    uFCoder1x.ReaderUISignal(FERR_LIGHT, FERR_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                } 
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(CONVERT_ERROR, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GL.FunctionOn=false;
                 
            }          
        }

        private void btnSTWWritePK_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn                 = true;
                DL_STATUS iFResult;
                byte bBlockAccessBits0        = 0;
                byte bBlockAccessBits1        = 0;
                byte bBlockAccessBits2        = 0;
                byte bSectorTrailerAccessBits = 0;
                byte bAddressingMode          = 0;
                byte bBlockOrSector           = 0;
                byte bTrailerAccessBits9      = 0;                                                                                               
                byte bAuthMode                = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                byte bCounter                 = 0;
                byte[] baKeyA                 = new byte[6];
                byte[] baKeyB                 = new byte[6];
                byte[] baKeyPK                = new byte[6];
                  
                if (cboSTWAddressingModePK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the ADDRESSING MODE !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAddressingModePK.Focus();
                    return;
                }
                if (txtSTWBlockOrSectorAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK OR SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSTWBlockOrSectorAddressPK.Focus();
                    return;
                }
                if (cboSTWAccessBits0PK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ACCESS BITS 0 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAccessBits0PK.Focus();
                    return;
                }
                if (cboSTWAccessBits1PK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ACCESS BITS 1 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAccessBits1PK.Focus();
                    return;
                }
                if (cboSTWAccessBits2PK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ACCESS BITS 2 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWAccessBits2PK.Focus();
                    return;
                }
                if (cboSTWTrailerAccessBitsPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the TRAILER ACCESS BITS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSTWTrailerAccessBitsPK.Focus();
                    return;
                }
                
                if (txtSTWTrailerByte9PK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the TRAILER BYTE 9 !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSTWTrailerByte9PK.Focus();
                    return;
                }
                bAddressingMode          = System.Convert.ToByte(cboSTWAddressingModePK.Text);
                bBlockOrSector           = System.Convert.ToByte(txtSTWBlockOrSectorAddressPK.Text);
                bBlockAccessBits0        = System.Convert.ToByte(cboSTWAccessBits0PK.Text);
                bBlockAccessBits1        = System.Convert.ToByte(cboSTWAccessBits1PK.Text);
                bBlockAccessBits2        = System.Convert.ToByte(cboSTWAccessBits2PK.Text);
                bSectorTrailerAccessBits = System.Convert.ToByte(cboSTWTrailerAccessBitsPK.Text);                                
                bTrailerAccessBits9      = System.Convert.ToByte(txtSTWTrailerByte9PK.Text);

                baKeyA = WriteKeyAB(pnlKeyA, chkHexKeyA, "txtKeyA");
                baKeyB = WriteKeyAB(pnlKeyB, chkHexKeyB, "txtKeyB");
                                
                foreach (Control cControl in pnlAuth.Controls)
                {
                    if (cControl.Name == "txtPKKey")
                    {
                        baKeyPK[bCounter] = System.Convert.ToByte(cControl.Text);
                        bCounter++;
                    }
                }

                baKeyA = WriteKeyAB(pnlKeyA, chkHexKeyA, "txtKeyA");
                baKeyB = WriteKeyAB(pnlKeyB, chkHexKeyB, "txtKeyB");
                unsafe
                {
                    fixed (byte* PKEY_A  = baKeyA, 
                                 PKEY_B  = baKeyB,
                                 PKEY_PK = baKeyPK)
                    iFResult = uFCoder1x.SectorTrailerWrite_PK(bAddressingMode, bBlockOrSector, PKEY_A, bBlockAccessBits0, bBlockAccessBits1, bBlockAccessBits2,
                                                               bSectorTrailerAccessBits, bTrailerAccessBits9, PKEY_B, bAuthMode,PKEY_PK);
                }
                if (iFResult == DL_OK)
                {
                    uFCoder1x.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }
                else
                {
                    uFCoder1x.ReaderUISignal(FERR_LIGHT, FERR_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                } 
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(CONVERT_ERROR, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GL.FunctionOn=false;
                 
            }          

        }

        

      
    }
}

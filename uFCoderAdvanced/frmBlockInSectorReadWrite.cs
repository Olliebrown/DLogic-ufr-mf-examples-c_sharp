using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using uFrAdvance;
namespace uFrAdvance
{
    using DL_STATUS = System.UInt32;
    public partial class frmBlockInSectorReadWrite : Form 
    {
        private
            Globals GL = new Globals();
        public frmBlockInSectorReadWrite()
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

        // sectors and blocks
        const byte MAX_BLOCK        = 0x0F;

        const string
                    CONVERT_ERROR = "You may enter only whole decimal number !",
                    APPROPRIATE_FORMAT = "You must enter the appropriate format !";

        private void frmBlockInSectorReadWrite_Load(object sender, EventArgs e)
        {
            
            cboKeyIndex.SelectedItem = cboKeyIndex.Items[0];
            GL.CreatePKKey(21, 31, 4, 350, "txtPKKey", 6, false, pnlAuth);
            
        }

        private String ConvertToHex(byte[] baBlockRead)
        {
            StringBuilder sb = new StringBuilder();
            UTF8Encoding enc = new UTF8Encoding();
            string sString = null, sBuffer = null;

            foreach (byte bCount in baBlockRead)
            {
                sBuffer = bCount.ToString("X2");
                sb.Append(sBuffer.PadLeft(2, "0"[0]));
                sString = sb.ToString();
            }
            return sString;
        }

        private byte[] HexConvert(String sTextBoxValue, byte bMaxBytes)
        {
            byte bCounter = 0,
                 bBr = 0;
            byte[] bBlockData = new byte[bMaxBytes];

            sTextBoxValue = Regex.Replace(sTextBoxValue, @"\s", "");

            try
            {
                while (bCounter < bMaxBytes*2)
                {
                    bBlockData[bBr] = Convert.ToByte(sTextBoxValue.Substring(bCounter, 2), 16);
                    bBr++;
                    bCounter += 2;
                }
            }
            catch (System.IndexOutOfRangeException ex)
            {

            }
            return bBlockData;
        }

        private byte MaxByteBlock(byte bCardType)
        {
            byte bMaxByte = 0;

            if (bCardType == (byte)uFrAdvance.Globals.DLCARDTYPE.DL_NTAG_203 ||
                bCardType == (byte)uFrAdvance.Globals.DLCARDTYPE.DL_MIFARE_ULTRALIGHT ||
                bCardType == (byte)uFrAdvance.Globals.DLCARDTYPE.DL_MIFARE_ULTRALIGHT_C)
                bMaxByte = 4;
            else
                bMaxByte = 16;
            return bMaxByte;
        }

        private void btnBISReadData_Click(object sender, EventArgs e)
        {
            
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn = true;
              DL_STATUS iFResult;
              byte bSectorAddress      = 0;
              byte bKeyIndex           = 0;              
              byte bBlockAddress       = 0;              
              byte[] baReadData        = new byte[MAX_BLOCK];
              byte bAuthMode           = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;                            
            
                if (txtBISRSectorAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISRSectorAddress.Focus();
                    return;
                }
                if (txtBISRBlockAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISRBlockAddress.Focus();
                    return;
                }

                bSectorAddress  = System.Convert.ToByte(txtBISRSectorAddress.Text);
                bBlockAddress   = System.Convert.ToByte(txtBISRBlockAddress.Text);
                bKeyIndex       = System.Convert.ToByte(cboKeyIndex.Text);
                
                txtBISReadData.Text = "";
                
                unsafe
                {
                    fixed (byte* PData = baReadData)
                    {
                        iFResult = uFCoder.BlockInSectorRead(PData, bSectorAddress, bBlockAddress, bAuthMode, bKeyIndex);                        
                    }
                }
                if (iFResult == DL_OK)
                {
                    if (chkBiSRHex.Checked)
                    {
                        txtBISReadData.Text = ConvertToHex(baReadData);
                    }
                    else
                    {
                        txtBISReadData.Text = Encoding.ASCII.GetString(baReadData);
                    }
                   
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);                   
                    GL.SetStatusBar(iFResult, stbFunctionError);                                                            
                }
                else
                {
                    uFCoder.ReaderUISignal(FERR_LIGHT, FERR_SOUND);                    
                    GL.SetStatusBar(iFResult, stbFunctionError);                     
                }

            }
            catch (System.FormatException)
            {
                MessageBox.Show(CONVERT_ERROR, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Exception exc)
            {
                MessageBox.Show(APPROPRIATE_FORMAT, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GL.FunctionOn=false;               
            }          

        }

        private void btnBISReadDataAKM1_Click(object sender, EventArgs e)
        {
            
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn = true;
              DL_STATUS iFResult;
              byte bSectorAddress      = 0;
              byte bBlockAddress       = 0;              
              byte[] baReadData        = new byte[MAX_BLOCK];
              byte bAuthMode           = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B; 
           
                if (txtBISRSectorAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISRSectorAddressAKM1.Focus();
                    return;
                }
                if (txtBISRBlockAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISRBlockAddressAKM1.Focus();
                    return;
                }
                bSectorAddress  = System.Convert.ToByte(txtBISRSectorAddressAKM1.Text);
                bBlockAddress   = System.Convert.ToByte(txtBISRBlockAddressAKM1.Text);
                txtBISReadDataAKM1.Text = "";
                
                unsafe
                {
                    fixed (byte* PData = baReadData)
                    {
                        iFResult = uFCoder.BlockInSectorRead_AKM1(PData, bSectorAddress, bBlockAddress, bAuthMode);
                    }
                }
                if (iFResult == DL_OK)
                {
                    if (chkBiSRAKM1Hex.Checked)
                    {
                        txtBISReadDataAKM1.Text = ConvertToHex(baReadData);
                    }
                    else
                    {
                        txtBISReadDataAKM1.Text = Encoding.ASCII.GetString(baReadData);
                    }
                   
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);                   
                    GL.SetStatusBar(iFResult, stbFunctionError);                                                            
                }
                else
                {
                    uFCoder.ReaderUISignal(FERR_LIGHT, FERR_SOUND);                    
                    GL.SetStatusBar(iFResult, stbFunctionError);                     
                }

            }
            catch (System.FormatException)
            {
                MessageBox.Show(CONVERT_ERROR, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Exception exc)
            {
                MessageBox.Show(APPROPRIATE_FORMAT, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GL.FunctionOn=false;               
            }       

        }

        private void btnBISReadDataAKM2_Click(object sender, EventArgs e)
        {
            
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
              GL.FunctionOn = true;
              DL_STATUS iFResult;
              byte bSectorAddress      = 0;
              byte bBlockAddress       = 0;              
              byte[] baReadData        = new byte[MAX_BLOCK];
              byte bAuthMode           = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
           
                if (txtBISRSectorAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISRSectorAddressAKM2.Focus();
                    return;
                }
                if (txtBISRBlockAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISRBlockAddressAKM2.Focus();
                    return;
                }

                bSectorAddress   = System.Convert.ToByte(txtBISRSectorAddressAKM2.Text);
                bBlockAddress    = System.Convert.ToByte(txtBISRBlockAddressAKM2.Text);
                txtBISReadDataAKM2.Text = "";
                
                unsafe
                {
                    fixed (byte* PData = baReadData)
                    {
                        iFResult = uFCoder.BlockInSectorRead_AKM2(PData, bSectorAddress, bBlockAddress, bAuthMode);
                    }
                }
                if (iFResult == DL_OK)
                {
                    if (chkBiSRAKM2Hex.Checked)
                    {
                        txtBISReadDataAKM2.Text = ConvertToHex(baReadData);
                    }
                    else
                    {
                        txtBISReadDataAKM2.Text = Encoding.ASCII.GetString(baReadData);
                    }
                    
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }
                else
                {
                    uFCoder.ReaderUISignal(FERR_LIGHT, FERR_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }

            }
            catch (System.FormatException)
            {
                MessageBox.Show(CONVERT_ERROR, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Exception exc)
            {
                MessageBox.Show(APPROPRIATE_FORMAT, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GL.FunctionOn=false;                   
            }    

        }

        private void btnBISReadDataPK_Click(object sender, EventArgs e)
        {            
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
              GL.FunctionOn = true;
              DL_STATUS iFResult;
              byte bSectorAddress      = 0;                            
              byte bBlockAddress       = 0;              
              byte[] baReadData        = new byte[MAX_BLOCK];
              byte[] baPKKey           = new byte[6];
              byte bAuthMode           = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                                  
                if (txtBISRSectorAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISRSectorAddressPK.Focus();
                    return;
                }
                if (txtBISRBlockAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISRBlockAddressPK.Focus();
                    return;
                }

                bSectorAddress   = System.Convert.ToByte(txtBISRSectorAddressPK.Text);
                bBlockAddress   = System.Convert.ToByte(txtBISRBlockAddressPK.Text);
                txtBISReadDataPK.Text = "";
               
                byte bCount = 0;
                foreach (Control cCont in pnlAuth.Controls)
                {
                    if (cCont.Name == "txtPKKey")
                    {
                        baPKKey[bCount] =System.Convert.ToByte(cCont.Text);
                        bCount++;
                    }
                }
                unsafe
                {
                    fixed (byte* PData = baReadData,
                                 PPKEY = baPKKey)
                    {
                        iFResult = uFCoder.BlockInSectorRead_PK(PData, bSectorAddress, bBlockAddress, bAuthMode,PPKEY);
                    }
                }
                if (iFResult == DL_OK)
                {
                    if (chkBiSRPKHex.Checked)
                    {
                        txtBISReadDataPK.Text = ConvertToHex(baReadData);
                    }
                    else
                    {
                        txtBISReadDataPK.Text = Encoding.ASCII.GetString(baReadData);
                    }
                    
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }
                else
                {
                    uFCoder.ReaderUISignal(FERR_LIGHT, FERR_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }

            }
            catch (System.FormatException)
            {
                MessageBox.Show(CONVERT_ERROR, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Exception exc)
            {
                MessageBox.Show(APPROPRIATE_FORMAT, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GL.FunctionOn=false;             
            }      

        }

        private void btnBISWrite_Click(object sender, EventArgs e)
        {
           
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn            = true;
                DL_STATUS iFResult;
                byte bKeyIndex           = 0;
                byte bSectorAddress      = 0;
                byte bBlockAddress       = 0;
                byte[] baWriteData       = new byte[MAX_BLOCK];                
                byte bAuthMode           = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;

                if (txtBISWWriteData.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISWWriteData.Focus();
                    return;
                }
                if (txtBISWSectorAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISWSectorAddress.Focus();
                    return;
                }
                if (txtBISWBlockAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISWBlockAddress.Focus();
                    return;
                }

                bKeyIndex      = System.Convert.ToByte(cboKeyIndex.Text);
                bSectorAddress = System.Convert.ToByte(txtBISWSectorAddress.Text);
                bBlockAddress  = System.Convert.ToByte(txtBISWBlockAddress.Text);
                                
                byte bMaxByteBlock = MaxByteBlock(GL.TypeOfCard);

                if (chkBiSWHex.Checked)
                {
                    if ((txtBISWWriteData.TextLength / 2) < bMaxByteBlock || (txtBISWWriteData.TextLength / 2) > bMaxByteBlock)
                    {
                        MessageBox.Show("You must enter " + bMaxByteBlock.ToString() + " bytes !", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    baWriteData = HexConvert(txtBISWWriteData.Text.Trim(), bMaxByteBlock);
                }
                else
                {
                    baWriteData = System.Text.Encoding.ASCII.GetBytes(txtBISWWriteData.Text);
                }

                unsafe
                {
                    fixed (byte* PData = baWriteData)
                    {
                        iFResult = uFCoder.BlockInSectorWrite(PData, bSectorAddress, bBlockAddress, bAuthMode, bKeyIndex);
                    }
                }
                if (iFResult == DL_OK)
                {                   
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }
                else
                {
                    uFCoder.ReaderUISignal(FERR_LIGHT, FERR_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }

            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(CONVERT_ERROR, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Exception exc)
            {
                MessageBox.Show(APPROPRIATE_FORMAT, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GL.FunctionOn=false;               
            }      

        }

        private void btnBISWriteAKM1_Click(object sender, EventArgs e)
        {
          
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn            = true;
                DL_STATUS iFResult;                
                byte bSectorAddress      = 0;
                byte bBlockAddress       = 0;
                byte[] baWriteData       = new byte[MAX_BLOCK];                
                byte bAuthMode           = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;

                if (txtBISWWriteDataAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISWWriteDataAKM1.Focus();
                    return;
                }
                if (txtBISWSectorAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISWSectorAddressAKM1.Focus();
                    return;
                }
                if (txtBISWBlockAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISWBlockAddressAKM1.Focus();
                    return;
                }

                bSectorAddress  = System.Convert.ToByte(txtBISWSectorAddressAKM1.Text);
                bBlockAddress  = System.Convert.ToByte(txtBISWBlockAddressAKM1.Text);
                
                byte bMaxByteBlock = MaxByteBlock(GL.TypeOfCard);

                if (chkBiSWAKM1Hex.Checked)
                {
                    if ((txtBISWWriteDataAKM1.TextLength / 2) < bMaxByteBlock || (txtBISWWriteDataAKM1.TextLength / 2) > bMaxByteBlock)
                    {
                        MessageBox.Show("You must enter " + bMaxByteBlock.ToString() + " bytes !", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    baWriteData = HexConvert(txtBISWWriteDataAKM1.Text.Trim(), bMaxByteBlock);
                }
                else
                {
                    baWriteData = System.Text.Encoding.ASCII.GetBytes(txtBISWWriteDataAKM1.Text);
                }
                unsafe
                {
                    fixed (byte* PData = baWriteData)
                    {
                        iFResult = uFCoder.BlockInSectorWrite_AKM1(PData, bSectorAddress, bBlockAddress, bAuthMode);
                    }
                }
                if (iFResult == DL_OK)
                {
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }
                else
                {
                    uFCoder.ReaderUISignal(FERR_LIGHT, FERR_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }

            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(CONVERT_ERROR, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Exception exc)
            {
                MessageBox.Show(APPROPRIATE_FORMAT, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GL.FunctionOn=false;               
            }      

        }

        private void btnBISWriteAKM2_Click(object sender, EventArgs e)
        {            
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn            = true;
                DL_STATUS iFResult;
                byte bSectorAddress      = 0;
                byte bBlockAddress       = 0;
                byte[] baWriteData       = new byte[MAX_BLOCK];
                byte bAuthMode           = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;

                if (txtBISWWriteDataAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISWWriteDataAKM2.Focus();
                    return;
                }
                if (txtBISWSectorAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISWSectorAddressAKM2.Focus();
                    return;
                }
                if (txtBISWBlockAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISWBlockAddressAKM2.Focus();
                    return;
                }

                bSectorAddress = System.Convert.ToByte(txtBISWSectorAddressAKM2.Text);
                bBlockAddress  = System.Convert.ToByte(txtBISWBlockAddressAKM2.Text);
                
                byte bMaxByteBlock = MaxByteBlock(GL.TypeOfCard);

                if (chkBiSWAKM2Hex.Checked)
                {
                    if ((txtBISWWriteDataAKM2.TextLength / 2) < bMaxByteBlock || (txtBISWWriteDataAKM2.TextLength / 2) > bMaxByteBlock)
                    {
                        MessageBox.Show("You must enter " + bMaxByteBlock.ToString() + " bytes !", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    baWriteData = HexConvert(txtBISWWriteDataAKM2.Text.Trim(), bMaxByteBlock);
                }
                else
                {
                    baWriteData = System.Text.Encoding.ASCII.GetBytes(txtBISWWriteDataAKM2.Text);
                }
                unsafe
                {
                    fixed (byte* PData = baWriteData)
                    {
                        iFResult = uFCoder.BlockInSectorWrite_AKM2(PData, bSectorAddress, bBlockAddress, bAuthMode);
                    }
                }
                if (iFResult == DL_OK)
                {
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }
                else
                {
                    uFCoder.ReaderUISignal(FERR_LIGHT, FERR_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }

            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(CONVERT_ERROR, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Exception exc)
            {
                MessageBox.Show(APPROPRIATE_FORMAT, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GL.FunctionOn=false;           
            }      

        }

        private void btnBISWritePK_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn            = true;
                DL_STATUS iFResult;
                byte bSectorAddress      = 0;
                byte bBlockAddress       = 0;;
                byte[] baWriteData       = new byte[MAX_BLOCK];
                byte[] baPKKey           = new byte[6];
                byte bAuthMode           = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;

                if (txtBISWWriteDataPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISWWriteDataPK.Focus();
                    return;
                }
                if (txtBISWSectorAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISWSectorAddressPK.Focus();
                    return;
                }
                if (txtBISWBlockAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISWBlockAddressPK.Focus();
                    return;
                }
                bSectorAddress = System.Convert.ToByte(txtBISWSectorAddressPK.Text);
                bBlockAddress  = System.Convert.ToByte(txtBISWBlockAddressPK.Text);               
                
                byte bMaxByteBlock = MaxByteBlock(GL.TypeOfCard);

                if (chkBiSWPKHex.Checked)
                {
                    if ((txtBISWWriteDataPK.TextLength / 2) < bMaxByteBlock || (txtBISWWriteDataPK.TextLength / 2) > bMaxByteBlock)
                    {
                        MessageBox.Show("You must enter " + bMaxByteBlock.ToString() + " bytes !", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    baWriteData = HexConvert(txtBISWWriteDataPK.Text.Trim(), bMaxByteBlock);
                }
                else
                {
                    baWriteData = System.Text.Encoding.ASCII.GetBytes(txtBISWWriteDataPK.Text);
                }

                byte bCount = 0;
                foreach (Control cControl in pnlAuth.Controls)
                {
                    if (cControl.Name == "txtPKKey")
                    {
                        baPKKey[bCount] = System.Convert.ToByte(cControl.Text);
                        bCount++;
                    }
                }
                unsafe
                {
                    fixed (byte* PData = baWriteData,
                                 PKEY  = baPKKey)
                    {
                        iFResult = uFCoder.BlockInSectorWrite_PK(PData, bSectorAddress, bBlockAddress, bAuthMode,PKEY);
                    }
                }
                if (iFResult == DL_OK)
                {
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }
                else
                {
                    uFCoder.ReaderUISignal(FERR_LIGHT, FERR_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }

            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(CONVERT_ERROR, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Exception exc)
            {
                MessageBox.Show(APPROPRIATE_FORMAT, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GL.FunctionOn=false;               
            }        

        }
                  
    }

}

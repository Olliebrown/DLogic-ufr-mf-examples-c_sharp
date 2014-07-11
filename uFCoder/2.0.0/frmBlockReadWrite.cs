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
    public partial class frmBlockReadWrite : Form
    {

        private
              Globals GL = new Globals();

        public frmBlockReadWrite()
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
                    CONVERT_ERROR      = "You may enter only whole decimal number !",
                    APPROPRIATE_FORMAT = "You must enter the appropriate format !";

        private byte MaxByteBlock(byte bCardType)
        {
            byte bMaxByte=0;

            if (bCardType == (byte)uFrAdvance.Globals.DLCARDTYPE.DL_NTAG_203 ||
                bCardType == (byte)uFrAdvance.Globals.DLCARDTYPE.DL_MIFARE_ULTRALIGHT ||
                bCardType == (byte)uFrAdvance.Globals.DLCARDTYPE.DL_MIFARE_ULTRALIGHT_C)
                bMaxByte = 4;
            else
                bMaxByte = 16;
            return bMaxByte;
        }


        private void frmBlockReadWrite_Load(object sender, EventArgs e)
        {
                       
            cboKeyIndex.SelectedItem = cboKeyIndex.Items[0];
            GL.CreatePKKey(21, 31, 4, 350, "txtPKKey", 6, false, pnlAuth);
             
        }

        private void btnBlockRead_Click(object sender, EventArgs e)
        {
         
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn           = true;                                
                byte bKeyIndex          = 0;
                UInt16 uiBlockAddress   = 0;
                byte bMaxByteBlock      = MaxByteBlock(GL.TypeOfCard);
                byte[] baBlockData      = new byte[bMaxByteBlock];               
                byte bAuthMode          = (rbAUTH1A.Checked) ?  MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                DL_STATUS iFResult;

                    if (txtBlockAddress.Text == String.Empty)
                    {
                        MessageBox.Show("You must enter the BLOCK ADDRESS !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtBlockAddress.Focus();                        
                        return;
                    }

                    bKeyIndex      = System.Convert.ToByte(cboKeyIndex.Text);
                    uiBlockAddress = System.Convert.ToUInt16(txtBlockAddress.Text);                                        
                    unsafe
                    {
                        fixed (byte* PData = baBlockData)
                        {
                            iFResult = uFCoder1x.BlockRead(PData, uiBlockAddress, bAuthMode, bKeyIndex);
                        }
                    }
                    if (iFResult == DL_OK)
                    {
                        if (chkBRHex.Checked)
                        {
                            txtBlockRead.Text = ConvertToHex(baBlockData);
                        }
                        else
                        {
                            txtBlockRead.Text = System.Text.ASCIIEncoding.ASCII.GetString(baBlockData);
                        }
                                                  
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

        private void btnBlockReadAKM1_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn           = true;                                                
                UInt16 uiBlockAddress   = 0;
                byte bMaxByteBlock      = MaxByteBlock(GL.TypeOfCard);
                byte[] baBlockData       = new byte[bMaxByteBlock];               
                byte bAuthMode          = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                DL_STATUS iFResult;

                if (txtBlockAddressAKM1.Text == String.Empty)
                {
                    MessageBox.Show("You must enter the BLOCK ADDRESS !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBlockAddressAKM1.Focus();                   
                    return;
                }
                uiBlockAddress = System.Convert.ToUInt16(txtBlockAddressAKM1.Text);                
                unsafe
                {
                    fixed (byte* PData = baBlockData)
                    {
                        iFResult = uFCoder1x.BlockRead_AKM1(PData,uiBlockAddress, bAuthMode);
                    }
                }
                if (iFResult == DL_OK)
                {
                    if (chkBRHexAKM1.Checked)
                    {
                        txtBlockReadAKM1.Text = ConvertToHex(baBlockData);
                    }
                    else
                    {
                        txtBlockReadAKM1.Text = System.Text.ASCIIEncoding.ASCII.GetString(baBlockData);
                    }
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

        private void btnBlockReadAKM2_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn           = true;                
                UInt16 uiBlockAddress   = 0;
                byte bMaxByteBlock      = MaxByteBlock(GL.TypeOfCard);
                byte[] baBlockData      = new byte[bMaxByteBlock];                
                byte bAuthMode          = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                DL_STATUS iFResult;

                if (txtBlockAddressAKM2.Text == String.Empty)
                {
                    MessageBox.Show("You must enter the BLOCK ADDRESS !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBlockAddressAKM2.Focus();                    
                    return;
                }
                uiBlockAddress = System.Convert.ToUInt16(txtBlockAddressAKM2.Text);
                
                unsafe
                {
                    fixed (byte* PData = baBlockData)
                    {
                        iFResult = uFCoder1x.BlockRead_AKM2(PData, uiBlockAddress, bAuthMode);
                    }
                }
                if (iFResult == DL_OK)
                {
                    if (chkBRHexAKM2.Checked)
                    {
                        txtBlockReadAKM2.Text = ConvertToHex(baBlockData);
                    }
                    else
                    {
                        txtBlockReadAKM2.Text = System.Text.ASCIIEncoding.ASCII.GetString(baBlockData);
                    }
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

        private void btnBlockAddressPK_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn           = true;               
                UInt16 uiBlockAddress   = 0;
                byte bCounter           = 0;
                byte bMaxByteBlock      = MaxByteBlock(GL.TypeOfCard);
                byte[] baBlockData      = new byte[bMaxByteBlock];                
                byte[] baPKKey          = new byte[6];
                byte bAuthMode          = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                DL_STATUS iFResult;

                if (txtBlockAddressPK.Text == String.Empty)
                {
                    MessageBox.Show("You must enter the BLOCK ADDRESS !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBlockAddressPK.Focus();                    
                    return;
                }
                uiBlockAddress = System.Convert.ToUInt16(txtBlockAddressPK.Text);
                
                
               
                    foreach (Control cControl in pnlAuth.Controls)
                    {
                        if (cControl.Name == "txtPKKey")
                        {
                            baPKKey[bCounter] = System.Convert.ToByte(cControl.Text);
                            bCounter++;
                        }
                    }
                
                unsafe
                {
                    fixed (byte* PData = baBlockData,PKKey = baPKKey)
                    {
                        iFResult = uFCoder1x.BlockRead_PK(PData, uiBlockAddress, bAuthMode,PKKey);
                    }
                }
                if (iFResult == DL_OK)
                {
                    if (chkBRHexPK.Checked)
                    {
                        txtBlockReadPK.Text = ConvertToHex(baBlockData);
                    }
                    else
                    {
                        txtBlockReadPK.Text = System.Text.ASCIIEncoding.ASCII.GetString(baBlockData);
                    }
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

        private void btnBlockWrite_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn          = true;
                DL_STATUS iFResult;
                UInt16 uiBlockAddress  = 0;
                byte bKeyIndex         = 0;
                byte bMaxByteBlock     = MaxByteBlock(GL.TypeOfCard);
                byte[] baWriteData     = new byte[bMaxByteBlock];                
                byte bAuthMode         = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
            
                if (txtBlockWrite.Text == String.Empty)
                {
                    MessageBox.Show("You must enter any data!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBlockWrite.Focus();                   
                    return;
                }
                if (txtBWBlockAddress.Text == String.Empty)
                {
                    MessageBox.Show("You must enter the BLOCK DATA!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBWBlockAddress.Focus();
                    return;
                }

                uiBlockAddress = System.Convert.ToUInt16(txtBWBlockAddress.Text);                
                bKeyIndex      = System.Convert.ToByte( cboKeyIndex.SelectedIndex);
              
                if (chkBWHex.Checked)
                {
                    if ((txtBlockWrite.TextLength /2) < bMaxByteBlock  || (txtBlockWrite.TextLength /2)>bMaxByteBlock)
                    {
                        MessageBox.Show("You must enter " +bMaxByteBlock.ToString()+" bytes !", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    baWriteData=HexConvert(txtBlockWrite.Text.Trim(),bMaxByteBlock);                                      
                }
                else
                {
                    baWriteData = System.Text.Encoding.ASCII.GetBytes(txtBlockWrite.Text);
                }
                unsafe
                {
                   
                    fixed (byte* PData = baWriteData)
                    {
                        iFResult = uFCoder1x.BlockWrite(PData, uiBlockAddress, bAuthMode, bKeyIndex);
                    }
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

        private void btnBlockWriteAKM1_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn           = true;
                DL_STATUS iFResult;
                UInt16 uiBlockAddress   = 0;
                byte bMaxByteBlock      = MaxByteBlock(GL.TypeOfCard);
                byte[] baWriteData      = new byte[bMaxByteBlock];
                byte bAuthMode          = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;

                if (txtBlockWriteAKM1.Text == String.Empty)
                {
                    MessageBox.Show("You must enter any data!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBlockWriteAKM1.Focus();                    
                    return;
                }
                if (txtBWBlockAddressAKM1.Text == String.Empty)
                {
                    MessageBox.Show("You must enter the BLOCK ADDRESS !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBWBlockAddressAKM1.Focus();                   
                    return;
                }
                uiBlockAddress = System.Convert.ToUInt16(txtBWBlockAddressAKM1.Text);                
                if (chkBWHexAKM1.Checked)
                {
                    if ((txtBlockWriteAKM1.TextLength / 2) < bMaxByteBlock || (txtBlockWriteAKM1.TextLength / 2) > bMaxByteBlock)
                    {
                        MessageBox.Show("You must enter " + bMaxByteBlock.ToString() + " bytes !", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    baWriteData = HexConvert(txtBlockWriteAKM1.Text.Trim(), bMaxByteBlock);                   
                }
                else
                {
                       baWriteData = System.Text.Encoding.ASCII.GetBytes(txtBlockWriteAKM1.Text);
                }
                
                unsafe
                {
                    fixed (byte* PData = baWriteData)
                    {
                        iFResult = uFCoder1x.BlockWrite_AKM1(PData, uiBlockAddress, bAuthMode);
                    }
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

        private void btnBlockWriteAKM2_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn         = true;
                DL_STATUS iFResult;
                UInt16 uiBlockAddress = 0;               
                byte bMaxByteBlock    = MaxByteBlock(GL.TypeOfCard);
                byte[] baWriteData    = new byte[bMaxByteBlock];
                byte bAuthMode        = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;

                if (txtBlockWriteAKM2.Text == String.Empty)
                {
                    MessageBox.Show("You must enter any data!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBlockWriteAKM2.Focus();                   
                    return;
                }
                if (txtBWBlockAddressAKM2.Text == String.Empty)
                {
                    MessageBox.Show("You must enter the BLOCK ADDRESS !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBWBlockAddressAKM2.Focus();                   
                    return;
                }

                uiBlockAddress = System.Convert.ToUInt16(txtBWBlockAddressAKM2.Text);
                

                if (chkBWHexAKM2.Checked)
                {
                    if ((txtBlockWriteAKM2.TextLength / 2) < bMaxByteBlock || (txtBlockWriteAKM2.TextLength / 2) > bMaxByteBlock)
                    {
                        MessageBox.Show("You must enter " + bMaxByteBlock.ToString() + " bytes !", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    baWriteData = HexConvert(txtBlockWriteAKM2.Text.Trim(), bMaxByteBlock);                   
                }
                else
                {
                       baWriteData = System.Text.Encoding.ASCII.GetBytes(txtBlockWriteAKM2.Text);
                }
                unsafe
                {
                    fixed (byte* PData = baWriteData)
                    {
                        iFResult = uFCoder1x.BlockWrite_AKM2(PData, uiBlockAddress, bAuthMode);
                    }
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

        private void btnBlockWritePK_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn           = true;
                DL_STATUS iFResult;
                UInt16 uiBlockAddress   = 0;
                byte bCounter           = 0;                
                byte bMaxByteBlock      = MaxByteBlock(GL.TypeOfCard);
                byte[] baWriteData      = new byte[bMaxByteBlock];
                byte[] baPKKey          = new byte[6];
                byte bAuthMode          = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;

                if (txtBlockWritePK.Text == String.Empty)
                {
                    MessageBox.Show("You must enter any data!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBlockWritePK.Focus();                    
                    return;
                }
                if (txtBWBlockAddressPK.Text == String.Empty)
                {
                    MessageBox.Show("You must enter the BLOCK ADDRESS !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBWBlockAddressPK.Focus();                    
                    return;
                }

                uiBlockAddress = System.Convert.ToUInt16(txtBWBlockAddressPK.Text);
                
                if (chkBWHexPK.Checked)
                {
                    if ((txtBlockWritePK.TextLength / 2) < bMaxByteBlock || (txtBlockWritePK.TextLength / 2) > bMaxByteBlock)
                    {
                        MessageBox.Show("You must enter " + bMaxByteBlock.ToString() + " bytes !", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    baWriteData = HexConvert(txtBlockWritePK.Text.Trim(), bMaxByteBlock);                    
                }
                else
                {
                        baWriteData = System.Text.Encoding.ASCII.GetBytes(txtBlockWritePK.Text);
                }
                
                foreach (Control cControl in pnlAuth.Controls)
                {
                    if (cControl.Name == "txtPKKey")
                    {
                        baPKKey[bCounter] = System.Convert.ToByte(cControl.Text);
                        bCounter++;
                    }
                }
                unsafe
                {
                    fixed (byte* PData = baWriteData,
                                 PKKey = baPKKey)
                    {
                        iFResult = uFCoder1x.BlockWrite_PK(PData, uiBlockAddress, bAuthMode,PKKey);
                    }
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

             
        
        private byte[] HexConvert(String sTextBoxValue,byte bMaxBytes)
        {                                             
            byte bCounter     = 0,
                 bBr          = 0;                       
            byte[] bBlockData = new byte[bMaxBytes]; 
                         
            sTextBoxValue     = Regex.Replace(sTextBoxValue, @"\s", "");
            
            try
            {
                while (bCounter < bMaxBytes)
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


        private String ConvertToHex(byte[]baBlockRead)
        {
            StringBuilder sb = new StringBuilder();
            UTF8Encoding enc = new UTF8Encoding();
            string sString   = null,sBuffer = null;
                       
             foreach(byte bCount in baBlockRead)
                {
                  sBuffer=bCount.ToString("X2");                  
                  sb.Append(sBuffer.PadLeft(2,"0"[0]));
                  sString=sb.ToString();
                }            
            return sString;
        }



       
                               
      }
 
    //-----end-----   
 }



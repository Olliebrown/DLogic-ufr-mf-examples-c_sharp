using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using uFrAdvance;

namespace uFrAdvance
{
    using DL_STATUS = System.UInt32;
    public partial class frmValueBlockReadWrite : Form
    {
        private
            Globals GL = new Globals();
        public frmValueBlockReadWrite()
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

        private void frmValueBlockReadWrite_Load(object sender, EventArgs e)
        {
             
            cboKeyIndex.SelectedItem = cboKeyIndex.Items[0];
            GL.CreatePKKey(21, 31, 4, 350, "txtPKKey", 6, false, pnlAuth);
             
        }

        private void btnValueBlockRead_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iValueData           = 0;                
                UInt16 uiBlockAddress      = 0; 
                byte bValueAddress         = 0;                               
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                byte bKeyIndex             = 0;
                                                
                if (txtVBRBlockAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBRBlockAddress.Focus();
                    return;
                }
                
                uiBlockAddress = System.Convert.ToByte(txtVBRBlockAddress.Text);
                bKeyIndex      = System.Convert.ToByte(cboKeyIndex.Text);
                                
                unsafe
                {
                        Int32* PData=stackalloc Int32[1];
                               PData=&iValueData;
                        iFResult = uFCoder.ValueBlockRead(PData, &bValueAddress, uiBlockAddress, bAuthMode, bKeyIndex);
                        
                }
                if (iFResult == DL_OK)
                {
                    txtVBReadValue.Text =iValueData.ToString();
                    txtVBValueAddress.Text = System.Convert.ToString(bValueAddress);
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

        private void btnValueBlockReadAKM1_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iValueData           = 0;                
                UInt16 uiBlockAddress      = 0; 
                byte bValueAddress         = 0;                               
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;

                if (txtVBRBlockAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBRBlockAddressAKM1.Focus();
                    return;
                }

                uiBlockAddress = System.Convert.ToByte(txtVBRBlockAddressAKM1.Text);
                
                unsafe
                {
                    Int32* PData = stackalloc Int32[1];
                           PData = &iValueData;
                    iFResult = uFCoder.ValueBlockRead_AKM1(PData, &bValueAddress, uiBlockAddress, bAuthMode);

                }
                if (iFResult == DL_OK)
                {
                    txtVBReadValueAKM1.Text = iValueData.ToString();
                    txtVBRValueAddressAKM1.Text = System.Convert.ToString(bValueAddress);
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

        private void btnValueBlockReadAKM2_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iValueData           = 0;                
                UInt16 uiBlockAddress      = 0; 
                byte bValueAddress         = 0;                               
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;

                if (txtVBRBlockAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBRBlockAddressAKM2.Focus();
                    return;
                }                
                uiBlockAddress = System.Convert.ToByte(txtVBRBlockAddressAKM2.Text);
                unsafe
                {
                    Int32* PData = stackalloc Int32[1];
                           PData = &iValueData;
                    iFResult = uFCoder.ValueBlockRead_AKM2(PData, &bValueAddress, uiBlockAddress, bAuthMode);

                }
                if (iFResult == DL_OK)
                {
                    txtVBReadValueAKM2.Text = iValueData.ToString();
                    txtVBRValueAddressAKM2.Text = System.Convert.ToString(bValueAddress);
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

        private void btnValueBlockReadPK_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iValueData           = 0;                
                UInt16 uiBlockAddress      = 0; 
                byte bValueAddress         = 0;
                byte bCounter              = 0;                              
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                byte[]baKeyPK              = new byte[6];
           
                if (txtVBRBlockAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBRBlockAddressPK.Focus();
                    return;
                }                
                uiBlockAddress = System.Convert.ToByte(txtVBRBlockAddressPK.Text);
                
                foreach (Control cControl in pnlAuth.Controls)
                {
                    if (cControl.Name == "txtPKKey")
                    {
                        baKeyPK[bCounter] = System.Convert.ToByte(cControl.Text);
                        bCounter++;
                    }
                }
                unsafe
                {
                    Int32* PData = stackalloc Int32[1];
                           PData = &iValueData;
                    fixed(byte* PKEY_PK = baKeyPK)
                    iFResult = uFCoder.ValueBlockRead_PK(PData, &bValueAddress, uiBlockAddress, bAuthMode,PKEY_PK);                                        
                }
                if (iFResult == DL_OK)
                {
                    txtVBReadValuePK.Text = iValueData.ToString();
                    txtVBRValueAddressPK.Text = System.Convert.ToString(bValueAddress);
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

        private void btnVBWrite_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iValueData           = 0;                
                UInt16 uiBlockAddress      = 0; 
                byte bValueAddress         = 0;
                byte bKeyIndex             = 0;                              
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                           
                if (txtVBWriteValue.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBWriteValue.Focus();
                    return;
                }
                if (txtVBWValueAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the VALUE ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBWValueAddress.Focus();
                    return;
                }
                
                
                if (txtVBWBlockAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBWBlockAddress.Focus();
                    return;
                }
              
                bKeyIndex      = System.Convert.ToByte(cboKeyIndex.Text);
                uiBlockAddress = System.Convert.ToByte(txtVBWBlockAddress.Text);
                bValueAddress  = System.Convert.ToByte(txtVBWValueAddress.Text);
                iValueData     = System.Convert.ToInt32(txtVBWriteValue.Text);
                                
                iFResult = uFCoder.ValueBlockWrite(iValueData, bValueAddress, uiBlockAddress, bAuthMode, bKeyIndex);

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

        private void btnVBWriteAKM1_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iValueData           = 0;                
                UInt16 uiBlockAddress      = 0; 
                byte bValueAddress         = 0;                                              
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;

                if (txtVBWriteValueAKM1.Text.Trim() == String.Empty)
                {               
                  MessageBox.Show("You must enter any value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBWriteValueAKM1.Focus();
                    return;
                }
                if (txtVBWValueAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the VALUE ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBWValueAddressAKM1.Focus();
                    return;
                }

                if (txtVBWBlockAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBWBlockAddressAKM1.Focus();
                    return;
                }
              
                uiBlockAddress = System.Convert.ToByte(txtVBWBlockAddressAKM1.Text);
                bValueAddress  = System.Convert.ToByte(txtVBWValueAddressAKM1.Text);
                iValueData     = System.Convert.ToInt32(txtVBWriteValueAKM1.Text);
                                
                iFResult = uFCoder.ValueBlockWrite_AKM1(iValueData, bValueAddress, uiBlockAddress, bAuthMode);

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

        private void btnVBWriteAKM2_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iValueData           = 0;                
                UInt16 uiBlockAddress      = 0; 
                byte bValueAddress         = 0;                                              
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;

                if (txtVBWriteValueAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBWriteValueAKM2.Focus();
                    return;
                }
                
                 if (txtVBWValueAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the VALUE ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBWValueAddressAKM2.Focus();
                    return;
                }
                if (txtVBWBlockAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBWBlockAddressAKM2.Focus();
                    return;
                }
               
                uiBlockAddress = System.Convert.ToByte(txtVBWBlockAddressAKM2.Text);
                bValueAddress  = System.Convert.ToByte(txtVBWValueAddressAKM2.Text);
                iValueData     = System.Convert.ToInt32(txtVBWriteValueAKM2.Text);
                                
                iFResult = uFCoder.ValueBlockWrite_AKM2(iValueData, bValueAddress, uiBlockAddress, bAuthMode);

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

        private void btnVBWritePK_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn = true;

                DL_STATUS iFResult;
                Int32 iValueData           = 0;                
                UInt16 uiBlockAddress      = 0; 
                byte bValueAddress         = 0;                                              
                byte bCounter              = 0;
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                byte[]baKeyPK=new byte[6];
            
                if (txtVBWriteValuePK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBWriteValuePK.Focus();
                    return;
                }
                if (txtVBWValueAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the VALUE ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBWValueAddressPK.Focus();
                    return;
                }
                if (txtVBWBlockAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBWBlockAddressPK.Focus();
                    return;
                }
               
                uiBlockAddress  = System.Convert.ToByte(txtVBWBlockAddressPK.Text);
                bValueAddress   = System.Convert.ToByte(txtVBWValueAddressPK.Text);
                iValueData      = System.Convert.ToInt32(txtVBWriteValuePK.Text);
                
                foreach(Control cControl in pnlAuth.Controls)
                {
                    if (cControl.Name=="txtPKKey") 
                    {
                        baKeyPK[bCounter]=System.Convert.ToByte(cControl.Text);
                        bCounter++;
                    }
                }

                unsafe
                {
                    fixed (byte* PKEY_PK = baKeyPK)
                    {
                        iFResult = uFCoder.ValueBlockWrite_PK(iValueData, bValueAddress, uiBlockAddress, bAuthMode, PKEY_PK);
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

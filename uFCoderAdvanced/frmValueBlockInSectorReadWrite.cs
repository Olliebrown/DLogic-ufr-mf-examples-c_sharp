using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace uFrAdvance
{
    using DL_STATUS = System.UInt32;
    public partial class frmValueBlockInSectorReadWrite : Form
    {
        private
             Globals GL = new Globals();
        public frmValueBlockInSectorReadWrite()
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
                    CONVERT_ERROR = "You may enter only whole decimal number !",
                    APPROPRIATE_FORMAT = "You must enter the appropriate format !";

        private void frmValueBlockInSectorReadWrite_Load(object sender, EventArgs e)
        {
             
            cboKeyIndex.SelectedItem = cboKeyIndex.Items[0];
            GL.CreatePKKey(21, 31, 4, 350, "txtPKKey", 6, false, pnlAuth);
             
        }

        private void btnVBISRead_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iReadData            = 0;
                byte bSectorAddress        = 0;
                byte bBlockAddress         = 0; 
                byte bValueAddress         = 0;                               
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                byte bKeyIndex             = 0;
                      
                if (txtVBISRSectorAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISRSectorAddress.Focus();
                    return;
                }
                if (txtVBISRBlockAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISRBlockAddress.Focus();
                    return;
                }
                
                bSectorAddress = System.Convert.ToByte(txtVBISRSectorAddress.Text);
                bBlockAddress = System.Convert.ToByte(txtVBISRBlockAddress.Text);
                bKeyIndex = System.Convert.ToByte(cboKeyIndex.Text);

                unsafe
                {
                    Int32* PData=stackalloc Int32[1];
                           PData = &iReadData;
                    iFResult = uFCoder.ValueBlockInSectorRead(PData, &bValueAddress, bSectorAddress, bBlockAddress, bAuthMode, bKeyIndex);
                    
                }
                if (iFResult == DL_OK)
                {
                    txtVBISReadData.Text = iReadData.ToString();
                    txtVBISRValueAddress.Text = bValueAddress.ToString();
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

        private void btnVBISReadAKM1_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iReadData            = 0;
                byte bSectorAddress        = 0;
                byte bBlockAddress         = 0; 
                byte bValueAddress         = 0;                               
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;

                if (txtVBISRSectorAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISRSectorAddressAKM1.Focus();
                    return;
                }
                if (txtVBISRBlockAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISRBlockAddressAKM1.Focus();
                    return;
                }

                bSectorAddress = System.Convert.ToByte(txtVBISRSectorAddressAKM1.Text);
                bBlockAddress  = System.Convert.ToByte(txtVBISRBlockAddressAKM1.Text);
                

                unsafe
                {
                    Int32* PData=stackalloc Int32[1];
                           PData = &iReadData;
                    iFResult = uFCoder.ValueBlockInSectorRead_AKM1(PData, &bValueAddress, bSectorAddress, bBlockAddress, bAuthMode);
                    
                }
                if (iFResult == DL_OK)
                {
                    txtVBISReadDataAKM1.Text = iReadData.ToString();
                    txtVBISRValueAddressAKM1.Text = bValueAddress.ToString();
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

        private void btnVBISReadAKM2_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iReadData            = 0;
                byte bSectorAddress        = 0;
                byte bBlockAddress         = 0; 
                byte bValueAddress         = 0;                               
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;

                if (txtVBISRSectorAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISRSectorAddressAKM2.Focus();
                    return;
                }
                if (txtVBISRBlockAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISRBlockAddressAKM2.Focus();
                    return;
                }

                 bSectorAddress = System.Convert.ToByte(txtVBISRSectorAddressAKM2.Text);
                 bBlockAddress  = System.Convert.ToByte(txtVBISRBlockAddressAKM2.Text);
                
                unsafe
                {
                    Int32* PData=stackalloc Int32[1];
                           PData = &iReadData;
                    iFResult = uFCoder.ValueBlockInSectorRead_AKM2(PData, &bValueAddress, bSectorAddress, bBlockAddress, bAuthMode);
                    
                }
                if (iFResult == DL_OK)
                {
                    txtVBISReadDataAKM2.Text = iReadData.ToString();
                    txtVBISRValueAddressAKM2.Text = bValueAddress.ToString();
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

        private void btnVBISReadPK_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iReadData            = 0;
                byte bSectorAddress        = 0;
                byte bBlockAddress         = 0; 
                byte bValueAddress         = 0;
                byte bCounter              = 0;                             
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                byte[] baKeyPK             = new byte[6];
            
                if (txtVBISRSectorAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISRSectorAddressPK.Focus();
                    return;
                }
                if (txtVBISRBlockAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISRBlockAddressPK.Focus();
                    return;
                }

                bSectorAddress   = System.Convert.ToByte(txtVBISRSectorAddressPK.Text);
                bBlockAddress    = System.Convert.ToByte(txtVBISRBlockAddressPK.Text);
                
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
                           PData = &iReadData;
                    fixed (byte* PKEY_PK = baKeyPK) 
                    iFResult = uFCoder.ValueBlockInSectorRead_PK(PData, &bValueAddress, bSectorAddress, bBlockAddress, bAuthMode,PKEY_PK);
                    
                }
                if (iFResult == DL_OK)
                {
                    txtVBISReadDataPK.Text = iReadData.ToString();
                    txtVBISRValueAddressPK.Text = bValueAddress.ToString();
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

        private void btnBISWrite_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iWriteData           = 0;
                byte bSectorAddress        = 0;
                byte bBlockAddress         = 0; 
                byte bValueAddress         = 0;                               
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                byte bKeyIndex             = 0;

            if (txtVBISWWriteData.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWWriteData.Focus();
                return;
            }
            if (txtVBISWSectorAddress.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter  the SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWSectorAddress.Focus();
                return;
            }
            if (txtVBISWBlockAddress.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWBlockAddress.Focus();
                return;
            }
            if (txtVBISWValueAddress.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter VALUE ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWValueAddress.Focus();
                return;
            }
                           
                bKeyIndex      = System.Convert.ToByte(cboKeyIndex.Text);
                iWriteData     = System.Convert.ToInt32(txtVBISWWriteData.Text);
                bSectorAddress = System.Convert.ToByte(txtVBISWSectorAddress.Text);
                bBlockAddress  = System.Convert.ToByte(txtVBISWBlockAddress.Text);
                bValueAddress  = System.Convert.ToByte(txtVBISWValueAddress.Text);

                iFResult = uFCoder.ValueBlockInSectorWrite(iWriteData, bValueAddress, bSectorAddress, bBlockAddress, bAuthMode, bKeyIndex);
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
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iWriteData           = 0;
                byte bSectorAddress        = 0;
                byte bBlockAddress         = 0; 
                byte bValueAddress         = 0;                               
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;

            if (txtVBISWWriteDataAKM1.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWWriteDataAKM1.Focus();
                return;
            }
            if (txtVBISWSectorAddressAKM1.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter  the SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWSectorAddressAKM1.Focus();
                return;
            }
            if (txtVBISWBlockAddressAKM1.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter the  BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWBlockAddressAKM1.Focus();
                return;
            }
            if (txtVBISWValueAddressAKM1.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter  the VALUE ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWValueAddressAKM1.Focus();
                return;
            }

                iWriteData     = System.Convert.ToInt32(txtVBISWWriteDataAKM1.Text);
                bSectorAddress = System.Convert.ToByte(txtVBISWSectorAddressAKM1.Text);
                bBlockAddress  = System.Convert.ToByte(txtVBISWBlockAddressAKM1.Text);
                bValueAddress  = System.Convert.ToByte(txtVBISWValueAddressAKM1.Text);

                iFResult = uFCoder.ValueBlockInSectorWrite_AKM1(iWriteData, bValueAddress, bSectorAddress, bBlockAddress, bAuthMode);

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
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iWriteData           = 0;
                byte bSectorAddress        = 0;
                byte bBlockAddress         = 0; 
                byte bValueAddress         = 0;                               
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;

            if (txtVBISWWriteDataAKM2.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWWriteDataAKM2.Focus();
                return;
            }
            if (txtVBISWSectorAddressAKM2.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter  the SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWSectorAddressAKM2.Focus();
                return;
            }
            if (txtVBISWBlockAddressAKM2.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter the  BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWBlockAddressAKM2.Focus();
                return;
            }
            if (txtVBISWValueAddressAKM2.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter  the VALUE ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWValueAddressAKM2.Focus();
                return;
            }

                iWriteData     = System.Convert.ToInt32(txtVBISWWriteDataAKM2.Text);
                bSectorAddress = System.Convert.ToByte(txtVBISWSectorAddressAKM2.Text);
                bBlockAddress  = System.Convert.ToByte(txtVBISWBlockAddressAKM2.Text);
                bValueAddress  = System.Convert.ToByte(txtVBISWValueAddressAKM2.Text);

                iFResult = uFCoder.ValueBlockInSectorWrite_AKM2(iWriteData, bValueAddress, bSectorAddress, bBlockAddress, bAuthMode);

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

        private void btnVBISWritePK_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iWriteData           = 0;
                byte bSectorAddress        = 0;
                byte bBlockAddress         = 0; 
                byte bValueAddress         = 0; 
                byte bCounter              = 0;                              
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                byte[] baKeyPk             = new byte[6];

            if (txtVBISWWriteDataPK.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWWriteDataPK.Focus();
                return;
            }
            if (txtVBISWSectorAddressPK.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter  the SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWSectorAddressPK.Focus();
                return;
            }
            if (txtVBISWBlockAddressPK.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWBlockAddressPK.Focus();
                return;
            }
            if (txtVBISWValueAddressPK.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter  the VALUE ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWValueAddressPK.Focus();
                return;
            }
            
                
                iWriteData     = System.Convert.ToInt32(txtVBISWWriteDataPK.Text);
                bSectorAddress = System.Convert.ToByte(txtVBISWSectorAddressPK.Text);
                bBlockAddress  = System.Convert.ToByte(txtVBISWBlockAddressPK.Text);
                bValueAddress  = System.Convert.ToByte(txtVBISWValueAddressPK.Text);
                
                foreach (Control cControl in pnlAuth.Controls)
                {
                    if (cControl.Name == "txtPKKey")
                    {
                        baKeyPk[bCounter] = System.Convert.ToByte(cControl.Text);
                        bCounter++;
                    }
                }

                unsafe
                {
                    fixed(byte* PKEY_PK=baKeyPk)
                    iFResult = uFCoder.ValueBlockInSectorWrite_PK(iWriteData, bValueAddress, bSectorAddress, bBlockAddress, bAuthMode, PKEY_PK);
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

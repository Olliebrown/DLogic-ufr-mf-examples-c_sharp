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
                        iFResult = uFCoder1x.BlockInSectorRead(PData, bSectorAddress, bBlockAddress, bAuthMode, bKeyIndex);                        
                    }
                }
                if (iFResult == DL_OK)
                {
                    txtBISReadData.Text =System.Text.Encoding.ASCII.GetString(baReadData);
                    uFCoder1x.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);                   
                    GL.SetStatusBar(iFResult, stbFunctionError);                                                            
                }
                else
                {
                    uFCoder1x.ReaderUISignal(FERR_LIGHT, FERR_SOUND);                    
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
                        iFResult = uFCoder1x.BlockInSectorRead_AKM1(PData, bSectorAddress, bBlockAddress, bAuthMode);
                    }
                }
                if (iFResult == DL_OK)
                {                                                          
                    txtBISReadDataAKM1.Text = System.Text.Encoding.ASCII.GetString(baReadData);
                    uFCoder1x.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);                   
                    GL.SetStatusBar(iFResult, stbFunctionError);                                                            
                }
                else
                {
                    uFCoder1x.ReaderUISignal(FERR_LIGHT, FERR_SOUND);                    
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
                        iFResult = uFCoder1x.BlockInSectorRead_AKM2(PData, bSectorAddress, bBlockAddress, bAuthMode);
                    }
                }
                if (iFResult == DL_OK)
                {                    
                    txtBISReadDataAKM2.Text = System.Text.Encoding.ASCII.GetString(baReadData);
                    uFCoder1x.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }
                else
                {
                    uFCoder1x.ReaderUISignal(FERR_LIGHT, FERR_SOUND);
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
                        iFResult = uFCoder1x.BlockInSectorRead_PK(PData, bSectorAddress, bBlockAddress, bAuthMode,PPKEY);
                    }
                }
                if (iFResult == DL_OK)
                {                    
                    txtBISReadDataPK.Text = System.Text.Encoding.ASCII.GetString(baReadData);
                    uFCoder1x.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }
                else
                {
                    uFCoder1x.ReaderUISignal(FERR_LIGHT, FERR_SOUND);
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
                                
                baWriteData = System.Text.Encoding.ASCII.GetBytes(txtBISWWriteData.Text);
                unsafe
                {
                    fixed (byte* PData = baWriteData)
                    {
                        iFResult = uFCoder1x.BlockInSectorWrite(PData, bSectorAddress, bBlockAddress, bAuthMode, bKeyIndex);
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
                
                baWriteData     = System.Text.Encoding.ASCII.GetBytes(txtBISWWriteDataAKM1.Text);
                unsafe
                {
                    fixed (byte* PData = baWriteData)
                    {
                        iFResult = uFCoder1x.BlockInSectorWrite_AKM1(PData, bSectorAddress, bBlockAddress, bAuthMode);
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
                
                baWriteData    = System.Text.Encoding.ASCII.GetBytes(txtBISWWriteDataAKM2.Text);
                unsafe
                {
                    fixed (byte* PData = baWriteData)
                    {
                        iFResult = uFCoder1x.BlockInSectorWrite_AKM2(PData, bSectorAddress, bBlockAddress, bAuthMode);
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
                baWriteData    = System.Text.Encoding.ASCII.GetBytes(txtBISWWriteDataPK.Text);

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
                        iFResult = uFCoder1x.BlockInSectorWrite_PK(PData, bSectorAddress, bBlockAddress, bAuthMode,PKEY);
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

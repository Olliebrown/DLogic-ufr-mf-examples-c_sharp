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
    

    public partial class frmLinearReadWrite : Form
    {
        private
              Globals GL = new Globals();
        public frmLinearReadWrite()
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

        private void frmLinearReadWrite_Load(object sender, EventArgs e)
        {

             
            cboKeyIndex.SelectedItem = cboKeyIndex.Items[0];
            GL.CreatePKKey(21, 31, 4, 350, "txtPKKey", 6, false, pnlAuth);
             
        }

        private void btnLinearRead_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn = true;
               
                DL_STATUS iFResult;
                
                               
                ushort usBytesRet          = 0;
                
                byte bAuthMode              = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                byte bKeyIndex              = Convert.ToByte(cboKeyIndex.Text);
                            
                if (txtLinearAddress.Text == String.Empty)
                {
                    MessageBox.Show("You must enter  the LINEAR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLinearAddress.Focus();
                    return;
                }
                if (txtDataLength.Text == String.Empty)
                {
                    MessageBox.Show("You must enter  the DATA LENGTH !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDataLength.Focus();
                    return;
                }

                ushort usLinearAddress = Convert.ToUInt16(txtLinearAddress.Text);
                ushort usDataLength    = Convert.ToUInt16(txtDataLength.Text);
                byte[] baReadData      = new byte[usDataLength];
                                    
                unsafe
                {
                    fixed (byte* PData = baReadData)
                    {
                        iFResult = uFCoder.LinearRead(PData, usLinearAddress, usDataLength, &usBytesRet, bAuthMode, bKeyIndex);
                    }
                }
                if (iFResult == DL_OK)
                {                                                       
                    txtLinearRead.Text = System.Text.ASCIIEncoding.ASCII.GetString(baReadData);
                    txtReadBytes.Text  = usBytesRet.ToString();
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }
                else
                {                    
                    txtLinearRead.Text = System.Text.ASCIIEncoding.ASCII.GetString(baReadData);
                    txtReadBytes.Text  = usBytesRet.ToString();
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

        private void btnLinearReadAKM1_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn = true;
                
                
                DL_STATUS iFResult;
                

                if (txtLinearAddressAKM1.Text == String.Empty)
                {
                    MessageBox.Show("You must enter  the LINEAR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLinearAddressAKM1.Focus();
                    return;
                }
                if (txtDataLengthAKM1.Text == String.Empty)
                {
                    MessageBox.Show("You must enter  the DATA LENGTH !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDataLengthAKM1.Focus();
                    return;
                }

                ushort usLinearAddress = Convert.ToUInt16(txtLinearAddressAKM1.Text);
                ushort usDataLength = Convert.ToUInt16(txtDataLengthAKM1.Text);
                ushort usBytesRet = 0;
                byte[] baReadData = new byte[usDataLength];
                byte bAuthMode = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                             
                unsafe
                {
                    fixed (byte* PData = baReadData)
                    {
                        iFResult = uFCoder.LinearRead_AKM1(PData, usLinearAddress, usDataLength, &usBytesRet, bAuthMode);
                    }
                }
                if (iFResult == DL_OK)
                {                                                       
                    txtLinearReadAKM1.Text = System.Text.ASCIIEncoding.ASCII.GetString(baReadData);
                    txtReadBytesAKM1.Text  = usBytesRet.ToString();
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }
                else
                {                    
                    txtLinearReadAKM1.Text = System.Text.ASCIIEncoding.ASCII.GetString(baReadData);
                    txtReadBytesAKM1.Text  = usBytesRet.ToString();
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

        private void btnLinearReadAKM2_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn = true;

                DL_STATUS iFResult;

                if (txtLinearAddressAKM2.Text == String.Empty)
                {
                    MessageBox.Show("You must enter  the LINEAR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLinearAddressAKM2.Focus();
                    return;
                }
                if (txtDataLengthAKM2.Text == String.Empty)
                {
                    MessageBox.Show("You must enter  the DATA LENGTH !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDataLengthAKM2.Focus();
                    return;
                }


                ushort usLinearAddress = Convert.ToUInt16(txtLinearAddressAKM2.Text);
                ushort usDataLength = Convert.ToUInt16(txtDataLengthAKM2.Text);
                ushort usBytesRet = 0;
                byte[] baReadData = new byte[usDataLength];
                byte bAuthMode = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                             
                unsafe
                {
                    fixed (byte* PData = baReadData)
                    {
                        iFResult = uFCoder.LinearRead_AKM2(PData, usLinearAddress, usDataLength, &usBytesRet, bAuthMode);
                    }
                }
                if (iFResult == DL_OK)
                {                                                       
                    txtLinearReadAKM2.Text = System.Text.ASCIIEncoding.ASCII.GetString(baReadData);
                    txtReadBytesAKM2.Text  = usBytesRet.ToString();
                     uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }
                else
                {                    
                    txtLinearReadAKM2.Text = System.Text.ASCIIEncoding.ASCII.GetString(baReadData);
                    txtReadBytesAKM2.Text  = usBytesRet.ToString();
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

        private void btnLinearReadPK_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn          = true;

                
                byte[] baKeyPK         = new byte[6];
                byte bCounter          = 0;
                DL_STATUS iFResult;
                

                if (txtLinearAddressPK.Text == String.Empty)
                {
                    MessageBox.Show("You must enter  the LINEAR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLinearAddressPK.Focus();
                    return;
                }
                if (txtDataLengthPK.Text == String.Empty)
                {
                    MessageBox.Show("You must enter  the DATA LENGTH !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDataLengthPK.Focus();
                    return;
                }

                ushort usLinearAddress = Convert.ToUInt16(txtLinearAddressPK.Text);
                ushort usDataLength = Convert.ToUInt16(txtDataLengthPK.Text);
                ushort usBytesRet = 0;
                byte[] baReadData = new byte[usDataLength];
                byte bAuthMode = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;    
                
                for (int i = 0; i < pnlAuth.Controls.Count; ++i)
                {
                    if (pnlAuth.Controls[i].Name == "txtPKKey")
                    {
                        baKeyPK[bCounter] = Convert.ToByte(pnlAuth.Controls[i].Text.ToString());
                        bCounter++;
                    }
                }
                unsafe
                {
                    fixed (byte* PData   = baReadData,
                                 PKEY_PK = baKeyPK )
                    {                        
                            iFResult = uFCoder.LinearRead_PK(PData, usLinearAddress, usDataLength, &usBytesRet, bAuthMode, PKEY_PK);                        
                    }
                }
                if (iFResult == DL_OK)
                {                                                       
                    txtLinearReadPK.Text = System.Text.ASCIIEncoding.ASCII.GetString(baReadData);
                    txtReadBytesPK.Text  = usBytesRet.ToString();
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }
                else
                {                    
                    txtLinearReadPK.Text = System.Text.ASCIIEncoding.ASCII.GetString(baReadData);
                    txtReadBytesPK.Text  = usBytesRet.ToString();
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

        private void btnLinearWrite_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn = true;
                                                               
                DL_STATUS iFResult;

                if (txtLinearWrite.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any data!", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLinearWrite.Focus();
                    return;
                }
                
                if (txtLinearAddressWrite.Text == String.Empty)
                {
                    MessageBox.Show("You must enter  the LINEAR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLinearAddressWrite.Focus();
                    return;
                }
                if (txtDataLengthWrite.Text == String.Empty)
                {
                    MessageBox.Show("You must enter  the DATA LENGTH !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDataLengthWrite.Focus();
                    return;
                }
                ushort usLinearAddress = Convert.ToUInt16(txtLinearAddressWrite.Text);
                ushort usDataLength = Convert.ToUInt16(txtDataLengthWrite.Text);
                byte[] baWriteData = new byte[usDataLength];
                byte bAuthMode = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                ushort usBytesRet = 0;
                byte bKeyIndex = Convert.ToByte(cboKeyIndex.Text);
                baWriteData     =  System.Text.Encoding.ASCII.GetBytes(txtLinearWrite.Text);
                                                                                                                                                                                                    
                unsafe
                {
                    fixed (byte* PData =baWriteData)
                    {
                        iFResult = uFCoder.LinearWrite(PData, usLinearAddress, usDataLength, &usBytesRet, bAuthMode, bKeyIndex);
                    }
                }

                if (iFResult == DL_OK)
                {
                    txtBytesWritten.Text = usBytesRet.ToString();
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }
                else
                {
                    txtBytesWritten.Text = usBytesRet.ToString();
                    uFCoder.ReaderUISignal(FERR_LIGHT, FERR_SOUND);
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

        private void btnLinearWriteAKM1_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn = true;

                              
                DL_STATUS iFResult;

                if (txtLinearWriteAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLinearWriteAKM1.Focus();
                    return;
                }
                if (txtLinearAddressWriteAKM1.Text == String.Empty)
                {
                    MessageBox.Show("You must enter  the LINEAR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLinearAddressWriteAKM1.Focus();
                    return;
                }
                if (txtDataLengthWriteAKM1.Text == String.Empty)
                {
                    MessageBox.Show("You must enter  the DATA LENGTH !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDataLengthWriteAKM1.Focus();
                    return;
                }
                ushort usLinearAddress = Convert.ToUInt16(txtLinearAddressWriteAKM1.Text);
                ushort usDataLength = Convert.ToUInt16(txtDataLengthWriteAKM1.Text);
                byte[] baWriteData = new byte[usDataLength];
                byte bAuthMode = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                ushort usBytesRet = 0;                              
                baWriteData     =  System.Text.Encoding.ASCII.GetBytes(txtLinearWriteAKM1.Text);
              

                unsafe
                {
                    fixed (byte* PData = baWriteData)
                    {
                        iFResult = uFCoder.LinearWrite_AKM1(PData, usLinearAddress, usDataLength, &usBytesRet, bAuthMode);
                    }
                }

                if (iFResult == DL_OK)
                {
                    txtBytesWrittenAKM1.Text = usBytesRet.ToString();
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }
                else
                {
                    txtBytesWrittenAKM1.Text = usBytesRet.ToString();
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

        private void btnLinearWriteAKM2_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn = true;

                DL_STATUS iFResult;

                if (txtLinearWriteAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLinearWriteAKM2.Focus();
                    return;
                }
                if (txtLinearAddressWriteAKM2.Text == String.Empty)
                {
                    MessageBox.Show("You must enter  the LINEAR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLinearAddressWriteAKM2.Focus();
                    return;
                }
                if (txtDataLengthWriteAKM2.Text == String.Empty)
                {
                    MessageBox.Show("You must enter  the DATA LENGTH !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDataLengthWriteAKM2.Focus();
                    return;
                }

                ushort usLinearAddress = Convert.ToUInt16(txtLinearAddressWriteAKM2.Text);
                ushort usDataLength = Convert.ToUInt16(txtDataLengthWriteAKM2.Text);
                byte[] baWriteData = new byte[usDataLength];
                byte bAuthMode = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                ushort usBytesRet = 0;
                baWriteData     =  System.Text.Encoding.ASCII.GetBytes(txtLinearWriteAKM2.Text);
                

                unsafe
                {
                    fixed (byte* PData = baWriteData)
                    {
                        iFResult = uFCoder.LinearWrite_AKM2(PData, usLinearAddress, usDataLength, &usBytesRet, bAuthMode);
                    }
                }

                if (iFResult == DL_OK)
                {
                    txtBytesWrittenAKM2.Text = usBytesRet.ToString();
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }
                else
                {
                    txtBytesWrittenAKM2.Text = usBytesRet.ToString();
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

        private void btnLinearWritePK_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn = true;

                byte[] baKeyPK = new byte[6];
                byte bCounter = 0;
                DL_STATUS iFResult;
                

                if (txtLinearWritePK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLinearWritePK.Focus();
                    return;
                }
                if (txtLinearAddressWritePK.Text == String.Empty)
                {
                    MessageBox.Show("You must enter  the LINEAR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLinearAddressWritePK.Focus();
                    return;
                }
                if (txtDataLengthWritePK.Text == String.Empty)
                {
                    MessageBox.Show("You must enter  the DATA LENGTH !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDataLengthWritePK.Focus();
                    return;
                }
                
                                                              
                for (int i = 0; i < pnlAuth.Controls.Count; ++i)
                {
                    if (pnlAuth.Controls[i].Name == "txtPKKey")
                    {
                        baKeyPK[bCounter] = Convert.ToByte(pnlAuth.Controls[i].Text.ToString());
                        bCounter++;
                    }
                }
               
                ushort usLinearAddress = Convert.ToUInt16(txtLinearAddressWritePK.Text);
                ushort usDataLength = Convert.ToUInt16(txtDataLengthWritePK.Text);
                byte[] baWriteData = new byte[usDataLength];
                byte bAuthMode = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                ushort usBytesRet = 0;
                baWriteData = System.Text.Encoding.ASCII.GetBytes(txtLinearWritePK.Text);
                unsafe
                {
                    fixed (byte* PData = baWriteData, PKEY_PK = baKeyPK)
                    {                        
                        iFResult = uFCoder.LinearWrite_PK(PData, usLinearAddress, usDataLength, &usBytesRet, bAuthMode,PKEY_PK);               
                    }                   
                }

                if (iFResult == DL_OK)
                {
                    txtBytesWrittenPK.Text = usBytesRet.ToString();
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }
                else
                {
                    txtBytesWrittenPK.Text = usBytesRet.ToString();
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

        private void txtLinearWrite_TextChanged(object sender, EventArgs e)
        {
            txtDataLengthWrite.Text = txtLinearWrite.TextLength.ToString();
        }

        private void txtLinearWriteAKM1_TextChanged(object sender, EventArgs e)
        {
            txtDataLengthWriteAKM1.Text = txtLinearWriteAKM1.TextLength.ToString();
        }

        private void txtLinearWriteAKM2_TextChanged(object sender, EventArgs e)
        {
            txtDataLengthWriteAKM2.Text = txtLinearWriteAKM2.TextLength.ToString();
        }

        private void txtLinearWritePK_TextChanged(object sender, EventArgs e)
        {
            txtDataLengthWritePK.Text = txtLinearWritePK.TextLength.ToString();
        }

        
      }

    }

     
  
    




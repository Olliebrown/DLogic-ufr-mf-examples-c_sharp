using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Mifare;

namespace Mifare
{
    
    public partial class frmBlockReadWrite : Form
    {
               
        private UInt32 result;        
       
        byte[] bBuferrArrayCopy=new byte[16];
        const byte AUTH1A = 96,
                   AUTH1B = 97,
                   DL_OK = 0,
                   RES_OK_LIGHT = 4,
                   RES_OK_SOUND = 4,
                   ERR_LIGHT = 2,
                   ERR_SOUND = 2;
        const string
                    CONVERT_ERROR = "You may enter only whole decimal number !",
                    APPROPRIATE_FORMAT = "You must enter the appropriate format !";

        public frmBlockReadWrite()
        {
            InitializeComponent();            
        }

        private void frmBlockReadWrite_Load(object sender, EventArgs e)
        {
            Globals GB = new Globals();
            cboKeyIndex.SelectedItem = cboKeyIndex.Items[0];
            GB.CreatePKKey(21, 31, 4, 350, "txtPKKey", 6, false, pnlAuth);            
        }

        private void btnBlockRead_Click(object sender, EventArgs e)
        {

            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

                byte[] bReadData = new byte[16];
                byte block_address = 0;
                byte auth_mode = 0;
                byte key_index = 0;
                try
                {
                    GL.FunctionStart = true;
                    if (txtBlockAddress.Text == String.Empty)
                    {
                        MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtBlockAddress.Focus();                        
                        return;
                    }
                    block_address = System.Convert.ToByte(txtBlockAddress.Text);
                    key_index = System.Convert.ToByte(cboKeyIndex.Text);
                    if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;

                    unsafe
                    {
                        fixed (byte* PData = bReadData)
                        {
                            result = ufCoder1x.BlockRead(PData, block_address, auth_mode, key_index);
                        }
                    }
                    if (result == DL_OK)
                    {
                        Array.Copy(bReadData, bBuferrArrayCopy, 16);
                        ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);                       
                       // txtBlockRead.Text = System.Text.ASCIIEncoding.ASCII.GetString(bReadData);               
                        txtBlockRead.Text=ConvertToHex(chkBRHex.Checked);      
                        GL.ERRORS_CODE(result, this.stbFunctionError);                        
                    }
                    else
                    {
                        ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);                        
                        GL.ERRORS_CODE(result, this.stbFunctionError);                        
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
                    GL.FunctionStart = false;
                    GL = null;
                }          
        }

        private void btnBlockReadAKM1_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte[] bReadData = new byte[16];
            byte block_address = 0;
            byte auth_mode = 0;

            try
            {
                GL.FunctionStart = true;
                if (txtBlockAddressAKM1.Text == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBlockAddressAKM1.Focus();                   
                    return;
                }
                block_address = System.Convert.ToByte(txtBlockAddressAKM1.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;

                unsafe
                {
                    fixed (byte* PData = bReadData)
                    {
                        result = ufCoder1x.BlockRead_AKM1(PData, block_address, auth_mode);
                    }
                }
                if (result == DL_OK)
                {
                    Array.Copy(bReadData, bBuferrArrayCopy, 16);
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    // txtBlockReadAKM1.Text = System.Text.ASCIIEncoding.ASCII.GetString(bReadData);                                     
                    txtBlockReadAKM1.Text=ConvertToHex(chkBRHexAKM1.Checked);
                    GL.ERRORS_CODE(result, this.stbFunctionError);                   
                }
                else
                {
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);                   
                    GL.ERRORS_CODE(result, this.stbFunctionError);                   
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
                GL.FunctionStart = false;
                GL = null;
            }   
        }

        private void btnBlockReadAKM2_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte[] bReadData = new byte[16];
            byte block_address = 0;
            byte auth_mode = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtBlockAddressAKM2.Text == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBlockAddressAKM2.Focus();                    
                    return;
                }
                block_address = System.Convert.ToByte(txtBlockAddressAKM2.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;

                unsafe
                {
                    fixed (byte* PData = bReadData)
                    {
                        result = ufCoder1x.BlockRead_AKM2(PData, block_address, auth_mode);
                    }
                }
                if (result == DL_OK)
                {
                    Array.Copy(bReadData, bBuferrArrayCopy, 16);
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    // txtBlockReadAKM2.Text = System.Text.ASCIIEncoding.ASCII.GetString(bReadData);                                     
                    txtBlockReadAKM2.Text=ConvertToHex(chkBRHexAKM2.Checked);  
                    GL.ERRORS_CODE(result, this.stbFunctionError);
                   
                }
                else
                {
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);                    
                    GL.ERRORS_CODE(result, this.stbFunctionError);                    
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
                GL.FunctionStart = false;
                GL = null;
            }   
        }

        private void btnBlockAddressPK_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte[] bReadData = new byte[16];
            byte[] pk_keys=new byte[6];
            byte block_address = 0;
            byte auth_mode = 0;

            try
            {
                GL.FunctionStart = true;
                if (txtBlockAddressPK.Text == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBlockAddressPK.Focus();                    
                    return;
                }
                block_address = System.Convert.ToByte(txtBlockAddressPK.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                byte count=0;
               
                    foreach (Control ctrl in pnlAuth.Controls)
                    {
                        if (ctrl.Name == "txtPKKey")
                        {
                            pk_keys[count] = System.Convert.ToByte(ctrl.Text);
                            count++;
                        }
                    }
                
                unsafe
                {
                    fixed (byte* PData = bReadData,PKKey = pk_keys)
                    {
                        result = ufCoder1x.BlockRead_PK(PData, block_address, auth_mode,PKKey);
                    }
                }
                if (result == DL_OK)
                {
                    Array.Copy(bReadData, bBuferrArrayCopy, 16);
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);                  
                    //txtBlockReadPK.Text = System.Text.ASCIIEncoding.ASCII.GetString(bReadData);

                    txtBlockReadPK.Text = ConvertToHex(chkBRHexPK.Checked);                 
                    GL.ERRORS_CODE(result, this.stbFunctionError);                    
                }
                else
                {
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);                    
                    GL.ERRORS_CODE(result, this.stbFunctionError);                    
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
                GL.FunctionStart = false;
                GL = null;
            }                        
        }

        private void btnBlockWrite_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte block_address = 0;
            byte auth_mode = 0;
            byte key_index = 0;
            byte[] write_data = new byte[17];
            try
            {
                GL.FunctionStart = true;
                if (txtBlockWrite.Text == String.Empty)
                {
                    MessageBox.Show("You must enter any data!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBlockWrite.Focus();                   
                    return;
                }
                if (txtBWBlockAddress.Text == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK DATA!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBWBlockAddress.Focus();
                    return;
                }
                block_address = System.Convert.ToByte(txtBWBlockAddress.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                key_index = System.Convert.ToByte( cboKeyIndex.SelectedIndex);
              
                if (chkBWHex.Checked)
                {
                  
                    write_data=HexConvert(txtBlockWrite.Text);
                    if (write_data[17]<16)
                    {
                        MessageBox.Show("You must enter 16 bytes", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                   write_data = System.Text.Encoding.ASCII.GetBytes(txtBlockWrite.Text);
                }
                unsafe
                {
                   
                    fixed (byte* PData = write_data)
                    {
                        result = ufCoder1x.BlockWrite(PData, block_address, auth_mode, key_index);
                    }
                }
                if (result==DL_OK) 
                {
                   
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);                    
                    GL.ERRORS_CODE(result, this.stbFunctionError);                    
                }
                else
                {
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);                    
                    GL.ERRORS_CODE(result, this.stbFunctionError);                    
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

        private void btnBlockWriteAKM1_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte block_address = 0;
            byte auth_mode = 0;
            byte[] write_data = new byte[17];
            try
            {
                GL.FunctionStart = true;
                if (txtBlockWriteAKM1.Text == String.Empty)
                {
                    MessageBox.Show("You must enter any data!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBlockWriteAKM1.Focus();                    
                    return;
                }
                if (txtBWBlockAddressAKM1.Text == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBWBlockAddressAKM1.Focus();                   
                    return;
                }
                block_address = System.Convert.ToByte(txtBWBlockAddressAKM1.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;

                if (chkBWHexAKM1.Checked)
                {
                    write_data = HexConvert(txtBlockWriteAKM1.Text);
                    if (write_data[17] < 16)
                    {
                        MessageBox.Show("You must enter 16 bytes", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    write_data = System.Text.Encoding.ASCII.GetBytes(txtBlockWriteAKM1.Text);
                }
                
                unsafe
                {
                    fixed (byte* PData = write_data)
                    {
                        result = ufCoder1x.BlockWrite_AKM1(PData, block_address, auth_mode);
                    }
                }
                if (result==DL_OK) 
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);                    
                    GL.ERRORS_CODE(result, this.stbFunctionError);                    
                }
                else
                {
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);                   
                    GL.ERRORS_CODE(result, this.stbFunctionError);                    
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

        private void btnBlockWriteAKM2_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte block_address = 0;
            byte auth_mode = 0;
            byte[] write_data = new byte[17];
            try
            {
                GL.FunctionStart = true;
                if (txtBlockWriteAKM2.Text == String.Empty)
                {
                    MessageBox.Show("You must enter any data!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBlockWriteAKM2.Focus();                   
                    return;
                }
                if (txtBWBlockAddressAKM2.Text == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBWBlockAddressAKM2.Focus();                   
                    return;
                }
                block_address = System.Convert.ToByte(txtBWBlockAddressAKM2.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;

                if (chkBWHexAKM2.Checked)
                {
                    write_data = HexConvert(txtBlockWriteAKM2.Text);
                    if (write_data[17] < 16)
                    {
                        MessageBox.Show("You must enter 16 bytes", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    write_data = System.Text.Encoding.ASCII.GetBytes(txtBlockWriteAKM2.Text);
                }
                unsafe
                {
                    fixed (byte* PData = write_data)
                    {
                        result = ufCoder1x.BlockWrite_AKM2(PData, block_address, auth_mode);
                    }
                }
                if (result==DL_OK) 
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);                    
                    GL.ERRORS_CODE(result, this.stbFunctionError);                    
                }
                else
                {
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);                    
                    GL.ERRORS_CODE(result, this.stbFunctionError);                    
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

        private void btnBlockWritePK_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte block_address = 0;
            byte auth_mode = 0;
            byte[] write_data = new byte[17];
            byte[] pk_keys = new byte[6];
            try
            {
                GL.FunctionStart = true;
                if (txtBlockWritePK.Text == String.Empty)
                {
                    MessageBox.Show("You must enter any data!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBlockWritePK.Focus();                    
                    return;
                }
                if (txtBWBlockAddressPK.Text == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBWBlockAddressPK.Focus();                    
                    return;
                }
                block_address = System.Convert.ToByte(txtBWBlockAddressPK.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                if (chkBWHexPK.Checked)
                {
                    write_data = HexConvert(txtBlockWritePK.Text);
                    if (write_data[17] < 16)
                    {
                        MessageBox.Show("You must enter 16 bytes", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    write_data = System.Text.Encoding.ASCII.GetBytes(txtBlockWritePK.Text);
                }
                byte count = 0;
                foreach (Control ctrl in pnlAuth.Controls)
                {
                    if (ctrl.Name == "txtPKKey")
                    {
                        pk_keys[count] = System.Convert.ToByte(ctrl.Text);
                        count++;
                    }
                }
                unsafe
                {
                    fixed (byte* PData = write_data,PKKey=pk_keys)
                    {
                        result = ufCoder1x.BlockWrite_PK(PData, block_address, auth_mode,PKKey);
                    }
                }
                if (result==DL_OK) 
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);                    
                    GL.ERRORS_CODE(result, this.stbFunctionError);                    
                }
                else
                {
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);                    
                    GL.ERRORS_CODE(result, this.stbFunctionError);                    
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

        private void chkBRHex_CheckedChanged(object sender, EventArgs e)
        {
          // txtBlockRead.Text=ConvertToHex(bBuferrArrayCopy,(sender as CheckBox).Checked);
        }

       
        
        private byte[] HexConvert(String sTextBoxValue)
        {                                             
            byte bCounter = 0;         
            byte bBr=0;              
            byte[] bBlockData=new byte[18];
           
              
                 sTextBoxValue=Regex.Replace(sTextBoxValue, @"\s", "");                
                 while (bCounter<sTextBoxValue.Length)
                 {                                     
                   bBlockData[bBr]=Convert.ToByte(sTextBoxValue.Substring(bCounter, 2),16);             
                   bBr++;
                   bCounter+=2;                                                         
                 }                    
                                                                                                                                                                          
           bBlockData[17]=bBr;
           return bBlockData;         
        }


        private String ConvertToHex(bool chkCheck)
        {
            StringBuilder sb=new StringBuilder();
            string sString=null,sBuffer=null;

            UTF8Encoding enc=new UTF8Encoding();
            if (chkCheck)
            {
                foreach(byte bCount in bBuferrArrayCopy)
                {
                  sBuffer=bCount.ToString("X");                  
                  sb.Append(sBuffer.PadLeft(2,"0"[0]));
                  sString=sb.ToString();
                }
            }
            else
            {
                sString += enc.GetString(bBuferrArrayCopy);                
            }
            return sString;
        }



        private void chkBRHexAKM1_CheckedChanged(object sender, EventArgs e)
        {
          //  txtBlockReadAKM1.Text = ConvertToHex(bBuferrArrayCopy, (sender as CheckBox).Checked);
           
        }

        private void chkBRHexAKM2_CheckedChanged(object sender, EventArgs e)
        {
          //  txtBlockReadAKM2.Text = ConvertToHex(bBuferrArrayCopy, (sender as CheckBox).Checked);
        }

        private void chkBRHexPK_CheckedChanged(object sender, EventArgs e)
        {
          //  txtBlockReadPK.Text = ConvertToHex(bBuferrArrayCopy, (sender as CheckBox).Checked);
        }

      

       

       
        
   

      }
 
    //-----end-----   
 }



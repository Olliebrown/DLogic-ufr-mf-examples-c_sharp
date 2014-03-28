using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mifare;

namespace Mifare
{
    public partial class frmLinearReadWrite : Form
    {
        public frmLinearReadWrite()
        {
            InitializeComponent();
        }

        private UInt32 result;
        const byte AUTH1A = 96,
                   AUTH1B = 97,
                   DL_OK = 0,
                   RES_OK_LIGHT = 4,
                   RES_OK_SOUND = 4,
                   ERR_LIGHT = 2,
                   ERR_SOUND = 2;

        const int  MAX_LINEAR_BYTE=752;                  
        const string
                   CONVERT_ERROR = "You may enter only whole decimal number !",
                   APPROPRIATE_FORMAT = "You must enter the appropriate format !";

        private void frmLinearReadWrite_Load(object sender, EventArgs e)
        {

            Globals GL = new Globals();
            cboKeyIndex.SelectedItem = cboKeyIndex.Items[0];
            GL.CreatePKKey(21, 31, 4, 350, "txtPKKey", 6, false, pnlAuth);
            GL = null;
        }

        private void btnLinearRead_Click(object sender, EventArgs e)
        {
            //frmuFrAdvance RC = new frmuFrAdvance();
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return; 
           
            byte[] read_data = new byte[800];
            ushort linear_address = 0;
            ushort data_length = 0;
            ushort bytes_ret = 0;
            byte auth_mode = 0;
            byte key_index = 0;
            try
            {
                GL.FunctionStart = true;
                if (rbAUTH1A.Checked) { auth_mode = AUTH1A; } else { auth_mode = AUTH1B; };

                if (txtLinearAddress.Text == String.Empty)
                {
                    MessageBox.Show("You must enter LINEAR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLinearAddress.Focus();
                    return;
                }
                if (txtDataLength.Text == String.Empty)
                {
                    MessageBox.Show("You must enter DATA LENGTH !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDataLength.Focus();
                    return;
                }
                linear_address = Convert.ToUInt16(txtLinearAddress.Text);
                data_length = Convert.ToUInt16(txtDataLength.Text);
                key_index = System.Convert.ToByte(cboKeyIndex.Text);
             
                unsafe
                {
                    fixed (byte* PData = read_data)
                    {
                        result = ufCoder1x.LinearRead(PData, linear_address, data_length, &bytes_ret, auth_mode, key_index);
                    }
                }
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    if (chkAscii.Checked)
                    {
                        for (int br = 0; br < data_length; br++)
                        {
                            if ((char)read_data[br] < 32)
                            {
                                read_data[br] = 127;
                            }
                        }
                    }                    
                    txtLinearRead.Text = System.Text.ASCIIEncoding.ASCII.GetString(read_data);
                    txtReadBytes.Text = bytes_ret.ToString();
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
                else
                {
                    read_data[bytes_ret] = 0;
                    txtLinearRead.Text = System.Text.ASCIIEncoding.ASCII.GetString(read_data);
                    txtReadBytes.Text = bytes_ret.ToString();
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
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

        private void btnLinearReadAKM1_Click(object sender, EventArgs e)
        {
           
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;
           
            byte[] read_data = new byte[800];
            ushort linear_address = 0;
            ushort data_length = 0;
            ushort bytes_ret = 0;
            byte auth_mode = 0;
            try
            {
                GL.FunctionStart = true;
                if (rbAUTH1A.Checked) { auth_mode = AUTH1A; } else { auth_mode = AUTH1B; };

                if (txtLinearAddressAKM1.Text == String.Empty)
                {
                    MessageBox.Show("You must enter LINEAR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLinearAddressAKM1.Focus();
                    return;
                }
                if (txtDataLengthAKM1.Text == String.Empty)
                {
                    MessageBox.Show("You must enter DATA LENGTH !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDataLengthAKM1.Focus();
                    return;
                }
                linear_address = Convert.ToUInt16(txtLinearAddressAKM1.Text);
                data_length = Convert.ToUInt16(txtDataLengthAKM1.Text);

                unsafe
                {
                    fixed (byte* PData = read_data)
                    {
                        result = ufCoder1x.LinearRead_AKM1(PData, linear_address, data_length, &bytes_ret, auth_mode);
                    }
                }
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    if (chkAsciiAKM1.Checked)
                    {
                        for (int br = 0; br < data_length; br++)
                        {
                            if ((char)read_data[br] < 32)
                            {
                                read_data[br] = 127;
                            }
                        }
                    }    
                    txtLinearReadAKM1.Text = System.Text.ASCIIEncoding.ASCII.GetString(read_data);
                    txtReadBytesAKM1.Text = bytes_ret.ToString();
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
                else
                {
                    read_data[bytes_ret] = 0;
                    txtLinearReadAKM1.Text = System.Text.ASCIIEncoding.ASCII.GetString(read_data);
                    txtReadBytesAKM1.Text = bytes_ret.ToString();
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
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

        private void btnLinearReadAKM2_Click(object sender, EventArgs e)
        {
            
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte[] read_data = new byte[800];
            ushort linear_address = 0;
            ushort data_length = 0;
            ushort bytes_ret = 0;
            byte auth_mode = 0;
            try
            {
                GL.FunctionStart = true;
                if (rbAUTH1A.Checked) { auth_mode = AUTH1A; } else { auth_mode = AUTH1B; };

                if (txtLinearAddressAKM2.Text == String.Empty)
                {
                    MessageBox.Show("You must enter LINEAR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLinearAddressAKM2.Focus();
                    return;
                }
                if (txtDataLengthAKM2.Text == String.Empty)
                {
                    MessageBox.Show("You must enter DATA LENGTH !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDataLengthAKM2.Focus();
                    return;
                }
                linear_address = Convert.ToUInt16(txtLinearAddressAKM2.Text);
                data_length = Convert.ToUInt16(txtDataLengthAKM2.Text);

                unsafe
                {
                    fixed (byte* PData = read_data)
                    {
                        result = ufCoder1x.LinearRead_AKM2(PData, linear_address, data_length, &bytes_ret, auth_mode);
                    }
                }
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    if (chkAsciiAKM2.Checked)
                    {
                        for (int br = 0; br < data_length; br++)
                        {
                            if ((char)read_data[br] < 32)
                            {
                                read_data[br] = 127;
                            }
                        }
                    }
                    
                    txtLinearReadAKM2.Text = System.Text.ASCIIEncoding.ASCII.GetString(read_data);
                    txtReadBytesAKM2.Text = bytes_ret.ToString();
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
                else
                {
                    read_data[bytes_ret] = 0;
                    txtLinearReadAKM2.Text = System.Text.ASCIIEncoding.ASCII.GetString(read_data);
                    txtReadBytesAKM2.Text = bytes_ret.ToString();
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
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

        private void btnLinearReadPK_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte[] read_data = new byte[800];
            byte[] pk_key = new byte[6];
            ushort linear_address = 0;
            ushort data_length = 0;
            ushort bytes_ret = 0;
            byte auth_mode = 0;
            try
            {
                GL.FunctionStart = true;
                if (rbAUTH1A.Checked) { auth_mode = AUTH1A; } else { auth_mode = AUTH1B; };

                if (txtLinearAddressPK.Text == String.Empty)
                {
                    MessageBox.Show("You must enter LINEAR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLinearAddressPK.Focus();
                    return;
                }
                if (txtDataLengthPK.Text == String.Empty)
                {
                    MessageBox.Show("You must enter DATA LENGTH !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDataLengthPK.Focus();
                    return;
                }
                linear_address = Convert.ToUInt16(txtLinearAddressPK.Text);
                data_length = Convert.ToUInt16(txtDataLengthPK.Text);
                byte count = 0;
                for (int i = 0; i < pnlAuth.Controls.Count; ++i)
                {
                    if (pnlAuth.Controls[i].Name == "txtPKKey")
                    {
                        pk_key[count] = Convert.ToByte(pnlAuth.Controls[i].Text.ToString());
                        count++;
                    }
                }
                unsafe
                {
                    fixed (byte* PData = read_data)
                    {
                        fixed (byte* PKKey = pk_key)
                        {
                            result = ufCoder1x.LinearRead_PK(PData, linear_address, data_length, &bytes_ret, auth_mode, PKKey);
                        }
                    }
                }
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    if (chkAsciiPK.Checked)
                    {
                        for (int br = 0; br < data_length; br++)
                        {
                            if ((char)read_data[br] < 32)
                            {
                                read_data[br] = 127;
                            }
                        }
                    }
                    read_data[data_length] = 0;
                    txtLinearReadPK.Text = System.Text.ASCIIEncoding.ASCII.GetString(read_data);
                    GL.ERRORS_CODE(result, stbFunctionError);
                    txtReadBytesPK.Text = bytes_ret.ToString();
                }
                else
                {
                    read_data[bytes_ret] = 0;
                    txtLinearReadPK.Text = System.Text.ASCIIEncoding.ASCII.GetString(read_data);
                    txtReadBytesPK.Text = bytes_ret.ToString();
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
                    
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

        private void btnLinearWrite_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;
            
            byte key_index = 0;
            byte auth_mode = 0;
            ushort linear_address = 0;
            ushort data_length = 0;
            ushort bytes_ret = 0;

            try
            {
                GL.FunctionStart = true;
                if (txtLinearWrite.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any data!", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLinearWrite.Focus();
                    return;
                }
                
                if (txtLinearAddressWrite.Text == String.Empty)
                {
                    MessageBox.Show("You must enter LINEAR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLinearAddressWrite.Focus();
                    return;
                }
                if (txtDataLengthWrite.Text == String.Empty)
                {
                    MessageBox.Show("You must enter DATA LENGTH !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDataLengthWrite.Focus();
                    return;
                }
               
                key_index = System.Convert.ToByte(cboKeyIndex.Text);
                if (rbAUTH1A.Checked)
                   { auth_mode = AUTH1A; } 
                else 
                   { auth_mode = AUTH1B; };
                
                linear_address = Convert.ToUInt16(txtLinearAddressWrite.Text);
                data_length = Convert.ToUInt16(txtDataLengthWrite.Text);
              
               

                byte[] write_data = new byte[MAX_LINEAR_BYTE];
                             
                write_data = System.Text.Encoding.ASCII.GetBytes(txtLinearWrite.Text); 
               
                             
                unsafe
                {
                    fixed (byte* PData = GL.WriteArray(write_data,data_length,MAX_LINEAR_BYTE))
                    {
                        result = ufCoder1x.LinearWrite(PData, linear_address, data_length, &bytes_ret, auth_mode, key_index);
                    }
                }

                if (result == DL_OK)
                {
                    txtBytesWritten.Text = bytes_ret.ToString();
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
                else
                {
                    txtBytesWritten.Text = bytes_ret.ToString();
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

        private void btnLinearWriteAKM1_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte[] write_data = new byte[MAX_LINEAR_BYTE];
            byte auth_mode = 0;
            ushort linear_address = 0;
            ushort data_length = 0;
            ushort bytes_ret = 0;
           
            try
            {
                GL.FunctionStart = true;
                if (txtLinearWriteAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLinearWriteAKM1.Focus();
                    return;
                }
                if (txtLinearAddressWriteAKM1.Text == String.Empty)
                {
                    MessageBox.Show("You must enter LINEAR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLinearAddressWriteAKM1.Focus();
                    return;
                }
                if (txtDataLengthWriteAKM1.Text == String.Empty)
                {
                    MessageBox.Show("You must enter DATA LENGTH !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDataLengthWriteAKM1.Focus();
                    return;
                }
               
                if (rbAUTH1A.Checked) { auth_mode = AUTH1A; } else { auth_mode = AUTH1B; };
              
                linear_address = Convert.ToUInt16(txtLinearAddressWriteAKM1.Text);
                data_length = Convert.ToUInt16(txtDataLengthWriteAKM1.Text);
              
                write_data = System.Text.Encoding.ASCII.GetBytes(txtLinearWriteAKM1.Text);

                unsafe
                {
                    fixed (byte* PData = GL.WriteArray(write_data, data_length, MAX_LINEAR_BYTE))
                    {
                        result = ufCoder1x.LinearWrite_AKM1(PData, linear_address, data_length, &bytes_ret, auth_mode);
                    }
                }

                if (result == DL_OK)
                {
                    txtBytesWrittenAKM1.Text = bytes_ret.ToString();
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
                else
                {
                    txtBytesWrittenAKM1.Text = bytes_ret.ToString();
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
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

        private void btnLinearWriteAKM2_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte[] write_data = new byte[MAX_LINEAR_BYTE];
            byte auth_mode = 0;
            ushort linear_address = 0;
            ushort data_length = 0;
            ushort bytes_ret = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtLinearWriteAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLinearWriteAKM2.Focus();
                    return;
                }
                if (txtLinearAddressWriteAKM2.Text == String.Empty)
                {
                    MessageBox.Show("You must enter LINEAR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLinearAddressWriteAKM2.Focus();
                    return;
                }
                if (txtDataLengthWriteAKM2.Text == String.Empty)
                {
                    MessageBox.Show("You must enter DATA LENGTH !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDataLengthWriteAKM2.Focus();
                    return;
                }
                
                if (rbAUTH1A.Checked) { auth_mode = AUTH1A; } else { auth_mode = AUTH1B; };
                linear_address = Convert.ToUInt16(txtLinearAddressWriteAKM2.Text);
                data_length = Convert.ToUInt16(txtDataLengthWriteAKM2.Text);
               
                write_data = System.Text.Encoding.ASCII.GetBytes(txtLinearWriteAKM2.Text);

                unsafe
                {
                    fixed (byte* PData = GL.WriteArray(write_data, data_length, MAX_LINEAR_BYTE))
                    {
                        result = ufCoder1x.LinearWrite_AKM2(PData, linear_address, data_length, &bytes_ret, auth_mode);
                    }
                }

                if (result == DL_OK)
                {
                    txtBytesWrittenAKM2.Text = bytes_ret.ToString();
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
                else
                {
                    txtBytesWrittenAKM2.Text = bytes_ret.ToString();
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
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

        private void btnLinearWritePK_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte[] write_data = new byte[MAX_LINEAR_BYTE];
            byte[] pk_key = new byte[6];
            byte auth_mode = 0;
            ushort linear_address = 0;
            ushort data_length = 0;
            ushort bytes_ret = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtLinearWritePK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLinearWritePK.Focus();
                    return;
                }
                if (txtLinearAddressWritePK.Text == String.Empty)
                {
                    MessageBox.Show("You must enter LINEAR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLinearAddressWritePK.Focus();
                    return;
                }
                if (txtDataLengthWritePK.Text == String.Empty)
                {
                    MessageBox.Show("You must enter DATA LENGTH !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDataLengthWritePK.Focus();
                    return;
                }
                
                if (rbAUTH1A.Checked) { auth_mode = AUTH1A; } else { auth_mode = AUTH1B; };
                linear_address = Convert.ToUInt16(txtLinearAddressWritePK.Text);
                data_length = Convert.ToUInt16(txtDataLengthWritePK.Text);
               
                write_data = System.Text.Encoding.ASCII.GetBytes(txtLinearWritePK.Text);
                byte count = 0;
                for (int i = 0; i < pnlAuth.Controls.Count; ++i)
                {
                    if (pnlAuth.Controls[i].Name == "txtPKKey")
                    {
                        pk_key[count] = Convert.ToByte(pnlAuth.Controls[i].Text.ToString());
                        count++;
                    }
                }
                unsafe
                {
                    fixed (byte* PData = GL.WriteArray(write_data, data_length, MAX_LINEAR_BYTE))
                    {
                        fixed(byte* PKKey=pk_key)
                        {
                        result = ufCoder1x.LinearWrite_PK(PData, linear_address, data_length, &bytes_ret, auth_mode,PKKey);                
                        }
                    }
                }

                if (result == DL_OK)
                {
                    txtBytesWrittenPK.Text = bytes_ret.ToString();
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
                else
                {
                    txtBytesWrittenPK.Text = bytes_ret.ToString();
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
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
        }

    }

     
  
    




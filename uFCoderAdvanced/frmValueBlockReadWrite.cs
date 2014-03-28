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
    public partial class frmValueBlockReadWrite : Form
    {
        public frmValueBlockReadWrite()
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
        const string
                    CONVERT_ERROR = "You may enter only whole decimal number !",
                    APPROPRIATE_FORMAT = "You must enter the appropriate format !";

        private void frmValueBlockReadWrite_Load(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            cboKeyIndex.SelectedItem = cboKeyIndex.Items[0];
            GL.CreatePKKey(21, 31, 4, 350, "txtPKKey", 6, false, pnlAuth);
            GL = null;
        }

        private void btnValueBlockRead_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte block_address = 0;
            byte key_index = 0;
            byte auth_mode = 0;
            Int32 value_data=0;
            byte value_address=0;
            
            try
            {
                GL.FunctionStart = true;
                if (txtVBRBlockAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBRBlockAddress.Focus();
                    return;
                }
                key_index = System.Convert.ToByte(cboKeyIndex.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                block_address = System.Convert.ToByte(txtVBRBlockAddress.Text);
                unsafe
                {
                        Int32* PData=stackalloc Int32[1];
                        PData=&value_data;
                        result = ufCoder1x.ValueBlockRead(PData, &value_address, block_address, auth_mode, key_index);
                        PData = null;
                }
                if (result == DL_OK)
                {
                    txtVBReadValue.Text =(value_data).ToString();
                    txtVBValueAddress.Text = System.Convert.ToString(value_address);
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError); 
                }
                else
                {
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

        private void btnValueBlockReadAKM1_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte block_address = 0;
            byte auth_mode = 0;
            Int32 value_data = 0;
            byte value_address = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtVBRBlockAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBRBlockAddressAKM1.Focus();
                    return;
                }
                
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                block_address = System.Convert.ToByte(txtVBRBlockAddressAKM1.Text);
                unsafe
                {
                    Int32* PData = stackalloc int[1];
                    PData = &value_data;
                    result = ufCoder1x.ValueBlockRead_AKM1(PData, &value_address, block_address, auth_mode);
                    PData = null;
                }
                if (result == DL_OK)
                {
                    txtVBReadValueAKM1.Text = (value_data).ToString();
                    txtVBRValueAddressAKM1.Text = System.Convert.ToString(value_address);
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
                else
                {
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

        private void btnValueBlockReadAKM2_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte block_address = 0;
            byte auth_mode = 0;
            Int32 value_data = 0;
            byte value_address = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtVBRBlockAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBRBlockAddressAKM2.Focus();
                    return;
                }

                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                block_address = System.Convert.ToByte(txtVBRBlockAddressAKM2.Text);
                unsafe
                {
                    Int32* PData = stackalloc int[1];
                    PData = &value_data;
                    result = ufCoder1x.ValueBlockRead_AKM2(PData, &value_address, block_address, auth_mode);
                    PData = null;
                }
                if (result == DL_OK)
                {
                    txtVBReadValueAKM2.Text = (value_data).ToString();
                    txtVBRValueAddressAKM2.Text = System.Convert.ToString(value_address);
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
                else
                {
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

        private void btnValueBlockReadPK_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte block_address = 0;
            byte auth_mode = 0;
            Int32 value_data = 0;
            byte value_address = 0;
            byte[]pk_key=new byte[6];
            try
            {
                GL.FunctionStart = true;
                if (txtVBRBlockAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBRBlockAddressPK.Focus();
                    return;
                }

                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                block_address = System.Convert.ToByte(txtVBRBlockAddressPK.Text);
                byte count = 0;
                foreach (Control ctrl in pnlAuth.Controls)
                {
                    if (ctrl.Name == "txtPKKey")
                    {
                        pk_key[count] = System.Convert.ToByte(ctrl.Text);
                        count++;
                    }
                }
                unsafe
                {
                    Int32* PData = stackalloc Int32[1];
                    PData = &value_data;
                    fixed(byte* PK_KEY=pk_key)
                    result = ufCoder1x.ValueBlockRead_PK(PData, &value_address, block_address, auth_mode,PK_KEY);
                    PData = null;
                    
                }
                if (result == DL_OK)
                {
                    txtVBReadValuePK.Text = (value_data).ToString();
                    txtVBRValueAddressPK.Text = System.Convert.ToString(value_address);
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
                else
                {
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

        private void btnVBWrite_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte key_index = 0;
            byte auth_mode = 0;
            byte block_address = 0;
            byte value_address = 0;
            Int32 write_value = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtVBWriteValue.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBWriteValue.Focus();
                    return;
                }
                if (txtVBWValueAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter VALUE ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBWValueAddress.Focus();
                    return;
                }
                
                
                if (txtVBWBlockAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBWBlockAddress.Focus();
                    return;
                }
              
                key_index = System.Convert.ToByte(cboKeyIndex.Text);
                block_address = System.Convert.ToByte(txtVBWBlockAddress.Text);
                value_address = System.Convert.ToByte(txtVBWValueAddress.Text);
                write_value=System.Convert.ToInt32(txtVBWriteValue.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                
                    result = ufCoder1x.ValueBlockWrite(write_value, value_address, block_address, auth_mode, key_index); 
                
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
                else
                {
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

        private void btnVBWriteAKM1_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte auth_mode = 0;
            byte block_address = 0;
            byte value_address = 0;
            Int32 write_value = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtVBWriteValueAKM1.Text.Trim() == String.Empty)
                {               
                  MessageBox.Show("You must enter any value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBWriteValueAKM1.Focus();
                    return;
                }
                if (txtVBWValueAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter VALUE ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBWValueAddressAKM1.Focus();
                    return;
                }

                if (txtVBWBlockAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBWBlockAddressAKM1.Focus();
                    return;
                }
              
                block_address = System.Convert.ToByte(txtVBWBlockAddressAKM1.Text);
                value_address = System.Convert.ToByte(txtVBWValueAddressAKM1.Text);
                write_value=System.Convert.ToInt32(txtVBWriteValueAKM1.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                
                    result = ufCoder1x.ValueBlockWrite_AKM1(write_value, value_address, block_address, auth_mode); 
                
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
                else
                {
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

        private void btnVBWriteAKM2_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte auth_mode = 0;
            byte block_address = 0;
            byte value_address = 0;
            Int32 write_value = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtVBWriteValueAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBWriteValueAKM2.Focus();
                    return;
                }
                
                 if (txtVBWValueAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter VALUE ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBWValueAddressAKM2.Focus();
                    return;
                }
                if (txtVBWBlockAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBWBlockAddressAKM2.Focus();
                    return;
                }
               
                block_address = System.Convert.ToByte(txtVBWBlockAddressAKM2.Text);
                value_address = System.Convert.ToByte(txtVBWValueAddressAKM2.Text);
                write_value = System.Convert.ToInt32(txtVBWriteValueAKM2.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;

                result = ufCoder1x.ValueBlockWrite_AKM2(write_value, value_address, block_address, auth_mode);

                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);

                }
                else
                {
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

        private void btnVBWritePK_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte auth_mode = 0;
            byte block_address = 0;
            byte value_address = 0;
            Int32 write_value = 0;
            byte[]pk_key=new byte[6];
            try
            {
                GL.FunctionStart = true;
                if (txtVBWriteValuePK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBWriteValuePK.Focus();
                    return;
                }
                if (txtVBWValueAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter VALUE ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBWValueAddressPK.Focus();
                    return;
                }
                if (txtVBWBlockAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBWBlockAddressPK.Focus();
                    return;
                }
               
                block_address = System.Convert.ToByte(txtVBWBlockAddressPK.Text);
                value_address = System.Convert.ToByte(txtVBWValueAddressPK.Text);
                write_value = System.Convert.ToInt32(txtVBWriteValuePK.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                byte count=0;
                foreach(Control ctrl in pnlAuth.Controls)
                {
                    if (ctrl.Name=="txtPKKey") 
                    {
                        pk_key[count]=System.Convert.ToByte(ctrl.Text);
                        count++;
                    }
                }
                unsafe
                {
                    fixed (byte* PK_KEY = pk_key)
                    {
                        result = ufCoder1x.ValueBlockWrite_PK(write_value, value_address, block_address, auth_mode, PK_KEY);
                    }
                }
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
                else
                {
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mifare
{
    public partial class frmValueBlockInSectorReadWrite : Form
    {
        public frmValueBlockInSectorReadWrite()
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

        private void frmValueBlockInSectorReadWrite_Load(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            cboKeyIndex.SelectedItem = cboKeyIndex.Items[0];
            GL.CreatePKKey(21, 31, 4, 350, "txtPKKey", 6, false, pnlAuth);
            GL = null;
        }

        private void btnVBISRead_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;
            byte key_index = 0;
            byte auth_mode = 0;
            byte value_address = 0;
            byte sector_address = 0;
            byte block_address = 0;
            Int32 read_data = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtVBISRSectorAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISRSectorAddress.Focus();
                    return;
                }
                if (txtVBISRBlockAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISRBlockAddress.Focus();
                    return;
                }
                key_index = System.Convert.ToByte(cboKeyIndex.Text);
                sector_address = System.Convert.ToByte(txtVBISRSectorAddress.Text);
                block_address = System.Convert.ToByte(txtVBISRBlockAddress.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                unsafe
                {
                    Int32* PData=stackalloc Int32[1];
                    PData = &read_data;
                    result = ufCoder1x.ValueBlockInSectorRead(PData, &value_address, sector_address, block_address, auth_mode, key_index);
                    PData = null;
                }
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    txtVBISReadData.Text = read_data.ToString();
                    txtVBISRValueAddress.Text = value_address.ToString();
                    GL.ERRORS_CODE(result, stbFunctionError);
                }
                else
                {
                    ufCoder1x.ReaderUISignal(ERR_LIGHT,ERR_SOUND);
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

        private void btnVBISReadAKM1_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte auth_mode = 0;
            byte value_address = 0;
            byte sector_address = 0;
            byte block_address = 0;
            Int32 read_data = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtVBISRSectorAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISRSectorAddressAKM1.Focus();
                    return;
                }
                if (txtVBISRBlockAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISRBlockAddressAKM1.Focus();
                    return;
                }
                sector_address = System.Convert.ToByte(txtVBISRSectorAddressAKM1.Text);
                block_address = System.Convert.ToByte(txtVBISRBlockAddressAKM1.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                unsafe
                {
                    Int32* PData = stackalloc Int32[1];
                    PData = &read_data;
                    result = ufCoder1x.ValueBlockInSectorRead_AKM1(PData, &value_address, sector_address, block_address, auth_mode);
                    PData = null;
                }
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    txtVBISReadDataAKM1.Text = read_data.ToString();
                    txtVBISRValueAddressAKM1.Text = value_address.ToString();
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

        private void btnVBISReadAKM2_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte auth_mode = 0;
            byte value_address = 0;
            byte sector_address = 0;
            byte block_address = 0;
            Int32 read_data = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtVBISRSectorAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISRSectorAddressAKM2.Focus();
                    return;
                }
                if (txtVBISRBlockAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISRBlockAddressAKM2.Focus();
                    return;
                }
                sector_address = System.Convert.ToByte(txtVBISRSectorAddressAKM2.Text);
                block_address = System.Convert.ToByte(txtVBISRBlockAddressAKM2.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                unsafe
                {
                    Int32* PData = stackalloc Int32[1];
                    PData = &read_data;
                    result = ufCoder1x.ValueBlockInSectorRead_AKM2(PData, &value_address, sector_address, block_address, auth_mode);
                    PData = null;
                }
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    txtVBISReadDataAKM2.Text = read_data.ToString();
                    txtVBISRValueAddressAKM2.Text = value_address.ToString();
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

        private void btnVBISReadPK_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte auth_mode = 0;
            byte value_address = 0;
            byte sector_address = 0;
            byte block_address = 0;
            Int32 read_data = 0;
            byte[] pk_key = new byte[6];
            try
            {
                GL.FunctionStart = true;
                if (txtVBISRSectorAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISRSectorAddressPK.Focus();
                    return;
                }
                if (txtVBISRBlockAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISRBlockAddressPK.Focus();
                    return;
                }
                sector_address = System.Convert.ToByte(txtVBISRSectorAddressPK.Text);
                block_address = System.Convert.ToByte(txtVBISRBlockAddressPK.Text);
                byte count = 0;
                foreach (Control ctrl in pnlAuth.Controls)
                {
                    if (ctrl.Name == "txtPKKey")
                    {
                        pk_key[count] = System.Convert.ToByte(ctrl.Text);
                        count++;
                    }
                }
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                unsafe
                {
                    Int32* PData = stackalloc Int32[1];
                    PData = &read_data;
                    fixed (byte* PK_KEY = pk_key) 
                    result = ufCoder1x.ValueBlockInSectorRead_PK(PData, &value_address, sector_address, block_address, auth_mode,PK_KEY);
                    PData = null;
                }
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    txtVBISReadDataPK.Text = read_data.ToString();
                    txtVBISRValueAddressPK.Text = value_address.ToString();
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

        private void btnBISWrite_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte key_index = 0;
            byte auth_mode = 0;
            byte value_address = 0;
            byte sector_address = 0;
            byte block_address = 0;
            Int32 write_data = 0;
            try
            {
                GL.FunctionStart = true;
            if (txtVBISWWriteData.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWWriteData.Focus();
                return;
            }
            if (txtVBISWSectorAddress.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWSectorAddress.Focus();
                return;
            }
            if (txtVBISWBlockAddress.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWBlockAddress.Focus();
                return;
            }
            if (txtVBISWValueAddress.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter VALUE ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWValueAddress.Focus();
                return;
            }
            
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                key_index = System.Convert.ToByte(cboKeyIndex.Text);
                write_data = System.Convert.ToInt32(txtVBISWWriteData.Text);
                sector_address = System.Convert.ToByte(txtVBISWSectorAddress.Text);
                block_address = System.Convert.ToByte(txtVBISWBlockAddress.Text);
                value_address = System.Convert.ToByte(txtVBISWValueAddress.Text);
                result = ufCoder1x.ValueBlockInSectorWrite(write_data, value_address, sector_address, block_address, auth_mode, key_index);
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

        private void btnBISWriteAKM1_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte auth_mode = 0;
            byte value_address = 0;
            byte sector_address = 0;
            byte block_address = 0;
            Int32 write_data = 0;
            try
            {
                GL.FunctionStart = true;
            if (txtVBISWWriteDataAKM1.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWWriteDataAKM1.Focus();
                return;
            }
            if (txtVBISWSectorAddressAKM1.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWSectorAddressAKM1.Focus();
                return;
            }
            if (txtVBISWBlockAddressAKM1.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWBlockAddressAKM1.Focus();
                return;
            }
            if (txtVBISWValueAddressAKM1.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter VALUE ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWValueAddressAKM1.Focus();
                return;
            }
           
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
      
                write_data = System.Convert.ToInt32(txtVBISWWriteDataAKM1.Text);
                sector_address = System.Convert.ToByte(txtVBISWSectorAddressAKM1.Text);
                block_address = System.Convert.ToByte(txtVBISWBlockAddressAKM1.Text);
                value_address = System.Convert.ToByte(txtVBISWValueAddressAKM1.Text);
                result = ufCoder1x.ValueBlockInSectorWrite_AKM1(write_data, value_address, sector_address, block_address, auth_mode);
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

        private void btnBISWriteAKM2_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;
            byte auth_mode = 0;
            byte value_address = 0;
            byte sector_address = 0;
            byte block_address = 0;
            Int32 write_data = 0;
            try
            {
                GL.FunctionStart = true;
            if (txtVBISWWriteDataAKM2.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWWriteDataAKM2.Focus();
                return;
            }
            if (txtVBISWSectorAddressAKM2.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWSectorAddressAKM2.Focus();
                return;
            }
            if (txtVBISWBlockAddressAKM2.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWBlockAddressAKM2.Focus();
                return;
            }
            if (txtVBISWValueAddressAKM2.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter VALUE ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWValueAddressAKM2.Focus();
                return;
            }
           
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;

                write_data = System.Convert.ToInt32(txtVBISWWriteDataAKM2.Text);
                sector_address = System.Convert.ToByte(txtVBISWSectorAddressAKM2.Text);
                block_address = System.Convert.ToByte(txtVBISWBlockAddressAKM2.Text);
                value_address = System.Convert.ToByte(txtVBISWValueAddressAKM2.Text);
                result = ufCoder1x.ValueBlockInSectorWrite_AKM2(write_data, value_address, sector_address, block_address, auth_mode);
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

        private void btnVBISWritePK_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;
            byte auth_mode = 0;
            byte value_address = 0;
            byte sector_address = 0;
            byte block_address = 0;
            Int32 write_data = 0;
            byte[] pk_key=new byte[6];
            try
            {
                GL.FunctionStart = true;
            if (txtVBISWWriteDataPK.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWWriteDataPK.Focus();
                return;
            }
            if (txtVBISWSectorAddressPK.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWSectorAddressPK.Focus();
                return;
            }
            if (txtVBISWBlockAddressPK.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWBlockAddressPK.Focus();
                return;
            }
            if (txtVBISWValueAddressPK.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must enter VALUE ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVBISWValueAddressPK.Focus();
                return;
            }
            
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;

                write_data = System.Convert.ToInt32(txtVBISWWriteDataPK.Text);
                sector_address = System.Convert.ToByte(txtVBISWSectorAddressPK.Text);
                block_address = System.Convert.ToByte(txtVBISWBlockAddressPK.Text);
                value_address = System.Convert.ToByte(txtVBISWValueAddressPK.Text);
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
                    fixed(byte* PK_KEY=pk_key)
                    result = ufCoder1x.ValueBlockInSectorWrite_PK(write_data, value_address, sector_address, block_address, auth_mode, PK_KEY);
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

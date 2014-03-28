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
    public partial class frmBlockInSectorReadWrite : Form
    {
        public frmBlockInSectorReadWrite()
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

        private void frmBlockInSectorReadWrite_Load(object sender, EventArgs e)
        {
            Globals GB = new Globals();
            cboKeyIndex.SelectedItem = cboKeyIndex.Items[0];
            GB.CreatePKKey(21, 31, 4, 350, "txtPKKey", 6, false, pnlAuth);
            GB = null;
        }

        private void btnBISReadData_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte sector_address = 0;
            byte block_address = 0;
            byte auth_mode = 0;
            byte key_index = 0;
            byte[] read_data = new byte[16];
            try
            {
                GL.FunctionStart = true;
                if (txtBISRSectorAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISRSectorAddress.Focus();
                    return;
                }
                if (txtBISRBlockAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISRBlockAddress.Focus();
                    return;
                }
                sector_address = System.Convert.ToByte(txtBISRSectorAddress.Text);
                block_address = System.Convert.ToByte(txtBISRBlockAddress.Text);
                key_index = System.Convert.ToByte(cboKeyIndex.Text);
                txtBISReadData.Text = "";
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                unsafe
                {
                    fixed (byte* PData = read_data)
                    {
                        result = ufCoder1x.BlockInSectorRead(PData, sector_address, block_address, auth_mode, key_index);
                    }
                }
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);                   
                    GL.ERRORS_CODE(result, stbFunctionError);                    
                    if (chkBISRAscii.Checked)
                    {
                        for (byte br = 0; br < 16; ++br)
                        {
                            if ((char)read_data[br] < 32) read_data[br] = 127;
                        }
                    }
                    txtBISReadData.Text =System.Text.Encoding.ASCII.GetString(read_data);
                }
                else
                {
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);                    
                    GL.ERRORS_CODE(result,stbFunctionError);                     
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
                GL.FunctionStart = false;
                GL = null;
            }          

        }

        private void btnBISReadDataAKM1_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte sector_address = 0;
            byte block_address = 0;
            byte auth_mode = 0;           
            byte[] read_data = new byte[16];
            try
            {
                GL.FunctionStart = true;
                if (txtBISRSectorAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISRSectorAddressAKM1.Focus();
                    return;
                }
                if (txtBISRBlockAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISRBlockAddressAKM1.Focus();
                    return;
                }
                sector_address = System.Convert.ToByte(txtBISRSectorAddressAKM1.Text);
                block_address = System.Convert.ToByte(txtBISRBlockAddressAKM1.Text);
            //    txtBISReadDataAKM1.Text = "";
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                unsafe
                {
                    fixed (byte* PData = read_data)
                    {
                        result = ufCoder1x.BlockInSectorRead_AKM1(PData, sector_address, block_address, auth_mode);
                    }
                }
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);                    
                    GL.ERRORS_CODE(result, stbFunctionError);                   
                    if (chkBISRAsciiAKM1.Checked)
                    {
                        for (byte br = 0; br < 16; ++br)
                        {
                            if ((char)read_data[br] < 32) read_data[br] = 127;
                        }
                    }
                    txtBISReadDataAKM1.Text = System.Text.Encoding.ASCII.GetString(read_data);
                }
                else
                {
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
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
                GL.FunctionStart = false;
                GL = null;
            }       

        }

        private void btnBISReadDataAKM2_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte sector_address = 0;
            byte block_address = 0;
            byte auth_mode = 0;
            byte[] read_data = new byte[16];
            try
            {
                GL.FunctionStart = true;
                if (txtBISRSectorAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISRSectorAddressAKM2.Focus();
                    return;
                }
                if (txtBISRBlockAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISRBlockAddressAKM2.Focus();
                    return;
                }
                sector_address = System.Convert.ToByte(txtBISRSectorAddressAKM2.Text);
                block_address = System.Convert.ToByte(txtBISRBlockAddressAKM2.Text);
            //    txtBISReadDataAKM2.Text = "";
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                unsafe
                {
                    fixed (byte* PData = read_data)
                    {
                        result = ufCoder1x.BlockInSectorRead_AKM2(PData, sector_address, block_address, auth_mode);
                    }
                }
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);                    
                    GL.ERRORS_CODE(result, stbFunctionError);                    
                    if (chkBISRAsciiAKM2.Checked)
                    {
                        for (byte br = 0; br < 16; ++br)
                        {
                            if ((char)read_data[br] < 32) read_data[br] = 127;
                        }
                    }
                    txtBISReadDataAKM2.Text = System.Text.Encoding.ASCII.GetString(read_data);
                }
                else
                {
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
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
                GL.FunctionStart = false;
                GL = null;
            }    

        }

        private void btnBISReadDataPK_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte sector_address = 0;
            byte block_address = 0;
            byte auth_mode = 0;
            byte[] read_data = new byte[16];
            byte[] pk_key = new byte[6];
            try
            {
                GL.FunctionStart = true;
                if (txtBISRSectorAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISRSectorAddressPK.Focus();
                    return;
                }
                if (txtBISRBlockAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISRBlockAddressPK.Focus();
                    return;
                }
                sector_address = System.Convert.ToByte(txtBISRSectorAddressPK.Text);
                block_address = System.Convert.ToByte(txtBISRBlockAddressPK.Text);
               // txtBISReadDataPK.Text = "";
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                byte count = 0;
                foreach (Control cont in pnlAuth.Controls)
                {
                    if (cont.Name == "txtPKKey")
                    {
                        pk_key[count] =System.Convert.ToByte(cont.Text);
                        count++;
                    }
                }
                unsafe
                {
                    fixed (byte* PData = read_data,PPK_KEY=pk_key)
                    {
                        result = ufCoder1x.BlockInSectorRead_PK(PData, sector_address, block_address, auth_mode,PPK_KEY);
                    }
                }
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);                    
                    GL.ERRORS_CODE(result, stbFunctionError);                   
                    if (chkBISRAsciiPK.Checked)
                    {
                        for (byte br = 0; br < 16; ++br)
                        {
                            if ((char)read_data[br] < 32) read_data[br] = 127;
                        }
                    }
                    txtBISReadDataPK.Text = System.Text.Encoding.ASCII.GetString(read_data);
                }
                else
                {
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);
                    GL.ERRORS_CODE(result, stbFunctionError);
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
                GL.FunctionStart = false;
                GL = null;
            }      

        }

        private void btnBISWrite_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte[] write_data = new byte[16];
            byte key_index = 0;
            byte sector_address = 0;
            byte block_address = 0;
            byte auth_mode = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtBISWWriteData.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISWWriteData.Focus();
                    return;
                }
                if (txtBISWSectorAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISWSectorAddress.Focus();
                    return;
                }
                if (txtBISWBlockAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISWBlockAddress.Focus();
                    return;
                }
                key_index = System.Convert.ToByte(cboKeyIndex.Text);
                sector_address = System.Convert.ToByte(txtBISWSectorAddress.Text);
                block_address = System.Convert.ToByte(txtBISWBlockAddress.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;

                write_data = System.Text.Encoding.ASCII.GetBytes(txtBISWWriteData.Text);
                unsafe
                {
                    fixed (byte* PData = write_data)
                    {
                        result = ufCoder1x.BlockInSectorWrite(PData, sector_address, block_address, auth_mode, key_index);
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

        private void btnBISWriteAKM1_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte[] write_data = new byte[16];
            byte sector_address = 0;
            byte block_address = 0;
            byte auth_mode = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtBISWWriteDataAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISWWriteDataAKM1.Focus();
                    return;
                }
                if (txtBISWSectorAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISWSectorAddressAKM1.Focus();
                    return;
                }
                if (txtBISWBlockAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISWBlockAddressAKM1.Focus();
                    return;
                }
                sector_address = System.Convert.ToByte(txtBISWSectorAddressAKM1.Text);
                block_address = System.Convert.ToByte(txtBISWBlockAddressAKM1.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;

                write_data = System.Text.Encoding.ASCII.GetBytes(txtBISWWriteDataAKM1.Text);
                unsafe
                {
                    fixed (byte* PData = write_data)
                    {
                        result = ufCoder1x.BlockInSectorWrite_AKM1(PData, sector_address, block_address, auth_mode);
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

        private void btnBISWriteAKM2_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte[] write_data = new byte[16];
            byte sector_address = 0;
            byte block_address = 0;
            byte auth_mode = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtBISWWriteDataAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISWWriteDataAKM2.Focus();
                    return;
                }
                if (txtBISWSectorAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISWSectorAddressAKM2.Focus();
                    return;
                }
                if (txtBISWBlockAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISWBlockAddressAKM2.Focus();
                    return;
                }
                sector_address = System.Convert.ToByte(txtBISWSectorAddressAKM2.Text);
                block_address = System.Convert.ToByte(txtBISWBlockAddressAKM2.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;

                write_data = System.Text.Encoding.ASCII.GetBytes(txtBISWWriteDataAKM2.Text);
                unsafe
                {
                    fixed (byte* PData = write_data)
                    {
                        result = ufCoder1x.BlockInSectorWrite_AKM2(PData, sector_address, block_address, auth_mode);
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

        private void btnBISWritePK_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte[] write_data = new byte[16];
            byte[] pk_key = new byte[6];
            byte sector_address = 0;
            byte block_address = 0;
            byte auth_mode = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtBISWWriteDataPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISWWriteDataPK.Focus();
                    return;
                }
                if (txtBISWSectorAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISWSectorAddressPK.Focus();
                    return;
                }
                if (txtBISWBlockAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBISWBlockAddressPK.Focus();
                    return;
                }
                sector_address = System.Convert.ToByte(txtBISWSectorAddressPK.Text);
                block_address = System.Convert.ToByte(txtBISWBlockAddressPK.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;

                write_data = System.Text.Encoding.ASCII.GetBytes(txtBISWWriteDataPK.Text);
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
                    fixed (byte* PData = write_data,PK_KEY=pk_key)
                    {
                        result = ufCoder1x.BlockInSectorWrite_PK(PData, sector_address, block_address, auth_mode,PK_KEY);
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

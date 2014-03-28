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
    public partial class frmValueBlockInSectorIncremDecrem : Form
    {
        public frmValueBlockInSectorIncremDecrem()
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

        private void frmValueBlockInSectorIncremDecrem_Load(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            cboKeyIndex.SelectedItem = cboKeyIndex.Items[0];
            GL.CreatePKKey(21, 31, 4, 350, "txtPKKey", 6, false, pnlAuth);
            GL = null;
        }

        private void btnVBISIncrement_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;
            byte key_index = 0;
            byte auth_mode = 0;
            byte sector_address = 0;
            byte block_address = 0;
            Int32 increment_value = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtVBISIncrementValue.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISIncrementValue.Focus();
                    return;
                }
                if (txtVBISIncrSectorAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISIncrSectorAddress.Focus();
                    return;
                }
                if (txtVBISIncrBlockAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISIncrBlockAddress.Focus();
                    return;
                }
                key_index = System.Convert.ToByte(cboKeyIndex.Text);
                increment_value = System.Convert.ToInt32(txtVBISIncrementValue.Text);
                sector_address = System.Convert.ToByte(txtVBISIncrSectorAddress.Text);
                block_address = System.Convert.ToByte(txtVBISIncrBlockAddress.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;

                result = ufCoder1x.ValueBlockInSectorIncrement(increment_value, sector_address, block_address, auth_mode, key_index);
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
            catch(System.FormatException ex)
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

        private void btnVBISIncrementAKM1_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte auth_mode = 0;
            byte sector_address = 0;
            byte block_address = 0;
            Int32 increment_value = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtVBISIncrementValueAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISIncrementValueAKM1.Focus();
                    return;
                }
                if (txtVBISIncrSectorAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISIncrSectorAddressAKM1.Focus();
                    return;
                }
                if (txtVBISIncrBlockAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISIncrBlockAddressAKM1.Focus();
                    return;
                }
                
                increment_value = System.Convert.ToInt32(txtVBISIncrementValueAKM1.Text);
                sector_address = System.Convert.ToByte(txtVBISIncrSectorAddressAKM1.Text);
                block_address = System.Convert.ToByte(txtVBISIncrBlockAddressAKM1.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;

                result = ufCoder1x.ValueBlockInSectorIncrement_AKM1(increment_value, sector_address, block_address, auth_mode);
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

        private void btnVBISIncrementAKM2_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte auth_mode = 0;
            byte sector_address = 0;
            byte block_address = 0;
            Int32 increment_value = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtVBISIncrementValueAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISIncrementValueAKM2.Focus();
                    return;
                }
                if (txtVBISIncrSectorAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISIncrSectorAddressAKM2.Focus();
                    return;
                }
                if (txtVBISIncrBlockAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISIncrBlockAddressAKM2.Focus();
                    return;
                }
                increment_value = System.Convert.ToInt32(txtVBISIncrementValueAKM2.Text);
                sector_address = System.Convert.ToByte(txtVBISIncrSectorAddressAKM2.Text);
                block_address = System.Convert.ToByte(txtVBISIncrBlockAddressAKM2.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;

                result = ufCoder1x.ValueBlockInSectorIncrement_AKM2(increment_value, sector_address, block_address, auth_mode);
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

        private void btnVBISIncrementPK_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            byte auth_mode = 0;
            byte sector_address = 0;
            byte block_address = 0;
            Int32 increment_value = 0;
            byte[] pk_key = new byte[6];
            try
            {
                GL.FunctionStart = true;
                if (txtVBISIncrementValuePK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISIncrementValuePK.Focus();
                    return;
                }
                if (txtVBISIncrSectorAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISIncrSectorAddressPK.Focus();
                    return;
                }
                if (txtVBISIncrBlockAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISIncrBlockAddressPK.Focus();
                    return;
                }
                
                increment_value = System.Convert.ToInt32(txtVBISIncrementValuePK.Text);
                sector_address = System.Convert.ToByte(txtVBISIncrSectorAddressPK.Text);
                block_address = System.Convert.ToByte(txtVBISIncrBlockAddressPK.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
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
                    result = ufCoder1x.ValueBlockInSectorIncrement_PK(increment_value, sector_address, block_address, auth_mode, PK_KEY);
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

        private void btnVBISDecrement_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            Int32 decrement_value = 0;
            byte key_index = 0;
            byte sector_address = 0;
            byte block_address = 0;
            byte auth_mode = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtVBISDecrValue.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISDecrValue.Focus();
                    return;
                }

                if (txtVBISDecrSectorAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISDecrSectorAddress.Focus();
                    return;
                }
                if (txtVBISDecrBlockAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISDecrBlockAddress.Focus();
                    return;
                }
                key_index = System.Convert.ToByte(cboKeyIndex.Text);
                decrement_value = System.Convert.ToInt32(txtVBISDecrValue.Text);
                sector_address = System.Convert.ToByte(txtVBISDecrSectorAddress.Text);
                block_address = System.Convert.ToByte(txtVBISDecrBlockAddress.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;

                result = ufCoder1x.ValueBlockInSectorDecrement(decrement_value, sector_address, block_address, auth_mode, key_index);
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

        private void btnVBISDecrementAKM1_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            Int32 decrement_value = 0;
            byte sector_address = 0;
            byte block_address = 0;
            byte auth_mode = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtVBISDecrValueAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISDecrValueAKM1.Focus();
                    return;
                }

                if (txtVBISDecrSectorAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISDecrSectorAddressAKM1.Focus();
                    return;
                }
                if (txtVBISDecrBlockAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISDecrBlockAddressAKM1.Focus();
                    return;
                }
                decrement_value = System.Convert.ToInt32(txtVBISDecrValueAKM1.Text);
                sector_address = System.Convert.ToByte(txtVBISDecrSectorAddressAKM1.Text);
                block_address = System.Convert.ToByte(txtVBISDecrBlockAddressAKM1.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;

                result = ufCoder1x.ValueBlockInSectorDecrement_AKM1(decrement_value, sector_address, block_address, auth_mode);
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

        private void btnVBISDecrementAKM2_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            Int32 decrement_value = 0;
            byte sector_address = 0;
            byte block_address = 0;
            byte auth_mode = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtVBISDecrValueAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISDecrValueAKM2.Focus();
                    return;
                }

                if (txtVBISDecrSectorAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISDecrSectorAddressAKM2.Focus();
                    return;
                }
                if (txtVBISDecrBlockAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISDecrBlockAddressAKM2.Focus();
                    return;
                }
                decrement_value = System.Convert.ToInt32(txtVBISDecrValueAKM2.Text);
                sector_address = System.Convert.ToByte(txtVBISDecrSectorAddressAKM2.Text);
                block_address = System.Convert.ToByte(txtVBISDecrBlockAddressAKM2.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;

                result = ufCoder1x.ValueBlockInSectorDecrement_AKM2(decrement_value, sector_address, block_address, auth_mode);
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

        private void btnVBISDecrementPK_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            Int32 decrement_value = 0;
            byte sector_address = 0;
            byte block_address = 0;
            byte auth_mode = 0;
            byte[] pk_key = new byte[6];
            try
            {
                GL.FunctionStart = true;
                if (txtVBISDecrValuePK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISDecrValuePK.Focus();
                    return;
                }

                if (txtVBISDecrSectorAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISDecrSectorAddressPK.Focus();
                    return;
                }
                if (txtVBISDecrBlockAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISDecrBlockAddressPK.Focus();
                    return;
                }
                decrement_value = System.Convert.ToInt32(txtVBISDecrValuePK.Text);
                sector_address = System.Convert.ToByte(txtVBISDecrSectorAddressPK.Text);
                block_address = System.Convert.ToByte(txtVBISDecrBlockAddressPK.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
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
                    fixed (byte* PK_KEY = pk_key)
                        result = ufCoder1x.ValueBlockInSectorDecrement_PK(decrement_value, sector_address, block_address, auth_mode, PK_KEY);
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

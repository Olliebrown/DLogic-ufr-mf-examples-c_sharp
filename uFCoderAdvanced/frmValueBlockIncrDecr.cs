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
    public partial class frmValueBlockIncrDecr : Form
    {
        public frmValueBlockIncrDecr()
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
        private void frmValueBlockIncrDecr_Load(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            cboKeyIndex.SelectedItem = cboKeyIndex.Items[0];
            GL.CreatePKKey(21, 31, 4, 350, "txtPKKey", 6, false, pnlAuth);
            GL = null;
        }

        private void btnIncrement_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            Int32 value_increment = 0;
            byte block_address = 0;
            byte key_index = 0;
            byte auth_mode = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtVBIncrementValue.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter increment value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBIncrementValue.Focus();
                    return;
                }
                if (txtBlockAddressIncr.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBlockAddressIncr.Focus();
                    return;
                }
                value_increment = System.Convert.ToInt32(txtVBIncrementValue.Text);
                block_address = System.Convert.ToByte(txtBlockAddressIncr.Text);
                key_index = System.Convert.ToByte(cboKeyIndex.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                result = ufCoder1x.ValueBlockIncrement(value_increment, block_address, auth_mode, key_index);
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

        private void btnIncrementAKM1_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            Int32 value_increment = 0;
            byte block_address = 0;
            byte auth_mode = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtVBIncrementValueAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter increment value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBIncrementValueAKM1.Focus();
                    return;
                }
                if (txtBlockAddressIncrAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBlockAddressIncrAKM1.Focus();
                    return;
                }
                value_increment = System.Convert.ToInt32(txtVBIncrementValueAKM1.Text);
                block_address = System.Convert.ToByte(txtBlockAddressIncrAKM1.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                result = ufCoder1x.ValueBlockIncrement_AKM1(value_increment, block_address, auth_mode);
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

        private void btnIncrementAKM2_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            Int32 value_increment = 0;
            byte block_address = 0;
            byte auth_mode = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtVBIncrementValueAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter increment value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBIncrementValueAKM2.Focus();
                    return;
                }
                if (txtBlockAddressIncrAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBlockAddressIncrAKM2.Focus();
                    return;
                }
                value_increment = System.Convert.ToInt32(txtVBIncrementValueAKM2.Text);
                block_address = System.Convert.ToByte(txtBlockAddressIncrAKM2.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                result = ufCoder1x.ValueBlockIncrement_AKM2(value_increment, block_address, auth_mode);
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

        private void btnIncrementPK_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            Int32 value_increment = 0;
            byte block_address = 0;
            byte auth_mode = 0;
            byte[] pk_key = new byte[6];
            try
            {
                GL.FunctionStart = true;
                if (txtVBIncrementValuePK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter increment value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBIncrementValuePK.Focus();
                    return;
                }
                if (txtBlockAddressIncrPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBlockAddressIncrPK.Focus();
                    return;
                }
                value_increment = System.Convert.ToInt32(txtVBIncrementValuePK.Text);
                block_address = System.Convert.ToByte(txtBlockAddressIncrPK.Text);
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
                        result = ufCoder1x.ValueBlockIncrement_PK(value_increment, block_address, auth_mode, PK_KEY);
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

        private void btnDecrement_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            Int32 value_decrement = 0;
            byte block_address = 0;
            byte key_index = 0;
            byte auth_mode = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtVBDecrement.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter decrement value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBDecrement.Focus();
                    return;
                }
                if (txtVBDecrBlockAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBDecrBlockAddress.Focus();
                    return;
                }
                value_decrement = System.Convert.ToInt32(txtVBDecrement.Text);
                block_address = System.Convert.ToByte(txtVBDecrBlockAddress.Text);
                key_index = System.Convert.ToByte(cboKeyIndex.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                result = ufCoder1x.ValueBlockDecrement(value_decrement, block_address, auth_mode, key_index);
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

        private void btnDecrementAKM1_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            Int32 value_decrement = 0;
            byte block_address = 0;
            byte auth_mode = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtVBDecrementAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter decrement value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBDecrementAKM1.Focus();
                    return;
                }
                if (txtVBDecrBlockAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBDecrBlockAddressAKM1.Focus();
                    return;
                }
                value_decrement = System.Convert.ToInt32(txtVBDecrementAKM1.Text);
                block_address = System.Convert.ToByte(txtVBDecrBlockAddressAKM1.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                result = ufCoder1x.ValueBlockDecrement_AKM1(value_decrement, block_address, auth_mode);
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

        private void btnDecrementAKM2_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;

            Int32 value_decrement = 0;
            byte block_address = 0;
            byte auth_mode = 0;
            try
            {
                GL.FunctionStart = true;
                if (txtVBDecrementAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter decrement value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBDecrementAKM2.Focus();
                    return;
                }
                if (txtVBDecrBlockAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBDecrBlockAddressAKM2.Focus();
                    return;
                }
                value_decrement = System.Convert.ToInt32(txtVBDecrementAKM2.Text);
                block_address = System.Convert.ToByte(txtVBDecrBlockAddressAKM2.Text);
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                result = ufCoder1x.ValueBlockDecrement_AKM2(value_decrement, block_address, auth_mode);
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

        private void btnDecrementPK_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;
            Int32 value_decrement = 0;
            byte block_address = 0;
            byte auth_mode = 0;
            byte[] pk_key = new byte[6];
            try
            {
                GL.FunctionStart = true;
                if (txtVBDecrementPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter decrement value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBDecrementPK.Focus();
                    return;
                }
                if (txtVBDecrBlockAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBDecrBlockAddressPK.Focus();
                    return;
                }
                value_decrement = System.Convert.ToInt32(txtVBDecrementPK.Text);
                block_address = System.Convert.ToByte(txtVBDecrBlockAddressPK.Text);
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
                        result = ufCoder1x.ValueBlockDecrement_PK(value_decrement, block_address, auth_mode, PK_KEY);
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

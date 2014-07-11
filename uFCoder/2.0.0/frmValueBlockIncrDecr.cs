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
    public partial class frmValueBlockIncrDecr : Form
    {
        private
               Globals GL = new Globals();
        public frmValueBlockIncrDecr()
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

        const string CONVERT_ERROR      = "You may enter only whole decimal number !",
                     APPROPRIATE_FORMAT = "You must enter the appropriate format !";

        private void frmValueBlockIncrDecr_Load(object sender, EventArgs e)
        {
             
            cboKeyIndex.SelectedItem = cboKeyIndex.Items[0];
            GL.CreatePKKey(21, 31, 4, 350, "txtPKKey", 6, false, pnlAuth);
             
        }

        private void btnIncrement_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iValueIncrement      = 0;
                UInt16 uiBlockAddress      = 0;
                byte bKeyIndex             = 0;                
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
            
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

                iValueIncrement      = System.Convert.ToInt32(txtVBIncrementValue.Text);
                uiBlockAddress       = System.Convert.ToUInt16(txtBlockAddressIncr.Text);
                bKeyIndex            = System.Convert.ToByte(cboKeyIndex.Text);
                
                iFResult = uFCoder1x.ValueBlockIncrement(iValueIncrement, uiBlockAddress, bAuthMode, bKeyIndex);

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

        private void btnIncrementAKM1_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iValueIncrement      = 0;
                UInt16 uiBlockAddress      = 0;                                
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;

                if (txtVBIncrementValueAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter increment value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBIncrementValueAKM1.Focus();
                    return;
                }
                if (txtBlockAddressIncrAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBlockAddressIncrAKM1.Focus();
                    return;
                }
                iValueIncrement      = System.Convert.ToInt32(txtVBIncrementValueAKM1.Text);
                uiBlockAddress       = System.Convert.ToUInt16(txtBlockAddressIncrAKM1.Text);

                iFResult = uFCoder1x.ValueBlockIncrement_AKM1(iValueIncrement, uiBlockAddress, bAuthMode);
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

        private void btnIncrementAKM2_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iValueIncrement      = 0;
                UInt16 uiBlockAddress      = 0;                                
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;

                if (txtVBIncrementValueAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter increment value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBIncrementValueAKM2.Focus();
                    return;
                }
                if (txtBlockAddressIncrAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBlockAddressIncrAKM2.Focus();
                    return;
                }
                iValueIncrement      = System.Convert.ToInt32(txtVBIncrementValueAKM2.Text);
                uiBlockAddress       = System.Convert.ToUInt16(txtBlockAddressIncrAKM2.Text);

                iFResult = uFCoder1x.ValueBlockIncrement_AKM2(iValueIncrement, uiBlockAddress, bAuthMode);
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

        private void btnIncrementPK_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iValueIncrement      = 0;
                UInt16 uiBlockAddress      = 0;
                byte bCounter              = 0;                               
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                byte[] baKeyPK             = new byte[6];

                if (txtVBIncrementValuePK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter increment value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBIncrementValuePK.Focus();
                    return;
                }
                if (txtBlockAddressIncrPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBlockAddressIncrPK.Focus();
                    return;
                }
                iValueIncrement = System.Convert.ToInt32(txtVBIncrementValuePK.Text);
                uiBlockAddress = System.Convert.ToUInt16(txtBlockAddressIncrPK.Text);
                                               
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
                    fixed (byte* PKEY_PK = baKeyPK)
                    iFResult = uFCoder1x.ValueBlockIncrement_PK(iValueIncrement, uiBlockAddress, bAuthMode, PKEY_PK);
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

        private void btnDecrement_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iValueDecrement      = 0;
                UInt16 uiBlockAddress      = 0;                                
                byte bKeyIndex             = 0;
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;

                if (txtVBDecrement.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter decrement value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBDecrement.Focus();
                    return;
                }
                if (txtVBDecrBlockAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter the  BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBDecrBlockAddress.Focus();
                    return;
                }

                iValueDecrement      = System.Convert.ToInt32(txtVBDecrement.Text);
                uiBlockAddress       = System.Convert.ToByte(txtVBDecrBlockAddress.Text);
                bKeyIndex            = System.Convert.ToByte(cboKeyIndex.Text);
                
                iFResult = uFCoder1x.ValueBlockDecrement(iValueDecrement, uiBlockAddress, bAuthMode, bKeyIndex);

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

        private void btnDecrementAKM1_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iValueDecrement      = 0;
                UInt16 uiBlockAddress      = 0;                                                
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;

                if (txtVBDecrementAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter decrement value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBDecrementAKM1.Focus();
                    return;
                }
                if (txtVBDecrBlockAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the  BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBDecrBlockAddressAKM1.Focus();
                    return;
                }

                iValueDecrement      = System.Convert.ToInt32(txtVBDecrementAKM1.Text);
                uiBlockAddress       = System.Convert.ToByte(txtVBDecrBlockAddressAKM1.Text);
                
                
                iFResult = uFCoder1x.ValueBlockDecrement_AKM1(iValueDecrement, uiBlockAddress, bAuthMode);

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

        private void btnDecrementAKM2_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iValueDecrement      = 0;
                UInt16 uiBlockAddress      = 0;                                                
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;

                if (txtVBDecrementAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter decrement value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBDecrementAKM2.Focus();
                    return;
                }
                if (txtVBDecrBlockAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBDecrBlockAddressAKM2.Focus();
                    return;
                }

                iValueDecrement      = System.Convert.ToInt32(txtVBDecrementAKM2.Text);
                uiBlockAddress       = System.Convert.ToByte(txtVBDecrBlockAddressAKM2.Text);
                                
                iFResult = uFCoder1x.ValueBlockDecrement_AKM2(iValueDecrement, uiBlockAddress, bAuthMode);

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

        private void btnDecrementPK_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iValueDecrement      = 0;
                UInt16 uiBlockAddress      = 0;
                byte bCounter              = 0;                                                
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                byte [] baKeyPK            = new byte[6];

                if (txtVBDecrementPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter decrement value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBDecrementPK.Focus();
                    return;
                }
                if (txtVBDecrBlockAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBDecrBlockAddressPK.Focus();
                    return;
                }

                iValueDecrement      = System.Convert.ToInt32(txtVBDecrementPK.Text);
                uiBlockAddress       = System.Convert.ToByte(txtVBDecrBlockAddressPK.Text);
                
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
                    fixed (byte* PKEY_PK = baKeyPK)
                    iFResult = uFCoder1x.ValueBlockDecrement_PK(iValueDecrement, uiBlockAddress, bAuthMode, PKEY_PK);
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

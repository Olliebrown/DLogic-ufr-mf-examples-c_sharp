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
    public partial class frmValueBlockInSectorIncremDecrem : Form
    {
        private
            Globals GL = new Globals();
        public frmValueBlockInSectorIncremDecrem()
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

        private void frmValueBlockInSectorIncremDecrem_Load(object sender, EventArgs e)
        {
             
            cboKeyIndex.SelectedItem = cboKeyIndex.Items[0];
            GL.CreatePKKey(21, 31, 4, 350, "txtPKKey", 6, false, pnlAuth);
             
        }

        private void btnVBISIncrement_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iValueIncrement      = 0;
                byte bSectorAddress        = 0;
                byte bBlockAddress         = 0;                                
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                byte bKeyIndex             = 0;
           
           
                if (txtVBISIncrementValue.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISIncrementValue.Focus();
                    return;
                }
                if (txtVBISIncrSectorAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISIncrSectorAddress.Focus();
                    return;
                }
                if (txtVBISIncrBlockAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISIncrBlockAddress.Focus();
                    return;
                }

                iValueIncrement = System.Convert.ToInt32(txtVBISIncrementValue.Text);
                bSectorAddress  = System.Convert.ToByte(txtVBISIncrSectorAddress.Text);
                bBlockAddress   = System.Convert.ToByte(txtVBISIncrBlockAddress.Text);
                bKeyIndex       = System.Convert.ToByte(cboKeyIndex.Text);
                                               
                iFResult = uFCoder1x.ValueBlockInSectorIncrement(iValueIncrement, bSectorAddress, bBlockAddress, bAuthMode, bKeyIndex);

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
                GL.FunctionOn=false;
                 
            }          
        }

        private void btnVBISIncrementAKM1_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iValueIncrement      = 0;
                byte bSectorAddress        = 0;
                byte bBlockAddress         = 0;                                
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                
                if (txtVBISIncrementValueAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISIncrementValueAKM1.Focus();
                    return;
                }
                if (txtVBISIncrSectorAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISIncrSectorAddressAKM1.Focus();
                    return;
                }
                if (txtVBISIncrBlockAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISIncrBlockAddressAKM1.Focus();
                    return;
                }

                iValueIncrement = System.Convert.ToInt32(txtVBISIncrementValueAKM1.Text);
                bSectorAddress = System.Convert.ToByte(txtVBISIncrSectorAddressAKM1.Text);
                bBlockAddress = System.Convert.ToByte(txtVBISIncrBlockAddressAKM1.Text);
                

                iFResult = uFCoder1x.ValueBlockInSectorIncrement_AKM1(iValueIncrement, bSectorAddress, bBlockAddress, bAuthMode);

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

        private void btnVBISIncrementAKM2_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iValueIncrement      = 0;
                byte bSectorAddress        = 0;
                byte bBlockAddress         = 0;                                
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;

                if (txtVBISIncrementValueAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISIncrementValueAKM2.Focus();
                    return;
                }
                if (txtVBISIncrSectorAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISIncrSectorAddressAKM2.Focus();
                    return;
                }
                if (txtVBISIncrBlockAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISIncrBlockAddressAKM2.Focus();
                    return;
                }

                iValueIncrement = System.Convert.ToInt32(txtVBISIncrementValueAKM2.Text);
                bSectorAddress  = System.Convert.ToByte(txtVBISIncrSectorAddressAKM2.Text);
                bBlockAddress   = System.Convert.ToByte(txtVBISIncrBlockAddressAKM2.Text);
                

                iFResult = uFCoder1x.ValueBlockInSectorIncrement_AKM2(iValueIncrement, bSectorAddress, bBlockAddress, bAuthMode);

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

        private void btnVBISIncrementPK_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iValueIncrement      = 0;
                byte bSectorAddress        = 0;
                byte bBlockAddress         = 0; 
                byte bCounter              = 0;                               
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                byte[] baKeyPK             = new byte[6];
           
                if (txtVBISIncrementValuePK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISIncrementValuePK.Focus();
                    return;
                }
                if (txtVBISIncrSectorAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISIncrSectorAddressPK.Focus();
                    return;
                }
                if (txtVBISIncrBlockAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISIncrBlockAddressPK.Focus();
                    return;
                }
                
                iValueIncrement = System.Convert.ToInt32(txtVBISIncrementValuePK.Text);
                bSectorAddress  = System.Convert.ToByte(txtVBISIncrSectorAddressPK.Text);
                bBlockAddress   = System.Convert.ToByte(txtVBISIncrBlockAddressPK.Text);
                
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
                    fixed(byte* PKEY_PK=baKeyPK)
                    iFResult = uFCoder1x.ValueBlockInSectorIncrement_PK(iValueIncrement, bSectorAddress, bBlockAddress, bAuthMode, PKEY_PK);
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

        private void btnVBISDecrement_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iValueDecrement      = 0;
                byte bSectorAddress        = 0;
                byte bBlockAddress         = 0;                  
                byte bKeyIndex             = 0;                              
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;

                if (txtVBISDecrValue.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISDecrValue.Focus();
                    return;
                }

                if (txtVBISDecrSectorAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISDecrSectorAddress.Focus();
                    return;
                }
                if (txtVBISDecrBlockAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISDecrBlockAddress.Focus();
                    return;
                }

                iValueDecrement  = System.Convert.ToInt32(txtVBISDecrValue.Text);
                bSectorAddress   = System.Convert.ToByte(txtVBISDecrSectorAddress.Text);
                bBlockAddress    = System.Convert.ToByte(txtVBISDecrBlockAddress.Text);
                bKeyIndex        = System.Convert.ToByte(cboKeyIndex.Text);

                iFResult = uFCoder1x.ValueBlockInSectorDecrement(iValueDecrement, bSectorAddress, bBlockAddress, bAuthMode, bKeyIndex);

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

        private void btnVBISDecrementAKM1_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iValueDecrement      = 0;
                byte bSectorAddress        = 0;
                byte bBlockAddress         = 0;                                                                
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;

                if (txtVBISDecrValueAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISDecrValueAKM1.Focus();
                    return;
                }

                if (txtVBISDecrSectorAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISDecrSectorAddressAKM1.Focus();
                    return;
                }
                if (txtVBISDecrBlockAddressAKM1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISDecrBlockAddressAKM1.Focus();
                    return;
                }

                iValueDecrement = System.Convert.ToInt32(txtVBISDecrValueAKM1.Text);
                bSectorAddress  = System.Convert.ToByte(txtVBISDecrSectorAddressAKM1.Text);
                bBlockAddress   = System.Convert.ToByte(txtVBISDecrBlockAddressAKM1.Text);
                

                iFResult = uFCoder1x.ValueBlockInSectorDecrement_AKM1(iValueDecrement, bSectorAddress, bBlockAddress, bAuthMode);

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

        private void btnVBISDecrementAKM2_Click(object sender, EventArgs e)
        {
            
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iValueDecrement      = 0;
                byte bSectorAddress        = 0;
                byte bBlockAddress         = 0;                                                                
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;

                if (txtVBISDecrValueAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISDecrValueAKM2.Focus();
                    return;
                }

                if (txtVBISDecrSectorAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISDecrSectorAddressAKM2.Focus();
                    return;
                }
                if (txtVBISDecrBlockAddressAKM2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISDecrBlockAddressAKM2.Focus();
                    return;
                }

                iValueDecrement = System.Convert.ToInt32(txtVBISDecrValueAKM2.Text);
                bSectorAddress  = System.Convert.ToByte(txtVBISDecrSectorAddressAKM2.Text);
                bBlockAddress   = System.Convert.ToByte(txtVBISDecrBlockAddressAKM2.Text);
                

                iFResult = uFCoder1x.ValueBlockInSectorDecrement_AKM2(iValueDecrement, bSectorAddress, bBlockAddress, bAuthMode);

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

        private void btnVBISDecrementPK_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn              = true;

                DL_STATUS iFResult;
                Int32 iValueDecrement      = 0;
                byte bSectorAddress        = 0;
                byte bBlockAddress         = 0; 
                byte bCounter              = 0;                               
                byte bAuthMode             = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                byte[] baKeyPK             = new byte[6];

                if (txtVBISDecrValuePK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any value !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISDecrValuePK.Focus();
                    return;
                }

                if (txtVBISDecrSectorAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the SECTOR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISDecrSectorAddressPK.Focus();
                    return;
                }
                if (txtVBISDecrBlockAddressPK.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter  the BLOCK ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVBISDecrBlockAddressPK.Focus();
                    return;
                }

                iValueDecrement = System.Convert.ToInt32(txtVBISDecrValuePK.Text);
                bSectorAddress  = System.Convert.ToByte(txtVBISDecrSectorAddressPK.Text);
                bBlockAddress   = System.Convert.ToByte(txtVBISDecrBlockAddressPK.Text);
                
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
                    fixed(byte* PKEY_PK=baKeyPK)
                    iFResult = uFCoder1x.ValueBlockInSectorDecrement_PK(iValueDecrement, bSectorAddress, bBlockAddress, bAuthMode, PKEY_PK);
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

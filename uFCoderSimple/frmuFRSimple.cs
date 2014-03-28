/************************************************************************************
  
   Program                :  uFr Simple
   File                   :  frmuFRSimple.cs
   Description            :  Functions to work with the keys card and reader key
   Author                 :  VladanS
   Manufacturer           :  D-Logic
   Development enviroment :  Microsoft Visual C# 2012 Express
   Revisions			  :  
   Version                :  1.6
   
************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace uFRSimple
{
    public partial class frmuFRSimpleImplementation : Form
    {
        public frmuFRSimpleImplementation()
        {
            InitializeComponent();
            cboSoundMode.SelectedItem = cboSoundMode.Items[0];
            cboLightMode.SelectedItem = cboLightMode.Items[0];
        }



        private UInt32 iResult = 0;
        private bool boCONN = false,
                     boReaderStop = false,
                     boThreadStart = false,
                     boFunctionOn = false;
        private byte bKeyIndex = 0;
        private string[] ERR_CODE = new string[180];

        const byte AUTH1A = 96,
                   AUTH1B = 97,
                   DL_OK = 0,
                   RES_OK_LIGHT = 4,
                   RES_OK_SOUND = 0,//4
                   ERR_LIGHT = 2,
                   ERR_SOUND = 0;//4

        const ushort LINEAR_MAX_BYTES = 752;

        const string
                    CONVERT_ERROR = "You may enter only whole decimal number !",
                    APPROPRIATE_FORMAT = "You must enter the appropriate format !\nEnter a number between 0 and 255 or 0 and FF hexadecimal !";

        const string NEW_CARD_KEY_A = "txtNewCardKeyA",
                     NEW_CARD_KEY_B = "txtNewCardKeyB",
                     NEW_READER_KEY = "txtNewReaderKey";


        private void ReaderOff()
        {
            boReaderStop = true;
        }
        private void ReaderOn()
        {
            boReaderStop = false;
        }
        void ERRORS_CODE(uint result, System.Windows.Forms.StatusStrip Status_bar)
        {
            ERR_CODE[0] = " DL_OK ";
            ERR_CODE[1] = "COMMUNICATION_ERROR";
            ERR_CODE[2] = "CHKSUM_ERROR";
            ERR_CODE[3] = "READING_ERROR";
            ERR_CODE[4] = "WRITING_ERROR";
            ERR_CODE[5] = "BUFFER_OVERFLOW";
            ERR_CODE[6] = "MAX_ADDRESS_EXCEEDED";
            ERR_CODE[7] = "MAX_KEY_INDEX_EXCEEDED";
            ERR_CODE[8] = "NO_CARD";
            ERR_CODE[9] = "COMMAND_NOT_SUPPORTED";
            ERR_CODE[10] = " FORBIDEN_DIRECT_WRITE_IN_SECTOR_TRAILER";
            ERR_CODE[11] = " ADDRESSED_BLOCK_IS_NOT_SECTOR_TRAILER  ";
            ERR_CODE[12] = " WRONG_ADDRESS_MODE  ";
            ERR_CODE[13] = " WRONG_ACCESS_BITS_VALUES  ";
            ERR_CODE[14] = " AUTH_ERROR  ";
            ERR_CODE[15] = " PARAMETERS_ERROR  ";
            ERR_CODE[16] = " MAX_SIZE_EXCEEDED  ";

            ERR_CODE[80] = " COMMUNICATION_BREAK  ";
            ERR_CODE[81] = " NO_MEMORY_ERROR  ";
            ERR_CODE[82] = " CAN_NOT_OPEN_READER  ";
            ERR_CODE[83] = " READER_NOT_SUPPORTED  ";
            ERR_CODE[84] = " READER_OPENING_ERROR  ";
            ERR_CODE[85] = " READER_PORT_NOT_OPENED  ";
            ERR_CODE[86] = " CANT_CLOSE_READER_PORT  ";

            ERR_CODE[112] = " WRITE_VERIFICATION_ERROR  ";
            ERR_CODE[113] = "  BUFFER_SIZE_EXCEEDED  ";
            ERR_CODE[114] = " VALUE_BLOCK_INVALID  ";
            ERR_CODE[115] = " VALUE_BLOCK_ADDR_INVALID  ";
            ERR_CODE[116] = " VALUE_BLOCK_MANIPULATION_ERROR  ";
            ERR_CODE[117] = " WRONG_UI_MODE ";
            ERR_CODE[118] = " KEYS_LOCKED ";
            ERR_CODE[119] = " KEYS_UNLOCKED ";
            ERR_CODE[120] = " WRONG_PASSWORD ";
            ERR_CODE[121] = " CAN_NOT_LOCK_DEVICE ";
            ERR_CODE[122] = " CAN_NOT_UNLOCK_DEVICE ";
            ERR_CODE[123] = " DEVICE_EEPROM_BUSY ";
            ERR_CODE[124] = " RTC_SET_ERROR ";

            ERR_CODE[160] = " FT_STATUS_ERROR_1 ";
            ERR_CODE[161] = " FT_STATUS_ERROR_2 ";
            ERR_CODE[162] = " FT_STATUS_ERROR_3 ";
            ERR_CODE[163] = " FT_STATUS_ERROR_4 ";
            ERR_CODE[164] = " FT_STATUS_ERROR_5 ";
            ERR_CODE[165] = " FT_STATUS_ERROR_6 ";
            ERR_CODE[166] = " FT_STATUS_ERROR_7 ";
            ERR_CODE[167] = " FT_STATUS_ERROR_8 ";

            Status_bar.Items[1].Text = "0x" + result.ToString("X2");
            Status_bar.Items[2].Text = ERR_CODE[result];

        }

        void CreateKey(byte bKeyWidth, byte bKeyHeight, byte bKeyX, byte bKeyY, string bKeyName, System.Windows.Forms.Panel pnlContainer)
        {
            for (byte br = 0; br < 6; br++)
            {
                TextBox TB = new TextBox();
                TB.Width = bKeyWidth;
                TB.Height = bKeyHeight;
                TB.Font = new Font("Verdana", 8, FontStyle.Bold);
                TB.Name = bKeyName;
                TB.Text = "";
                TB.MaxLength = 3;
                TB.KeyPress += new KeyPressEventHandler(TB_KeyPress);
                TB.Leave += TB_Leave;
                TB.Location = new Point((bKeyX + (bKeyWidth * br) + 2), bKeyY);
                TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                pnlContainer.Controls.Add(TB);
            }
        }

        void TB_Leave(object sender, EventArgs e)
        {

            TextBox TB = (TextBox)sender;
            try
            {
                if (TB.Text.Trim() == String.Empty)
                {
                    TB.Undo();                    
                    return;
                }
                if (chkCardKeysHex.Checked && TB.Name == NEW_CARD_KEY_A || chkCardKeysHex.Checked && TB.Name == NEW_CARD_KEY_B ||
                chkReaderKeyHex.Checked && TB.Name == NEW_READER_KEY) return;
                System.Convert.ToByte(TB.Text, 10);
            }
            catch (OverflowException OWE)
            {
                MessageBox.Show("Wrong key ! \n Input value must not be greater than 255 !", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);                                        TB.SelectAll();       
                TB.Focus();                
            }
        }



        void TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox TB = (TextBox)sender;

            if (e.KeyChar == (char)Keys.Back) return;

            if (chkCardKeysHex.Checked && TB.Name == NEW_CARD_KEY_A || chkCardKeysHex.Checked && TB.Name == NEW_CARD_KEY_B ||
                chkReaderKeyHex.Checked && TB.Name == NEW_READER_KEY)
            {
                TB.MaxLength = 2;
                if (e.KeyChar == (char)Keys.Back) return;
                if (Regex.IsMatch(e.KeyChar.ToString(), "[^a-fA-F0-9]")) e.Handled = true;
            }
            else
            {
                TB.MaxLength = 3;
                if (Regex.IsMatch(e.KeyChar.ToString(), "[^0-9]")) e.Handled = true;
            }

        }

        private void mniExitItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainThread()
        {
            ulong ulReaderType = 0;
            ulong ulReaderSerialNumber = 0;
            ulong ulCardSerial = 0;
            byte bCardType = 0;

            boThreadStart = true;
            if (!boCONN)
            {
                if ((iResult = uFRCoder1x.ReaderOpen()) == DL_OK)
                {
                    boCONN = true;
                    stbReader.Items[0].Text = "CONNECTED";
                    ERRORS_CODE(iResult, stbReader);
                }
                else
                {
                    stbReader.Items[0].Text = "NOT CONNECTED";
                    txtReaderType.Text = "";
                    txtReaderSerial.Text = "";
                    txtCardType.Text = "";
                    txtCardSerial.Text = "";
                    ERRORS_CODE(iResult, stbReader);

                }
            }
            unsafe
            {
                if (boCONN)
                {
                    if ((iResult = uFRCoder1x.GetReaderType(&ulReaderType)) == DL_OK)
                    {
                        txtReaderType.Text = "0x" + ulReaderType.ToString("X");
                        if ((iResult = uFRCoder1x.GetReaderSerialNumber(&ulReaderSerialNumber)) == DL_OK)
                        {
                            txtReaderSerial.Text = "0x" + ulReaderSerialNumber.ToString("X");
                        }
                        if ((iResult = uFRCoder1x.GetCardId(&bCardType, &ulCardSerial)) == DL_OK)
                        {
                            txtCardSerial.Text = "0x" + ulCardSerial.ToString("X");
                            txtCardType.Text = "0x" + bCardType.ToString("X2");
                            ERRORS_CODE(iResult, stbCardStatus);
                        }
                        else
                        {
                            txtCardType.Text = "";
                            txtCardSerial.Text = "";
                            ERRORS_CODE(iResult, stbCardStatus);
                        }
                    }
                    else
                    {
                        uFRCoder1x.ReaderClose();
                        boCONN = false;
                        ERRORS_CODE(iResult, stbCardStatus);
                    }

                }
            }
            boThreadStart = false;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!boReaderStop)
                MainThread();
        }

        private void btnReaderUISignal_Click(object sender, EventArgs e)
        {
            if (boFunctionOn) return;
            boFunctionOn = true;
            ReaderOff();
            if (!boThreadStart)
                uFRCoder1x.ReaderUISignal(cboLightMode.SelectedIndex, cboSoundMode.SelectedIndex);
            ReaderOn();
            boFunctionOn = false;
        }

        private void frmuFRCoderSimpleImplementation_Load(object sender, EventArgs e)
        {
            CreateKey(32, 21, 3, 10, NEW_CARD_KEY_A, pnlCardKeys);
            CreateKey(32, 21, 3, 33, NEW_CARD_KEY_B, pnlCardKeys);
            CreateKey(32, 21, 53, 10, NEW_READER_KEY, pnlReaderKey);
            bKeyIndex = System.Convert.ToByte(txtReaderKeyIndex.Text);
        }
        private void DecHexConversion(String sTextBoxName, Boolean CheckBoxChecked, System.Windows.Forms.Panel Container)
        {


            foreach (Control ctrlKey in Container.Controls)
            {
                if (ctrlKey.Name == sTextBoxName)
                {
                    if (ctrlKey.Text == String.Empty)
                        continue;
                    else
                    {
                        ctrlKey.Text = CheckBoxChecked ? System.Convert.ToByte(ctrlKey.Text).ToString("X")
                                                      : System.Convert.ToUInt16(ctrlKey.Text, 16).ToString();
                    }
                }
            }
        }



        private void btnLinearRead_Click(object sender, EventArgs e)
        {
            if (boFunctionOn) return;
            boFunctionOn = true;
            ReaderOff();
            if (boThreadStart)
            {
                ReaderOn();
                boFunctionOn = false;
                return;
            }
            try
            {
                if (txtReadLinearAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter LINEAR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtReadLinearAddress.Focus();
                    ReaderOn();
                    boFunctionOn = false;
                    return;
                }
                if (txtReadDataLength.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter DATA LENGTH !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtReadDataLength.Focus();
                    ReaderOn();
                    boFunctionOn = false;
                    return;
                }
                ushort linear_address = System.Convert.ToUInt16(txtReadLinearAddress.Text);
                ushort data_length = System.Convert.ToUInt16(txtReadDataLength.Text);
                byte[] read_data = new byte[LINEAR_MAX_BYTES];
                ushort bytes_ret = 0;
                byte auth_mode = 0;

                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                unsafe
                {
                    fixed (byte* PData = read_data)
                        iResult = uFRCoder1x.LinearRead(PData, linear_address, data_length, &bytes_ret, auth_mode, bKeyIndex);
                }
                if (iResult == DL_OK)
                {
                    uFRCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    ERRORS_CODE(iResult, stbFunction_error);
                    txtReadData.Text = System.Text.Encoding.ASCII.GetString(read_data);
                    txtReadBytes.Text = bytes_ret.ToString();
                }
                else
                {
                    read_data[bytes_ret] = 0;
                    txtReadData.Text = System.Text.Encoding.ASCII.GetString(read_data);
                    txtReadBytes.Text = bytes_ret.ToString();
                    uFRCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);
                    ERRORS_CODE(iResult, stbFunction_error);
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
                ReaderOn();
                boFunctionOn = false;
            }
        }

        private void btnWriteData_Click(object sender, EventArgs e)
        {
            if (boFunctionOn) return;
            boFunctionOn = true;
            ReaderOff();
            if (boThreadStart)
            {
                ReaderOn();
                boFunctionOn = false;
                return;
            }
            try
            {
                if (txtWriteData.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtWriteData.Focus();
                    ReaderOn();
                    boFunctionOn = false;
                    return;
                }
                if (txtWriteLinearAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter LINEAR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtWriteLinearAddress.Focus();
                    ReaderOn();
                    boFunctionOn = false;
                    return;
                }
                if (txtWriteDataLength.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter DATA LENGTH !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtWriteDataLength.Focus();
                    ReaderOn();
                    boFunctionOn = false;
                    return;
                }

                ushort linear_address = System.Convert.ToUInt16(txtWriteLinearAddress.Text);
                ushort data_length = System.Convert.ToUInt16(txtWriteDataLength.Text);
                byte auth_mode = 0;
                ushort bytes_ret;
                if (rbAUTH1A.Checked) auth_mode = AUTH1A; else auth_mode = AUTH1B;
                byte[] write_data = new byte[LINEAR_MAX_BYTES];



                write_data = System.Text.Encoding.ASCII.GetBytes(txtWriteData.Text);
                unsafe
                {
                    fixed (byte* PData = WriteArray(write_data, data_length, LINEAR_MAX_BYTES))
                        iResult = uFRCoder1x.LinearWrite(PData, linear_address, data_length, &bytes_ret, auth_mode, bKeyIndex);
                }
                if (iResult == DL_OK)
                {
                    txtBytesWritten.Text = bytes_ret.ToString();
                    uFRCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    ERRORS_CODE(iResult, stbFunction_error);
                }
                else
                {
                    txtBytesWritten.Text = bytes_ret.ToString();
                    uFRCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);
                    ERRORS_CODE(iResult, stbFunction_error);
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
                ReaderOn();
                boFunctionOn = false;
            }
        }

        private byte[] WriteArray(byte[] bGetBytesArray, int iDataLength, int iMaxBytes)
        {
            byte[] bCloneArray = new byte[iMaxBytes];
            Array.Copy(bGetBytesArray, bCloneArray, bGetBytesArray.Length);
            for (int br = bGetBytesArray.Length; br < iDataLength; br++)
            {
                bCloneArray[br] = 32;
            }

            return bCloneArray;

        }





        private void chkCardKeysHex_Click(object sender, EventArgs e)
        {
            DecHexConversion(NEW_CARD_KEY_A, chkCardKeysHex.Checked, pnlCardKeys);
            DecHexConversion(NEW_CARD_KEY_B, chkCardKeysHex.Checked, pnlCardKeys);

        }

        private void chkReaderKeyHex_Click(object sender, EventArgs e)
        {
            DecHexConversion(NEW_READER_KEY, chkReaderKeyHex.Checked, pnlReaderKey);
        }

        private void btnEnterReaderKey_Click(object sender, EventArgs e)
        {
            if (boFunctionOn) return;
            boFunctionOn = true;
            ReaderOff();
            if (boThreadStart)
            {
                ReaderOn();
                boFunctionOn = false;
                return;
            }

            byte[] baReaderKey = new byte[6];
            byte bCounter = 0;

            try
            {
                foreach (Control CtrlKey in pnlReaderKey.Controls)
                {
                    if (CtrlKey.Name == NEW_READER_KEY)
                    {
                        baReaderKey[bCounter] = chkReaderKeyHex.Checked ? System.Convert.ToByte(int.Parse(CtrlKey.Text, System.Globalization.NumberStyles.HexNumber)) : System.Convert.ToByte(CtrlKey.Text, 10);
                        bCounter++;
                    }
                }

                unsafe
                {
                    fixed (byte* PReaderKey = baReaderKey)
                    {
                        iResult = uFRCoder1x.ReaderKeyWrite(PReaderKey, bKeyIndex);

                    }
                }
                if (iResult == DL_OK)
                {
                    uFRCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    ERRORS_CODE(iResult, stbFunction_error);
                    MessageBox.Show("Reader key is formatted successfully !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    uFRCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);
                    ERRORS_CODE(iResult, stbFunction_error);
                    MessageBox.Show("Reader key is not formatted successfully !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException FE)
            {
                MessageBox.Show(APPROPRIATE_FORMAT, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(ArgumentOutOfRangeException AURE)
            {
                MessageBox.Show(APPROPRIATE_FORMAT, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ReaderOn();
                boFunctionOn = false;
            }
        }

        private void btnFormatCard_Click(object sender, EventArgs e)
        {
            if (boFunctionOn) return;
            boFunctionOn = true;
            ReaderOff();
            if (boThreadStart)
            {
                ReaderOn();
                boFunctionOn = false;
                return;
            }

            byte bBlockAccessBits = 0;
            byte bSectorTrailersAccess_bits = 1;
            byte bSectorTrailersByte9 = 45;
            byte[] baKeyA = new byte[6];
            byte[] baKeyB = new byte[6];
            byte bCounter = 0;
            byte bSectorsFormatted = 0;
            txtSectorFormatted.Text = "";

            byte bAuthMode = rbAUTH1A.Checked ? AUTH1A : AUTH1B;
            try
            {
                foreach (Control ctrlkey in pnlCardKeys.Controls)
                {
                    if (ctrlkey.Name == NEW_CARD_KEY_A)
                    {
                        baKeyA[bCounter] = chkCardKeysHex.Checked ? System.Convert.ToByte(int.Parse(ctrlkey.Text, System.Globalization.NumberStyles.HexNumber)) : System.Convert.ToByte(ctrlkey.Text, 10);
                        bCounter++;
                    }
                }
                bCounter = 0;
                foreach (Control ctrlkey in pnlCardKeys.Controls)
                {
                    if (ctrlkey.Name == NEW_CARD_KEY_B)
                    {
                        baKeyB[bCounter] = chkCardKeysHex.Checked ? System.Convert.ToByte(int.Parse(ctrlkey.Text, System.Globalization.NumberStyles.HexNumber)) : System.Convert.ToByte(ctrlkey.Text);
                        bCounter++;
                    }
                }

                unsafe
                {
                    fixed (byte* PKEY_A = baKeyA, PKEY_B = baKeyB)
                        iResult = uFRCoder1x.LinearFormatCard(PKEY_A, bBlockAccessBits, bSectorTrailersAccess_bits, bSectorTrailersByte9, PKEY_B, &bSectorsFormatted, bAuthMode, bKeyIndex);
                }
                if (iResult == DL_OK)
                {
                    uFRCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    txtSectorFormatted.Text = bSectorsFormatted.ToString();
                    ERRORS_CODE(iResult, stbFunction_error);
                    MessageBox.Show("Card keys are formatted successfully !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    uFRCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);
                    txtSectorFormatted.Text = bSectorsFormatted.ToString();
                    ERRORS_CODE(iResult, stbFunction_error);
                    MessageBox.Show("Card keys are not formatted successfully !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException FE)
            {
                MessageBox.Show(APPROPRIATE_FORMAT, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentOutOfRangeException AURE)
            {
                MessageBox.Show(APPROPRIATE_FORMAT, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                ReaderOn();
                boFunctionOn = false;
            }
        }


    }
}

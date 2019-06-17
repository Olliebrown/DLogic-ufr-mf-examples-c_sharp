

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
    using  DL_STATUS = System.UInt32;
    public partial class frmuFrSimple : Form
    {
        
        public frmuFrSimple()
        {
            InitializeComponent();
            cboSoundMode.SelectedItem = cboSoundMode.Items[0];
            cboLightMode.SelectedItem = cboLightMode.Items[0];
        }

        //DLOGIC CARD TYPE
        public enum DLCARDTYPE
        {
            DL_MIFARE_ULTRALIGHT        = 0x01,
            DL_MIFARE_ULTRALIGHT_EV1_11 = 0x02,
            DL_MIFARE_ULTRALIGHT_EV1_21 = 0x03,
            DL_MIFARE_ULTRALIGHT_C      = 0x04,
            DL_NTAG_203                 = 0x05,
            DL_NTAG_210                 = 0x06,
            DL_NTAG_212                 = 0x07,
            DL_NTAG_213                 = 0x08,
            DL_NTAG_215                 = 0x09,
            DL_NTAG_216                 = 0x0A,
            DL_MIFARE_MINI              = 0x20,
            DL_MIFARE_CLASSIC_1K        = 0x21,
            DL_MIFARE_CLASSIC_4K        = 0x22,
            DL_MIFARE_PLUS_S_2K         = 0x23,
            DL_MIFARE_PLUS_S_4K         = 0x24,
            DL_MIFARE_PLUS_X_2K         = 0x25,
            DL_MIFARE_PLUS_X_4K         = 0x26,
            DL_MIFARE_DESFIRE           = 0x27,
            DL_MIFARE_DESFIRE_EV1_2K    = 0x28,
            DL_MIFARE_DESFIRE_EV1_4K    = 0x29,
            DL_MIFARE_DESFIRE_EV1_8K    = 0x2A
        }
        //card type     
        const byte MIFARE_CLASSIC_1k = 0x08,
                   MIFARE_CLASSIC_4k = 0x18;

        //authenticate
        const byte MIFARE_AUTHENT1A  = 0x60,
                   MIFARE_AUTHENT1B  = 0x61;

        const byte DL_OK             = 0x00,
                   KEY_INDEX         = 0x00;

        //for error                    
        const byte FRES_OK_LIGHT     = 0x04,
                   FRES_OK_SOUND     = 0x00,
                   FERR_LIGHT        = 0x02,
                   FERR_SOUND        = 0x00;

        // sectors and blocks
        const byte MAX_SECTORS_1k    = 0x10,
                   MAX_SECTORS_4k    = 0x28,
                   MAX_BLOCK         = 0x0F;
                         
        const string
                    CONVERT_ERROR      = "You may enter only whole decimal number !",
                    APPROPRIATE_FORMAT = "You must enter the appropriate format !\nEnter a number between 0 and 255 or 0 and FF hexadecimal !";

        const string GIT_PATH = "https://git.d-logic.net/nfc-rfid-reader-sdk/ufr-lib",
                    LIB_DIR_NAME = "ufr-lib";


        const string NEW_CARD_KEY_A = "txtNewCardKeyA",
                     NEW_CARD_KEY_B = "txtNewCardKeyB",
                     NEW_READER_KEY = "txtNewReaderKey";

        private Boolean boCONN        = false,
                        boThreadStart = false,
                        boFunctionOn  = false;
                        

        private byte bKeyIndex   = 0;
        private byte bTypeOfCard = 0;
        private string[] ERROR_CODES;


        void CloneGitRepo(string gitPath)
        {
            string gitCommand = "git";
            string gitArgs = "";
            if (!System.IO.Directory.Exists(LIB_DIR_NAME))
            {
                string gitClone = String.Format("clone {0}", GIT_PATH);
                gitArgs = gitClone;
            }
            else
            {
                string gitUpdate = String.Format("pull origin {0}", GIT_PATH);
                gitArgs = gitUpdate;
            }

            try
            {
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(gitCommand, gitArgs);
                System.Diagnostics.Process someProcess = System.Diagnostics.Process.Start(startInfo);
                someProcess.WaitForExit();
                this.Timer.Enabled = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        void SetStatusBar(DL_STATUS result, System.Windows.Forms.StatusStrip Status_bar)
        {            
            Status_bar.Items[1].Text = "0x" + result.ToString("X2");
            Status_bar.Items[2].Text = ERROR_CODES[result];
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
                TB.Text = "255";
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

       

        

        private Boolean FunctionOn
        {
            get
            {
                return boFunctionOn;
            }
            set
            {
                boFunctionOn = value;
            }
        }

        private Boolean LoopStatus
        {
            get
            {
                return boThreadStart ;
            }
            set
            {
                boThreadStart  = value;
            }
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
             .Where(x => x % 2 == 0)
             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
             .ToArray();
        }

        private void checkAdvanced_CheckedChanged(object sender, EventArgs e)
        {
            txtReaderTypeEx.Enabled = !txtReaderTypeEx.Enabled;
            txtPortName.Enabled = !txtPortName.Enabled;
            txtPortInterface.Enabled = !txtPortInterface.Enabled;
            txtOpenArg.Enabled = !txtOpenArg.Enabled;

            labelReaderTypeEx.Enabled = !labelReaderTypeEx.Enabled;
            labelPortName.Enabled = !labelPortName.Enabled;
            labelPortInterface.Enabled = !labelPortInterface.Enabled;
            labelOpenArg.Enabled = !labelOpenArg.Enabled;

        }

        private void btnReaderOpen_Click(object sender, EventArgs e)
        {
            if (checkAdvanced.Checked == true)
            {
                DL_STATUS status;


                string reader_type = txtReaderTypeEx.Text;
                string port_name = txtPortName.Text;
                string port_interface = txtPortInterface.Text;
                string arg = txtOpenArg.Text;
                UInt32 reader_type_int = 0, port_interface_int = 0;

                try
                {
                    reader_type_int = Convert.ToUInt32(reader_type);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Advanced options parameter: Reader type");
                    txtReaderTypeEx.Focus();
                    return;
                }
                try
                {
                    port_interface_int = (UInt32)port_interface[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Advanced options parameter: Port interface");
                    txtPortInterface.Focus();
                    return;
                }

                status = (UInt32)uFCoder.ReaderOpenEx(reader_type_int, port_name, port_interface_int, arg);
                    if (status == DL_OK)
                    {
                        boCONN = true;
                        stbReader.Items[0].Text = "CONNECTED";
                        SetStatusBar(status, stbReader);
                        uFCoder.ReaderUISignal(1, 1);
                        Timer.Start();
                    }
                    else
                    {
                        txtReaderType.Clear();
                        txtReaderSerial.Clear();
                        txtCardType.Clear();
                        txtCardSerial.Clear();
                        txtCardSerial.Clear();
                        stbReader.Items[0].Text = "NOT CONNECTED";
                        SetStatusBar(status, stbReader);
                    }
            }
            else
            {

                DL_STATUS status;

                status = uFCoder.ReaderOpen();

                if (status == DL_OK)
                {
                    boCONN = true;
                    stbReader.Items[0].Text = "CONNECTED";
                    SetStatusBar(status, stbReader);
                    uFCoder.ReaderUISignal(1, 1);
                    Timer.Start();
                }
                else
                {
                    txtReaderType.Clear();
                    txtReaderSerial.Clear();
                    txtCardType.Clear();
                    txtCardSerial.Clear();
                    txtCardSerial.Clear();
                    stbReader.Items[0].Text = "NOT CONNECTED";
                    SetStatusBar(status, stbReader);
                }
            }
        }

        private void linkLabel_nfc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel_nfc.Text);
        }

        private void MainThread()
        {            
           
            ulong ulReaderType   = 0,
                  ulReaderSerial = 0,
                  ulCardSerial   = 0;

            byte  bUidSize       = 0,
                  bDLCardType    = 0,
                  bCardType      = 0;
                  
            byte[] baCardUID     = new byte[9];
            String sBuffer = "";
            DL_STATUS iRResult,
                      iCResult;

            LoopStatus =true;                                                         
            if (!boCONN)
            {
                if ((iRResult = uFCoder.ReaderOpen()) == DL_OK)
                {
                    boCONN = true;
                    stbReader.Items[0].Text = "CONNECTED";
                    SetStatusBar(iRResult, stbReader);
                }
                else
                {                    
                    txtReaderType  .Clear();
                    txtReaderSerial.Clear();
                    txtCardType    .Clear();
                    txtCardSerial  .Clear();                    
                    txtCardSerial  .Clear();
                    stbReader.Items[0].Text = "NOT CONNECTED";
                    SetStatusBar(iRResult, stbReader);
                }
            }
            unsafe
            {
                fixed (byte* pCardUID = baCardUID) 
                if (boCONN)
                {
                    iRResult = uFCoder.GetReaderType(&ulReaderType);
                    if ( iRResult == DL_OK)
                    {
                        txtReaderType.Text = "0x" + ulReaderType.ToString("X");
                        iRResult = uFCoder.GetReaderSerialNumber(&ulReaderSerial);
                        if (iRResult == DL_OK)
                        {
                            txtReaderSerial.Text = "0x" + ulReaderSerial.ToString("X");  
                            
                            iCResult = uFCoder.GetDlogicCardType(&bDLCardType);
                            
                            if (iCResult == DL_OK)
                            {
                                if (bDLCardType == (byte)DLCARDTYPE.DL_NTAG_203 ||
                                    bDLCardType == (byte)DLCARDTYPE.DL_MIFARE_ULTRALIGHT ||
                                    bDLCardType == (byte)DLCARDTYPE.DL_MIFARE_ULTRALIGHT_C)
                                {
                                    btnFormatCard.Enabled = false;
                                }
                                else
                                {
                                    btnFormatCard.Enabled = true;
                                }

                                uFCoder.GetCardIdEx(&bCardType, pCardUID, &bUidSize);
                                for (byte bBr = 0; bBr < bUidSize; bBr++)
                                {
                                    sBuffer += baCardUID[bBr].ToString("X");
                                }
                                txtCardType.Text   = "0x" + bDLCardType.ToString("X2");
                                txtUIDSize.Text    = "0x" + bUidSize.ToString("X2");                                
                                txtCardSerial.Text = "0x" + sBuffer;
                                bTypeOfCard        = bDLCardType;
                                SetStatusBar(iCResult, stbCardStatus);
                            }
                            else
                            {
                                btnFormatCard.Enabled = true;
                                txtCardType    .Clear();
                                txtUIDSize     .Clear();                                
                                txtCardSerial  .Clear();
                                SetStatusBar(iCResult, stbCardStatus);
                            }
                        }
                    }
                    else
                    {
                        txtReaderType  .Clear();
                        txtReaderSerial.Clear();
                        txtCardType    .Clear();                      
                        txtCardSerial  .Clear();
                        uFCoder.ReaderClose();
                        boCONN = false;
                        SetStatusBar(iRResult, stbReader);
                    }

                }
            }
            LoopStatus = false;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!FunctionOn )
                MainThread();
        }

        private void btnReaderUISignal_Click(object sender, EventArgs e)
        {
           if (FunctionOn || LoopStatus ) return;
           try
           {
               FunctionOn =true ;
                uFCoder.ReaderUISignal(cboLightMode.SelectedIndex, cboSoundMode.SelectedIndex);
           }
           finally
           {
              FunctionOn=false;
            }
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
            if (FunctionOn || LoopStatus) return;
            try
            {
                FunctionOn = true;
                if (txtReadLinearAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter the LINEAR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtReadLinearAddress.Focus();                                       
                    return;
                }
                if (txtReadDataLength.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter the DATA LENGTH !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtReadDataLength.Focus();                                        
                    return;
                }
                
                ushort ushLinearAddress = System.Convert.ToUInt16(txtReadLinearAddress.Text);
                ushort ushDataLength    = System.Convert.ToUInt16(txtReadDataLength.Text);
                byte[] baReadData       = new byte[ushDataLength];
                ushort ushBytesRet      = 0;
                byte bAuthMode          = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                DL_STATUS iFResult;
               
                unsafe
                {                    
                  
                        iFResult = uFCoder.LinearRead(baReadData, ushLinearAddress, ushDataLength, &ushBytesRet, bAuthMode, bKeyIndex);
                }
                if (iFResult == DL_OK)
                {
                    txtReadData.Text = BitConverter.ToString(baReadData).Replace("-", ":");
                    txtReadBytes.Text = ushBytesRet.ToString();                    
                    SetStatusBar(iFResult, stbFunction);
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                }
                else
                {
                    SetStatusBar(iFResult, stbFunction);
                    uFCoder.ReaderUISignal(FERR_LIGHT, FERR_SOUND);                    
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
                FunctionOn =false;
            }
        }

        private void btnWriteData_Click(object sender, EventArgs e)
        {
            if (FunctionOn || LoopStatus) return;
            try
            {
                FunctionOn = true;
                if (txtWriteData.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtWriteData.Focus();                                        
                    return;
                }
                if (txtWriteLinearAddress.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter the LINEAR ADDRESS !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtWriteLinearAddress.Focus();                                        
                    return;
                }
                if (txtWriteDataLength.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must enter the DATA LENGTH !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtWriteDataLength.Focus();                    
                    return;
                }

                
                ushort ushLinearAddress = System.Convert.ToUInt16(txtWriteLinearAddress.Text);
                ushort ushDataLength    = System.Convert.ToUInt16(txtWriteDataLength.Text);
                byte bAuthMode          = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
                ushort ushBytesRet;                
                byte[] baWriteData      = new byte[ushDataLength];
                baWriteData = StringToByteArray(txtWriteData.Text);
                DL_STATUS iFResult;

                unsafe
                {
                    fixed (byte* PData = baWriteData)
                        iFResult = uFCoder.LinearWrite(PData, ushLinearAddress, ushDataLength, &ushBytesRet, bAuthMode, bKeyIndex);
                }
                if (iFResult == DL_OK)
                {
                    txtBytesWritten.Text = ushBytesRet.ToString();
                    SetStatusBar(iFResult, stbFunction);
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    
                }
                else
                {
                    txtBytesWritten.Text = ushBytesRet.ToString();
                    SetStatusBar(iFResult, stbFunction);
                    uFCoder.ReaderUISignal(FERR_LIGHT, FERR_SOUND);                    
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
                FunctionOn=false;
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
           if (FunctionOn || LoopStatus ) return;
           try
           {
               FunctionOn         = true ; 
               byte[] baReaderKey = new byte[6];
               byte bCounter      = 0;
               DL_STATUS iFResult;
            
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
                        iFResult = uFCoder.ReaderKeyWrite(PReaderKey, bKeyIndex);

                    }
                }
                if (iFResult == DL_OK)
                {
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    SetStatusBar(iFResult, stbFunction);
                    MessageBox.Show("Reader key is formatted successfully !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    uFCoder.ReaderUISignal(FERR_LIGHT, FERR_SOUND);
                    SetStatusBar(iFResult, stbFunction);
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
                FunctionOn = false;
            }
        }

        private void btnFormatCard_Click(object sender, EventArgs e)
        {
           if (FunctionOn || LoopStatus ) return;
           try
           {
               FunctionOn =true ;           
               
               byte bBlockAccessBits           = 0,
                    bSectorTrailersAccess_bits = 1,
                    bSectorTrailersByte9       = 45,
                    bCounter                   = 0,
                    bSectorsFormatted          = 0;
               byte bAuthMode = rbAUTH1A.Checked ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
               byte[] baKeyA  = new byte[6];
               byte[] baKeyB  = new byte[6];
              
               txtSectorFormatted.Clear();                          
               DL_STATUS iFResult;

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
                        iFResult = uFCoder.LinearFormatCard(PKEY_A, bBlockAccessBits, bSectorTrailersAccess_bits, bSectorTrailersByte9, PKEY_B, &bSectorsFormatted, bAuthMode, bKeyIndex);
                }
                if (iFResult == DL_OK)
                {
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    txtSectorFormatted.Text = bSectorsFormatted.ToString();
                    SetStatusBar(iFResult, stbFunction);
                    MessageBox.Show("Card keys are formatted successfully !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    uFCoder.ReaderUISignal(FERR_LIGHT, FERR_SOUND);
                    txtSectorFormatted.Text = bSectorsFormatted.ToString();
                    SetStatusBar(iFResult, stbFunction);
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
             FunctionOn =false;
            }
        }

        private void frmuFrSimple_Load(object sender, EventArgs e)
        {
            CreateKey(32, 21, 3, 10, NEW_CARD_KEY_A, pnlCardKeys);
            CreateKey(32, 21, 3, 33, NEW_CARD_KEY_B, pnlCardKeys);
            CreateKey(32, 21, 53, 10, NEW_READER_KEY, pnlReaderKey);
            bKeyIndex = System.Convert.ToByte(txtReaderKeyIndex.Text);

            int[] iErrorValues = (int[])Enum.GetValues(typeof(ERRORCODES));
            string[] sErrorNames = Enum.GetNames(typeof(ERRORCODES));
            
            ERROR_CODES=new string[iErrorValues.Max()+1];
            
            for (int i = 0; i < iErrorValues.Length; i++)
                ERROR_CODES[iErrorValues[i]] = sErrorNames[i];

            //CloneGitRepo(GIT_PATH);
        }

        private void txtWriteData_TextChanged(object sender, EventArgs e)
        {
            txtWriteDataLength.Text=txtWriteData.Text.Length.ToString();
        }


    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace uFRSimplest
{
    using System.IO;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using DL_STATUS = System.UInt32;
    public partial class frmuFRSimplest : Form
    {
       
        public frmuFRSimplest()
        {
            InitializeComponent();
            
        }



        //DLOGIC CARD TYPE
        const byte DL_MIFARE_ULTRALIGHT		      =	 0x01,
           DL_MIFARE_ULTRALIGHT_EV1_11	  =	 0x02,
           DL_MIFARE_ULTRALIGHT_EV1_21	  =	 0x03,
           DL_MIFARE_ULTRALIGHT_C		  =	 0x04,
           DL_NTAG_203				      =  0x05,
           DL_NTAG_210				      =  0x06,
           DL_NTAG_212				      =  0x07,
           DL_NTAG_213				      =  0x08,
           DL_NTAG_215				      =  0x09,
           DL_NTAG_216				      =  0x0A,
           DL_MIFARE_MINI				  =  0x20,
           DL_MIFARE_CLASSIC_1K			  =  0x21,
           DL_MIFARE_CLASSIC_4K			  =  0x22,
           DL_MIFARE_PLUS_S_2K			  =  0x23,
           DL_MIFARE_PLUS_S_4K			  =  0x24,
           DL_MIFARE_PLUS_X_2K			  =  0x25,
           DL_MIFARE_PLUS_X_4K			  =  0x26,
           DL_MIFARE_DESFIRE			  =  0x27,
           DL_MIFARE_DESFIRE_EV1_2K		  =  0x28,
           DL_MIFARE_DESFIRE_EV1_4K		  =  0x29,
           DL_MIFARE_DESFIRE_EV1_8K		  =  0x2A;

  

   //authenticate
  const byte  MIFARE_AUTHENT1A  = 0x60,
              MIFARE_AUTHENT1B  = 0x61;

       

  const byte  DL_OK             = 0,
              KEY_INDEX         = 0;

        private void btnReaderOpen_Click(object sender, EventArgs e)
        {
             if (checkAdvanced.Checked == true)
            {
                DL_STATUS status;


                string reader_type = txtReaderType.Text;
                string port_name = txtPortName.Text;
                string port_interface = txtPortInterface.Text;
                string arg = txtOpenArg.Text;
                UInt32 reader_type_int = 0, port_interface_int = 0;

                try { 
                    reader_type_int = Convert.ToUInt32(reader_type);
                } catch (Exception ex) {
                    MessageBox.Show("Invalid Advanced options parameter: Reader type");
                    txtReaderType.Focus();
                    return;
                }
                try { 
                     port_interface_int = (UInt32)port_interface[0];
                } catch (Exception ex) {
                    MessageBox.Show("Invalid Advanced options parameter: Port interface");
                    txtPortInterface.Focus();
                    return;
                }
                status = (UInt32)uFCoder.ReaderOpenEx(reader_type_int, port_name, port_interface_int, arg);
                    if (status > 0) {
                        pnlConnected.Text = "NOT CONNECTED";
                        txtCardType.Clear();
                        txtUIDSize.Clear();
                        txtCardUID.Clear();
                        SetStatusBar(status, stbConnected);
                        return;
                    }
                    else {
                        pnlConnected.Text = "CONNECTED";
                        boCONN = true;
                        SetStatusBar(status, stbConnected);

                        uFCoder.ReaderUISignal(1, 1);

                        Timer.Start();
                    }
                
            }
            else {

                DL_STATUS status;

                status = uFCoder.ReaderOpen();

                if (status == DL_OK)
               
                {
                    pnlConnected.Text = "CONNECTED";
                    boCONN = true;
                    SetStatusBar(status, stbConnected);

                    uFCoder.ReaderUISignal(1, 1);
                    Timer.Start();
                }
                    else
                    {
                    pnlConnected.Text = "NOT CONNECTED";
                    txtCardType.Clear();
                    txtUIDSize.Clear();
                    txtCardUID.Clear();
                    SetStatusBar(status, stbConnected);
                }
            } 
        }

        private void checkAdvanced_CheckedChanged(object sender, EventArgs e)
        {
            txtReaderType.Enabled = !txtReaderType.Enabled;
            txtPortName.Enabled = !txtPortName.Enabled;
            txtPortInterface.Enabled = !txtPortInterface.Enabled;
            txtOpenArg.Enabled = !txtOpenArg.Enabled;

            labelReaderType.Enabled = !labelReaderType.Enabled;
            labelPortName.Enabled = !labelPortName.Enabled;
            labelPortInterface.Enabled = !labelPortInterface.Enabled;
            labelOpenArg.Enabled = !labelOpenArg.Enabled;

        }

        const string
                    CONVERT_ERROR = "You may enter only whole decimal number !",
                    APPROPRIATE_FORMAT = "You must enter the appropriate format !\nEnter a number between 0 and 255 or 0 and FF hexadecimal !";


        //for result                    
        const byte  FRES_OK_LIGHT     = 4,
              FRES_OK_SOUND     = 0,
              FERR_LIGHT        = 2,
              FERR_SOUND        = 0;

  // sectors and bytes
  const byte 
             MAX_SECTORS_1k         = 16,
             MAX_SECTORS_4k         = 40,            
             MAX_BYTES_NTAG_203     = 144,
             MAX_BYTES_ULTRALIGHT   =  48,
             MAX_BYTES_ULTRALIGHT_C = 144;
  const short
             MAX_BYTES_CLASSIC_1K   = 752,
             MAX_BYTES_CLASSIC_4k   = 3440;
             
  const byte           
             MAX_BLOCK          = 16,
             FORMAT_SIGN        = 0xFF; //use 0x00 for making card blank during format procedure


        const string GIT_PATH = "https://git.d-logic.net/nfc-rfid-reader-sdk/ufr-lib",
                     LIB_DIR_NAME = "ufr-lib";



        private Boolean boCONN        = false,  
                        boThreadStart = false,
                        boFunctionOn  = false;


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

        void SetStatusBar(DL_STATUS result, System.Windows.Forms.StatusStrip stbStatusBar)
        {            
            stbStatusBar.Items[1].Text = "0x" + result.ToString("X2");
            stbStatusBar.Items[2].Text = ERROR_CODES[result];
        }

       
       

        private Boolean SetFunctionStatus
        {
          get{
            return boFunctionOn;
          }
          set{
            boFunctionOn=value;
          }
        }

        private Boolean LoopStart
        {
          get{
              return boThreadStart;
          }
          set{
              boThreadStart=value;
          }
        }

        //max blocks in card
        private int MaxBlocks(byte bTypeCard){
            int iResult=0;
          switch (bTypeCard)
          {
              case DL_MIFARE_CLASSIC_1K : iResult = MAX_SECTORS_1k * 4;
                   break;
              case DL_MIFARE_CLASSIC_4K :
              case DL_MIFARE_PLUS_S_4K: iResult = ((MAX_SECTORS_1k * 2) * 4) + ((MAX_SECTORS_1k - 8) * 16);
                   break;
          }
          return iResult;
       }

       //max bytes of card
        private int MaxBytes(byte bCardType)
        {
          short usMaxBytes = 0;
          switch(bCardType)
          {
             case DL_NTAG_203           : usMaxBytes = MAX_BYTES_NTAG_203;
                 break;
             case DL_MIFARE_ULTRALIGHT  : usMaxBytes = MAX_BYTES_ULTRALIGHT;
                 break;
             case DL_MIFARE_ULTRALIGHT_C: usMaxBytes = MAX_BYTES_ULTRALIGHT_C;
                 break;
             case DL_MIFARE_CLASSIC_1K  : usMaxBytes = MAX_BYTES_CLASSIC_1K;
                 break;
             case DL_MIFARE_CLASSIC_4K  :
             case DL_MIFARE_PLUS_S_4K   : usMaxBytes = MAX_BYTES_CLASSIC_4k;
                  break;
           }
          return usMaxBytes;
        }

        private void mnuExitItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainThread()
        {
            ulong ulReaderType = 0;                 
            byte bUidSize      = 0,
                 bDLCardType   = 0,
                 bCardType     = 0; 
            byte [] baCardUID  = new byte[9];
            String sBuffer     = null;
            DL_STATUS iRResult,
                      iCResult;

            LoopStart =true;           
           
            if (boCONN)
            {
                unsafe
                {
                    
                    fixed (byte* pData = baCardUID) 
                    if ((iRResult = uFCoder.GetReaderType(&ulReaderType)) == DL_OK)
                    {
                        iCResult = uFCoder.GetDlogicCardType(&bDLCardType);
                        if (iCResult == DL_OK)
                        {
                            iCResult = uFCoder.GetCardIdEx(&bCardType,pData, &bUidSize);
                            if (iCResult == DL_OK)
                            {
                                   btnFormatCard.Enabled = bDLCardType > 0x0A;
                                   for (byte bCounter = 0; bCounter < bUidSize; bCounter++)
                                   {
                                       sBuffer += baCardUID[bCounter].ToString("X2");
                                   }
                            }                                               
                              txtCardType.Text   = "0x" + bDLCardType.ToString("X2");
                              txtUIDSize.Text    = "0x" + bUidSize.ToString("X2");
                              txtCardUID.Text    = "0x" +sBuffer;                                                                                           
                              bTypeOfCard=bDLCardType;
                              SetStatusBar(iCResult, stbCardStatus);
                        }
                        else
                        {
                            txtCardType  .Clear();
                            txtUIDSize   .Clear();
                            txtCardUID   .Clear();
                            btnFormatCard.Enabled = true;                            
                            SetStatusBar(iCResult, stbCardStatus);
                        }                       
                    }
                    else
                    {                        
                        boCONN = false;
                        uFCoder.ReaderClose();
                        txtCardType  .Clear();
                        txtUIDSize   .Clear();
                        txtCardUID   .Clear();                        
                    }
                }

            }
            LoopStart =false;
        }
      
      
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!SetFunctionStatus)
                MainThread();
        }

        private void linkLabel_nfc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(llblNfcRfid.Text);
        }

        private void btnFormatCard_Click(object sender, EventArgs e)
        {
           if (SetFunctionStatus  || LoopStart ) return;
            try
            {
                SetFunctionStatus = true;

                byte bBlockAccessBits = 0,
                     bSectorTrailersAccess_bits = 1,
                     bSectorTrailersByte9 = 105,
                     bCounter = 0,
                     bSectorsFormatted = 0;
                byte bAuthMode = 0x60;
                byte[] baKeyA = new byte[6];
                byte[] baKeyB = new byte[6];

                for (int i = 0; i < 6; i++)
                {
                    baKeyA[i] = 0xFF;
                    baKeyB[i] = 0xFF;
                }

                DL_STATUS iFResult;


                unsafe
                {
                    fixed (byte* PKEY_A = baKeyA, PKEY_B = baKeyB)
                        iFResult = uFCoder.LinearFormatCard(PKEY_A, bBlockAccessBits, bSectorTrailersAccess_bits, bSectorTrailersByte9, PKEY_B, &bSectorsFormatted, bAuthMode, 0);
                }

                if (iFResult == DL_OK)
                {

                    ushort linearSize = 0;
                    int rawLen = 0;
                    ushort retBytes = 0;
                    unsafe
                    {
                        iFResult = uFCoder.GetCardSize(&linearSize, &rawLen);
                    }

                    byte[] zeroData = new byte[linearSize];
                    unsafe
                    {
                        iFResult = uFCoder.LinearWrite(zeroData, 0, linearSize, &retBytes, 0x60, 0);
                    }

                    if (iFResult == DL_OK)
                    {
                        uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);

                        SetStatusBar(iFResult, stbFunctionError);
                        MessageBox.Show("Card keys are formatted successfully !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    uFCoder.ReaderUISignal(FERR_LIGHT, FERR_SOUND);
                    
                    SetStatusBar(iFResult, stbFunctionError);
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
                SetFunctionStatus = false;
            }
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
             .Where(x => x % 2 == 0)
             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
             .ToArray();
        }
        
        private void frmuFRSimplest_Load(object sender, EventArgs e)
       { 
         int[]iErrorValues=(int[])Enum.GetValues(typeof(ERRORCODES));
         string[]sErrorNames=Enum.GetNames(typeof(ERRORCODES));
         
         ERROR_CODES=new string[iErrorValues.Max()+1];
         for (int i=0;i<iErrorValues.Length;i++)                          
              ERROR_CODES[iErrorValues[i]]=sErrorNames[i];
            //CloneGitRepo(GIT_PATH);
                                                                                           
       }

       private void btnLinearRead_Click(object sender, EventArgs e)
       {
           if (SetFunctionStatus  || LoopStart ) return;
           try
           {
               SetFunctionStatus=true;
               int uiDataLength = MaxBytes(bTypeOfCard);
               int uiLinearAddress = 0;
               int uiBytesRet = 0;
               DL_STATUS iFResult;
               byte[] baReadData = new byte[uiDataLength];
               unsafe
               {
                   
                       iFResult = uFCoder.LinearRead(baReadData, uiLinearAddress, uiDataLength, &uiBytesRet, MIFARE_AUTHENT1A, KEY_INDEX);
               }
               if (iFResult == DL_OK)
               {
                    txtReadData.Text = System.Text.Encoding.Default.GetString(baReadData);
                    txtReadData.Text = Regex.Replace(txtReadData.Text, @"\p{C}+", String.Empty);
                    SetStatusBar(iFResult, stbFunctionError);
                   uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
               }
               else
               {
                   SetStatusBar(iFResult, stbFunctionError);
                   uFCoder.ReaderUISignal(FERR_LIGHT, FERR_SOUND);
               }
           }
           finally
           {
               SetFunctionStatus=false;
           }
       }

       private void btnLinearWrite_Click(object sender, EventArgs e)
       {           
           if (SetFunctionStatus  || LoopStart ) return;
           try
           {
             SetFunctionStatus=true;
             DL_STATUS iFResult;
             byte[]baWriteData;             
             
             if (txtWriteData.Text.Trim()==String.Empty) {
                MessageBox.Show("You need to enter any data !","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtWriteData.Focus();
                return;
                }
                baWriteData = Encoding.ASCII.GetBytes(txtWriteData.Text);
                unsafe
                {
                    ushort usLinearAddress   =0;
                    ushort usDataLength      =(ushort)baWriteData.Length;
                    ushort usBytesRet        =0;

                   
                         iFResult=uFCoder.LinearWrite(baWriteData, usLinearAddress,usDataLength,&usBytesRet,MIFARE_AUTHENT1A,KEY_INDEX);
                }
                    if (iFResult == DL_OK)
                    {                        
                        SetStatusBar(iFResult, stbFunctionError);
                        uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    }
                    else
                    {
                        SetStatusBar(iFResult, stbFunctionError);
                        uFCoder.ReaderUISignal(FERR_LIGHT, FERR_SOUND);
                    }                     
           }finally{
              SetFunctionStatus=false;
           }
       }     
    }
}

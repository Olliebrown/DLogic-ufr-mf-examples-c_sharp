using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace uFrAdvance
{
    using DL_STATUS = System.UInt32;
    
    class Globals
    {
        //DLOGIC CARD TYPE
        public enum DLCARDTYPE
        {
                   DL_MIFARE_ULTRALIGHT           = 0x01,
                   DL_MIFARE_ULTRALIGHT_EV1_11    = 0x02,
                   DL_MIFARE_ULTRALIGHT_EV1_21    = 0x03,
                   DL_MIFARE_ULTRALIGHT_C         = 0x04,
                   DL_NTAG_203                    = 0x05,
                   DL_NTAG_210                    = 0x06,
                   DL_NTAG_212                    = 0x07,
                   DL_NTAG_213                    = 0x08,
                   DL_NTAG_215                    = 0x09,
                   DL_NTAG_216                    = 0x0A,
                   DL_MIFARE_MINI                 = 0x20,
                   DL_MIFARE_CLASSIC_1K           = 0x21,
                   DL_MIFARE_CLASSIC_4K           = 0x22,
                   DL_MIFARE_PLUS_S_2K            = 0x23,
                   DL_MIFARE_PLUS_S_4K            = 0x24,
                   DL_MIFARE_PLUS_X_2K            = 0x25,
                   DL_MIFARE_PLUS_X_4K            = 0x26,
                   DL_MIFARE_DESFIRE              = 0x27,
                   DL_MIFARE_DESFIRE_EV1_2K       = 0x28,
                   DL_MIFARE_DESFIRE_EV1_4K       = 0x29,
                   DL_MIFARE_DESFIRE_EV1_8K       = 0x2A
        }

        //max bytes of card type     
        const byte 
                   MAX_BYTES_NTAG_203     = 144,
                   MAX_BYTES_ULTRALIGHT   =  48,
                   MAX_BYTES_ULTRALIGHT_C = 144;
        const short
                   MAX_BYTES_CLASSIC_1K   = 752,
                   MAX_BYTES_CLASSIC_4k   = 3440;

        // sectors and blocks
        const byte MAX_SECTORS_1k         = 0x10,
                   MAX_SECTORS_4k         = 0x28;
                   //MAX_BLOCK              = 0x10;
       
        //max page for NTAG203 and ULTRALIGHT 
        const byte MAX_PAGE_NTAG203       = 39,
                   MAX_PAGE_ULTRALIGHT    = 15,
                   MAX_PAGE_ULTRALIGHT_C  = 39;

       

       
        //property for card type of current card 
        private static byte btypeofcard;
        public byte TypeOfCard
        {
            get
            {
                return btypeofcard;
            }
            set
            {
                btypeofcard = value;
            }

        }

        //property for function start/stop status
        private Boolean boFunctionStart;
        public Boolean FunctionOn
        {
            get
            {
                return boFunctionStart;
            }
            set
            {
                boFunctionStart = value;
            }
        }

        //property for main loop start/stop status
        private Boolean boLoopStart;
        public Boolean LoopStatus
        {
            get
            {
                return boLoopStart;
            }
            set
            {
                boLoopStart = value;
            }
        }

                    
        private  static string[] ERROR_CODES = new string[180]; 

        public void FullRangeERROR_CODES()
        {
            int[] iErrorValues   = (int[])Enum.GetValues(typeof(ERRORCODES));            
            string[] sErrorNames = Enum.GetNames(typeof(ERRORCODES));
            
            //ERROR_CODES=new string[iErrorValues.Max()];
            
            for (int i = 0; i < iErrorValues.Length; i++)
                ERROR_CODES[iErrorValues[i]] = sErrorNames[i];
            
        }

        //max card blocks
        public int MaxBlock(byte bTypeCard)
        {
            int iResult = 0;

            switch (bTypeCard)
            {
                
                case  (byte) DLCARDTYPE.DL_MIFARE_CLASSIC_1K  :iResult  = MAX_SECTORS_1k * 4;
                break;
                case  (byte) DLCARDTYPE.DL_MIFARE_CLASSIC_4K  :iResult  = ((MAX_SECTORS_1k * 2) * 4) + ((MAX_SECTORS_1k - 8) * 16);
                break;
                case  (byte) DLCARDTYPE.DL_MIFARE_ULTRALIGHT  : iResult = MAX_PAGE_ULTRALIGHT;
                break;
                case  (byte) DLCARDTYPE.DL_MIFARE_ULTRALIGHT_C: iResult = MAX_PAGE_ULTRALIGHT_C;
                break;
                case (byte) DLCARDTYPE.DL_NTAG_203           : iResult = MAX_PAGE_NTAG203;
                break;
            }
                           
            return iResult;
        }

        //max card bytes 
        public int MaxBytes(byte bCardType)
        {
            short usMaxBytes = 0;
            switch (bCardType)
            {
                case (byte) DLCARDTYPE.DL_NTAG_203: usMaxBytes = MAX_BYTES_NTAG_203;
                    break;
                case (byte) DLCARDTYPE.DL_MIFARE_ULTRALIGHT: usMaxBytes = MAX_BYTES_ULTRALIGHT;
                    break;
                case (byte) DLCARDTYPE.DL_MIFARE_ULTRALIGHT_C: usMaxBytes = MAX_BYTES_ULTRALIGHT_C;
                    break;
                case (byte) DLCARDTYPE.DL_MIFARE_CLASSIC_1K: usMaxBytes = MAX_BYTES_CLASSIC_1K;
                    break;
                case (byte) DLCARDTYPE.DL_MIFARE_CLASSIC_4K:
                case (byte) DLCARDTYPE.DL_MIFARE_PLUS_S_4K: usMaxBytes = MAX_BYTES_CLASSIC_4k;
                    break;
            }
            return usMaxBytes;
        }

    


        public void SetStatusBar(DL_STATUS iResult, System.Windows.Forms.StatusStrip stbStatusBar)
        {           
            stbStatusBar.Items[1].Text = "0x" + iResult.ToString("X2");
            stbStatusBar.Items[2].Text = ERROR_CODES[iResult];
        }

        public void CreatePKKey(byte key_height, byte key_width, int key_top, int key_left, string key_name, byte number_key, Boolean key_readonly, Panel pnlContainer)
        {
            for (byte br = 0; br < number_key; ++br)
            {
                System.Windows.Forms.TextBox KBox = new TextBox();
                KBox.Height = key_height;
                KBox.Width = key_width;
                KBox.Location = new System.Drawing.Point(key_left + (key_width * br + 2), key_top);
                KBox.Name = key_name;
                KBox.Text = "255";
                KBox.ReadOnly = key_readonly;
                KBox.KeyPress += new KeyPressEventHandler(KBox_KeyPress);
                KBox.TextChanged += new EventHandler(KBox_TextChanged);
                KBox.Leave += new EventHandler(KBox_Leave);
                KBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                pnlContainer.Controls.Add(KBox);
            }
        }

        void KBox_Leave(object sender, EventArgs e)
        {
            try
            {
                TextBox TB = (TextBox)sender;
                if (TB.Text.Trim() == String.Empty)
                {
                    TB.Focus();
                    TB.Undo();
                }
                if (System.Convert.ToInt16(TB.Text) > 255)
                {
                    MessageBox.Show("Wrong entry !\n You must enter the numeric value of less than 255.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TB.Undo();
                    TB.Focus();
                    TB.SelectAll();
                    TB = null;
                }

            }
            catch
            {

            }
        }

        void KBox_TextChanged(object sender, EventArgs e)
        {
            try
            {

                TextBox TB = (TextBox)sender;
                if (System.Convert.ToInt16(TB.Text) > 255)
                {
                    MessageBox.Show("Wrong entry !\nYou must enter the numeric value of less than 255.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TB.Undo();
                    TB.Focus();
                    TB.SelectAll();
                    TB = null;
                }

            }
            catch
            {

            }

        }
        void KBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8) return;
            if (e.KeyChar < (char)48 || e.KeyChar > (char)57) e.Handled = true;
        }




        public byte[] WriteArray(byte[] bGetBytesArray,int iDataLength,int iMaxBytes)
        {
            byte[] bCloneArray = new byte[iMaxBytes];
            Array.Copy(bGetBytesArray, bCloneArray, bGetBytesArray.Length);
            for (int br = bGetBytesArray.Length; br < iDataLength; br++)
            {
                bCloneArray[br] = 32;
            }
                                    
            return bCloneArray;

        }

     }   
        
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;


namespace Mifare
{
    
    
    class Globals
    {

        private Boolean boReaderStart,
                        boFunctionStart;

        public Boolean FunctionStart
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

        public Boolean ReaderStart
        {
            get
            {
                return boReaderStart;
            }
            set
            {
                boReaderStart = value;
            }
        }


        private string[] ERR_CODE = new string[180];
        public void ERRORS_CODE(uint result, System.Windows.Forms.StatusStrip status_bar)
        {
            ERR_CODE[0] = "DL_OK ";
            ERR_CODE[1] = "COMMUNICATION_ERROR ";
            ERR_CODE[3] = "READING_ERROR ";
            ERR_CODE[4] = "WRITING_ERROR ";
            ERR_CODE[6] = "MAX_ADDRESS_EXCEEDED ";
            ERR_CODE[7] = "MAX_KEY_INDEX_EXCEEDED ";
            ERR_CODE[8] = "NO_CARD ";
            ERR_CODE[10] = "FORBIDEN_DIRECT_WRITE_IN_SECTOR_TRAILER ";
            ERR_CODE[11] = "ADDRESSED_BLOCK_IS_NOT_SECTOR_TRAILER ";
            ERR_CODE[12] = "WRONG_ADDRESS_MODE ";
            ERR_CODE[13] = "WRONG_ACCESS_BITS_VALUES ";
            ERR_CODE[14] = "AUTH_ERROR ";
            ERR_CODE[15] = "PARAMETERS_ERROR ";
            ERR_CODE[80] = "COMMUNICATION_BREAK ";
            ERR_CODE[82] = "CAN_NOT_OPEN_READER ";
            ERR_CODE[84] = "READER_OPENING_ERROR ";
            ERR_CODE[85] = "READER_PORT_NOT_OPENED ";
            ERR_CODE[114] = "VALUE_BLOCK_INVALID ";
            ERR_CODE[113] = "BUFFER_SIZE_EXCEEDED ";
            ERR_CODE[115] = "VALUE_BLOCK_ADDR_INVALID ";
            ERR_CODE[116] = "VALUE_BLOCK_MANIPULATION_ERROR ";
            ERR_CODE[117] = "WRONG_UI_MODE";
            ERR_CODE[121] = "CAN_NOT_LOCK_DEVICE";
            ERR_CODE[122] = "CAN_NOT_UNLOCK_DEVICE";
            ERR_CODE[123] = "DEVICE_EEPROM_BUSY";
            ERR_CODE[160] = "HARDWARE_ERROR";
            ERR_CODE[161] = "HARDWARE_ERROR";

            status_bar.Items[1].Text = "0x" + result.ToString("X2");
            status_bar.Items[2].Text = ERR_CODE[result];
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



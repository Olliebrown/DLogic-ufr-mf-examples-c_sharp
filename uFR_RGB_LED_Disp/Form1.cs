using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using DL_uFCoder;

namespace uFR_RGB_LED_Disp
{
    public partial class Form1 : Form
    {
        private Thread oThread;
        private Effect oEffect;
        private DLOGIC_CARD_TYPE dlogic_card_type;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DL_STATUS status;
            bool reader_connected;
            ulong reader_type;
            byte[] reader_sn = new byte[8];

            statusReader.Text = "Please wait...";
            this.Update();

            tbDeviceType.Text = "";
            tbDeviceSerialNr.Text = "";
            tbDeviceType.Refresh();
            tbDeviceSerialNr.Refresh();

            status = uFCoder.ReaderOpen();
            reader_connected = status == DL_STATUS.UFR_OK;

            unsafe
            {
                status = uFCoder.GetReaderType(&reader_type);
            }
            reader_connected &= status == DL_STATUS.UFR_OK;

            unsafe
            {
                fixed (byte* rdsn = reader_sn)
                    status = uFCoder.GetReaderSerialDescription(rdsn);
            }
            reader_connected &= status == DL_STATUS.UFR_OK;

            if (!reader_connected)
            {
                statusReader.Text = "Reader not connected";
                return;
            }
            else
            {
                statusReader.Text = "Reader connected";

                tbDeviceType.Text = Convert.ToString((long)reader_type, 16).ToUpper();
                tbDeviceSerialNr.Text = System.Text.Encoding.UTF8.GetString(reader_sn);
                btnClose.Enabled = true;
                btnCardIdEx.Enabled = true;
                btnSetDisplayColor.Enabled = true;
                btnClearDisplay.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DL_STATUS status;

            status = uFCoder.ReaderClose();

            if (status == DL_STATUS.UFR_OK)
            {
                statusReader.Text = "Reader not connected";
                tbDeviceType.Text = "";
                tbDeviceSerialNr.Text = "";
                btnClose.Enabled = false;
                btnCardIdEx.Enabled = false;
                btnSetDisplayColor.Enabled = false;
                btnClearDisplay.Enabled = false;
            }

        }

        private void btnCardIdEx_Click(object sender, EventArgs e)
        {
            DL_STATUS status;
            byte card_type, id_len;
            byte[] card_id = new byte[10];

            unsafe
            {
                status = uFCoder.GetDlogicCardType(&card_type);
            }
            dlogic_card_type = (DLOGIC_CARD_TYPE)card_type;

            if (status != DL_STATUS.UFR_OK)
            {
                statusReader.Text = "NO CARD";
                tbCardType.Text = "";
                tbCardId.Text = "";
                return;
            }
            else
            {
                statusReader.Text = "Card ID were read successfully";
            }

            switch (dlogic_card_type)
            {
                case DLOGIC_CARD_TYPE.DL_MIFARE_ULTRALIGHT:
                    tbCardType.Text = "MIFARE ULTRALIGHT";
                    break;

                case DLOGIC_CARD_TYPE.DL_MIFARE_ULTRALIGHT_C:
                    tbCardType.Text = "MIFARE ULTRALIGHT C";
                    break;

                case DLOGIC_CARD_TYPE.DL_NTAG_203:
                    tbCardType.Text = "NTAG203";
                    break;

                case DLOGIC_CARD_TYPE.DL_MIFARE_ULTRALIGHT_EV1_11:
                    tbCardType.Text = "MIFARE ULTRALIGHT EV1 11";
                    break;

                case DLOGIC_CARD_TYPE.DL_MIFARE_ULTRALIGHT_EV1_21:
                    tbCardType.Text = "MIFARE ULTRALIGHT EV1 21";
                    break;

                case DLOGIC_CARD_TYPE.DL_NTAG_210:
                    tbCardType.Text = "NTAG 210";
                    break;

                case DLOGIC_CARD_TYPE.DL_NTAG_212:
                    tbCardType.Text = "NTAG 212";
                    break;

                case DLOGIC_CARD_TYPE.DL_NTAG_213:
                    tbCardType.Text = "NTAG 213";
                    break;

                case DLOGIC_CARD_TYPE.DL_NTAG_215:
                    tbCardType.Text = "NTAG 215";
                    break;

                case DLOGIC_CARD_TYPE.DL_NTAG_216:
                    tbCardType.Text = "NTAG 216";
                    break;

                case DLOGIC_CARD_TYPE.DL_MIKRON_MIK640D:
                    tbCardType.Text = "MIKRON MIK640D";
                    break;

                case DLOGIC_CARD_TYPE.DL_MIFARE_MINI:
                    tbCardType.Text = "MIFARE MINI";
                    break;

                case DLOGIC_CARD_TYPE.DL_MIFARE_CLASSIC_1K:
                    tbCardType.Text = "MIFARE CLASSIC 1K";
                    break;

                case DLOGIC_CARD_TYPE.DL_MIFARE_CLASSIC_4k:
                case DLOGIC_CARD_TYPE.DL_MIFARE_CLASSIC_4K:
                    tbCardType.Text = "MIFARE CLASSIC 4K";
                    break;

                case DLOGIC_CARD_TYPE.DL_MIFARE_PLUS_S_2K:
                    tbCardType.Text = "MIFARE PLUS S 2K";
                    break;

                case DLOGIC_CARD_TYPE.DL_MIFARE_PLUS_S_4K:
                    tbCardType.Text = "MIFARE PLUS S 4K";
                    break;

                case DLOGIC_CARD_TYPE.DL_MIFARE_PLUS_X_2K:
                    tbCardType.Text = "MIFARE PLUS X 2K";
                    break;

                case DLOGIC_CARD_TYPE.DL_MIFARE_PLUS_X_4K:
                    tbCardType.Text = "MIFARE PLUS X 4K";
                    break;

                case DLOGIC_CARD_TYPE.DL_MIFARE_DESFIRE:
                    tbCardType.Text = "MIFARE DESFIRE";
                    break;

                case DLOGIC_CARD_TYPE.DL_MIFARE_DESFIRE_EV1_2K:
                    tbCardType.Text = "MIFARE DESFIRE EV1 2K";
                    break;

                case DLOGIC_CARD_TYPE.DL_MIFARE_DESFIRE_EV1_4K:
                    tbCardType.Text = "MIFARE DESFIRE EV1 4K";
                    break;

                case DLOGIC_CARD_TYPE.DL_MIFARE_DESFIRE_EV1_8K:
                    tbCardType.Text = "MIFARE DESFIRE EV1 8K";
                    break;

                default:
                    tbCardType.Text = "UNSUPPORTED CARD TYPE";
                    break;
            }

            unsafe
            {
                fixed (byte* cid = card_id)
                    status = uFCoder.GetCardIdEx(&card_type, cid, &id_len);
            }
            if (status != DL_STATUS.UFR_OK)
            {
                statusReader.Text = "Card ID were read unsuccessfully ";
                return;
            }

            tbCardId.Text = BitConverter.ToString(card_id, 0, id_len);

        }

        private void btnSetDisplayColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlgColorDialog = new ColorDialog();
            if (dlgColorDialog.ShowDialog() == DialogResult.OK)
            {
                SetDisplayColor(dlgColorDialog.Color.ToArgb());
            }
                
        }

        private void btnClearDisplay_Click(object sender, EventArgs e)
        {
            SetDisplayColor(0);
        }

        private void SetDisplayColor(int color)
        {
            DL_STATUS status;
            byte[] display_data = new byte[DisplayConsts.DISPLAY_BUFFER_LEN];
            byte green = (byte)((color >> 8) & 0xFF);
            byte red = (byte)((color >> 16) & 0xFF);
            byte blue = (byte)(color & 0xFF);

            for (int i = 0; i < DisplayConsts.DISPLAY_BUFFER_LEN; i += 3)
            {
                display_data[i] = green;
                display_data[i + 1] = red;
                display_data[i + 2] = blue;
            }

            unsafe
            {
                fixed (byte* unsafe_display_data = display_data)
                    status = uFCoder.SetDisplayData(unsafe_display_data, DisplayConsts.DISPLAY_BUFFER_LEN);
            }

            if (status == DL_STATUS.UFR_OK)
            {
                statusReader.Text = "Display color is set successfully";
            }
            else
            {
                statusReader.Text = "Error while setting display color";
            }
        }

        private void btnEffect1_Click(object sender, EventArgs e)
        {
            oEffect = new Effect1();
            oThread = new Thread(new ThreadStart(oEffect.run));
            oThread.Start();
            Thread.Sleep(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oThread.Abort();
        }
    }

    public class Effect
    {
        public byte[] display_data;

        public Effect()
        {
        }

        public virtual void run()
        {
        }
    }

    public class Effect1 : Effect
    {        
        byte green, red, blue;

        public Effect1()
        {
            int i, byte_cnt = 0; 
            //display_data = new byte[DisplayConsts.DISPLAY_BUFFER_LEN];
            display_data = Enumerable.Repeat((byte)0, DisplayConsts.DISPLAY_BUFFER_LEN).ToArray();

 

            green = 2;
            red = 10;
            blue = 3;

            for (i = 0; i < DisplayConsts.DISPLAY_LEDS; i++)
            {
                display_data[byte_cnt++] = green;
                display_data[byte_cnt++] = red;
                display_data[byte_cnt++] = blue;

                red += 1;
                green += 2;
                blue += 3;
            }
        }

        public override void run()
        {
            byte g, r, b;

            while (true)
            {
                unsafe
                {
                    fixed (byte* unsafe_display_data = display_data)
                        uFCoder.SetDisplayData(unsafe_display_data, DisplayConsts.DISPLAY_BUFFER_LEN);
                }

                g = display_data[0];
                r = display_data[1];
                b = display_data[2];
                for (int i = 0; i < DisplayConsts.DISPLAY_BUFFER_LEN - 3; i++)
                {
                    display_data[i] = display_data[i + 3];
                }
                display_data[DisplayConsts.DISPLAY_BUFFER_LEN - 3] = g;
                display_data[DisplayConsts.DISPLAY_BUFFER_LEN - 2] = r;
                display_data[DisplayConsts.DISPLAY_BUFFER_LEN - 1] = b;

                //Thread.Sleep(2);
            }

        }
    }

    public class DisplayConsts
    {
        public const byte DISPLAY_LEDS = 16;
        public const byte DISPLAY_BUFFER_LEN = (DISPLAY_LEDS * 3);
    }

}

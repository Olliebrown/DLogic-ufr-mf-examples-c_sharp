﻿using System;
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
        private ThreadStopRequest effect_stop_request;
        private Thread oThread;
        private Effect oEffect;
        private DLOGIC_CARD_TYPE dlogic_card_type;
        private static Mutex mut_uFR = new Mutex();

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

            mut_uFR.WaitOne();
            status = uFCoder.ReaderOpen();
            mut_uFR.ReleaseMutex();

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
                btnEffect1.Enabled = true;
                btnEffect2.Enabled = true;
                btnOpen.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DL_STATUS status;

            if (btnStopEffect.Enabled)
            {
                effect_stop_request.stopRequest();
                oThread.Join();
                oThread = null;
                oEffect = null;
                effect_stop_request = null;
            }

            SetDisplayColor(0);

            mut_uFR.WaitOne();
            status = uFCoder.ReaderClose();
            mut_uFR.ReleaseMutex();

            if (status == DL_STATUS.UFR_OK)
            {
                statusReader.Text = "Reader not connected";
                tbDeviceType.Text = "";
                tbDeviceSerialNr.Text = "";
                btnClose.Enabled = false;
                btnCardIdEx.Enabled = false;
                btnSetDisplayColor.Enabled = false;
                btnClearDisplay.Enabled = false;
                btnEffect1.Enabled = false;
                btnEffect2.Enabled = false;
                btnStopEffect.Enabled = false;
                btnOpen.Enabled = true;
            }
        }

        private void btnCardIdEx_Click(object sender, EventArgs e)
        {
            DL_STATUS status;
            byte card_type, id_len;
            byte[] card_id = new byte[10];

            mut_uFR.WaitOne();
            unsafe
            {
                status = uFCoder.GetDlogicCardType(&card_type);
            }
            mut_uFR.ReleaseMutex();

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

            mut_uFR.WaitOne();
            unsafe
            {
                fixed (byte* cid = card_id)
                    status = uFCoder.GetCardIdEx(&card_type, cid, &id_len);
            }
            mut_uFR.ReleaseMutex();

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

            // There is different arrangement of colors in RGB Display (GRB instead of RGB):
            byte green = (byte)((color >> 8) & 0xFF);
            byte red = (byte)((color >> 16) & 0xFF);
            byte blue = (byte)(color & 0xFF);

            for (int i = 0; i < DisplayConsts.DISPLAY_BUFFER_LEN; i += 3)
            {
                display_data[i] = green;
                display_data[i + 1] = red;
                display_data[i + 2] = blue;
            }

            mut_uFR.WaitOne();
            unsafe
            {
                fixed (byte* unsafe_display_data = display_data)
                    status = uFCoder.SetDisplayData(unsafe_display_data, DisplayConsts.DISPLAY_BUFFER_LEN);
            }
            mut_uFR.ReleaseMutex();

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
            effect_stop_request = new ThreadStopRequest();
            oEffect = new Effect1(mut_uFR, effect_stop_request);
            oThread = new Thread(new ThreadStart(oEffect.run));
            oThread.Start();

            btnSetDisplayColor.Enabled = false;
            btnClearDisplay.Enabled = false;
            btnEffect1.Enabled = false;
            btnEffect2.Enabled = false;
            btnStopEffect.Enabled = true;
        }

        private void btnEffect2_Click(object sender, EventArgs e)
        {
            effect_stop_request = new ThreadStopRequest();
            oEffect = new Effect2(mut_uFR, effect_stop_request);
            oThread = new Thread(new ThreadStart(oEffect.run));
            oThread.Start();

            btnSetDisplayColor.Enabled = false;
            btnClearDisplay.Enabled = false;
            btnEffect1.Enabled = false;
            btnEffect2.Enabled = false;
            btnStopEffect.Enabled = true;
        }

        private void btnStopEffect_Click(object sender, EventArgs e)
        {
            effect_stop_request.stopRequest();
            oThread.Join();
            oThread = null;
            effect_stop_request = null;
            oEffect = null;

            btnSetDisplayColor.Enabled = true;
            btnClearDisplay.Enabled = true;
            btnEffect1.Enabled = true;
            btnEffect2.Enabled = true;
            btnStopEffect.Enabled = false;

            SetDisplayColor(0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnStopEffect.Enabled)
            {
                btnStopEffect_Click(sender, e);
            }

            if (btnClose.Enabled)
            {
                SetDisplayColor(0); 

                mut_uFR.WaitOne();
                uFCoder.ReaderClose();
                mut_uFR.ReleaseMutex();
            }
        }

    }

    public class ThreadStopRequest
    {
        private bool stopNow = false;

        public void stopRequest()
        {
            stopNow = true;
        }

        public bool shouldIStopNow()
        {
            return stopNow;
        }
    }

    public class Effect
    {
        public ThreadStopRequest stop_request;
        public byte[] display_data;
        public Mutex uFR_mutex;

        public Effect(Mutex mut, ThreadStopRequest request)
        {
            uFR_mutex = mut;
            stop_request = request;
        }

        public virtual void run()
        {
        }
    }

    public class Effect1 : Effect
    {
        public Effect1(Mutex mut, ThreadStopRequest request)
            : base(mut, request)
        {
            int i, byte_cnt = 0;
            byte green, red, blue;

            display_data = new byte[DisplayConsts.DISPLAY_BUFFER_LEN];
            //display_data = Enumerable.Repeat((byte)0, DisplayConsts.DISPLAY_BUFFER_LEN).ToArray();

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

            while (!stop_request.shouldIStopNow())
            {
                //Thread.Sleep(40);

                uFR_mutex.WaitOne();
                unsafe
                {
                    fixed (byte* unsafe_display_data = display_data)
                        uFCoder.SetDisplayData(unsafe_display_data, DisplayConsts.DISPLAY_BUFFER_LEN);
                }
                uFR_mutex.ReleaseMutex();

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
            }
        }
    }

    public class Effect2 : Effect
    {
        public Effect2(Mutex mut, ThreadStopRequest request)
            : base(mut, request)
        {

            //display_data = new byte[DisplayConsts.DISPLAY_BUFFER_LEN];
            display_data = Enumerable.Repeat((byte)0, DisplayConsts.DISPLAY_BUFFER_LEN).ToArray();

            // red component setup:
            display_data[1] = 40;
            display_data[4] = 30;
            display_data[7] = 20;
            display_data[10] = 10;
            display_data[13] = 4;

            // blue component setup:
            display_data[23] = 2;
            display_data[26] = 10;
            display_data[29] = 20;
            display_data[32] = 30;
            display_data[35] = 45;
        }

        public override void run()
        {

            byte temp;

            while (!stop_request.shouldIStopNow())
            {
                Thread.Sleep(40);

                uFR_mutex.WaitOne();
                unsafe
                {
                    fixed (byte* unsafe_display_data = display_data)
                        uFCoder.SetDisplayData(unsafe_display_data, DisplayConsts.DISPLAY_BUFFER_LEN);
                }
                uFR_mutex.ReleaseMutex();

                // Only red component rotate clockwise:
                temp = display_data[1];
                for (int i = 1; i < DisplayConsts.DISPLAY_BUFFER_LEN - 3; i += 3)
                {
                    display_data[i] = display_data[i + 3];
                }
                display_data[DisplayConsts.DISPLAY_BUFFER_LEN - 2] = temp;

                // Only blue component rotate counter-clockwise
                temp = display_data[DisplayConsts.DISPLAY_BUFFER_LEN - 1];
                for (int i = DisplayConsts.DISPLAY_BUFFER_LEN - 1; i > 2; i -= 3)
                {
                    display_data[i] = display_data[i - 3];
                }
                display_data[2] = temp;
            }
        }
    }

    public class DisplayConsts
    {
        public const byte DISPLAY_LEDS = 16;
        public const byte DISPLAY_BUFFER_LEN = (DISPLAY_LEDS * 3);
    }
}

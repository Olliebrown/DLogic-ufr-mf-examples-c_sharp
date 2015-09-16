using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DL_uFCoder;

namespace uFR_RGB_LED_Disp
{
    public partial class Form1 : Form
    {
        private DLOGIC_CARD_TYPE dlogic_card_type;
        private bool reader_opened;

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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DL_uFCoder;

namespace NTAG_lock_bytes
{
    public partial class frmMain : Form
    {
        DLOGIC_CARD_TYPE dlogic_card_type;
        private bool reader_opened;
        private const UInt64 READER_CONTROLS_AFFECTED = 0x100000000;
        private const UInt64 NTAG203_CONTROLS_AFFECTED = 0x200000000;
        private const UInt64 ULTRALIGHT_CONTROLS_AFFECTED = 0x400000000;

        public bool isReaderOpened()
        {
            return reader_opened;
        }

        public frmMain()
        {
            InitializeComponent();
            reader_opened = false;
            statusReader.Text = "Reader not connected";
            disableControls(READER_CONTROLS_AFFECTED | NTAG203_CONTROLS_AFFECTED | ULTRALIGHT_CONTROLS_AFFECTED);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DL_STATUS status;
            bool reader_connected;
            uint reader_type;
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

                tbDeviceType.Text = Convert.ToString(reader_type, 16).ToUpper();
                tbDeviceSerialNr.Text = System.Text.Encoding.UTF8.GetString(reader_sn);

                enableControls(READER_CONTROLS_AFFECTED);
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

                disableControls(READER_CONTROLS_AFFECTED | NTAG203_CONTROLS_AFFECTED | ULTRALIGHT_CONTROLS_AFFECTED);
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

            disableControls(NTAG203_CONTROLS_AFFECTED | ULTRALIGHT_CONTROLS_AFFECTED);

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
                    enableControls(ULTRALIGHT_CONTROLS_AFFECTED);
                    break;

                case DLOGIC_CARD_TYPE.DL_MIFARE_ULTRALIGHT_C:
                    tbCardType.Text = "MIFARE ULTRALIGHT C";
                    enableControls(NTAG203_CONTROLS_AFFECTED);
                    break;

                case DLOGIC_CARD_TYPE.DL_NTAG_203:
                    tbCardType.Text = "NTAG203";
                    enableControls(NTAG203_CONTROLS_AFFECTED);
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

        private void btnPageRead_Click(object sender, EventArgs e)
        {
            DL_STATUS status;
            byte[] page_data = new byte[16];
            byte page_address, auth_mode;
            byte[] key = {0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF};

            if ((dlogic_card_type == DLOGIC_CARD_TYPE.DL_MIFARE_ULTRALIGHT)
                || (dlogic_card_type == DLOGIC_CARD_TYPE.DL_MIFARE_ULTRALIGHT_C)
                || (dlogic_card_type == DLOGIC_CARD_TYPE.DL_NTAG_203))
            {
                auth_mode = 0x60;
                page_address = 2;
                unsafe
                {
                    fixed (byte* pd = page_data)
                    fixed (byte* k = key)
                        status = uFCoder.BlockRead_PK(pd, page_address, auth_mode, k);
                }
                if (status != DL_STATUS.UFR_OK)
                {
                    statusReader.Text = "NO DATA";
                    return;
                }

                tbLockByte0.Text = String.Format("{0:X2}", page_data[2]);
                tbLockByte1.Text = String.Format("{0:X2}", page_data[3]);
                tbLockByte2.Text = "00";
                tbLockByte3.Text = "00";

                setCheckBoxes(ULTRALIGHT_CONTROLS_AFFECTED);

                if ((dlogic_card_type == DLOGIC_CARD_TYPE.DL_NTAG_203)
                    || (dlogic_card_type == DLOGIC_CARD_TYPE.DL_MIFARE_ULTRALIGHT_C))
                {
                    page_address = 40;
                    unsafe
                    {
                        fixed (byte* pd = page_data)
                        fixed (byte* k = key)
                            status = uFCoder.BlockRead_PK(pd, page_address, auth_mode, k);
                    }
                    if (status != DL_STATUS.UFR_OK)
                    {
                        statusReader.Text = "NO SECOND LOCK PAGE";
                        return;
                    }

                    tbLockByte2.Text = String.Format("{0:X2}", page_data[0]);
                    tbLockByte3.Text = String.Format("{0:X2}", page_data[1]);
                }

                setCheckBoxes(NTAG203_CONTROLS_AFFECTED);
                statusReader.Text = "Data were successfully read";
            }
        }

        private void btnPageWrite_Click(object sender, EventArgs e)
        {
            DL_STATUS status;
            byte[] page_data = new byte[16];
            byte page_address, auth_mode;
            byte[] key = {0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF};

            if ((dlogic_card_type == DLOGIC_CARD_TYPE.DL_MIFARE_ULTRALIGHT)
                || (dlogic_card_type == DLOGIC_CARD_TYPE.DL_MIFARE_ULTRALIGHT_C)
                || (dlogic_card_type == DLOGIC_CARD_TYPE.DL_NTAG_203))
            {

                auth_mode = 0x60;
                page_address = 2;
                page_data = Enumerable.Repeat((byte)0, 16).ToArray();
                page_data[2] = Convert.ToByte(tbLockByte0.Text.ToString(), 16);
                page_data[3] = Convert.ToByte(tbLockByte1.Text.ToString(), 16);

                unsafe
                {
                    fixed (byte* pd = page_data)
                    fixed (byte* k = key)
                        status = uFCoder.BlockWrite_PK(pd, page_address, auth_mode, k);
                }
                if (status != DL_STATUS.UFR_OK)
                {
                    statusReader.Text = "Data hasn't been written";
                    return;
                }

                if ((dlogic_card_type == DLOGIC_CARD_TYPE.DL_NTAG_203)
                    || (dlogic_card_type == DLOGIC_CARD_TYPE.DL_MIFARE_ULTRALIGHT_C))
                {
                    page_address = 40;
                    page_data = Enumerable.Repeat((byte)0, 16).ToArray();
                    page_data[0] = Convert.ToByte(tbLockByte2.Text.ToString(), 16);
                    page_data[1] = Convert.ToByte(tbLockByte3.Text.ToString(), 16);

                    unsafe
                    {
                        fixed (byte* pd = page_data)
                        fixed (byte* k = key)
                            status = uFCoder.BlockWrite_PK(pd, page_address, auth_mode, k);
                    }
                    if (status != DL_STATUS.UFR_OK)
                    {
                        statusReader.Text = "Data hasn't been written";
                        return;
                    }
                }

                statusReader.Text = "Data has been written";
            }
        }

        private void chkBit_Click(object sender, EventArgs e)
        {
            UInt64 raw;
            byte[] block_bytes = new byte[4];

            raw = BlockBytes2UInt64(block_bytes);

            foreach (Control ctrl in this.Controls)
            {
                if ((ctrl is CheckBox) && (ctrl.Tag != null))
                {
                    if (((CheckBox)ctrl).Checked)
                    {
                        raw |= Convert.ToUInt64(ctrl.Tag.ToString(), 16) & 0xFFFFFFFF;
                    }
                    else
                    {
                        raw &= ~(Convert.ToUInt64(ctrl.Tag.ToString(), 16) & 0xFFFFFFFF);
                    }
                }
            }

            for (int i = 0; i < 4; i++)
            {
                block_bytes[i] = (byte)(raw >> (i * 8));
            }

            tbLockByte0.Text = String.Format("{0:X2}", block_bytes[2]);
            tbLockByte1.Text = String.Format("{0:X2}", block_bytes[3]);
            tbLockByte2.Text = String.Format("{0:X2}", block_bytes[0]);
            tbLockByte3.Text = String.Format("{0:X2}", block_bytes[1]);
        }

        private void setCheckBoxes(UInt64 mask)
        {
            UInt64 tag_val, mask_val, raw;
            byte[] block_bytes = new byte[4];

            raw = BlockBytes2UInt64(block_bytes);

            foreach (Control ctrl in this.Controls)
            {
                if ((ctrl is CheckBox) && (ctrl.Tag != null))
                {
                    mask_val = Convert.ToUInt64(ctrl.Tag.ToString(), 16) & 0xFFFFFFFF00000000;
                    tag_val = Convert.ToUInt64(ctrl.Tag.ToString(), 16) & 0xFFFFFFFF;

                    if ((mask_val & mask) != 0)
                    {
                        ((CheckBox)ctrl).Checked = (tag_val & raw) == tag_val;
                    }
                }
            }
        }

        private UInt64 BlockBytes2UInt64(byte[] block_bytes)
        {
            UInt64 result = 0;

            block_bytes[0] = Convert.ToByte(tbLockByte2.Text.ToString(), 16);
            block_bytes[1] = Convert.ToByte(tbLockByte3.Text.ToString(), 16);
            block_bytes[2] = Convert.ToByte(tbLockByte0.Text.ToString(), 16);
            block_bytes[3] = Convert.ToByte(tbLockByte1.Text.ToString(), 16);

            for (int i = 0; i < 4; i++)
            {
                result |= ((UInt64)block_bytes[i] << (i * 8));
            }
            return result;
        }

        private void enableControls(UInt64 mask)
        {

            foreach (Control ctrl in this.Controls)
            {
                if ((ctrl.Tag != null) && ((Convert.ToUInt64(ctrl.Tag.ToString(), 16) & mask) != 0))
                {
                    ctrl.Enabled = true;
                }
            }
        }

        private void disableControls(UInt64 mask)
        {

            foreach (Control ctrl in this.Controls)
            {
                if ((ctrl.Tag != null) && ((Convert.ToUInt64(ctrl.Tag.ToString(), 16) & mask) != 0))
                {
                    if (ctrl is CheckBox)
                    {
                        ((CheckBox)ctrl).Checked = false;
                    }
                    if (ctrl is TextBox)
                    {
                        ctrl.Text = "";
                    }
                    ctrl.Enabled = false;
                }
            }
            tbLockByte0.Text = "00";
            tbLockByte1.Text = "00";
            tbLockByte2.Text = "00";
            tbLockByte3.Text = "00";
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}

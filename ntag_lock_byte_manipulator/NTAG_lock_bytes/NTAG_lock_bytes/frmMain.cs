using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uFCoderMulti;

namespace NTAG_lock_bytes
{
    public partial class frmMain : Form
    {        
        private bool reader_opened;
        private const int READER_CONTROLS_AFFECTED = 1;
        private const int NTAG203_CONTROLS_AFFECTED = 2;
        private const int ULTRALIGHT_CONTROLS_AFFECTED = 4;

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
                fixed (byte* f_rdsn = reader_sn)
                status = uFCoder.GetReaderSerialDescription(f_rdsn);
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

                tbDeviceType.Text = "0x" + Convert.ToString(reader_type, 16);
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

        private void enableControls(UInt32 mask)
        {
            int i = 1;

            foreach (Control ctrl in this.Controls)
            {
                if ((Convert.ToUInt32(ctrl.Tag) & mask) != 0)
                {
                    ctrl.Enabled = true;
                }
            }
        }

        private void disableControls(UInt32 mask)
        {
            foreach (Control ctrl in this.Controls)
            {
                if ((Convert.ToUInt32(ctrl.Tag) & mask) != 0)
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
        }
    }
}

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
    public partial class frmMain : Form
    {
        UInt32 tmpAutoSleepTime = 0;

        public frmMain()
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
                byte tmp;
                status = uFCoder.AutoSleepGet(out tmp);
                if (status == DL_STATUS.UFR_OK)
                {
                    if (tmp == 0xFF)
                        tmp = 0;
                    tmpAutoSleepTime = tmp;
                    if ((tmp != 0) && (tmp != 0xFF))
                    {
                        chkEnableAutoSleep.Checked = true;
                    }
                }

                statusReader.Text = "Reader connected";
                tbDeviceType.Text = Convert.ToString((long)reader_type, 16).ToUpper();
                tbDeviceSerialNr.Text = System.Text.Encoding.UTF8.GetString(reader_sn);

                btnOpen.Enabled = false;
                btnSleep.Enabled = true;
                btnWakeUp.Enabled = true;
                btnClose.Enabled = true;
                chkEnableAutoSleep.Enabled = true;
                btnSetAutoSleep.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DL_STATUS status;

            status = uFCoder.ReaderClose();

            if (status == DL_STATUS.UFR_OK)
            {
                tbDeviceSerialNr.Text = "";
                tbDeviceType.Text = "";
                statusReader.Text = "Reader not connected";
                chkEnableAutoSleep.Checked = false;
                chkEnableAutoSleep.Enabled = false;
                btnSetAutoSleep.Enabled = false;
                btnSleep.Enabled = false;
                btnWakeUp.Enabled = false;
                btnClose.Enabled = false;
                btnOpen.Enabled = true;
            }
        }

        private void chkEnableAutoSleep_CheckedChanged(object sender, EventArgs e)
        {
            statusReader.Text = "";
            if (chkEnableAutoSleep.Checked)
            {
                lbAutoSleepTime.Enabled = true;
                lbSeconds.Enabled = true;
                numAutoSleepTime.Enabled = true;
                numAutoSleepTime.Value = tmpAutoSleepTime;
            }
            else
            {
                lbAutoSleepTime.Enabled = false;
                lbSeconds.Enabled = false;
                numAutoSleepTime.Enabled = false;
                tmpAutoSleepTime = (UInt32)numAutoSleepTime.Value;
                numAutoSleepTime.Value = 0;
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnClose.Enabled)
            {
                btnClose_Click(sender, e);
            }
        }

        private void btnSetAutoSleep_Click(object sender, EventArgs e)
        {
            DL_STATUS status;

            statusReader.Text = "Please wait...";
            status = uFCoder.AutoSleepSet((byte)numAutoSleepTime.Value);
            if (status == DL_STATUS.UFR_OK)
            {
                if ((byte)numAutoSleepTime.Value == 0)
                {
                    statusReader.Text = "Auto-sleep mode successfuly disabled";
                }
                else
                {
                    statusReader.Text = "Auto-sleep mode set successfuly";
                }
            }
            else
            {
                statusReader.Text = "Error: " + status.ToString();
            }
        }

        private void btnSleep_Click(object sender, EventArgs e)
        {
            DL_STATUS status;

            statusReader.Text = "Please wait...";
            status = uFCoder.UfrEnterSleepMode();
            if (status == DL_STATUS.UFR_OK)
            {
                statusReader.Text = "Device is in sleep mode";
            }
            else
            {
                statusReader.Text = "Error: " + status.ToString();
            }
        }

        private void btnWakeUp_Click(object sender, EventArgs e)
        {
            DL_STATUS status;

            statusReader.Text = "Please wait...";
            status = uFCoder.UfrLeaveSleepMode();
            if (status == DL_STATUS.UFR_OK)
            {
                statusReader.Text = "Device is woken";
            }
            else
            {
                statusReader.Text = "Error: " + status.ToString();
            }
        }
    }
}

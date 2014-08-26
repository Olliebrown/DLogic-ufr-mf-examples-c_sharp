using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uFCoderMulti; // DL_STATUS

namespace uFR_multiDLL_tester
{
    using UFR_HANDLE = System.UIntPtr;

    public partial class frmMultiuFRTester : Form
    {
        int block = 0;
        List<uFReader> readers_list = new List<uFReader>();

        DL_STATUS status;
        string msg;

        public frmMultiuFRTester()
        {
            InitializeComponent();

            SetupDataGridView();

            //eSector.SelectedIndex = 0;
            //eBlockSec.SelectedIndex = 0;
        }

        private void error_wr(string pre_text, DL_STATUS status)
        {
            string out_text = pre_text + ": ";
            out_text += status;
            // out_text += Environment.NewLine;

            memoDebug.AppendText(out_text);

            memoDebug.Update();
        }

        private void prndbg(string message)
        {
            string tmp;

            tmp = Environment.NewLine;
            tmp += "================================================";
            tmp += Environment.NewLine;
            tmp += message;
            tmp += Environment.NewLine;

            memoDebug.AppendText(tmp);
            memoDebug.Update();
        }

        private void update_block()
        {
            int sector;
            int blocksec;


            try
            {
                sector = Convert.ToInt32(eSector.Text);
                blocksec = Convert.ToInt32(eBlockSec.Text);
            }
            catch
            {
                sector = 0;
                blocksec = 0;
            }

            block = sector * 4 + blocksec;

            eBlock.Text = Convert.ToString(block);

        }

        // ==========================================================

        private void SetupDataGridView()
        {
            gridReader.ColumnCount = 6;

            gridReader.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            gridReader.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridReader.ColumnHeadersDefaultCellStyle.Font =
                new Font(gridReader.Font, FontStyle.Bold);

            gridReader.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            gridReader.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            gridReader.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            gridReader.GridColor = Color.Black;
            gridReader.RowHeadersVisible = false;

            gridReader.Columns[0].Name = "Index";
            gridReader.Columns[1].Name = "Reader SN";
            gridReader.Columns[2].Name = "Reader Type";
            gridReader.Columns[3].Name = "FTDI Serial";
            gridReader.Columns[4].Name = "FTDI Description";
            gridReader.Columns[5].Name = "Opened";
            //gridReader.Columns[4].DefaultCellStyle.Font =
            //    new Font(gridReader.DefaultCellStyle.Font, FontStyle.Italic);

            gridReader.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            gridReader.MultiSelect = false;
            //gridReader.Dock = DockStyle.Fill;

            //gridReader.CellFormatting += new
            //    DataGridViewCellFormattingEventHandler(
            //    gridReader_CellFormatting);
        }

        //===========================================================

        private void readers_get_count()
        {
            int NumberOfDevices;

            foreach (uFReader reader in readers_list)
            {
                if (reader.opened) // Will match once
                {
                    reader.close();

                    msg = "Closed reader: " + reader.get_designator();
                    prndbg(msg);
                }
            }

            readers_list.Clear();

            gridReader.Rows.Clear();
            gridReader.Update();

            msg = "( All opened readers are closed now ! )" + Environment.NewLine;
            msg += "Checking... Create new list... please wait...";
            prndbg(msg);

            NumberOfDevices = uFReader.get_reader_count();

            msg = "Device found: " + NumberOfDevices.ToString();
            prndbg(msg);

            for (int i = 0; i < NumberOfDevices; i++)
            {
                uFReader ufr = new uFReader(i);
                readers_list.Add(ufr);

                gridReader.Rows.Add(ufr.get_info());
                gridReader.Update();
            }
        }

        private void readers_get_info()
        {
            if (0 == readers_list.Count)
            {
                msg = "No D-LOGIC uFReader device connected !" + Environment.NewLine;
                msg += "( connect uFR device(s) and use click Get Count )";
                prndbg(msg);

                return;
            }

            // check all connected readers
            // for descrition, types, serials

            gridReader.Rows.Clear();

            foreach (uFReader ufr in readers_list)
            {
                gridReader.Rows.Add(ufr.get_info());
            }
        }

        private void reader_open(int idx)
        {
            if (readers_list.Count == 0)
                return;

            uFReader ufr = readers_list[idx];

            status = ufr.open();
            error_wr("ReaderList_OpenByIndex()", status);

            if (DL_STATUS.UFR_OK == status)
            {
                msg = ufr + "connected.";
            }
            else
            {
                msg = ufr + "NOT connected !";
            }
            prndbg(msg);

            gridReader.Rows[idx].SetValues(ufr.get_info());
            gridReader.Update();
        }

        private void reader_close(int idx)
        {
            if (readers_list.Count == 0)
                return;

            uFReader ufr = readers_list[idx];

            status = ufr.close();

            if (status == DL_STATUS.UFR_OK)
            {
                msg = ufr + ": closed.";
            }
            else
            {
                msg = ufr + ": NOT closed ! >>> " + status;
            }

            prndbg(msg);

            gridReader.Rows[idx].SetValues(ufr.get_info());
            gridReader.Update();
        }

        //------------------------------------------------------
        private void data_rd()
        {
            if (readers_list.Count == 0)
                return;

            uFReader ufr = readers_list[gridReader.CurrentRow.Index];

            byte[] data = new byte[16];
            int block_nr = Convert.ToInt32(eBlock.Text);

            eData.Text = "";

            status = ufr.read(block_nr, data);

            msg = ufr + "read";
            error_wr(msg, status);

            if (status != DL_STATUS.UFR_OK)
                return;

            msg = "Data: ";
            msg += BitConverter.ToString(data);
            prndbg(msg);

            eData.Text = System.Text.Encoding.UTF8.GetString(data);
        }

        private void data_wr()
        {
            if (readers_list.Count == 0)
                return;

            uFReader ufr = readers_list[gridReader.CurrentRow.Index];

            byte[] data = new byte[16];
            int block_nr = Convert.ToInt32(eBlock.Text);

            byte[] data1 = System.Text.Encoding.ASCII.GetBytes(eData.Text);

            int data_size = eData.Text.Length;

            if (data_size > data.Length)
                data_size = data.Length;

            Array.Copy(data1, data, data_size);

            status = ufr.write(block_nr, data);

            msg = ufr + "write";
            error_wr(msg, status);

        }
        //===========================================================
        

        private void bGetCount_Click(object sender, EventArgs e)
        {
            readers_get_count();
        }

        private void bGetInfo_Click(object sender, EventArgs e)
        {
            readers_get_info();
        }

        private void bOpenByIdx_Click(object sender, EventArgs e)
        {
            reader_open(gridReader.CurrentRow.Index);
        }

        private void bCloseByIdx_Click(object sender, EventArgs e)
        {
            reader_close(gridReader.CurrentRow.Index);
        }

        //===========================================================

        private void bOpenAll_Click(object sender, EventArgs e)
        {
            readers_get_count();

            if (readers_list.Count == 0)
                return;

            foreach (uFReader ufr in readers_list)
            {
                reader_open(ufr.list_idx);
            }

            bOpenAll.Enabled = false;
            bCloseAll.Enabled = true;
        }

        private void bCloseAll_Click(object sender, EventArgs e)
        {
            foreach (uFReader ufr in readers_list)
            {
                reader_close(ufr.list_idx);
            }

            bOpenAll.Enabled = true;
            bCloseAll.Enabled = false;
        }

        //-----------------------------------------------------------

        private void eSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_block();
        }

        private void eBlockSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_block();
        }

        //-----------------------------------------------------------

        private void cbPollReaders_CheckedChanged(object sender, EventArgs e)
        {
            timerPoll.Enabled = cbPollReaders.Checked;
            cbPollReaders.BackColor = cbPollReaders.Checked ? Color.Lime : SystemColors.Control;
        }

        private void timerPoll_Tick(object sender, EventArgs e)
        {
            if (!cbPollReaders.Checked)
                return;

            bool detected = false;
            DL_STATUS status;
            string asDate;
            string asFTDI;
            string str;

            // only info with card will show
            CARD_SAK Sak = CARD_SAK.UNKNOWN;
            byte[] baUid = new byte[7];

            foreach (uFReader ufr in readers_list)
            {
                if (!ufr.opened)
                    continue;

                status = ufr.GetCardIdEx(ref Sak, ref baUid);

                if (status != DL_STATUS.UFR_OK)
                    continue;

                // CARD OK
                asDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                asFTDI = ufr.ftdi_sn;

                str = asDate + " | [" + asFTDI + "] | ";

                   // return hex.Replace("-", "");
                
                str += BitConverter.ToString(baUid);
                str += " (" + baUid.Length + ") | ";
                
                str += Sak;
                str += Environment.NewLine;

                memoDetected.AppendText(str);
                memoDetected.Update();

                detected = true;
            }

            if (detected)
                // try
                memoDetected.SaveFile(eFileNameDetectedCard.Text);
        }

        private void gridReader_SelectionChanged(object sender, EventArgs e)
        {
            eReader.Text = gridReader.CurrentRow.Index.ToString();
        }

        private void btWriteData_Click(object sender, EventArgs e)
        {
            data_wr();
        }

        private void btReadData_Click(object sender, EventArgs e)
        {
            data_rd();
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mifare
{
    public partial class frmViewAll : Form
    {
        public frmViewAll()
        {
            InitializeComponent();
        }
        private UInt32 result;
        const byte AUTH1A = 96,
                   AUTH1B = 97,
                   DL_OK = 0,
                   RES_OK_LIGHT = 1,
                   RES_OK_SOUND = 4,
                   ERR_LIGHT = 2,
                   ERR_SOUND = 2;

        void DrawGridData(Boolean press_read_data)
        {
            byte auth_mode = AUTH1A;
            byte key_index = 0;
            byte[] block_data = new byte[16];
            unsafe
            {
                fixed(byte* PData=block_data)
                    if ((result = ufCoder1x.BlockRead(PData, 0, auth_mode, key_index)) == 14) auth_mode = AUTH1B; else auth_mode = AUTH1A;
            }
            lvViewAll.Columns.Add("S", (lvViewAll.Width - 5) / 15);
            lvViewAll.Columns.Add("BiS", (lvViewAll.Width - 5) / 15);
            lvViewAll.Columns.Add("Blo", (lvViewAll.Width - 5) / 15);           
            for (byte br = 0; br < 16; br++)
            {
                lvViewAll.Columns.Add(br.ToString(), (lvViewAll.Width - 5) / 18);
            }
            byte block_count = 0;
            byte sector_count = 0;
            byte bis_count = 0;

            while (block_count < 63)
            {
                bis_count = 0;
                while (bis_count < 3)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = sector_count.ToString();
                    lvi.SubItems.Add(bis_count.ToString());
                    lvi.SubItems.Add(block_count.ToString());
                    lvi.BackColor = Color.Silver;
                    if (press_read_data)
                    {
                        unsafe
                        {
                            fixed (byte* PData = block_data)                                                         
                                result = ufCoder1x.BlockRead(PData, block_count, auth_mode, key_index);
                            
                        }
                        
                            if (!rbHex.Checked)
                            {
                                for (byte br = 0; br < 16; br++)
                                    lvi.SubItems.Add(System.Text.Encoding.ASCII.GetString(block_data, br, 1));
                            }
                            else
                            {
                                for (byte br = 0; br < 16; br++)
                                    lvi.SubItems.Add((block_data[br].ToString("X")));
                            }
                         
                    }
                    lvViewAll.Items.Add(lvi);
                    bis_count++;
                    block_count++;
                }
                block_count++;
                ListViewItem lvs = new ListViewItem();
                lvs.Text = "SCT";
                lvs.SubItems.Add("SCT");
                lvs.SubItems.Add("SCT");
                lvs.Font = new Font("Verdana", 8, FontStyle.Bold);
                lvs.ForeColor = Color.White;
                lvs.BackColor = Color.SteelBlue;
                lvViewAll.Items.Add(lvs);                   
                sector_count++;
        }
            if (press_read_data)
            {
                if (result == DL_OK)
                {
                    ufCoder1x.ReaderUISignal(RES_OK_LIGHT, RES_OK_SOUND);
                    Globals GB = new Globals();
                    GB.ERRORS_CODE(result, stbFunctionError);
                    GB = null;
                }
                else
                {
                    ufCoder1x.ReaderUISignal(ERR_LIGHT, ERR_SOUND);
                    Globals GB = new Globals();
                    GB.ERRORS_CODE(result, stbFunctionError);
                    GB = null;
                }
            }
      
     }
    
        private void frmViewAll_Load(object sender, EventArgs e)
        {
           DrawGridData(false);  
        }

        private void btnReadCard_Click(object sender, EventArgs e)
        {
            Globals GL = new Globals();
            if (GL.FunctionStart || GL.ReaderStart) return;
            GL.FunctionStart = true;
              lvViewAll.Clear();
              DrawGridData(true);
            GL.FunctionStart = false;
            GL = null;
        }

           

        
    }
}

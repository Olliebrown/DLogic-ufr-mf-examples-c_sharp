using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace uFrAdvance
{
    using DL_STATUS = System.UInt32;
    public partial class frmViewAll : Form
    {
        private
              Globals GL = new Globals();
        public frmViewAll()
        {
            InitializeComponent();
        }
       //authenticate
        const byte MIFARE_AUTHENT1A = 0x60,
                   MIFARE_AUTHENT1B = 0x61;

        const byte DL_OK            = 0x00;
                   

        //for error                    
        const byte FRES_OK_LIGHT    = 0x04,
                   FRES_OK_SOUND    = 0x00,
                   FERR_LIGHT       = 0x02,
                   FERR_SOUND       = 0x00;

        static int iMaxBlock = 0;

        void DrawNTULGridData()
        {

            byte bAuthMode     = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
            byte bKeyIndex     = System.Convert.ToByte(cboKeyIndex.Text);
            byte[] baBlockData = new byte[4];
            byte[] baPageData  = new byte[16];
            byte keyIndex      = System.Convert.ToByte(cboKeyIndex.Text);
            DL_STATUS iFResult = 0;


            iMaxBlock = GL.MaxBlock(GL.TypeOfCard);

            lvViewAll.Columns.Add("PAGE", (lvViewAll.Width) / 10);
            lvViewAll.BackColor = Color.Silver;
            for (byte br = 1; br < 5; br++)
            {
                lvViewAll.Columns.Add(br.ToString(), (lvViewAll.Width) / 7);
            }

            pBar.Visible = true;
            pBar.Maximum = iMaxBlock;

            unsafe
            {
                fixed (byte* pPageData = baPageData)
                    for (int i = 4; i <= iMaxBlock; i++)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = i.ToString();


                        iFResult = uFCoder1x.BlockRead(pPageData, (ushort)(i), bAuthMode,keyIndex);
                        if (iFResult != DL_OK) break;
                        if (!rbHex.Checked)
                        {
                            for (byte br = 0; br < 4; br++)
                                lvi.SubItems.Add(System.Text.Encoding.ASCII.GetString(baPageData, br, 1));
                        }
                        else
                        {
                            for (byte br = 0; br < 4; br++)
                                lvi.SubItems.Add("0x"+baPageData[br].ToString("X2"));
                        }

                        pBar.Value = i;
                        lvViewAll.Items.Add(lvi);
                    }
            }
            pBar.Visible = false;
            if (iFResult == DL_OK)
            {
                uFCoder1x.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                GL.SetStatusBar(iFResult, stbFunctionError);
            }
            else
            {
                uFCoder1x.ReaderUISignal(FERR_LIGHT, FERR_SOUND);
                GL.SetStatusBar(iFResult, stbFunctionError);
            }     
        }


        void Draw1k4kGridData()
        {
            DL_STATUS iFResult    = 0;
            byte bAuthMode        = (rbAUTH1A.Checked) ? MIFARE_AUTHENT1A : MIFARE_AUTHENT1B;
            byte bKeyIndex        = System.Convert.ToByte(cboKeyIndex.Text);            
            byte[] baBlockData    = new byte[16];
            
            short shBISCount      = 0;
            ushort shBlockCount   = 0;
            byte bSectorCounter   = 0;
            byte bBISCounter      = 3;

            iMaxBlock = GL.MaxBlock(GL.TypeOfCard);

            lvViewAll.Columns.Add("S", (lvViewAll.Width - 5) / 15);
            lvViewAll.Columns.Add("BiS", (lvViewAll.Width - 5) / 15);
            lvViewAll.Columns.Add("Blo", (lvViewAll.Width - 5) / 15);

            for (byte br = 0; br < 16; br++)
            {
                lvViewAll.Columns.Add(br.ToString(), (lvViewAll.Width - 5) / 18);
            }

            pBar.Visible=true;
            pBar.Maximum=iMaxBlock;

            while (shBlockCount < iMaxBlock)
            {
                shBISCount = 0;
                while (shBISCount < bBISCounter)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = bSectorCounter.ToString();
                    lvi.SubItems.Add(shBISCount.ToString());
                    lvi.SubItems.Add(shBlockCount.ToString());
                    lvi.BackColor = Color.Silver;
                    
                        unsafe
                        {
                            fixed (byte* PData = baBlockData)                                                         
                                iFResult = uFCoder1x.BlockRead(PData, shBlockCount, bAuthMode, bKeyIndex);                            
                        }
                        
                            if (!rbHex.Checked)
                            {
                                for (byte br = 0; br < 16; br++)
                                    lvi.SubItems.Add(System.Text.Encoding.ASCII.GetString(baBlockData, br, 1));
                            }
                            else
                            {
                                for (byte br = 0; br < 16; br++)
                                    lvi.SubItems.Add((baBlockData[br].ToString("X")));
                            }
                         
                    
                    lvViewAll.Items.Add(lvi);
                    shBISCount++;
                    shBlockCount++;
                }
                shBlockCount++;
                pBar.Value=shBlockCount;

               if (bSectorCounter >= 31 && shBlockCount % 16 == 0)
                {
                    bSectorCounter++;
                    bBISCounter = 15;
                }
                else
                    bSectorCounter++;

                ListViewItem lvs = new ListViewItem();
                lvs.Text      = "SCT";
                lvs.SubItems.Add("SCT");
                lvs.SubItems.Add("SCT");
                lvs.Font      = new Font("Verdana", 8, FontStyle.Bold);
                lvs.ForeColor = Color.White;
                lvs.BackColor = Color.SteelBlue;
                lvViewAll.Items.Add(lvs);                                                                                  
        }
                pBar.Visible=false;
           
                if (iFResult == DL_OK)
                {
                    uFCoder1x.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult,stbFunctionError);
                }
                else
                {
                    uFCoder1x.ReaderUISignal(FERR_LIGHT, FERR_SOUND);
                    GL.SetStatusBar(iFResult, stbFunctionError);
                }                  
     }
    
        private void frmViewAll_Load(object sender, EventArgs e)
        {
            
        }

        private void btnReadCard_Click(object sender, EventArgs e)
        {
             
            if (GL.FunctionOn || GL.LoopStatus) return;
            try
            {
                byte bCardType = GL.TypeOfCard;
                GL.FunctionOn = true;                
                lvViewAll.Clear();
                if (bCardType == (byte)uFrAdvance.Globals.DLCARDTYPE.DL_NTAG_203 || 
                    bCardType == (byte)uFrAdvance.Globals.DLCARDTYPE.DL_MIFARE_ULTRALIGHT ||
                    bCardType == (byte)uFrAdvance.Globals.DLCARDTYPE.DL_MIFARE_ULTRALIGHT_C)
                    DrawNTULGridData();
                else  
                    if(bCardType == (byte)uFrAdvance.Globals.DLCARDTYPE.DL_MIFARE_CLASSIC_1K || 
                       bCardType == (byte)uFrAdvance.Globals.DLCARDTYPE.DL_MIFARE_CLASSIC_4K ||
                       bCardType == (byte)uFrAdvance.Globals.DLCARDTYPE.DL_MIFARE_PLUS_S_4K)
                       Draw1k4kGridData();
            }finally{
                GL.FunctionOn=false;
              }
        }

           

        
    }
}

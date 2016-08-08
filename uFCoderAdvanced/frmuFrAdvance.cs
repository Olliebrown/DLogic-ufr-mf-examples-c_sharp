


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Text.RegularExpressions;

namespace uFrAdvance
{
    using DL_STATUS = System.UInt32;
    
    public partial class frmuFrAdvance : Form
    {
        private
               Globals GL;
        public frmuFrAdvance()
        {
            InitializeComponent();
            GL = new Globals();
        }
        
        //card type     
        const byte MIFARE_CLASSIC_1k = 0x08,
                   MIFARE_CLASSIC_4k = 0x18;

        // sectors and blocks
        const byte MAX_SECTORS_1k    = 0x10,
                   MAX_SECTORS_4k    = 0x28,
                   MAX_BLOCK         = 0x0F;

        const byte DL_OK             = 0x00,
                   KEY_INDEX         = 0x00;

        //for error                    
        const byte FRES_OK_LIGHT     = 0x04,
                   FRES_OK_SOUND     = 0x00,
                   FERR_LIGHT        = 0x02,
                   FERR_SOUND        = 0x00;

        //authenticate
        const byte MIFARE_AUTHENT1A  = 0x60,
                   MIFARE_AUTHENT1B  = 0x61;


        const string GIT_PATH = "https://git.d-logic.net/nfc-rfid-reader-sdk/ufr-lib",
                     LIB_DIR_NAME = "ufr-lib";

        private static Boolean boCONN = false;                        
        
        
        void ShowForm(System.Windows.Forms.Form my_form)
        {
           
            my_form.TopLevel = false;
            my_form.Dock = DockStyle.Fill;
            my_form.Show();
            pnlConteiner.Controls.Add(my_form);
            my_form.BringToFront();
        }

        private void MenuItemsEnabled(Boolean isEnabled)
        {
            mnuValueBlockReadWriteItem.Enabled        = isEnabled;
            mnuBlockInSectorReadWriteItem.Enabled     = isEnabled;
            mnuValueBlockInSectorReadWrite.Enabled    = isEnabled;
            mnuValueBlockIncrDecrItems.Enabled        = isEnabled;
            mnuValueBlockInSectorIncrDecrItem.Enabled = isEnabled;
            mnuLinearFormatCardItem.Enabled           = isEnabled;
            mnuSectorTrailerWriteItems.Enabled        = isEnabled;
        }

        void CloneGitRepo(string gitPath)
        {
            string gitCommand = "git";
            string gitArgs = "";
            if (!System.IO.Directory.Exists(LIB_DIR_NAME))
            {
                string gitClone = String.Format("clone {0}", GIT_PATH);
                gitArgs = gitClone;
            }
            else
            {
                string gitUpdate = String.Format("pull origin {0}", GIT_PATH);
                gitArgs = gitUpdate;
            }

            try
            {
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(gitCommand, gitArgs);
                System.Diagnostics.Process someProcess = System.Diagnostics.Process.Start(startInfo);
                someProcess.WaitForExit();
                this.Timer.Enabled = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void MainThread()
        {
            
            
            ulong ulReaderType         = 0,
                  ulReaderSerial       = 0,            
                  ulCardSerial         = 0;
           
            String sBuffer="";
            byte bUidSize              = 0;
            byte [] baCardUID  = new byte[9];
            byte [] baUserData = new byte[15];

            DL_STATUS iRResult,
                      iCResult,
                      iFResult;

            GL.LoopStatus = true;
            
            if (!boCONN)
            {
                iRResult = uFCoder.ReaderOpen();
                if (iRResult == DL_OK)
                {
                    boCONN       = true;
                    pnlConn.Text = "CONNECTED";                                        
                    GL.SetStatusBar(iRResult,stbReader);
                }
                else
                {
                    pnlConn.Text         = "NOT CONNECTED";
                    txtReaderType  .Clear();
                    txtReaderSerial.Clear();
                    txtCardType    .Clear();
                    txtCardSerial  .Clear();
                    txtUIDSize     .Clear();
                    txtCardSerial     .Clear();
                    GL.SetStatusBar(iRResult, stbReader);
                }

            }
            if (boCONN)
            {
               byte bCardType   = 0,
                    bDLCardType = 0;
                unsafe
                {
                    fixed (byte *pCardUID = baCardUID)
                                        
                    if ((iRResult = uFCoder.GetReaderType(&ulReaderType)) == DL_OK)
                    {
                        txtReaderType.Text = "0x" + ulReaderType.ToString("X");
                        if ((iRResult = uFCoder.GetReaderSerialNumber(&ulReaderSerial)) == DL_OK)
                        {
                            txtReaderSerial.Text = "0x" + ulReaderSerial.ToString("X");
                        }

                        iCResult = uFCoder.GetDlogicCardType(&bDLCardType);

                        if (iCResult == DL_OK)
                        {
                             if (bDLCardType <= (byte)uFrAdvance.Globals.DLCARDTYPE.DL_NTAG_216 )
                            {
                                MenuItemsEnabled(false);
                            }
                           
                            uFCoder.GetCardIdEx(&bCardType, pCardUID, &bUidSize);
                            for (byte bBr = 0; bBr < bUidSize; bBr++)
                            {
                                sBuffer += baCardUID[bBr].ToString("X");
                            }
                            txtCardType.Text   = "0x" + bDLCardType.ToString("X2");
                            txtCardSerial.Text = "0x" + ulCardSerial.ToString("X");
                            txtUIDSize.Text    = "0x" + bUidSize.ToString("X");
                            txtCardSerial.Text = "0x" + sBuffer;
                            GL.TypeOfCard = bDLCardType;
                            GL.SetStatusBar(iCResult, stbCard);
                        }
                        else
                        {
                            MenuItemsEnabled(true);
                            txtCardType    .Clear();
                            txtCardSerial  .Clear();
                            txtUIDSize     .Clear();                            
                            GL.TypeOfCard = bCardType;
                            GL.SetStatusBar(iCResult, stbCard);                        
                        }

                        fixed (byte* PData = baUserData)
                        {
                            iFResult = uFCoder.ReadUserData(PData);
                        }
                        if (iFResult == DL_OK)
                            txtUserData.Text = System.Text.Encoding.ASCII.GetString(baUserData);
                        else
                            txtUserData.Text = "";

                    }
                    else
                    {
                        boCONN = false;
                        uFCoder.ReaderClose();
                        txtReaderType  .Clear();
                        txtReaderSerial.Clear();
                        txtCardType    .Clear();
                        txtCardSerial  .Clear();
                        txtUIDSize     .Clear();                        
                    }
                }
            }
            GL.LoopStatus=false;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!GL.FunctionOn)
                MainThread();
        }

       

        void Check_values(object sender)
        {
            
            TextBox TB = (TextBox)sender;
            if (TB.Text.Trim() == String.Empty)
            {
                TB.Focus();                
                TB.Undo();
            }

            if (chkHex.Checked) return;

            if (System.Convert.ToInt16(TB.Text) > 255)
            {
                MessageBox.Show("Wrong entry !\nYou must enter the numeric value of less than 255.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TB.Undo();
                TB.Focus();
                TB.SelectAll();
                //TB = null;
            }
        }
        void RB_Leave(object sender, EventArgs e)
        {
            Check_values(sender);

        }


        void RB_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox TB = (TextBox)sender;
            if (e.KeyChar == (char)Keys.Back) return;
            
            if (chkHex.Checked)
            {
               
                TB.MaxLength = 2;
                if (Regex.IsMatch(e.KeyChar.ToString(), "[^a-fA-F0-9]")) e.Handled = true;
            }
            else
            {
                TB.MaxLength = 3;
                if (Regex.IsMatch(e.KeyChar.ToString(), "[^0-9]")) e.Handled = true;
            }
           
        }

        private void btnReaderUISignal_Click(object sender, EventArgs e)
        {
           if (GL.FunctionOn || GL.LoopStatus) return;
           try
           {
               GL.FunctionOn=true;
               uFCoder.ReaderUISignal(cboLightMode.SelectedIndex, cboSoundMode.SelectedIndex); 
           }finally{
               GL.FunctionOn = false;
            }
        }

        private void btnWriteUserData_Click(object sender, EventArgs e)
        {
          
           if (GL.FunctionOn || GL.LoopStatus) return;
           
           try
           {
                GL.FunctionOn=true;
                if (txtNewUserData.Text == String.Empty)
                {
                    MessageBox.Show("You must enter any data !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNewUserData.Focus();
                    return;
                }
                DL_STATUS iFResult;                
                byte[] baNewUserData = new byte[16];               
                baNewUserData = System.Text.Encoding.ASCII.GetBytes(txtNewUserData.Text);
                unsafe
                {
                    fixed (byte* PData = baNewUserData)
                    {
                        iFResult = uFCoder.WriteUserData(PData);
                    }
                }
                if (iFResult == DL_OK)
                {
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult,stbReader);
                    
                }
                else
                {
                    uFCoder.ReaderUISignal(FERR_SOUND, FERR_SOUND);
                    GL.SetStatusBar(iFResult,stbReader);
                }
            }finally{
              
              GL.FunctionOn=false;
            }
        }

        private void btnReaderReset_Click(object sender, EventArgs e)
        {
            
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn = true;
                DL_STATUS iFResult;
                iFResult = uFCoder.ReaderReset();
                if (iFResult == DL_OK)
                {
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbReader);

                }
                else
                {
                    uFCoder.ReaderUISignal(FERR_SOUND, FERR_SOUND);
                    GL.SetStatusBar(iFResult, stbReader);
                }
           }
           finally
           {               
               GL.FunctionOn=false;
           }
                        
        }

        private void btnSoftRestart_Click(object sender, EventArgs e)
        {
           
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn = true;
                DL_STATUS iFResult;
                iFResult = uFCoder.ReaderSoftRestart();
                if (iFResult == DL_OK)
                {
                    uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                    GL.SetStatusBar(iFResult, stbReader);

                }
                else
                {
                    uFCoder.ReaderUISignal(FERR_SOUND, FERR_SOUND);
                    GL.SetStatusBar(iFResult, stbReader);
                }
           }
           finally
           {               
               GL.FunctionOn=false;
           }
        }



        private void chkHex_CheckedChanged(object sender, EventArgs e)
        {

            switch (chkHex.Checked)
            {
                case true:

                    for (int i = 0; i <= pnlReaderKey.Controls.Count - 1; i++)
                    {
                        if (pnlReaderKey.Controls[i].Name == "txtReaderKey")
                        {

                            pnlReaderKey.Controls[i].Text = Convert.ToInt32(pnlReaderKey.Controls[i].Text).ToString("X");
                        }
                    }
                    break;
                case false:
                    for (int i = 0; i <= pnlReaderKey.Controls.Count - 1; i++)
                    {
                        if (pnlReaderKey.Controls[i].Name == "txtReaderKey")
                        {

                            pnlReaderKey.Controls[i].Text = int.Parse(pnlReaderKey.Controls[i].Text, System.Globalization.NumberStyles.HexNumber).ToString();
                        }
                    }
                    break;
            }
        }

        private void btnReaderKeyWrite_Click(object sender, EventArgs e)
        {
           
            if (GL.FunctionOn || GL.LoopStatus) return;

            try
            {
                GL.FunctionOn      = true;
                byte bKeyIndex     = System.Convert.ToByte(cboKeyIndex.Text);
                byte[] baReaderKey = new byte[6];
                byte bCount        = 0;
                DL_STATUS iFResult;
                

            foreach (Control ctrl in pnlReaderKey.Controls)
            {
                if (ctrl.Name == "txtReaderKey")
                {
                    if (!chkHex.Checked)
                        baReaderKey[bCount] = Convert.ToByte(ctrl.Text);
                    else
                        baReaderKey[bCount] = Convert.ToByte(int.Parse(ctrl.Text, System.Globalization.NumberStyles.HexNumber).ToString());
                       bCount++;
                }
            }
            unsafe
            {
                fixed (byte* PData = baReaderKey)
                {
                    iFResult = uFCoder.ReaderKeyWrite(PData, bKeyIndex);
                }
            }
            if (iFResult == DL_OK)
            {
                uFCoder.ReaderUISignal(FRES_OK_LIGHT, FRES_OK_SOUND);
                GL.SetStatusBar(iFResult, stbReader);

            }
            else
            {
                uFCoder.ReaderUISignal(FERR_SOUND, FERR_SOUND);
                GL.SetStatusBar(iFResult, stbReader);
            }
           }
           finally
           {
               GL.FunctionOn=false;
           }
        }


        private void mnuExitItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuBlockReadWriteItem_Click(object sender, EventArgs e)
        {

            frmBlockReadWrite BlockReadWrite = new frmBlockReadWrite();
            ShowForm(BlockReadWrite);

        }

        private void linearReadWriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLinearReadWrite LinearReadWrite = new frmLinearReadWrite();
            ShowForm(LinearReadWrite);
        }

        private void mnuBlockInSectorReadWriteItem_Click(object sender, EventArgs e)
        {
            frmBlockInSectorReadWrite BlockInSectorReadWrite = new frmBlockInSectorReadWrite();
            ShowForm(BlockInSectorReadWrite);
        }

        private void mnuValueBlockReadWriteItem_Click(object sender, EventArgs e)
        {
            frmValueBlockReadWrite ValueBlockReadWrite = new frmValueBlockReadWrite();
            ShowForm(ValueBlockReadWrite);
        }

        private void llblNfcSdk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(llblNfcSdk.Text);
        }

        private void mnuValueBlockIncrDecrItems_Click(object sender, EventArgs e)
        {
            frmValueBlockIncrDecr ValueBlockIncrDecr = new frmValueBlockIncrDecr();
            ShowForm(ValueBlockIncrDecr);
        }

        private void mnuValueBlockInSectorReadWrite_Click(object sender, EventArgs e)
        {
            frmValueBlockInSectorReadWrite ValueBlockInSectorReadWrite = new frmValueBlockInSectorReadWrite();
            ShowForm(ValueBlockInSectorReadWrite);
        }

        private void mnuValueBlockInSectorIncrDecrItem_Click(object sender, EventArgs e)
        {
            frmValueBlockInSectorIncremDecrem ValueBlockInSectorIncDecr = new frmValueBlockInSectorIncremDecrem();
            ShowForm(ValueBlockInSectorIncDecr);
        }

        private void mnuSectorTrailerWriteItems_Click(object sender, EventArgs e)
        {
            frmSectorTrailerWrite SectorTrailerWrite = new frmSectorTrailerWrite();
            ShowForm(SectorTrailerWrite);
        }



        private void mnuLinearFormatCardItem_Click(object sender, EventArgs e)
        {
            frmLinearFormatCard LinearFormatCard = new frmLinearFormatCard();
            ShowForm(LinearFormatCard);
        }

        private void mnuViewAllItem_Click_1(object sender, EventArgs e)
        {
            frmViewAll ViewAll = new frmViewAll();
            ShowForm(ViewAll);
        }

        private void frmuFrAdvance_Load(object sender, EventArgs e)
        {
            
            cboLightMode.SelectedItem = cboLightMode.Items[0];
            cboSoundMode.SelectedItem = cboSoundMode.Items[0];
            cboKeyIndex.SelectedItem  = cboKeyIndex.Items[0];            
            for (int br = 0; br < 6; br++)
            {
                System.Windows.Forms.TextBox RB = new TextBox();
                RB.Width = 31;
                RB.Height = 21;
                RB.Location = new Point(21 + (RB.Width * br + 2), 17);
                RB.Name = "txtReaderKey";
                RB.Text = "255";
                RB.MaxLength = 3;
                RB.Font = new Font("Verdana", 8, FontStyle.Bold);
                RB.KeyPress += new KeyPressEventHandler(RB_KeyPress);
                RB.Leave += new EventHandler(RB_Leave);
                RB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                pnlReaderKey.Controls.Add(RB);
            }

            frmLinearReadWrite LinearReadWrite = new frmLinearReadWrite();
            ShowForm(LinearReadWrite);            
            GL.FullRangeERROR_CODES();

            CloneGitRepo(GIT_PATH);
        }

        private void mnuHardwareFirmwareVersionItem_Click(object sender, EventArgs e)
        {
            byte bRHardwareMajor,
                 bRHardwareMinor,
                 bRFirmwareMajor,
                 bRFirmwareMinor;                       
            unsafe
            {
               uFCoder.GetReaderHardwareVersion(&bRHardwareMajor,&bRHardwareMinor);
               uFCoder.GetReaderFirmwareVersion(&bRFirmwareMajor, &bRFirmwareMinor);

               MessageBox.Show("Hardware version : " + bRHardwareMajor.ToString() + "." + bRHardwareMajor.ToString() + 
                               "\nFirmware  version : " + bRFirmwareMajor.ToString() + "." + bRFirmwareMinor.ToString(), 
                               "Hardware and Firmware version", MessageBoxButtons.OK,MessageBoxIcon.Information); 
                               
            }
             
        }

       















    }
}

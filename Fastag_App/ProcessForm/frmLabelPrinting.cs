using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using SATOPrinterAPI;
using System.Threading;
using System.Data.OleDb;

namespace Fatag_App
{
    public partial class frmLabelPrinting : Form
    {
        #region Variables

        Printer SATOPrinter = null;
        string UsbPortId = "";
        int stopprint = 0;
        DataTable dt = new DataTable();
        Dal oDal = new Dal();
        TagDetails oTag = new TagDetails();
        #endregion

        #region Form Methods

        public frmLabelPrinting()
        {
            try
            {
                InitializeComponent();
                SATOPrinter = new Printer();
            }
            catch (Exception ex)
            {
                ClsGlobal.SetErrorMessage(ex.Message, lblMessage);
            }
        }

        private void frmModelMaster_Load(object sender, EventArgs e)
        {
            try
            {
                lblWait.Visible = false;
                ClsGlobal.ClearMessage(lblMessage);
                Refresh_USBList();

            }
            catch (Exception ex)
            {
                ClsGlobal.SetErrorMessage(ex.Message, lblMessage);
            }
        }

        private void frmLabelPrinting_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SATOPrinter.Disconnect();
            }
            catch (Exception ex) { ClsGlobal.SetErrorMessage(ex.Message, lblMessage); }
        }

        #endregion

        #region Button Event
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ClsGlobal.ClearMessage(lblMessage);
                if (txtQty.Text.Trim() == "")
                {
                    ClsGlobal.ShowInfoMessageBox("Please browse excell sheet");
                    txtQty.Focus();
                    return;
                }
                pnlMain.Enabled = false;
                lblWait.Visible = true;
                int feed = 0;
                Application.DoEvents();

                /*
                 *    Since Printer is connected to USB, so we will use usb port it to connect to the printer,
                 *    So here we are checking whether we have usb port id or not
                 */
                if (UsbPortId != "")
                {
                    //It will set printer interface
                    if (SetInterface() == false)
                        return;
                }
                else
                {
                    ClsGlobal.ShowInfoMessageBox("Printer USB Port not found, check printer is connected or not or click on refresh button");
                    return;
                }
                //It will read the rfid tag read command from the file
                string RfidMemoryCommand = ReadRfidMemoryCommand();
                // string RfidWriteCommand = ReadRfidWriteCommand();
                if (RfidMemoryCommand == "")
                {
                    ClsGlobal.ShowInfoMessageBox("Rfid memory command data not found");
                    return;
                }
                //read the prn file
                string PrnFileData = ReadPrnFile();
                if (PrnFileData == "")
                {
                    ClsGlobal.ShowInfoMessageBox("Print prn data not found");
                    return;
                }
                //Manage no. of print count
                int PrintCount = 0;
                int PrintQty = dt.Rows.Count;
                for (int i = 0; i < PrintQty; i++)
                {
                    string RfidWriteCommand = ReadRfidWriteCommand();
                    byte[] cmddata = Utils.StringToByteArray(ControlCharReplace(RfidMemoryCommand));
                    byte[] receiveData = SATOPrinter.Query(cmddata);
                    string Barcodedata = dt.Rows[i]["Asset Number "].ToString();
                    string Location = dt.Rows[i]["Asset Location"].ToString();
                    if (receiveData != null)
                    {
                        string TagDetails = ControlCharConvert(Utils.ByteArrayToString(receiveData));
                        string[] ArrayTagData = TagDetails.Split(',');
                        if (ArrayTagData.Length >= 2)
                        {
                            string[] TagIdArray = ArrayTagData[2].Split(':');
                            if (TagIdArray.Length == 2)
                            {
                                string TagId = TagIdArray[1].Trim();                              
                                RfidWriteCommand = RfidWriteCommand.Replace("{EPCCODE}", "0000000000" + Barcodedata);
                                RfidWriteCommand = RfidWriteCommand.Replace("{ASSETCODE}", Barcodedata);
                                RfidWriteCommand = RfidWriteCommand.Replace("{LOCATION}", Location);
                                //RfidWriteCommand = RfidWriteCommand.Replace("{V1}", Barcodedata.Substring(0, 6));
                                //RfidWriteCommand = RfidWriteCommand.Replace("{V2}", Barcodedata.Substring(6, 6));
                                //RfidWriteCommand = RfidWriteCommand.Replace("{V3}", Barcodedata.Substring(12));

                                byte[] cmddataNew1 = Utils.StringToByteArray(ControlCharReplace(RfidWriteCommand));
                                // byte[] receiveDataNew = SATOPrinter.Query(cmddataNew);
                                //oTag.OrderID = dt.Rows[i]["Order ID"].ToString();
                                //oTag.SrNo = dt.Rows[i]["Sr# No#"].ToString();
                                //oTag.VehicleClass = dt.Rows[i]["Vehicle Class (VC)"].ToString();
                                //oTag.Usermemory = dt.Rows[i]["User memory"].ToString();
                                //oTag.EPCID = dt.Rows[i]["TagID/EPCID"].ToString();
                                //oTag.TagID = TagId;
                                //oTag.Barcodedata = dt.Rows[i]["Barcode data"].ToString();
                                //oTag.EPCMemory = dt.Rows[i]["EPC Memory (optional)"].ToString();
                                //oTag.VRC = dt.Rows[i]["VRC (optional)"].ToString();
                                //oTag.CreatedBy = ClsGlobal.UserId;


                                //oTag.DbType = EnumDbType.SELECT;
                                //DataTable dt2 = oDal.ManageUser(oTag);

                                //if (dt2.Rows.Count !=0)
                                //{

                                    WriteTagFile(dt.Rows[i]["Asset Number "].ToString(), dt.Rows[i]["Supplier Name"].ToString(), dt.Rows[i]["Po Number"].ToString(), dt.Rows[i]["MRC NO"].ToString(), dt.Rows[i]["Invoice Number"].ToString(), dt.Rows[i]["TAG No"].ToString(), dt.Rows[i]["Serial Number"].ToString(),dt.Rows[i]["Manufacturer"].ToString(), dt.Rows[i]["Asset Description"].ToString(), dt.Rows[i]["Asset Category"].ToString(), dt.Rows[i]["No Of Units"].ToString(), dt.Rows[i]["Asset Type"].ToString(), dt.Rows[i]["Asset Location"].ToString(), dt.Rows[i]["Depreciation Method"].ToString(), dt.Rows[i]["Depreciation Rate"].ToString(), dt.Rows[i]["Date Placed in Service"].ToString());
                                    Thread.Sleep(3500);
                                    if (stopprint == 1)
                                    {
                                        MessageBox.Show("Printing Stopped..");
                                        return;
                                    }
                                    else
                                    {
                                        //printing
                                        SATOPrinter.Send(cmddataNew1);
                                        PrintCount++;
                                        feed = 0;
                                    }

                                    ////Updating data after printing tag's
                                    //oTag.OrderID = dt.Rows[i]["Order ID"].ToString();
                                    //oTag.SrNo = dt.Rows[i]["Sr# No#"].ToString();
                                    //oTag.VehicleClass = dt.Rows[i]["Vehicle Class (VC)"].ToString();
                                    //oTag.Usermemory = dt.Rows[i]["User memory"].ToString();
                                    //oTag.EPCID = dt.Rows[i]["TagID/EPCID"].ToString();
                                    //oTag.TagID = TagId;
                                    //oTag.Barcodedata = dt.Rows[i]["Barcode data"].ToString();
                                    //oTag.EPCMemory = dt.Rows[i]["EPC Memory (optional)"].ToString();
                                    //oTag.VRC = dt.Rows[i]["VRC (optional)"].ToString();
                                    //oTag.CreatedBy = ClsGlobal.UserId;
                                    ////If saving data

                                    //oTag.DbType = EnumDbType.UPDATE;
                                    //DataTable dt1 = oDal.ManageUser(oTag);
                                //}
                                //else
                                //{
                                //    ClsGlobal.ShowErrorMessageBox("This Barcode data already printed with other TAG. Please verify the file and re-upload " + Barcodedata);
                                //    return;
                                //}

                               
                            }
                            else
                            {
                                ClsGlobal.ShowErrorMessageBox("Bad Tag : Tag id data length is not valid " + ArrayTagData[2]);
                              //  string RfidFeedCommand = ReadRfidFeedCommand();
                              //  byte[] cmddataNew2 = Utils.StringToByteArray(ControlCharReplace(RfidFeedCommand));
                              //  SATOPrinter.Send(cmddataNew2);
                              //  oTag.OrderID = dt.Rows[i]["Order ID"].ToString();
                              //  oTag.SrNo = dt.Rows[i]["Sr# No#"].ToString();
                              //  oTag.VehicleClass = dt.Rows[i]["Vehicle Class (VC)"].ToString();
                              //  oTag.Usermemory = dt.Rows[i]["User memory"].ToString();
                              //  oTag.EPCID = dt.Rows[i]["TagID/EPCID"].ToString();
                              //  oTag.TagID = "ERROR-" + ArrayTagData[2];
                              //  oTag.Barcodedata = dt.Rows[i]["Barcode data"].ToString();
                              //  oTag.EPCMemory = dt.Rows[i]["EPC Memory (optional)"].ToString();
                              //  oTag.VRC = dt.Rows[i]["VRC (optional)"].ToString();
                              //  oTag.CreatedBy = ClsGlobal.UserId;
                              //  //If saving data

                              //  oTag.DbType = EnumDbType.INSERT;
                              //  DataTable dt1 = oDal.ManageUser(oTag);
                              //  //i--;
                              ////  WriteTagFile_Error(dt.Rows[i]["Sr# No#"].ToString(), "Bad Tag : Error " + lblMessage.ToString());
                              //  //WriteTagFile(dt.Rows[i]["Sr# No#"].ToString(), dt.Rows[i]["Vehicle Class (VC)"].ToString(), "Bad Tag : Error " + lblMessage.ToString(), dt.Rows[i]["Barcode data"].ToString(), dt.Rows[i]["TagID/EPCID"].ToString(), dt.Rows[i]["VRC (optional)"].ToString(), dt.Rows[i]["User memory"].ToString(), dt.Rows[i]["EPC Memory (optional)"].ToString(), dt.Rows[i]["Order ID"].ToString());

                              //  PrintQty--;
                              //  feed++;
                              //  //WriteTagFile("Bad Tag : Tag id data length is not valid " + ArrayTagData[2]);
                              //  //ClsGlobal.SetErrorMessage("Bad Tag : Tag id data length is not valid " + ArrayTagData[2], lblMessage);
                              //  if (feed > 2)
                              //  {
                              //      if (MessageBox.Show("Bad Tag : Tag id data length is not valid " + ArrayTagData[2] + ", still want to continue", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                              //          continue;
                              //      else
                              //          break;
                              //  }
                            }
                        }
                        else
                        {
                           ClsGlobal.ShowErrorMessageBox("Bad Tag : Return tag data is not valid " + TagDetails);
                           // //WriteTagFile("Bad Tag : Return tag data is not valid " + TagDetails);
                           // string RfidFeedCommand = ReadRfidFeedCommand();
                           // byte[] cmddataNew2 = Utils.StringToByteArray(ControlCharReplace(RfidFeedCommand));
                           // SATOPrinter.Send(cmddataNew2);
                           // oTag.OrderID = dt.Rows[i]["Order ID"].ToString();
                           // oTag.SrNo = dt.Rows[i]["Sr# No#"].ToString();
                           // oTag.VehicleClass = dt.Rows[i]["Vehicle Class (VC)"].ToString();
                           // oTag.Usermemory = dt.Rows[i]["User memory"].ToString();
                           // oTag.EPCID = dt.Rows[i]["TagID/EPCID"].ToString();
                           // oTag.TagID = "ERROR-" + TagDetails;
                           // oTag.Barcodedata = dt.Rows[i]["Barcode data"].ToString();
                           // oTag.EPCMemory = dt.Rows[i]["EPC Memory (optional)"].ToString();
                           // oTag.VRC = dt.Rows[i]["VRC (optional)"].ToString();
                           // oTag.CreatedBy = ClsGlobal.UserId;
                           // //If saving data

                           // oTag.DbType = EnumDbType.INSERT;
                           // DataTable dt1 = oDal.ManageUser(oTag);
                           // // i--;
                           //// WriteTagFile_Error(dt.Rows[i]["Sr# No#"].ToString(), "Bad Tag : Error " + lblMessage.ToString());
                           // //WriteTagFile(dt.Rows[i]["Sr# No#"].ToString(), dt.Rows[i]["Vehicle Class (VC)"].ToString(), "Bad Tag : Error " + lblMessage.ToString(), dt.Rows[i]["Barcode data"].ToString(), dt.Rows[i]["TagID/EPCID"].ToString(), dt.Rows[i]["VRC (optional)"].ToString(), dt.Rows[i]["User memory"].ToString(), dt.Rows[i]["EPC Memory (optional)"].ToString(), dt.Rows[i]["Order ID"].ToString());

                           // PrintQty--;

                           // //ClsGlobal.SetErrorMessage("Bad Tag : Return tag data is not valid " + TagDetails, lblMessage);
                           // feed++;
                           // //WriteTagFile("Bad Tag : Tag id data length is not valid " + ArrayTagData[2]);
                           // //ClsGlobal.SetErrorMessage("Bad Tag : Tag id data length is not valid " + ArrayTagData[2], lblMessage);
                           // if (feed > 2)
                           // {

                           //     if (MessageBox.Show("Bad Tag: Return tag data is not valid " + TagDetails + ", still want to continue", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                           //         continue;
                           //     else
                           //         break;
                           // }
                        }
                    }
                    else
                    {
                        //WriteTagFile("Bad Tag : no data return from read command");
                        ClsGlobal.SetErrorMessage("Bad Tag: no data return from read command", lblMessage);
                        //string RfidFeedCommand = ReadRfidFeedCommand();
                        //byte[] cmddataNew2 = Utils.StringToByteArray(ControlCharReplace(RfidFeedCommand));
                        //SATOPrinter.Send(cmddataNew2);

                        //oTag.OrderID = dt.Rows[i]["Order ID"].ToString();
                        //oTag.SrNo = dt.Rows[i]["Sr# No#"].ToString();
                        //oTag.VehicleClass = dt.Rows[i]["Vehicle Class (VC)"].ToString();
                        //oTag.Usermemory = dt.Rows[i]["User memory"].ToString();
                        //oTag.EPCID = dt.Rows[i]["TagID/EPCID"].ToString();
                        //oTag.TagID = "ERROR-" + lblMessage;
                        //oTag.Barcodedata = dt.Rows[i]["Barcode data"].ToString();
                        //oTag.EPCMemory = dt.Rows[i]["EPC Memory (optional)"].ToString();
                        //oTag.VRC = dt.Rows[i]["VRC (optional)"].ToString();
                        //oTag.CreatedBy = ClsGlobal.UserId;
                        ////If saving data

                        //oTag.DbType = EnumDbType.INSERT;
                        //DataTable dt1 = oDal.ManageUser(oTag);
                        ////i--;
                        ////WriteTagFile_Error(dt.Rows[i]["Sr# No#"].ToString(), "Bad Tag : Error " + lblMessage.ToString());
                        ////WriteTagFile(dt.Rows[i]["Sr# No#"].ToString(), dt.Rows[i]["Vehicle Class (VC)"].ToString(), "Bad Tag : Error " + lblMessage.ToString(), dt.Rows[i]["Barcode data"].ToString(), dt.Rows[i]["TagID/EPCID"].ToString(), dt.Rows[i]["VRC (optional)"].ToString(), dt.Rows[i]["User memory"].ToString(), dt.Rows[i]["EPC Memory (optional)"].ToString(), dt.Rows[i]["Order ID"].ToString());

                        //PrintQty--;
                        //feed++;
                        ////WriteTagFile("Bad Tag : Tag id data length is not valid " + ArrayTagData[2]);
                        ////ClsGlobal.SetErrorMessage("Bad Tag : Tag id data length is not valid " + ArrayTagData[2], lblMessage);
                        //if (feed > 2)
                        //{
                        //    if (MessageBox.Show("Bad Tag : no data return from read command, still want to continue", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //        continue;
                        //    else
                        //        break;
                        //}
                    }
                }
                if (PrintCount >= 1)
                    ClsGlobal.SetSuccessMessage(PrintCount.ToString() + " labels print successfully!!", lblMessage);
            }
            catch (Exception ex)
            {
                ClsGlobal.ShowErrorMessageBox(ex.Message);
            }
            finally
            {
                pnlMain.Enabled = true;
                lblWait.Visible = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                btnRefresh.Enabled = false;
                Refresh_USBList();
                btnRefresh.Enabled = true;
            }
            catch (Exception ex) { ClsGlobal.ShowErrorMessageBox(ex.Message); }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                txtQty.Text = "";
                ClsGlobal.ClearMessage(lblMessage);
                btnRefresh_Click(sender, e);
            }
            catch (Exception ex)
            {
                ClsGlobal.SetErrorMessage(ex.Message, lblMessage);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Label Event
        private void lblMessage_DoubleClick(object sender, EventArgs e)
        {
            ClsGlobal.ShowInfoMessageBox(lblMessage.Text);
        }

        #endregion

        #region TextBox Events

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                ClsGlobal.ClearMessage(lblMessage);
                if (e.KeyChar != 8 && !char.IsNumber(e.KeyChar))
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                ClsGlobal.SetErrorMessage(ex.Message, lblMessage);
            }
        }

        #endregion

        #region Methods

        private void Refresh_USBList()
        {
            try
            {
                lblMessage.Text = "";
                UsbPortId = "";
                lblPrinterUSBPortId.Text = "Port Id :";
                bool found = false;
                foreach (Printer.USBInfo usbPorts in SATOPrinter.GetUSBList())
                {
                    UsbPortId = usbPorts.PortID;
                    found = true;
                    break;
                }
                if (UsbPortId == "" || found == false)
                {
                    ClsGlobal.ShowInfoMessageBox("Printer USB Port not found, check printer is connected or not or click on refresh button");
                }
                lblPrinterUSBPortId.Text += UsbPortId;
            }
            catch (Exception ex)
            {
                ClsGlobal.SetErrorMessage(ex.Message, lblMessage);
            }
        }
        private bool SetInterface()
        {
            try
            {
                //USB
                SATOPrinter.Interface = Printer.InterfaceType.USB;
                if (UsbPortId != "")
                {
                    SATOPrinter.USBPortID = UsbPortId;
                    return true;
                }
                else
                {
                    ClsGlobal.ShowInfoMessageBox("Printer USB Port not found, check printer is connected or not or click on refresh button");
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string ControlCharConvert(string data)
        {
            try
            {
                Dictionary<char, string> chrList = ControlCharList().ToDictionary(x => x.Value, x => x.Key);
                foreach (char key in chrList.Keys)
                {
                    data = data.Replace(key.ToString(), chrList[key]);
                }
                return data;
            }
            catch (Exception ex) { throw ex; }
        }
        private string ControlCharReplace(string data)
        {
            try
            {
                Dictionary<string, char> chrList = ControlCharList();
                foreach (string key in chrList.Keys)
                {
                    data = data.Replace(key, chrList[key].ToString());
                }
                return data;
            }
            catch (Exception ex) { throw ex; }
        }

        private Dictionary<string, char> ControlCharList()
        {
            try
            {
                Dictionary<string, char> ctr = new Dictionary<string, char>();
                ctr.Add("[NUL]", '\u0000');
                ctr.Add("[SOH]", '\u0001');
                ctr.Add("[STX]", '\u0002');
                ctr.Add("[ETX]", '\u0003');
                ctr.Add("[EOT]", '\u0004');
                ctr.Add("[ENQ]", '\u0005');
                ctr.Add("[ACK]", '\u0006');
                ctr.Add("[BEL]", '\u0007');
                ctr.Add("[BS]", '\u0008');
                ctr.Add("[HT]", '\u0009');
                ctr.Add("[LF]", '\u000A');
                ctr.Add("[VT]", '\u000B');
                ctr.Add("[FF]", '\u000C');
                ctr.Add("[CR]", '\u000D');
                ctr.Add("[SO]", '\u000E');
                ctr.Add("[SI]", '\u000F');
                ctr.Add("[DLE]", '\u0010');
                ctr.Add("[DC1]", '\u0011');
                ctr.Add("[DC2]", '\u0012');
                ctr.Add("[DC3]", '\u0013');
                ctr.Add("[DC4]", '\u0014');
                ctr.Add("[NAK]", '\u0015');
                ctr.Add("[SYN]", '\u0016');
                ctr.Add("[ETB]", '\u0017');
                ctr.Add("[CAN]", '\u0018');
                ctr.Add("[EM]", '\u0019');
                ctr.Add("[SUB]", '\u001A');
                ctr.Add("[ESC]", '\u001B');
                ctr.Add("[FS]", '\u001C');
                ctr.Add("[GS]", '\u001D');
                ctr.Add("[RS]", '\u001E');
                ctr.Add("[US]", '\u001F');
                ctr.Add("[DEL]", '\u007F');
                return ctr;
            }
            catch (Exception ex) { throw ex; }
        }
        private string ReadPrnFile()
        {
            StreamReader sr = null;
            string PrnFileData = "";
            try
            {
                string PrnFile = Application.StartupPath + "\\Assa PRN.prn";
                if (File.Exists(PrnFile))
                {
                    sr = new StreamReader(PrnFile);
                    PrnFileData = sr.ReadToEnd();
                }
                else
                    ClsGlobal.ShowErrorMessageBox("Prn file " + PrnFile + " not found");
            }
            catch (Exception ex) { ClsGlobal.ShowErrorMessageBox(ex.Message); }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                    sr = null;
                }
            }
            return PrnFileData;
        }

        private string ReadRfidMemoryCommand()
        {
            StreamReader sr = null;
            string RfidMemory = "";
            try
            {
                string RfidFile = Application.StartupPath + "\\RFID.txt";
                if (File.Exists(RfidFile))
                {
                    sr = new StreamReader(RfidFile);
                    RfidMemory = sr.ReadToEnd();
                }
                else
                    ClsGlobal.ShowErrorMessageBox("Rfid file " + RfidFile + " not found");
            }
            catch (Exception ex) { ClsGlobal.ShowErrorMessageBox(ex.Message); }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                    sr = null;
                }
            }
            return RfidMemory;
        }
        private string ReadRfidWriteCommand()
        {
            StreamReader sr = null;
            string RfidWrite = "";
            try
            {
                string RfidFile = Application.StartupPath + "\\RFID_WRITING.txt";
                if (File.Exists(RfidFile))
                {
                    sr = new StreamReader(RfidFile);
                    RfidWrite = sr.ReadToEnd();
                }
                else
                    ClsGlobal.ShowErrorMessageBox("Rfid Write file " + RfidFile + " not found");
            }
            catch (Exception ex) { ClsGlobal.ShowErrorMessageBox(ex.Message); }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                    sr = null;
                }
            }
            return RfidWrite;
        }
        private string ReadRfidFeedCommand()
        {
            StreamReader sr = null;
            string RfidWrite = "";
            try
            {
                string RfidFile = Application.StartupPath + "\\TagFeed.txt";
                if (File.Exists(RfidFile))
                {
                    sr = new StreamReader(RfidFile);
                    RfidWrite = sr.ReadToEnd();
                }
                else
                    ClsGlobal.ShowErrorMessageBox("Rfid Feed file " + RfidFile + " not found");
            }
            catch (Exception ex) { ClsGlobal.ShowErrorMessageBox(ex.Message); }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                    sr = null;
                }
            }
            return RfidWrite;
        }
        private void WriteTagFile(string Assetnum, string suppname, string ponum, string mrcno, string invno, string tagno, string sernum, string manfuc, string assetdes, string assetcat, string noofunit, string assettype, string assetloc, string depmethod, string deprate, string date)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(Application.StartupPath + "\\TAG_DATA.csv", true);
                sw.WriteLine(Assetnum + "," + suppname + "," + ponum + "," + mrcno + "," + invno + "," + tagno + "," + sernum + "," + manfuc + "," + assetdes +","+ assetcat+","+ noofunit + "," + assettype + "," + assetloc + "," + depmethod + "," + deprate + "," + date);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                    sw = null;
                }
            }
        }

        #endregion
        private void WriteTagFile_Error(string SrNO, string TagError)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(Application.StartupPath + "\\TAG_DATA_ERROR.csv", true);
                sw.WriteLine(SrNO + "," + TagError + "," + System.DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                    sw = null;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txtQty.Text == "")
                //{
                //    ClsGlobal.ShowErrorMessageBox("PLEASE BROWSE EXCELL FILE");
                //    txtQty.Focus();
                //   // CommonClasses.CommonMethods.MessageBoxShow("PLEASE BROWSE EXCELL FILE");
                //   // cmbkanbanType.Focus();
                //    return;
                //}

                OpenFileDialog obj_OP = new OpenFileDialog();
                obj_OP.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files(*.xls)|*.xls";
                obj_OP.ShowDialog();
                if (obj_OP.FileName != "")
                {
                    txtQty.Text = obj_OP.FileName;
                    string conn = string.Empty;
                    dt = new DataTable();
                    if (txtQty.Text.EndsWith(".xls"))
                        conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txtQty.Text + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
                    else
                        conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtQty.Text + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1';"; //for above excel 2007  
                    using (OleDbConnection con = new OleDbConnection(conn))
                    {
                        OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from  [Sheet1$]", con); //here we read data from sheet1  
                        oleAdpt.Fill(dt); //fill excel data into dataTable  

                        if(dt.Rows.Count > 0)
                        {
                            dgvDetails.DataSource = dt;
                            //for (int i = 0; i < dt.Rows.Count; i++)
                            //{
                            //    //oTag.Barcodedata = dt.Rows[i]["Barcode data"].ToString();
                            //    //oTag.DbType = EnumDbType.SELECT;
                            //    //DataTable dt0 = oDal.ManageUser(oTag);
                            //    //if (dt0.Rows.Count == 0)
                            //    //{ 

                            //    //////Inserting data 
                            //    ////oTag.OrderID = dt.Rows[i]["Order ID"].ToString();
                            //    ////oTag.SrNo = dt.Rows[i]["Sr# No#"].ToString();
                            //    ////oTag.VehicleClass = dt.Rows[i]["Vehicle Class (VC)"].ToString();
                            //    ////oTag.Usermemory = dt.Rows[i]["User memory"].ToString();
                            //    ////oTag.EPCID = dt.Rows[i]["TagID/EPCID"].ToString();
                            //    ////oTag.TagID = "";
                            //    ////oTag.Barcodedata = dt.Rows[i]["Barcode data"].ToString();
                            //    ////oTag.EPCMemory = dt.Rows[i]["EPC Memory (optional)"].ToString();
                            //    ////oTag.VRC = dt.Rows[i]["VRC (optional)"].ToString();
                            //    ////oTag.CreatedBy = ClsGlobal.UserId;
                            //    //////If saving data

                            //    ////oTag.DbType = EnumDbType.INSERT;
                            //    ////DataTable dt1 = oDal.ManageUser(oTag);
                            //    // }
                            //}
                        }
                    }
                }
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    oTag.OrderID = dt.Rows[i]["Order ID"].ToString();
                //    oTag.SrNo = dt.Rows[i]["Sr# No#"].ToString();
                //    oTag.VehicleClass = dt.Rows[i]["Vehicle Class (VC)"].ToString();
                //    oTag.Usermemory = dt.Rows[i]["User memory"].ToString();
                //    oTag.EPCID = dt.Rows[i]["TagID/EPCID"].ToString();
                //    oTag.TagID = "";
                //    oTag.Barcodedata = dt.Rows[i]["Barcode data"].ToString();
                //    oTag.EPCMemory = dt.Rows[i]["EPC Memory (optional)"].ToString();
                //    oTag.VRC = dt.Rows[i]["VRC (optional)"].ToString();
                //    oTag.CreatedBy = ClsGlobal.UserId;
                //    //If saving data

                //    oTag.DbType = EnumDbType.SELECT;
                //    DataTable dt2 = oDal.ManageUser(oTag);

                //    if (dt2.Rows.Count == 0)
                //    {
                //        foreach (DataRow dr in dt.Rows)
                //        {
                //                if (dr["Barcode data"].ToString() == oTag.Barcodedata)
                //                    dr.Delete();
                //        }
                //        dt.AcceptChanges();
                //        //ClsGlobal.ShowErrorMessageBox("This Barcode data already printed with other TAG. Please verify the file and re-upload " + oTag.Barcodedata);
                //        //txtQty.Text = "";
                //        //return;
                //    }

                //}

                // }
            }
            catch (Exception ex)
            {
                ClsGlobal.ShowErrorMessageBox(ex.Message.ToString());
            }
        }

        private void Btnstopprint_Click(object sender, EventArgs e)
        {
            try
            {
                stopprint = 1;
            }
            catch (Exception ex)
            {
                ClsGlobal.ShowErrorMessageBox(ex.Message.ToString());
            }
        }

        private void ChkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSelectAll.Checked == true)
                {
                    for (int iloop = 0; iloop < dgvDetails.Rows.Count; iloop++)
                    {
                        dgvDetails.Rows[iloop].Cells[0].Value = true;
                    }
                }
                else
                {
                    for (int iloop = 0; iloop < dgvDetails.Rows.Count; iloop++)
                    {
                        dgvDetails.Rows[iloop].Cells[0].Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Tenneco", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}

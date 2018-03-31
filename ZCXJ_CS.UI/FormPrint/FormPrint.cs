using BarChart;
using Bucklematerial;
using DM_API;
using LabelManager2;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ZCXJ_CS.Applications;
using ZCXJ_CS.Utilities;

namespace ZCXJ_CS.UI
{
    public partial class FormPrint : FormBase
    {
        #region var

        private VBarChart chartWarning;
        public LogHelper log;
        private Plc plc;
        /// <summary>
        /// 可执行文件路径        
        ///</summary> 
        public string ExePath
        {
            get { return AppDomain.CurrentDomain.BaseDirectory; }
        }

        #endregion

        #region constructor

        public FormPrint()
        {
            InitializeComponent();
        }

        #endregion

        #region load

        /// <summary>
        /// 初始加载
        /// </summary> 
        private void FormPrint_Load(object sender, EventArgs e)
        {
            log = LogHelper.GetInstence();
            InitChartComponent();

            //启动网络连接监测线程
            if (IsNetConnected == true)
            {
                InitPlcService();
            }
            else
            {
                OnDisplayLog("Attention: PLC-[" + GlobalData.PlcIP + "]未连接……");
            }

            SFCInterface = new DM_SFCInterface();

        }

        #endregion

        #region check net status

        /// <summary>
        /// 检测网络状态,断线重连
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerPrint_Tick(object sender, EventArgs e)
        {
            if (IsNetConnected)
            {
                if (plc == null)
                {
                    InitPlcService();
                }
            }
            else
            {
                if (plc != null)
                {
                    plc.Dispose();
                    plc = null;
                    OnDisplayLog("PLC[" + GlobalData.PlcIP + "]已断开连接……");
                    log.Info("PLC[" + GlobalData.PlcIP + "]已断开连接……");
                }
            }
        }

        #endregion

        #region init plc connect

        private void InitPlcService()
        {
            try
            {
                plc = new Plc(CpuType.S71200, GlobalData.PlcIP, 0, 0);

                List<MonitorTag> lstM = new List<MonitorTag>();
                lstM.Add(new MonitorTag("HandleType", GlobalData.MonitorTagAdd, 0));
                plc.MonitorTagAddList = lstM;
                plc.DataChange += Plc_DataChange; ;
                plc.Open();
                if (plc.IsConnected && plc.IsAvailable)
                {
                    log.Info("已连接plc[" + GlobalData.PlcIP + "]");
                    OnDisplayLog("已连接plc[" + GlobalData.PlcIP + "]");
                }
            }
            catch (Exception)
            {

            }
        }

        #region ConstString

        private const string NEWLINE = "\n--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
        private const string ERROR = "\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Equipment test error<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<";

        private const string INITADDRESS = "---Initialization address.";
        private const string CLEARSUCCESS = "---Clear success.";
        private const string READSUCCESS = "---MES reads the PLC signal success.";
        private const string PRINTSUCCESS = "---Print success.";
        private const string SNCHECKSUCCESS = "---SN check success.";
        private const string SNCHECKFAIL = "---SN check fail.";
        private const string GETWOSUCCESS = "---Get WO success.";
        private const string GETWOFAIL = "---Get WO fail.";
        private const string STATIONPASS = "---Station Pass.";
        private const string STATIONFAIL = "---Station fail.";
        private const string UNKNOWNVALEU = "---is unknown state value.";
        private const string SCANCOMPLETE = "---Scan complete, start reading bar code.";
        private const string READBARCODESUCCESS = "---Bar code read success.";
        private const string PROCESSCHECKSUCCESS = "---Process check success.";
        private const string PROCESSCHECKFAIL = "---Process check fail.";
        private const string READFUR_NUM_IN = "---Start reading the furnace number_in.";
        private const string READFUR_NUM_OUT = "---Start reading the furnace number_out.";
        private const string STARTMAPPING = "---Start the mapping serialNumber and the furnace number.";
        private const string MAPPINGSUCCESS = "---Mapping success.";
        private const string MAPPINGFAIL = "---Mapping fail.";
        private const string GETSN_BY_FURNUM_OUT = "---Start get serialNumber from db server by the furnace number_out.";
        private const string GETSN_BY_FURNUM_OUT_SUCCESS = "---Get serialNumber success in db server.";
        private const string DISPCOMPLETE = "---Dispensing complete.";
        private const string READVALUESUCCESS = "---Read value success.";
        private const string HARDTESTSUCCESS = "---Hardness test success.";
        private const string HARDTESTFAIL = "---Hardness test fail.";
        private string CheckStatus;
        private string ReturnMsg;
        private string Msg;

        #endregion

        private string mesSN;
        private string plcSN;
        private DM_SFCInterface SFCInterface;
        object sync = new object();
        private void Plc_DataChange(object sender, DataChangeEventArgs e)
        {
            lock (sync)
            {
                string ht = e._stateType;
                ushort hv = e._stateValue;

                if (ht == "HandleType")
                {
                    #region OP010-1

                    switch (hv)
                    {
                        case 0:
                            OnDisplayMesSn("", 0, 0);
                            OnDisplayMesSn("", 0, 1);
                            OnDisplayMesSn("", 0, 2);
                            OnDisplayLog("");

                            ResetWarningChart(0, true);
                            log.Info(hv + INITADDRESS);
                            break;
                        case 1:
                            log.Info(hv + CLEARSUCCESS);
                            ResetWarningChart(1, true); // 清洗完毕
                            ResetWarningChart(2, true); // 清洗完毕
                            //测试代码，模拟扫描枪扫描条码至PLC---------------------------------------
                            if (GlobalData.SimWrite == "true")
                            {
                                mesSN = "MonitorSN" + DateTime.Now.ToString("yyyyMMddHHmmsss");
                                mesSN = "OBC_DFM.V014.1.084.5.00000018180327";
                                SendMsgToPlc(int.Parse(GlobalData.MsgDB), 0, mesSN);
                                ResetWarningChart(3, true); // 获取条码完毕
                                ResetWarningChart(4, true); // 打印条码完毕
                            }
                            else
                                mesSN = printSNBarcode();


                            OnDisplayMesSn(mesSN, 1, 1);
                            //清洗完毕，告诉plc消息已收到
                            SetPlcStatus(GlobalData.MonitorTagAdd, 2);

                            break;
                        case 2:
                            log.Info(hv + READSUCCESS);
                            SendMsgToPlc(int.Parse(GlobalData.MsgDB), 0, hv + READSUCCESS);
                            break;
                        case 3:
                            ResetWarningChart(5, true);
                            log.Info(hv + PRINTSUCCESS + "SN<" + mesSN + ">");
                            //扫码完成，MES读取条码 
                            byte[] bytes = plc.ReadBytes(DataType.DataBlock, int.Parse(GlobalData.MsgDB), 0, 256);
                            plcSN = Utility.ConvertToString(bytes);
                            ResetWarningChart(6, true);

                            //扫码完成，告诉plc消息已收到
                            SetPlcStatus(GlobalData.MonitorTagAdd, 4);
                            break;
                        case 4:
                            log.Info(hv + READSUCCESS + "SN<" + plcSN + ">.");

                            if (mesSN == plcSN)
                            {
                                OnDisplayMesSn(plcSN, 1, 2);
                                OnDisplayMesSn("", 1, 0);
                                OnDisplayLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm") + " 条码校验正确 ");
                                SendMsgToPlc(int.Parse(GlobalData.MsgDB), 0, hv + SNCHECKSUCCESS);
                                log.Info(hv + SNCHECKSUCCESS);
                                ResetWarningChart(7, true);
                                try
                                {
                                    if (GlobalData.SimWrite != "true")
                                    {
                                        DataTable dt = SFCInterface.SFC_DM_CheckRoute(plcSN, GlobalData.EquipmentNO, GlobalData.WorkOrder, "PASS");//FAIL
                                        CheckStatus = dt.Rows[0][0].ToString().ToString();
                                        ReturnMsg = dt.Rows[0][1].ToString().ToString();
                                        Msg = CheckStatus + ":" + ReturnMsg;
                                        if (CheckStatus == "1") //成功 
                                        {
                                            BuckleMaterialIn(hv, plcSN, "ASM", GlobalData.EquipmentNO + "-01");

                                            SetPlcStatus(GlobalData.MonitorTagAdd, 5);
                                            SendMsgToPlc(int.Parse(GlobalData.MsgDB), 0, hv + STATIONPASS + Msg);
                                            log.Info(hv + STATIONPASS + Msg);


                                        }
                                        else
                                        {
                                            SetPlcStatus(GlobalData.MonitorTagAdd, 6);
                                            SendMsgToPlc(int.Parse(GlobalData.MsgDB), 0, hv + STATIONFAIL + Msg);
                                            log.Info(hv + STATIONFAIL + Msg);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    log.Info(hv + SNCHECKFAIL + ex.Message);
                                }
                            }
                            else
                            {
                                OnDisplayMesSn(plcSN, 2, 2);
                                OnDisplayMesSn("", 2, 0);
                                OnDisplayLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm") + " 条码校验错误：MES推送条码与现场PLC扫描条码不一致 ");
                                ResetWarningChart(7, false);
                                SetPlcStatus(GlobalData.MonitorTagAdd, 6);
                                SendMsgToPlc(int.Parse(GlobalData.MsgDB), 0, hv + SNCHECKFAIL);
                            }
                            break;
                        case 5:
                            log.Info(hv + STATIONPASS);
                            ResetWarningChart(8, true);
                            break;
                        case 6:
                            log.Info(hv + STATIONFAIL);
                            ResetWarningChart(8, false);
                            break;
                        //case 7:
                        //    log.Info(hv + STATIONPASS);
                        //    ResetWarningChart(8, true);
                        //    break;
                        //case 8:
                        //    log.Info(hv + STATIONFAIL);
                        //    ResetWarningChart(8, false);
                        //    break;
                        default:
                            log.Info(hv + UNKNOWNVALEU);
                            break;
                    }

                    #endregion
                }

            }
        }

        private void SetPlcStatus(string plcAddress, int status)
        {
            Thread.Sleep(300);
            plc.Write(plcAddress, (ushort)status);
        }

        private void SendMsgToPlc(int db, int startAdr, string msg)
        {
            Thread.Sleep(300);
            byte[] bytebuff = ConvertStringToByte(msg);
            ErrorCode errCode = plc.WriteBytes(DataType.DataBlock, db, startAdr, bytebuff);
        }

        private byte[] ConvertStringToByte(string str)
        {
            byte[] bytebuff = Encoding.ASCII.GetBytes(str);
            List<byte> lstByte = new List<byte>();
            lstByte.Add(254);
            lstByte.Add((byte)bytebuff.Length);
            lstByte.AddRange(bytebuff);
            bytebuff = lstByte.ToArray();
            return bytebuff;
        }

        private void BuckleMaterialIn(ushort _hv, string _plcSN, string _equipmentNO, string palCode)
        {
            try
            {
                DM_Bucklematerial BucMat = new DM_Bucklematerial();
                string retMsg = BucMat.BuckleMaterialIn(_plcSN, _equipmentNO, palCode);
                log.Info(_hv + "---Buckle material success. success<" + retMsg + "---SN:" + _plcSN + "---EquipmentNO:" + _equipmentNO + "---PalCode:" + palCode + ">");
            }
            catch (Exception e)
            {
                log.Info(_hv + "---Buckle material fail. error<" + e.Message + ">");
            }
        }

        #endregion 

        private void InitChartComponent()
        {
            OnDisplayMesSn("", 0, 0);
            OnDisplayMesSn("", 0, 1);
            OnDisplayMesSn("", 0, 2);

            chartWarning = new VBarChart();
            this.panelWarning.Controls.Add(chartWarning);

            // 
            #region right side

            chartWarning.Dock = DockStyle.Fill;
            //chartWarning.AutoSize = true;
            chartWarning.AutoScroll = true;
            chartWarning.BarWidth = 35;
            //chartWarning.Height = 425;
            chartWarning.SizingMode = BarSizingMode.Normal;
            //chartWarning.SizingMode = BarSizingMode.AutoScale;
            chartWarning.Values.Visible = false;
            chartWarning.Scales.Section = 0;//刻度线
            chartWarning.Background.PaintingMode = CBackgroundProperty.PaintingModes.RadialGradient;
            chartWarning.Background.GradientColor1 = Color.Gainsboro;
            chartWarning.Background.GradientColor2 = Color.WhiteSmoke;

            chartWarning.Label.Font = new Font("微软雅黑", 10, FontStyle.Bold);

            chartWarning.Shadow.ColorInner = Color.WhiteSmoke;
            chartWarning.Shadow.ColorOuter = Color.Gray;

            #endregion
            chartWarning.Clear();

            chartWarning.Add(100, "---1---初始状态", Color.Lime);
            chartWarning.Add(100, "---2---壳体清洗完毕", Color.WhiteSmoke);
            chartWarning.Add(100, "---3---MES读取清洗信号完毕", Color.WhiteSmoke);
            chartWarning.Add(100, "---4---MES获取条码完毕", Color.WhiteSmoke);
            chartWarning.Add(100, "---5---在线条码打印完毕", Color.WhiteSmoke);
            chartWarning.Add(100, "---6---PLC扫描条码完毕", Color.WhiteSmoke);
            chartWarning.Add(100, "---7---MES读取条码完毕", Color.WhiteSmoke);
            chartWarning.Add(100, "---8---MES校验条码完毕", Color.WhiteSmoke);
            chartWarning.Add(100, "---9---出站完毕", Color.WhiteSmoke);

            RedrawWarningChart();
        }

        private void ResetWarningChart(int flat, bool result)
        {
            if (chartWarning != null)
            {
                if (chartWarning.Items.Count > 1)
                {
                    if (flat == 0)
                    {
                        for (int i = 1; i < chartWarning.Items.Count; i++)
                        {
                            chartWarning.Items[i].Color = Color.WhiteSmoke;
                        }
                    }
                    else
                    {
                        if (result)
                            chartWarning.Items[flat].Color = Color.LimeGreen;
                        else
                            chartWarning.Items[flat].Color = Color.Red;

                    }
                    RedrawWarningChart();
                }
            }
        }

        public delegate void DelegateRedrawWarningChart();
        private void RedrawWarningChart()
        {
            if (this.chartWarning.InvokeRequired)
            {
                this.BeginInvoke(new DelegateRedrawWarningChart(RedrawWarningChart));
            }
            else
            {
                //this.chartWarning.Sort();
                this.chartWarning.RedrawChart();
            }
        }

        #region 打印条码

        /// <summary>
        /// 根据规则,生成产品sn条码，并打印
        /// </summary>
        /// <returns></returns>
        private string printSNBarcode()
        {
            // 根据制令单生成SN条码 
            log.Info("2---Start get Qr code...... ");
            string snBarCode = "";
            try
            {
                //string str = DM_API.SqlHelper.connectionString;
                DataTable dt = SFCInterface.SFC_DM__ProvideBlockID_ByWO(GlobalData.WorkOrder);
                snBarCode = dt.Rows[0][0].ToString();
                snBarCode = snBarCode.Substring(4); // 1---DFM201982.93748
                log.Info("2---Get Qr code success --- [" + snBarCode + "] ");

                ResetWarningChart(3, true); // 获取条码完毕 
            }
            catch (Exception ex)
            {
                SendMsgToPlc(int.Parse(GlobalData.MsgDB), 0, "2---Gets Qr code failure---Func error---" + ex.Message);
                log.Info("2---Gets Qr code failure---Func error---" + ex.Message);

                ResetWarningChart(3, false); // 获取条码完毕 
            }

            //驱动打印机打印条码 
            ApplicationClass lbl = null;
            Document doc = null;

            try
            {

                log.Info("2---Start print……");
                lbl = new ApplicationClass();
                lbl.Documents.Open(@"E:\DAService\" + '\\' + "SNCode.Lab", false);
                doc = lbl.ActiveDocument;
                doc.Variables.FormVariables.Item("PN_2D").Value = snBarCode;

                log.Info("2---ActivePrinterName<" + lbl.ActivePrinterName + ">;  DefaultFilePath<" + lbl.DefaultFilePath + ">");
                doc.PrintDocument(1);
                log.Info("2---Print Qr code success---[" + snBarCode + "]");

                ResetWarningChart(4, true);
            }
            catch (Exception ex)
            {
                log.Info("2---label open error---[" + ex.Message + "]");
                ResetWarningChart(4, false);
                if (lbl != null)
                    lbl.Quit();
            }
            finally
            {
                if (lbl != null)
                {
                    lbl.Documents.CloseAll(true);
                    lbl.Quit();//退出  
                    lbl = null;
                    doc = null;
                }
                GC.Collect(0);
            }

            return snBarCode;
        }

        #endregion

        //日志显示
        private void OnDisplayLog(string msg)
        {
            Invoke(new Action<string>((message) =>
            {
                lblPrintLog.Text = message;

            }), msg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="flag">0-清空；1-绿色；2-红色</param>
        /// <param name="type">0-图示；1-MesSN；2-PlcSN</param>
        private void OnDisplayMesSn(string msg, int flag, int type)
        {
            Invoke(new Action<string, int, int>((_msg, _flag, _type) =>
              {
                  switch (_type)
                  {
                      case 0://picBoxV
                          picBoxV.SizeMode = PictureBoxSizeMode.Zoom;
                          switch (_flag)
                          {
                              case 0:
                                  picBoxV.Load(ExePath + @"Res\Question.png");
                                  break;
                              case 1:
                                  picBoxV.Load(ExePath + @"Res\OK.png");
                                  break;
                              case 2:
                                  picBoxV.Load(ExePath + @"Res\SNG.png");
                                  break;

                              default:
                                  break;
                          }
                          break;
                      case 1:
                          switch (_flag)
                          {
                              case 0:
                                  lblMesSN.Text = "";
                                  break;
                              case 1:
                                  lblMesSN.Text = _msg;
                                  lblMesSN.ForeColor = Color.LimeGreen;
                                  break;
                              case 2:
                                  lblMesSN.Text = _msg;
                                  lblMesSN.ForeColor = Color.Crimson;
                                  break;

                              default:
                                  break;
                          }
                          break;
                      case 2:
                          switch (_flag)
                          {
                              case 0:
                                  lblPlcSN.Text = "";
                                  break;
                              case 1:
                                  lblPlcSN.Text = _msg;
                                  lblPlcSN.ForeColor = Color.LimeGreen;
                                  break;
                              case 2:
                                  lblPlcSN.Text = _msg;
                                  lblPlcSN.ForeColor = Color.Crimson;
                                  break;

                              default:
                                  break;
                          }
                          break;
                  }


              }), msg, flag, type);
        }
        
        #region TestBarCodeScanner

        BardCodeHooK BarCode = new BardCodeHooK();
        private delegate void ShowInfoDelegate(BardCodeHooK.BarCodes barCode);
        private void ShowInfo(BardCodeHooK.BarCodes barCode)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ShowInfoDelegate(ShowInfo), new object[] { barCode });
            }
            else
            {


            }
        }


        void BarCode_BarCodeEvent(BardCodeHooK.BarCodes barCode)
        {
            ShowInfo(barCode);
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            BarCode.Stop();
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion
    }
}

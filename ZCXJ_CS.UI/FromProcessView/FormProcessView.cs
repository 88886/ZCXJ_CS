
using BarChart;
using DM_API;
using DM_MES;
using FormProcessView.Properties;
using FromProcessView;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using ZCXJ_CS.Applications;
using ZCXJ_CS.Utilities;

namespace ZCXJ_CS.UI
{
    public partial class FormProcessView : FormBase
    {
        #region var

        private System.Timers.Timer _timer = new System.Timers.Timer();
        private VBarChart chartWarning;
        public LogHelper log;
        private Plc plc;

        //可执行文件路径
        public string ExePath
        {
            get { return AppDomain.CurrentDomain.BaseDirectory; }
        }

        #endregion

        #region constructor

        public FormProcessView()
        {
            InitializeComponent();

            this.MouseWheel += FormProcessView_MouseWheel;
            gsProcess.ClearAllGObject();
        }

        #endregion

        #region load

        private void FormPrint_Load(object sender, EventArgs e)
        {
            log = LogHelper.GetInstence();
            InitChartComponent();

            _timer.Interval = 1000;
            _timer.Elapsed += new ElapsedEventHandler(timer_Timer);

            //启动网络连接监测线程
            if (IsNetConnected == true)
            {
                InitPlcService();
            }
            else
            {
                OnDisplayLog("Attention: PLC-[" + GlobalData.PlcIP + "]未连接……", false);
            }

            SFCInterface = new DM_SFCInterface();

            //LoadFlowHistory("DFM18030300001V4.1.08V4.5.00000220180312");
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
                    OnDisplayLog("PLC[" + GlobalData.PlcIP + "]已断开连接……", false);
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
                    OnDisplayLog("已连接plc[" + GlobalData.PlcIP + "]", false);
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
        private const string PFCheckPASS = "---PFCheck Pass.";
        private const string PFCheckFAIL = "---PFCheck fail.";
        private const string VICheckPASS = "---VICheck Pass.";
        private const string VICheckFAIL = "---VICheck fail.";
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

        private string plcSN;
        private DM_SFCInterface SFCInterface;
        object sync = new object();
        private DataTable dt;

        private const string PFCheck = "制成检验";
        private const string VICheck = "外观检验";
        private void Plc_DataChange(object sender, DataChangeEventArgs e)
        {
            lock (sync)
            {
                string ht = e._stateType;
                ushort hv = e._stateValue;

                if (ht == "HandleType")
                {
                    #region OP130-2

                    switch (hv)
                    {
                        case 0:
                            SetBtnEnableFalse();
                            gsProcess.ClearAllGObject();
                            OnDisplayLog("", true);
                            log.Info(hv + INITADDRESS);
                            break;
                        case 1:
                            log.Info(hv + SCANCOMPLETE);
                            //清洗完毕，告诉plc消息已收到
                            SetPlcStatus(GlobalData.MonitorTagAdd, 2);
                            break;
                        case 2:
                            log.Info(hv + READBARCODESUCCESS + "plcSN<" + plcSN + ">");
                            //扫码完成，MES读取条码 
                            byte[] bytes = plc.ReadBytes(DataType.DataBlock, int.Parse(GlobalData.MsgDB), 256, 256);
                            plcSN = Utility.ConvertToString(bytes);
                            OnDisplayLog("SN: " + plcSN, true);
                            try
                            {
                                if (GlobalData.SimWrite != "true")
                                {
                                    //调用MES函数向MES传递SN码，MES验证上工序是否成功，成功返回true，失败返回false 
                                    dt = SFCInterface.SFC_DM_CheckRouteOnlyCheck(plcSN, GlobalData.EquipmentNO, "", "");
                                    CheckStatus = dt.Rows[0][0].ToString().ToString();
                                    ReturnMsg = dt.Rows[0][1].ToString().ToString();
                                    Msg = CheckStatus + ":" + ReturnMsg;
                                    if (CheckStatus == "1") //成功 
                                    {
                                        SetPlcStatus(GlobalData.MonitorTagAdd, 3);
                                        SendMsgToPlc(int.Parse(GlobalData.MsgDB), int.Parse(GlobalData.MsgStart), hv + PROCESSCHECKSUCCESS + Msg);
                                        log.Info(hv + PROCESSCHECKSUCCESS + Msg);
                                    }
                                    else
                                    {
                                        SetPlcStatus(GlobalData.MonitorTagAdd, 4);
                                        SendMsgToPlc(int.Parse(GlobalData.MsgDB), int.Parse(GlobalData.MsgStart), hv + PROCESSCHECKFAIL + Msg);
                                        log.Info(hv + PROCESSCHECKFAIL + Msg);
                                        OnDisplayLog("Error: " + Msg, false);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                log.Info(hv + PROCESSCHECKFAIL + ex.Message);
                                OnDisplayLog("Error: " + ex.Message, false);
                            }
                            break;
                        case 3:
                            SetBtnEnableTrue();
                            log.Info(hv + PROCESSCHECKSUCCESS);
                            LoadFlowHistory(plcSN);
                            break;
                        case 4:
                            SetBtnEnableFalse();
                            log.Info(hv + PROCESSCHECKFAIL);
                            break;
                        case 5:
                            lblHandle.Text = VICheck;
                            log.Info(hv + PFCheckPASS);
                            break;
                        case 6:
                            log.Info(hv + PFCheckFAIL);
                            break;
                        case 7:
                            lblHandle.Text = PFCheck;
                            log.Info(hv + VICheckPASS);
                            break;
                        case 8:
                            log.Info(hv + VICheckFAIL);
                            break;
                        case 9:
                            log.Info(hv + STATIONPASS);
                            break;
                        case 10:
                            log.Info(hv + STATIONFAIL);
                            break;
                        default:
                            log.Info(hv + UNKNOWNVALEU);
                            break;
                    }

                    #endregion
                }

            }
        }

        private void SetBtnEnableTrue()
        {
            btnFail.Enabled = true;
            btnPass.Enabled = true;
        }

        private void SetBtnEnableFalse()
        {
            btnFail.Enabled = false;
            btnPass.Enabled = false;
        }

        /// <summary>
        /// set plc status
        /// </summary>
        /// <param name="plcAddress"></param>
        /// <param name="status"></param>
        private void SetPlcStatus(string plcAddress, int status)
        {
            Thread.Sleep(300);
            plc.Write(plcAddress, (ushort)status);
        }

        /// <summary>
        /// Send msg to plc
        /// </summary>
        /// <param name="db"></param>
        /// <param name="startAdr"></param>
        /// <param name="msg"></param>
        private void SendMsgToPlc(int db, int startAdr, string msg)
        {
            Thread.Sleep(300);
            byte[] bytebuff = ConvertStringToByte(msg);
            ErrorCode errCode = plc.WriteBytes(DataType.DataBlock, db, startAdr, bytebuff);
        }

        /// <summary>
        /// string to byte
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
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

        #endregion

        #region 标签选中事件

        private void Pt_OnNotifySelected(ProcessTicket item)
        {
            foreach (ProcessTicket pt in gsProcess.Controls)
            {
                if (pt.Index != item.Index)
                {
                    pt.IsSelected = false;
                }
            }
        }

        #endregion

        #region about log

        /// <summary>
        /// 日志显示
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="b"></param>
        private void OnDisplayLog(string msg, bool b)
        {
            Invoke(new Action<string, bool>((message, flag) =>
             {
                 if (!flag)
                 {
                     lblContent.ForeColor = Color.Red;
                     _timer.Start();
                 }
                 else
                 {
                     _timer.Stop();
                     lblContent.ForeColor = Color.FromArgb(255, 30, 57, 91);
                 }
                 lblContent.Text = message;

             }), msg, b);
        }

        protected void timer_Timer(object sender, EventArgs e)
        {
            this.Invoke(new Action<string>((msg) =>
            {
                if (lblContent.ForeColor == Color.Red)
                {
                    lblContent.ForeColor = Color.FromArgb(225, 225, 225);
                }
                else
                {
                    lblContent.ForeColor = Color.Red;
                }

            }), "");
        }


        #endregion

        #region flyPanel 鼠标滚轮滚动
        private void FormProcessView_MouseWheel(object sender, MouseEventArgs e)
        {
            ////e.X e.Y以窗体左上角为原点，aPoint为鼠标滚动时的坐标
            //Point aPoint = new Point(e.X, e.Y);

            ////this.Location.X,this.Location.Y为窗体左上角相对于screen的坐标,得出的结果是鼠标相对于电脑screen的坐标
            //aPoint.Offset(this.Location.X, this.Location.Y);

            //Rectangle r = new Rectangle(flyPnlContent.Location.X, flyPnlContent.Location.Y, flyPnlContent.Width, flyPnlContent.Height);
            //// MessageBox.Show(flowLayoutPanel1.Width+"  "+flowLayoutPanel1.Height);

            ////判断鼠标是不是在flowLayoutPanel1区域内
            //if (RectangleToScreen(r).Contains(aPoint))
            //{
            //    //设置鼠标滚动幅度的大小
            //    flyPnlContent.AutoScrollPosition = new Point(0, flyPnlContent.VerticalScroll.Value - e.Delta / 2);
            //}

        }

        #endregion

        #region process pass/fail

        private void btnFail_Click(object sender, EventArgs e)
        {
            DialogResult dr = DlgBox.Show("确定检验结果为FAIL吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                SetBtnEnableFalse();
                try
                {
                    if (lblHandle.Text == PFCheck)
                    {
                        SetPlcStatus(GlobalData.MonitorTagAdd, 6);
                        log.Info("Fail" + PFCheckFAIL + Msg);
                    }
                    else if (lblHandle.Text == VICheck)
                    {
                        SetPlcStatus(GlobalData.MonitorTagAdd, 8);
                        log.Info("Fail" + VICheckFAIL + Msg);
                    }
                    DataTable dt = SFCInterface.SFC_DM_CheckRoute(plcSN, GlobalData.EquipmentNO, "", "FAIL");//FAIL  
                    CheckStatus = dt.Rows[0][0].ToString().ToString();
                    ReturnMsg = dt.Rows[0][1].ToString().ToString();
                    Msg = CheckStatus + ":" + ReturnMsg;
                    if (CheckStatus == "1") //成功 
                    {
                        SetPlcStatus(GlobalData.MonitorTagAdd, 10);
                        SendMsgToPlc(int.Parse(GlobalData.MsgDB), int.Parse(GlobalData.MsgStart), "Pass" + STATIONFAIL + Msg);
                        log.Info("Pass" + STATIONPASS + Msg);

                    }
                    else
                    {
                        //SetPlcStatus(GlobalData.MonitorTagAdd, 5);
                        SendMsgToPlc(int.Parse(GlobalData.MsgDB), int.Parse(GlobalData.MsgStart), "Fail " + STATIONFAIL + Msg);
                        log.Info("Fail" + STATIONFAIL + Msg);
                    }
                }
                catch (Exception ex)
                {
                    log.Info("Func error " + STATIONFAIL + ex.Message);
                }
            }
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            SetBtnEnableFalse();
            try
            {
                if (lblHandle.Text == PFCheck)
                {
                    SetPlcStatus(GlobalData.MonitorTagAdd, 5);
                    log.Info("Pass" + PFCheckPASS + Msg);
                }
                else if (lblHandle.Text == VICheck)
                {

                    SetPlcStatus(GlobalData.MonitorTagAdd, 7);
                    log.Info("Pass" + VICheckPASS + Msg);

                    DataTable dt = SFCInterface.SFC_DM_CheckRoute(plcSN, GlobalData.EquipmentNO, "", "PASS");//FAIL  
                    CheckStatus = dt.Rows[0][0].ToString().ToString();
                    ReturnMsg = dt.Rows[0][1].ToString().ToString();
                    Msg = CheckStatus + ":" + ReturnMsg;
                    if (CheckStatus == "1") //成功 
                    {
                        SetPlcStatus(GlobalData.MonitorTagAdd, 9);
                        SendMsgToPlc(int.Parse(GlobalData.MsgDB), int.Parse(GlobalData.MsgStart), "Pass" + STATIONPASS + Msg);
                        log.Info("Pass" + STATIONPASS + Msg);

                    }
                    else
                    {
                        //SetPlcStatus(GlobalData.MonitorTagAdd, 5);
                        SendMsgToPlc(int.Parse(GlobalData.MsgDB), int.Parse(GlobalData.MsgStart), "Fail " + STATIONFAIL + Msg);
                        log.Info("Fail" + STATIONFAIL + Msg);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Info("Func error " + ex.Message);
            }
        }

        #endregion

        #region load flow history

        private void LoadFlowHistory(string sn)
        {
            dt = CDBConnection.FlowHistory(sn);
            gsProcess.ClearAllGObject();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Image imgChild = (dr["StatusCode"].ToString() == "PASS") ? Resources.newPASS : Resources.newFAIL;
                    gsProcess.AddGObject(dr["ID"].ToString(), imgChild, dr["EquipmentNO"].ToString() + "\n" + dr["ProcessNO"].ToString() + "_" + dr["ProcessDescription"].ToString());

                }

            }
            else
            {
                OnDisplayLog("Info: Return data is null ", false);
            }

        }

        #endregion

        #region node selected

        private void gsProcess_NodeSelected(object sender, GraphScenario.SelectedEvent e)
        {
            if (!string.IsNullOrEmpty(e.ID))
            {
                if (dt != null)
                {
                    DataRow dr = dt.Select("ID = '" + e.ID + "'").FirstOrDefault();

                    lblID.Text = dr["ID"].ToString();
                    lblSN.Text = dr["SerialNumber"].ToString();
                    lblProcessNO.Text = dr["ProcessNO"].ToString();
                    lblProcessName.Text = dr["ProcessDescription"].ToString();
                    lblENO.Text = dr["EquipmentNO"].ToString();
                    lblTime.Text = dr["ActionDatetime"].ToString();

                    if (dr["StatusCode"].ToString() == "PASS")
                    {
                        picStatus.Image = Resources.newPASS;
                    }
                    else
                    {
                        picStatus.LoadAsync();
                    }
                }
            }
        }

        #endregion

        #region bar chart


        private void InitChartComponent()
        {
            chartWarning = new VBarChart();
            this.panelWarning.Controls.Add(chartWarning);

            #region right side
            chartWarning.Dock = DockStyle.Fill;
            chartWarning.AutoScroll = true;
            //chartWarning.BarsGap = 4;//逐条间距
            chartWarning.Items.DrawingMode = DrawingModes.Glass;
            chartWarning.AutoScroll = true;
            chartWarning.BarWidth = 30;
            chartWarning.SizingMode = BarSizingMode.Normal;
            chartWarning.Values.Visible = false;
            chartWarning.Scales.Section = 0;//刻度线
            chartWarning.Background.PaintingMode = CBackgroundProperty.PaintingModes.RadialGradient;
            chartWarning.Background.GradientColor1 = Color.Gainsboro;
            chartWarning.Background.GradientColor2 = Color.WhiteSmoke;
            chartWarning.ForeColor = Color.FromArgb(30, 57, 91);
            chartWarning.Label.Font = new Font("微软雅黑", 10, FontStyle.Bold);

            chartWarning.Shadow.ColorInner = Color.WhiteSmoke;
            chartWarning.Shadow.ColorOuter = Color.Gray;

            #endregion
            chartWarning.Clear();

            chartWarning.Add(100, "---1---初始状态", Color.Lime);
            chartWarning.Add(100, "---2---条码读取完毕", Color.WhiteSmoke);
            chartWarning.Add(100, "---3---上工序检验完毕", Color.WhiteSmoke);
            chartWarning.Add(100, "---4---制成检验完毕", Color.WhiteSmoke);
            chartWarning.Add(100, "---5---外观检验完毕", Color.WhiteSmoke);
            chartWarning.Add(100, "---6---出站完毕", Color.WhiteSmoke);

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
        #endregion
    }
}

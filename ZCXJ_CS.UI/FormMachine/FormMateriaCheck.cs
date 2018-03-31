using BarChart;
using SocketAsyncServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZCXJ_CS.UI;


using BarChart;
using TreeListView;
using SocketAsyncServer;
using System.Net;
using DM_API;
using System.Data.SqlClient;
using DM_MES;

namespace ZCXJ_CS.UI
{
    public partial class FormMateriaCheck : FormBase
    {

        #region Var

        private HBarChart chartPerformance; // 显示设备效率
        private VBarChart chartWarning;     // 剩余可用物料
        private SocketListener asyncServer; // Tcp Server 用于跟PDA通信

        // 上料防错
        private TreeListView.TreeListView listMaterial = new TreeListView.TreeListView();
        // 定时刷新
        private System.Windows.Forms.Timer pollTimer = new System.Windows.Forms.Timer();


        delegate void RedrawPerformanceChartCallback(); //委托，刷新设备效率展示控件
        delegate void RedrawWarningChartCallBack();     //委托，刷新剩余可用物料展示控件
        delegate void RedrawMaterialListCallback();     // 

        string moduleID = string.Empty;
        string programName = string.Empty;

        DateTime dtStartQEP = Convert.ToDateTime("2016-10-21");
        DateTime dtEndQEP = Convert.ToDateTime("2016-10-22");
        private string strLbl2;
        private string strLbl3;
        private DataTable dtProgramName;

        #endregion

        #region 初始化
        public FormMateriaCheck()
        {
            InitializeComponent();

            InitChartComponent();
            InitInputComponent();
            InitSocketServer();
        }

        /// <summary>
        /// 初始化控件，设备使用效率，剩余可用物料
        /// </summary>
        private void InitChartComponent()
        {
            chartPerformance = new HBarChart();
            chartWarning = new VBarChart();
            panelPerformance.Controls.Add(chartPerformance);
            this.panelWarning.Controls.Add(chartWarning);

            // Left side
            chartPerformance.Dock = DockStyle.Fill;
            chartPerformance.AutoScroll = true;
            chartPerformance.BarWidth = 28;
            chartPerformance.SizingMode = BarSizingMode.Normal;
            chartPerformance.Values.Mode = CValueProperty.ValueMode.Digit;
            chartPerformance.Scales.Section = 4; //刻度
            chartPerformance.Background.PaintingMode = CBackgroundProperty.PaintingModes.RadialGradient;
            chartPerformance.Background.GradientColor1 = Color.Gainsboro;
            chartPerformance.Background.GradientColor2 = Color.Gray;
            chartPerformance.Label.Font = new Font("微软雅黑", 9, FontStyle.Regular);

            // right side
            chartWarning.Dock = DockStyle.Fill;
            chartWarning.AutoScroll = true;
            chartWarning.BarWidth = 30;
            chartWarning.SizingMode = BarSizingMode.Normal;
            chartWarning.Values.Mode = CValueProperty.ValueMode.Digit;
            chartWarning.Scales.Section = 4;
            chartWarning.Background.PaintingMode = CBackgroundProperty.PaintingModes.RadialGradient;
            chartWarning.Background.GradientColor1 = Color.Gainsboro;
            chartWarning.Background.GradientColor2 = Color.Gray;
            chartWarning.Label.Font = new Font("微软雅黑", 9, FontStyle.Regular);

        }

        /// <summary>
        /// 初始化控件，上料防错
        /// </summary>
        private void InitInputComponent()
        {
            this.panelMaterial.Controls.Add(listMaterial);
            listMaterial.Dock = DockStyle.Fill;
            listMaterial.BackColor = Color.WhiteSmoke;// Color.FromName("Window");

            listMaterial.Font = new Font(new FontFamily("Microsoft Sans Serif"), 16.25F);
            listMaterial.ColumnsOptions.HeaderHeight = 0;
            listMaterial.RowOptions.ItemHeight = 45;
            listMaterial.RowOptions.HeaderWidth = 30;
            listMaterial.RowOptions.ShowHeader = false;

            listMaterial.ViewOptions.ShowLine = true;
            listMaterial.ViewOptions.ShowPlusMinus = true;


            // add nodes
            TreeListColumn colLine = new TreeListColumn("Column_0", "LineID");
            colLine.AutoSize = true;
            colLine.AutoSizeRatio = 50;

            TreeListColumn colReel = new TreeListColumn("Column_1", "ReelID");
            colReel.AutoSize = true;
            colReel.AutoSizeRatio = 100;

            listMaterial.Columns.Add(colLine);
            listMaterial.Columns.Add(colReel);
        }

        /// <summary>
        ///  没作用
        /// </summary>
        public void InitSocketServer()
        {
            try
            {
                // Setup delegate
                SocketAsyncServer.Program.QueryWork = new QueryEventHandler(QueryDataBase);

                // Load parameters from configuration //
                string iniPath = System.IO.Directory.GetCurrentDirectory() + "\\SystemSettings.ini";
                DM_MES.IniFile iniFile = new DM_MES.IniFile(iniPath);
                int Port = iniFile.ReadInt("PDAServer", "Port", 4444);
                int maxConnections = iniFile.ReadInt("PDAServer", "MaxConnections", 3000);
                int bufferSize = iniFile.ReadInt("PDAServer", "BufferSize", 2048);

                // Create BarCode of server //生成条形码
                System.Net.IPHostEntry myEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                string strHost = myEntry.AddressList[1].ToString(); 
                strHost += ":" + Port; 
                Image imgHost = SocketAsyncServer.Code128Rendering.MakeBarcodeImage(strHost, 1, true);
                this.pictBarCode.Image = imgHost;

                // Get endpoint for the listener.                
                IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, Port);

                // This object holds a lot of settings that we pass from Main method
                // to the SocketListener. In a real app, you might want to read
                // these settings from a database or windows registry settings that
                // you would create.
                SocketListenerSettings theSocketListenerSettings = new SocketListenerSettings(
                     maxConnections,
                     bufferSize,
                     localEndPoint,
                     "");

                // Instantiate the SocketListener.
                asyncServer = new SocketListener(theSocketListenerSettings); //tcp异步服务监听
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        /// <summary>
        /// 加载设备使用效率图表
        /// </summary>
        /// <param name="programName"></param>
        private void LoadEquipmentPerformance(string programName)
        {
            // 工作，DownTime，维修
            double fWork = 0.0F, fDwnTime = 0.0F, fRepaire = 0.0F;
            this.chartPerformance.Clear();
            this.chartPerformance.Ratio.Clear();

            try
            {
                dtStartQEP = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:01");
                dtEndQEP = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                DataTable dt = QueryEquipmentPerformancebyDay(dtStartQEP, dtEndQEP);

                string equment = dt.Rows[0][0].ToString();
                int worktime = Int32.Parse(dt.Rows[0][1].ToString().Trim());
                int repairtime = Int32.Parse(dt.Rows[0][2].ToString().Trim());
                int downtime = Int32.Parse(dt.Rows[0][3].ToString().Trim());
                int total = downtime + repairtime + worktime;
                fWork = worktime * 100 / total;
                fDwnTime = downtime * 100 / total;
                fRepaire = repairtime * 100 / total;
            }
            catch (System.Exception ex)
            {
                //MessageBox.Show("LoadEquipmentPerformance(): " + ex.Message);
                return;
            }

            chartPerformance.Ratio.AddItem(fWork, "Working", Color.FromArgb(255, 50, 215, 50));
            chartPerformance.Ratio.AddItem(fDwnTime, "DownTime", Color.Yellow);
            chartPerformance.Ratio.AddItem(fRepaire, "Repair", Color.Orange);

            try
            {
                DataTable dt = QueryEquipmentPerformancebyHour(dtStartQEP, dtEndQEP);
                StringBuilder msg = new StringBuilder();

                int i = 0, nStart = 0;
                if (dt.Rows.Count > 16)
                    nStart = dt.Rows.Count - 16;

                foreach (DataRow dr in dt.Rows)
                {
                    if (i++ < nStart)
                        continue;

                    string[] date = dr[1].ToString().Split(new char[] { ' ' });
                    int downtime = Int32.Parse(dr[2].ToString().Trim());
                    int repairtime = 0;
                    if (dr[3].ToString() != "")
                        repairtime = Int32.Parse(dr[3].ToString().Trim());
                    int worktime = Int32.Parse(dr[4].ToString().Trim());
                    int total = downtime + repairtime + worktime;

                    this.chartPerformance.Add(downtime, worktime, repairtime, date[1], Color.Green);

                    msg.Append(date[1]); msg.Append(" ");
                    msg.Append(dr[2].ToString().Trim()); msg.Append(" ");
                    msg.Append(dr[3].ToString().Trim()); msg.Append(" ");
                    msg.Append(dr[4].ToString().Trim()); msg.Append("\r\n");
                }
                //MessageBox.Show(msg.ToString());
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("LoadEquipmentPerformance(): " + ex.Message);
            }
        }

        /// <summary>
        /// 按小时查询设备效率比例值
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public DataTable QueryEquipmentPerformancebyHour(DateTime StartTime, DateTime EndTime)
        {
            // 查询设备ID
            string SQL = "SELECT DISTINCT B.ID FROM TB_QMS_ProgramList A,TB_Assembly_Builder B " +
                         "WHERE A.Code ='" + this.programName + "' AND B.Code =SUBSTRING(A.Name,0, CHARINDEX('---',A.Name)) " +
                         "AND B.IsEnable =1 AND B.ModuleID ='e42e041b-12a5-4b92-b8c1-257a2adb2e63'";
            DataTable dt = CDBConnection._GetGrdInfo(SQL);
            string EquipmentID = dt.Rows[0][0].ToString();


            SqlParameter[] parameter = new SqlParameter[] {
                new SqlParameter("@startTime", StartTime),
                new SqlParameter("@endTime", EndTime),
                new SqlParameter("@equipmentId ", EquipmentID)

            };
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataSet(CDBConnection._GetDBConn(), CommandType.StoredProcedure, "status_min_proportion_byHour", parameter);
            return ds.Tables[0];

        }

        /// <summary>
        /// 按天(班次)查询设备效率平均比例值
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        private DataTable QueryEquipmentPerformancebyDay(DateTime StartTime, DateTime EndTime)
        {
            // 查询设备名
            string SQL = "SELECT DISTINCT B.ID FROM TB_QMS_ProgramList A,TB_Assembly_Builder B " +
                         "WHERE A.Code ='" + this.programName + "' AND B.Code =SUBSTRING(A.Name,0, CHARINDEX('---',A.Name)) " +
                         "AND B.IsEnable =1 AND B.ModuleID ='e42e041b-12a5-4b92-b8c1-257a2adb2e63'";
            DataTable dt = CDBConnection._GetGrdInfo(SQL);
            string EquipmentID = dt.Rows[0][0].ToString();

            // 查询运行效率
            SqlParameter[] parameter = new SqlParameter[] {
                new SqlParameter("@equipmentId",EquipmentID),
                new SqlParameter("@startTime",StartTime),
                new SqlParameter("@endTime",EndTime)
            };
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataSet(CDBConnection._GetDBConn(), CommandType.StoredProcedure, "Status_min_proportionV11", parameter);
            return ds.Tables[0];
        }

        private void Polling_Ticker(object sender, EventArgs myEventArgs)
        {
            UpdateDevicePerformanceChart(this.programName);
            UpdateMaterialWarningChart(this.programName);
        }

        private void RestartPolling()
        {
            this.pollTimer.Start();
        }
        private void ClosePolling()
        {
            this.pollTimer.Stop();
        }

        /// <summary>
        /// 异步载入本地工单列表
        /// </summary>
        /// <param name="loadtype">载入方式(1为停止正在运行的工单)</param>
        private void AsyncLoadLocalMateriaInfo(int loadtype = 0)
        {
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += Bgw_DoWork;
            bgw.RunWorkerCompleted += Bgw_RunWorkerCompleted;
            bgw.RunWorkerAsync(loadtype);
        }
        /// <summary>
        /// 加载工单列表到界面
        /// </summary>
        private void Bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label2.Text = strLbl2;
            label3.Text = strLbl3;

            foreach (DataRow dr in dtProgramName.Rows)
            {
                this.comboBoxProgramName.Items.Add(dr[0].ToString());
            }

            // 设置默认选项
            if (this.comboBoxProgramName.Items.Count > 0)
                this.comboBoxProgramName.SelectedIndex = 0;

            // 启动查询定时器
            this.pollTimer.Tick += new EventHandler(Polling_Ticker);
            this.pollTimer.Interval = 5000;
            this.pollTimer.Start();

            HideLoading();
        }
        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            ShowLoading("开始载入工单，请稍后...");

            moduleID = CDBConnection._GetModuleID("Program List Registration");
            strLbl2 = CDBConnection._GetLabelsTxt(CDBConnection._GetModuleID("上料防错"), 100);
            strLbl3 = CDBConnection._GetLabelsTxt(CDBConnection._GetModuleID("上料防错"), 101);

            // 枚举程序名称列表
            CDBConnection.SQL = "SELECT DISTINCT Code FROM TB_QMS_ProgramList WHERE ModuleID='" + moduleID + "' AND IsEnable=1";
            dtProgramName = CDBConnection._GetGrdInfo(CDBConnection.SQL);

        }
        private void Frm_MaterialPrevention_Load(object sender, EventArgs e)
        {
            //ShowLoading("开始载入工单，请稍后...");
            AsyncLoadLocalMateriaInfo();
        }
        

        private void Frm_MaterialPrevention_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Close Socket server
            if (asyncServer != null)
                asyncServer.Dispose();
        }

        private void comboBoxProgramName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClosePolling();
            this.programName = this.comboBoxProgramName.Text.Trim();
            LoadStackMaterialList(this.programName);
            LoadEquipmentPerformance(this.programName);
            RestartPolling();
        }

        #region Material Checking Kernal
        /// <summary>
        /// 上料防错检查过程
        /// </summary>
        /// <param name="msg"></param>
        private void CheckMeterialSetup(ref QueryMessage msg)
        {
            if (msg.items.Count <= 0)
            {
                msg.respose = "NO item";
                return;
            }
            QueryMessage.QueryItem item = msg.items[0];

            // [1] 查询数量
            string strSQL = "select QTY from TB_WH_UnitItem where ReelID='" + item.ReelID + "'";
            string strQTY = CDBConnection._GetID(strSQL);
            item.QTY = int.Parse(strQTY);
            if (item.QTY <= 0)
            {
                UpdateStackMaterialList(item.StackNO, false);
                msg.respose = "Get QTY failed";
                return;
            }

            // [2] 检查ReelID是否匹配物料或替代料
            bool bOK = false;
            strSQL = "SELECT A.ReelID, TB_PartNO.Code PartNO, TB_PartNO.Name PartName, a.QTY " +
                     "FROM TB_WH_UnitItem A, TB_WH_MaterialAttribute_Event B, TB_Assembly_Builder TB_PartNO " +
                     "WHERE A.ParentID=B.MainID AND B.PartNumberID=TB_PartNO.ID " +
                     "AND TB_PartNO.ModuleID='b5e9db96-6a31-410d-a23c-6bdcb563ac53' AND A.ReelID='" + item.ReelID + "' " +
                     "UNION ALL " +
                     "SELECT A.ReelID ,B.Code PartNO,B.Name PartName,A.QTY  FROM TB_WH_UnitItem A, TB_Assembly_Builder B, TB_WH_PurchaseDetail C, TB_WH_UnitItem D " +
                     "WHERE A.ParentID = D.ID AND D.ParentID =C.ID AND B.ID =C.PartID AND B.ModuleID ='b5e9db96-6a31-410d-a23c-6bdcb563ac53' " +
                     "AND A.ReelID ='" + item.ReelID + "' ";
            DataTable dtList = CDBConnection._GetDTInfo(strSQL);
            foreach (DataRow dr in dtList.Rows)
            {
                if (dr[0].ToString() == item.ReelID)
                {
                    if (dr[1].ToString() == item.PartNO || dr[2].ToString() == item.PartName)
                    {
                        bOK = true;
                        break;
                    }
                }
            }
            if (bOK == false)
            {
                UpdateStackMaterialList(item.StackNO, false);
                msg.respose = "Wrong Material Setup";
                return;
            }

            // [3] 检查栈位是否正确
            strSQL = "SELECT D.CompoentNO FROM TB_QMS_ProgramList A, TB_Assembly_Builder B, TB_Assembly_Builder C, TB_QMS_ReplaceComponentList D " +
                "WHERE A.ID=D.MainID AND B.Code=A.CompoentNO AND C.Code =D.CompoentNO AND B.ModuleID =C.ModuleID " +
                "AND B.ModuleID = 'b5e9db96-6a31-410d-a23c-6bdcb563ac53' AND D.IsEnable=1 AND A.[Address]='" + item.StackNO + "' " +
                "UNION ALL " +
                "SELECT CompoentNO FROM TB_QMS_ProgramList WHERE Code ='" + this.programName + "' AND [Address]='" + item.StackNO + "' AND ParentID IS NOT NULL";
            DataTable dtStack = CDBConnection._GetDTInfo(strSQL);
            bOK = false;
            foreach (DataRow dr in dtStack.Rows)
            {
                if (dr[0].ToString() == item.PartNO)
                {
                    bOK = true;
                    break;
                }
            }
            if (bOK == false)
            {
                UpdateStackMaterialList(item.StackNO, false);
                msg.respose = "Wrong Stack Setup";
                return;
            }

            // [4] 调用API执行存储过程
            const string NewREELID = "";
            const string TransDescription = "上料 Setup the REELID Components";
            DM_API.DM_SFCInterface a = new DM_API.DM_SFCInterface();
            DataTable DT = a.SFC_DM_QMSReplacePDA_SetupComponents(item.ReelID, NewREELID, item.QTY, msg.OperatorID, TransDescription);
            if (DT.Rows[0][0].ToString().Trim() != "1")
            {
                UpdateStackMaterialList(item.StackNO, false);
                msg.respose = DT.Rows[0][1].ToString();
                return;
            }

            // [5] 检查成功后更新QTY数量
            strSQL = "UPDATE TB_QMS_ProgramList SET CurrentREELID='" + item.ReelID + "',QTY=QTY+" + item.QTY +
                " WHERE Code='" + this.programName + "' AND Address='" + item.StackNO + "'";
            int num = CDBConnection.EXECRecord_RowsAffected(strSQL);
            if (num == -1)
            {
                UpdateStackMaterialList(item.StackNO, false);
                msg.respose = "Update QTY failed";
            }
            else
            {
                UpdateStackMaterialList(item.StackNO, true);
                UpdateMaterialWarningChart(this.programName, item.StackNO);
                msg.respose = "OK";
            }
        }
        /// <summary>
        /// 接料防错检查过程
        /// </summary>
        /// <param name="msg"></param>
        private void CheckMeterialLink(ref QueryMessage msg)
        {
            if (msg.items.Count <= 0)
            {
                msg.respose = "NO item";
                return;
            }

            QueryMessage.QueryItem item = msg.items[0];
            if (item.QTY <= 0) //接料数量手工输入
            {
                UpdateStackMaterialList(item.StackNO, false);
                msg.respose = "Get QTY failed";
                return;
            }

            // [2] 检查ReelI0D是否匹配物料或替代料
            bool bOK = false;
            string strSQL = "SELECT A.ReelID, TB_PartNO.Code PartNO, TB_PartNO.Name PartName, a.QTY " +
                "FROM TB_WH_UnitItem A, TB_WH_MaterialAttribute_Event B, TB_Assembly_Builder TB_PartNO, TB_QMS_ComponentItem TB_QMS " +
                "WHERE TB_QMS.ReelID=A.ReelID AND " +
                "A.ParentID=B.MainID AND B.PartNumberID=TB_PartNO.ID AND " +
                "TB_PartNO.ModuleID='b5e9db96-6a31-410d-a23c-6bdcb563ac53' AND " +
                "A.ReelID='" + item.ReelID + "'";
            DataTable dtList = CDBConnection._GetDTInfo(strSQL);
            foreach (DataRow dr in dtList.Rows)
            {
                if (dr[0].ToString() == item.ReelID)
                {
                    if (dr[1].ToString() == item.PartNO || dr[2].ToString() == item.PartName)
                    {
                        bOK = true;
                        break;
                    }
                }
            }
            if (bOK == false)
            {
                UpdateStackMaterialList(item.StackNO, false);
                msg.respose = "Wrong Material Link";
                return;
            }

            // [3] 调用API执行存储过程
            const string NewREELID = "";
            const string TransDescription = "接料 Link the REELID Components";
            DM_API.DM_SFCInterface a = new DM_API.DM_SFCInterface();
            DataTable DT = a.SFC_DM_QMSReplacePDA_SetupComponents(item.ReelID, NewREELID, item.QTY, msg.OperatorID, TransDescription);
            if (DT.Rows[0][0].ToString().Trim() != "1")
            {
                UpdateStackMaterialList(item.StackNO, false);
                msg.respose = DT.Rows[0][1].ToString();
                return;
            }

            // [4] 成功后更新QTY数量
            strSQL = "UPDATE TB_QMS_ProgramList SET QTY=QTY+" + item.QTY +
                " WHERE Code='" + this.programName + "' AND Address='" + item.StackNO + "'";
            int num = CDBConnection.EXECRecord_RowsAffected(strSQL);
            if (num == -1)
            {
                UpdateStackMaterialList(item.StackNO, false);
                msg.respose = "Update QTY failed";
            }
            else
            {
                UpdateStackMaterialList(item.StackNO, true);
                UpdateMaterialWarningChart(this.programName, item.StackNO);
                msg.respose = "OK";
            }
        }
        /// <summary>
        /// 换料防错检查过程
        /// </summary>
        /// <param name="msg"></param>
        private void CheckMeterialReplace(ref QueryMessage msg)
        {
            if (msg.items.Count <= 0)
            {
                msg.respose = "NO item";
                return;
            }

            QueryMessage.QueryItem item = msg.items[0];

            // [1] 换料用New ReelID查询数量
            string strSQL = "select QTY from TB_WH_UnitItem where ReelID='" + item.NewReelID + "'";
            string strQTY = CDBConnection._GetID(strSQL);
            item.QTY = int.Parse(strQTY);
            if (item.QTY <= 0)
            {
                UpdateStackMaterialList(item.StackNO, false);
                msg.respose = "Get QTY failed";
                return;
            }

            // [2] 检查New ReelID是否匹配物料或替代料
            bool bOK = false;
            strSQL = "SELECT A.ReelID, TB_PartNO.Code PartNO, TB_PartNO.Name PartName, a.QTY " +
                     "FROM TB_WH_UnitItem A, TB_WH_MaterialAttribute_Event B, TB_Assembly_Builder TB_PartNO " +
                     "WHERE A.ParentID=B.MainID AND B.PartNumberID=TB_PartNO.ID " +
                     "AND TB_PartNO.ModuleID='b5e9db96-6a31-410d-a23c-6bdcb563ac53' AND A.ReelID='" + item.NewReelID + "' " +
                     "UNION ALL " +
                     "SELECT A.ReelID ,B.Code PartNO,B.Name PartName,A.QTY  FROM TB_WH_UnitItem A, TB_Assembly_Builder B, TB_WH_PurchaseDetail C, TB_WH_UnitItem D " +
                     "WHERE A.ParentID = D.ID AND D.ParentID =C.ID AND B.ID =C.PartID AND B.ModuleID ='b5e9db96-6a31-410d-a23c-6bdcb563ac53' " +
                     "AND A.ReelID ='" + item.NewReelID + "' ";
            DataTable dtList = CDBConnection._GetDTInfo(strSQL);
            foreach (DataRow dr in dtList.Rows)
            {
                if (dr[0].ToString() == item.NewReelID)
                {
                    if (dr[1].ToString() == item.PartNO || dr[2].ToString() == item.PartName)
                    {
                        bOK = true;
                        break;
                    }
                }
            }
            if (bOK == false)
            {
                UpdateStackMaterialList(item.StackNO, false);
                msg.respose = "Wrong Material Replace";
                return;
            }

            // [3] 检查栈位是否正确
            strSQL = "SELECT D.CompoentNO FROM TB_QMS_ProgramList A, TB_Assembly_Builder B, TB_Assembly_Builder C, TB_QMS_ReplaceComponentList D " +
                "WHERE A.ID=D.MainID AND B.Code=A.CompoentNO AND C.Code =D.CompoentNO AND B.ModuleID =C.ModuleID " +
                "AND B.ModuleID = 'b5e9db96-6a31-410d-a23c-6bdcb563ac53' AND D.IsEnable=1 AND A.[Address]='" + item.StackNO + "' " +
                "UNION ALL " +
                "SELECT CompoentNO FROM TB_QMS_ProgramList WHERE Code ='" + this.programName + "' AND [Address]='" + item.StackNO + "' AND ParentID IS NOT NULL";
            DataTable dtStack = CDBConnection._GetDTInfo(strSQL);
            bOK = false;
            foreach (DataRow dr in dtStack.Rows)
            {
                if (dr[0].ToString() == item.PartNO)
                {
                    bOK = true;
                    break;
                }
            }
            if (bOK == false)
            {
                UpdateStackMaterialList(item.StackNO, false);
                msg.respose = "Wrong Stack Replace";
                return;
            }


            // [4] 调用API执行存储过程
            const string TransDescription = "换料 Replace the REELID Components";
            DM_API.DM_SFCInterface a = new DM_API.DM_SFCInterface();
            DataTable DT = a.SFC_DM_QMSReplacePDA_SetupComponents(item.ReelID, item.NewReelID, item.QTY, msg.OperatorID, TransDescription);
            if (DT.Rows[0][0].ToString().Trim() != "1")
            {
                UpdateStackMaterialList(item.StackNO, false);
                msg.respose = DT.Rows[0][1].ToString();
                return;
            }


            // [5] 换料需要更新NewReelID和QTY数量
            strSQL = "UPDATE TB_QMS_ProgramList SET CurrentREELID='" + item.NewReelID + "', QTY=" + item.QTY +
                    " WHERE Code='" + this.programName + "' AND Address='" + item.StackNO + "'";
            int num = CDBConnection.EXECRecord_RowsAffected(strSQL);
            if (num == -1)
            {
                UpdateStackMaterialList(item.StackNO, false);
                msg.respose = "Update QTY failed";
            }
            else
            {
                UpdateStackMaterialList(item.StackNO, true);
                UpdateMaterialWarningChart(this.programName, item.StackNO);
                msg.respose = "OK";
            }
        }

        /// <summary>
        /// PDA的扫描信息进行查询和执行入库操作
        /// </summary>
        /// <param name="message">查询语句</param>
        /// <returns>查询结果字符串</returns>
        public byte[] QueryDataBase(byte[] message)
        {
            // received
            string strXML = Encoding.UTF8.GetString(message, 0, message.Length);

            // Fill up list
            QueryMessage msg = XmlHelper.Deserialize(typeof(QueryMessage), strXML) as QueryMessage;
            if (msg == null)
            {
                msg = new QueryMessage();
                msg.respose = "Wrong Format";
                strXML = XmlHelper.Serializer(typeof(QueryMessage), msg);
                return System.Text.Encoding.Default.GetBytes(strXML);
            }

            // Command Dispatching for clients
            ClosePolling();
            switch (msg.type)
            {
                case QueryMessage.MsgType.MaterialList:     // TODO: 获取栈位列表
                    GetMaterialList(ref msg);
                    break;

                case QueryMessage.MsgType.MaterialSetup:    // TODO: 上料防错检查
                    CheckMeterialSetup(ref msg);
                    break;
                case QueryMessage.MsgType.MaterialLink:     // TODO: 接料防错检查 
                    CheckMeterialLink(ref msg);
                    break;
                case QueryMessage.MsgType.MaterialReplace:  // TODO: 换料防错检查
                    CheckMeterialReplace(ref msg);
                    break;
                default:
                    msg.respose = "Query Error!";
                    break;
            }
            RestartPolling();

            // return back
            strXML = XmlHelper.Serializer(typeof(QueryMessage), msg);
            return System.Text.Encoding.Default.GetBytes(strXML);
        }
        #endregion

        /// <summary> 
        /// 加载栈料列表+低料预警列表
        /// </summary>
        private void LoadStackMaterialList(string programName)
        {
            if (programName == string.Empty)
                return;

            CDBConnection.SQL = "SELECT A.Code PROGRAM_NAME, B.ID,B.Code, B.[Address], B.CompoentNO, B.QTY-B.UsedQTY AS QTY " +
                "FROM TB_QMS_ProgramList A, TB_QMS_ProgramList B " +
                "WHERE A.Code ='" + programName + "' and A.ID=B.ParentID";
            DataTable dtStack = CDBConnection._GetGrdInfo(CDBConnection.SQL);

            // 加载栈位物料列表
            TreeListView.NodeCollection collection = this.listMaterial.Nodes;
            this.listMaterial.BeginUpdate();
            collection.Clear();
            foreach (DataRow drStack in dtStack.Rows)
            {
                string ID = drStack[1].ToString();
                string address = drStack[3].ToString();
                string material = drStack[4].ToString();
                int QTY;
                try
                {
                    QTY = Int32.Parse(drStack[5].ToString());
                }
                catch
                {
                    QTY = 0;
                }

                // 添加栈位物料父节点
                // Node.m_data[3] = { staclID, MaterialName, QTY }
                Node node = new Node(new object[3] { address, material, QTY.ToString() });
                node.TextColor = (QTY > 0) ? Color.Green : Color.Black;

                // 加载替换物料子节点
                CDBConnection.SQL = "SELECT CompoentNO from TB_QMS_ReplaceComponentList where MainID='" + ID + "'";
                DataTable dtSub = CDBConnection._GetGrdInfo(CDBConnection.SQL);
                foreach (DataRow drSub in dtSub.Rows)
                {
                    Node subNode = new Node(new object[2] { address, drSub[0].ToString() });
                    node.Nodes.Add(subNode);
                }

                collection.Add(node);
            }
            this.listMaterial.EndUpdate();


            // 加载低料预警列表
            this.chartWarning.Clear();
            foreach (DataRow drQty in dtStack.Rows)
            {
                string stackNO = drQty[3].ToString().Trim();
                if (stackNO == null || stackNO == string.Empty)
                    continue;
                string strQTY = drQty[5].ToString().Trim();
                if (strQTY == null || strQTY == string.Empty)
                    continue;

                int QTY = int.Parse(strQTY.ToString());
                int MinQTY = 100; // assume
                this.chartWarning.Add(QTY, MinQTY, stackNO);
            }
            RedrawWarningChart();
        }

        /// <summary> 
        /// 更新栈料列表项
        /// </summary>
        private void UpdateStackMaterialList(string stackNO, bool bOK)
        {
            TreeListView.Node node = this.listMaterial.GetNodeByFirstColumn(stackNO);
            if (node != null)
            {
                node.TextColor = (bOK) ? Color.Green : Color.Red;
                RedrawMaterialList();
            }
        }

        /// <summary>
        /// 更新低料预警图表
        /// </summary>
        public void UpdateMaterialWarningChart(string programName)
        {
            if (programName == string.Empty)
                return;

            CDBConnection.SQL = "SELECT Address,QTY-UsedQTY AS QTY FROM TB_QMS_ProgramList WHERE Code='" + programName + "'";
            DataTable dtStack = CDBConnection._GetDTInfo(CDBConnection.SQL);
            foreach (DataRow drQty in dtStack.Rows)
            {
                string stackNO = drQty[0].ToString();
                if (stackNO.Trim() == string.Empty)
                    continue;

                VBarItem item;
                if (this.chartWarning.GetAt(stackNO, out item))
                {
                    item.Value = int.Parse(drQty[1].ToString());
                    this.chartWarning.ModifyAt(stackNO, item);
                }
            }
            RedrawWarningChart();
        }
        public void UpdateMaterialWarningChart(string programName, string stackNO)
        {
            CDBConnection.SQL = "SELECT QTY-UsedQTY AS QTY FROM TB_QMS_ProgramList WHERE Code='" + programName + "' AND [Address]='" + stackNO + "'";
            DataTable dtList = CDBConnection._GetDTInfo(CDBConnection.SQL);
            foreach (DataRow dr in dtList.Rows)
            {
                VBarItem item;
                if (this.chartWarning.GetAt(stackNO, out item))
                {
                    item.Value = int.Parse(dr[0].ToString());
                    this.chartWarning.ModifyAt(stackNO, item);
                }
            }
            RedrawWarningChart();
        }

        public void GetMaterialList(ref QueryMessage msg)
        {
            if (programName == string.Empty)
                return;

            CDBConnection.SQL = "SELECT Address,CompoentNO, QTY-UsedQTY AS QTY FROM TB_QMS_ProgramList WHERE Code='" + programName + "'";
            DataTable dtStack = CDBConnection._GetDTInfo(CDBConnection.SQL);
            foreach (DataRow drQty in dtStack.Rows)
            {
                string stackNO = drQty[0].ToString();
                if (stackNO.Trim() == string.Empty)
                    continue;

                QueryMessage.QueryItem item = new QueryMessage.QueryItem(stackNO, drQty[1].ToString());
                try
                {
                    item.QTY = Int32.Parse(drQty[2].ToString());
                }
                catch (Exception ex)
                {
                    item.QTY = 0;
                }
                msg.items.Add(item);
            }
        }

        /// <summary>
        /// 更新设备绩效图表
        /// </summary>
        public void UpdateDevicePerformanceChart(string programName)
        {
            LoadEquipmentPerformance(programName);
            RedrawDevicePerformance();
        }

        private void RedrawMaterialList()
        {
            if (this.listMaterial.InvokeRequired)
            {
                RedrawMaterialListCallback call = new RedrawMaterialListCallback(RedrawMaterialList);
                this.Invoke(call);
            }
            else
            {
                this.listMaterial.Invalidate();
            }
        }

        private void RedrawWarningChart()
        {
            if (this.chartWarning.InvokeRequired)
            {
                RedrawWarningChartCallBack call = new RedrawWarningChartCallBack(RedrawWarningChart);
                this.Invoke(call);
            }
            else
            {
                this.chartWarning.Sort();
                this.chartWarning.RedrawChart();
            }
        }

        private void RedrawDevicePerformance()
        {
            if (this.chartWarning.InvokeRequired)
            {
                RedrawPerformanceChartCallback call = new RedrawPerformanceChartCallback(RedrawDevicePerformance);
                this.Invoke(call);
            }
            else
            {
                this.chartPerformance.RedrawChart();
            }
        }

    }
}

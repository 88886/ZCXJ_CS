using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZCXJ_CS.Utilities;
using ZCXJ_CS.Domain;
using System.IO;
using System.Reflection;


namespace ZCXJ_CS.Applications
{
    public class GlobalData : Object
    {
        public static event EventHandler OnCurWorkTicketChanged;
        //配置文件助手
        public static ConfigHelper CfgHelper = null;
        //日志助手对象
        public static LogHelper Log = null;
        //全局工单管理对象
        public static WorkTicketManager WtManager = null;
        //全局SCADA数据对象
        public static ScadaData Scada = null;
        //助理类对象
        public static Utils Utils = null;
        //当前工序类型
        public static string Process;
        //当前机台编号
        public static string MachineId;
        //SCADA数据表文件路径
        public static string ScadaDataFile;
        //SCADA数据表表名
        public static string ScadaDataTableName;
        //服务器IP
        public static string ServerIP;
        //备份服务器IP
        public static string ServerIP_BK;
        //扫描枪管理对象
        public static SerialPortHelper SpScanner;
         
        // 当前操作工对象
        public static User CurUser;

        //---------------PLC相关--------------------- 
        public static string PlcIP;
        public static string MonitorTagAdd;
        public static string SimWrite;
        public static string MsgDB;
        public static string MsgStart;
        public static string EquipmentNO;
        public static string WorkOrder; 

        /// <summary>
        /// 初始化全局数据
        /// </summary>
        public static void InitGlobalData()
        { 
            //配置文件对象
            CfgHelper = new ConfigHelper();
            LoadConfig();
            //日志对象
            Log = LogHelper.GetInstence();
            Log.StartLog(LogLevel.DEBUG);
            //Scada数据管理对象---------------------------------
            //Scada = new ScadaData();
            //SpScanner = new SerialPortHelper(CfgHelper.GetKeyValue("SpScannerPortName"));
            //SpScanner.Open();
            //if (File.Exists(ScadaDataFile))
            //{
            //    Scada.Init(ScadaDataFile, ScadaDataTableName);
            //}
            //工单计划管理--------------------------------------
            //WtManager = new WorkTicketManager();            
			CurUser = new User();
            Utils = new Utils();
        }

        ~GlobalData()
        {
            OnCurWorkTicketChanged = null;//清除事件
            SpScanner.Close();
        }
        /// <summary>
        /// 触发当前运行工单切换事件
        /// </summary>
        public static void NotifyCurWorkTicketChanged(WorkTicket sender)
        {
            WtManager.CurWorkTicket = sender;
            if (OnCurWorkTicketChanged != null)
                OnCurWorkTicketChanged(sender, new EventArgs());
        }

        /// <summary>
        /// 读取配置参数
        /// </summary>
        public static void LoadConfig()
        {
            //读取配置参数
            Process = CfgHelper.GetKeyValue("Process");
            MachineId = CfgHelper.GetKeyValue("MachineId");
            ScadaDataFile = CfgHelper.GetKeyValue("ScadaDataFile");
            ScadaDataTableName = CfgHelper.GetKeyValue("ScadaDataTableName");
            ServerIP = CfgHelper.GetKeyValue("ServerIP");
            ServerIP_BK = CfgHelper.GetKeyValue("ServerIP_BK");

            //------------Plc相关---------------------------------------------- 
            PlcIP = CfgHelper.GetKeyValue("PlcIP");
            MonitorTagAdd = CfgHelper.GetKeyValue("MonitorTagAdd");
            SimWrite = CfgHelper.GetKeyValue("SimWrite");
            MsgDB = CfgHelper.GetKeyValue("MsgDB");
            MsgStart = CfgHelper.GetKeyValue("MsgStart");
            EquipmentNO = CfgHelper.GetKeyValue("EquipmentNO");
            WorkOrder = CfgHelper.GetKeyValue("WorkOrder"); 
        }
    }
}

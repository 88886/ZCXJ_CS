using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZCXJ_CS.Infrastructure;
using ZCXJ_CS.Utilities;
using System.Data;
using System.Threading;

namespace ZCXJ_CS.Domain
{
    public class ScadaData : Object
    {
        /// <summary>
        /// 班组产量
        /// </summary>
        public double TeamYield
        {
            get; set;
        }

        /// <summary>
        /// 总产量
        /// </summary>
        public double TotalYield
        {
            get;
            set;
        }

        /// <summary>
        /// 产量清零控制
        /// </summary>
        public int YieldCleanFlag
        {
            get;
            set;
        }

        /// <summary>
        /// 设备控制
        /// </summary>
        public int Mes_Control
        {
            get;
            set;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ScadaData()
        {
            log = LogHelper.GetInstence();
            TeamYield = TotalYield = 0.0;
            YieldCleanFlag = 0;
            IsDataValid = false;
            tableName = "";
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="dataFile">数据文件</param>
        public void Init(string dataFile, string table)
        {
            try
            {
                sqlite = new SqliteHelper(dataFile);
                tableName = table;
                IsDataValid = true;
            }
            catch (System.Exception ex)
            {
                log.Error("ScadaData无法打开数据表文件：{0}", ex.Message);
            }
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        public void ReadData()
        {
            if (string.IsNullOrEmpty(tableName) || !IsDataValid)
                return;
            //启动SCADA数据读线程
            Thread threaScadaRead = new Thread(ReadDataThread);
            threaScadaRead.IsBackground = true;
            threaScadaRead.Start();
        }

        /// <summary>
        /// 读数据线程
        /// </summary>
        private void ReadDataThread()
        {
            object lockObj = new object();
            try
            {
                string str = "select Tagname,Value from " + tableName;
                DataTable dt = sqlite.GetDataTable(str);
                if (dt == null)
                {
                    log.Debug("ScadaData无法连接数据表");
                    return;
                }
                for (int i = 0; i < dt.Rows.Count; i++ )
                {
                    DataRow dr = dt.Rows[i];
                    lock (lockObj)
                    {
                        switch (dr.ItemArray[0] as string)
                        {
                        case "Team_Count":
                            TeamYield = (double)(decimal)(dr.ItemArray[1]);
                            break;
                        case "Count":
                            TotalYield = (double)(decimal)(dr.ItemArray[1]);
                            break;
                        case "MES_Control":
                            Mes_Control = (int)(decimal)(dr.ItemArray[1]);
                            break;
                        case "MES_Clean":
                            YieldCleanFlag = (int)(decimal)(dr.ItemArray[1]);
                            break;
                        default:
                            break;
                        }
                    }
                }
                log.Debug("ScadaData数据读取 班产：{0}， 总产: {1}", TeamYield, TotalYield);
            }
            catch (System.Exception ex)
            {
                log.Error("ScadaData读取数据过程中发生异常：{0}", ex.Message);
            }
        }

        /// <summary>
        /// 写数据
        /// </summary>
        public void WriteData(string tagName, double value)
        {
            if (string.IsNullOrEmpty(tableName) || !IsDataValid)
                return;
            ParamObj param;
            param.tagName = tagName;
            param.value = value;
            //启动SCADA数据写线程
            Thread threaScadaWrite = new Thread(WriteDataThread);
            threaScadaWrite.IsBackground = true;
            threaScadaWrite.Start(param);
        }

        /// <summary>
        /// 写数据线程
        /// </summary>
        /// <param name="obj"></param>
        private void WriteDataThread(Object obj)
        {
            ParamObj param = (ParamObj)obj;
            string str = string.Format("update {0} set Value={1} where Tagname='{2}'", 
                tableName, param.value, param.tagName);
            sqlite.ExecuteNonQuery(str);
        }

        //数据助手
        private SqliteHelper sqlite = null;     
        //日志对象
        private LogHelper log = null;
        //数据是否能访问到
        private bool IsDataValid;
        //对应的数据表名
        private string tableName;
        //参数对象
        private struct ParamObj
        {
            public string tagName;
            public double value;
        } 
    }
}

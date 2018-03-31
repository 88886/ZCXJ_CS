using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using ZCXJ_CS.Applications;
using ZCXJ_CS.Domain;
using ZCXJ_CS.Utilities;
using ZCXJ_CS.Infrastructure;
using System.Threading;
using DM_MES;

namespace ZCXJ_CS.UI
{
    public partial class FormWorkTicket : FormBase
    {
        //全局工单管理对象
        WorkTicketManager wtManager = null;
        //UI控件对象列表
        List<ItemWorkTicket> itemWTList = null;
        //WorkTicket对象列表
        List<WorkTicket> wtList = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public FormWorkTicket()
        {
            InitializeComponent();
            itemWTList = new List<ItemWorkTicket>();
            wtList = new List<WorkTicket>();
            //wtManager = GlobalData.WtManager;
            //wtManager.OnDownWTCompleted += OnDownWTCompleted;// GlobalData中已经注释掉，未加载
        }
        /// <summary>
        /// 窗口载入
        /// </summary>
        private void FormWorkTicket_Load(object sender, EventArgs e)
        {
            AsyncLoadLocalWorkTicket();
        }
        /// <summary>
        /// 工单下载完成
        /// </summary>
        /// <param name="data">下载数据</param>
        private void OnDownWTCompleted(string data, object param)
        {
            if (!string.IsNullOrEmpty(data))
            {
                itemWTListClear();
                AsyncLoadLocalWorkTicket();
            }
            else
            {
                HideLoading();
            }
        }

        /// <summary>
        /// 下载计划工单
        /// </summary>
        private void btnDownloadWT_Click(object sender, EventArgs e)
        {
            if (IsNetConnected)
            {
                ShowLoading("正在同步工单，请稍后...");
                wtManager.DownLoadWorkTicket();
            }
            else
            {
                DlgBox.Show("当前无网络，请检查网络连接！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 重新载入工单
        /// </summary>
        private void btnReLoad_Click(object sender, EventArgs e)
        {
            itemWTListClear();

            AsyncLoadLocalWorkTicket();
        }


        /// <summary>
        /// 刷新工单列表
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < itemWTList.Count; i++)
            {
                //刷新运行中的工单
                if (itemWTList[i].WT.UpdateState == 1)
                    itemWTList[i].UpdateUI();
            }
        }
        /// <summary>
        /// 清理现有工单
        /// </summary>
        private void itemWTListClear()
        {
            //清理当前控件集合
            panelWTList.Controls.Clear();
            for (int i = 0; i < itemWTList.Count; i++)
            {
                //注销项选中通知事件
                itemWTList[i].OnNotifySelected -= OnItemSelected;
                itemWTList[i].OnNotifyWTStateChanged -= OnItemStateChanged;
                itemWTList[i].Dispose();
            }
            itemWTList.Clear();
        }
        /// <summary>
        /// 异步载入本地工单列表
        /// </summary>
        /// <param name="loadtype">载入方式(1为停止正在运行的工单)</param>
        private void AsyncLoadLocalWorkTicket()
        {
            try
            {
                //BackgroundWorker bgw = new BackgroundWorker();
                //bgw.DoWork += Bgw_DoWork; ;
                //bgw.RunWorkerCompleted += Bgw_RunWorkerCompleted;
                //bgw.RunWorkerAsync
                ShowLoading("开始载入工单，请稍后...");
                wtList.Clear();
                for (int i = 0; i < 5; i++)
                {
                    WorkTicket wt = new WorkTicket();
                    wt.planNo = "DFM00A01.00" + i.ToString();
                    wt.planAmount = 20 * i;
                    wt.UpdateState = i % 2;
                    wt.prodNo = "DFM";
                    wt.prodSpec = "-/--";
                    wt.startTime = DateTime.Now;
                    wt.endTime = DateTime.Now.AddDays(1);
                    wtList.Add(wt);
                }
                if (wtList != null && wtList.Count > 0)
                {
                    ItemWorkTicket RunOrPanseItem = null;
                    for (int i = 0; i < wtList.Count; i++)
                    {
                        ItemWorkTicket item = new ItemWorkTicket(wtList[i]);
                        //注册项通知事件
                        item.OnNotifySelected += OnItemSelected;
                        item.OnNotifyWTStateChanged += OnItemStateChanged;
                        itemWTList.Add(item);
                        if (wtList[i].UpdateState == 1 || wtList[i].UpdateState == 2)
                        {
                            RunOrPanseItem = item;
                        }
                    }
                    panelWTList.Controls.AddRange(itemWTList.ToArray());
                    if (RunOrPanseItem != null)
                    {
                        OnItemStateChanged(RunOrPanseItem);
                    }
                }
                else
                {
                    DlgBox.Show("没有获取到有效工单。", "提示", MessageBoxButtons.OK);
                }
                HideLoading();


            }
            catch (Exception e)
            { 
                throw e;
            }
        }


        /// <summary>
        /// 加载工单列表到界面
        /// </summary>
        private void Bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (wtList != null && wtList.Count > 0)
            {
                ItemWorkTicket RunOrPanseItem = null;
                for (int i = 0; i < wtList.Count; i++)
                {
                    ItemWorkTicket item = new ItemWorkTicket(wtList[i]);
                    //注册项通知事件
                    item.OnNotifySelected += OnItemSelected;
                    item.OnNotifyWTStateChanged += OnItemStateChanged;
                    itemWTList.Add(item);
                    if (wtList[i].UpdateState == 1 || wtList[i].UpdateState == 2)
                    {
                        RunOrPanseItem = item;
                    }
                }
                panelWTList.Controls.AddRange(itemWTList.ToArray());
                if (RunOrPanseItem != null)
                {
                    OnItemStateChanged(RunOrPanseItem);
                }
            }
            else
            {
                DlgBox.Show("没有获取到有效工单。", "提示", MessageBoxButtons.OK);
            }
            HideLoading();
        }

        /// <summary>
        /// 异步获取本地本地工单并填充Bom
        /// </summary>
        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            ShowLoading("开始载入工单，请稍后...");
            CDBConnection.SQL = @"SELECT * FROM 
                            ( SELECT A.Code,
                                        A.QTY,
                                        A.Description,
                                        B.Status_Name AS 制令单状态,
                                        D.AttributeNamezh_CN,
                                        C.AttributeValue FROM TB_Assembly_WorkOrderBuilder A,  
                                                            TB_Assembly_Status B ,
                                                            TB_Assembly_FlexAttributeValueItem C,
                                                            TB_Assembly_FlexAttributeVar D  
                                                            WHERE A.ModuleID='7ccf6c36-31ce-40d4-a0cc-ca9fdbbf4416' 
                                                                AND A.IsEnable=1 
                                                                AND A.Status_ID=B.ID 
                                                                AND D.ID=C.AttributeVarID 
                                                                AND A.ID=C.MainID) AS P 
                                                                PIVOT (max(P.AttributeValue) 
                                                                FOR P.AttributeNamezh_CN IN ( [产线信息],
                                                                                              [工作中心],
                                                                                              [制令单计划开工时间],
                                                                                              [制令单计划完工时间]) ) AS Q";
            // DataTable dt = CDBConnection._GetDTInfo(CDBConnection.SQL);

            wtList.Clear();
            for (int i = 0; i < 5; i++)
            {
                WorkTicket wt = new WorkTicket();
                wt.planNo = "DFM00" + i.ToString();
                wt.planAmount = 2 * i;
                wt.UpdateState = i % 2;
                wt.prodNo = "-/--";
                wt.prodSpec = "-/--";
                wt.startTime = DateTime.Now;
                wt.endTime = DateTime.Now.AddDays(1);
                wtList.Add(wt);
            }
            //foreach (DataRow dr in dt.Rows)
            //{
            //    WorkTicket wt = new WorkTicket();
            //    wt.planNo = dr["Code"].ToString();
            //    wt.planAmount = int.Parse(dr["QTY"].ToString()); 
            //    wt.produceFlag = uint.Parse(dr["制令单状态"].ToString());
            //    wt.prodNo = dr["产线信息"].ToString();
            //    wt.prodSpec = dr["工作中心"].ToString();
            //    wt.startTime = DateTime.Parse(dr["制令单计划开工时间"].ToString());
            //    wt.endTime = DateTime.Parse(dr["制令单计划完工时间"].ToString());
            //    wtList.Add(wt);
            //} 
        }

        /// <summary>
        /// 列表中项目的选中状态处理
        /// </summary>
        /// <param name="itemWT"></param>
        private void OnItemSelected(ItemWorkTicket itemWT)
        {
            //设置所有非选中项目
            for (int i = 0; i < itemWTList.Count; i++)
            {
                if (itemWTList[i] != itemWT)
                {
                    itemWTList[i].SetSelected(false);
                }
            }
        }

        /// <summary>
        /// 列表中工单状态改变处理
        /// </summary>
        /// <param name="itemWT"></param>
        private void OnItemStateChanged(ItemWorkTicket itemWT)
        {
            //设置所有非当前项目
            for (int i = 0; i < itemWTList.Count; i++)
            {
                if (itemWTList[i] != itemWT)
                {
                    itemWTList[i].Enabled = (itemWT.WT.UpdateState != 1 && itemWT.WT.UpdateState != 2);
                    //以下条件永不满足，为防止意外而添加
                    if (itemWTList[i].WT.UpdateState == 1 || itemWTList[i].WT.UpdateState == 2)
                    {
                        itemWTList[i].WT.UpdateState = 3;
                    }
                }
                itemWTList[i].UpdateItemState();
            }
        }
    }
}

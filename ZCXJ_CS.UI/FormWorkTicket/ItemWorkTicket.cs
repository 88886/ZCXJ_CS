using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using ZCXJ_CS.Domain;
using ZCXJ_CS.Applications;
using System.IO;
using System.Threading;

namespace ZCXJ_CS.UI
{
    public partial class ItemWorkTicket : UserControl
    {
        //选中通知的委托
        public delegate void NotifySelectedDelegate(ItemWorkTicket item);
        //更改工单计划状态的委托
        public delegate void NotifyWTStateChangedDelegate(ItemWorkTicket item);
        public NotifySelectedDelegate OnNotifySelected;
        public NotifyWTStateChangedDelegate OnNotifyWTStateChanged;

        /// <summary>
        /// 工单对象
        /// </summary>
        public WorkTicket WT
        {
            get;
            set;
        }
        /// <summary>
        /// ID
        /// </summary>
        public string WorkTicketId
        {
            get;
            set;
        }
        /// <summary>
        /// 是否被选中
        /// </summary>
        public bool IsSelected
        {
            get;
            set;
        }
        /// <summary>
        /// 是否允许展开操作面板
        /// </summary>
        public bool AllowMaxPanel
        {
            get;
            set;
        }
        /// <summary>
        /// 制品ID
        /// </summary>
        public string ProductionID
        {
            get;
            set;
        }
        /// <summary>
        /// 计划起止时间
        /// </summary>
        public string WTPlanTime
        {
            get;
            set;
        }
        /// <summary>
        /// 计划生产数量
        /// </summary>
        public double CountWT
        {
            get;
            set;
        }
        /// <summary>
        /// 实际生产数量
        /// </summary>
        public double CountCompleted
        {
            get;
            set;
        }
        /// <summary>
        /// 实际合格品数量
        /// </summary>
        public double CountPassed
        {
            get;
            set;
        }
        /// <summary>
        /// 制品规格
        /// </summary>
        public string ProdSpec
        {
            get;
            set;
        }
        /// <summary>
        /// 计划执行状态
        /// </summary>
        public string WTStatus
        {
            get;
            set;
        }

        //插件dll路径
        string path;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ItemWorkTicket()
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
            path = Assembly.GetExecutingAssembly().Location;
            path = path.Substring(0, path.LastIndexOf('\\'));
            if (File.Exists(path + "\\Res\\RightPanel.png"))
                RightMaxPanel.BackgroundImage = Image.FromFile(path + "\\Res\\RightPanel.png");
            AllowMaxPanel = true;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="wt">对应的WorkTicket对象</param>
        public ItemWorkTicket(WorkTicket wt) : this()
        {
            WT = wt;
        }
        /// <summary>
        /// 控件初始化
        /// </summary>
        private void ItemWorkTicket_Load(object sender, EventArgs e)
        {
            if (null == WT)
            {
                WT = new WorkTicket();
            }
            LoadWT(WT);
        }
        /// <summary>
        /// 设置选中状态
        /// </summary>SkyBlue
        /// <param name="isSel"></param>
        public void SetSelected(bool isSel)
        {
            IsSelected = isSel;
            if (IsSelected)
            {
                this.BackColor = Color.FromArgb(200, 150, 100);
                btnShow.ForeColor = Color.White;
                btnDetails.ForeColor = Color.White;
            }
            else
            {
                RightPanelTrigger(false);
                this.BackColor = Color.LightBlue;
                btnShow.ForeColor = Color.Black;
                btnDetails.ForeColor = Color.Black;
            }
        }
        /// <summary>
        /// 显示或隐藏控件上的按钮
        /// </summary>
        /// <param name="isShow">是否隐藏</param>
        public void ShowButtons(bool isShow)
        {
            AllowMaxPanel = isShow;
            this.btnComplete.Visible = isShow;
            this.btnReport.Visible = isShow;
            this.btnRunOrPause.Visible = isShow;
            this.btnWTDetail.Visible = isShow;
        }
        /// <summary>
        /// 更新界面显示
        /// </summary>
        public void UpdateUI()
        {
            if (WT == null)
                return;
            lblWorkTicketId.Text = WT.planNo;
            lblProdId.Text = "车载充电器("+WT.prodNo+")";
            string strTime = string.Format("{0} ~ {1}",
                WT.startTime.ToString("yy-MM-dd HH:mm:ss"), WT.endTime.ToString("yy-MM-dd HH:mm:ss"));
            lblWTPlanTime.Text = strTime;
            lblCountWT.Text = WT.planAmount.ToString() + "条";
            lblProdSpec.Text = WT.prodSpec;
            lblCountCompleted.Text = WT.completeAmount.ToString() + "条";
            lblCountPassed.Text = WT.completeAmount.ToString() + "条";
            if (WT.planAmount < 1e-6)
                pgbWTProgress.Value = 0;
            else
            {
                int v = (int)(WT.completeAmount * 100 / WT.planAmount);
                pgbWTProgress.Value = (v >= 100) ? 100 : v;
            }
        }
        /// <summary>
        /// 载入工单
        /// </summary>
        private void LoadWT(WorkTicket wt, bool TimerEnable=true)
        {
            if (wt == null)
                return;
            this.BackColor = Color.LightBlue;
            WT = wt;
            UpdateUI();
            UpdateItemState();
            if (WT.UpdateState == 1 && TimerEnable)
            {
                timer.Start();
            }
        }
        /// <summary>
        /// 重新加载工单
        /// </summary>
        /// <param name="wt">工单</param>
        public void ReLoadWT(WorkTicket wt)
        {
            LoadWT(wt, false);
        }
        /// <summary>
        /// 根据工单状态设置控件界面
        /// </summary>
        public void UpdateItemState()
        {
            switch (WT.UpdateState)
            {
                case -1: //禁用
                    RightMaxPanel.Visible = false;
                    RightMinPanel.Visible = false;
                    picWTStatus.Load(path + "\\Res\\wait.png");
                    break;
                case 0: //初始状态
                    UpdateBtnEnableAndLabel("校验", "待校验", true, true,
                        true, false, false, true, false, false, false, true);
                    picWTStatus.Load(path + "\\Res\\Wait.png");
                    break;
                case 1: //运行
                    UpdateBtnEnableAndLabel("暂停", "生产中", true, true,
                        true, true, true, true, true, true, true, false);
                    picWTStatus.Load(path + "\\Res\\Run.png");
                    break;
                case 2: //暂停
                    UpdateBtnEnableAndLabel("运行", "已暂停", true, true,
                        true, true, true, true, true, true, true, false);
                    picWTStatus.Load(path + "\\Res\\wait.png");
                    break;
                case 3: //中止
                    UpdateBtnEnableAndLabel("重校验", "暂时中止", true, true,
                        true, true, false, true, true, true, true, false);
                    picWTStatus.Load(path + "\\Res\\Frozen.png");
                    break;
                case 4: //完成
                    UpdateBtnEnableAndLabel("运行", "已完成", true, true,
                        false, false, false, true, true, false, false, false);
                    picWTStatus.Load(path + "\\Res\\OK.png");
                    break;
                case 5:
                    break;
                case 100: //终止
                    UpdateBtnEnableAndLabel("运行", "已终止", true, true,
                        false, false, false, true, true, false, false, false);
                    picWTStatus.Load(path + "\\Res\\Stop.png");
                    SetSelected(false);
                    break;
                case 101: //取消
                    lblWTStatus.Text = "已取消";
                    Enabled = false;
                    RightMaxPanel.Visible = false;
                    RightMinPanel.Visible = false;
                    picWTStatus.Load(path + "\\Res\\Cancel.png");
                    SetSelected(false);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 更新控制按钮状态和文本
        /// </summary>
        /// <param name="WTStatus">状态文本</param>
        /// <param name="btntext">启动按钮文本</param>
        /// <param name="enable">依次按顺序设置按钮enable属性</param>
        private void UpdateBtnEnableAndLabel(string btntext, string WTStatus, params bool[] enable)
        {
            btnRunOrPause.Text = btntext;
            lblWTStatus.Text = WTStatus;
            if (enable != null && enable.Length > 0)
            {
                btnShow.Enabled = enable[0];
                btnDetails.Enabled = enable.Length > 1 ? enable[1] : true;
                btnRunOrPause.Enabled = enable.Length > 2 ? enable[2] : true;
                btnComplete.Enabled = enable.Length > 3 ? enable[3] : true;
                btnFrozen.Enabled = enable.Length > 4 ? enable[4] : true;
                btnHide.Enabled = enable.Length > 5 ? enable[5] : true;
                btnWTDetail.Enabled = enable.Length > 6 ? enable[6] : true;
                btnReport.Enabled = enable.Length > 7 ? enable[7] : true;
                btnStop.Enabled = enable.Length > 8 ? enable[8] : true;
                btnCancel.Enabled = enable.Length > 9 ? enable[9] : true;
            }
        }
        /// <summary>
        /// 点击label事件
        /// </summary>
        private void LabelCtrl_Click(object sender, EventArgs e)
        {
            ItemWorkTicket_Click(null, null);
        }
        /// <summary>
        /// 窗体单击事件
        /// </summary>
        private void ItemWorkTicket_Click(object sender, EventArgs e)
        {
            SetSelected(true);
            //通知父窗体
            if (OnNotifySelected != null)
            {
                OnNotifySelected(this);
            }
        }
        /// <summary>
        /// 定时器事件
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (WT.UpdateState == 1)
            {
                WT.completeAmount += 1;
                //GlobalData.WtManager.Update(WT);
                UpdateUI();
            }
        }
        /// <summary>
        /// 命令按钮点击事件
        /// </summary>
        private void CmdBtn_Click(object sender, EventArgs e)
        {
            ItemWorkTicket_Click(null, null);
            bool isNeedNotify = false;
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "btnShow":
                    RightPanelTrigger(true);
                    return;
                case "btnDetails":
                    ShowBomDialog();
                    return;
                case "btnHide":
                    break;
                case "btnRunOrPause":
                    isNeedNotify = btnRunOrPause_Click();
                    break;
                case "btnComplete":
                    isNeedNotify = UpdateWTAndTimer(4, 2);
                    break;
                case "btnWTDetail":
                    btnWTDetail_Click();
                    break;
                case "btnReport":
                    btnReport_Click();
                    break;
                case "btnFrozen":
                    isNeedNotify = UpdateWTAndTimer(3, 2);
                    break;
                case "btnStop":
                    isNeedNotify = btnCancelOrStop_Click(100);
                    break;
                case "btnCancel":
                    isNeedNotify = btnCancelOrStop_Click(101);
                    break;
            }
            RightPanelTrigger(false);
            if (isNeedNotify && OnNotifyWTStateChanged != null)
            {
                OnNotifyWTStateChanged(this);
            }
        }
        /// <summary>
        /// 右侧面板开合
        /// </summary>
        /// <param name="IsOpen">是否打开</param>
        private void RightPanelTrigger(bool IsOpen)
        {
            if (AllowMaxPanel && RightMaxPanel.Visible != IsOpen)
            {
                this.SuspendLayout();
                RightMaxPanel.Visible = IsOpen;
                RightMinPanel.Visible = !IsOpen;
                this.ResumeLayout(true);
            }
        }
        /// <summary>
        /// 取消工单或终止工单
        /// </summary>
        private bool btnCancelOrStop_Click(int UpdateState)
        {
            if (DlgBox.Show("该操作无法撤销,确认执行此操作吗？", "警告",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                return UpdateWTAndTimer(UpdateState, 0);
            }
            return false;
        }
        /// <summary>
        /// 启动或暂停工单
        /// </summary>
        private bool btnRunOrPause_Click()
        {
            bool ret = false;
            //启动工单
            if (WT.UpdateState == 0 || WT.UpdateState == 3)
            {
                if (ShowBomDialog(true))
                {
                    ret = UpdateWTAndTimer(1, 1);
                }
                else
                {
                    ret = false;
                }
            }
            else if (WT.UpdateState == 1)   //暂停工单
            {
                ret = UpdateWTAndTimer(2, 2);
            }
            else if (WT.UpdateState == 2)   //继续工单
            {
                ret = UpdateWTAndTimer(1, 1);
            }
            if (WT.UpdateState == 1)
                GlobalData.NotifyCurWorkTicketChanged(WT);
            return ret;
        }
        /// <summary>
        /// 报产
        /// </summary>
        private void btnReport_Click()
        {

        }
        /// <summary>
        /// 更新计划状态及计时器状态
        /// </summary>
        /// <param name="UpdateState">计划状态</param>
        /// <param name="TimerState">计时器状态0，无动作1，开启；2，关闭</param>
        private bool UpdateWTAndTimer(int UpdateState, int TimerState = 0)
        {
            WT.UpdateState = UpdateState;
            switch (TimerState)
            {
                case 1:
                    timer.Start();
                    break;
                case 2:
                    timer.Stop();
                    break;
            }
            GlobalData.WtManager.Update(WT);
            return true;
        }
        /// <summary>
        /// 显示工单详细信息
        /// </summary>
        private void btnWTDetail_Click()
        {
            FormRoot detail = new FormRoot();
            detail.TitleTextAlign = ContentAlignment.MiddleLeft;
            detail.Width = 500;
            detail.Height = 500;
            ItemDetail item = new ItemDetail(this);
            item.Dock = DockStyle.Fill;
            detail.ClientRootPanel.Controls.Add(item);
            detail.ShowDialog();
        }
        /// <summary>
        /// 显示施工表对话框
        /// </summary>
        /// <param name="IsDownData">是否下载数据</param>
        /// <returns></returns>
        public bool ShowBomDialog(bool IsDownData = false)
        {
            if (string.IsNullOrEmpty(WT.planNo))
                return false;
            bool isRunWorkTicket = false;
            DlgFactorVerify dlgVerify = new DlgFactorVerify();
            if (!WT.isFillBom)
                DlgBox.Show("未查询到施工表Bom信息，请与工单下发人员联系", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                isRunWorkTicket = (WT.isFillBom && dlgVerify.Show(WT,IsDownData) == DialogResult.Yes);
                if (!GlobalData.WtManager.SavePlanBomCacheIfNotNull(WT))
                    GlobalData.Log.Error("保存工单Bom失败,工单编号：{0}", WT.planNo);
            }
            return isRunWorkTicket;
        }
    }
}

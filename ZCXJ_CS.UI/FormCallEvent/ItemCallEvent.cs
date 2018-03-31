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
using FormCallEvent;
using ZCXJ_CS.Applications;
using ZCXJ_CS.Infrastructure;
using ZCXJ_CS.Utilities;

namespace ZCXJ_CS.UI
{
    public partial class ItemCallEvent : UserControl
    {
        //选中通知的委托
        public delegate void CallSelectedDelegate(ItemCallEvent item);
        public event CallSelectedDelegate OnCallSelected;
        public LogHelper log;
        public CallEvent CE
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
        
        public void SetSelected(bool isSel)
        {
            IsSelected = isSel;
            if (IsSelected)
            {
                this.BackColor = Color.FromArgb(200, 150, 100);
            }
            else
            {
                this.BackColor = Color.LightBlue;
            }
        }
        /// <summary>
        /// 资源文件路径
        /// </summary>
        public string ResPath
        {
            get
            {
                string SelfPath = Assembly.GetExecutingAssembly().Location;
                SelfPath = SelfPath.Substring(0, SelfPath.LastIndexOf('\\'));
                return SelfPath + "\\Res\\Call\\";
            }
        }
        /// <summary>
        /// 控件加载时更新界面
        /// </summary>
        private void ItemCallEvent_Load(object sender, EventArgs e)
        {
            UpdataUI();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id"></param>
        public ItemCallEvent(CallEvent wt)
        {
            InitializeComponent();
            Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
            CE = wt;
        }
        /// <summary>
        /// 更新界面
        /// </summary>
        public void UpdataUI()
        {
            if (CE != null)
            {
                lblEventId.Text = CE.eventNo;
                lblEventType.Text = CE.eventstateName;
                lblcount.Text = CE.callCount.ToString() + "次";
                lblcallName.Text = CE.callApplyName;
                lblcallTime.Text = CE.callTime.ToString("yy-MM-dd HH:mm:ss");
                lblprocessName.Text = CE.callProcessName;
                lblprocessTime.Text = CE.startProcessTime.ToString("yy-MM-dd HH:mm:ss");
                lblensureName.Text = CE.callEnsureName;
                lblensureTime.Text = CE.endProcessTime.ToString("yy-MM-dd HH:mm:ss");
                lblContent.Text = CE.eventContent;
                lblRemark.Text = CE.Remark;
                switch (CE.eventState)
                {
                    case 0:
                        picWTStatus.Load(ResPath + "Calling.png");
                        btnStart.Enabled = true;
                        btnStart.Image = Image.FromFile(ResPath + "BtnStart.png");
                        btnFinish.Enabled = false;
                        btnFinish.Image = Image.FromFile(ResPath + "BtnDFinish.png");
                        btnReCall.Enabled = true;
                        btnReCall.Image = Image.FromFile(ResPath + "BtnReCall.png");
                        break;

                    case 1:
                        picWTStatus.Load(ResPath + "Treating.png");
                        btnStart.Enabled = false;
                        btnStart.Image = Image.FromFile(ResPath + "BtnDStart.png");
                        btnFinish.Enabled = true;
                        btnFinish.Image = Image.FromFile(ResPath + "BtnFinish.png");
                        btnReCall.Enabled = false;
                        btnReCall.Image = Image.FromFile(ResPath + "BtnDReCall.png");
                        break;
                    case 2:
                        picWTStatus.Load(ResPath + "Finish.png");
                        btnStart.Enabled = false;
                        btnStart.Image = Image.FromFile(ResPath + "BtnDStart.png");
                        btnFinish.Enabled = false;
                        btnFinish.Image = Image.FromFile(ResPath + "BtnDFinish.png");
                        btnReCall.Enabled = false;
                        btnReCall.Image = Image.FromFile(ResPath + "BtnDReCall.png");
                        break;
                    default:
                        break;
                }
            }
        }
        #region 开始按钮事件
        private void btnRunOrPause_Click(object sender, EventArgs e)
        {
            CallEventDetail chw_callstart = new CallEventDetail(CE);
            chw_callstart.State = 1;
            if (chw_callstart.ShowDialog() == DialogResult.OK)
                UpdataUI();
        }
        #endregion

        #region 完成按钮事件
        private void btnWTOK_Click(object sender, EventArgs e)
        {
            CallEventDetail chw_callstart = new CallEventDetail(CE);
            chw_callstart.State = 2;
            if (chw_callstart.ShowDialog() == DialogResult.OK)
                UpdataUI();
        }
        #endregion

        #region 重呼按钮事件
        private void btncall_Click(object sender, EventArgs e)
        {
            CallEventManager ceManager = new CallEventManager();
            CE.callCount = CE.callCount + 1;
            ceManager.Update(CE);
            ceManager.UpEnvent(CE);
            UpdataUI();
        }
        #endregion


        private void picWTStatus_MouseDown(object sender, MouseEventArgs e)
        {
            ItemCallEvent_Click(null, null);
        }
        Image img = null;
        private void btnStart_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if(pic.Enabled)
            {
                img = pic.Image;
                switch (pic.Name)
                {
                    case "btnStart":
                        pic.Image = Image.FromFile(ResPath + "BtnOStart.png");
                        break;
                    case "btnFinish":
                        pic.Image = Image.FromFile(ResPath + "BtnOFinish.png");
                        break;
                    case "btnReCall":
                        pic.Image = Image.FromFile(ResPath + "BtnOReCall.png");
                        break;
                }
            }
        }

        private void btnStart_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic.Enabled)
            {
                pic.Image = img;
            }
        }

        private void ItemCallEvent_Click(object sender, EventArgs e)
        {
            this.SetSelected(true);
            if (OnCallSelected != null)
                OnCallSelected(this);
        }
    }
}

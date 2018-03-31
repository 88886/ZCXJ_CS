using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ZCXJ_CS.Applications;
using ZCXJ_CS.Domain;
using ZCXJ_CS.Infrastructure;
using ZCXJ_CS.UI;
using ZCXJ_CS.Utilities;

namespace FormCallEvent
{
    public partial class CallEventDetail : Form
    {
        CallEventManager ceManager;
        public int State;
        public LogHelper log;
        public CallEvent CE;
        public UserManager UsManager = null;

        public CallEventDetail(CallEvent ce)
        {
            InitializeComponent();
            ceManager = new CallEventManager();
            log = LogHelper.GetInstence();
            GlobalData.SpScanner.OnDataReceived += serialport_OnDataReceived;
            UsManager = new UserManager();
            CE = ce;
        }

        private void CallEventDetail_Load(object sender, EventArgs e)
        {
            switch (State)
            {
                case 0:
                    txbcallApplyName.Enabled = true;
                    txbcallProcessName.Enabled = false;
                    txbcallEnsureName.Enabled = false;
                    txbeventNo.Text = CE.eventNo;
                    txbeventContent.Enabled = true;
                    txbRemark.Enabled = true;
                    cobcallType.Text = CE.eventstateName;
                    break;

                case 1:
                    txbcallApplyName.Enabled = false;
                    txbcallProcessName.Enabled = true;
                    txbcallEnsureName.Enabled = false;
                    txbeventContent.Enabled = false;
                    txbRemark.Enabled = true;
                    cobcallType.Text = CE.eventstateName;
                    txbeventNo.Text = CE.eventNo;
                    txbcallApplyName.Text = CE.callApplyName;
                    txbcallProcessName.Text = CE.callProcessName;
                    txbcallEnsureName.Text = CE.callEnsureName;
                    txbeventContent.Text = CE.eventContent;
                    txbRemark.Text = CE.Remark;
                    break;

                case 2:
                    txbcallApplyName.Enabled = false;
                    txbcallProcessName.Enabled = false;
                    txbcallEnsureName.Enabled = true;
                    txbeventContent.Enabled = false;
                    txbRemark.Enabled = false;
                    cobcallType.Text = CE.eventstateName;
                    txbeventNo.Text = CE.eventNo;
                    txbcallApplyName.Text = CE.callApplyName;
                    txbcallProcessName.Text = CE.callProcessName;
                    txbcallEnsureName.Text = CE.callEnsureName;
                    txbeventContent.Text = CE.eventContent;
                    txbRemark.Text = CE.Remark;
                    break;

                default:
                    break;
            }


            
        }

        #region 扫码器冒泡事件
        void serialport_OnDataReceived(object sender, byte[] data)
        {
            string str = System.Text.Encoding.UTF8.GetString(data).Replace("\r\n", "");//字节转换成字符串
            try
            {
                if (!string.IsNullOrEmpty(str) && str.IndexOf("HC") == 0)
                {
                    string Name = UsManager.QueryUser(str, 0);
                    if (!string.IsNullOrEmpty(Name))
                    {
                        Invoke(new Action(() =>
                        {
                            if (this.ActiveControl is System.Windows.Forms.TextBox)
                            {
                                this.ActiveControl.Text = Name;
                            }
                        }));
                        return;
                    }
                }
                DlgBox.Show("无效的卡号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                log.Info("扫码异常！");
            }
        }
        #endregion

        #region 确认
        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (State)
            {
                case 0:
                    if (txbcallApplyName.Text.Trim() != "")
                    {
                        CE.callTime = DateTime.Now;
                        CE.callApplyName = txbcallApplyName.Text.Replace("\r\n", "");
                        CE.callApplyPerson = UsManager.QueryUserID(txbcallApplyName.Text.Trim());
                        CE.eventContent = txbeventContent.Text;
                        CE.Remark = txbRemark.Text;
                        CE.callCount = 1;
                        UpdateCE(true, 0);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("无呼叫人员信息，无法提交！");
                    }
                    break;

                case 1:
                    if (txbcallProcessName.Text.Trim() != "")
                    {
                        CE.Remark = txbRemark.Text;
                        CE.startProcessTime = DateTime.Now;
                        CE.callProcessName = txbcallProcessName.Text.Replace("\r\n", "");
                        CE.callProcessPerson = UsManager.QueryUserID(txbcallProcessName.Text.Trim());
                        UpdateCE(false, 1);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("无处理人员信息，无法提交！");
                    }
                    break;

                case 2:
                    if (txbcallEnsureName.Text.Trim() != "")
                    {
                        CE.endProcessTime = DateTime.Now;
                        CE.callEnsureName = txbcallEnsureName.Text.Replace("\r\n", "");
                        CE.callEnsurePerson = UsManager.QueryUserID(txbcallEnsureName.Text.Trim());
                        UpdateCE(false, 2);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("无确认人员信息，无法提交！");
                    }
                    break;

                default:
                    break;
            }
           
        }
        #endregion
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="IsAdd">是否新增</param>
        /// <param name="EventState">事件状态</param>
        public void UpdateCE(bool IsAdd,int EventState)
        {
            CE.eventState = EventState;
            if (IsAdd)
                ceManager.Add(CE);
            else
                ceManager.Update(CE);
            ceManager.UpEnvent(CE);
        }
        #region 取消
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion


        #region 文本框按钮事件

        private void post_tbox1_KeyDown(object sender, KeyEventArgs e)
        {
            System.Windows.Forms.TextBox tBox = (System.Windows.Forms.TextBox)sender;
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    tBox.Text = UsManager.QueryUser(tBox.Text,0);
                    break;
                case Keys.Escape:
                    tBox.Text = "";
                    break;
                default:
                    break;
            }
        }

        private void textBox_shift_KeyDown(object sender, KeyEventArgs e)
        {
            System.Windows.Forms.TextBox tBox = (System.Windows.Forms.TextBox)sender;
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    tBox.Text = UsManager.QueryUser(tBox.Text,0);
                    break;
                case Keys.Escape:
                    tBox.Text = "";
                    break;
                default:
                    break;
            }
        }

        private void textBox_obtain_KeyDown(object sender, KeyEventArgs e)
        {
            System.Windows.Forms.TextBox tBox = (System.Windows.Forms.TextBox)sender;
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    tBox.Text = UsManager.QueryUser(tBox.Text,0);
                    break;
                case Keys.Escape:
                    tBox.Text = "";
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}

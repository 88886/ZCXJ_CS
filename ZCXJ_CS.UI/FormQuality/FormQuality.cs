using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZCXJ_CS.Applications;
using ZCXJ_CS.Domain;

namespace ZCXJ_CS.UI
{
    public partial class FormQuality : FormBase
    {
        //质检管理对象
        private QualityManager qManager;
        //当前工单的临时拷贝
        private WorkTicket WT;
        public FormQuality()
        {
            InitializeComponent();
            qManager = new QualityManager();
            WT = GlobalData.WtManager.CurWorkTicket;
            GlobalData.OnCurWorkTicketChanged += GlobalData_OnCurWorkTicketChanged;
        }
        /// <summary>
        /// 工单切换事件
        /// </summary>
        private void GlobalData_OnCurWorkTicketChanged(object sender, EventArgs e)
        {
            if (WT.planNo != GlobalData.WtManager.CurWorkTicket.planNo)
            {
                WT = GlobalData.WtManager.CurWorkTicket;
                bool isExistStandard = qManager.ExistQualityStandard(WT.prodNo, IsNetConnected);
                if (isExistStandard)
                {
                    //TODO 制定质检计划
                }
                else
                {
                    string msg = IsNetConnected ? "正在同步质检标准" : "请联网同步";
                    GlobalData.Log.Info("无制品检验标准缓存！{0}", msg);
                }
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

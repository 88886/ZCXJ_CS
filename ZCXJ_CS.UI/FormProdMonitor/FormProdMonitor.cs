using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ZCXJ_CS.UI;
using ZCXJ_CS.Applications;
using ZCXJ_CS.Domain;

namespace ZCXJ_CS.UI
{
    public partial class FormProdMonitor : FormBase
    {
        List<PointF> listP = new List<PointF>();
        //当前工单控件
        private ItemWorkTicket ItemWT = null;
        private WorkTicket wt = null;
        double count = 0;
        public FormProdMonitor()
        {
            InitializeComponent();
            wt = GlobalData.WtManager.CurWorkTicket;
            count = wt.completeAmount;
            ItemWT = new ItemWorkTicket(wt);
            ItemWT.Dock = DockStyle.Fill;
            ItemWT.ShowButtons(false);
            panelCurWT.Controls.Add(ItemWT);
            GlobalData.OnCurWorkTicketChanged += GlobalData_OnCurWorkTicketChanged;
        }
        /// <summary>
        /// 运行工单切换事件
        /// </summary>
        private void GlobalData_OnCurWorkTicketChanged(object sender, EventArgs e)
        {
            if (wt.planNo != GlobalData.WtManager.CurWorkTicket.planNo)
            {
                count = wt.completeAmount;
                wt = GlobalData.WtManager.CurWorkTicket;
                listP.Clear();
                yGraphWT.f_ClearAllPix();
                yGraphWT.f_AddPix(ref listP, Color.Gold, (float)1.5);
                yGraphWT.f_AddPix(ref listP, Color.Red, 10, LineJoin.Round, LineCap.Flat, Yangyalin.YGraph.DrawStyle.dot);
                i = 0;
            }
        }
        int i = 0;
        private void AddPoint()
        {
            listP.Add(new PointF((float)i, (float)(7+Math.Abs(Math.Sin(i)*2))));
            yGraphWT.YGraphTip = listP.Last().Y.ToString("0.00");
            if (listP.Count > 20)
            {
                listP.RemoveRange(0, listP.Count - 20);
                yGraphWT.YGraphxAxisBegin = (int)listP[0].X;
                yGraphWT.YGraphxAxisEnd = (int)listP.Last().X + 2f;
                yGraphWT.f_RefreshXY();
            }
            else
            {
                yGraphWT.f_Refresh();
            }
            i++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (ItemWT != null)
                {
                    ItemWT.ReLoadWT(wt);
                    ItemWT.SetSelected(ItemWT.IsSelected);
                }
                if (wt.GetWTState() == WTState.Running && count < wt.completeAmount)
                {
                    AddPoint();
                    count = wt.completeAmount;
                }
            }
            catch { }
        }
    }
}

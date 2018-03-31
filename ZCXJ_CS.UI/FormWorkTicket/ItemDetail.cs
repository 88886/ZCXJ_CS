using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZCXJ_CS.UI
{
    public partial class ItemDetail : UserControl
    {
        ItemWorkTicket parentItem = null;
        public ItemDetail(ItemWorkTicket Item)
        {
            parentItem = Item;
            InitializeComponent();
        }

        private void ItemDetail_Load(object sender, EventArgs e)
        {
            txtItemDetail.AppendText("工单号：" + parentItem.WorkTicketId + "\r\n");
            txtItemDetail.AppendText("制品编码：" + parentItem.ProductionID + "\r\n");
            txtItemDetail.AppendText("制品名：" + "胎面" + "\r\n");
            txtItemDetail.AppendText("制品规格：" + parentItem.ProdSpec + "\r\n");
            txtItemDetail.AppendText("计划时间：" + parentItem.WTPlanTime + "\r\n");
            txtItemDetail.AppendText("任务数：" + parentItem.CountWT + "\r\n");
            txtItemDetail.AppendText("物料1： XXXXXXXXX  编码：" + "XXXXXXXXX" + "\r\n");
            txtItemDetail.AppendText("物料2： XXXXXXXXX  编码：" + "XXXXXXXXX" + "\r\n");
            txtItemDetail.AppendText("物料3： XXXXXXXXX  编码：" + "XXXXXXXXX" + "\r\n");
            txtItemDetail.AppendText("物料4： XXXXXXXXX  编码：" + "XXXXXXXXX" + "\r\n");
            txtItemDetail.AppendText("工装1： XXXXXXXXX  编码：" + "XXXXXXXXX" + "\r\n");
            txtItemDetail.AppendText("工装2： XXXXXXXXX  编码：" + "XXXXXXXXX" + "\r\n");
            txtItemDetail.AppendText("工装3： XXXXXXXXX  编码：" + "XXXXXXXXX" + "\r\n");
            txtItemDetail.AppendText("工装4： XXXXXXXXX  编码：" + "XXXXXXXXX" + "\r\n");
            txtItemDetail.AppendText("质检计划编号： XXXXXXXXX" + "\r\n");
            txtItemDetail.AppendText("工艺单编号： XXXXXXXXX \r\n");
            txtItemDetail.AppendText("当前进度： \r\n");
            txtItemDetail.AppendText("当前状态：" + parentItem.WTStatus + "\r\n");
        }
    }
}

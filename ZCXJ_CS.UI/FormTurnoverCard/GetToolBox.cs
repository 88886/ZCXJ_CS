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
    public delegate void FillTextChangeDelegate(bool IsFill);
    public partial class GetToolBox : UserControl
    {
        public event FillTextChangeDelegate OnFillTextChange;
        /// <summary>
        /// 产量
        /// </summary>
        public int Count
        {
            get { return Convert.ToInt32(txCount.Text); }
            set { txCount.Text = value.ToString(); }
        }
        /// <summary>
        /// 工装
        /// </summary>
        public string Tool
        {
            get { return txTool.Text; }
            set { txTool.Text = value; }
        }
        public GetToolBox()
        {
            InitializeComponent();
        }

        private void txTool_TextChanged(object sender, EventArgs e)
        {
            bool IsFillBox = Count > 0 && txTool.Text.Length > 0;
            if (OnFillTextChange != null)
                OnFillTextChange(IsFillBox);
        }

        private void GetBox_Load(object sender, EventArgs e)
        {
            if (OnFillTextChange != null)
                OnFillTextChange(false);
        }
    }
}

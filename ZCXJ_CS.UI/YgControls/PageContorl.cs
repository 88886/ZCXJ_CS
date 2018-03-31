using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace ZCXJ_CS.UI
{
    public delegate void PageEventArgs(int Index);

    public partial class PageContorl : UserControl
    {
        public event PageEventArgs OnPageChange;
        public int PageCount
        {
            get
            {
                return Convert.ToInt32(lbPageSize.Text);
            }
            set
            {
                lbPageSize.Text = value.ToString();
                UpdataCmdBtn(CurrentIndex);
            }
        }
        public int CurrentIndex
        {
            get
            {
                return Convert.ToInt32(txIndex.Text);
            }
        }
        public int RecordCount
        {
            get
            {
                return 0;
            }
        }
        public string PluginPath
        {
            get
            {
                string SelfPath = Assembly.GetExecutingAssembly().Location;
                SelfPath = SelfPath.Substring(0, SelfPath.LastIndexOf('\\'));
                return SelfPath;
            }
        }
        public PageContorl()
        {
            InitializeComponent();
        }

        private void PageStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int index = 0;
            switch (e.ClickedItem.Name)
            {
                case "btnFirst":
                    index = 1;
                    break;
                case "btnPreview":
                    index = CurrentIndex - 1;
                    break;
                case "btnNext":
                    index = CurrentIndex + 1;
                    break;
                case "btnLast":
                    index = PageCount;
                    break;
            }
            if (index != 0)
            {
                txIndex.Text = index.ToString();
                UpdataCmdBtn(index);
                if (OnPageChange != null)
                {
                    OnPageChange.Invoke(index);
                }
            }
        }
        private void UpdataCmdBtn(int index)
        {
            btnFirst.Enabled = btnPreview.Enabled = index > 1;
            btnNext.Enabled = btnLast.Enabled = index < PageCount;
            if (File.Exists(PluginPath + "\\Res\\Page\\First.png"))
            {
                btnFirst.DisplayStyle = ToolStripItemDisplayStyle.Image;
                btnPreview.DisplayStyle = ToolStripItemDisplayStyle.Image;
                btnNext.DisplayStyle = ToolStripItemDisplayStyle.Image;
                btnLast.DisplayStyle = ToolStripItemDisplayStyle.Image;
                string path = PluginPath + "\\Res\\Page\\{0}";
                btnFirst.BackgroundImage = Image.FromFile(string.Format(path+"First.png",btnFirst.Enabled?"":"d"));
                btnPreview.BackgroundImage = Image.FromFile(string.Format(path + "Preview.png",btnPreview.Enabled?"":"d"));
                btnNext.BackgroundImage = Image.FromFile(string.Format(path + "Next.png", btnNext.Enabled ? "" : "d"));
                btnLast.BackgroundImage = Image.FromFile(string.Format(path + "Last.png", btnLast.Enabled ? "" : "d"));
            }
            else
            {
                btnFirst.DisplayStyle = ToolStripItemDisplayStyle.Text;
                btnPreview.DisplayStyle = ToolStripItemDisplayStyle.Text;
                btnNext.DisplayStyle = ToolStripItemDisplayStyle.Text;
                btnLast.DisplayStyle = ToolStripItemDisplayStyle.Text;
            }
        }

        private void PageContorl_Load(object sender, EventArgs e)
        {
            UpdataCmdBtn(1);
        }
    }
}

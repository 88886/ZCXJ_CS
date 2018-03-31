using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZCXJ_CS.UI
{
    public partial class DlgBase : FormRoot
    {
        protected Panel MainPanel;
        private FlowLayoutPanel flowLayoutBottom;
        private SplitContainer MainsplitContainer;

        private void InitializeComponent()
        {
            this.MainsplitContainer = new System.Windows.Forms.SplitContainer();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.flowLayoutBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.RootMainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainsplitContainer)).BeginInit();
            this.MainsplitContainer.Panel1.SuspendLayout();
            this.MainsplitContainer.Panel2.SuspendLayout();
            this.MainsplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // RootMainPanel
            // 
            this.RootMainPanel.Controls.Add(this.MainsplitContainer);
            // 
            // MainsplitContainer
            // 
            this.MainsplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainsplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.MainsplitContainer.IsSplitterFixed = true;
            this.MainsplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainsplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.MainsplitContainer.Name = "MainsplitContainer";
            this.MainsplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainsplitContainer.Panel1
            // 
            this.MainsplitContainer.Panel1.Controls.Add(this.MainPanel);
            // 
            // MainsplitContainer.Panel2
            // 
            this.MainsplitContainer.Panel2.Controls.Add(this.flowLayoutBottom);
            this.MainsplitContainer.Size = new System.Drawing.Size(673, 395);
            this.MainsplitContainer.SplitterDistance = 353;
            this.MainsplitContainer.SplitterWidth = 1;
            this.MainsplitContainer.TabIndex = 0;
            // 
            // MainPanel
            // 
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(673, 353);
            this.MainPanel.TabIndex = 0;
            // 
            // flowLayoutBottom
            // 
            this.flowLayoutBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutBottom.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutBottom.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutBottom.Name = "flowLayoutBottom";
            this.flowLayoutBottom.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.flowLayoutBottom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flowLayoutBottom.Size = new System.Drawing.Size(673, 41);
            this.flowLayoutBottom.TabIndex = 0;
            // 
            // DlgBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.ClientSize = new System.Drawing.Size(675, 432);
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "DlgBase";
            this.TitleTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RootMainPanel.ResumeLayout(false);
            this.MainsplitContainer.Panel1.ResumeLayout(false);
            this.MainsplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainsplitContainer)).EndInit();
            this.MainsplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public DlgBase()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
        }
        public Panel BaseMainPanel
        {
            get { return MainPanel; }
        }

        public FlowLayoutPanel BottomPane
        {
            get { return flowLayoutBottom; }
        }
        /// <summary>
        /// 构造对话框按钮
        /// </summary>
        /// <param name="Text">显示文本</param>
        /// <param name="Name">名称</param>
        /// <param name="TabIndex">Tab序号</param>
        /// <param name="eHandler">点击事件</param>
        /// <param name="btnResult">对话框响应</param>
        /// <returns></returns>
        public Button GenComandBtn(string Text, string Name, int TabIndex, EventHandler eHandler, DialogResult? btnResult = null)
        {
            Button Btn = new Button();
            Btn.Text = Text;
            Btn.Size = new Size(100, 30);
            Btn.Height = 30;
            Btn.Width = (int)Btn.CreateGraphics().MeasureString(Text, Btn.Font).Width + 80;
            Btn.Name = Name;
            Btn.TabIndex = 0;
            Btn.TabIndex = TabIndex;
            Btn.UseVisualStyleBackColor = true;
            if (btnResult.HasValue)
            {
                Btn.DialogResult = btnResult.GetValueOrDefault(DialogResult.None);
            }
            Btn.Click += eHandler;
            return Btn;
        }
    }
}

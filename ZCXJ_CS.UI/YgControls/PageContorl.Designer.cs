namespace ZCXJ_CS.UI
{
    partial class PageContorl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.PageStrip = new System.Windows.Forms.ToolStrip();
            this.btnFirst = new System.Windows.Forms.ToolStripButton();
            this.btnPreview = new System.Windows.Forms.ToolStripButton();
            this.txIndex = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lbPageSize = new System.Windows.Forms.ToolStripLabel();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.btnLast = new System.Windows.Forms.ToolStripButton();
            this.PageStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // PageStrip
            // 
            this.PageStrip.BackColor = System.Drawing.SystemColors.Control;
            this.PageStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PageStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PageStrip.GripMargin = new System.Windows.Forms.Padding(1);
            this.PageStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.PageStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.PageStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFirst,
            this.btnPreview,
            this.txIndex,
            this.toolStripLabel1,
            this.lbPageSize,
            this.btnNext,
            this.btnLast});
            this.PageStrip.Location = new System.Drawing.Point(0, 0);
            this.PageStrip.Name = "PageStrip";
            this.PageStrip.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.PageStrip.Size = new System.Drawing.Size(521, 50);
            this.PageStrip.TabIndex = 0;
            this.PageStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.PageStrip_ItemClicked);
            // 
            // btnFirst
            // 
            this.btnFirst.AutoSize = false;
            this.btnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFirst.Enabled = false;
            this.btnFirst.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnFirst.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(48, 48);
            this.btnFirst.Text = "首页";
            this.btnFirst.ToolTipText = "首页";
            // 
            // btnPreview
            // 
            this.btnPreview.AutoSize = false;
            this.btnPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPreview.Enabled = false;
            this.btnPreview.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnPreview.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(48, 48);
            this.btnPreview.Text = "上一页";
            // 
            // txIndex
            // 
            this.txIndex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txIndex.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txIndex.Name = "txIndex";
            this.txIndex.ReadOnly = true;
            this.txIndex.Size = new System.Drawing.Size(30, 50);
            this.txIndex.Text = "1";
            this.txIndex.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(18, 47);
            this.toolStripLabel1.Text = "/";
            // 
            // lbPageSize
            // 
            this.lbPageSize.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPageSize.Name = "lbPageSize";
            this.lbPageSize.Size = new System.Drawing.Size(20, 47);
            this.lbPageSize.Text = "1";
            // 
            // btnNext
            // 
            this.btnNext.AutoSize = false;
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(48, 48);
            this.btnNext.Text = "下一页";
            // 
            // btnLast
            // 
            this.btnLast.AutoSize = false;
            this.btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLast.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnLast.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(48, 48);
            this.btnLast.Text = "尾页";
            // 
            // PageContorl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PageStrip);
            this.Name = "PageContorl";
            this.Size = new System.Drawing.Size(521, 50);
            this.Load += new System.EventHandler(this.PageContorl_Load);
            this.PageStrip.ResumeLayout(false);
            this.PageStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip PageStrip;
        private System.Windows.Forms.ToolStripButton btnPreview;
        private System.Windows.Forms.ToolStripButton btnFirst;
        private System.Windows.Forms.ToolStripTextBox txIndex;
        private System.Windows.Forms.ToolStripLabel lbPageSize;
        private System.Windows.Forms.ToolStripButton btnNext;
        private System.Windows.Forms.ToolStripButton btnLast;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}

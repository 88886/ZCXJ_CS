namespace FromProcessView
{
    partial class ProcessTicket
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.PnlContent = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProcessTime = new System.Windows.Forms.Label();
            this.lblProcessName = new System.Windows.Forms.Label();
            this.pnlPic = new System.Windows.Forms.Panel();
            this.picProcess = new System.Windows.Forms.PictureBox();
            this.pnlIndex = new System.Windows.Forms.Panel();
            this.lblProcessIndex = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.PnlContent.SuspendLayout();
            this.pnlPic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProcess)).BeginInit();
            this.pnlIndex.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.PnlContent);
            this.pnlTop.Controls.Add(this.pnlPic);
            this.pnlTop.Controls.Add(this.pnlIndex);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(387, 44);
            this.pnlTop.TabIndex = 1;
            // 
            // PnlContent
            // 
            this.PnlContent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PnlContent.Controls.Add(this.label1);
            this.PnlContent.Controls.Add(this.lblProcessTime);
            this.PnlContent.Controls.Add(this.lblProcessName);
            this.PnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlContent.Location = new System.Drawing.Point(35, 0);
            this.PnlContent.Name = "PnlContent";
            this.PnlContent.Size = new System.Drawing.Size(296, 42);
            this.PnlContent.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(154, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "过站时间 :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblProcessTime
            // 
            this.lblProcessTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProcessTime.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProcessTime.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblProcessTime.Location = new System.Drawing.Point(206, 26);
            this.lblProcessTime.Name = "lblProcessTime";
            this.lblProcessTime.Size = new System.Drawing.Size(90, 16);
            this.lblProcessTime.TabIndex = 2;
            this.lblProcessTime.Text = "2018-3-30 11:10";
            this.lblProcessTime.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblProcessName
            // 
            this.lblProcessName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProcessName.BackColor = System.Drawing.Color.Transparent;
            this.lblProcessName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProcessName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblProcessName.Location = new System.Drawing.Point(0, 0);
            this.lblProcessName.Name = "lblProcessName";
            this.lblProcessName.Size = new System.Drawing.Size(296, 26);
            this.lblProcessName.TabIndex = 1;
            this.lblProcessName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblProcessName.Click += new System.EventHandler(this.lblProcessName_Click);
            // 
            // pnlPic
            // 
            this.pnlPic.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlPic.Controls.Add(this.picProcess);
            this.pnlPic.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlPic.Location = new System.Drawing.Point(331, 0);
            this.pnlPic.Name = "pnlPic";
            this.pnlPic.Size = new System.Drawing.Size(54, 42);
            this.pnlPic.TabIndex = 2;
            // 
            // picProcess
            // 
            this.picProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picProcess.BackColor = System.Drawing.Color.Transparent;
            this.picProcess.Location = new System.Drawing.Point(3, 3);
            this.picProcess.Name = "picProcess";
            this.picProcess.Size = new System.Drawing.Size(48, 36);
            this.picProcess.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProcess.TabIndex = 0;
            this.picProcess.TabStop = false;
            // 
            // pnlIndex
            // 
            this.pnlIndex.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlIndex.Controls.Add(this.lblProcessIndex);
            this.pnlIndex.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIndex.Location = new System.Drawing.Point(0, 0);
            this.pnlIndex.Name = "pnlIndex";
            this.pnlIndex.Size = new System.Drawing.Size(35, 42);
            this.pnlIndex.TabIndex = 0;
            // 
            // lblProcessIndex
            // 
            this.lblProcessIndex.BackColor = System.Drawing.Color.Transparent;
            this.lblProcessIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProcessIndex.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProcessIndex.Location = new System.Drawing.Point(0, 0);
            this.lblProcessIndex.Name = "lblProcessIndex";
            this.lblProcessIndex.Size = new System.Drawing.Size(35, 42);
            this.lblProcessIndex.TabIndex = 0;
            this.lblProcessIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProcessTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Name = "ProcessTicket";
            this.Size = new System.Drawing.Size(387, 44);
            this.Load += new System.EventHandler(this.ProcessTicket_Load);
            this.pnlTop.ResumeLayout(false);
            this.PnlContent.ResumeLayout(false);
            this.pnlPic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picProcess)).EndInit();
            this.pnlIndex.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlPic;
        private System.Windows.Forms.Panel pnlIndex;
        private System.Windows.Forms.Panel PnlContent;
        private System.Windows.Forms.Label lblProcessIndex;
        private System.Windows.Forms.PictureBox picProcess;
        private System.Windows.Forms.Label lblProcessName;
        private System.Windows.Forms.Label lblProcessTime;
        private System.Windows.Forms.Label label1;
    }
}

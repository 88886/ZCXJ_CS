namespace ZCXJ_CS.Presentation
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.staStripMain = new System.Windows.Forms.StatusStrip();
            this.staStripShowOutWnd = new System.Windows.Forms.ToolStripStatusLabel();
            this.staStripX1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.staStripNote = new System.Windows.Forms.ToolStripStatusLabel();
            this.staStripTest2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.staStripX2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.staStripTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.staStripVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.picMainRIcon = new System.Windows.Forms.PictureBox();
            this.picMainIcon = new System.Windows.Forms.PictureBox();
            this.picNetwork = new System.Windows.Forms.PictureBox();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.lblLoginUser = new System.Windows.Forms.Label();
            this.picLoginUser = new System.Windows.Forms.PictureBox();
            this.tabCtrlMain = new System.Windows.Forms.TabControl();
            this.LogPage = new System.Windows.Forms.TabPage();
            this.logText = new System.Windows.Forms.Label();
            this.LogPictruce = new System.Windows.Forms.PictureBox();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.tabCtrlBottom = new System.Windows.Forms.TabControl();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.tabPageBarCode = new System.Windows.Forms.TabPage();
            this.MainSplit = new System.Windows.Forms.SplitContainer();
            this.tsMainTop = new System.Windows.Forms.ToolStrip();
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.staStripMain.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMainRIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMainIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNetwork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoginUser)).BeginInit();
            this.tabCtrlMain.SuspendLayout();
            this.LogPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogPictruce)).BeginInit();
            this.tabCtrlBottom.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).BeginInit();
            this.MainSplit.Panel1.SuspendLayout();
            this.MainSplit.Panel2.SuspendLayout();
            this.MainSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // staStripMain
            // 
            this.staStripMain.BackColor = System.Drawing.Color.Transparent;
            this.staStripMain.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.staStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.staStripShowOutWnd,
            this.staStripX1,
            this.staStripNote,
            this.staStripTest2,
            this.staStripX2,
            this.staStripTime,
            this.toolStripStatusLabel1,
            this.staStripVersion});
            this.staStripMain.Location = new System.Drawing.Point(0, 713);
            this.staStripMain.Name = "staStripMain";
            this.staStripMain.Size = new System.Drawing.Size(1024, 28);
            this.staStripMain.TabIndex = 1;
            // 
            // staStripShowOutWnd
            // 
            this.staStripShowOutWnd.ForeColor = System.Drawing.Color.White;
            this.staStripShowOutWnd.Name = "staStripShowOutWnd";
            this.staStripShowOutWnd.Size = new System.Drawing.Size(101, 23);
            this.staStripShowOutWnd.Text = " ↑ [条码-日志]";
            this.staStripShowOutWnd.Click += new System.EventHandler(this.staStripShowOutWnd_Click);
            // 
            // staStripX1
            // 
            this.staStripX1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.staStripX1.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.staStripX1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.staStripX1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.staStripX1.Name = "staStripX1";
            this.staStripX1.Size = new System.Drawing.Size(17, 23);
            this.staStripX1.Text = " ";
            // 
            // staStripNote
            // 
            this.staStripNote.AutoSize = false;
            this.staStripNote.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.staStripNote.ForeColor = System.Drawing.Color.White;
            this.staStripNote.Name = "staStripNote";
            this.staStripNote.Size = new System.Drawing.Size(550, 23);
            this.staStripNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.staStripNote.Click += new System.EventHandler(this.staStripNote_Click);
            // 
            // staStripTest2
            // 
            this.staStripTest2.ForeColor = System.Drawing.Color.White;
            this.staStripTest2.Name = "staStripTest2";
            this.staStripTest2.Size = new System.Drawing.Size(21, 23);
            this.staStripTest2.Text = "...";
            this.staStripTest2.Click += new System.EventHandler(this.staStripTest2_Click);
            // 
            // staStripX2
            // 
            this.staStripX2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.staStripX2.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.staStripX2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.staStripX2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.staStripX2.Name = "staStripX2";
            this.staStripX2.Size = new System.Drawing.Size(17, 23);
            this.staStripX2.Text = " ";
            // 
            // staStripTime
            // 
            this.staStripTime.ForeColor = System.Drawing.Color.White;
            this.staStripTime.Name = "staStripTime";
            this.staStripTime.Size = new System.Drawing.Size(238, 23);
            this.staStripTime.Spring = true;
            this.staStripTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(17, 23);
            this.toolStripStatusLabel1.Text = " ";
            // 
            // staStripVersion
            // 
            this.staStripVersion.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.staStripVersion.ForeColor = System.Drawing.Color.White;
            this.staStripVersion.Name = "staStripVersion";
            this.staStripVersion.Size = new System.Drawing.Size(48, 23);
            this.staStripVersion.Text = "版本：";
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.picMainRIcon);
            this.pnlTitle.Controls.Add(this.picMainIcon);
            this.pnlTitle.Controls.Add(this.picNetwork);
            this.pnlTitle.Controls.Add(this.lblMainTitle);
            this.pnlTitle.Controls.Add(this.lblLoginUser);
            this.pnlTitle.Controls.Add(this.picLoginUser);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1024, 32);
            this.pnlTitle.TabIndex = 1;
            // 
            // picMainRIcon
            // 
            this.picMainRIcon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picMainRIcon.BackColor = System.Drawing.Color.Transparent;
            this.picMainRIcon.Image = global::ZCXJ_CS.Presentation.Properties.Resources.metasystem_logo;
            this.picMainRIcon.Location = new System.Drawing.Point(308, 0);
            this.picMainRIcon.Name = "picMainRIcon";
            this.picMainRIcon.Padding = new System.Windows.Forms.Padding(1);
            this.picMainRIcon.Size = new System.Drawing.Size(34, 31);
            this.picMainRIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMainRIcon.TabIndex = 5;
            this.picMainRIcon.TabStop = false;
            // 
            // picMainIcon
            // 
            this.picMainIcon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picMainIcon.BackColor = System.Drawing.Color.Transparent;
            this.picMainIcon.Image = global::ZCXJ_CS.Presentation.Properties.Resources.derun;
            this.picMainIcon.Location = new System.Drawing.Point(348, 0);
            this.picMainIcon.Name = "picMainIcon";
            this.picMainIcon.Size = new System.Drawing.Size(34, 34);
            this.picMainIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMainIcon.TabIndex = 4;
            this.picMainIcon.TabStop = false;
            this.picMainIcon.DoubleClick += new System.EventHandler(this.picMainIcon_DoubleClick);
            // 
            // picNetwork
            // 
            this.picNetwork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picNetwork.BackColor = System.Drawing.Color.Transparent;
            this.picNetwork.Location = new System.Drawing.Point(984, -1);
            this.picNetwork.Name = "picNetwork";
            this.picNetwork.Size = new System.Drawing.Size(32, 32);
            this.picNetwork.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picNetwork.TabIndex = 3;
            this.picNetwork.TabStop = false;
            this.toolTipInfo.SetToolTip(this.picNetwork, "现场PLC与MES服务器网络连接状态");
            this.picNetwork.Click += new System.EventHandler(this.picNetwork_Click);
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblMainTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMainTitle.ForeColor = System.Drawing.Color.White;
            this.lblMainTitle.Location = new System.Drawing.Point(388, 5);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(124, 19);
            this.lblMainTitle.TabIndex = 2;
            this.lblMainTitle.Text = "IA_MES CS端系统";
            this.lblMainTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMainTitle.DoubleClick += new System.EventHandler(this.lblMainTitle_DoubleClick);
            // 
            // lblLoginUser
            // 
            this.lblLoginUser.AutoSize = true;
            this.lblLoginUser.BackColor = System.Drawing.Color.Transparent;
            this.lblLoginUser.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLoginUser.ForeColor = System.Drawing.Color.White;
            this.lblLoginUser.Location = new System.Drawing.Point(37, 7);
            this.lblLoginUser.Name = "lblLoginUser";
            this.lblLoginUser.Size = new System.Drawing.Size(74, 19);
            this.lblLoginUser.TabIndex = 1;
            this.lblLoginUser.Text = "系统管理员";
            this.lblLoginUser.DoubleClick += new System.EventHandler(this.lblLoginUser_DoubleClick);
            // 
            // picLoginUser
            // 
            this.picLoginUser.BackColor = System.Drawing.Color.Transparent;
            this.picLoginUser.Location = new System.Drawing.Point(5, 2);
            this.picLoginUser.Name = "picLoginUser";
            this.picLoginUser.Size = new System.Drawing.Size(30, 27);
            this.picLoginUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLoginUser.TabIndex = 0;
            this.picLoginUser.TabStop = false;
            this.picLoginUser.DoubleClick += new System.EventHandler(this.picLoginUser_DoubleClick);
            // 
            // tabCtrlMain
            // 
            this.tabCtrlMain.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabCtrlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCtrlMain.Controls.Add(this.LogPage);
            this.tabCtrlMain.ItemSize = new System.Drawing.Size(1, 1);
            this.tabCtrlMain.Location = new System.Drawing.Point(-3, -4);
            this.tabCtrlMain.Margin = new System.Windows.Forms.Padding(0);
            this.tabCtrlMain.Name = "tabCtrlMain";
            this.tabCtrlMain.Padding = new System.Drawing.Point(0, 0);
            this.tabCtrlMain.SelectedIndex = 0;
            this.tabCtrlMain.Size = new System.Drawing.Size(1030, 651);
            this.tabCtrlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabCtrlMain.TabIndex = 2;
            this.tabCtrlMain.SizeChanged += new System.EventHandler(this.tabCtrlMain_SizeChanged);
            // 
            // LogPage
            // 
            this.LogPage.BackColor = System.Drawing.SystemColors.Control;
            this.LogPage.Controls.Add(this.logText);
            this.LogPage.Controls.Add(this.LogPictruce);
            this.LogPage.Location = new System.Drawing.Point(4, 4);
            this.LogPage.Margin = new System.Windows.Forms.Padding(1);
            this.LogPage.Name = "LogPage";
            this.LogPage.Padding = new System.Windows.Forms.Padding(1);
            this.LogPage.Size = new System.Drawing.Size(1022, 642);
            this.LogPage.TabIndex = 0;
            this.LogPage.Text = "tabPage1";
            // 
            // logText
            // 
            this.logText.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.logText.Font = new System.Drawing.Font("微软雅黑", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.logText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.logText.Location = new System.Drawing.Point(210, 444);
            this.logText.Name = "logText";
            this.logText.Size = new System.Drawing.Size(565, 147);
            this.logText.TabIndex = 1;
            this.logText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogPictruce
            // 
            this.LogPictruce.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LogPictruce.Location = new System.Drawing.Point(286, 39);
            this.LogPictruce.Name = "LogPictruce";
            this.LogPictruce.Size = new System.Drawing.Size(400, 400);
            this.LogPictruce.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.LogPictruce.TabIndex = 0;
            this.LogPictruce.TabStop = false;
            // 
            // timerMain
            // 
            this.timerMain.Enabled = true;
            this.timerMain.Interval = 1000;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // tabCtrlBottom
            // 
            this.tabCtrlBottom.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabCtrlBottom.Controls.Add(this.tabPageLog);
            this.tabCtrlBottom.Controls.Add(this.tabPageBarCode);
            this.tabCtrlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabCtrlBottom.ItemSize = new System.Drawing.Size(50, 23);
            this.tabCtrlBottom.Location = new System.Drawing.Point(0, 513);
            this.tabCtrlBottom.Multiline = true;
            this.tabCtrlBottom.Name = "tabCtrlBottom";
            this.tabCtrlBottom.SelectedIndex = 0;
            this.tabCtrlBottom.Size = new System.Drawing.Size(1024, 200);
            this.tabCtrlBottom.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabCtrlBottom.TabIndex = 3;
            // 
            // tabPageLog
            // 
            this.tabPageLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.tabPageLog.Controls.Add(this.rtbLog);
            this.tabPageLog.Location = new System.Drawing.Point(27, 4);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLog.Size = new System.Drawing.Size(993, 192);
            this.tabPageLog.TabIndex = 0;
            this.tabPageLog.Text = "日志";
            // 
            // rtbLog
            // 
            this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.ForeColor = System.Drawing.Color.Yellow;
            this.rtbLog.Location = new System.Drawing.Point(5, 6);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbLog.Size = new System.Drawing.Size(982, 180);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // tabPageBarCode
            // 
            this.tabPageBarCode.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageBarCode.Location = new System.Drawing.Point(27, 4);
            this.tabPageBarCode.Name = "tabPageBarCode";
            this.tabPageBarCode.Size = new System.Drawing.Size(993, 192);
            this.tabPageBarCode.TabIndex = 1;
            this.tabPageBarCode.Text = "条码";
            // 
            // MainSplit
            // 
            this.MainSplit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainSplit.BackColor = System.Drawing.Color.Transparent;
            this.MainSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.MainSplit.IsSplitterFixed = true;
            this.MainSplit.Location = new System.Drawing.Point(0, 32);
            this.MainSplit.Margin = new System.Windows.Forms.Padding(0);
            this.MainSplit.Name = "MainSplit";
            this.MainSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainSplit.Panel1
            // 
            this.MainSplit.Panel1.Controls.Add(this.tsMainTop);
            // 
            // MainSplit.Panel2
            // 
            this.MainSplit.Panel2.Controls.Add(this.tabCtrlMain);
            this.MainSplit.Size = new System.Drawing.Size(1026, 710);
            this.MainSplit.SplitterDistance = 70;
            this.MainSplit.SplitterWidth = 1;
            this.MainSplit.TabIndex = 5;
            this.MainSplit.TabStop = false;
            // 
            // tsMainTop
            // 
            this.tsMainTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsMainTop.Location = new System.Drawing.Point(0, 0);
            this.tsMainTop.Name = "tsMainTop";
            this.tsMainTop.Size = new System.Drawing.Size(1026, 70);
            this.tsMainTop.TabIndex = 5;
            this.tsMainTop.Text = "toolStrip2";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1024, 741);
            this.Controls.Add(this.tabCtrlBottom);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.staStripMain);
            this.Controls.Add(this.MainSplit);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1024, 726);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主框架窗口";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.staStripMain.ResumeLayout(false);
            this.staStripMain.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMainRIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMainIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNetwork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoginUser)).EndInit();
            this.tabCtrlMain.ResumeLayout(false);
            this.LogPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogPictruce)).EndInit();
            this.tabCtrlBottom.ResumeLayout(false);
            this.tabPageLog.ResumeLayout(false);
            this.MainSplit.Panel1.ResumeLayout(false);
            this.MainSplit.Panel1.PerformLayout();
            this.MainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).EndInit();
            this.MainSplit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip staStripMain;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.TabControl tabCtrlMain;
        private System.Windows.Forms.ToolStripStatusLabel staStripNote;
        private System.Windows.Forms.ToolStripStatusLabel staStripX1;
        private System.Windows.Forms.ToolStripStatusLabel staStripShowOutWnd;
        private System.Windows.Forms.ToolStripStatusLabel staStripX2;
        private System.Windows.Forms.ToolStripStatusLabel staStripTest2;
        private System.Windows.Forms.ToolStripStatusLabel staStripTime;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.TabControl tabCtrlBottom;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.TabPage tabPageBarCode;
        private System.Windows.Forms.PictureBox picLoginUser;
        private System.Windows.Forms.Label lblLoginUser;
        private System.Windows.Forms.PictureBox picNetwork;
        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.ToolStripStatusLabel staStripVersion;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.PictureBox picMainIcon;
        private System.Windows.Forms.SplitContainer MainSplit;
        private System.Windows.Forms.TabPage LogPage;
        private System.Windows.Forms.PictureBox LogPictruce;
        private System.Windows.Forms.Label logText;
        private System.Windows.Forms.ToolTip toolTipInfo;
        private System.Windows.Forms.PictureBox picMainRIcon;
        private System.Windows.Forms.ToolStrip tsMainTop;
    }
}


namespace ZCXJ_CS.UI
{
    partial class ItemWorkTicket
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemWorkTicket));
            this.label1 = new System.Windows.Forms.Label();
            this.btnRunOrPause = new System.Windows.Forms.Button();
            this.pgbWTProgress = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lblWorkTicketId = new System.Windows.Forms.Label();
            this.btnWTDetail = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProdId = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblWTPlanTime = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnComplete = new System.Windows.Forms.Button();
            this.lblWTStatus = new System.Windows.Forms.Label();
            this.lblCountWT = new System.Windows.Forms.Label();
            this.lblProdSpec = new System.Windows.Forms.Label();
            this.lblCountCompleted = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCountPassed = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.picWTStatus = new System.Windows.Forms.PictureBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.RightMaxPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnFrozen = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnHide = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.RightMinPanel = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.picWTStatus)).BeginInit();
            this.RightMaxPanel.SuspendLayout();
            this.RightMinPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(91, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "状态：";
            this.label1.Click += new System.EventHandler(this.LabelCtrl_Click);
            // 
            // btnRunOrPause
            // 
            this.btnRunOrPause.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunOrPause.BackColor = System.Drawing.Color.Peru;
            this.btnRunOrPause.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnRunOrPause.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.btnRunOrPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunOrPause.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRunOrPause.ForeColor = System.Drawing.Color.White;
            this.btnRunOrPause.Location = new System.Drawing.Point(10, 10);
            this.btnRunOrPause.Margin = new System.Windows.Forms.Padding(10);
            this.btnRunOrPause.Name = "btnRunOrPause";
            this.btnRunOrPause.Size = new System.Drawing.Size(81, 46);
            this.btnRunOrPause.TabIndex = 1;
            this.btnRunOrPause.Text = "运行";
            this.btnRunOrPause.UseVisualStyleBackColor = false;
            this.btnRunOrPause.Click += new System.EventHandler(this.CmdBtn_Click);
            // 
            // pgbWTProgress
            // 
            this.pgbWTProgress.Location = new System.Drawing.Point(356, 97);
            this.pgbWTProgress.Name = "pgbWTProgress";
            this.pgbWTProgress.Size = new System.Drawing.Size(231, 23);
            this.pgbWTProgress.Step = 1;
            this.pgbWTProgress.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(91, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "工单号：";
            this.label2.Click += new System.EventHandler(this.LabelCtrl_Click);
            // 
            // lblWorkTicketId
            // 
            this.lblWorkTicketId.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkTicketId.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWorkTicketId.ForeColor = System.Drawing.Color.Blue;
            this.lblWorkTicketId.Location = new System.Drawing.Point(148, 11);
            this.lblWorkTicketId.Name = "lblWorkTicketId";
            this.lblWorkTicketId.Size = new System.Drawing.Size(160, 22);
            this.lblWorkTicketId.TabIndex = 4;
            this.lblWorkTicketId.Text = "WT000001";
            this.lblWorkTicketId.Click += new System.EventHandler(this.LabelCtrl_Click);
            // 
            // btnWTDetail
            // 
            this.btnWTDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWTDetail.BackColor = System.Drawing.Color.Peru;
            this.btnWTDetail.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnWTDetail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.btnWTDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWTDetail.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWTDetail.ForeColor = System.Drawing.Color.White;
            this.btnWTDetail.Location = new System.Drawing.Point(10, 76);
            this.btnWTDetail.Margin = new System.Windows.Forms.Padding(10);
            this.btnWTDetail.Name = "btnWTDetail";
            this.btnWTDetail.Size = new System.Drawing.Size(81, 47);
            this.btnWTDetail.TabIndex = 5;
            this.btnWTDetail.Text = "明细";
            this.btnWTDetail.UseVisualStyleBackColor = false;
            this.btnWTDetail.Click += new System.EventHandler(this.CmdBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(306, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "制品编码：";
            this.label3.Click += new System.EventHandler(this.LabelCtrl_Click);
            // 
            // lblProdId
            // 
            this.lblProdId.BackColor = System.Drawing.Color.Transparent;
            this.lblProdId.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProdId.ForeColor = System.Drawing.Color.Blue;
            this.lblProdId.Location = new System.Drawing.Point(372, 10);
            this.lblProdId.Name = "lblProdId";
            this.lblProdId.Size = new System.Drawing.Size(206, 22);
            this.lblProdId.TabIndex = 7;
            this.lblProdId.Text = "TM00XXXXX (胎面)";
            this.lblProdId.Click += new System.EventHandler(this.LabelCtrl_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(91, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "计划时间：";
            this.label5.Click += new System.EventHandler(this.LabelCtrl_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(91, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "规格：";
            this.label6.Click += new System.EventHandler(this.LabelCtrl_Click);
            // 
            // lblWTPlanTime
            // 
            this.lblWTPlanTime.BackColor = System.Drawing.Color.Transparent;
            this.lblWTPlanTime.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWTPlanTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWTPlanTime.Location = new System.Drawing.Point(171, 38);
            this.lblWTPlanTime.Name = "lblWTPlanTime";
            this.lblWTPlanTime.Size = new System.Drawing.Size(294, 25);
            this.lblWTPlanTime.TabIndex = 10;
            this.lblWTPlanTime.Text = "08-13 08:00:00 ~ 08-13 16:00:00";
            this.lblWTPlanTime.Click += new System.EventHandler(this.LabelCtrl_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(302, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 19);
            this.label8.TabIndex = 11;
            this.label8.Text = "进度：";
            this.label8.Click += new System.EventHandler(this.LabelCtrl_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(466, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 19);
            this.label9.TabIndex = 12;
            this.label9.Text = "任务数:";
            this.label9.Click += new System.EventHandler(this.LabelCtrl_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnComplete.BackColor = System.Drawing.Color.Peru;
            this.btnComplete.Enabled = false;
            this.btnComplete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnComplete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.btnComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComplete.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnComplete.ForeColor = System.Drawing.Color.White;
            this.btnComplete.Location = new System.Drawing.Point(111, 10);
            this.btnComplete.Margin = new System.Windows.Forms.Padding(10);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(81, 46);
            this.btnComplete.TabIndex = 13;
            this.btnComplete.Text = "完成";
            this.btnComplete.UseVisualStyleBackColor = false;
            this.btnComplete.Click += new System.EventHandler(this.CmdBtn_Click);
            // 
            // lblWTStatus
            // 
            this.lblWTStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblWTStatus.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWTStatus.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblWTStatus.Location = new System.Drawing.Point(145, 94);
            this.lblWTStatus.Name = "lblWTStatus";
            this.lblWTStatus.Size = new System.Drawing.Size(119, 25);
            this.lblWTStatus.TabIndex = 14;
            this.lblWTStatus.Click += new System.EventHandler(this.LabelCtrl_Click);
            // 
            // lblCountWT
            // 
            this.lblCountWT.BackColor = System.Drawing.Color.Transparent;
            this.lblCountWT.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCountWT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCountWT.Location = new System.Drawing.Point(524, 38);
            this.lblCountWT.Name = "lblCountWT";
            this.lblCountWT.Size = new System.Drawing.Size(94, 25);
            this.lblCountWT.TabIndex = 15;
            this.lblCountWT.Text = "600";
            this.lblCountWT.Click += new System.EventHandler(this.LabelCtrl_Click);
            // 
            // lblProdSpec
            // 
            this.lblProdSpec.BackColor = System.Drawing.Color.Transparent;
            this.lblProdSpec.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProdSpec.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProdSpec.Location = new System.Drawing.Point(145, 68);
            this.lblProdSpec.Name = "lblProdSpec";
            this.lblProdSpec.Size = new System.Drawing.Size(147, 25);
            this.lblProdSpec.TabIndex = 16;
            this.lblProdSpec.Text = "TMG-X001-3";
            this.lblProdSpec.Click += new System.EventHandler(this.LabelCtrl_Click);
            // 
            // lblCountCompleted
            // 
            this.lblCountCompleted.BackColor = System.Drawing.Color.Transparent;
            this.lblCountCompleted.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCountCompleted.ForeColor = System.Drawing.Color.Blue;
            this.lblCountCompleted.Location = new System.Drawing.Point(360, 64);
            this.lblCountCompleted.Name = "lblCountCompleted";
            this.lblCountCompleted.Size = new System.Drawing.Size(78, 25);
            this.lblCountCompleted.TabIndex = 18;
            this.lblCountCompleted.Text = "0";
            this.lblCountCompleted.Click += new System.EventHandler(this.LabelCtrl_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(302, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 19);
            this.label12.TabIndex = 17;
            this.label12.Text = "完成数:";
            this.label12.Click += new System.EventHandler(this.LabelCtrl_Click);
            // 
            // lblCountPassed
            // 
            this.lblCountPassed.BackColor = System.Drawing.Color.Transparent;
            this.lblCountPassed.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCountPassed.ForeColor = System.Drawing.Color.Blue;
            this.lblCountPassed.Location = new System.Drawing.Point(524, 64);
            this.lblCountPassed.Name = "lblCountPassed";
            this.lblCountPassed.Size = new System.Drawing.Size(78, 25);
            this.lblCountPassed.TabIndex = 20;
            this.lblCountPassed.Text = "0";
            this.lblCountPassed.Click += new System.EventHandler(this.LabelCtrl_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(466, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 19);
            this.label14.TabIndex = 19;
            this.label14.Text = "合格数:";
            this.label14.Click += new System.EventHandler(this.LabelCtrl_Click);
            // 
            // picWTStatus
            // 
            this.picWTStatus.BackColor = System.Drawing.Color.Transparent;
            this.picWTStatus.Image = ((System.Drawing.Image)(resources.GetObject("picWTStatus.Image")));
            this.picWTStatus.Location = new System.Drawing.Point(20, 14);
            this.picWTStatus.Name = "picWTStatus";
            this.picWTStatus.Size = new System.Drawing.Size(48, 48);
            this.picWTStatus.TabIndex = 21;
            this.picWTStatus.TabStop = false;
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.BackColor = System.Drawing.Color.Peru;
            this.btnReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Location = new System.Drawing.Point(111, 76);
            this.btnReport.Margin = new System.Windows.Forms.Padding(10);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(81, 47);
            this.btnReport.TabIndex = 22;
            this.btnReport.Text = "报产";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.CmdBtn_Click);
            // 
            // timer
            // 
            this.timer.Interval = 5000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // RightMaxPanel
            // 
            this.RightMaxPanel.BackColor = System.Drawing.Color.LightGray;
            this.RightMaxPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RightMaxPanel.ColumnCount = 4;
            this.RightMaxPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.RightMaxPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.RightMaxPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.RightMaxPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.RightMaxPanel.Controls.Add(this.btnRunOrPause, 0, 0);
            this.RightMaxPanel.Controls.Add(this.btnComplete, 1, 0);
            this.RightMaxPanel.Controls.Add(this.btnReport, 1, 1);
            this.RightMaxPanel.Controls.Add(this.btnFrozen, 2, 0);
            this.RightMaxPanel.Controls.Add(this.btnWTDetail, 0, 1);
            this.RightMaxPanel.Controls.Add(this.btnCancel, 3, 1);
            this.RightMaxPanel.Controls.Add(this.btnHide, 3, 0);
            this.RightMaxPanel.Controls.Add(this.btnStop, 2, 1);
            this.RightMaxPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightMaxPanel.Location = new System.Drawing.Point(410, 0);
            this.RightMaxPanel.Name = "RightMaxPanel";
            this.RightMaxPanel.RowCount = 2;
            this.RightMaxPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RightMaxPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RightMaxPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RightMaxPanel.Size = new System.Drawing.Size(407, 133);
            this.RightMaxPanel.TabIndex = 23;
            this.RightMaxPanel.Visible = false;
            this.RightMaxPanel.Click += new System.EventHandler(this.LabelCtrl_Click);
            // 
            // btnFrozen
            // 
            this.btnFrozen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFrozen.BackColor = System.Drawing.Color.Peru;
            this.btnFrozen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnFrozen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.btnFrozen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFrozen.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFrozen.ForeColor = System.Drawing.Color.White;
            this.btnFrozen.Location = new System.Drawing.Point(212, 10);
            this.btnFrozen.Margin = new System.Windows.Forms.Padding(10);
            this.btnFrozen.Name = "btnFrozen";
            this.btnFrozen.Size = new System.Drawing.Size(81, 46);
            this.btnFrozen.TabIndex = 23;
            this.btnFrozen.Text = "中止";
            this.btnFrozen.UseVisualStyleBackColor = false;
            this.btnFrozen.Click += new System.EventHandler(this.CmdBtn_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Peru;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(313, 76);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 47);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.CmdBtn_Click);
            // 
            // btnHide
            // 
            this.btnHide.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHide.BackColor = System.Drawing.Color.Peru;
            this.btnHide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnHide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.btnHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHide.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHide.ForeColor = System.Drawing.Color.White;
            this.btnHide.Location = new System.Drawing.Point(313, 10);
            this.btnHide.Margin = new System.Windows.Forms.Padding(10);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(84, 46);
            this.btnHide.TabIndex = 25;
            this.btnHide.Text = "收起>>";
            this.btnHide.UseVisualStyleBackColor = false;
            this.btnHide.Click += new System.EventHandler(this.CmdBtn_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.BackColor = System.Drawing.Color.Peru;
            this.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(212, 76);
            this.btnStop.Margin = new System.Windows.Forms.Padding(10);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(81, 47);
            this.btnStop.TabIndex = 26;
            this.btnStop.Text = "终止";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.CmdBtn_Click);
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.BackColor = System.Drawing.Color.Transparent;
            this.btnShow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btnShow.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShow.Location = new System.Drawing.Point(10, 10);
            this.btnShow.Margin = new System.Windows.Forms.Padding(10);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(87, 46);
            this.btnShow.TabIndex = 25;
            this.btnShow.Text = "<<展开";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.CmdBtn_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetails.BackColor = System.Drawing.Color.Transparent;
            this.btnDetails.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btnDetails.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.btnDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetails.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDetails.Location = new System.Drawing.Point(10, 76);
            this.btnDetails.Margin = new System.Windows.Forms.Padding(10);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(87, 47);
            this.btnDetails.TabIndex = 27;
            this.btnDetails.Text = "施工表";
            this.btnDetails.UseVisualStyleBackColor = false;
            this.btnDetails.Click += new System.EventHandler(this.CmdBtn_Click);
            // 
            // RightMinPanel
            // 
            this.RightMinPanel.ColumnCount = 1;
            this.RightMinPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RightMinPanel.Controls.Add(this.btnShow, 0, 0);
            this.RightMinPanel.Controls.Add(this.btnDetails, 0, 1);
            this.RightMinPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightMinPanel.Location = new System.Drawing.Point(303, 0);
            this.RightMinPanel.Name = "RightMinPanel";
            this.RightMinPanel.RowCount = 2;
            this.RightMinPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RightMinPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RightMinPanel.Size = new System.Drawing.Size(107, 133);
            this.RightMinPanel.TabIndex = 28;
            this.RightMinPanel.Click += new System.EventHandler(this.LabelCtrl_Click);
            // 
            // ItemWorkTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightGray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.RightMinPanel);
            this.Controls.Add(this.RightMaxPanel);
            this.Controls.Add(this.lblWorkTicketId);
            this.Controls.Add(this.picWTStatus);
            this.Controls.Add(this.lblCountPassed);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblCountCompleted);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblProdSpec);
            this.Controls.Add(this.lblCountWT);
            this.Controls.Add(this.lblWTStatus);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblWTPlanTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblProdId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pgbWTProgress);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "ItemWorkTicket";
            this.Size = new System.Drawing.Size(817, 133);
            this.Load += new System.EventHandler(this.ItemWorkTicket_Load);
            this.Click += new System.EventHandler(this.ItemWorkTicket_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picWTStatus)).EndInit();
            this.RightMaxPanel.ResumeLayout(false);
            this.RightMinPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRunOrPause;
        private System.Windows.Forms.ProgressBar pgbWTProgress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblWorkTicketId;
        private System.Windows.Forms.Button btnWTDetail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblProdId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblWTPlanTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Label lblWTStatus;
        private System.Windows.Forms.Label lblCountWT;
        private System.Windows.Forms.Label lblProdSpec;
        private System.Windows.Forms.Label lblCountCompleted;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblCountPassed;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox picWTStatus;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TableLayoutPanel RightMaxPanel;
        private System.Windows.Forms.Button btnFrozen;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.TableLayoutPanel RightMinPanel;
    }
}

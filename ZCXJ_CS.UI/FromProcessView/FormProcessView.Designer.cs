  
namespace ZCXJ_CS.UI
{
    partial class FormProcessView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProcessView));
            this.timerPrint = new System.Windows.Forms.Timer(this.components);
            this.pnlAll = new MetroFramework.Controls.MetroPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gsProcess = new GraphScenario.GraphScenario();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panelWarning = new MetroFramework.Controls.MetroPanel();
            this.metroGroupBox1 = new MetroFramework.Controls.MetroGroupBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblENO = new System.Windows.Forms.Label();
            this.lblProcessName = new System.Windows.Forms.Label();
            this.lblProcessNO = new System.Windows.Forms.Label();
            this.lblSN = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.pnlTop = new MetroFramework.Controls.MetroGroupBox();
            this.pnlbtnProc = new MetroFramework.Controls.MetroPanel();
            this.pnlbtnReset = new MetroFramework.Controls.MetroPanel();
            this.btnPlcReset = new MetroFramework.Controls.MetroButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblHandle = new System.Windows.Forms.Label();
            this.btnPass = new MetroFramework.Controls.MetroButton();
            this.btnFail = new MetroFramework.Controls.MetroButton();
            this.lblContent = new System.Windows.Forms.Label();
            this.pnlLeftTitle = new MetroFramework.Controls.MetroTile();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.pnlAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.metroGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlbtnProc.SuspendLayout();
            this.pnlbtnReset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timerPrint
            // 
            this.timerPrint.Enabled = true;
            this.timerPrint.Interval = 1000;
            this.timerPrint.Tick += new System.EventHandler(this.timerPrint_Tick);
            // 
            // pnlAll
            // 
            this.pnlAll.Controls.Add(this.splitContainer1);
            this.pnlAll.Controls.Add(this.pnlTop);
            this.pnlAll.Controls.Add(this.pnlLeftTitle);
            this.pnlAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAll.HorizontalScrollbarBarColor = true;
            this.pnlAll.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlAll.HorizontalScrollbarSize = 10;
            this.pnlAll.Location = new System.Drawing.Point(0, 0);
            this.pnlAll.Name = "pnlAll";
            this.pnlAll.Size = new System.Drawing.Size(1135, 506);
            this.pnlAll.TabIndex = 0;
            this.pnlAll.VerticalScrollbarBarColor = true;
            this.pnlAll.VerticalScrollbarHighlightOnWheel = false;
            this.pnlAll.VerticalScrollbarSize = 10;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 109);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gsProcess);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1135, 397);
            this.splitContainer1.SplitterDistance = 211;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 3;
            // 
            // gsProcess
            // 
            this.gsProcess.AllowDrop = true;
            this.gsProcess.AutoScroll = true;
            this.gsProcess.AutoScrollMinSize = new System.Drawing.Size(1135, 211);
            this.gsProcess.AutoSize = true;
            this.gsProcess.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gsProcess.CustomBackground = false;
            this.gsProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gsProcess.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gsProcess.GridSpace = 120;
            this.gsProcess.HorizontalScrollbar = true;
            this.gsProcess.HorizontalScrollbarBarColor = false;
            this.gsProcess.HorizontalScrollbarHighlightOnWheel = false;
            this.gsProcess.HorizontalScrollbarSize = 10;
            this.gsProcess.ImeMode = System.Windows.Forms.ImeMode.On;
            this.gsProcess.Location = new System.Drawing.Point(0, 0);
            this.gsProcess.Name = "gsProcess";
            this.gsProcess.Offset = new System.Drawing.Point(0, 0);
            this.gsProcess.ReadOnly = true;
            this.gsProcess.Size = new System.Drawing.Size(1135, 211);
            this.gsProcess.TabIndex = 0;
            this.gsProcess.VerticalScrollbar = true;
            this.gsProcess.VerticalScrollbarBarColor = false;
            this.gsProcess.VerticalScrollbarHighlightOnWheel = false;
            this.gsProcess.VerticalScrollbarSize = 10;
            this.gsProcess.NodeSelected += new GraphScenario.GraphScenario.SelectedEventHandler(this.gsProcess_NodeSelected);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Panel1.Controls.Add(this.panelWarning);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.metroGroupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(1135, 185);
            this.splitContainer2.SplitterDistance = 360;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // panelWarning
            // 
            this.panelWarning.BackColor = System.Drawing.Color.Transparent;
            this.panelWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWarning.HorizontalScrollbarBarColor = true;
            this.panelWarning.HorizontalScrollbarHighlightOnWheel = false;
            this.panelWarning.HorizontalScrollbarSize = 10;
            this.panelWarning.Location = new System.Drawing.Point(0, 0);
            this.panelWarning.Name = "panelWarning";
            this.panelWarning.Size = new System.Drawing.Size(360, 185);
            this.panelWarning.TabIndex = 1;
            this.panelWarning.VerticalScrollbarBarColor = true;
            this.panelWarning.VerticalScrollbarHighlightOnWheel = false;
            this.panelWarning.VerticalScrollbarSize = 10;
            // 
            // metroGroupBox1
            // 
            this.metroGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGroupBox1.BorderStyle = MetroFramework.Controls.MetroGroupBox.BorderMode.Full;
            this.metroGroupBox1.Controls.Add(this.lblTime);
            this.metroGroupBox1.Controls.Add(this.lblENO);
            this.metroGroupBox1.Controls.Add(this.lblProcessName);
            this.metroGroupBox1.Controls.Add(this.lblProcessNO);
            this.metroGroupBox1.Controls.Add(this.lblSN);
            this.metroGroupBox1.Controls.Add(this.lblID);
            this.metroGroupBox1.Controls.Add(this.label8);
            this.metroGroupBox1.Controls.Add(this.label6);
            this.metroGroupBox1.Controls.Add(this.label5);
            this.metroGroupBox1.Controls.Add(this.label4);
            this.metroGroupBox1.Controls.Add(this.label3);
            this.metroGroupBox1.Controls.Add(this.label2);
            this.metroGroupBox1.Controls.Add(this.picStatus);
            this.metroGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroGroupBox1.DrawBottomLine = false;
            this.metroGroupBox1.DrawShadows = false;
            this.metroGroupBox1.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGroupBox1.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroGroupBox1.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.metroGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.metroGroupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.metroGroupBox1.Name = "metroGroupBox1";
            this.metroGroupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.metroGroupBox1.PaintDefault = false;
            this.metroGroupBox1.Size = new System.Drawing.Size(774, 185);
            this.metroGroupBox1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroGroupBox1.StyleManager = null;
            this.metroGroupBox1.TabIndex = 0;
            this.metroGroupBox1.TabStop = false;
            this.metroGroupBox1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroGroupBox1.UseStyleColors = false;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lblTime.Location = new System.Drawing.Point(157, 149);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 17);
            this.lblTime.TabIndex = 25;
            // 
            // lblENO
            // 
            this.lblENO.AutoSize = true;
            this.lblENO.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblENO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lblENO.Location = new System.Drawing.Point(157, 125);
            this.lblENO.Name = "lblENO";
            this.lblENO.Size = new System.Drawing.Size(0, 17);
            this.lblENO.TabIndex = 24;
            // 
            // lblProcessName
            // 
            this.lblProcessName.AutoSize = true;
            this.lblProcessName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lblProcessName.Location = new System.Drawing.Point(157, 101);
            this.lblProcessName.Name = "lblProcessName";
            this.lblProcessName.Size = new System.Drawing.Size(0, 17);
            this.lblProcessName.TabIndex = 23;
            // 
            // lblProcessNO
            // 
            this.lblProcessNO.AutoSize = true;
            this.lblProcessNO.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessNO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lblProcessNO.Location = new System.Drawing.Point(157, 77);
            this.lblProcessNO.Name = "lblProcessNO";
            this.lblProcessNO.Size = new System.Drawing.Size(0, 17);
            this.lblProcessNO.TabIndex = 22;
            // 
            // lblSN
            // 
            this.lblSN.AutoSize = true;
            this.lblSN.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lblSN.Location = new System.Drawing.Point(157, 53);
            this.lblSN.Name = "lblSN";
            this.lblSN.Size = new System.Drawing.Size(0, 17);
            this.lblSN.TabIndex = 21;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lblID.Location = new System.Drawing.Point(157, 29);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 17);
            this.lblID.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.label8.Location = new System.Drawing.Point(80, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Action time :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.label6.Location = new System.Drawing.Point(59, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Equipment NO :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.label5.Location = new System.Drawing.Point(61, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Process Name :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.label4.Location = new System.Drawing.Point(76, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Process NO :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.label3.Location = new System.Drawing.Point(61, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Serial Number :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.label2.Location = new System.Drawing.Point(132, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "ID :";
            // 
            // picStatus
            // 
            this.picStatus.Image = ((System.Drawing.Image)(resources.GetObject("picStatus.Image")));
            this.picStatus.Location = new System.Drawing.Point(8, 20);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(57, 57);
            this.picStatus.TabIndex = 13;
            this.picStatus.TabStop = false;
            this.picStatus.DoubleClick += new System.EventHandler(this.test_DoubleClick);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTop.BorderStyle = MetroFramework.Controls.MetroGroupBox.BorderMode.Header;
            this.pnlTop.Controls.Add(this.pnlbtnProc);
            this.pnlTop.Controls.Add(this.lblContent);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.DrawBottomLine = true;
            this.pnlTop.DrawShadows = false;
            this.pnlTop.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.pnlTop.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.pnlTop.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.pnlTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlTop.Location = new System.Drawing.Point(0, 31);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.PaintDefault = false;
            this.pnlTop.Size = new System.Drawing.Size(1135, 78);
            this.pnlTop.Style = MetroFramework.MetroColorStyle.Blue;
            this.pnlTop.StyleManager = null;
            this.pnlTop.TabIndex = 2;
            this.pnlTop.TabStop = false;
            this.pnlTop.Theme = MetroFramework.MetroThemeStyle.Light;
            this.pnlTop.UseStyleColors = false;
            // 
            // pnlbtnProc
            // 
            this.pnlbtnProc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlbtnProc.BackColor = System.Drawing.Color.Transparent;
            this.pnlbtnProc.Controls.Add(this.pnlbtnReset);
            this.pnlbtnProc.Controls.Add(this.pictureBox2);
            this.pnlbtnProc.Controls.Add(this.pictureBox1);
            this.pnlbtnProc.Controls.Add(this.lblHandle);
            this.pnlbtnProc.Controls.Add(this.btnPass);
            this.pnlbtnProc.Controls.Add(this.btnFail);
            this.pnlbtnProc.HorizontalScrollbarBarColor = true;
            this.pnlbtnProc.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlbtnProc.HorizontalScrollbarSize = 10;
            this.pnlbtnProc.Location = new System.Drawing.Point(625, 3);
            this.pnlbtnProc.Name = "pnlbtnProc";
            this.pnlbtnProc.Size = new System.Drawing.Size(507, 72);
            this.pnlbtnProc.TabIndex = 8;
            this.pnlbtnProc.VerticalScrollbarBarColor = true;
            this.pnlbtnProc.VerticalScrollbarHighlightOnWheel = false;
            this.pnlbtnProc.VerticalScrollbarSize = 10;
            // 
            // pnlbtnReset
            // 
            this.pnlbtnReset.BackColor = System.Drawing.Color.Transparent;
            this.pnlbtnReset.Controls.Add(this.btnPlcReset);
            this.pnlbtnReset.HorizontalScrollbarBarColor = true;
            this.pnlbtnReset.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlbtnReset.HorizontalScrollbarSize = 10;
            this.pnlbtnReset.Location = new System.Drawing.Point(374, 0);
            this.pnlbtnReset.Name = "pnlbtnReset";
            this.pnlbtnReset.Size = new System.Drawing.Size(133, 72);
            this.pnlbtnReset.TabIndex = 9;
            this.pnlbtnReset.VerticalScrollbarBarColor = true;
            this.pnlbtnReset.VerticalScrollbarHighlightOnWheel = false;
            this.pnlbtnReset.VerticalScrollbarSize = 10;
            this.pnlbtnReset.Visible = false;
            // 
            // btnPlcReset
            // 
            this.btnPlcReset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlcReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btnPlcReset.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnPlcReset.ForeColor = System.Drawing.Color.White;
            this.btnPlcReset.Location = new System.Drawing.Point(15, 5);
            this.btnPlcReset.Name = "btnPlcReset";
            this.btnPlcReset.Size = new System.Drawing.Size(110, 64);
            this.btnPlcReset.TabIndex = 7;
            this.btnPlcReset.Text = "PLC 复位";
            this.btnPlcReset.UseSelectable = true;
            this.btnPlcReset.UseStyleColors = true;
            this.btnPlcReset.Click += new System.EventHandler(this.btnPlcReset_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(135, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(66, 72);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(316, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // lblHandle
            // 
            this.lblHandle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHandle.AutoSize = true;
            this.lblHandle.BackColor = System.Drawing.Color.Transparent;
            this.lblHandle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHandle.Location = new System.Drawing.Point(204, 14);
            this.lblHandle.Name = "lblHandle";
            this.lblHandle.Size = new System.Drawing.Size(110, 31);
            this.lblHandle.TabIndex = 9;
            this.lblHandle.Text = "制程检验";
            // 
            // btnPass
            // 
            this.btnPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(179)))), ((int)(((byte)(0)))));
            this.btnPass.Enabled = false;
            this.btnPass.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnPass.ForeColor = System.Drawing.Color.White;
            this.btnPass.Location = new System.Drawing.Point(19, 5);
            this.btnPass.Name = "btnPass";
            this.btnPass.Size = new System.Drawing.Size(110, 64);
            this.btnPass.TabIndex = 8;
            this.btnPass.Text = "P A S S";
            this.btnPass.UseCustomBackColor = true;
            this.btnPass.UseCustomForeColor = true;
            this.btnPass.UseSelectable = true;
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
            // 
            // btnFail
            // 
            this.btnFail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnFail.Enabled = false;
            this.btnFail.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnFail.ForeColor = System.Drawing.Color.White;
            this.btnFail.Location = new System.Drawing.Point(388, 5);
            this.btnFail.Name = "btnFail";
            this.btnFail.Size = new System.Drawing.Size(110, 64);
            this.btnFail.TabIndex = 7;
            this.btnFail.Text = "F A I L";
            this.btnFail.UseCustomBackColor = true;
            this.btnFail.UseCustomForeColor = true;
            this.btnFail.UseSelectable = true;
            this.btnFail.UseStyleColors = true;
            this.btnFail.Click += new System.EventHandler(this.btnFail_Click);
            // 
            // lblContent
            // 
            this.lblContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContent.BackColor = System.Drawing.Color.Transparent;
            this.lblContent.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lblContent.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblContent.Location = new System.Drawing.Point(3, 3);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(616, 72);
            this.lblContent.TabIndex = 1;
            this.lblContent.Text = "DFM18030300001V4.1.08V4.5.00000130180312";
            this.lblContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlLeftTitle
            // 
            this.pnlLeftTitle.ActiveControl = null;
            this.pnlLeftTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.pnlLeftTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLeftTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftTitle.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlLeftTitle.Name = "pnlLeftTitle";
            this.pnlLeftTitle.Size = new System.Drawing.Size(1135, 31);
            this.pnlLeftTitle.TabIndex = 1;
            this.pnlLeftTitle.Text = "OP130-2 制程工序";
            this.pnlLeftTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pnlLeftTitle.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.pnlLeftTitle.UseSelectable = true;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(0, 0);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.TabIndex = 0;
            this.metroButton1.UseSelectable = true;
            // 
            // FormProcessView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 506);
            this.Controls.Add(this.pnlAll);
            this.Name = "FormProcessView";
            this.Text = "";
            this.Load += new System.EventHandler(this.FormPrint_Load);
            this.pnlAll.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.metroGroupBox1.ResumeLayout(false);
            this.metroGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlbtnProc.ResumeLayout(false);
            this.pnlbtnProc.PerformLayout();
            this.pnlbtnReset.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel pnlAll;
        private MetroFramework.Controls.MetroTile pnlLeftTitle;
        private MetroFramework.Controls.MetroGroupBox pnlTop;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Timer timerPrint;
        private GraphScenario.GraphScenario gsProcess;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private MetroFramework.Controls.MetroPanel panelWarning;
        private MetroFramework.Controls.MetroPanel pnlbtnProc;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblHandle;
        private MetroFramework.Controls.MetroButton btnPass;
        private MetroFramework.Controls.MetroButton btnFail;
        private MetroFramework.Controls.MetroButton btnPlcReset;
        private MetroFramework.Controls.MetroPanel pnlbtnReset;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroGroupBox metroGroupBox1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblENO;
        private System.Windows.Forms.Label lblProcessName;
        private System.Windows.Forms.Label lblProcessNO;
        private System.Windows.Forms.Label lblSN;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picStatus;
    }
}
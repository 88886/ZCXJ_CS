

namespace ZCXJ_CS.UI
{
    partial class FormPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrint));
            this.PnlAll = new MetroFramework.Controls.MetroPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.panelWarning = new MetroFramework.Controls.MetroPanel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new MetroFramework.Controls.MetroGroupBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.lblPlcSN = new MetroFramework.Controls.MetroTextBox();
            this.lblMesSN = new MetroFramework.Controls.MetroTextBox();
            this.groupBox3 = new MetroFramework.Controls.MetroGroupBox();
            this.picBoxV = new System.Windows.Forms.PictureBox();
            this.lblPrintLog = new MetroFramework.Controls.MetroTextBox();
            this.panel1 = new MetroFramework.Controls.MetroPanel();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.timerPrint = new System.Windows.Forms.Timer(this.components);
            this.PnlAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxV)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlAll
            // 
            this.PnlAll.BackColor = System.Drawing.Color.Transparent;
            this.PnlAll.Controls.Add(this.splitContainer1);
            this.PnlAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlAll.HorizontalScrollbarBarColor = true;
            this.PnlAll.HorizontalScrollbarHighlightOnWheel = false;
            this.PnlAll.HorizontalScrollbarSize = 10;
            this.PnlAll.Location = new System.Drawing.Point(0, 0);
            this.PnlAll.Name = "PnlAll";
            this.PnlAll.Size = new System.Drawing.Size(1135, 506);
            this.PnlAll.TabIndex = 0;
            this.PnlAll.VerticalScrollbarBarColor = true;
            this.PnlAll.VerticalScrollbarHighlightOnWheel = false;
            this.PnlAll.VerticalScrollbarSize = 10;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.metroTile1);
            this.splitContainer1.Panel1.Controls.Add(this.panelWarning);
            this.splitContainer1.Panel1MinSize = 450;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2MinSize = 450;
            this.splitContainer1.Size = new System.Drawing.Size(1135, 506);
            this.splitContainer1.SplitterDistance = 450;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroTile1.Location = new System.Drawing.Point(0, 0);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(450, 31);
            this.metroTile1.TabIndex = 2;
            this.metroTile1.Text = "OP010-1 清洗工序";
            this.metroTile1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroTile1.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile1.UseSelectable = true;
            // 
            // panelWarning
            // 
            this.panelWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelWarning.HorizontalScrollbarBarColor = true;
            this.panelWarning.HorizontalScrollbarHighlightOnWheel = false;
            this.panelWarning.HorizontalScrollbarSize = 10;
            this.panelWarning.Location = new System.Drawing.Point(0, 31);
            this.panelWarning.Name = "panelWarning";
            this.panelWarning.Size = new System.Drawing.Size(450, 475);
            this.panelWarning.TabIndex = 1;
            this.panelWarning.VerticalScrollbar = true;
            this.panelWarning.VerticalScrollbarBarColor = true;
            this.panelWarning.VerticalScrollbarHighlightOnWheel = false;
            this.panelWarning.VerticalScrollbarSize = 10;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 31);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel1MinSize = 110;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lblPrintLog);
            this.splitContainer2.Panel2MinSize = 90;
            this.splitContainer2.Size = new System.Drawing.Size(684, 475);
            this.splitContainer2.SplitterDistance = 110;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.BorderStyle = MetroFramework.Controls.MetroGroupBox.BorderMode.FullCustom;
            this.groupBox1.Controls.Add(this.metroLabel2);
            this.groupBox1.Controls.Add(this.metroLabel1);
            this.groupBox1.Controls.Add(this.lblPlcSN);
            this.groupBox1.Controls.Add(this.lblMesSN);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.DrawBottomLine = false;
            this.groupBox1.DrawShadows = false;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox1.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.groupBox1.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.PaintDefault = false;
            this.groupBox1.Size = new System.Drawing.Size(684, 110);
            this.groupBox1.Style = MetroFramework.MetroColorStyle.Blue;
            this.groupBox1.StyleManager = null;
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.groupBox1.UseStyleColors = false;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(9, 63);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(96, 19);
            this.metroLabel2.TabIndex = 13;
            this.metroLabel2.Text = "PLC扫描条码 :";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(6, 16);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(99, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "MES推送条码 :";
            // 
            // lblPlcSN
            // 
            this.lblPlcSN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlcSN.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.lblPlcSN.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.lblPlcSN.ForeColor = System.Drawing.Color.Crimson;
            this.lblPlcSN.Lines = new string[] {
        "DFM18030300001V4.1.08V4.5.00000130180312"};
            this.lblPlcSN.Location = new System.Drawing.Point(105, 61);
            this.lblPlcSN.MaxLength = 32767;
            this.lblPlcSN.Multiline = true;
            this.lblPlcSN.Name = "lblPlcSN";
            this.lblPlcSN.PasswordChar = '\0';
            this.lblPlcSN.ReadOnly = true;
            this.lblPlcSN.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.lblPlcSN.SelectedText = "";
            this.lblPlcSN.Size = new System.Drawing.Size(435, 35);
            this.lblPlcSN.TabIndex = 12;
            this.lblPlcSN.Text = "DFM18030300001V4.1.08V4.5.00000130180312";
            this.lblPlcSN.UseCustomForeColor = true;
            this.lblPlcSN.UseSelectable = true;
            // 
            // lblMesSN
            // 
            this.lblMesSN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMesSN.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.lblMesSN.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.lblMesSN.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblMesSN.Lines = new string[] {
        "DFM18030300001V4.1.08V4.5.00000130180312"};
            this.lblMesSN.Location = new System.Drawing.Point(105, 14);
            this.lblMesSN.MaxLength = 32767;
            this.lblMesSN.Multiline = true;
            this.lblMesSN.Name = "lblMesSN";
            this.lblMesSN.PasswordChar = '\0';
            this.lblMesSN.ReadOnly = true;
            this.lblMesSN.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.lblMesSN.SelectedText = "";
            this.lblMesSN.Size = new System.Drawing.Size(435, 35);
            this.lblMesSN.TabIndex = 11;
            this.lblMesSN.Text = "DFM18030300001V4.1.08V4.5.00000130180312";
            this.lblMesSN.UseCustomForeColor = true;
            this.lblMesSN.UseSelectable = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox3.BorderStyle = MetroFramework.Controls.MetroGroupBox.BorderMode.FullCustom;
            this.groupBox3.Controls.Add(this.picBoxV);
            this.groupBox3.DrawBottomLine = false;
            this.groupBox3.DrawShadows = false;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox3.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.groupBox3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox3.Location = new System.Drawing.Point(546, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.PaintDefault = false;
            this.groupBox3.Size = new System.Drawing.Size(134, 101);
            this.groupBox3.Style = MetroFramework.MetroColorStyle.Blue;
            this.groupBox3.StyleManager = null;
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "校验结果";
            this.groupBox3.Theme = MetroFramework.MetroThemeStyle.Light;
            this.groupBox3.UseStyleColors = false;
            // 
            // picBoxV
            // 
            this.picBoxV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxV.Image = ((System.Drawing.Image)(resources.GetObject("picBoxV.Image")));
            this.picBoxV.Location = new System.Drawing.Point(3, 22);
            this.picBoxV.Name = "picBoxV";
            this.picBoxV.Size = new System.Drawing.Size(128, 76);
            this.picBoxV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBoxV.TabIndex = 0;
            this.picBoxV.TabStop = false;
            // 
            // lblPrintLog
            // 
            this.lblPrintLog.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPrintLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrintLog.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.lblPrintLog.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.lblPrintLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(90)))));
            this.lblPrintLog.Lines = new string[0];
            this.lblPrintLog.Location = new System.Drawing.Point(0, 0);
            this.lblPrintLog.MaxLength = 32767;
            this.lblPrintLog.Multiline = true;
            this.lblPrintLog.Name = "lblPrintLog";
            this.lblPrintLog.PasswordChar = '\0';
            this.lblPrintLog.ReadOnly = true;
            this.lblPrintLog.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.lblPrintLog.SelectedText = "";
            this.lblPrintLog.Size = new System.Drawing.Size(684, 364);
            this.lblPrintLog.TabIndex = 1;
            this.lblPrintLog.UseCustomForeColor = true;
            this.lblPrintLog.UseSelectable = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Controls.Add(this.metroTile2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.HorizontalScrollbarBarColor = true;
            this.panel1.HorizontalScrollbarHighlightOnWheel = false;
            this.panel1.HorizontalScrollbarSize = 10;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 31);
            this.panel1.TabIndex = 1;
            this.panel1.VerticalScrollbarBarColor = true;
            this.panel1.VerticalScrollbarHighlightOnWheel = false;
            this.panel1.VerticalScrollbarSize = 10;
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroTile2.Location = new System.Drawing.Point(0, 0);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(684, 31);
            this.metroTile2.TabIndex = 4;
            this.metroTile2.Text = "条码校验";
            this.metroTile2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroTile2.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile2.UseSelectable = true;
            // 
            // timerPrint
            // 
            this.timerPrint.Enabled = true;
            this.timerPrint.Interval = 1000;
            this.timerPrint.Tick += new System.EventHandler(this.timerPrint_Tick);
            // 
            // FormPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 506);
            this.Controls.Add(this.PnlAll);
            this.Name = "FormPrint";
            this.Text = "FormPrint";
            this.Load += new System.EventHandler(this.FormPrint_Load);
            this.PnlAll.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private MetroFramework.Controls.MetroGroupBox groupBox1;
        private MetroFramework.Controls.MetroTextBox lblPlcSN;
        private MetroFramework.Controls.MetroTextBox lblMesSN;
        private MetroFramework.Controls.MetroGroupBox groupBox3;
        private System.Windows.Forms.PictureBox picBoxV;
        private System.Windows.Forms.Timer timerPrint;
        private MetroFramework.Controls.MetroTextBox lblPrintLog;
        private MetroFramework.Controls.MetroPanel panelWarning;
        private MetroFramework.Controls.MetroPanel PnlAll;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroPanel panel1;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
    }
}
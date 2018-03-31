namespace ZCXJ_CS.UI
{
    partial class FormProdMonitor
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
            this.yGraphWT = new Yangyalin.YGraph();
            this.panelCurWT = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // yGraphWT
            // 
            this.yGraphWT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yGraphWT.BackColor = System.Drawing.SystemColors.Control;
            this.yGraphWT.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yGraphWT.ForeColor = System.Drawing.Color.Black;
            this.yGraphWT.Location = new System.Drawing.Point(0, 142);
            this.yGraphWT.m_BigXYBackColor = System.Drawing.SystemColors.Control;
            this.yGraphWT.m_BigXYButtonBackColor = System.Drawing.Color.LightGreen;
            this.yGraphWT.m_BigXYButtonForeColor = System.Drawing.Color.Black;
            this.yGraphWT.Margin = new System.Windows.Forms.Padding(0);
            this.yGraphWT.MinimumSize = new System.Drawing.Size(520, 428);
            this.yGraphWT.Name = "yGraphWT";
            this.yGraphWT.ShowToolBar = false;
            this.yGraphWT.Size = new System.Drawing.Size(872, 525);
            this.yGraphWT.TabIndex = 0;
            this.yGraphWT.YGraphBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.yGraphWT.YGraphBorderButtomBackColor = System.Drawing.Color.Black;
            this.yGraphWT.YGraphBorderTopBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.yGraphWT.YGraphCmdBtnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.yGraphWT.YGraphCmdBtnCheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.yGraphWT.YGraphCmdBtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.yGraphWT.YGraphCoordinateFont = new System.Drawing.Font("微软雅黑", 12F);
            this.yGraphWT.YGraphCoordinateForeColor = System.Drawing.Color.Lime;
            this.yGraphWT.YGraphCoordinateLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.yGraphWT.YGraphCoordinateTitleFont = new System.Drawing.Font("微软雅黑", 12F);
            this.yGraphWT.YGraphCoordinateTitleForeColor = System.Drawing.Color.Yellow;
            this.yGraphWT.YGraphGridAlpha = 100;
            this.yGraphWT.YGraphGridColor = System.Drawing.Color.Gray;
            this.yGraphWT.YGraphTip = "";
            this.yGraphWT.YGraphTipFont = new System.Drawing.Font("微软雅黑", 56F);
            this.yGraphWT.YGraphTipForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.yGraphWT.YGraphTitle = "生产节拍";
            this.yGraphWT.YGraphTitleFont = new System.Drawing.Font("微软雅黑", 16F);
            this.yGraphWT.YGraphTitleForeColor = System.Drawing.Color.Lime;
            this.yGraphWT.YGraphTopPointFont = new System.Drawing.Font("微软雅黑", 16F);
            this.yGraphWT.YGraphTopPointForeColor = System.Drawing.Color.White;
            this.yGraphWT.YGraphxAxisBegin = 0F;
            this.yGraphWT.YGraphxAxisEnd = 22F;
            this.yGraphWT.YGraphxAxisTitle = "采样次数";
            this.yGraphWT.YGraphyAxisBegin = 0F;
            this.yGraphWT.YGraphyAxisEnd = 10F;
            this.yGraphWT.YGraphyAxisTitle = "时间";
            // 
            // panelCurWT
            // 
            this.panelCurWT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCurWT.BackColor = System.Drawing.Color.Transparent;
            this.panelCurWT.Location = new System.Drawing.Point(1, 1);
            this.panelCurWT.Name = "panelCurWT";
            this.panelCurWT.Size = new System.Drawing.Size(871, 138);
            this.panelCurWT.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormProdMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(872, 667);
            this.Controls.Add(this.panelCurWT);
            this.Controls.Add(this.yGraphWT);
            this.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Name = "FormProdMonitor";
            this.Text = "FormProdMonitor";
            this.ResumeLayout(false);

        }

        #endregion

        private Yangyalin.YGraph yGraphWT;
        private System.Windows.Forms.Panel panelCurWT;
        private System.Windows.Forms.Timer timer1;
    }
}
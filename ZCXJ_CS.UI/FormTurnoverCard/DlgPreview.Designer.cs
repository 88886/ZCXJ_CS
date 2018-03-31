namespace ZCXJ_CS.UI
{
    partial class DlgPreview
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
            this.previewCtrl = new System.Windows.Forms.PrintPreviewControl();
            this.SuspendLayout();
            // 
            // previewCtrl
            // 
            this.previewCtrl.AutoZoom = false;
            this.previewCtrl.BackColor = System.Drawing.Color.White;
            this.previewCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewCtrl.Location = new System.Drawing.Point(0, 0);
            this.previewCtrl.Name = "previewCtrl";
            this.previewCtrl.Size = new System.Drawing.Size(541, 537);
            this.previewCtrl.TabIndex = 0;
            this.previewCtrl.Zoom = 0.7D;
            // 
            // DlgPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(541, 537);
            this.Controls.Add(this.previewCtrl);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgPreview";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "周转卡预览";
            this.Load += new System.EventHandler(this.DlgPreview_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintPreviewControl previewCtrl;
    }
}
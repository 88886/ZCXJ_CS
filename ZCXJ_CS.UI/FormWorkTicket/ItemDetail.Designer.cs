namespace ZCXJ_CS.UI
{
    partial class ItemDetail
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
            this.txtItemDetail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtItemDetail
            // 
            this.txtItemDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtItemDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtItemDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtItemDetail.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtItemDetail.Location = new System.Drawing.Point(0, 0);
            this.txtItemDetail.Multiline = true;
            this.txtItemDetail.Name = "txtItemDetail";
            this.txtItemDetail.Size = new System.Drawing.Size(350, 349);
            this.txtItemDetail.TabIndex = 1;
            // 
            // ItemDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtItemDetail);
            this.Name = "ItemDetail";
            this.Size = new System.Drawing.Size(350, 349);
            this.Load += new System.EventHandler(this.ItemDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtItemDetail;
    }
}

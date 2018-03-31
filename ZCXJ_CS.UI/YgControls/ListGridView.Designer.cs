namespace ZCXJ_CS.UI
{
    partial class ListGridView<T>
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainsplitContainer = new System.Windows.Forms.SplitContainer();
            this.GridView = new System.Windows.Forms.DataGridView();
            this.GridPage = new ZCXJ_CS.UI.PageContorl();
            ((System.ComponentModel.ISupportInitialize)(this.MainsplitContainer)).BeginInit();
            this.MainsplitContainer.Panel1.SuspendLayout();
            this.MainsplitContainer.Panel2.SuspendLayout();
            this.MainsplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainsplitContainer
            // 
            this.MainsplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainsplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.MainsplitContainer.IsSplitterFixed = true;
            this.MainsplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainsplitContainer.Name = "MainsplitContainer";
            this.MainsplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainsplitContainer.Panel1
            // 
            this.MainsplitContainer.Panel1.Controls.Add(this.GridView);
            // 
            // MainsplitContainer.Panel2
            // 
            this.MainsplitContainer.Panel2.Controls.Add(this.GridPage);
            this.MainsplitContainer.Size = new System.Drawing.Size(592, 425);
            this.MainsplitContainer.SplitterDistance = 375;
            this.MainsplitContainer.SplitterWidth = 1;
            this.MainsplitContainer.TabIndex = 0;
            // 
            // GridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridView.BackgroundColor = System.Drawing.Color.White;
            this.GridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.NullValue = "未知";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.GridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridView.ColumnHeadersHeight = 40;
            this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.GridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.GridView.EnableHeadersVisualStyles = false;
            this.GridView.Location = new System.Drawing.Point(0, 0);
            this.GridView.MultiSelect = false;
            this.GridView.Name = "GridView";
            this.GridView.ReadOnly = true;
            this.GridView.RowHeadersVisible = false;
            this.GridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GridView.RowTemplate.Height = 35;
            this.GridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView.Size = new System.Drawing.Size(592, 375);
            this.GridView.TabIndex = 0;
            this.GridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellClick);
            this.GridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellValueChanged);
            this.GridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GridView_DataBindingComplete);
            this.GridView.BindingContextChanged += new System.EventHandler(this.GridView_BindingContextChanged);
            // 
            // GridPage
            // 
            this.GridPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridPage.Location = new System.Drawing.Point(0, 0);
            this.GridPage.Name = "GridPage";
            this.GridPage.PageCount = 1;
            this.GridPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GridPage.Size = new System.Drawing.Size(592, 49);
            this.GridPage.TabIndex = 0;
            // 
            // ListGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainsplitContainer);
            this.DoubleBuffered = true;
            this.Name = "ListGridView";
            this.Size = new System.Drawing.Size(592, 425);
            this.MainsplitContainer.Panel1.ResumeLayout(false);
            this.MainsplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainsplitContainer)).EndInit();
            this.MainsplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainsplitContainer;
        public System.Windows.Forms.DataGridView GridView;
        private PageContorl GridPage;
    }
}

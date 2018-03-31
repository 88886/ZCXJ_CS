namespace ZCXJ_CS.UI
{
    partial class FormCallEvent
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
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.tableLP = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayList = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.MainSplitContainer.IsSplitterFixed = true;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainSplitContainer.Name = "MainSplitContainer";
            this.MainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.tableLP);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.tableLayList);
            this.MainSplitContainer.Size = new System.Drawing.Size(967, 622);
            this.MainSplitContainer.SplitterWidth = 1;
            this.MainSplitContainer.TabIndex = 0;
            // 
            // tableLP
            // 
            this.tableLP.ColumnCount = 8;
            this.tableLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP.Location = new System.Drawing.Point(0, 0);
            this.tableLP.Margin = new System.Windows.Forms.Padding(0);
            this.tableLP.Name = "tableLP";
            this.tableLP.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.tableLP.RowCount = 1;
            this.tableLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLP.Size = new System.Drawing.Size(967, 50);
            this.tableLP.TabIndex = 6;
            // 
            // tableLayList
            // 
            this.tableLayList.AutoScroll = true;
            this.tableLayList.AutoSize = true;
            this.tableLayList.BackColor = System.Drawing.Color.Transparent;
            this.tableLayList.ColumnCount = 1;
            this.tableLayList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayList.Location = new System.Drawing.Point(0, 0);
            this.tableLayList.Name = "tableLayList";
            this.tableLayList.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayList.RowCount = 1;
            this.tableLayList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayList.Size = new System.Drawing.Size(967, 571);
            this.tableLayList.TabIndex = 5;
            // 
            // FormCallEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 622);
            this.Controls.Add(this.MainSplitContainer);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FormCallEvent";
            this.Text = "FormCallEvent";
            this.Load += new System.EventHandler(this.FormCallEvent_Load);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            this.MainSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.TableLayoutPanel tableLP;
        private System.Windows.Forms.TableLayoutPanel tableLayList;
    }
}
namespace ZCXJ_CS.UI
{
    partial class FormTeamHandover
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cobpass = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_hand = new System.Windows.Forms.Button();
            this.textBox_shift = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cobshift = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cobreceive = new System.Windows.Forms.ComboBox();
            this.labelcont = new System.Windows.Forms.Label();
            this.btn_receive = new System.Windows.Forms.Button();
            this.textBox_obtain = new System.Windows.Forms.TextBox();
            this.labelreceive = new System.Windows.Forms.Label();
            this.panel_pass = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_obtain = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnQueryHistory = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel_pass, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel_obtain, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 57);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(971, 503);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cobpass);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_hand);
            this.groupBox1.Controls.Add(this.textBox_shift);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(481, 124);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "交班班组";
            // 
            // cobpass
            // 
            this.cobpass.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cobpass.FormattingEnabled = true;
            this.cobpass.Location = new System.Drawing.Point(90, 79);
            this.cobpass.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cobpass.Name = "cobpass";
            this.cobpass.Size = new System.Drawing.Size(316, 27);
            this.cobpass.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(9, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "交班记录：";
            // 
            // btn_hand
            // 
            this.btn_hand.BackColor = System.Drawing.Color.Transparent;
            this.btn_hand.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_hand.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_hand.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_hand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_hand.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_hand.Location = new System.Drawing.Point(327, 33);
            this.btn_hand.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_hand.Name = "btn_hand";
            this.btn_hand.Size = new System.Drawing.Size(80, 30);
            this.btn_hand.TabIndex = 2;
            this.btn_hand.Text = "交班";
            this.btn_hand.UseVisualStyleBackColor = false;
            this.btn_hand.Click += new System.EventHandler(this.btn_hand_Click);
            // 
            // textBox_shift
            // 
            this.textBox_shift.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_shift.Location = new System.Drawing.Point(90, 36);
            this.textBox_shift.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox_shift.Name = "textBox_shift";
            this.textBox_shift.Size = new System.Drawing.Size(174, 25);
            this.textBox_shift.TabIndex = 1;
            this.textBox_shift.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_shift_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(9, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "交班人：";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.cobshift);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cobreceive);
            this.groupBox2.Controls.Add(this.labelcont);
            this.groupBox2.Controls.Add(this.btn_receive);
            this.groupBox2.Controls.Add(this.textBox_obtain);
            this.groupBox2.Controls.Add(this.labelreceive);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(487, 3);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Size = new System.Drawing.Size(482, 124);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接班班组";
            // 
            // cobshift
            // 
            this.cobshift.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cobshift.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cobshift.FormattingEnabled = true;
            this.cobshift.Location = new System.Drawing.Point(390, 78);
            this.cobshift.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cobshift.Name = "cobshift";
            this.cobshift.Size = new System.Drawing.Size(83, 27);
            this.cobshift.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(386, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "选择班组：";
            // 
            // cobreceive
            // 
            this.cobreceive.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cobreceive.FormattingEnabled = true;
            this.cobreceive.Location = new System.Drawing.Point(88, 78);
            this.cobreceive.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cobreceive.Name = "cobreceive";
            this.cobreceive.Size = new System.Drawing.Size(288, 27);
            this.cobreceive.TabIndex = 9;
            // 
            // labelcont
            // 
            this.labelcont.AutoSize = true;
            this.labelcont.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelcont.Location = new System.Drawing.Point(12, 81);
            this.labelcont.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelcont.Name = "labelcont";
            this.labelcont.Size = new System.Drawing.Size(74, 19);
            this.labelcont.TabIndex = 8;
            this.labelcont.Text = "接班记录：";
            // 
            // btn_receive
            // 
            this.btn_receive.BackColor = System.Drawing.Color.Transparent;
            this.btn_receive.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_receive.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_receive.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_receive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_receive.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_receive.Location = new System.Drawing.Point(296, 33);
            this.btn_receive.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_receive.Name = "btn_receive";
            this.btn_receive.Size = new System.Drawing.Size(80, 30);
            this.btn_receive.TabIndex = 7;
            this.btn_receive.Text = "接班";
            this.btn_receive.UseVisualStyleBackColor = false;
            this.btn_receive.Click += new System.EventHandler(this.btn_receive_Click);
            // 
            // textBox_obtain
            // 
            this.textBox_obtain.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_obtain.Location = new System.Drawing.Point(88, 37);
            this.textBox_obtain.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox_obtain.Name = "textBox_obtain";
            this.textBox_obtain.Size = new System.Drawing.Size(174, 25);
            this.textBox_obtain.TabIndex = 6;
            this.textBox_obtain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_obtain_KeyDown);
            // 
            // labelreceive
            // 
            this.labelreceive.AutoSize = true;
            this.labelreceive.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelreceive.Location = new System.Drawing.Point(13, 37);
            this.labelreceive.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelreceive.Name = "labelreceive";
            this.labelreceive.Size = new System.Drawing.Size(61, 19);
            this.labelreceive.TabIndex = 5;
            this.labelreceive.Text = "接班人：";
            // 
            // panel_pass
            // 
            this.panel_pass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_pass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_pass.Location = new System.Drawing.Point(2, 133);
            this.panel_pass.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel_pass.Name = "panel_pass";
            this.panel_pass.Padding = new System.Windows.Forms.Padding(5);
            this.panel_pass.Size = new System.Drawing.Size(481, 367);
            this.panel_pass.TabIndex = 3;
            // 
            // panel_obtain
            // 
            this.panel_obtain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_obtain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_obtain.Location = new System.Drawing.Point(487, 133);
            this.panel_obtain.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel_obtain.Name = "panel_obtain";
            this.panel_obtain.Padding = new System.Windows.Forms.Padding(5);
            this.panel_obtain.Size = new System.Drawing.Size(482, 367);
            this.panel_obtain.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Controls.Add(this.btnQueryHistory, 7, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(971, 49);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // btnQueryHistory
            // 
            this.btnQueryHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQueryHistory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnQueryHistory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnQueryHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQueryHistory.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQueryHistory.Location = new System.Drawing.Point(852, 3);
            this.btnQueryHistory.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnQueryHistory.Name = "btnQueryHistory";
            this.btnQueryHistory.Size = new System.Drawing.Size(114, 43);
            this.btnQueryHistory.TabIndex = 1;
            this.btnQueryHistory.Text = "查看历史记录";
            this.btnQueryHistory.UseVisualStyleBackColor = true;
            this.btnQueryHistory.Click += new System.EventHandler(this.btnQueryHistory_Click);
            // 
            // FormTeamHandover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(982, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "FormTeamHandover";
            this.Text = "FormTeamHandover";
            this.Load += new System.EventHandler(this.FormTeamHandover_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cobpass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_hand;
        private System.Windows.Forms.TextBox textBox_shift;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cobshift;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cobreceive;
        private System.Windows.Forms.Label labelcont;
        private System.Windows.Forms.Button btn_receive;
        private System.Windows.Forms.TextBox textBox_obtain;
        private System.Windows.Forms.Label labelreceive;
        private System.Windows.Forms.FlowLayoutPanel panel_pass;
        private System.Windows.Forms.FlowLayoutPanel panel_obtain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnQueryHistory;




    }
}
namespace PriceMonitoringSystem
{
    partial class UcDictComp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.HISbm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HISmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jkbm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jkmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HospCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Coltype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.ColumnHeadersHeight = 34;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HISbm,
            this.HISmc,
            this.Jkbm,
            this.Jkmc,
            this.HospCode,
            this.Coltype,
            this.ID,
            this.remark});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkKhaki;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Location = new System.Drawing.Point(3, 40);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(796, 336);
            this.dgv.TabIndex = 41;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtText);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(652, 34);
            this.panel3.TabIndex = 40;
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(79, 6);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(227, 21);
            this.txtText.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 28;
            this.label8.Text = "检索关键字：";
            // 
            // HISbm
            // 
            this.HISbm.HeaderText = "国家科室编码";
            this.HISbm.Name = "HISbm";
            this.HISbm.ReadOnly = true;
            this.HISbm.Width = 120;
            // 
            // HISmc
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.HISmc.DefaultCellStyle = dataGridViewCellStyle3;
            this.HISmc.HeaderText = "国家科室名称";
            this.HISmc.Name = "HISmc";
            this.HISmc.ReadOnly = true;
            this.HISmc.Width = 200;
            // 
            // Jkbm
            // 
            this.Jkbm.HeaderText = "对应科室编码";
            this.Jkbm.Name = "Jkbm";
            this.Jkbm.ReadOnly = true;
            this.Jkbm.Width = 120;
            // 
            // Jkmc
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Jkmc.DefaultCellStyle = dataGridViewCellStyle4;
            this.Jkmc.HeaderText = "对应科室名称";
            this.Jkmc.Name = "Jkmc";
            this.Jkmc.ReadOnly = true;
            this.Jkmc.Width = 200;
            // 
            // HospCode
            // 
            this.HospCode.HeaderText = "医疗机构代码";
            this.HospCode.Name = "HospCode";
            this.HospCode.Visible = false;
            // 
            // Coltype
            // 
            this.Coltype.HeaderText = "Column1";
            this.Coltype.Name = "Coltype";
            this.Coltype.Visible = false;
            // 
            // ID
            // 
            this.ID.HeaderText = "对照明细记录ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // remark
            // 
            this.remark.HeaderText = "说明";
            this.remark.Name = "remark";
            this.remark.Width = 150;
            // 
            // UcDictComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panel3);
            this.Name = "UcDictComp";
            this.Size = new System.Drawing.Size(802, 379);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn HISbm;
        private System.Windows.Forms.DataGridViewTextBoxColumn HISmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jkbm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jkmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn HospCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coltype;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
    }
}

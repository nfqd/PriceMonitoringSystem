namespace PriceMonitoringSystem
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gropUp = new System.Windows.Forms.GroupBox();
            this.dgrdUp = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUP_cs = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.UpTime = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.cbbtablename = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dtpend = new System.Windows.Forms.DateTimePicker();
            this.dtpstart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUP_sd = new System.Windows.Forms.Button();
            this.btnSTOP = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.用户操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripCssc = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSdsc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripTc = new System.Windows.Forms.ToolStripMenuItem();
            this.字典管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.字典对照明细记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.科室对照ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.麻醉对照ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.药品导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.耗材导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.医疗服务导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.药品价格ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.耗材价格编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.机构信息编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.国家科室编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gropUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdUp)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gropUp
            // 
            this.gropUp.Controls.Add(this.dgrdUp);
            this.gropUp.ForeColor = System.Drawing.Color.Blue;
            this.gropUp.Location = new System.Drawing.Point(0, 92);
            this.gropUp.Name = "gropUp";
            this.gropUp.Size = new System.Drawing.Size(1092, 403);
            this.gropUp.TabIndex = 6;
            this.gropUp.TabStop = false;
            this.gropUp.Text = "上月数据";
            // 
            // dgrdUp
            // 
            this.dgrdUp.AllowUserToAddRows = false;
            this.dgrdUp.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dgrdUp.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdUp.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdUp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrdUp.ColumnHeadersHeight = 34;
            this.dgrdUp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkKhaki;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdUp.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdUp.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgrdUp.EnableHeadersVisualStyles = false;
            this.dgrdUp.Location = new System.Drawing.Point(3, 17);
            this.dgrdUp.MultiSelect = false;
            this.dgrdUp.Name = "dgrdUp";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdUp.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdUp.RowHeadersVisible = false;
            this.dgrdUp.RowTemplate.Height = 23;
            this.dgrdUp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdUp.Size = new System.Drawing.Size(1086, 383);
            this.dgrdUp.TabIndex = 5;
            this.dgrdUp.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrdUp_CellValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnUP_cs);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.UpTime);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.cbbtablename);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1112, 31);
            this.panel1.TabIndex = 5;
            // 
            // btnUP_cs
            // 
            this.btnUP_cs.Location = new System.Drawing.Point(1008, 4);
            this.btnUP_cs.Name = "btnUP_cs";
            this.btnUP_cs.Size = new System.Drawing.Size(74, 23);
            this.btnUP_cs.TabIndex = 10;
            this.btnUP_cs.Text = "定时上传";
            this.btnUP_cs.UseVisualStyleBackColor = true;
            this.btnUP_cs.Click += new System.EventHandler(this.btnUP_cs_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(538, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(118, 23);
            this.button4.TabIndex = 19;
            this.button4.Text = "上月数据重新导入";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(796, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "每天上传时间：";
            // 
            // UpTime
            // 
            this.UpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.UpTime.Location = new System.Drawing.Point(892, 5);
            this.UpTime.Name = "UpTime";
            this.UpTime.ShowUpDown = true;
            this.UpTime.Size = new System.Drawing.Size(102, 21);
            this.UpTime.TabIndex = 8;
            this.UpTime.Value = new System.DateTime(2011, 6, 28, 0, 0, 0, 0);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(425, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "上月数据生成";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbbtablename
            // 
            this.cbbtablename.FormattingEnabled = true;
            this.cbbtablename.Location = new System.Drawing.Point(67, 6);
            this.cbbtablename.Name = "cbbtablename";
            this.cbbtablename.Size = new System.Drawing.Size(232, 20);
            this.cbbtablename.TabIndex = 7;
            this.cbbtablename.SelectedIndexChanged += new System.EventHandler(this.cbbtablename_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "表  名：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(313, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "上月数据上传";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(542, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "手动生成";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dtpend
            // 
            this.dtpend.Location = new System.Drawing.Point(338, 5);
            this.dtpend.Name = "dtpend";
            this.dtpend.Size = new System.Drawing.Size(104, 21);
            this.dtpend.TabIndex = 17;
            // 
            // dtpstart
            // 
            this.dtpstart.Location = new System.Drawing.Point(109, 5);
            this.dtpstart.Name = "dtpstart";
            this.dtpstart.Size = new System.Drawing.Size(114, 21);
            this.dtpstart.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "- 选择结束时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "选择开始时间：";
            // 
            // btnUP_sd
            // 
            this.btnUP_sd.Location = new System.Drawing.Point(455, 4);
            this.btnUP_sd.Name = "btnUP_sd";
            this.btnUP_sd.Size = new System.Drawing.Size(75, 23);
            this.btnUP_sd.TabIndex = 8;
            this.btnUP_sd.Text = "手动上传";
            this.btnUP_sd.UseVisualStyleBackColor = true;
            this.btnUP_sd.Click += new System.EventHandler(this.btnUP_sd_Click);
            // 
            // btnSTOP
            // 
            this.btnSTOP.Enabled = false;
            this.btnSTOP.Location = new System.Drawing.Point(1008, 4);
            this.btnSTOP.Name = "btnSTOP";
            this.btnSTOP.Size = new System.Drawing.Size(75, 23);
            this.btnSTOP.TabIndex = 1;
            this.btnSTOP.Text = "暂停";
            this.btnSTOP.UseVisualStyleBackColor = true;
            this.btnSTOP.Click += new System.EventHandler(this.btnSTOP_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.用户操作ToolStripMenuItem,
            this.字典管理ToolStripMenuItem,
            this.数据导入ToolStripMenuItem,
            this.数据编辑ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1097, 25);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 用户操作ToolStripMenuItem
            // 
            this.用户操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripCssc,
            this.ToolStripSdsc,
            this.toolStripMenuItem1,
            this.ToolStripTc});
            this.用户操作ToolStripMenuItem.Name = "用户操作ToolStripMenuItem";
            this.用户操作ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.用户操作ToolStripMenuItem.Text = "用户操作";
            // 
            // ToolStripCssc
            // 
            this.ToolStripCssc.Name = "ToolStripCssc";
            this.ToolStripCssc.Size = new System.Drawing.Size(148, 22);
            this.ToolStripCssc.Text = "测试上传";
            this.ToolStripCssc.Visible = false;
            // 
            // ToolStripSdsc
            // 
            this.ToolStripSdsc.Name = "ToolStripSdsc";
            this.ToolStripSdsc.Size = new System.Drawing.Size(148, 22);
            this.ToolStripSdsc.Text = "手动上传";
            this.ToolStripSdsc.Visible = false;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem1.Text = "取消定时上传";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // ToolStripTc
            // 
            this.ToolStripTc.Name = "ToolStripTc";
            this.ToolStripTc.Size = new System.Drawing.Size(148, 22);
            this.ToolStripTc.Text = "退出";
            this.ToolStripTc.Click += new System.EventHandler(this.ToolStripTc_Click);
            // 
            // 字典管理ToolStripMenuItem
            // 
            this.字典管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.字典对照明细记录ToolStripMenuItem});
            this.字典管理ToolStripMenuItem.Name = "字典管理ToolStripMenuItem";
            this.字典管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.字典管理ToolStripMenuItem.Text = "字典管理";
            // 
            // 字典对照明细记录ToolStripMenuItem
            // 
            this.字典对照明细记录ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.科室对照ToolStripMenuItem,
            this.麻醉对照ToolStripMenuItem});
            this.字典对照明细记录ToolStripMenuItem.Name = "字典对照明细记录ToolStripMenuItem";
            this.字典对照明细记录ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.字典对照明细记录ToolStripMenuItem.Text = "字典对照明细记录";
            // 
            // 科室对照ToolStripMenuItem
            // 
            this.科室对照ToolStripMenuItem.Name = "科室对照ToolStripMenuItem";
            this.科室对照ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.科室对照ToolStripMenuItem.Text = "科室对照";
            this.科室对照ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripYpdy_Click);
            // 
            // 麻醉对照ToolStripMenuItem
            // 
            this.麻醉对照ToolStripMenuItem.Name = "麻醉对照ToolStripMenuItem";
            this.麻醉对照ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.麻醉对照ToolStripMenuItem.Text = "麻醉对照";
            this.麻醉对照ToolStripMenuItem.Click += new System.EventHandler(this.麻醉对照ToolStripMenuItem_Click);
            // 
            // 数据导入ToolStripMenuItem
            // 
            this.数据导入ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.药品导入ToolStripMenuItem,
            this.耗材导入ToolStripMenuItem,
            this.医疗服务导入ToolStripMenuItem});
            this.数据导入ToolStripMenuItem.Name = "数据导入ToolStripMenuItem";
            this.数据导入ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.数据导入ToolStripMenuItem.Text = "数据导入";
            // 
            // 药品导入ToolStripMenuItem
            // 
            this.药品导入ToolStripMenuItem.Name = "药品导入ToolStripMenuItem";
            this.药品导入ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.药品导入ToolStripMenuItem.Text = "药品导入";
            this.药品导入ToolStripMenuItem.Click += new System.EventHandler(this.药品导入ToolStripMenuItem_Click);
            // 
            // 耗材导入ToolStripMenuItem
            // 
            this.耗材导入ToolStripMenuItem.Name = "耗材导入ToolStripMenuItem";
            this.耗材导入ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.耗材导入ToolStripMenuItem.Text = "耗材导入";
            this.耗材导入ToolStripMenuItem.Click += new System.EventHandler(this.耗材导入ToolStripMenuItem_Click);
            // 
            // 医疗服务导入ToolStripMenuItem
            // 
            this.医疗服务导入ToolStripMenuItem.Name = "医疗服务导入ToolStripMenuItem";
            this.医疗服务导入ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.医疗服务导入ToolStripMenuItem.Text = "医疗服务导入";
            this.医疗服务导入ToolStripMenuItem.Click += new System.EventHandler(this.医疗服务导入ToolStripMenuItem_Click);
            // 
            // 数据编辑ToolStripMenuItem
            // 
            this.数据编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.药品价格ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.耗材价格编辑ToolStripMenuItem,
            this.机构信息编辑ToolStripMenuItem,
            this.国家科室编辑ToolStripMenuItem});
            this.数据编辑ToolStripMenuItem.Name = "数据编辑ToolStripMenuItem";
            this.数据编辑ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.数据编辑ToolStripMenuItem.Text = "数据编辑";
            // 
            // 药品价格ToolStripMenuItem
            // 
            this.药品价格ToolStripMenuItem.Name = "药品价格ToolStripMenuItem";
            this.药品价格ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.药品价格ToolStripMenuItem.Text = "药品价格编辑";
            this.药品价格ToolStripMenuItem.Click += new System.EventHandler(this.药品价格ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "服务价格编辑";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // 耗材价格编辑ToolStripMenuItem
            // 
            this.耗材价格编辑ToolStripMenuItem.Name = "耗材价格编辑ToolStripMenuItem";
            this.耗材价格编辑ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.耗材价格编辑ToolStripMenuItem.Text = "耗材价格编辑";
            this.耗材价格编辑ToolStripMenuItem.Click += new System.EventHandler(this.耗材价格编辑ToolStripMenuItem_Click);
            // 
            // 机构信息编辑ToolStripMenuItem
            // 
            this.机构信息编辑ToolStripMenuItem.Name = "机构信息编辑ToolStripMenuItem";
            this.机构信息编辑ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.机构信息编辑ToolStripMenuItem.Text = "机构信息编辑";
            this.机构信息编辑ToolStripMenuItem.Click += new System.EventHandler(this.机构信息编辑ToolStripMenuItem_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSTOP);
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.btnUP_sd);
            this.panel3.Controls.Add(this.dtpend);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.dtpstart);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(0, 59);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1112, 31);
            this.panel3.TabIndex = 9;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(630, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(97, 23);
            this.button5.TabIndex = 18;
            this.button5.Text = "手动重新导入";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // 国家科室编辑ToolStripMenuItem
            // 
            this.国家科室编辑ToolStripMenuItem.Name = "国家科室编辑ToolStripMenuItem";
            this.国家科室编辑ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.国家科室编辑ToolStripMenuItem.Text = "国家科室编辑";
            this.国家科室编辑ToolStripMenuItem.Click += new System.EventHandler(this.国家科室编辑ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 496);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.gropUp);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "药品和医疗服务价格监测信息系统上传程序";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gropUp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdUp)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gropUp;
        private System.Windows.Forms.DataGridView dgrdUp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUP_sd;
        private System.Windows.Forms.Button btnSTOP;
        private System.Windows.Forms.ComboBox cbbtablename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 用户操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripCssc;
        private System.Windows.Forms.ToolStripMenuItem ToolStripSdsc;
        private System.Windows.Forms.ToolStripMenuItem ToolStripTc;
        private System.Windows.Forms.ToolStripMenuItem 字典管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 字典对照明细记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 科室对照ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 麻醉对照ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据导入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 药品导入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 耗材导入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 医疗服务导入ToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpend;
        private System.Windows.Forms.DateTimePicker dtpstart;
        private System.Windows.Forms.Button btnUP_cs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker UpTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 数据编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 药品价格ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 耗材价格编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 机构信息编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolStripMenuItem 国家科室编辑ToolStripMenuItem;
    }
}


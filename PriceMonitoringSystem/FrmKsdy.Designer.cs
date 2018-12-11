namespace PriceMonitoringSystem
{
    partial class FrmKsdy
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnout = new System.Windows.Forms.Button();
            this.btnBc = new System.Windows.Forms.Button();
            this.ucDictComp1 = new UcDictComp();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.btnout);
            this.panel1.Controls.Add(this.btnBc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 25);
            this.panel1.TabIndex = 4;
            // 
            // btnout
            // 
            this.btnout.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnout.Location = new System.Drawing.Point(65, 0);
            this.btnout.Name = "btnout";
            this.btnout.Size = new System.Drawing.Size(65, 25);
            this.btnout.TabIndex = 10;
            this.btnout.Text = "退出";
            this.btnout.UseVisualStyleBackColor = false;
            this.btnout.Click += new System.EventHandler(this.btnout_Click);
            // 
            // btnBc
            // 
            this.btnBc.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBc.Location = new System.Drawing.Point(0, 0);
            this.btnBc.Name = "btnBc";
            this.btnBc.Size = new System.Drawing.Size(65, 25);
            this.btnBc.TabIndex = 5;
            this.btnBc.Text = "保存";
            this.btnBc.UseVisualStyleBackColor = false;
            this.btnBc.Click += new System.EventHandler(this.btnBc_Click);
            // 
            // ucDictComp1
            // 
            this.ucDictComp1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucDictComp1.Bm = null;
            this.ucDictComp1.Location = new System.Drawing.Point(6, 31);
            this.ucDictComp1.Mc = null;
            this.ucDictComp1.Name = "ucDictComp1";
            this.ucDictComp1.Size = new System.Drawing.Size(896, 482);
            this.ucDictComp1.TabIndex = 5;
            // 
            // FrmKsdy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 512);
            this.Controls.Add(this.ucDictComp1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmKsdy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmKsdy";
            this.Load += new System.EventHandler(this.FrmKsdy_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnout;
        private System.Windows.Forms.Button btnBc;
        private UcDictComp ucDictComp1;
    }
}
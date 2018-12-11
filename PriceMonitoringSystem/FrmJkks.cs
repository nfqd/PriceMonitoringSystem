using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace PriceMonitoringSystem
{
    public partial class FrmJkks : Form
    {
        #region 公共属性
        private Point pp;

        public Point Pp
        {
            get { return pp; }
            set { pp = value; }
        }
        private  string _bm;
        public string bm
        {
            get { return _bm; }
            set { _bm = value; }
        }
        public string title;
        public List<string> colNames = new List<string>();
        public string LocationCode = "";
        public bool isVisibe= false;
        public string searchName = "";

        public delegate void deleSetValue(string ID, string  Name);
        public event deleSetValue setVauleEvent;
        #endregion

        public FrmJkks()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.COMMIT;
            
        }
       
        private static DataTable dt;
        private void FrmJkks_Load(object sender, EventArgs e)
        {
            this.Text = title;
            this.Location = Pp;
            if (isVisibe)
            {
                this.Width = 500;
            }
            else
            {
                this.Width = 355;
            }
            Jkbm.HeaderText= colNames[2];
            Jkmc.HeaderText=colNames[3];
           
            
            this.remark.Visible = isVisibe;
            //dt = AppServer.getdzxx(LocationCode);
            dt = AppServer.sjcx(LocationCode, "");
            SelectTodgv();
            //this.txtText.Text = searchName;
            txtText.Focus();
        }
        private void SelectTodgv()
        {
            try
            {
                string select = "";
                if (txtText.Text != "")
                {
                    select = "( bm like '%" + txtText.Text + "%' mc like '%" + txtText.Text + "%')";
                }
                String[] s = new String[3];
                dgv.Rows.Clear();
                foreach (DataRow dr in dt.Select(select, "bm ASC"))
                {
                    s[0] = dr["bm"].ToString();
                    s[1] = dr["mc"].ToString();
                    //s[2] = dr["Sj"].ToString();

                    dgv.Rows.Add(s[0], s[1]);//, s[2]
                }
            }
            catch
            {
            }
            
        }

     

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string BM = dgv.CurrentRow.Cells[0].Value.ToString();
                string MC = dgv.CurrentRow.Cells[1].Value.ToString();
                

                if (setVauleEvent != null)
                {
                    setVauleEvent(BM, MC);
                }


                this.DialogResult = DialogResult.OK;
            }
        }
        #region 重写键盘事件
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && dgv.Focused)
            {
                btnSure_Click(null, null);
                return true;
            }
            if ((keyData == Keys.Up || keyData == Keys.Down) && (!dgv.Focused))
            {
                if (dgv.RowCount > 0)
                    dgv.Focus();
                return true;
            }


            int WM_KEYDOWN = 256;

            int WM_SYSKEYDOWN = 260;

            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)
            {

                switch (keyData)
                {

                    case Keys.Escape:

                        this.Close();//esc关闭窗体

                        break;

                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
        private void btnSure_Click(object sender, EventArgs e)
        {
            if (dgv.RowCount == 0)
                return;
            if (dgv.CurrentCell.RowIndex > -1)
            {
                string BM = dgv.CurrentRow.Cells[0].Value.ToString();
                string MC = dgv.CurrentRow.Cells[1].Value.ToString();

                if (setVauleEvent != null)
                {
                    setVauleEvent(BM, MC);
                }
                this.DialogResult = DialogResult.OK;
                
            }
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            SelectTodgv();
        }
    }
}

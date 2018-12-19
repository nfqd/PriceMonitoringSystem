using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace PriceMonitoringSystem
{
    public partial class Frmgjks : Form
    {
        public Frmgjks()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.COMMIT;
        }

        public DataTable dt;
        public string tablename;
        public string type;
        public string sql;//查询语句
        private void FrmTen_Load(object sender, EventArgs e)
        {
            //dt = AppServer.zbcx("", "", "0"); cbojslb.SelectedIndex = 0;
            //bindingdgrdUp();
           // SelectTodgv();
            tttype.Text = type;
        }


        //移除datatable指定列



        private void btnYes_Click(object sender, EventArgs e)
        {

        }



        private void btnout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //单元格内容改变

        //
        /// <summary>
        /// 判断datatable的row行是否全为null 第一参数 行值 第二 列值
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        /// 

        public int newrowid;
        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                string strcomm = "insert into " + tablename + " (code,value,type) values('" + ttcode.Text + "','" + ttvalue.Text + "','" + tttype.Text + "')";

                AppServer.ExecuteNonQuery(strcomm);
                MessageBox.Show("保存成功！");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        //删除

    }
}

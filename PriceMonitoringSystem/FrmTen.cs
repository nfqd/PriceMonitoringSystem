using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace PriceMonitoringSystem
{
    public partial class FrmTen : Form
    {
        public FrmTen()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.COMMIT;
        }

        public DataTable dt;
        public string tablename;
        public string sql;//查询语句
        private void SelectTodgv()
        {
            try
            {
                string select = "";
                if (txtText.Text != "" && !string.IsNullOrEmpty(dgrdUp.Columns[0].HeaderText) && !string.IsNullOrEmpty(dgrdUp.Columns[1].HeaderText))
                {
                    select = "(" + dgrdUp.Columns[0].HeaderText + " like '%" + txtText.Text + "%' OR " + dgrdUp.Columns[1].HeaderText + "  like '%" + txtText.Text + "%')";
                }
                dgrdUp.DataSource = null;
                DataTable tmp = dt.Rows[0].Table.Clone(); // 复制DataRow的表结构
                foreach (DataRow row in dt.Select(select))
                {

                    tmp.ImportRow(row); // 将DataRow添加到DataTable中
                }
                dgrdUp.DataSource = tmp;
                //id列 只读
                if (dgrdUp.Columns[0].HeaderText.ToLower() == "id")
                {
                    dgrdUp.Columns[0].ReadOnly = true;
                }
                //foreach (DataRow dr in dt.Select(select))
                //{
                //    //s[0] = dr["code"].ToString();
                //    //s[1] = dr["value"].ToString();
                //    //s[2] = dr["hiscode"].ToString();
                //    //s[3] = dr["hisname"].ToString();
                //    //s[4] = dr["typename"].ToString();
                //    ////s[5] = dr["ID"].ToString();
                //    //dgrdUp.Rows.Add(s[0], s[1], s[2], s[3], s[4]);//, s[5]
                //    dgrdUp.Rows.Add(dr);
                //}
                // dgrdUp.DataSource = dt1;
            }
            catch (Exception ex)
            {
            }
        }
        private void FrmTen_Load(object sender, EventArgs e)
        {
            //dt = AppServer.zbcx("", "", "0"); cbojslb.SelectedIndex = 0;
            //bindingdgrdUp();
            SelectTodgv();
        }


        //移除datatable指定列
        public void romovetablecolums(DataTable dtresult)
        {
            if (dtresult.Columns.Contains("dataStartDate"))
            {
                dtresult.Columns.Remove("dataStartDate");
            }
            if (dtresult.Columns.Contains("dataEndDate"))
            {
                dtresult.Columns.Remove("dataEndDate");
            }
            if (dtresult.Columns.Contains("updatestatus"))
            {
                dtresult.Columns.Remove("updatestatus");
            }
        }



        private void btnYes_Click(object sender, EventArgs e)
        {

        }

        private void cbojslb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectTodgv();
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            SelectTodgv();
        }

        private void btnout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //单元格内容改变
        private void dgrdUp_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                string strcomm;//sql
                string stridcolumname = dgrdUp.Columns[0].HeaderText;//获取主键名
                string strcolumn = dgrdUp.Columns[e.ColumnIndex].HeaderText;//获取列标题
                string strrow = dgrdUp.Rows[e.RowIndex].Cells[0].Value.ToString();//获取焦点触发行的第一个值
                string value = dgrdUp.CurrentCell.Value.ToString();//获取当前点击的活动单元格的值

                if (e.ColumnIndex == 0 && dgrdUp.Columns[0].HeaderText.ToLower() == "id")
                {
                    MessageBox.Show("ID列不能输入数值!");
                    dgrdUp.CurrentCell.Value = null;
                    return;
                }
                //判断是否是空行
                if ((newrowid - 1) == e.RowIndex && datarownull(e.RowIndex, e.ColumnIndex))
                {
                    //如果新增的不是第一列 并且第一列不是id列 提示需要先新增第一列
                    if (e.ColumnIndex != 0 && dgrdUp.Columns[0].HeaderText.ToLower() != "id")
                    {
                        MessageBox.Show("需要先输入 " + stridcolumname + " 的值!");
                        return;
                    }
                    strcomm = "insert into " + tablename + " (" + strcolumn + ") values('" + value + "')";
                }
                else
                {
                    //第一列不能编辑
                    if (e.ColumnIndex == 0 )
                    {
                        MessageBox.Show("第一列" + stridcolumname + "的值不能编辑!");
                        return;
                    }
                    strcomm = "update " + tablename + " set  " + strcolumn + " ='" + value + "' where " + stridcolumname + " = '" + strrow+"'";
                }


                AppServer.ExecuteNonQuery(strcomm);
                //再更新datagridview 
                dt = AppServer.SelData(sql);
                SelectTodgv();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        //
        /// <summary>
        /// 判断datatable的row行是否全为null 第一参数 行值 第二 列值
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        /// 
        private bool datarownull(int r, int c)
        {

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (!string.IsNullOrEmpty(dgrdUp.Rows[r].Cells[i].Value.ToString()) )
                {
                    if (i == c)
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                    
                }
            }
            return true;
        }

        private void btnsave_Click(object sender, EventArgs e)//保存
        {

        }
        public int newrowid;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow dr1 = dt.NewRow();
            dt.Rows.Add(dr1);
            newrowid = dt.Rows.Count;
            dgrdUp.DataSource = dt;


        }

        //删除
        private void btnDel_Click(object sender, EventArgs e)
        {
            //弹出确认对话框
            DialogResult dr = MessageBox.Show("确定要删除选中行吗? " , "提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
            {
                return;
            }


            dt.Rows.RemoveAt(dgrdUp.CurrentRow.Index);
            Deletedata();
        }
        //删除选中行
        private void Deletedata()
        {

            string stridcolumname = dgrdUp.Columns[0].HeaderText;//获取主键名
            string value = dgrdUp.Rows[dgrdUp.CurrentRow.Index].Cells[0].Value.ToString();//获取选中行第一列值

            string deletesql = "delete from "+tablename+" where " + stridcolumname + "='" + value + "'";
            AppServer.ExecuteNonQuery(deletesql);
            //再更新datagridview 
            dt = AppServer.SelData(sql);
            SelectTodgv();
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace PriceMonitoringSystem
{
    public partial class UcDictComp : UserControl
    {

        #region 公共属性
        private string bm;
        public string Bm
        {
            get { return bm; }
            set { bm = value; }
        }
        private string mc;
        public string Mc
        {
            get { return mc; }
            set { mc = value; }
        }
        /// <summary>
        /// 省平台科室主记录ID
        /// </summary>
        //public string SectionCodeService = "ZZ244";//省平台科室主记录ID
        //public string SectionNameService = "";
        /// <summary>
        /// 医院科室主记录
        /// </summary>
        //public string SectionCodeHosp = "KSXX001"; //医院科室主记录ID
        //public string SectionNameHosp = "";
        public DataTable dt;//医院科室列表
        //public string versionStandard = "V1.0";
        //public string version = "V1.0";
        public string title;
        /// <summary>
        /// 本字典自定义编码（如科室：KS）
        /// </summary>
        public string LocationCode = "";

        public Form owerForm;
        public string type;//类型

        public List<string> columnNames = null;
        public bool isDisplayRemark = false;


        #endregion



        public UcDictComp()
        {
            InitializeComponent();
            dgv.CellMouseClick+=new DataGridViewCellMouseEventHandler(dgv_CellMouseClick);
            dgv.CellMouseDown+=new DataGridViewCellMouseEventHandler(dgv_CellMouseDown);
            this.txtText.TextChanged +=new EventHandler(txtText_TextChanged);
        }

        public void InitForm()
        {
             #region  表格初始化
           
            this.HISbm.HeaderText = columnNames[0];
            this.HISmc.HeaderText = columnNames[1]; 
            this.Jkbm.HeaderText = columnNames[2];           
            this.Jkmc.HeaderText = columnNames[3];
            this.remark.Visible = false;
            #endregion

            SelectTodgv();
        }



        #region 表格处理事件
        private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCell CurrnetCell = dgv.CurrentCell;
            if (CurrnetCell == null)
                return;
            int yzrow = CurrnetCell.RowIndex;
            int j = CurrnetCell.ColumnIndex;
            if (yzrow > -1 && j > -1)
            {
                //pnl.Visible = false;
                dgv.CurrentCell = dgv.Rows[yzrow].Cells[j];//获取当前单元格
                dgv.CurrentCell.ReadOnly = false;
                //dgv.CurrentCell.Style.BackColor = Color.Yellow;
                dgv.BeginEdit(true);//将单元格设为编辑状态
            }
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgv.RowCount <= 0)
                return;
            DataGridViewCell CurrnetCell = dgv.CurrentCell;
            if (CurrnetCell == null)
                return;
            int yzrow = CurrnetCell.RowIndex;
            int j = CurrnetCell.ColumnIndex;
            if (yzrow > -1 && j > -1)
            {
                //pnl.Visible = false;
                dgv.CurrentCell = dgv.Rows[yzrow].Cells[j];//获取当前单元格
                //dgv.CurrentCell.Style.BackColor = Color.Yellow;
                dgv.BeginEdit(true);//将单元格设为编辑状态
            }
            Rectangle TmpRect;
            TmpRect = dgv.GetCellDisplayRectangle(CurrnetCell.ColumnIndex, CurrnetCell.RowIndex, true);
            switch (CurrnetCell.OwningColumn.Name)
            {
                case "Jkbm":
                    FrmJkks f = new FrmJkks();
                    f.setVauleEvent +=new FrmJkks.deleSetValue(f_setVauleEvent);
                    f.isVisibe = this.isDisplayRemark;
                    f.colNames = columnNames;
                    //f.LocationCode = this.LocationCode;
                    f.LocationCode = this.type;
                    f.title = this.title;
                    f.Owner = owerForm;
                    f.searchName = dgv.Rows[yzrow].Cells[1].Value.ToString();
                    Point po = new Point(0, 0);

                    if (TmpRect.Bottom + 330 > dgv.Height)
                    {
                        po.Y = dgv.PointToScreen(new Point(0, TmpRect.Top - 392)).Y;
                        if (po.Y < 0)
                        {
                            po.Y = -1;
                        }
                    }
                    else
                        po.Y = dgv.PointToScreen(new Point(0, TmpRect.Bottom)).Y;
                    po.X = dgv.PointToScreen(new Point(TmpRect.Left, 0)).X;

                    f.Pp = po;
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        dgv.Rows[yzrow].Cells[2].Value = Bm;
                        dgv.Rows[yzrow].Cells[3].Value = Mc;
                    }
                    break;
            }
        }
        void f_setVauleEvent(string id, string name)
        {
            Bm = id;
            mc = name;
        }


        #endregion
        #region 查找
        private void txtText_TextChanged(object sender, EventArgs e)
        {
            SelectTodgv();
        }

        //private void SelectTodgv()
        //{
        //    try
        //    {
        //        string select = "";
        //        if (txtText.Text != "")
        //        {
        //            select = "(value like '%" + txtText.Text + "%' OR code like '%" + txtText.Text + "%')";
        //        }
        //        String[] s = new String[6];
        //        dgv.Rows.Clear();
        //        foreach (DataRow dr in dt.Select(select, "code ASC"))
        //        {
        //            s[0] = dr["code"].ToString();
        //            s[1] = dr["value"].ToString();
        //            s[2] = dr["hiscode"].ToString();
        //            s[3] = dr["hisname"].ToString();
        //            s[4] = dr["typename"].ToString();
        //            s[5] = dr["type"].ToString();
        //            dgv.Rows.Add(s[0], s[1], s[2], s[3], s[4], s[5]);//
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}

        private void SelectTodgv()
        {
            try
            {
                string select = "";
                if (txtText.Text != "")
                {
                    select = "(bm like '%" + txtText.Text + "%' OR mc like '%" + txtText.Text + "%')";
                }
                String[] s = new String[6];
                dgv.Rows.Clear();
                foreach (DataRow dr in dt.Select(select, "bm ASC"))
                {
                    //s[0] = dr["code"].ToString();
                    //s[1] = dr["value"].ToString();
                    //s[2] = dr["hiscode"].ToString();
                    //s[3] = dr["hisname"].ToString();
                    //s[4] = dr["typename"].ToString();
                    //s[5] = dr["type"].ToString();
                    //dgv.Rows.Add(s[0], s[1], s[2], s[3], s[4], s[5]);//

                    s[0] = dr["bm"].ToString();
                    s[1] = dr["mc"].ToString();
                    s[2] = dr["code"].ToString();
                    s[3] = dr["value"].ToString();
                    s[4] = "";
                    s[5] = this.type;
                    dgv.Rows.Add(s[0], s[1], s[2], s[3], s[4], s[5]);//
                }
            }
            catch
            {
            }
        }
        #endregion

        #region 退出 保存
       

        public void  Save()
        {
            string errmsg = "";
            
            List<interface_rcmodel> list = new List<interface_rcmodel>();

            #region 赋值
            //model.Begin_date = DateTime.Now;
            //model.Createtime = DateTime.Now;
            //model.Hos_org_code = Hosp.HospCode;
            //model.ID = SectionCodeHosp;
            //model.Local_dict_id = SectionCodeHosp;
            //model.Local_dict_name = SectionNameHosp;
            //model.Local_dict_version = version;
            //model.Standard_dict_id = SectionCodeService;
            //model.Standard_dict_name = SectionNameService;
            //model.Standard_dict_version = versionStandard;

            for (int i = 0; i < this.dgv.Rows.Count; i++)
            {
                //已经对照过
                if (this.dgv.Rows[i].Cells[2].Value.ToString() != "")
                {
                    interface_rcmodel model = new interface_rcmodel();

                    //modelDetail.DictID = model.ID;
                    //modelDetail.Hos_org_code = model.Hos_org_code;

                    //model.code = dgv.Rows[i].Cells["HISbm"].Value.ToString();
                    //model.value = dgv.Rows[i].Cells["HISmc"].Value.ToString();

                    //model.hiscode = dgv.Rows[i].Cells["Jkbm"].Value.ToString();
                    //model.hisname = dgv.Rows[i].Cells["Jkmc"].Value.ToString();
                    model.hiscode = dgv.Rows[i].Cells["HISbm"].Value.ToString();
                    model.hisname = dgv.Rows[i].Cells["HISmc"].Value.ToString();

                    model.code = dgv.Rows[i].Cells["Jkbm"].Value.ToString();
                    model.value = dgv.Rows[i].Cells["Jkmc"].Value.ToString();
                    model.type = dgv.Rows[i].Cells["Coltype"].Value.ToString();
                    list.Add(model);
                }
            }

            #endregion

            DictComp obj = new DictComp();

            bool isSuc = obj.Add( list);

            if (isSuc)
            {
                MessageBox.Show("保存成功！");
            }
            else
            {
                if (errmsg != "")
                {
                    errmsg = "保存失败！异常信息：" + errmsg;
                }
                else
                {
                    errmsg = "保存失败！";
                }

                MessageBox.Show(errmsg);
            }
        }

        #endregion







    }
}

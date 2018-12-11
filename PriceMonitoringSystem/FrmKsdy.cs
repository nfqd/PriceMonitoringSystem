using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;


namespace PriceMonitoringSystem
{
    public partial class FrmKsdy : Form
    {

        public FrmKsdy()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.COMMIT;
        }

       
       
        private void FrmKsdy_Load(object sender, EventArgs e)
        {
            this.Text = "科室对照";
            ucDictComp1.owerForm = this;
            ucDictComp1.LocationCode = "ks";
            //ucDictComp1.SectionCodeService = "ZZ244";
            //ucDictComp1.SectionCodeHosp = "KSXX001";
            //ucDictComp1.dt = AppServer.sjcx("RC038", "");
            ucDictComp1.dt = AppServer.getdzxx("ks");
            ucDictComp1.type = "RC038";
            ucDictComp1.title = "科室选择";
            //ucDictComp1.SectionNameService = "科室编码";
            //ucDictComp1.SectionNameHosp = "科室编码";

            List<string> list = new List<string>();
            list.Add("院内科室编码");
            list.Add("院内科室名称");
            list.Add("对应国家科室编码");
            list.Add("对应国家科室名称");
            ucDictComp1.columnNames = list;

            this.ucDictComp1.InitForm();


        }
       

        #region 退出 保存
        private void btnout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {

                ucDictComp1.Save();
            }

           // ucDictComp1.Save();
            

           }

        #endregion



       
    }
}

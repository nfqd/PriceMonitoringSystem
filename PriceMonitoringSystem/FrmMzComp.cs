using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PriceMonitoringSystem
{
    public partial class FrmMzComp : Form
    {
        public FrmMzComp()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.COMMIT;
        }

        private void FrmCheckComp_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "麻醉方式对照";
                ucDictComp1.owerForm = this;
                ucDictComp1.LocationCode = "mz";
                //ucDictComp1.SectionCodeService = "CV06.00.103";
                //ucDictComp1.SectionCodeHosp = "MZXX001";
                //ucDictComp1.dt = AppServer.sjcx("RC041", "");
                ucDictComp1.dt = AppServer.getdzxx("mz");
                ucDictComp1.type = "RC041";
                ucDictComp1.title = "麻醉方式选择";
                ucDictComp1.isDisplayRemark = true;
                //ucDictComp1.SectionNameService = "麻醉方式";
                //ucDictComp1.SectionNameHosp = "麻醉方式";
                //ucDictComp1.versionStandard = "V2.0";


                List<string> list = new List<string>();
                list.Add("院内麻醉编码");
                list.Add("院内麻醉名称");
                list.Add("对应国家麻醉编码");
                list.Add("对应国家麻醉名称");
                ucDictComp1.columnNames = list;

                this.ucDictComp1.InitForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {

                ucDictComp1.Save();
            }

        }

        private void btnout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
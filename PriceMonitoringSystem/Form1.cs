
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace PriceMonitoringSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        public static string tablename = null;

        public static Dictionary<string, string> dictable = new Dictionary<string, string>();
        DataTable dtresult = new DataTable();
        DateTime dt1;//按月手动上传时间
        DateTime dt2;//按月手动上传时间
        //DateTime today;//定时上传当天
        //DateTime yesterday;//定时上传前一天
        public static List<string> tablesnamelist = new List<string>();

        public static bool stopbz = false;

        private void Form1_Load(object sender, EventArgs e)
        {

            dictable.Add("药品价格表", "interface_drugPriceTraceVo");//每天一个文件
            dictable.Add("耗材价格表", "interface_materialPriceTraceVo");//每天一个文件
            dictable.Add("医疗服务价格表", "interface_servicePriceTraceVo");//每天一个文件  //可编辑
            dictable.Add("资源、服务、药品加成表", "interface_hospitalResourceVo");//每季度一个文件
            dictable.Add("住院病案首页表", "interface_hospitalBASY");//每季度一个文件
            dictable.Add("药品价格导入表", "interface_drug");//可编辑
            dictable.Add("耗材价格导入表", "interface_material");//可编辑
            dictable.Add("服务价格导入表", "interface_service");//可编辑
            dictable.Add("医疗机构表", "interface_orginfo");//可编辑
            //dictable.Add("测试表", "T_WebConfigSet");

            //先给cbbtablename控件赋值表名
            foreach (var dic in dictable)
            {
                cbbtablename.Items.Add(dic.Key);
            }

            //

            //bindingdgrdUp("T_WebConfigSet");
            autoupdate();

        }

        public void autoupdate()
        {
            //获取配置文件信息
            Configuration con = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string updatetime = con.AppSettings.Settings["updatetime"].Value;
            if (updatetime != "" && updatetime != "00:00:00")
            {
                //开启自动上传
                timer.Enabled = true;
                //控件显示时间
                UpTime.Value = Convert.ToDateTime(updatetime);
            }
            else
            {
                timer.Enabled = false;
            }


        }

        /// <summary>
        /// 给grdUp 绑定数据
        /// </summary>
        /// <param name="tablename"></param>
        public void bindingdgrdUp(string tablename)
        {
            try
            {
                //第一个：设置自动创建列，默认为True 
                dgrdUp.AutoGenerateColumns = true;
                //第二个：鼠标单击编辑，默认双击 
                dgrdUp.EditMode = DataGridViewEditMode.EditOnEnter;
                //先获取当前时间，
                string StartDate = DateTime.Now.AddMonths(-1).ToString("yyyy-MM") + "-01";//当前月的前一月
                string EndDate = DateTime.Now.ToString("yyyy-MM") + "-01";//当前月的第一天
                string sql = "select * from " + tablename + " where datastartdate>='" + StartDate + "' and dataenddate<'" + EndDate + "' and updatestatus=0 ";
                dtresult = AppServer.SelData(sql);
                romovetablecolums(dtresult);
                dgrdUp.ReadOnly = true;//数据表不可编辑
                dgrdUp.DataSource = dtresult;
                if (tablename == "interface_servicePriceTraceVo")//医疗服务价格表 可以编辑
                {
                    dgrdUp.Columns[0].Visible = false;
                    dgrdUp.ReadOnly = false;
                }

                //dgrdUp.ReadOnly = true;//整个表格只读
                //dgrdUp.Columns[0].ReadOnly = true;//第一列只读（第一列为主键列）
                //dgrdUp.Rows[0].ReadOnly = true;//行只读
                //dgrdUp[3, 3].ReadOnly = true;//单元格只读
            }
            catch (Exception ex)
            {


            }
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

        private void dgrdUp_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (tablename != "interface_servicePriceTraceVo")//只能编辑 医疗服务价格表
            {
                return;
            }
            try
            {
                string stridcolumname = dgrdUp.Columns[0].HeaderText;//获取主键名
                string strcolumn = dgrdUp.Columns[e.ColumnIndex].HeaderText;//获取列标题
                string strrow = dgrdUp.Rows[e.RowIndex].Cells[0].Value.ToString();//获取焦点触发行的第一个值
                string value = dgrdUp.CurrentCell.Value.ToString();//获取当前点击的活动单元格的值
                string strcomm = "update " + tablename + " set  " + strcolumn + " ='" + value + "' where " + stridcolumname + " = " + strrow;

                AppServer.ExecuteNonQuery(strcomm);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }


        }
        // 根据下拉选择的不同表名给给grdUp 绑定数据
        private void cbbtablename_SelectedIndexChanged(object sender, EventArgs e)
        {
            Thread.Sleep(500);  //.sleep();
            //MessageBox.Show(dictable[cbbtablename.SelectedItem.ToString()]);
            tablename = dictable[cbbtablename.SelectedItem.ToString()];
            //如果选择导入表 上传按钮不能用
            if (tablename == "interface_drug" || tablename == "interface_material" || tablename == "interface_service")
            {
                this.button1.Enabled = false;
                this.btnUP_sd.Enabled = false;
                this.button2.Enabled = false;
                this.button3.Enabled = false;
            }
            else
            {
                this.button1.Enabled = true;
                this.btnUP_sd.Enabled = true;
                this.button2.Enabled = true;
                this.button3.Enabled = true;
            }
            if (tablename == "interface_hospitalResourceVo" || tablename == "interface_hospitalBASY")//按季度上传
            {
                this.button1.Text = "上季度数据上传";
                this.button2.Text = "上季度数据生成";
                this.button4.Text = "上季度数据重新导入";
            }
            else
            {
                this.button1.Text = "上月数据上传";
                this.button2.Text = "上月数据生成";
                this.button4.Text = "上月度数据重新导入";
            }
            bindingdgrdUp(tablename);
        }

        //上传按钮
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbtablename.SelectedItem == null)
                {
                    return;
                }
                //弹出确认对话框
                DialogResult dr = MessageBox.Show("确定要上传 " + cbbtablename.SelectedItem.ToString() + " 至国家价格监测系统吗？", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }

                stopbz = false;//暂停
                //按季度或者按月上传
                string StartDate = "";
                string EndDate = "";
                if (tablename == "interface_hospitalResourceVo" || tablename == "interface_hospitalBASY")
                {
                    StartDate = DateTime.Now.AddMonths(-3 - ((DateTime.Now.Month - 1) % 3)).AddDays(1 - DateTime.Now.Day).ToShortDateString();// 上季度第一天
                    EndDate = DateTime.Now.AddMonths(0 - ((DateTime.Now.Month - 1) % 3)).AddDays(1 - DateTime.Now.Day).AddDays(-1).ToShortDateString();// 上季度最后一天
                }
                else
                {
                    //先获取当前时间，然后循环遍历上个月每一天查询数据库生成报文上传
                    StartDate = DateTime.Now.AddMonths(-1).ToString("yyyy-MM") + "-01";//当前月的前一月
                    EndDate = DateTime.Now.ToString("yyyy-MM") + "-01";//当前月的第一天
                }

                dt1 = DateTime.Parse(StartDate);
                dt2 = DateTime.Parse(EndDate);
                //selecttime(dt1, dt2);
                Thread th = new Thread(selecttime);
                th.IsBackground = true;
                th.Start();
                this.button1.Enabled = false;
                btnsotptrue();
                // MessageBox.Show("上报完成！");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //上传按钮恢复
        public void button1enable()
        {
            this.button1.Enabled = true;
        }
        //上月生成
        public void button2enable()
        {
            this.button2.Enabled = true;
        }
        //手动生成
        public void button3enable()
        {
            this.button3.Enabled = true;
        }
        //手动上传按钮恢复
        public void btnUPenable()
        {
            this.btnUP_sd.Enabled = true;
        }
        public void btnsotptrue()
        {
            this.btnSTOP.Enabled = true;
        }
        public void btnsotpfalse()
        {
            this.btnSTOP.Enabled = false;
        }
        public void button4enable()
        {
            this.button4.Enabled = true;
        }
        public void button5enable()
        {
            this.button5.Enabled = true;
        }

        //手动上传
        private void btnUP_sd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbtablename.SelectedItem == null)
                {
                    return;
                }
                //弹出确认对话框
                DialogResult dr = MessageBox.Show("确定要上传 " + cbbtablename.SelectedItem.ToString() + " 至国家价格监测系统吗？", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                stopbz = false;//暂停
                dt1 = dtpstart.Value.Date;
                dt2 = dtpend.Value.Date;
                Thread th = new Thread(selecttime);
                th.IsBackground = true;
                th.Start();

                this.btnUP_sd.Enabled = false;
                btnsotptrue();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 根据选择的时间循环调用
        /// </summary>
        /// <param name="dt1">开始时间</param>
        /// <param name="dt2">结束时间</param>
        public void selecttime()//DateTime dt1, DateTime dt2
        {
            try
            {
                string StartDate = null;
                string EndDate = null;
                if (tablename == "interface_hospitalResourceVo" || tablename == "interface_hospitalBASY")//按季度
                {
                    while (DateTime.Compare(dt1, dt2) < 0 && !stopbz)
                    {
                        DateTime startQuarter = dt1.AddMonths(0 - (dt1.Month - 1) % 3).AddDays(1 - dt1.Day);  //本季度初
                        DateTime endQuarter = startQuarter.AddMonths(3).AddDays(-1);  //本季度末
                        StartDate = startQuarter.ToString("yyyy-MM-dd");// 选择日期那季度第一天
                        EndDate = endQuarter.ToString("yyyy-MM-dd");// 
                        dt1 = endQuarter.AddDays(1);

                        update(StartDate, EndDate, tablename);
                    }
                }
                else
                {
                    while (DateTime.Compare(dt1, dt2) < 0 && !stopbz)
                    {
                        StartDate = dt1.ToString("yyyy-MM-dd");//开始时间
                        dt1 = dt1.AddDays(1);
                        EndDate = dt1.ToString("yyyy-MM-dd");//结束时间

                        update(StartDate, EndDate, tablename);
                    }
                }



                MessageBox.Show("上报完成！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            button1enable();
            btnUPenable();
            btnsotpfalse();
        }

        /// <summary>
        /// 根据选择的时间循环调用 手动生成xml文件
        /// </summary>
        /// <param name="dt1">开始时间</param>
        /// <param name="dt2">结束时间</param>
        public void selecttime_sd()//DateTime dt1, DateTime dt2
        {
            try
            {
                string StartDate = null;
                string EndDate = null;
                if (tablename == "interface_hospitalResourceVo" || tablename == "interface_hospitalBASY")//按季度
                {
                    while (DateTime.Compare(dt1, dt2) < 0 && !stopbz)
                    {
                        DateTime startQuarter = dt1.AddMonths(0 - (dt1.Month - 1) % 3).AddDays(1 - dt1.Day);  //本季度初
                        DateTime endQuarter = startQuarter.AddMonths(3).AddDays(-1);  //本季度末
                        StartDate = startQuarter.ToString("yyyy-MM-dd");// 选择日期那季度第一天
                        EndDate = endQuarter.ToString("yyyy-MM-dd");// 
                        dt1 = endQuarter.AddDays(1);
                        string path = AppDomain.CurrentDomain.BaseDirectory + cbbtablename.SelectedItem.ToString();
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string filename = path + "\\" + StartDate + ".xml";
                        if (System.IO.File.Exists(filename))                                //存在则删除
                        {
                            System.IO.File.Delete(filename);
                        }
                        ToXML(StartDate, EndDate, tablename, filename);
                    }
                }
                else
                {
                    while (DateTime.Compare(dt1, dt2) < 0 && !stopbz)
                    {
                        StartDate = dt1.ToString("yyyy-MM-dd");//开始时间
                        dt1 = dt1.AddDays(1);
                        EndDate = dt1.ToString("yyyy-MM-dd");//结束时间
                        string path = AppDomain.CurrentDomain.BaseDirectory + cbbtablename.SelectedItem.ToString();
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string filename = path + "\\" + StartDate + ".xml";
                        if (System.IO.File.Exists(filename))                                //存在则删除
                        {
                            System.IO.File.Delete(filename);
                        }
                        ToXML(StartDate, EndDate, tablename, filename);
                    }
                }


                MessageBox.Show("生成完成！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnsotpfalse();
            button2enable();
            button3enable();
        }
        //根据日期和表名生成数据
        public void ToXML(string StartDate, string EndDate, string tablename, string filepath)
        {
            try
            {
                LogHelper.WriteLog("选择生成表：" + cbbtablename.SelectedItem.ToString());
                //状态 0未上传 1 已上传
                string sql;
                if (tablename == "interface_hospitalResourceVo" || tablename == "interface_hospitalBASY")//按季度
                {
                    sql = "select * from " + tablename + " where datastartdate>='" + StartDate + "' and dataenddate<='" + EndDate + "' and updatestatus=0 ";
                }
                else
                {
                    sql = "select * from " + tablename + " where datastartdate>='" + StartDate + "' and dataenddate<'" + EndDate + "' and updatestatus=0 ";
                }

                if (tablename == "interface_drugPriceTraceVo" || tablename == "interface_servicePriceTraceVo" || tablename == "interface_materialPriceTraceVo")
                {
                    sql += " order by seqNumber asc ";
                }
                string updatesql = "update " + tablename + "  set updatestatus=1 where  datastartdate>='" + StartDate + "' and dataenddate<'" + EndDate + "'";
                //获取机构表
                DataTable dtorg = AppServer.getdzxx("org");
                dtresult = AppServer.SelData(sql);
                if (dtresult.Rows.Count == 0)//没有数据
                {
                    return;
                }
                //移除指定列
                romovetablecolums(dtresult);

                //判断如果是病案首页 则导出数据到excel文件并转换为字节流上传
                if (cbbtablename.SelectedItem.ToString() == "住院病案首页表")
                {
                    string fliename = "41_db_" + StartDate;
                    //生成文件
                    string pathname = ExcelHelper.DataToExcel(dtresult, fliename);
                    //更新数据状态
                    AppServer.QueryData(updatesql);
                    return;

                }

                //根据选择的表名 拼接字符串 
                string Str = ConvertDataTableToXML(dtresult);
                //Str = Str.Replace("<Table>", "<drugPriceTrace>").Replace("</Table>", "</drugPriceTrace>").Replace("<NewDataSet>", "<drugPriceTraces>").Replace("</NewDataSet>", "</drugPriceTraces>");
                //string info = "<drugPriceTraceVo><orgCode>" + dtorg.Rows[0]["bm"].ToString() + "</orgCode><hospName>" + dtorg.Rows[0]["mc"].ToString() + "</hospName><submitTotalNum>" + dtresult.Rows.Count.ToString() + "</submitTotalNum><dataStartDate>" + StartDate + "</dataStartDate><dataEndDate>" + StartDate + "</dataEndDate>" + Str + "</drugPriceTraceVo>";
                string info = stringedit(Str, dtorg, StartDate, EndDate);
                info = info.Contains("&") ? info.Replace('&', ' ') : info;
                info = info.Contains("T00:00:00+08:00") ? info.Replace("T00:00:00+08:00","") : info;
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(info);
                //保存xml文档
                xmldoc.Save(filepath);
                //保存加密文本
                //MainSm4 sm4 = new MainSm4();
                //string secretKey = AppServer.GetConn("secretKey");//秘钥
                //string ms4txt=sm4.Encrypt_ECB(secretKey, false, info);
                //FileWrite FileWrite = new PriceMonitoringSystem.FileWrite();
                //FileWrite.FileStreamWrite(ms4txt, AppDomain.CurrentDomain.BaseDirectory + tablename + "\\" + StartDate + ".txt");
                //更新数据状态
                AppServer.QueryData(updatesql);
                return;
            }
            catch (Exception ex)
            {

                MessageBox.Show("生成失败！错误信息描述：" + ex.Message);
                LogHelper.WriteLog("生成失败！错误信息描述：" + ex.Message);
            }





        }


        //根据日期和表名上传数据
        public void update(string StartDate, string EndDate, string tablename)
        {
            #region 测试代码
            ////文件路径
            //string info="";
            //string filePath = @"C:\Users\Administrator\Desktop\2017-01-01.xml";
            //try
            //{
            //    if (File.Exists(filePath))
            //    {
            //        info = File.ReadAllText(filePath);
            //        //byte[] mybyte = Encoding.UTF8.GetBytes(text1.Text);
            //        //txt = Encoding.UTF8.GetString(mybyte);
            //    }
            //    else
            //    {
            //        MessageBox.Show("文件不存在");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //} 
            #endregion



            LogHelper.WriteLog("选择上传表：" + cbbtablename.SelectedItem.ToString());
            //状态 0未上传 1 已上传
            string sql;
            if (tablename == "interface_hospitalResourceVo" || tablename == "interface_hospitalBASY")//按季度
            {
                sql = "select * from " + tablename + " where datastartdate>='" + StartDate + "' and dataenddate<='" + EndDate + "' and updatestatus=0 ";
            }
            else
            {
                sql = "select * from " + tablename + " where datastartdate>='" + StartDate + "' and dataenddate<'" + EndDate + "' and updatestatus=0 ";
            }
            if (tablename == "interface_drugPriceTraceVo" || tablename == "interface_servicePriceTraceVo" || tablename == "interface_materialPriceTraceVo")
            {
                sql += " order by seqNumber asc ";
            }
            string updatesql = "update " + tablename + "  set updatestatus=1 where  datastartdate>='" + StartDate + "' and dataenddate<'" + EndDate + "'";
            //获取机构表
            DataTable dtorg = AppServer.getdzxx("org");
            dtresult = AppServer.SelData(sql);
            if (dtresult.Rows.Count == 0)//没有数据
            {
                return;
            }
            //移除指定列
            romovetablecolums(dtresult);

            string res = null;
            //判断如果是病案首页 则导出数据到excel文件并转换为字节流上传
            if (cbbtablename.SelectedItem.ToString() == "住院病案首页表")
            {
                string fliename = "41_db_" + StartDate;
                //生成文件
                string pathname = ExcelHelper.DataToExcel(dtresult, fliename);
                //将datatable 转为字节数组
                byte[] byt = ExcelHelper.GetFileData(pathname);
                //调用接口
                BASYtest.MedicalTempWServiceInterfaceClient BASY = new BASYtest.MedicalTempWServiceInterfaceClient();
                res = BASY.collection("41", dtorg.Rows[0]["bm"].ToString(), fliename + ".xls", byt);
                JObject jo = (JObject)JsonConvert.DeserializeObject(res);
                string msg_type = jo["msg_type"].ToString();
                string msg_desc = jo["msg_desc"].ToString();
                if (msg_type == "success")
                {
                    //更新数据状态
                    AppServer.QueryData(updatesql);
                    return;
                }
                else
                {
                    MessageBox.Show("上报失败！错误类型：" + msg_type + "错误描述" + msg_desc);
                    LogHelper.WriteLog("上报失败！错误类型：" + msg_type + "错误描述" + msg_desc + "错误数据具体原因" + jo["content"].ToString());
                    //string content = jo["content"].ToString();//返回错误数据具体原因
                }
                return;
            }

            //根据选择的表名 拼接字符串 
            string Str = ConvertDataTableToXML(dtresult);
            string info = stringedit(Str, dtorg, StartDate, EndDate);
            info = info.Contains("&") ? info.Replace('&', ' ') : info;
            info = info.Contains("T00:00:00+08:00") ? info.Replace("T00:00:00+08:00", "") : info;

            //Str = Str.Replace("<Table>", "<drugPriceTrace>").Replace("</Table>", "</drugPriceTrace>").Replace("<NewDataSet>", "<drugPriceTraces>").Replace("</NewDataSet>", "</drugPriceTraces>");
            //string info = "<drugPriceTraceVo><orgCode>" + dtorg.Rows[0]["bm"].ToString() + "</orgCode><hospName>" + dtorg.Rows[0]["mc"].ToString() + "</hospName><submitTotalNum>" + dtresult.Rows.Count.ToString() + "</submitTotalNum><dataStartDate>" + StartDate + "</dataStartDate><dataEndDate>" + StartDate + "</dataEndDate>" + Str + "</drugPriceTraceVo>";
            LogHelper.WriteLog("上传内容：" + info);
            //加密文本
            MainSm4 sm4 = new MainSm4();
            string secretKey = AppServer.GetConn("secretKey");//秘钥
            string ms4txt = sm4.Encrypt_ECB(secretKey, false, info);
            //调用webservice 进行上传
            ms4txt = dtorg.Rows[0]["bm"].ToString() + ms4txt;
            res = Getres(ms4txt);
            LogHelper.WriteLog("返回内容：" + res);
            if (string.IsNullOrEmpty(res))
            {
                MessageBox.Show("上报失败！返回结果为空");
                LogHelper.WriteLog("上报失败！");
                return;
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(res);
            string returncode = xmlDoc.SelectSingleNode("/Response/return_code").InnerText;
            if (returncode == "0")
            {
                //更新数据状态
                AppServer.QueryData(updatesql);
                return;
            }
            else
            {
                string returndesc = xmlDoc.SelectSingleNode("/Response/return_desc").InnerText;//返回错误数据具体原因
                MessageBox.Show("上报失败！错误信息描述：" + returndesc);
                LogHelper.WriteLog("上报失败！错误信息描述：" + returndesc);

            }
        }

        private string stringedit(string Str, DataTable dtorg, string StartDate, string EndDate)
        {
            // string info = "";
            switch (tablename)
            {
                case "interface_drugPriceTraceVo":
                    Str = Str.Replace("<Table>", "<drugPriceTrace>").Replace("</Table>", "</drugPriceTrace>").Replace("<NewDataSet>", "<drugPriceTraces>").Replace("</NewDataSet>", "</drugPriceTraces>");
                    return "<drugPriceTraceVo><orgCode>" + dtorg.Rows[0]["bm"].ToString() + "</orgCode><hospName>" + dtorg.Rows[0]["mc"].ToString() + "</hospName><submitTotalNum>" + dtresult.Rows.Count.ToString() + "</submitTotalNum><dataStartDate>" + StartDate + "</dataStartDate><dataEndDate>" + StartDate + "</dataEndDate>" + Str + "</drugPriceTraceVo>";

                case "interface_materialPriceTraceVo":
                    Str = Str.Replace("<Table>", "<materialPriceTrace>").Replace("</Table>", "</materialPriceTrace>").Replace("<NewDataSet>", "<materialPriceTraces>").Replace("</NewDataSet>", "</materialPriceTraces>");
                    return "<materialPriceTraceVo><orgCode>" + dtorg.Rows[0]["bm"].ToString() + "</orgCode><hospName>" + dtorg.Rows[0]["mc"].ToString() + "</hospName><submitTotalNum>" + dtresult.Rows.Count.ToString() + "</submitTotalNum><dataStartDate>" + StartDate + "</dataStartDate><dataEndDate>" + StartDate + "</dataEndDate>" + Str + "</materialPriceTraceVo>";

                case "interface_servicePriceTraceVo":
                    Str = Str.Replace("<Table>", "<servicePriceTrace>").Replace("</Table>", "</servicePriceTrace>").Replace("<NewDataSet>", "<servicePriceTraces>").Replace("</NewDataSet>", "</servicePriceTraces>");
                    return "<servicePriceTraceVo><orgCode>" + dtorg.Rows[0]["bm"].ToString() + "</orgCode><hospName>" + dtorg.Rows[0]["mc"].ToString() + "</hospName><submitTotalNum>" + dtresult.Rows.Count.ToString() + "</submitTotalNum><dataStartDate>" + StartDate + "</dataStartDate><dataEndDate>" + StartDate + "</dataEndDate>" + Str + "</servicePriceTraceVo>";

                case "interface_hospitalResourceVo":
                    Str = Str.Replace("<Table>", "").Replace("</Table>", "").Replace("<NewDataSet>", "").Replace("</NewDataSet>", "");
                    return "<hospitalResourceVo><orgCode>" + dtorg.Rows[0]["bm"].ToString() + "</orgCode><hospName>" + dtorg.Rows[0]["mc"].ToString() + "</hospName><dataStartDate>" + StartDate + "</dataStartDate><dataEndDate>" + EndDate + "</dataEndDate>" + Str + "</hospitalResourceVo>";

                default:
                    return "";
            }
        }



        public string Getres(string info)
        {
            switch (tablename)
            {
                case "interface_drugPriceTraceVo":
                    drugPriceTracetest.DrugPriceTraceWServiceInterfaceClient drug = new drugPriceTracetest.DrugPriceTraceWServiceInterfaceClient();
                    return drug.receiveDrugData(info);
                case "interface_materialPriceTraceVo":
                    materialPriceTracetest.MaterialPriceTraceWServiceInterfaceClient mater = new materialPriceTracetest.MaterialPriceTraceWServiceInterfaceClient();
                    return mater.receiveMaterialPriceData(info);
                case "interface_servicePriceTraceVo":
                    servicePriceTracetest.ServicePriceTraceWServiceInterfaceClient service = new servicePriceTracetest.ServicePriceTraceWServiceInterfaceClient();
                    return service.receiveServiceData(info);
                case "interface_hospitalResourceVo":
                    hospitalResourcetest.HospitalResourceWServiceInterfaceClient hospital = new hospitalResourcetest.HospitalResourceWServiceInterfaceClient();
                    return hospital.receiveResourceData(info);
                default:
                    return "";

            }
        }

        //datatable转xml
        public string ConvertDataTableToXML(DataTable dt)
        {

            if (dt != null)
            {
                MemoryStream ms = null;
                XmlTextWriter XmlWt = null;
                try
                {
                    ms = new MemoryStream();
                    //根据ms实例化XmlWt  
                    XmlWt = new XmlTextWriter(ms, Encoding.Default);
                    //获取ds中的数据  
                    dt.WriteXml(XmlWt);
                    int count = (int)ms.Length;
                    byte[] temp = new byte[count];
                    ms.Seek(0, SeekOrigin.Begin);
                    ms.Read(temp, 0, count);
                    //返回Unicode编码的文本  
                    Encoding utf8 = Encoding.Default;
                    //UnicodeEncoding ucode = new UnicodeEncoding();
                    string returnValue = utf8.GetString(temp).Trim();
                    return returnValue;
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    //释放资源  
                    if (XmlWt != null)
                    {
                        XmlWt.Close();
                        ms.Close();
                        ms.Dispose();
                    }
                }
            }
            else
            {
                return "";
            }
        }

        //科室对照
        private void ToolStripYpdy_Click(object sender, EventArgs e)
        {
            FrmKsdy f = new FrmKsdy();
            f.Owner = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            //f.WindowState = FormWindowState.Maximized;

            f.ShowDialog();
        }

        private void 麻醉对照ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMzComp f = new FrmMzComp();
            f.Owner = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
            // FrmMain_Load(null, null);
        }

        private void 药品导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //弹出对话框选择导入文件
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            //判断导入文件合法
            if (!file.SafeFileName.Contains("xls") && !file.SafeFileName.Contains("xlsx"))
            {
                MessageBox.Show("选择的文件不是Excel文件！");
                return;
            }
            string excelpath = file.FileName;
            //插入数据库
            if (insertdatatable("interface_drug", excelpath, 13))
            {
                MessageBox.Show("导入成功！");
                //刷新数据
                bindingdgrdUp("interface_drug");
            }
            else
            {
                MessageBox.Show("导入失败！");
            }



        }

        //数据导入
        public bool insertdatatable(string tablename, string path, int columns)
        {
            try
            {
                //数据导入表
                ExcelHelper ExcelHelper = new PriceMonitoringSystem.ExcelHelper();
                DataTable dt = ExcelHelper.GetExcelToDataTableBySheet(path, "sheet1$");
                //移除前三行
                dt.Rows.RemoveAt(0);
                dt.Rows.RemoveAt(0);
                //药品excel多移除一行
                if (tablename == "interface_drug")
                {
                    dt.Rows.RemoveAt(0);
                }
                //获取 tablename 表的列数
                string columnscount = AppServer.getdatatble(" select count(*) from syscolumns s where s.id=object_id('" + tablename + "')").Rows[0][0].ToString();
                //移除空列
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[0][j].ToString().Trim()))
                    {

                        dt.Columns.Remove(dt.Columns[j].ColumnName);
                    }
                }

                //移除第一行
                dt.Rows.RemoveAt(0);

                //显示数据
                bindingdgrdUp(tablename);
                //插入数据库
                return AppServer.insertdatatable(dt, tablename, columns, Convert.ToInt32(columnscount));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void 耗材导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //弹出对话框选择导入文件
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            //判断导入文件合法
            if (!file.SafeFileName.Contains("xls") && !file.SafeFileName.Contains("xlsx"))
            {
                MessageBox.Show("选择的文件不是Excel文件！");
                return;
            }
            string excelpath = file.FileName;
            //插入数据库
            if (insertdatatable("interface_material", excelpath, 11))
            {
                MessageBox.Show("导入成功！");
                //刷新数据
                bindingdgrdUp("interface_material");
            }
            else
            {
                MessageBox.Show("导入失败！");
            }
        }

        private void 医疗服务导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //弹出对话框选择导入文件
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            //判断导入文件合法
            if (!file.SafeFileName.Contains("xls") && !file.SafeFileName.Contains("xlsx"))
            {
                MessageBox.Show("选择的文件不是Excel文件！");
                return;
            }
            string excelpath = file.FileName;
            //插入数据库
            if (insertdatatable("interface_service", excelpath, -1))
            {
                MessageBox.Show("导入成功！");
                //刷新数据
                bindingdgrdUp("interface_service");
            }
            else
            {
                MessageBox.Show("导入失败！");
            }
        }

        private void btnSTOP_Click(object sender, EventArgs e)
        {

            if (stopbz == false)
            {
                stopbz = true;
            }
        }

        //定时上传
        private void timer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.ToString("HH:mm:ss") == UpTime.Value.ToString("HH:mm:ss"))
            {
                Thread th = new Thread(updateinfo);
                th.IsBackground = true;
                th.Start();

            }
        }

        //定时上传前一天的数据
        private void updateinfo()
        {
            //MessageBox.Show("上传！");
            //定时上传前一天 dictable.Add("药品价格表", "");dictable.Add("耗材价格表", "interface_materialPriceTraceVo");dictable.Add("资源、服务、药品加成表", "interface_hospitalResourceVo");
            //首先获取时间
            string StartDate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");//当前日期的前一天
            string EndDate = DateTime.Now.ToString("yyyy-MM-dd");//当前日期 
            //yesterday = DateTime.Parse(StartDate);
            //today = DateTime.Parse(EndDate);
            //将需要每天上传的表加入list 
            tablesnamelist.Clear();
            tablesnamelist.Add("interface_drugPriceTraceVo");//药品价格表
            tablesnamelist.Add("interface_materialPriceTraceVo");//耗材价格表
            tablesnamelist.Add("interface_hospitalResourceVo");//资源、服务、药品加成表
            //循环list上传每张表
            for (int i = 0; i < tablesnamelist.Count; i++)
            {
                update(StartDate, EndDate, tablesnamelist[i]);
            }
        }


        /// <summary>
        /// 根据当前时间循环上传每个表前一天的数据
        /// </summary>
        public void timingdata()//DateTime dt1, DateTime dt2
        {
            string StartDate = null;
            string EndDate = null;
            while (DateTime.Compare(dt1, dt2) < 0 && !stopbz)
            {
                StartDate = dt1.ToString();//开始时间
                dt1 = dt1.AddDays(1);
                EndDate = dt1.ToString();//结束时间

                update(StartDate, EndDate, tablename);
            }
            button1enable();
            btnUPenable();
            btnsotpfalse();
            MessageBox.Show("上报完成！");
        }
        //定时上传
        private void btnUP_cs_Click(object sender, EventArgs e)
        {
            //弹出确认对话框
            DialogResult dr = MessageBox.Show("确定要设定每天 " + UpTime.Value.ToString("HH:mm:ss") + " 上传数据至国家价格监测系统吗？", "提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            string updatetime = UpTime.Value.ToString("HH:mm:ss");
            //ConfigurationManager.AppSettings.Settings["updatetime"].Value
            Configuration con = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //int val = int.Parse(con.AppSettings.Settings["updatetime"].Value);
            //val = val * 2;
            //写入<add>元素的Value
            con.AppSettings.Settings["updatetime"].Value = updatetime;
            //一定要记得保存，写不带参数的config.Save()也可以
            con.Save(ConfigurationSaveMode.Modified);
            //刷新，否则程序读取的还是之前的值（可能已装入内存）
            System.Configuration.ConfigurationManager.RefreshSection("appSettings");
            //设定自动上传
            timer.Enabled = true;
        }

        private void ToolStripTc_Click(object sender, EventArgs e)
        {
            string content = string.Format("确认要退出 {0}", this.Text);
            string title = this.Text;
            if (MessageBox.Show(content, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                Application.Exit();

            }
        }

        //取消定时上传
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //弹出确认对话框
            DialogResult dr = MessageBox.Show("确定要取消设定每天 " + UpTime.Value.ToString("HH:mm:ss") + " 上传数据至国家价格监测系统吗？", "提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            UpTime.Value = Convert.ToDateTime("00:00:00");
            //string updatetime = UpTime.Value.ToString("HH:mm:ss");
            Configuration con = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //int val = int.Parse(con.AppSettings.Settings["updatetime"].Value);
            //val = val * 2;
            //写入<add>元素的Value
            con.AppSettings.Settings["updatetime"].Value = "";
            //一定要记得保存，写不带参数的config.Save()也可以
            con.Save(ConfigurationSaveMode.Modified);
            //刷新，否则程序读取的还是之前的值（可能已装入内存）
            System.Configuration.ConfigurationManager.RefreshSection("appSettings");
            //设定自动上传
            timer.Enabled = false;
        }

        //数据编辑
        private void 药品价格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTen f = new FrmTen();
            f.Owner = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.sql = "select  * from  interface_drug";
            DataTable dt = AppServer.SelData(f.sql);
            f.dt = dt;
            f.tablename = "interface_drug";
            f.ShowDialog();
        }

        private void 耗材价格编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTen f = new FrmTen();
            f.Owner = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.sql = "select  * from  interface_material";
            DataTable dt = AppServer.SelData(f.sql);
            f.dt = dt;
            f.tablename = "interface_material";
            f.ShowDialog();
        }

        private void 机构信息编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTen f = new FrmTen();
            f.Owner = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.sql = "select  * from  interface_orginfo";
            DataTable dt = AppServer.SelData(f.sql);
            f.dt = dt;
            f.tablename = "interface_orginfo";
            f.ShowDialog();
        }

        //服务价格编辑
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmTen f = new FrmTen();
            f.Owner = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.sql = "select  * from  interface_service";
            DataTable dt = AppServer.SelData(f.sql);
            f.dt = dt;
            f.tablename = "interface_service";
            f.ShowDialog();
        }

        //上月数据生成
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbtablename.SelectedItem == null)
                {
                    return;
                }
                //弹出确认对话框
                DialogResult dr = MessageBox.Show("确定要生成 " + cbbtablename.SelectedItem.ToString() + " xml文件吗？", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }

                stopbz = false;//暂停
                //按季度或者按月上传
                string StartDate = "";
                string EndDate = "";
                if (tablename == "interface_hospitalResourceVo" || tablename == "interface_hospitalBASY")
                {
                    StartDate = DateTime.Now.AddMonths(-3 - ((DateTime.Now.Month - 1) % 3)).AddDays(1 - DateTime.Now.Day).ToShortDateString();// 上季度第一天
                    EndDate = DateTime.Now.AddMonths(0 - ((DateTime.Now.Month - 1) % 3)).AddDays(1 - DateTime.Now.Day).AddDays(-1).ToShortDateString();// 上季度最后一天
                }
                else
                {
                    //先获取当前时间，然后循环遍历上个月每一天查询数据库生成报文上传
                    StartDate = DateTime.Now.AddMonths(-1).ToString("yyyy-MM") + "-01";//当前月的前一月
                    EndDate = DateTime.Now.ToString("yyyy-MM") + "-01";//当前月的第一天
                }
                dt1 = DateTime.Parse(StartDate);
                dt2 = DateTime.Parse(EndDate);
                //selecttime(dt1, dt2);
                Thread th = new Thread(selecttime_sd);
                th.IsBackground = true;
                th.Start();
                this.button2.Enabled = false;
                btnsotptrue();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //手动生成
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbtablename.SelectedItem == null)
                {
                    return;
                }
                //弹出确认对话框
                DialogResult dr = MessageBox.Show("确定要生成 " + cbbtablename.SelectedItem.ToString() + " xml文件吗？", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                stopbz = false;//暂停
                dt1 = dtpstart.Value.Date;
                dt2 = dtpend.Value.Date;
                Thread th = new Thread(selecttime_sd);
                th.IsBackground = true;
                th.Start();

                this.button3.Enabled = false;
                btnsotptrue();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //上月数据重新导入
        private void button4_Click(object sender, EventArgs e)
        {
            //开始结束日期
            try
            {
                if (cbbtablename.SelectedItem == null)
                {
                    return;
                }
                //弹出确认对话框
                DialogResult dr = MessageBox.Show("确定要重新导入 " + cbbtablename.SelectedItem.ToString() + " 的数据吗？", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }

                stopbz = false;//暂停
                //按季度或者按月上传
                string StartDate = "";
                string EndDate = "";
                if (tablename == "interface_hospitalResourceVo" || tablename == "interface_hospitalBASY")
                {
                    StartDate = DateTime.Now.AddMonths(-3 - ((DateTime.Now.Month - 1) % 3)).AddDays(1 - DateTime.Now.Day).ToShortDateString();// 上季度第一天
                    EndDate = DateTime.Now.AddMonths(0 - ((DateTime.Now.Month - 1) % 3)).AddDays(1 - DateTime.Now.Day).AddDays(-1).ToShortDateString();// 上季度最后一天
                }
                else
                {
                    //先获取当前时间，然后循环遍历上个月每一天查询数据库生成报文上传
                    StartDate = DateTime.Now.AddMonths(-1).ToString("yyyy-MM") + "-01";//当前月的前一月
                    EndDate = DateTime.Now.ToString("yyyy-MM") + "-01";//当前月的第一天
                }
                dt1 = DateTime.Parse(StartDate);
                dt2 = DateTime.Parse(EndDate);
                //selecttime(dt1, dt2);
                Thread th = new Thread(ExceProAgain);
                th.IsBackground = true;
                th.Start();
                this.button4.Enabled = false;
                btnsotptrue();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


            //根据表名判断调用不同的存储


        }

        //选择日期重新导入
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                if (cbbtablename.SelectedItem == null)
                {
                    return;
                }
                //弹出确认对话框
                DialogResult dr = MessageBox.Show("确定要重新导入 " + cbbtablename.SelectedItem.ToString() + " 的数据吗？", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }

                stopbz = false;//暂停
                dt1 = dtpstart.Value.Date;
                dt2 = dtpend.Value.Date;
                Thread th = new Thread(ExceProAgain);
                th.IsBackground = true;
                th.Start();

                this.button5.Enabled = false;
                btnsotptrue();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 根据选择的时间循环调用 存储过程 重新生成数据
        /// </summary>
        /// <param name="dt1">开始时间</param>
        /// <param name="dt2">结束时间</param>
        public void ExceProAgain()//DateTime dt1, DateTime dt2
        {
            try
            {
                string StartDate = null;
                string EndDate = null;
                if (tablename == "interface_hospitalResourceVo")//按季度
                {
                    while (DateTime.Compare(dt1, dt2) < 0 && !stopbz)
                    {
                        DateTime startQuarter = dt1.AddMonths(0 - (dt1.Month - 1) % 3).AddDays(1 - dt1.Day);  //本季度初
                        DateTime endQuarter = startQuarter.AddMonths(3).AddDays(-1);  //本季度末
                        StartDate = startQuarter.ToString("yyyy-MM-dd");// 选择日期那季度第一天
                        EndDate = endQuarter.ToString("yyyy-MM-dd");// 
                        dt1 = endQuarter.AddDays(1);

                        #region 测试代码
                        //string dt3 = Convert.ToInt32(Math.Ceiling((double)1 / (double)3)).ToString();
                        //string dt4 = Convert.ToInt32(Math.Ceiling((double)4 / (double)3)).ToString();
                        //string dt5 = Convert.ToInt32(Math.Ceiling((double)7 / (double)3)).ToString();
                        //string dt6 = Convert.ToInt32(Math.Ceiling((double)10 / (double)3)).ToString();
                        //int dt = (dtpstart.Value.Date.Month - 1) % 3;
                        #endregion
                        int Month = startQuarter.Month;
                        ExcePro(StartDate, Convert.ToInt32(Math.Ceiling((double)Month / (double)3)).ToString());
                    }
                }
                else
                {
                    while (DateTime.Compare(dt1, dt2) < 0 && !stopbz)
                    {
                        StartDate = dt1.ToString("yyyy-MM-dd");//开始时间
                        dt1 = dt1.AddDays(1);
                        EndDate = dt1.ToString("yyyy-MM-dd");//结束时间

                        ExcePro(StartDate, "");
                    }
                }


                MessageBox.Show("重新导入完成！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnsotpfalse();
            button4enable();
            button5enable();
        }

        //
        /// <summary>
        /// 根据日期和表名重新导入数据
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="quarter">季度 1 2 3 4</param>
        /// <param name="tablename"></param>
        public void ExcePro(string StartDate, string quarter)
        {
            try
            {
                LogHelper.WriteLog("选择重新导入表：" + cbbtablename.SelectedItem.ToString());
                //状态 0未上传 1 已上传
                string proname;
                switch (tablename)
                {
                    case "interface_drugPriceTraceVo":
                        proname = "Pro_wlpt_createdrug_ypjc";
                        break;
                    case "interface_materialPriceTraceVo":
                        proname = "Pro_wlpt_creatematerial_ypjc";
                        break;
                    case "interface_servicePriceTraceVo":
                        proname = "Pro_wlpt_createservice_ypjc";
                        break;
                    case "interface_hospitalResourceVo":
                        proname = "Pro_wlpt_createresource_ypjc";
                        break;
                    case "interface_hospitalBASY":
                        proname = "Pro_wlpt_createhospitalbasy_ypjc";
                        break;
                    default:
                        proname = "";
                        break;
                }
                if (string.IsNullOrEmpty(proname))
                {
                    return;
                }
                if (tablename == "interface_hospitalResourceVo")//按季度
                {
                    StartDate = StartDate.Substring(0, 4);//截取年的数字
                    AppServer.ExcePro(proname, StartDate, quarter);
                }
                else
                {
                    AppServer.ExcePro(proname, StartDate);
                }
                return;
            }
            catch (Exception ex)
            {

                MessageBox.Show("重新导入数据失败！错误信息描述：" + ex.Message);
                LogHelper.WriteLog("重新导入数据失败！错误信息描述：" + ex.Message);
            }

        }

        private void 国家科室编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTen f = new FrmTen();
            f.Owner = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.sql = "select  * from  interface_rc where type='rc038'";//
            DataTable dt = AppServer.SelData(f.sql);
            f.dt = dt;
            f.tablename = "interface_rc";
            f.ShowDialog();
        }



    }
}

using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Xml;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Oracle;
using System.Data.OleDb;
namespace PriceMonitoringSystem
{
    public class AppServer
    {
        public class ErrorMsg
        {
            int code;
            string message;
            public int Code
            {
                get { return code; }
                set { code = value; }
            }
            public string Message
            {
                get { return message; }
                set { message = value; }
            }
        }
        public static string UserID;
        public static int IniSetting(string time, string sccs_cs, string sccount_cs, string sccs_sd, string sccount_sd, string sccs_zd, string sccount_zd)
        {
            try
            {
                DataRow drSetting = null;
                DataSet dsSetting = new DataSet();
                dsSetting.ReadXml(System.Environment.CurrentDirectory + @"/SysSetup.xml");
                drSetting = dsSetting.Tables[0].Rows[0];
                drSetting["Uptime"] = time;
                drSetting["Sccs_cs"] = sccs_cs;
                drSetting["Sccount_cs"] = sccount_cs;
                drSetting["Sccs_sd"] = sccs_sd;
                drSetting["Sccount_sd"] = sccount_sd;
                drSetting["Sccs_zd"] = sccs_zd;
                drSetting["Sccount_zd"] = sccount_zd;
                dsSetting.WriteXml(System.Environment.CurrentDirectory + @"/SysSetup.xml");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public static string GetConn(string bz)
        {
            XmlDocument docSetup = new XmlDocument();
            docSetup.Load(System.Environment.CurrentDirectory + @"/SysSetup.xml");
            XmlNode node = null;
            if (bz == "sql")
            {
                node = docSetup.SelectSingleNode("System/Connection/SqlConnection");
            }
            if (bz == "oracle_zkr")
            {
                node = docSetup.SelectSingleNode("System/Connection/OracleConnection");
            }
            if (bz == "sqlpwd")
            {
                node = docSetup.SelectSingleNode("System/Connection/SqlPassword");
            }
            if (bz == "oracle_zkrpwd")
            {
                node = docSetup.SelectSingleNode("System/Connection/OraclePassword");
            }
            if (bz == "uptime")
            {
                node = docSetup.SelectSingleNode("System/Connection/Uptime");
            }
            if (bz == "xzqh")
            {
                node = docSetup.SelectSingleNode("System/Connection/Xzqh");
            }
            if (bz == "Sccs_cs")
            {
                node = docSetup.SelectSingleNode("System/Connection/Sccs_cs");
            }
            if (bz == "Sccount_cs")
            {
                node = docSetup.SelectSingleNode("System/Connection/Sccount_cs");
            }
            if (bz == "Sccs_sd")
            {
                node = docSetup.SelectSingleNode("System/Connection/Sccs_sd");
            }
            if (bz == "Sccount_sd")
            {
                node = docSetup.SelectSingleNode("System/Connection/Sccount_sd");
            }
            if (bz == "Sccs_zd")
            {
                node = docSetup.SelectSingleNode("System/Connection/Sccs_zd");
            }
            if (bz == "Sccount_zd")
            {
                node = docSetup.SelectSingleNode("System/Connection/Sccount_zd");
            }
            if (bz == "secretKey")
            {
                node = docSetup.SelectSingleNode("System/Connection/secretKey");
            }


            return node.InnerText;

        }

        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string sqlConnctionString
        {
            get
            {
                return GetConn("sql") + GetConn("sqlpwd");

            }
        }

        public static int UpdateState(string ID, string data_Source, DataTable dt)
        {
            SqlDatabase db = new SqlDatabase(GetConn("sql") + GetConn("sqlpwd"));
            string update_table = dt.Rows[0]["update_table"].ToString();
            string update_Field = dt.Rows[0]["update_Field"].ToString();
            string update_result = dt.Rows[0]["update_result"].ToString();
            string sql = "";
            if (update_table == "PatientReg")
                sql = "update " + update_table + " set " + update_Field + "='" + update_result + "' where MedicalService_no='" + ID + "'";
            else
                sql = "update " + update_table + " set " + update_Field + "='" + update_result + "' where ID='" + ID + "'";
            DbCommand cmd = db.GetSqlStringCommand(sql);
            cmd.CommandTimeout = 600000;
            int a = db.ExecuteNonQuery(cmd);
            cmd.Connection.Close();
            return a;
        }
        public static void InsertErr(string err, DateTime up_sj, string bh, string tablename, string xml_ret)
        {
            SqlDatabase db = new SqlDatabase(GetConn("sql") + GetConn("sqlpwd"));
            string sql = "insert into data_up_error_log(msg_error,up_sj,data_bh,data_type,xml_ret) values('" + err.Replace("'", "") + "','" + up_sj + "','" + bh + "','" + tablename + "','" + xml_ret + "')";
            DbCommand cmd = db.GetSqlStringCommand("insert into data_up_error_log(data_up_from,xml_text,msg_error,up_sj,data_bh,data_type,xml_ret) values('接口',' ','" + err.Replace("'", "") + "','" + up_sj + "','" + bh + "','" + tablename + "','" + xml_ret + "')");
            cmd.CommandTimeout = 600000;
            db.ExecuteNonQuery(cmd);
            cmd.Connection.Close();
        }

        //插入日志
        public static void InsertUpLog(string UpModel, string TableName, int CycleNum, string BeginTime, string EndTime, int SuccessCount, int FailureCount)
        {
            SqlDatabase db = new SqlDatabase(GetConn("sql") + GetConn("sqlpwd"));
            string sql = "insert into data_up_log(UpModel,TableName,CycleNum,BeginTime,EndTime,SuccessCount,FailureCount) values('"
                + UpModel + "','" + TableName + "','" + CycleNum.ToString() + "','" + BeginTime + "','" + EndTime + "','" + SuccessCount.ToString()
                + "','" + FailureCount.ToString() + "')";
            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.ExecuteNonQuery(cmd);
        }

        //查询日志
        public static DataTable SelUpLog(DateTime BeginTime, DateTime EndTime, string UpModel, string TableName)
        {
            SqlDatabase db = new SqlDatabase(GetConn("sql") + GetConn("sqlpwd"));
            DbCommand cmd = db.GetStoredProcCommand("proc_sys_scrzcx");
            db.AddInParameter(cmd, "@beginTime", SqlDbType.DateTime, BeginTime);
            db.AddInParameter(cmd, "@endTime", SqlDbType.DateTime, EndTime);
            db.AddInParameter(cmd, "@UpModel", SqlDbType.VarChar, UpModel);
            db.AddInParameter(cmd, "@TableName", SqlDbType.VarChar, TableName);
            return db.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable SelData(string sql)
        {
            SqlDatabase db = new SqlDatabase(GetConn("sql") + GetConn("sqlpwd"));
            DbCommand cmd = db.GetSqlStringCommand(sql);
            cmd.CommandTimeout = 600000;
            DataTable dt = db.ExecuteDataSet(cmd).Tables[0];
            return dt;
        }
        public static int QueryData(string sql)
        {
            SqlDatabase db = new SqlDatabase(GetConn("sql") + GetConn("sqlpwd"));
            DbCommand cmd = db.GetSqlStringCommand(sql); cmd.CommandTimeout = 600000;
            cmd.CommandTimeout = 600000;
            int a = db.ExecuteNonQuery(cmd);
            cmd.Connection.Close();
            return a;
        }
        public static int QueryData_qzj(string sql)
        {
            OracleDatabase db = new OracleDatabase(GetConn("oracle_zkr") + JM.Decryption(GetConn("oracle_zkrpwd")));
            //SqlDatabase db = new SqlDatabase(GetConn("oracle_zkr") + JM.Decryption(GetConn("oracle_zkrpwd")));
            DbCommand cmd = db.GetSqlStringCommand(sql);
            cmd.CommandTimeout = 600000;
            int a = db.ExecuteNonQuery(cmd);
            cmd.Connection.Close();
            return a;
        }
        public static DataTable zbcx(string userid, string dt, string options)
        {
            SqlDatabase db = new SqlDatabase(GetConn("sql") + GetConn("sqlpwd"));
            DbCommand cmd = db.GetStoredProcCommand("proc_ten_cxgl");
            db.AddInParameter(cmd, "@userid", SqlDbType.VarChar, userid);
            db.AddInParameter(cmd, "@dt", SqlDbType.VarChar, dt);
            db.AddInParameter(cmd, "@options", SqlDbType.VarChar, options);
            cmd.CommandTimeout = 600000;
            DataTable dt1 = db.ExecuteDataSet(cmd).Tables[0];
            cmd.Connection.Close();
            return dt1;
        }
        public static ErrorMsg zbxg(string dt, string zbbm, string item, string options)
        {
            AppServer.ErrorMsg err = new ErrorMsg();
            SqlDatabase db = new SqlDatabase(GetConn("sql") + GetConn("sqlpwd"));
            DbCommand cmd = db.GetStoredProcCommand("proc_ten_xggl");
            db.AddInParameter(cmd, "@dt", SqlDbType.VarChar, dt);
            db.AddInParameter(cmd, "@zbbm", SqlDbType.VarChar, zbbm);
            db.AddInParameter(cmd, "@item", SqlDbType.VarChar, item);
            db.AddInParameter(cmd, "@options", SqlDbType.VarChar, options);

            db.AddOutParameter(cmd, "@errcode", DbType.Int32, 4);
            db.AddOutParameter(cmd, "@msg", DbType.String, 50);

            db.ExecuteNonQuery(cmd);

            // 取得输出型参数的值
            err.Code = (int)db.GetParameterValue(cmd, "@errcode");
            err.Message = (string)db.GetParameterValue(cmd, "@msg");
            cmd.Connection.Close();
            // 返回执行信息
            return err;
        }
        public static DataTable sjcx(string type, string options)
        {
            SqlDatabase db = new SqlDatabase(GetConn("sql") + GetConn("sqlpwd"));
            //DbCommand cmd = db.GetStoredProcCommand("proc_sys_cxgl");
            //db.AddInParameter(cmd, "@cs", SqlDbType.VarChar, cs);
            //db.AddInParameter(cmd, "@options", SqlDbType.VarChar, options);
            string sql = "select code as  bm ,value as mc from interface_rc where type='" + type + "'";
            DataTable dt1 = null;
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);

                cmd.CommandTimeout = 600000;
                dt1 = db.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {

            }
            return dt1;
        }

        public static DataTable getksjbxx()
        {
            SqlDatabase db = new SqlDatabase(GetConn("sql") + GetConn("sqlpwd"));
            //DbCommand cmd = db.GetStoredProcCommand("proc_sys_cxgl");
            //db.AddInParameter(cmd, "@cs", SqlDbType.VarChar, cs);
            //db.AddInParameter(cmd, "@options", SqlDbType.VarChar, options);
            string sql = "  SELECT  ksjbxx_bmchr as bm,ksjbxx_mcchr as mc,ksjbxx_zjm1chr as pym FROM jc..jcjc_tb_ksjbxx ";
            DbCommand cmd = db.GetSqlStringCommand(sql);

            cmd.CommandTimeout = 600000;
            DataTable dt1 = db.ExecuteDataSet(cmd).Tables[0];
            return dt1;
        }

        public static DataTable getdzxx(string type)
        {
            SqlDatabase db = new SqlDatabase(GetConn("sql") + GetConn("sqlpwd"));
            string sql = null;
            switch (type)
            {
                case "ks"://科室对照
                    //sql = "  SELECT  a.ksjbxx_bmchr as bm,a.ksjbxx_mcchr as mc,a.ksjbxx_zjm1chr as pym FROM jc..jcjc_tb_ksjbxx a";
                    sql = "  SELECT  a.ksjbxx_bmchr as bm,a.ksjbxx_mcchr as mc,a.ksjbxx_zjm1chr as pym,b.code as code ,b.value as value FROM jc..jcjc_tb_ksjbxx a left join ( SELECT * FROM  interface_rc where type='rc038' AND HISCODE IS NOT NULL) b on a.ksjbxx_bmchr=b.hiscode ";
                    break;
                case "mz"://麻醉
                    //sql = "  SELECT  Fbh as bm, Fdesc as mc, Fpym as pym FROM zy..Twh_mzfs ";
                    sql = "  SELECT  a.Fbh as bm, a.Fdesc as mc, a.Fpym as pym,b.code as code ,b.value as value  FROM zy..Twh_mzfs a  left join ( SELECT * FROM  interface_rc where type='rc041' AND HISCODE IS NOT NULL) b on a.Fbh=b.hiscode ";

                    break;
                case "org"://麻醉
                    sql = "  SELECT  orgCode as bm, hospName as mc FROM interface_orginfo ";
                    break;
                default:
                    break;
            }
            DbCommand cmd = db.GetSqlStringCommand(sql);

            cmd.CommandTimeout = 600000;
            DataTable dt1 = db.ExecuteDataSet(cmd).Tables[0];
            return dt1;
        }

        public static DataTable getdatatble(string sql)
        {
            SqlDatabase db = new SqlDatabase(GetConn("sql") + GetConn("sqlpwd"));
            //DbCommand cmd = db.GetStoredProcCommand("proc_sys_cxgl");
            //db.AddInParameter(cmd, "@cs", SqlDbType.VarChar, cs);
            //db.AddInParameter(cmd, "@options", SqlDbType.VarChar, options);
            DbCommand cmd = db.GetSqlStringCommand(sql);

            cmd.CommandTimeout = 600000;
            DataTable dt1 = db.ExecuteDataSet(cmd).Tables[0];
            return dt1;
        }



        public static int qxgl(string userid, string gnbm, string lx, string options)
        {
            SqlDatabase db = new SqlDatabase(GetConn("sql") + GetConn("sqlpwd"));
            DbCommand cmd = db.GetStoredProcCommand("proc_sys_qxgl");
            db.AddInParameter(cmd, "@userid", SqlDbType.VarChar, userid);
            db.AddInParameter(cmd, "@gnbm", SqlDbType.VarChar, gnbm);
            db.AddInParameter(cmd, "@lx", SqlDbType.VarChar, lx);
            db.AddInParameter(cmd, "@options", SqlDbType.VarChar, options);
            int a = db.ExecuteNonQuery(cmd);
            cmd.Connection.Close();
            return a;
        }

        public static int ExcePro(string proname, string date)
        {
            SqlDatabase db = new SqlDatabase(GetConn("sql") + GetConn("sqlpwd"));
            DbCommand cmd = db.GetStoredProcCommand(proname);
            db.AddInParameter(cmd, "@date", SqlDbType.VarChar, date);
            db.AddOutParameter(cmd, "@ErrMsg", SqlDbType.VarChar, 500);
            int a = db.ExecuteNonQuery(cmd);
            cmd.Connection.Close();
            return a;
        }
        //服务资源按季度生成
        public static int ExcePro(string proname, string year, string quarter)
        {
            SqlDatabase db = new SqlDatabase(GetConn("sql") + GetConn("sqlpwd"));
            DbCommand cmd = db.GetStoredProcCommand(proname);
            db.AddInParameter(cmd, "@year", SqlDbType.VarChar, year);
            db.AddInParameter(cmd, "@quarter", SqlDbType.VarChar, quarter);
            db.AddOutParameter(cmd, "@ErrMsg", SqlDbType.VarChar, 500);
            int a = db.ExecuteNonQuery(cmd);
            cmd.Connection.Close();
            return a;
        }


        public static int ExecuteNonQuery(string sql)
        {
            SqlDatabase db = new SqlDatabase(GetConn("sql") + GetConn("sqlpwd"));
            //string sql = "insert into data_up_error_log(msg_error,up_sj,data_bh,data_type,xml_ret) values('" + err.Replace("'", "") + "','" + up_sj + "','" + bh + "','" + tablename + "','" + xml_ret + "')";
            DbCommand cmd = db.GetSqlStringCommand(sql);
            cmd.CommandTimeout = 600000;
            int a = db.ExecuteNonQuery(cmd);
            cmd.Connection.Close();
            return a;
        }

        //public static int Executedatatable(string sql)
        //{
        //    SqlDatabase db = new SqlDatabase(GetConn("sql") + GetConn("sqlpwd"));
        //    DbCommand cmd = db.(sql);
        //    cmd.CommandTimeout = 600000;
        //    int a = db.ExecuteNonQuery(cmd);
        //    cmd.Connection.Close();
        //    return a;
        //}

        //导入的文件导入数据库中
        public static bool insertdatatable(DataTable dt, string tablename)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append(" insert into " + tablename + "  values(  ");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        //if (string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                        //{
                        //    sb.Append("' ',");
                        //}
                        //else
                        //{
                        sb.Append("'" + dt.Rows[i][j].ToString() + "',");
                        //}

                    }
                    sb.Remove(sb.Length - 1, 1);
                    sb.Append(" ); ");

                }
                if (ExecuteNonQuery(sb.ToString()) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                return false;
            }

            //foreach (var row in dt.Rows)
            //{

            //    sb.Append(" insert into " + tablename + "  values( ) ");
            //}

        }

        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="tablename"></param>
        /// <param name="columns">第几列转为int型</param>
        /// <returns></returns>
        public static bool insertdatatable(DataTable dt, string tablename, int columns, int columnscount)
        {

            StringBuilder sb = new StringBuilder();
            string tmp;
            //查询表临时码
            long lsm = getlsm();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append(" insert into " + tablename + "  values(  ");
                for (int j = 0; j < columnscount; j++)
                {
                    //国家编码为空的 未对照上的自动生成临时码
                    if (tablename == "interface_drug" && j == 0)
                    {
                        if (string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                        {
                            //临时码赋值
                            sb.Append("'LS" + lsm + "',");
                            lsm++;
                            continue;
                        }
                    }
                    else if (tablename == "interface_service" && j == 1)//医疗服务依据名称
                    {
                        if (string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                        {
                            sb.Append("'" + dt.Rows[i - 1][j].ToString() + "',");
                            lsm++;
                            continue;
                        }
                    }
                    else if (tablename == "interface_service" && j == 2)//地方收费标准编码为ls生成
                    {
                        if (string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                        {
                            //临时码赋值
                            sb.Append("'LS" + lsm + "',");
                            lsm++;
                            continue;
                        }
                    }
                    else if (tablename == "interface_service" && j == 3)//地方收费标准服务名称
                    {
                        if (string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                        {
                            sb.Append("'" + dt.Rows[i][5].ToString() + "',");
                            lsm++;
                            continue;
                        }
                    }
                    else if (tablename == "interface_service" && j == 11)//全国服务价格编码
                    {
                        if (string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                        {
                            if (dt.Rows[i][2].ToString().Contains("LS"))//地方收费标准编码为ls生成 则全国服务价格编码生成相同编码
                            {
                                sb.Append("'" + dt.Rows[i][2].ToString() + "',");
                            }
                            else
                            {
                                //临时码赋值
                                sb.Append("'LS" + lsm + "',");
                                lsm++;
                            }
                            continue;
                        }
                    }
                    else if (tablename == "interface_material" && j == 0)//高值耗材统一标识码
                    {
                        if (string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                        {
                            //临时码赋值
                            sb.Append("'LS" + lsm + "',");
                            lsm++;
                            continue;
                        }
                    }



                    //转换系数列转为int
                    if (j == columns)
                    {
                        try
                        {
                            //string a = dt.Rows[i][j].ToString();
                            sb.Append("'" + Convert.ToInt32(dt.Rows[i][j].ToString() == "" ? null : dt.Rows[i][j].ToString()) + "',");
                        }
                        catch
                        {
                            sb.Append("'0',");
                        }
                    }
                    else
                    {
                        //if (string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                        //{
                        //    sb.Append("' ',");
                        //}
                        //else
                        //{
                        //替换文中的’为中文‘
                        tmp = dt.Rows[i][j].ToString().Contains("\'") ? dt.Rows[i][j].ToString().Replace('\'', '’') : dt.Rows[i][j].ToString();
                        sb.Append("'" + tmp + "',");
                        //}
                    }
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append(" ); ");

            }
            if (ExecuteNonQuery(sb.ToString()) > 0)
            {
                //更新表临时码 自增1
                if (lsm > getlsm())
                {
                    ExecuteNonQuery("update interface_orginfo set lsm='LS" + lsm + "'");
                }
                return true;
            }
            else
            {
                return false;
            }

        }
        //获取lsm
        private static long getlsm()
        {
            //查询表临时码
            DataTable dtlsm = getdatatble("select top 1 lsm from interface_orginfo");

            //赋值
            string lsm = dtlsm.Rows[0][0].ToString();
            long lsmtemp = Convert.ToInt64(lsm.Substring(2, lsm.Length - 2));
            return lsmtemp;
            //更新表临时码 自增1

        }


    }
}

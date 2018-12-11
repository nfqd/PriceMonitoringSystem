using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace PriceMonitoringSystem
{
    class DictComp
    {
        #region 增加字典对照主记录 Add
        /// <summary>
        /// 增加一条数据
        /// </summary>
        //public bool Add(Model.DictComp model)
        //{
        //    SqlDatabase db = new SqlDatabase(AppServer.sqlConnctionString);
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("insert into DictComp(");
        //    strSql.Append("Hos_org_code,ID,Local_dict_id,Local_dict_name,Local_dict_version,Standard_dict_id,Standard_dict_name,Standard_dict_version,Begin_date,Unuse_mark,Createtime,Lastuptime,State,field_pk,field_pk_fk");
        //    strSql.Append(")");
        //    strSql.Append(" values (");
        //    strSql.Append("'" + model.Hos_org_code + "',");
        //    strSql.Append("'" + model.ID + "',");
        //    strSql.Append("'" + model.Local_dict_id + "',");
        //    strSql.Append("'" + model.Local_dict_name + "',");
        //    strSql.Append("'" + model.Local_dict_version + "',");
        //    strSql.Append("'" + model.Standard_dict_id + "',");
        //    strSql.Append("'" + model.Standard_dict_name + "',");
        //    strSql.Append("'" + model.Standard_dict_version + "',");
        //    strSql.Append("'" + model.Begin_date + "',");
        //    //strSql.Append("'" + model.End_date + "',");
        //    strSql.Append("'" + model.Unuse_mark + "',");
        //    strSql.Append("'" + model.Createtime + "',");
        //    strSql.Append("'" + model.Lastuptime + "',");
        //    strSql.Append("'" + model.State + "',");
        //    strSql.Append("'" + model.Hos_org_code + model.ID + "',");
        //    strSql.Append("'" + model.Hos_org_code + model.ID + "'");
        //    strSql.Append(")");
        //    DbCommand cmd = db.GetSqlStringCommand(strSql.ToString());
        //    int icount = db.ExecuteNonQuery(cmd);

        //    return icount > 0 ? true : false;


        //}

        public bool Add(List<interface_rcmodel> list)
        {
            int icount = 0;
            try
            {
                SqlDatabase db = new SqlDatabase(AppServer.sqlConnctionString);
                StringBuilder strSql = new StringBuilder();
                
                foreach (interface_rcmodel m in list)
                {
                    strSql.Append("update interface_rc set hiscode ='" + m.hiscode + "',hisname='" + m.hisname + "' where code='" + m.code + "' and value='" + m.value + "' and type='" + m.type + "' ;");

                }
                DbCommand cmd = db.GetSqlStringCommand(strSql.ToString());
                icount = db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                //errMsg = ex.Message;
                
                return false;
            }


            return icount > 0 ? true : false;
        }

        //public bool AddDict(Model.DictComp model, List<interface_rcmodel> list, out string errMsg)
        //{
        //    Dal.compare.DictComp objDict = new Dal.compare.DictComp();
        //    errMsg = "";

        //    using (System.Transactions.TransactionScope scope = new System.Transactions.TransactionScope())
        //    {
        //        try
        //        {
        //            objDict.Delete(model.Hos_org_code, model.ID);
        //            bool isSuc = objDict.Add(model);
        //            if (isSuc == false)
        //            {
        //                throw new Exception("添加字典对照主记录(DictComp)失败！");
        //            }
        //            objDict.DeleteDetail(model.Hos_org_code, model.ID);

        //            foreach (interface_rcmodel m in list)
        //            {
        //                objDict.AddDetail(m);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            errMsg = ex.Message;
        //            return false;
        //        }
        //        scope.Complete();

        //        return true;
        //    }

        //}



        #endregion
        #region 更新主记录 Update
        /// <summary>
        /// 更新一条数据
        /// </summary>
        //public bool Update(Model.DictComp model)
        //{
        //    SqlDatabase db = new SqlDatabase(AppServer.sqlConnctionString);
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update DictComp set ");
        //    strSql.Append("Local_dict_id='" + model.Local_dict_id + "',");
        //    strSql.Append("Local_dict_name='" + model.Local_dict_name + "',");
        //    strSql.Append("Local_dict_version='" + model.Local_dict_version + "',");
        //    strSql.Append("Standard_dict_id='" + model.Standard_dict_id + "',");
        //    strSql.Append("Standard_dict_name='" + model.Standard_dict_name + "',");
        //    strSql.Append("Standard_dict_version='" + model.Standard_dict_version + "',");
        //    strSql.Append("Begin_date='" + model.Begin_date + "',");
        //    strSql.Append("End_date='" + model.End_date + "',");
        //    strSql.Append("Unuse_mark=" + model.Unuse_mark + ",");
        //    strSql.Append("Createtime='" + model.Createtime + "',");
        //    strSql.Append("Lastuptime='" + model.Lastuptime + "',");
        //    strSql.Append("State=" + model.State + "");
        //    strSql.Append(" where Hos_org_code='" + model.Hos_org_code + "' and ID='" + model.ID + "' ");
        //    DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
        //    int icount = db.ExecuteNonQuery(dbCommand);

        //    return icount > 0 ? true : false;
        //}
        #endregion
        #region  删除一条数据Delete
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string Hos_org_code, string ID)
        {
            SqlDatabase db = new SqlDatabase(AppServer.sqlConnctionString);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DictComp ");
            strSql.Append(" where Hos_org_code='" + Hos_org_code + "' and ID='" + ID + "' ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            int rows = db.ExecuteNonQuery(dbCommand);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion  Method


        /// <summary>
        /// 增加一条数据
        /// </summary>
        //public bool AddDetail(interface_rcmodel model)
        //{
        //    SqlDatabase db = new SqlDatabase(AppServer.sqlConnctionString);

        //    DbCommand dbCommand = db.GetStoredProcCommand("PROC_SYS_dict");

        //    db.AddInParameter(dbCommand, "@Hos_org_code", SqlDbType.VarChar, model.Hos_org_code);
        //    db.AddInParameter(dbCommand, "@ID", SqlDbType.VarChar, model.ID);
        //    db.AddInParameter(dbCommand, "@DictID", SqlDbType.VarChar, model.DictID);
        //    db.AddInParameter(dbCommand, "@Local_dict_code", SqlDbType.VarChar, model.Local_dict_code);
        //    db.AddInParameter(dbCommand, "@Local_dict_value", SqlDbType.VarChar, model.Local_dict_value);
        //    db.AddInParameter(dbCommand, "@Standard_dict_code", SqlDbType.VarChar, model.Standard_dict_code);
        //    db.AddInParameter(dbCommand, "@Standard_dict_value", SqlDbType.VarChar, model.Standard_dict_value);
        //    db.AddInParameter(dbCommand, "@OpteionType", SqlDbType.VarChar, "1");

        //    int icount = db.ExecuteNonQuery(dbCommand);

        //    return icount > 0 ? true : false;
        //}

        /// <summary>
        /// 更新一条数据
        /// </summary>
        //public bool UpdateDetail(interface_rcmodel model)
        //{
        //    SqlDatabase db = new SqlDatabase(AppServer.sqlConnctionString);
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update DictCompDetail set ");
        //    strSql.Append("DictID='" + model.DictID + "',");
        //    strSql.Append("Local_dict_code='" + model.Local_dict_code + "',");
        //    strSql.Append("Local_dict_value='" + model.Local_dict_value + "',");
        //    strSql.Append("Standard_dict_code='" + model.Standard_dict_code + "',");
        //    strSql.Append("Standard_dict_value='" + model.Standard_dict_value + "',");
        //    strSql.Append("Createtime='" + model.Createtime + "',");
        //    strSql.Append("Lastuptime='" + model.Lastuptime + "',");
        //    strSql.Append("State=" + model.State + "");
        //    strSql.Append(" where Hos_org_code='" + model.Hos_org_code + "' and ID='" + model.ID + "' ");
        //    DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
        //    int icount = db.ExecuteNonQuery(dbCommand);
        //    return icount > 0 ? true : false;

        //}

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteDetail(string Hos_org_code, string ID)
        {
            SqlDatabase db = new SqlDatabase(AppServer.sqlConnctionString);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DictCompDetail ");
            strSql.Append(" where Hos_org_code='" + Hos_org_code + "' and DictID='" + ID + "' ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            int rows = db.ExecuteNonQuery(dbCommand);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region 根据查询条件得到对照明细GetDictList
        /// <summary>
        /// 
        /// 根据查询条件得到对照明细
        /// 
        /// </summary>
        /// <param name="sqlFilter"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public DataTable GetDictList(string sqlFilter, string orderby)
        {
            string strsql = "select * from DictCompDetail where 1=1  ";

            if (sqlFilter != "")
            {
                strsql += (" and " + sqlFilter);

            }

            if (orderby != "")
            {
                strsql += orderby;
            }
            SqlDatabase db = new SqlDatabase(AppServer.sqlConnctionString);
            DbCommand dbCommand = db.GetSqlStringCommand(strsql.ToString());
            DataSet ds = db.ExecuteDataSet(dbCommand);

            if (ds != null && ds.Tables.Count != 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return new DataTable();
            }
        }

        #endregion





    }
}

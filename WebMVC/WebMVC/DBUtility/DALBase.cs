using Caxa.Project.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebMVC.Common;

namespace WebMVC.DBUtility
{
    public class DALBase
    {
        public DataSet GetDataBySql(string ConnectionStringName, string Sql)
        {
            try
            {
                return DbHelperMySQL.Query(ConnectionStringName, Sql);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("获取数据基类出现异常！", ex);
                return null;
            }
        }
    }
}
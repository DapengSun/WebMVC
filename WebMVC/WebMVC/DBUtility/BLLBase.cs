using Caxa.Project.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using WebMVC.Common;

namespace WebMVC.DBUtility
{
    public class BLLBase
    {
        DALBase _dalBase = new DALBase();
        static public bool _OPEN_CACHE = Convert.ToBoolean(ConfigurationManager.AppSettings["OpenCache"]);

        /// <summary>
        /// 通过SQL获得数据（带缓存）
        /// </summary>
        /// <param name="ConnectionStringName"></param>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public DataSet GetDataBySql(string ConnectionStringName,string Sql,string TableName) {
            try
            {
                string Key = string.Join("/", ConnectionStringName, "TableName=" + TableName, Sql);
                if (_OPEN_CACHE)
                {
                    var ResObj = RedisHelper.GetMemByDataSet(Key);
                    if (ResObj != null)
                    {
                        return (DataSet)ResObj;
                    }
                    else
                    {
                        var ObjDataSet = _dalBase.GetDataBySql(ConnectionStringName,Sql);
                        if (ObjDataSet != null && ObjDataSet.Tables[0].Rows.Count > 0)
                        {
                            RedisHelper.SetMemByDataSet(Key, ObjDataSet, 60);
                        }
                        return ObjDataSet;
                    }
                }
                else
                {
                    var ObjDataSet = _dalBase.GetDataBySql(ConnectionStringName, Sql);
                    return ObjDataSet;
                }
            }
            catch (Exception ex) {
                LogHelper.WriteLog("获取数据基类出现异常！", ex);
                return null;
            }
        }
    }
}
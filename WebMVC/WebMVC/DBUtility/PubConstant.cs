using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebMVC.DBUtility
{
    public class PubConstant
    {
        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MysqlConnection"].ToString();
            //解密连接串
            //string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
            //if (ConStringEncrypt == "true")
            //{
            //    connectionString = DESEncrypt.Decrypt(connectionString);
            //}
            return connectionString;
        }
    }
}
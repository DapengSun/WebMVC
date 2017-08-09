using Caxa.Project.Common;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebMVC.DBUtility;

namespace WebMVC.BLL
{
    public class TestRedis
    {
        BLLBase _bllBase = new BLLBase();
        public class NewClass{
            public string name { get; set; }
            public string id { get; set; }
        }
        public void TestValue() {
            try
            {
                string Sql = "select * from douban_toprankfilm limit 0,100";
                DataSet Ds = _bllBase.GetDataBySql("MysqlConnection", Sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
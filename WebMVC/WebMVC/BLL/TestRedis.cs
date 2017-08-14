using Caxa.Project.Common;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebMVC.Common;
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
                //string Sql = "select * from douban_toprankfilm limit 0,100";
                //DataSet Ds = _bllBase.GetDataBySql("MysqlConnection", Sql, "douban_toprankfilm");

                //List<string> _redisKeysList = RedisHelper.CommonPreKeyExist("douban_toprankfilm");

                string a = "1";
                string b = "0";
                int c = int.Parse(a) / int.Parse(b);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
using Caxa.Project.Common;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebMVC.Common;
using WebMVC.DBUtility;

namespace WebMVC.BLL
{
    public class TestRedis
    {
        BLLBase _bllBase = new BLLBase();

        public void TestValue() {
            string a = "0";
            string b = "0";
            int c = int.Parse(a) / int.Parse(b);
        }
    }
}
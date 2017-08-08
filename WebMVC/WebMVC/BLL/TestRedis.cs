using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebMVC.BLL
{
    public class TestRedis
    {
        public class NewClass{
            public string name { get; set; }
            public string id { get; set; }
        }
        public void TestValue() {
            try
            {
                //Common.RedisHelper.ItemSet<string>("NEW_KEY", "123321");
                //string tt = Common.RedisHelper.ItemGet<string>("NEW_KEY");

                //var cc = new
                //{
                //    test1 = "123",
                //    test2 = "456",
                //    test3 = "789"
                //};

                //NewClass _newClass = new NewClass
                //{
                //    name = "sun",
                //    id = "666"
                //};

                //string Json_cc = JsonConvert.SerializeObject(cc);

                //string Json_newClass = JsonConvert.SerializeObject(_newClass);

                //DataTable _dt = new DataTable();
                //_dt.Columns.Add("TestCol", typeof(string));
                //DataSet _ds = new DataSet();
                //DataRow dr = _dt.NewRow();
                //dr["TestCol"] = "TestColValue";
                //_dt.Rows.Add(dr);
                //_ds.Tables.Add(_dt);

                //DataSet _ds1 = _ds.Clone();


                //Common.RedisHelper.ItemSet<string>("Json_cc", Json_cc);
                //Common.RedisHelper.ItemSet<string>("Json_newClass", Json_newClass);
                //Common.RedisHelper.SetMemByDataSet("DS", _ds,60);
                //Common.RedisHelper.ItemSet<NewClass>("_newClass", _newClass);
                //DataSet Ds = Common.RedisHelper.GetMemByDataSet("DS");
                //string Json_cc_after = Common.RedisHelper.ItemGet<string>("Json_cc");
                //string Json_newClass_after = Common.RedisHelper.ItemGet<string>("Json_newClass");
                //NewClass _newClass_after = Common.RedisHelper.ItemGet<NewClass>("_newClass");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
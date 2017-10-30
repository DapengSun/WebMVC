using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WebMVC.Common;
using WebMVC.DAL;
using WebMVC.Models;

namespace WebMVC.BLL
{
    public class MainBLL
    {
        static public bool _OPEN_CACHE = Convert.ToBoolean(ConfigurationManager.AppSettings["OpenCache"]);
        MainDAL _Dal = new MainDAL();
        Object _Obj = new Object();

        public int GetPV(string Key) {
            int PVNum = 0;
            if (true)
            {
                PVNum = RedisHelper.ItemGet<int>(Key);
                if (PVNum != 0)
                {
                    return PVNum;
                }
                else
                {
                    //读取数据库PV值
                    Statistics PVObj = _Dal.Get();

                    //初始值创建
                    if (PVObj != null)
                    {
                        PVNum = PVObj.PV;
                    }
                    else {
                        Statistics _Statistics = new Statistics
                        {
                            Id = ToolMethod.GetGuid(),
                            PV = 0,
                            UV = 0
                        };
                        AddPV(_Statistics);
                    }
                    
                    RedisHelper.ItemSet<int>(Key, PVNum);
                    //过期时间为1分钟
                    RedisHelper.CommonSetExpire(Key, DateTime.Now.AddMinutes(1));
                    return PVNum;
                }
            }
            else {
                return 0;
            }
        }

        /// <summary>
        /// 更新PV
        /// </summary>
        public bool UpdatePV() {
            lock(_Obj)
            { 
                Statistics _Statistics = _Dal.Get();
                _Statistics.PV++;
                return _Dal.Update(_Statistics);
            }
        }

        /// <summary>
        /// 添加PV
        /// </summary>
        public bool AddPV(Statistics _Statistics) {
            return _Dal.Add(_Statistics);
        }
    }
}
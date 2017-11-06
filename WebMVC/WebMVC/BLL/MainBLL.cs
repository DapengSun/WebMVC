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
                    Statistics PVObj = _Dal.GetPV();

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
                Statistics _Statistics = _Dal.GetPV();
                _Statistics.PV++;
                return _Dal.UpdatePV(_Statistics);
            }
        }

        /// <summary>
        /// 添加PV
        /// </summary>
        public bool AddPV(Statistics _Statistics) {
            return _Dal.AddPV(_Statistics);
        }

        /// <summary>
        /// 获取BTC比特币价格
        /// </summary>
        /// <returns></returns>
        public List<BTC_Price_Statistics> GetBTCPrice()
        {
            return _Dal.GetBTCPrice();
        }
    }
}
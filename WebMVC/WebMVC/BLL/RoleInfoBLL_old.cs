using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Common;
using WebMVC.DAL;
using WebMVC.Models;

namespace WebMVC.BLL
{
    public class RoleInfoBLL_old
    {
        public RoleInfoDAL _roleInfoDal = new RoleInfoDAL();

        public bool Add(RoleInfo _RoleInfo)
        {
            return _roleInfoDal.Add(_RoleInfo);
        }

        public bool Update(RoleInfo _RoleInfo)
        {
            return _roleInfoDal.Update(_RoleInfo);
        }

        public bool Delete(RoleInfo _RoleInfo)
        {
            return _roleInfoDal.Delete(_RoleInfo);
        }

        public RoleInfo Get(string Id)
        {
            //return _roleInfoDal.Get(Id);
            return null;
        }

        /// <summary>
        /// 从缓存中角色列表 未命中 则读取数据库存放至缓存
        /// </summary>
        /// <param name="IsCache">是否从缓存中读取数据</param>
        /// <returns></returns>
        public List<RoleInfo> GetAll(bool IsCache)
        {
            string RoleKey = "RoleList";
            string RoleListString = string.Empty;

            //IsCache
            //false  重新读取数据
            //true   从缓存中读取数据
            if (!IsCache)
            {
                RedisHelper.CommonRemove("RoleList");
            }

            RoleListString = RedisHelper.ItemGet<string>(RoleKey);
            if (RoleListString != null)
            {
                return JsonHelper.DeserializeJsonToList<RoleInfo>(RoleListString);
            }
            else
            {
                //List<RoleInfo> _roleInfoList = _roleInfoDal.GetAll();
                List<RoleInfo> _roleInfoList = null;

                if (_roleInfoList.Count > 0)
                {
                    RoleListString = JsonHelper.SerializeObject(_roleInfoList);
                    RedisHelper.ItemSet<string>(RoleKey, RoleListString);
                    RedisHelper.CommonSetExpire(RoleKey, ToolMethod.GetNow().AddDays(1));
                }
                return _roleInfoList;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Common;
using WebMVC.DAL;
using WebMVC.Models;

namespace WebMVC.BLL
{
    public class RoleInfoBLL
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
            return _roleInfoDal.Get(Id);
        }

        /// <summary>
        /// 从缓存中角色列表 未命中 则读取数据库存放至缓存
        /// </summary>
        /// <returns></returns>
        public List<RoleInfo> GetAll()
        {
            string RoleKey = "RoleList";
            string RoleListString = string.Empty;
            RoleListString = RedisHelper.ItemGet<string>(RoleKey);
            if (RoleListString != null)
            {
                return JsonHelper.DeserializeJsonToList<RoleInfo>(RoleListString);
            }
            else
            {
                List<RoleInfo> _roleInfoList = _roleInfoDal.GetAll();
                RoleListString = JsonHelper.SerializeObject(_roleInfoList);
                RedisHelper.ItemSet<string>(RoleKey, RoleListString);
                RedisHelper.CommonSetExpire(RoleKey, ToolMethod.GetNow().AddDays(1));
                return _roleInfoList;
            }
        }
    }
}
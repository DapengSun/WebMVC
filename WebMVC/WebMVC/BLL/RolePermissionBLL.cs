using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Common;
using WebMVC.DAL;
using WebMVC.Models;

namespace WebMVC.BLL
{
    public class RolePermissionBLL
    {
        public RolePermissionDAL _rolePermissionDal = new RolePermissionDAL();

        public bool Add(RolePermission _RolePermission)
        {
            return _rolePermissionDal.Add(_RolePermission);
        }

        public bool Update(RolePermission _RolePermission)
        {
            return _rolePermissionDal.Update(_RolePermission);
        }

        public bool Delete(RolePermission _RolePermission)
        {
            return _rolePermissionDal.Delete(_RolePermission);
        }

        public RolePermission Get(string Id)
        {
            return _rolePermissionDal.Get(Id);
        }

        /// <summary>
        /// 从缓存中权限角色对应关系 未命中 则读取数据库存放至缓存
        /// </summary>
        /// <returns></returns>
        public List<RolePermission> GetAll()
        {
            string RolePermissionKey = "RolePermissionList";
            string RolePermissionListString = string.Empty;
            RolePermissionListString = RedisHelper.ItemGet<string>(RolePermissionKey);
            if (RolePermissionListString != null)
            {
                return JsonHelper.DeserializeJsonToList<RolePermission>(RolePermissionListString);
            }
            else
            {
                List<RolePermission> _rolePermissionInfoList = _rolePermissionDal.GetAll();
                RolePermissionListString = JsonHelper.SerializeObject(_rolePermissionInfoList);
                RedisHelper.ItemSet<string>(RolePermissionKey, RolePermissionListString);
                RedisHelper.CommonSetExpire(RolePermissionKey, ToolMethod.GetNow().AddDays(1));
                return _rolePermissionInfoList;
            }
        }

        /// <summary>
        /// RoleId & PermissionId权限角色映射关系是否存在
        /// </summary>
        /// <param name="Controller"></param>
        /// <param name="Action"></param>
        /// <returns></returns>
        public bool Exist(string RoleId, string PermissionId)
        {
            List<RolePermission> _rolePermissionInfoList = GetAll();
            return _rolePermissionInfoList.Exists(x => x.RoleId == RoleId && x.PermissionId == PermissionId);
        }
    }
}
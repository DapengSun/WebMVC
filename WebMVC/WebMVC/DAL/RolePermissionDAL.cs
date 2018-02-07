using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Common;
using WebMVC.DBContext;
using WebMVC.IDAL;
using WebMVC.Models;

namespace WebMVC.DAL
{
    public class RolePermissionDAL : BaseDAL<RolePermission>, IRolePermissionDAL
    {
        public bool UpdateCache(string CacheKey, string ItemCacheKey,RolePermission RolePermission)
        {
            RedisHelper.HashRemove(CacheKey, ItemCacheKey);
            RedisHelper.HashSet<RolePermission>(CacheKey, ItemCacheKey, RolePermission);
            return true;
        }
    }
}
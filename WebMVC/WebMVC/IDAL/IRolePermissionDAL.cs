using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Models;

namespace WebMVC.IDAL
{
    public interface IRolePermissionDAL : IBaseDAL<RolePermission>
    {
        /// <summary>
        /// 更新缓存内容
        /// </summary>
        /// <returns></returns>
        bool UpdateCache(string CacheKey, string ItemCacheKey, RolePermission RolePermission);
    }
}
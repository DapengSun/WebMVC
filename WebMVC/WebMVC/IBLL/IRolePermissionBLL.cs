using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.IBLL;
using WebMVC.Models;

namespace WebMVC.IBLL
{
    public interface IRolePermissionBLL : IBaseBLL<RolePermission>
    {
        /// <summary>
        /// 更新缓存内容
        /// </summary>
        /// <returns></returns>
        bool UpdateCache(string CacheKey, string ItemCacheKey, RolePermission RolePermission);
    }
}

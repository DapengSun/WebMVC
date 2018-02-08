using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.IBLL
{
    public interface IPermissionInfoBLL : IBaseBLL<PermissionInfo>
    {
        PermissionInfo Get(string Controller, string Action);

        /// <summary>
        /// 更新缓存内容
        /// </summary>
        /// <returns></returns>
        bool UpdateCache(string CacheKey, string ItemCacheKey, PermissionInfo PermissionInfo);
    }
}

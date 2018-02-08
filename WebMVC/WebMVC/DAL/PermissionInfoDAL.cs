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
    public class PermissionInfoDAL : BaseDAL<PermissionInfo>, IPermissionInfoDAL
    {
        public PermissionInfo Get(string Id)
        {
            using (var context = new LocalDBContext())
            {
                return context.PermissionInfo.Where(i => i.Id == Id && i.Delflag == EnumType.DelflagType.正常).FirstOrDefault();
            }
        }

        public bool UpdateCache(string CacheKey, string ItemCacheKey, PermissionInfo PermissionInfo)
        {
            RedisHelper.HashRemove(CacheKey, ItemCacheKey);
            RedisHelper.HashSet<PermissionInfo>(CacheKey, ItemCacheKey, PermissionInfo);
            return true;
        }
    }
}
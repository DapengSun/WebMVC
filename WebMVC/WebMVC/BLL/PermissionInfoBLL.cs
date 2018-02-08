using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.DALContainer;
using WebMVC.IBLL;
using WebMVC.IDAL;
using WebMVC.Models;

namespace WebMVC.BLL
{
    public class PermissionInfoBLL : BaseBLL<PermissionInfo> , IPermissionInfoBLL
    {
        private IPermissionInfoDAL _IPermissionInfoDAL = PermissionInfoDALContainer.Resolve<IPermissionInfoDAL>();

        /// <summary>
        /// 根据Controller & Action获取权限
        /// </summary>
        /// <param name="Controller"></param>
        /// <param name="Action"></param>
        /// <returns></returns>
        public PermissionInfo Get(string Controller, string Action)
        {
            return _IPermissionInfoDAL.GetModels(x=> x.Controller == Controller && x.Action == Action && x.Delflag == EnumType.DelflagType.正常,true,false,true, "PermissionList").FirstOrDefault();
        }

        public override void SetDAL()
        {
            this._Dal = _IPermissionInfoDAL;
        }

        public bool UpdateCache(string CacheKey, string ItemCacheKey, PermissionInfo PermissionInfo)
        {
            return _IPermissionInfoDAL.UpdateCache(CacheKey, ItemCacheKey, PermissionInfo);
        }
    }
}
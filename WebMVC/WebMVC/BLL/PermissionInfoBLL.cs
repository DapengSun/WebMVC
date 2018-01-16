using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Common;
using WebMVC.DAL;
using WebMVC.Models;

namespace WebMVC.BLL
{
    public class PermissionInfoBLL
    {
        public PermissionInfoDAL _PermissionInfoDal = new PermissionInfoDAL();

        public bool Add(PermissionInfo _PermissionInfo)
        {
            return _PermissionInfoDal.Add(_PermissionInfo);
        }

        public bool Update(PermissionInfo _PermissionInfo)
        {
            return _PermissionInfoDal.Update(_PermissionInfo);
        }

        public bool Delete(PermissionInfo _PermissionInfo)
        {
            return _PermissionInfoDal.Delete(_PermissionInfo);
        }

        public PermissionInfo Get(string Id)
        {
            return _PermissionInfoDal.Get(Id);
        }

        /// <summary>
        /// 从缓存中权限列表 未命中 则读取数据库存放至缓存
        /// </summary>
        /// <returns></returns>
        public List<PermissionInfo> GetAll()
        {
            string PermissionKey = "PermissionList";
            string PermissionListString = string.Empty;
            PermissionListString = RedisHelper.ItemGet<string>(PermissionKey);
            if(PermissionListString != null) {
                return JsonHelper.DeserializeJsonToList<PermissionInfo>(PermissionListString);
            }
            else{
                List<PermissionInfo>  _permissionInfoList = _PermissionInfoDal.GetAll();
                PermissionListString = JsonHelper.SerializeObject(_permissionInfoList);
                RedisHelper.ItemSet<string>(PermissionKey, PermissionListString);
                RedisHelper.CommonSetExpire(PermissionKey, ToolMethod.GetNow().AddDays(1));
                return _permissionInfoList;
            }
        }

        /// <summary>
        /// 根据Controller & Action获取权限
        /// </summary>
        /// <param name="Controller"></param>
        /// <param name="Action"></param>
        /// <returns></returns>
        public PermissionInfo Get(string Controller,string Action) {
            List<PermissionInfo> _permissionInfoList = GetAll();
            return _permissionInfoList.Where(x => x.Controller == Controller && x.Action == Action).FirstOrDefault();
        }
    }
}
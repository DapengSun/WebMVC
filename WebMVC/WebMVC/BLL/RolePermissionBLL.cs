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
    public class RolePermissionBLL : BaseBLL<RolePermission> , IRolePermissionBLL
    {
        public IRolePermissionDAL _IRolePermissionDAL = RolePermissionDALContainer.Resolve<IRolePermissionDAL>();


        public override void SetDAL()
        {
            _Dal = _IRolePermissionDAL;
        }
    }
}
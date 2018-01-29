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
    public class RoleInfoBLL : BaseBLL<RoleInfo>, IRoleInfoBLL
    {
        private IRoleInfoDAL _IRoleInfoDAL = DALContainer.RoleInfoDALContainer.Resolve<IRoleInfoDAL>();
        public override void SetDAL()
        {
            _Dal = _IRoleInfoDAL;
        }
    }
}
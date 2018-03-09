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
    public class LogInfoBLL : BaseBLL<LogInfo>, ILogInfoBLL
    {
        public ILogInfoDAL _ILogInfoDAL = LogInfoDALContainer.Resolv<ILogInfoDAL>();
        public override void SetDAL()
        {
            _Dal = _ILogInfoDAL;
        }
    }
}
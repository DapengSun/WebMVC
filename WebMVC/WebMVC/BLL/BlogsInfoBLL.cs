using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.IBLL;
using WebMVC.IDAL;
using WebMVC.Models;

namespace WebMVC.BLL
{
    public class BlogsInfoBLL : BaseBLL<BlogsInfo>, IBlogsInfoBLL
    {
        public IBlogsInfoDAL _IBlogsInfoDAL = DALContainer.BlogsInfoDALContainer.Resolve<IBlogsInfoDAL>();
        public override void SetDAL()
        {
            _Dal = _IBlogsInfoDAL;
        }
    }
}
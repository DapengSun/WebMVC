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
    public class ImageInfoBLL : BaseBLL<ImageInfo>, IImageInfoBLL
    {
        private IImageInfoDAL _IImageInfoDAL = ImageInfoDALContainer.Resolve<IImageInfoDAL>();
        public override void SetDAL()
        {
            _Dal = _IImageInfoDAL;
        }
    }
}
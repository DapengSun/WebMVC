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
    public class ProductInfoBLL : BaseBLL<ProductInfo>, IProductInfoBLL
    {
        private IProductInfoDAL _IProductInfoDAL = ProductInfoDALContainer.Resolve<IProductInfoDAL>();
        public override void SetDAL()
        {
            _Dal = _IProductInfoDAL;
        }
    }
}
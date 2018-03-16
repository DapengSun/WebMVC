using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.IDAL;
using WebMVC.Models;

namespace WebMVC.DAL
{
    public class ProductInfoDAL : BaseDAL<ProductInfo> , IProductInfoDAL
    {
    }
}
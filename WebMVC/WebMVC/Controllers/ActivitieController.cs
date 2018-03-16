using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Attributes;
using WebMVC.BLLContainer;
using WebMVC.Common;
using WebMVC.IBLL;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    [DescriptionAttribute(DescptionName = "平台活动")]
    public class ActivitieController : Controller
    {
        protected IProductInfoBLL _IProductInfoBLL = ProductInfoBLLContainer.Resovle<IProductInfoBLL>();

        [AuthAttribute]
        [DescriptionAttribute(DescptionName = "活动主页")]
        // GET: Activitie
        public ActionResult Index()
        {
            //ProductInfo _p = new ProductInfo
            //{
            //    Id = ToolMethod.GetGuid(),
            //    ProductName = "商品1",
            //    ProductNum = "123",
            //    StoreNum = 20,
            //    Delflag = EnumType.DelflagType.正常,
            //    CDate = ToolMethod.GetNow(),
            //};

            //_IProductInfoBLL.Add(_p);

            //ProductInfo _p = _IProductInfoBLL.GetModels(x=>true).FirstOrDefault();

            return View();
        }
    }
}
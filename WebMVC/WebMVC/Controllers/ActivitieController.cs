using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
             

            return View();
        }
    }
}
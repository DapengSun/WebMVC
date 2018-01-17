using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Attributes;

namespace WebMVC.Controllers
{
    [DescriptionAttribute(DescptionName = "地图管理")]
    public class MapsController : Controller
    {
        // GET: Maps
        [AuthAttribute]
        [DescriptionAttribute(DescptionName = "地图首页")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
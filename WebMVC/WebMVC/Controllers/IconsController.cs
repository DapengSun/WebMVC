using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Attributes;

namespace WebMVC.Controllers
{
    [DescriptionAttribute(DescptionName = "图标管理")]
    public class IconsController : Controller
    {
        // GET: Icons
        public ActionResult Index()
        {
            return View();
        }

        [AuthAttribute]
        [DescriptionAttribute(DescptionName = "获取图标")]
        public ActionResult GetTTTT()
        {
            return View();
        }
    }
}
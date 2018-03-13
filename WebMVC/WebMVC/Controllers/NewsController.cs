using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Attributes;

namespace WebMVC.Controllers
{
    [DescriptionAttribute(DescptionName = "新闻管理")]
    public class NewsController : Controller
    {
        // GET: News
        [AuthAttribute]
        [DescriptionAttribute(DescptionName = "新闻首页")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
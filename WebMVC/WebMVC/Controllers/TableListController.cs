using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Attributes;

namespace WebMVC.Controllers
{
    [DescriptionAttribute(DescptionName = "图表管理")]
    public class TableListController : Controller
    {
        // GET: TableList
        [AuthAttribute]
        [DescriptionAttribute(DescptionName = "图表首页")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
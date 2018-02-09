using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Attributes;


namespace WebMVC.Controllers
{
    [DescriptionAttribute(DescptionName = "词云")]
    public class WordCloudController : Controller
    {
        [AuthAttribute]
        [DescriptionAttribute(DescptionName = "词云主页")]
        // GET: WordCloud
        public ActionResult Index()
        {
            return View();
        }
    }
}
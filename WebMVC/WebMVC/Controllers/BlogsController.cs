using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Attributes;

namespace WebMVC.Controllers
{
    [DescriptionAttribute(DescptionName = "个人博客")]
    public class BlogsController : Controller
    {
        [AuthAttribute]
        [DescriptionAttribute(DescptionName = "个人博客")]
        // GET: Blogs
        public ActionResult Index()
        {
            return View();
        }
    }
}
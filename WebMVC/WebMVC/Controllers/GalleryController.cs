using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Attributes;

namespace WebMVC.Controllers
{
    [DescriptionAttribute(DescptionName = "个人影集")]
    public class GalleryController : Controller
    {
        [AuthAttribute]
        [DescriptionAttribute(DescptionName = "个人影集")]
        // GET: Gallery
        public ActionResult Index()
        {
            return View();
        }
    }
}
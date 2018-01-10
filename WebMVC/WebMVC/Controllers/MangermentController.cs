using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Attributes;
using WebMVC.BLL;

namespace WebMVC.Controllers
{
    public class MangermentController : Controller
    {
        // GET: Mangerment
        [Description(DescptionName = "后台管理首页")]
        public ActionResult Index()
        {
            AutoGeneraterBLL _autoGeneraterBll = new AutoGeneraterBLL();
            ViewBag.JsonString = _autoGeneraterBll.ControllerList();


            return View();
        }
    }
}
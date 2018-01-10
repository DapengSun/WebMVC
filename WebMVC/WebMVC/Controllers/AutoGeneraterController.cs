using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class AutoGeneraterController : Controller
    {
        // GET: AutoGenerater
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InstallPermissions() {

            
            return View();
        }
    }
}
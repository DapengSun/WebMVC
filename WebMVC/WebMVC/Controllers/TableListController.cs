using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class TableListController : Controller
    {
        // GET: TableList
        public ActionResult Index()
        {
            return View();
        }
    }
}
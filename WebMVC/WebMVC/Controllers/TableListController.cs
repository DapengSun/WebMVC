using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Attributes;

namespace WebMVC.Controllers
{
    public class TableListController : Controller
    {
        // GET: TableList
        [AuthAttribute]
        public ActionResult Index()
        {
            return View();
        }
    }
}
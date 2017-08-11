using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.BLL;
using WebMVC.Common;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                HouseInfoBLL _houseInfoBLL = new HouseInfoBLL();
                List<houseinfo> _houseInfoList = _houseInfoBLL.Get("公主坟");
                return View();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("获取数据失败！", ex);
                return Content("获取数据异常！");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
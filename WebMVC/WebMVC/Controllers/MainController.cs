using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Attributes;
using WebMVC.BLL;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    [DescriptionAttribute(DescptionName = "首页")]
    public class MainController : BaseController
    {
        MainBLL _Bll = new MainBLL();
        string Key = "KeyPV";

        [OutputCache(Duration = 60, VaryByParam = "type")]
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 读取缓存获取网站PV
        /// 若有，则返回;
        /// 若无，则读取数据库中PV值返回，并将值放入缓存中，过期时间设为1分钟
        /// </summary>
        /// <returns></returns>
        public ActionResult GetWebSitePV() {
            try
            {
                int PVNum = _Bll.GetPV(Key);
                return Json(new { Success = true, SuccessModel = PVNum });
            }
            catch (Exception ee)
            {
                return Json(new { Success = false, ErrorMessage = ee });
            }
        }

        /// <summary>
        /// 更新PV 客户端刷新一次页面 则调用一次
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateWebSitePV() {
            try
            {
                _Bll.UpdatePV();
                return Json(new { Success = true });
            }
            catch (Exception)
            {
                return Json(new { Success = false });
            }
        }
        
        /// <summary>
        /// 获取比特币走势数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetBTCData()
        {
            try
            {
                List<BTC_Price_Statistics> _BTC_Price_Statistics = _Bll.GetBTCPrice();

                return Json(new { Success = true  , SuccessModel = _BTC_Price_Statistics });
            }
            catch (Exception ee)
            {
                return Json(new { Success = false , ErrorMessage = ee });
            }
        }
    }
}
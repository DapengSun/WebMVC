using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Attributes;
using WebMVC.IBLL;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    [DescriptionAttribute(DescptionName = "个人博客")]
    public class BlogsController : Controller
    {
        public IBlogsInfoBLL _IBlogsInfoBLL = BLLContainer.BlogsInfoBLLContainer.Resolve<IBlogsInfoBLL>();

        [AuthAttribute]
        [DescriptionAttribute(DescptionName = "个人博客主页")]
        // GET: Blogs
        public ActionResult Index(int? Page, int PageSize = 10)
        {
            int _pageIndex = Page ?? 1;

            ViewBag.Page = _pageIndex;
            ViewBag.PageSize = PageSize;

            return View();
        }

        /// <summary>
        /// 分部视图 - 博客内容
        /// </summary>
        /// <returns></returns>
        public ActionResult _PartialIndex(int? Page , int PageSize = 10)
        {
            int _pageIndex = Page ?? 1;

            //上一页 / 下一页
            ViewBag.PrevPage = _pageIndex == 1 ?  1 : _pageIndex - 1;
            ViewBag.NextPage = _pageIndex + 1;
            ViewBag.PageSize = PageSize;

            //分页获取数据
            List<BlogsInfo> _blogsInfoList = _IBlogsInfoBLL.GetModelsByPage<DateTime>(PageSize, _pageIndex, false, x => x.CDate,
                                            x => x.Delflag == Models.EnumType.DelflagType.正常, true, x => x.Delflag == Models.EnumType.DelflagType.正常
                                            , "BlogsInfo").OrderByDescending(x => x.CDate).Skip((_pageIndex - 1) * PageSize).Take(PageSize).ToList();

            return PartialView(_blogsInfoList);
        }
    }
}
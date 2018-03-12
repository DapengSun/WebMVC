using Hangfire;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Attributes;
using WebMVC.Common;
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

        /// <summary>
        /// 新增博客界面
        /// </summary>
        /// <param name="fc"></param>
        /// <returns></returns>
        [AuthAttribute]
        [DescriptionAttribute(DescptionName = "新增博客界面")]
        public ActionResult AddBlogsIndex()
        {
            return View();
        }

        /// <summary>
        /// 新增博客
        /// </summary>
        /// <param name="fc"></param>
        /// <returns></returns>
        [AuthAttribute]
        [HttpPost]
        [ValidateInput(false)]
        [DescriptionAttribute(DescptionName = "新增博客")]
        public ActionResult AddBlogs(FormCollection fc)
        {
            #region 验证用户信息
            string _SessionId = HttpContext.Request.Cookies["SessionId"].Value;
            string _UserProfileJson = RedisHelper.ItemGet<string>(_SessionId);
            #endregion

            if (!string.IsNullOrEmpty(_UserProfileJson)) {

                UserProfile _UserProfile = ToolMethod.GetUerProfile(_UserProfileJson);

                //获取Ueditor内容
                var _Content = fc["editor"];

                BlogsInfo _BlogsInfo = new BlogsInfo()
                {
                    Id = ToolMethod.GetGuid(),
                    BlogAuthor = "Sun Dapeng",
                    BlogContent = _Content,
                    BlogHeading = "第一个博客",
                    BlogsSurfacePlot = "/Content/img/Blogs/pic01.jpg",
                    BlogSubHeading = "测试",
                    CDate = ToolMethod.GetNow(),
                    CommentNum = 0,
                    Delflag = EnumType.DelflagType.正常,
                    UDate = ToolMethod.GetNow(),
                    LikeNum = 0,
                    BlogAbstarct = "博客简介",
                };

                RedisHelper.HashSet<BlogsInfo>("BlogsInfo", _BlogsInfo.Id, _BlogsInfo);

                BackgroundJobClient _Job = new BackgroundJobClient();
                _Job.Enqueue(() => _IBlogsInfoBLL.Add(_BlogsInfo));
            }

            return Json(new { Success = true , SuccessModel = "添加博客成功！" });
        }

        /// <summary>
        /// 查看博客
        /// </summary>
        /// <param name="fc"></param>
        /// <returns></returns>
        [AuthAttribute]
        [HttpGet]
        [DescriptionAttribute(DescptionName = "查看博客")]
        public ActionResult ViewBlogs(string Id)
        {
            BlogsInfo _BlogsInfo = _IBlogsInfoBLL.GetModels(x => x.Id == Id && x.Delflag == EnumType.DelflagType.正常,true,null,"BlogsInfo").FirstOrDefault();
            return View(_BlogsInfo);
        }

        /// <summary>
        /// 修改博客
        /// </summary>
        /// <param name="fc"></param>
        /// <returns></returns>
        [AuthAttribute]
        [HttpGet]
        [DescriptionAttribute(DescptionName = "修改博客")]
        public ActionResult UpdateBlogs(string Id)
        {
            BlogsInfo _BlogsInfo = _IBlogsInfoBLL.GetModels(x => x.Id == Id && x.Delflag == EnumType.DelflagType.正常, true, null, "BlogsInfo").FirstOrDefault();
            return View(_BlogsInfo);
        }
    }
}
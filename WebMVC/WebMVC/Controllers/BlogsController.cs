using Hangfire;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        public IImageInfoBLL _IImageInfoBLL = BLLContainer.ImageInfoBLLContainer.Resolve<IImageInfoBLL>();


        [AuthAttribute]
        [DescriptionAttribute(DescptionName = "个人博客主页")]
        // GET: Blogs
        public ActionResult Index(int? Page, int PageSize = 3)
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
        public ActionResult _PartialIndex(int? Page , int PageSize = 3)
        {
            int _pageIndex = Page ?? 1;

            //上一页 / 下一页
            ViewBag.PrevPage = _pageIndex == 1 ?  1 : _pageIndex - 1;
            ViewBag.NextPage = _pageIndex + 1;
            ViewBag.PageIndex = _pageIndex;
            ViewBag.PageSize = PageSize;

            //分页获取数据
            List<BlogsInfo> _blogsInfoList = _IBlogsInfoBLL.GetModelsByPage<DateTime>(PageSize, _pageIndex, false, x => x.CDate,
                                            x => x.Delflag == Models.EnumType.DelflagType.正常, true, x => x.Delflag == Models.EnumType.DelflagType.正常
                                            , "BlogsInfo").ToList();

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

                //获取标题
                var _BlogsHeading = fc["BlogsHeading"];
                //获取副标题
                string _BlogsSubHeading = fc["BlogsSubHeading"];
                //获取简介
                var _BlogsAbstract = fc["BlogsAbstract"];
                //获取Ueditor内容
                var _Content = fc["editor"];
                //获取封面图ID
                string _SurfacePlot = fc["SurfacePlot"];

                BlogsInfo _BlogsInfo = new BlogsInfo()
                {
                    Id = ToolMethod.GetGuid(),
                    BlogAuthorId = _UserProfile.Id,
                    BlogAuthorName = _UserProfile.NickName,
                    BlogContent = _Content,
                    BlogHeading = _BlogsHeading,
                    BlogsSurfacePlot = _SurfacePlot,
                    BlogSubHeading = _BlogsSubHeading,
                    CDate = ToolMethod.GetNow(),
                    CommentNum = 0,
                    Delflag = EnumType.DelflagType.正常,
                    UDate = ToolMethod.GetNow(),
                    LikeNum = 0,
                    BlogAbstarct = _BlogsAbstract,
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
        /// 修改博客界面
        /// </summary>
        /// <param name="fc"></param>
        /// <returns></returns>
        [AuthAttribute]
        [HttpGet]
        [DescriptionAttribute(DescptionName = "修改博客界面")]
        public ActionResult UpdateBlogs(string Id)
        {
            BlogsInfo _BlogsInfo = _IBlogsInfoBLL.GetModels(x => x.Id == Id && x.Delflag == EnumType.DelflagType.正常, true, null, "BlogsInfo").FirstOrDefault();
            ViewBag.BlogsId = Id;
            return View(_BlogsInfo);
        }

        /// <summary>
        /// 修改博客
        /// </summary>
        /// <param name="fc"></param>
        /// <returns></returns>
        [AuthAttribute]
        [HttpPost]
        [ValidateInput(false)]
        [DescriptionAttribute(DescptionName = "修改博客界面")]
        public ActionResult UpdateBlogs(FormCollection fc)
        {
            #region 验证用户信息
            string _SessionId = HttpContext.Request.Cookies["SessionId"].Value;
            string _UserProfileJson = RedisHelper.ItemGet<string>(_SessionId);
            #endregion

            var _Content = fc["editor"];
            var _BlogsId = fc["BlogsId"];

            if (!string.IsNullOrEmpty(_UserProfileJson))
            {
                UserProfile _UserProfile = ToolMethod.GetUerProfile(_UserProfileJson);
                BlogsInfo _BlogsInfo = _IBlogsInfoBLL.GetModels(x => x.Id == _BlogsId && x.Delflag == EnumType.DelflagType.正常, true, null, "BlogsInfo").FirstOrDefault();
                _BlogsInfo.BlogContent = _Content;
                _BlogsInfo.UDate = ToolMethod.GetNow();

                RedisHelper.HashSet<BlogsInfo>("BlogsInfo", _BlogsId, _BlogsInfo);

                BackgroundJobClient _Job = new BackgroundJobClient();
                _Job.Enqueue(() => _IBlogsInfoBLL.Update(_BlogsInfo));
                
                return Json(new { Success = true, SuccessModel = "修改博客成功！" });
            }
            else {
                return RedirectToAction("Login", "Account");
            }
        }

        /// <summary>
        /// 上传博客图片
        /// </summary>
        /// <param name="fc"></param>
        /// <returns></returns>
        [HttpPost]
        [DescriptionAttribute(DescptionName = "上传博客图片")]
        public ActionResult AjaxFileUpload()
        {
            #region 验证用户信息
            string _SessionId = HttpContext.Request.Cookies["SessionId"].Value;
            string _UserProfileJson = RedisHelper.ItemGet<string>(_SessionId);
            #endregion

            if (!string.IsNullOrEmpty(_UserProfileJson))
            {
                UserProfile _UserProfile = ToolMethod.GetUerProfile(_UserProfileJson);

                HttpFileCollection _Files = System.Web.HttpContext.Current.Request.Files;

                string _DateTimePath = ToolMethod.GetDateTimePath();
                string _PhysicalPath = ToolMethod.GetBlogsSurfacePlot_PhysicalPath(_DateTimePath);
                string _VirualPath = ToolMethod.GetBlogsSurfacePlot_VirualPath(_DateTimePath);

                if (!Directory.Exists(_PhysicalPath)) {
                    Directory.CreateDirectory(_PhysicalPath);
                }

                string _FileName = _Files[0].FileName;
                string _StrFile = System.DateTime.Now.ToString("yyyyMMddHHmmssms");
                string _FilePhysicalPath = _PhysicalPath  + _StrFile + "_" + _FileName;
                string _FileVirualPath = _VirualPath + _StrFile + "_" + _FileName;
                long _FileSize = _Files[0].ContentLength;
                //获取文件后缀
                string _FileType = _FileName.Substring(_FileName.LastIndexOf(@"."), _FileName.Length - _FileName.LastIndexOf(@"."));
                //保存文件
                _Files[0].SaveAs(_FilePhysicalPath);

                string _FileId = ToolMethod.GetGuid();
                ImageInfo _ImageInfo = new ImageInfo
                {
                    Id = _FileId,
                    CDate = ToolMethod.GetNow(),
                    Delflag = EnumType.DelflagType.正常,
                    AccountId = _UserProfile.Id,
                    AccountName = _UserProfile.LoginName,
                    FileName = _FileName,
                    FileSize = _FileSize,
                    RelativePath = _StrFile + "_" + _FileName,
                    FileType = _FileType
                };

                //保存文件集合
                _IImageInfoBLL.Add(_ImageInfo);

                return Json(new { FileId = _FileId, FileName = _FileName, PhysicalPath = _FilePhysicalPath , VirualPath = _FileVirualPath});
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult DeleteBlogs(string Id) {
            BlogsInfo _BlogsInfo = _IBlogsInfoBLL.GetModels(x=>x.Id == Id && x.Delflag == EnumType.DelflagType.正常,true,null,"BlogsInfo").FirstOrDefault();
            _BlogsInfo.Delflag = EnumType.DelflagType.已删除;

            RedisHelper.HashSet("BlogsInfo", Id, _BlogsInfo);

            BackgroundJobClient _Job = new BackgroundJobClient();
            _Job.Enqueue(() => _IBlogsInfoBLL.Update(_BlogsInfo));

            return Json(new { Success = true,SuccessModel = "删除博客成功！"});
        }
    }
}
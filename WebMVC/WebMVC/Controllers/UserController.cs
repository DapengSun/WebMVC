using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMVC.Attributes;
using WebMVC.BLL;
using WebMVC.Common;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    [DescriptionAttribute(DescptionName = "账户管理")]
    public class UserController : Controller
    {
        public UserProfileBLL _Bll = new UserProfileBLL();

        // GET: User
        [AuthAttribute]
        [DescriptionAttribute(DescptionName = "账户管理首页")]
        public ActionResult Index()
        {
            return View();
        }

        [AuthAttribute]
        [DescriptionAttribute(DescptionName = "新增用户")]
        public ActionResult Add() {
            try
            {
                UserProfile _UserProfile = new UserProfile
                {
                    Id = ToolMethod.GetGuid(),
                    //Role = UserProfile.EnumAccountType.User,
                    LoginName = "13520387252@163.com",
                    NickName = "Dipa666",
                    Phone = "13520387252",
                    Password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"),
                    FirstName = "Sun",
                    LastName = "Dapeng",
                    Sex = UserProfile.EnumSexType.Male,
                    SysStatus = UserProfile.EnumSysType.正常,
                    CDate = DateTime.Now,
                    LastDate = DateTime.Now
                };
                if (_Bll.Add(_UserProfile))
                {
                    return Json(new { Success = true, Message = "添加成功！", SuccessModel = _UserProfile });
                }
                else
                {
                    return Json(new { Success = true, Message = "添加失败！", SuccessModel = "" });
                }
            }
            catch (Exception ee)
            {
                return Json(new { Success = false, Message = "添加异常！", SuccessModel = ee });
            }
        }
    }
}
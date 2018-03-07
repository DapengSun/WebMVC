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
            #region 获取账号信息
            string _SessionId = Request.Cookies["sessionId"].Value;
            string _UserProfileJson = RedisHelper.ItemGet<string>(_SessionId);
            UserProfile _UserProfile = Common.ToolMethod.GetUerProfile(_UserProfileJson);
            #endregion

            return View(_UserProfile);
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

        [HttpPost]
        [AuthAttribute]
        [DescriptionAttribute(DescptionName = "修改用户")]
        public ActionResult Update(UserProfile _UserProfile)
        {
            try
            {
                UserProfile _OldUserProfile = _Bll.Get(_UserProfile.Id);

                _OldUserProfile.Address = _UserProfile.Address;
                _OldUserProfile.City = _UserProfile.City;
                _OldUserProfile.Company = _UserProfile.Company;
                _OldUserProfile.Country = _UserProfile.Country;
                _OldUserProfile.Describe = _UserProfile.Describe;
                _OldUserProfile.Email = _UserProfile.Email;
                _OldUserProfile.FirstName = _UserProfile.FirstName;
                _OldUserProfile.LastName = _UserProfile.LastName;
                _OldUserProfile.NickName = _UserProfile.NickName;
                _OldUserProfile.PostalCode = _UserProfile.PostalCode;
                _OldUserProfile.LastDate = ToolMethod.GetNow();

                if (_Bll.Update(_OldUserProfile))
                {
                    string _SessionId = Request.Cookies["sessionId"].Value;
                    string _UserProfileString = ToolMethod.GetUerProfileString(_OldUserProfile);
                    if (RedisHelper.ItemSet<string>(_SessionId, _UserProfileString)) {
                        return Json(new { Success = true, Message = "修改信息成功！", SuccessModel = _UserProfile });
                    } else {
                        return Json(new { Success = true, Message = "修改信息失败！", ErrorMessage = "" });
                    }
                }
                else
                {
                    return Json(new { Success = true, Message = "添加失败！", ErrorMessage = "" });
                }
            }
            catch (Exception ee)
            {
                return Json(new { Success = false, Message = "添加异常！", ErrorMessage = ee });
            }
        }
    }
}
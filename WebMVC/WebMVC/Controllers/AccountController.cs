using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.BLL;

namespace WebMVC.Controllers
{
    public class AccountController : Controller
    {
        UserProfileBLL _UserProfileBLL = new UserProfileBLL();

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public ActionResult UserLogin(string Username, string Password)
        {
            try
            {
                //用户验证并生成SessionId
                string _SessionId = _UserProfileBLL.Login(Username, Password);
                if (_SessionId != null)
                {
                    //SessionId保存到Cookies中 8小时超时
                    Response.Cookies["SessionId"].Value = _SessionId;
                    Response.Cookies["SessionId"].Expires = DateTime.Now.AddHours(8);
                    return Json(new { Success = true, SuccessModel = "登录成功！" });
                }
                else {
                    return Json(new { Success = false, ErrorMessage = "登录失败！用户名或密码不正确！" });
                } 
            }
            catch (Exception ee)
            {
                return Json(new { Success = false, ErrorMessage = ee.ToString()});
            }
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        public ActionResult UserRegister()
        {

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public ActionResult UserLogin(string LoginName,string Password)
        {

            return View();
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
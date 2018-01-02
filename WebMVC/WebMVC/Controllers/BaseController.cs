using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Common;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class BaseController : Controller
    {
        public UserProfile _UserProfile { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string curActionName = filterContext.ActionDescriptor.ActionName;
            string curControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            if (!filterContext.HttpContext.Request.IsAuthenticated && (curControllerName.ToLower() != "account" || curActionName.ToLower() != "login"))
            {
                bool isExt = false;
                if (Request.Cookies["SessionId"] != null)
                {
                    string _SessionId = Request.Cookies["SessionId"].Value;
                    string _UserProfileJson = RedisHelper.ItemGet<string>(_SessionId);
                    if (_UserProfileJson != null)
                    {
                        _UserProfile = JsonConvert.DeserializeObject<UserProfile>(_UserProfileJson);
                        isExt = true;
                    }
                }

                if (!isExt)
                {
                    filterContext.HttpContext.Response.Redirect("/Account/Login?session=false");
                }
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
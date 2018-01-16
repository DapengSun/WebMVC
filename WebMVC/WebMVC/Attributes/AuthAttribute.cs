using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebMVC.BLL;
using WebMVC.Common;
using WebMVC.Models;

namespace WebMVC.Attributes
{
    /// <summary>
    /// 角色权限认证
    /// </summary>
    public class AuthAttribute : AuthorizeAttribute
    {
        public UserProfile _UserProfile { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //获取当前的Controller & Action信息
            string ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string ActionName = filterContext.ActionDescriptor.ActionName;

            if (filterContext.HttpContext.Request.Cookies["SessionId"] != null)
            {
                string _SessionId = filterContext.HttpContext.Request.Cookies["SessionId"].Value;
                string _UserProfileJson = RedisHelper.ItemGet<string>(_SessionId);
                if (_UserProfileJson != null)
                {
                    //获取用户账号实体
                    _UserProfile = JsonConvert.DeserializeObject<UserProfile>(_UserProfileJson);
                    //角色ID
                    string RoleId = _UserProfile.RoleId;

                    //获取当前Controller & Action的权限ID
                    PermissionInfoBLL _permissionInfoBLL = new PermissionInfoBLL();
                    PermissionInfo _permissionInfo = _permissionInfoBLL.Get(ControllerName + "Controller", ActionName);

                    if (_permissionInfo != null)
                    {
                        //权限ID
                        string permissionInfoId = _permissionInfo.Id;

                        RolePermissionBLL _rolePermissionBLL = new RolePermissionBLL();
                        if (!_rolePermissionBLL.Exist(RoleId, permissionInfoId))
                        {
                            //未授权则跳转到未授权403页面
                            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Template", action = "Template_403", returnUrl = filterContext.HttpContext.Request.Url, returnMessage = "您无权查看." }));
                            return;
                        }
                    }
                }
            }else{
                filterContext.HttpContext.Response.Redirect("/Account/Login?session=false");
            }
        }

    }
}
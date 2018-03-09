using Hangfire;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using WebMVC.BLLContainer;
using WebMVC.Common;
using WebMVC.IBLL;
using WebMVC.Models;

namespace WebMVC.Attributes
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        public UserProfile _UserProfile { get; set; }

        public ILogInfoBLL _ILogInfoBLL = LogInfoBLLContainer.Resolv<ILogInfoBLL>();

        public override void OnActionExecuted(ActionExecutedContext filterContext) {
            #region 获取Action & Controller信息
            string _ActionName = filterContext.ActionDescriptor.ActionName;
            string _ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            #endregion

            #region 记录操作日志
            if (_ControllerName != "Account")
            { 
                if (filterContext.HttpContext.Request.Cookies["SessionId"] != null)
                {
                    string _SessionId = filterContext.HttpContext.Request.Cookies["SessionId"].Value;
                    string _UserProfileJson = RedisHelper.ItemGet<string>(_SessionId);
                    if (_UserProfileJson != null)
                    {
                        //获取用户账号实体
                        _UserProfile = JsonConvert.DeserializeObject<UserProfile>(_UserProfileJson);

                        LogInfo _logInfo = new LogInfo()
                        {
                            Id = ToolMethod.GetGuid(),
                            Content = _UserProfile.NickName + "(" + _UserProfile.Id+ ") 调用了 " + _ControllerName + "Controller下的" + _ActionName + "操作",
                            AccountId = _UserProfile.Id,
                            AccountName = _UserProfile.NickName,
                            Level = EnumType.LogLevel.INFO,
                            CDate = ToolMethod.GetNow()
                        };

                        BackgroundJobClient _jobs = new BackgroundJobClient();
                        Expression<Action> _actionExpression = () => _ILogInfoBLL.Add(_logInfo);
                        _jobs.Enqueue(_actionExpression);
                    }
                }
                else {
                    filterContext.HttpContext.Response.Redirect("/Account/Login?session=false");
                }
            }
            #endregion
        }
    }
}
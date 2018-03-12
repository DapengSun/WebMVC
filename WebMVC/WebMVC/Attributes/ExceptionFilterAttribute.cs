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
    public class ExceptionFilterAttribute : HandleErrorAttribute
    {
        public UserProfile _UserProfile { get; set; }

        public ILogInfoBLL _ILogInfoBLL = LogInfoBLLContainer.Resolv<ILogInfoBLL>();

        public override void OnException(ExceptionContext filterContext)
        {
            string _ControllerName = filterContext.Controller.ToString();

            #region 记录异常日志
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
                            Content = "【请求异常】：" 
                                    + "【请求路径：" + filterContext.HttpContext.Request.Path  + "】"
                                    + "【请求方式：" + filterContext.HttpContext.Request.HttpMethod + "】"
                                    + "【异常内容：" + filterContext.Exception.Message.ToString() + "】",
                            AccountId = _UserProfile.Id,
                            AccountName = _UserProfile.NickName,
                            Level = EnumType.LogLevel.ERROR,
                            CDate = ToolMethod.GetNow()
                        };

                        BackgroundJobClient _jobs = new BackgroundJobClient();
                        Expression<Action> _actionExpression = () => _ILogInfoBLL.Add(_logInfo);
                        _jobs.Enqueue(_actionExpression);
                    }
                }
                else
                {
                    filterContext.HttpContext.Response.Redirect("/Account/Login?session=false");
                }
            }
            #endregion
        }
    }
}
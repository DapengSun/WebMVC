using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Common
{
    public class BaseExceptionAttribute :HandleErrorAttribute
    {
        public static IRedisClientsManager clientsManager = new PooledRedisClientManager(new string[] { "127.0.0.1:6379" });

        public static IRedisClient redisClient = clientsManager.GetClient();

        public override void OnException(ExceptionContext filterContext)
        {
            redisClient.EnqueueItemOnList("ErrorMsg", filterContext.Exception.ToString());

            filterContext.HttpContext.Response.Redirect("~/Error.html");

            base.OnException(filterContext);
        }
    }
}
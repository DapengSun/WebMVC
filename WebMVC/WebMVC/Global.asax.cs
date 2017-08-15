using log4net;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebMVC.Common;

namespace WebMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure(); //获取Log4Net配置信息  
            ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    if (BaseExceptionAttribute.redisClient.GetListCount("ErrorMsg") > 0)
                    {
                        string msg = BaseExceptionAttribute.redisClient.DequeueItemFromList("ErrorMsg");
                        if (!string.IsNullOrEmpty(msg))
                        {
                            ILog logger = LogManager.GetLogger("SystemLog");
                            logger.Error(msg); //将异常信息写入Log4Net中  
                        }
                        else
                        {
                            Thread.Sleep(5000);
                        }
                    }
                    else
                    {
                        Thread.Sleep(5000);
                    }
                }
            });

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

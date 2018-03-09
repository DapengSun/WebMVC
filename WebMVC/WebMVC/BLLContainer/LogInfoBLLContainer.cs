using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.BLL;
using WebMVC.IBLL;

namespace WebMVC.BLLContainer
{
    public class LogInfoBLLContainer
    {
        private static IContainer _container = null;

        public static T Resolv<T>()
        {
            try
            {
                if (_container == null)
                {
                    var builder = new ContainerBuilder();
                    builder.RegisterType<LogInfoBLL>().As<ILogInfoBLL>().InstancePerLifetimeScope();
                    _container = builder.Build();
                }
            }
            catch (Exception ee)
            {
                throw new Exception("IOC实例化出错!" + ee.Message);
            }
            return _container.Resolve<T>();
        }
    }
}
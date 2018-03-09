using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.DAL;
using WebMVC.IDAL;

namespace WebMVC.DALContainer
{
    public class LogInfoDALContainer
    {
        private static IContainer _container = null;

        public static T Resolv<T>() {
            try
            {
                var builder = new ContainerBuilder();
                builder.RegisterType<LogInfoDAL>().As<ILogInfoDAL>().InstancePerLifetimeScope();
                _container = builder.Build();
            }
            catch (Exception ee)
            {
                throw new Exception("IOC实例化出错!" + ee.Message);
            }
            return _container.Resolve<T>();
        }
    }
}
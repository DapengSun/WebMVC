using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.BLL;
using WebMVC.IBLL;

namespace WebMVC.BLLContainer
{
    public class ProductInfoBLLContainer
    {
        public static IContainer _container = null;

        public static T Resovle<T>() {
            var builder = new ContainerBuilder();
            builder.RegisterType<ProductInfoBLL>().As<IProductInfoBLL>().InstancePerLifetimeScope();
            _container = builder.Build();
            return _container.Resolve<T>();
        }
    }
}
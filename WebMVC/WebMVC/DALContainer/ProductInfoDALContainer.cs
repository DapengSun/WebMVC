using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.DAL;
using WebMVC.IDAL;

namespace WebMVC.DALContainer
{
    public class ProductInfoDALContainer
    {
        public static IContainer _container = null;

        public static T Resolve<T>() {
            var builder = new ContainerBuilder();
            builder.RegisterType<ProductInfoDAL>().As<IProductInfoDAL>().InstancePerLifetimeScope();
            _container = builder.Build();
            return _container.Resolve<T>();
        }
    }
}
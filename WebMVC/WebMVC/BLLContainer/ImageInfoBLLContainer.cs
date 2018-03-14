using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.BLL;
using WebMVC.IBLL;

namespace WebMVC.BLLContainer
{
    public class ImageInfoBLLContainer
    {
        public static IContainer _contain = null;

        public static T Resolve<T>() {
            var builder = new ContainerBuilder();
            builder.RegisterType<ImageInfoBLL>().As<IImageInfoBLL>().InstancePerLifetimeScope();
            _contain = builder.Build();
            return _contain.Resolve<T>();
        }
    }
}
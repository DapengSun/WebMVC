using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.DAL;
using WebMVC.IDAL;

namespace WebMVC.DALContainer
{
    public class ImageInfoDALContainer
    {
        public static IContainer _container = null;

        public static T Resolve<T>(){
            try
            {
                var builder = new ContainerBuilder();
                builder.RegisterType<ImageInfoDAL>().As<IImageInfoDAL>().InstancePerLifetimeScope();
                _container = builder.Build();
            }
            catch (Exception ee)
            {
                throw new System.Exception("IOC实例化出错!" + ee.Message);
            }
            return _container.Resolve<T>();
        }
    }
}
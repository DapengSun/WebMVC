using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.DAL;
using WebMVC.IDAL;

namespace WebMVC.DALContainer
{
    public class BlogsInfoDALContainer
    {
        /// <summary>
        /// IOC容器
        /// </summary>
        public static IContainer _container = null;

        public static T Resolve<T>() {
            try
            {
                Initialise();
            }
            catch (Exception ee)
            {
                throw new System.Exception("IOC实例化出错!" + ee.Message);
            }
            return _container.Resolve<T>();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialise()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BlogsInfoDAL>().As<IBlogsInfoDAL>().InstancePerLifetimeScope();
            _container = builder.Build();
        }
    }
}
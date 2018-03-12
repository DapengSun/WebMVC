using System.Configuration;
using System.Web;
using System.Web.Mvc;
using WebMVC.Attributes;
using WebMVC.Common;

namespace WebMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //var OpenCache = ConfigurationManager.AppSettings["OpenCache"];
            //if (bool.Parse(OpenCache))
            //{
            //    filters.Add(new BaseExceptionAttribute());
            //}
            //else {
            //    filters.Add(new HandleErrorAttribute());
            //}
            filters.Add(new LogFilterAttribute());
            filters.Add(new ExceptionFilterAttribute());
        }
    }
}

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
            var LogFilter = ConfigurationManager.AppSettings["LogFilter"];
            var ExceptionFilter = ConfigurationManager.AppSettings["ExceptionFilter"];

            bool LogFilterBool = false;
            bool ExceptionFilterBool = false;

            bool.TryParse(LogFilter, out LogFilterBool);
            bool.TryParse(ExceptionFilter, out ExceptionFilterBool);

            if (LogFilterBool) { 
                filters.Add(new LogFilterAttribute());
            }
            if (ExceptionFilterBool) { 
                filters.Add(new ExceptionFilterAttribute());
            }
        }
    }
}

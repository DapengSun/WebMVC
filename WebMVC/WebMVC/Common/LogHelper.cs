using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//[assembly: log4net.Config.XmlConfigurator(Watch = true)]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace WebMVC.Common
{
    public class LogHelper
    {
        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="ex"></param>
        #region static void WriteLog(Type t, Exception ex)
        public static void WriteLog(string msg, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("SystemLog");
            log.Error(msg, ex);
        }

        #endregion

        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>    
        /// <param name="msg"></param>
        #region static void WriteLog(Type t, string msg)

        public static void WriteLog(string msg)
        {
            log4net.Config.XmlConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger("SystemLog");
            log.Error(msg);
        }

        #endregion
    }
}

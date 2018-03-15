using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Models;

namespace WebMVC.Common
{
    public class ToolMethod
    {
        /// <summary>
        /// 获取GUID
        /// </summary>
        /// <returns></returns>
        public static string GetGuid()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        /// <summary>
        /// 获取当前时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetNow()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 将用户信息Json 转换成UserProfile实体
        /// </summary>
        /// <param name="_UserProfile"></param>
        public static UserProfile GetUerProfile(string _UserProfileJson)
        {
            return JsonConvert.DeserializeObject<UserProfile>(_UserProfileJson);
        }

        /// <summary>
        /// 将UserProfile实体 转换成用户信息Json
        /// </summary>
        /// <param name="_UserProfile"></param>
        /// <returns></returns>
        public static string GetUerProfileString(UserProfile _UserProfile)
        {
            return JsonConvert.SerializeObject(_UserProfile);
        }

        /// <summary>
        /// 获取博客封面图—虚拟路径
        /// </summary>
        /// <returns></returns>
        public static string GetBlogsSurfacePlot_VirualPath(string DateTimePath)
        {
            return System.Configuration.ConfigurationManager.AppSettings["BlogsSurfacePlot_VirualPath"].ToString() + DateTimePath;
        }

        /// <summary>
        /// 获取博客封面图—物理路径
        /// </summary>
        /// <returns></returns>
        public static string GetBlogsSurfacePlot_PhysicalPath(string DateTimePath)
        {
            return System.Configuration.ConfigurationManager.AppSettings["BlogsSurfacePlot_PhysicalPath"].ToString() + DateTimePath;
        }

        public static string GetDateTimePath() {
            DateTime Dt = ToolMethod.GetNow();
            string Year = Dt.Year.ToString();
            string Month = Dt.Month.ToString();
            string Day = Dt.Day.ToString();
            string Hour = Dt.Hour.ToString();
            return Year + @"\" + Month + @"\" + Day + @"\" + Hour + @"\";
        }
    }
}
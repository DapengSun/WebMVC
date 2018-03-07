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
        public static string GetGuid() {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        public static DateTime GetNow() {
            return DateTime.Now;
        }

        public static UserProfile GetUerProfile(string _UserProfileJson) {
            return JsonConvert.DeserializeObject<UserProfile>(_UserProfileJson);
        }

        public static string GetUerProfileString(UserProfile _UserProfile)
        {
            return JsonConvert.SerializeObject(_UserProfile);
        }
    }
}
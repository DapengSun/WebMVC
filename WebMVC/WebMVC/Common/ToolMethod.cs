using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}
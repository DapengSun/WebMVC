using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class EnumType
    {
        public enum DelflagType {
            正常 = 0,
            已删除 = 1
        }

        public enum UsedType {
            启用 = 1,
            未启用 = 0
        }

        public enum LogLevel {
            DEBUG = 0,
            INFO = 1,
            WARN = 2,
            ERROR = 3,
            FATAL = 4
        }
    }
}
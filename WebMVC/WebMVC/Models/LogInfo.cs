using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class LogInfo
    {
        [Key]
        public string Id { get; set; }

        //public string Title { get; set; }

        /// <summary>
        /// 日志内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 日志等级
        /// DEBUG = 0,
        /// INFO = 1,
        /// WARN = 2,
        /// ERROR = 3,
        /// FATAL = 4
        /// </summary>
        public EnumType.LogLevel Level { get; set; }

        /// <summary>
        /// 操作人ID
        /// </summary>
        [MaxLength(50,ErrorMessage ="")]
        public string AccountId { get; set; }

        /// <summary>
        /// 操作人名称
        /// </summary>
        [MaxLength(50, ErrorMessage = "")]
        public string AccountName { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime CDate { get; set; }
    }
}
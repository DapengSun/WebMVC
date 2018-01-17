using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Attributes
{
    public class DescriptionAttribute : Attribute
    {
        /// <summary>
        /// 特性描述
        /// </summary>
        public string DescptionName { get; set; }
    }
}
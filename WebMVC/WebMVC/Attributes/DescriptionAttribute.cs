using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Attributes
{
    public class DescriptionAttribute : Attribute
    {
        public string DescptionName { get; set; }
    }
}
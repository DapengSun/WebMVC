﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Attributes;

namespace WebMVC.Controllers
{
    [DescriptionAttribute(DescptionName = "通知管理")]
    public class NotificationsController : Controller
    {
        // GET: Notifications
        [AuthAttribute]
        [DescriptionAttribute(DescptionName = "通知首页")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
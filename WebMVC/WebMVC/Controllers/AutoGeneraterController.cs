using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.BLL;
using WebMVC.Common;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class AutoGeneraterController : Controller
    {
        // GET: AutoGenerater
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InstallPermissions() {

            try
            {
                PermissionInfoBLL _permissionInfoBLL = new PermissionInfoBLL();
                AutoGeneraterBLL _autoGeneraterBll = new AutoGeneraterBLL();
                List<string> _controllerList = _autoGeneraterBll.ControllerList();
                List<string> _actionList = new List<string>();

                _controllerList.ForEach(x =>
                {
                    _actionList = _autoGeneraterBll.ActionList(x);
                    if(_actionList != null) { 
                        _actionList.ForEach(y =>
                        {
                            PermissionInfo _permissionInfo = new PermissionInfo()
                            {
                                Id = ToolMethod.GetGuid(),
                                Controller = x,
                                Action = y,
                                CDate = ToolMethod.GetNow(),
                                Delflag = EnumType.DelflagType.正常
                            };
                            _permissionInfoBLL.Add(_permissionInfo);
                        });
                    }
                });

                return Json(new { Success = true, SuccessModel = "生成项目权限列表成功！" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ee)
            {
                return Json(new { Success = false, ErrorModel = "生成项目权限列表失败！", ErrorMessage = ee.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
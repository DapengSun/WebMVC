using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Attributes;
using WebMVC.BLL;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    [DescriptionAttribute(DescptionName = "后台管理")]
    public class ManagermentController : Controller
    {
        // GET: Managerment
        [DescriptionAttribute(DescptionName = "后台管理首页")]
        public ActionResult Index()
        {
            RoleInfoBLL _roleInfoBLL = new RoleInfoBLL();
            List<RoleInfo> _roleInfoList = _roleInfoBLL.GetAll(true);
            ViewBag.RoleInfoList = _roleInfoList;
            return View();
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetRoles()
        {
            try
            {
                RoleInfoBLL _roleInfoBLL = new RoleInfoBLL();
                List<RoleInfo> _roleInfoList = _roleInfoBLL.GetAll(true);
                return Json(new { Success = true, SuccessModel = _roleInfoList },JsonRequestBehavior.AllowGet);
            }
            catch (Exception ee)
            {
                return Json(new { Success = false, ErrorMessage = ee.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPermissions()
        {
            try
            {
                PermissionInfoBLL _permissionInfoBLL = new PermissionInfoBLL();
                List<PermissionInfo> _permissionInfoList = _permissionInfoBLL.GetAll(true);
                return Json(new { Success = true, SuccessModel = _permissionInfoList }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ee)
            {
               return Json(new { Success = false, ErrorMessage = ee.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 获取角色权限映射关系列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetRolePermissions(string RoleId)
        {
            try
            {
                if (string.IsNullOrEmpty(RoleId))
                {
                    return Json(new { Success = false, ErrorMessage = "角色ID不能为空" });
                }

                RolePermissionBLL _rolepermissionBLL = new RolePermissionBLL();
                List<RolePermission> _rolePermissionList = _rolepermissionBLL.GetAll(true);

                //返回指定角色的权限映射关系
                List<RolePermission> _result = _rolePermissionList.Where(x => x.RoleId == RoleId).ToList();

                return Json(new { Success = true, SuccessModel = _result });
            }
            catch (Exception ee)
            {
                return Json(new { Success = false, ErrorMessage = ee.ToString() });
            }
        }
    }
}
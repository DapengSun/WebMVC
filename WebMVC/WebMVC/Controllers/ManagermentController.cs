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
    public class ManagermentController : Controller
    {
        // GET: Managerment
        [AuthAttribute]
        [DescriptionAttribute(DescptionName = "后台管理首页")]
        public ActionResult Index()
        {
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
                List<RoleInfo> _roleInfoList = _roleInfoBLL.GetAll();
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
                List<PermissionInfo> _permissionInfoList = _permissionInfoBLL.GetAll();
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
        [HttpGet]
        public ActionResult GetRolePermissions()
        {
            try
            {
                RolePermissionBLL _rolepermissionBLL = new RolePermissionBLL();
                List<RolePermission> _rolePermissionList = _rolepermissionBLL.GetAll();
                return Json(new { Success = true, SuccessModel = _rolePermissionList }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ee)
            {
                return Json(new { Success = false, ErrorMessage = ee.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
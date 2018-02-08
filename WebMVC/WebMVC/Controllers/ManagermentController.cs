using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Attributes;
using WebMVC.BLL;
using WebMVC.Common;
using WebMVC.IBLL;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    [DescriptionAttribute(DescptionName = "后台管理")]
    public class ManagermentController : Controller
    {
        #region IOC控制反转 / 依赖注入
        private IRoleInfoBLL _IRoleInfoBLL = BLLContainer.RoleInfoBLLContainer.Resolve<IRoleInfoBLL>();
        private IPermissionInfoBLL _IPermissionInfoBLL = BLLContainer.PermissionInfoBLLContainer.Resolve<IPermissionInfoBLL>();
        private IRolePermissionBLL _IRolePermissionBLL = BLLContainer.RolePermissionBLLContainer.Resolve<IRolePermissionBLL>();
        #endregion

        // GET: Managerment
        [DescriptionAttribute(DescptionName = "后台管理首页")]
        public ActionResult Index()
        {
            List<RoleInfo> _roleInfoList = _IRoleInfoBLL.GetModels(x=> x.Delflag == EnumType.DelflagType.正常,true, false, true,"RoleList").ToList();
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
                List<RoleInfo> _roleInfoList = _IRoleInfoBLL.GetModels(x => x.Delflag == EnumType.DelflagType.正常, true, false,true, "RoleList").ToList();
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
                List<PermissionInfo> _permissionInfoList = _IPermissionInfoBLL.GetModels(x => x.Delflag == EnumType.DelflagType.正常, true, false, true, "PermissionList").ToList();
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

                List<RolePermission> _rolePermissionList = _IRolePermissionBLL.GetModels(x => x.Delflag == EnumType.DelflagType.正常, true, false, true, "RolePermission").ToList();

                //返回指定角色的权限映射关系
                List<RolePermission> _result = _rolePermissionList.Where(x => x.Delflag == EnumType.DelflagType.正常 && x.RoleId == RoleId).ToList();

                return Json(new { Success = true, SuccessModel = _result });
            }
            catch (Exception ee)
            {
                return Json(new { Success = false, ErrorMessage = ee.ToString() });
            }
        }

        /// <summary>
        /// 选中角色权限映射关系
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChooseRolePermission(string RolePermissionId)
        {
            try
            {
                if (string.IsNullOrEmpty(RolePermissionId))
                {
                    return Json(new { Success = false, ErrorMessage = "角色权限关系ID不能为空" });
                }

                RolePermission _rolePermission = _IRolePermissionBLL.GetModels(x => x.Delflag == EnumType.DelflagType.正常 && x.Id == RolePermissionId, true, false, false, "RolePermission").FirstOrDefault();

                if (_rolePermission.UsedType == EnumType.UsedType.启用)
                {
                    _rolePermission.UsedType = EnumType.UsedType.未启用;
                }
                else {
                    _rolePermission.UsedType = EnumType.UsedType.启用;
                }
                
                //更新缓存
                _IRolePermissionBLL.UpdateCache("RolePermission", _rolePermission.Id, _rolePermission);
                
                //异步更新数据库
                BackgroundJobClient _jobs = new BackgroundJobClient();
                _jobs.Enqueue(() => _IRolePermissionBLL.Update(_rolePermission));

                return Json(new { Success = true, SuccessModel = "选中关系生效！" });
            }
            catch (Exception ee)
            {
                return Json(new { Success = false, ErrorMessage = ee.ToString() });
            }
        }
    }
}
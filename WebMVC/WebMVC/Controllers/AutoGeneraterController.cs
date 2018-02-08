using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.BLL;
using WebMVC.Common;
using WebMVC.Custom.Compare;
using WebMVC.IBLL;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class AutoGeneraterController : Controller
    {
        private IRoleInfoBLL _IRoleInfoBLL = BLLContainer.RoleInfoBLLContainer.Resolve<IRoleInfoBLL>();
        private IPermissionInfoBLL _IPermissionInfoBLL = BLLContainer.PermissionInfoBLLContainer.Resolve<IPermissionInfoBLL>();
        private IRolePermissionBLL _IRolePermissionBLL = BLLContainer.RolePermissionBLLContainer.Resolve<IRolePermissionBLL>();

        // GET: AutoGenerater
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 自动装载权限列表
        /// </summary>
        /// <returns></returns>
        public ActionResult InstallPermissions() {

            try
            {
                AutoGeneraterBLL _autoGeneraterBll = new AutoGeneraterBLL();
                List<KeyValuePair<string,string>> _controllerList = _autoGeneraterBll.ControllerList();
                List<KeyValuePair<string, string>> _actionList = new List<KeyValuePair<string, string>>();

                //获取库中权限数据
                List<PermissionInfo> _oldPermissionInfoList = _IPermissionInfoBLL.GetModels(x => x.Delflag == EnumType.DelflagType.正常, false, false, false, "").ToList();

                //获取新的权限数据
                List<PermissionInfo> _newPermissionInfoList = new List<PermissionInfo>();
                _controllerList.ForEach(x =>
                {
                    _actionList = _autoGeneraterBll.ActionList(x.Key);
                    if(_actionList != null) { 
                        _actionList.ForEach(y =>
                        {
                            PermissionInfo _permissionInfo = new PermissionInfo()
                            {
                                Id = ToolMethod.GetGuid(),
                                Controller = x.Key,
                                Action = y.Key,
                                ControllerDescription = x.Value,
                                ActionDescription = y.Value,
                                CDate = ToolMethod.GetNow(),
                                Delflag = EnumType.DelflagType.正常
                            };
                            _newPermissionInfoList.Add(_permissionInfo);
                        });
                    }
                });

                BackgroundJobClient _jobs = new BackgroundJobClient();

                //不存在权限列表
                if (_oldPermissionInfoList.Count == 0)
                {
                    //直接创建映射关系
                    _newPermissionInfoList.ForEach(x =>
                    {
                        //更新缓存
                        _IPermissionInfoBLL.UpdateCache("PermissionList", x.Id, x);

                        //异步更新数据库
                        _jobs.Enqueue(() => _IPermissionInfoBLL.Add(x));
                    });
                }
                //已存在映射关系
                else
                {
                    //对比新旧映射关系列表 不存在的删除 存在的保留
                    PermissionInfo_EqualityCompare _comparer = new PermissionInfo_EqualityCompare();
                    List<PermissionInfo> _createList = _newPermissionInfoList.Except(_oldPermissionInfoList, _comparer).ToList();
                    List<PermissionInfo> _deleteList = _oldPermissionInfoList.Except(_newPermissionInfoList, _comparer).ToList();

                    _createList.ForEach(x =>
                    {
                        //更新缓存
                        _IPermissionInfoBLL.UpdateCache("PermissionList", x.Id, x);

                        //异步更新数据库
                        _jobs.Enqueue(() => _IPermissionInfoBLL.Add(x));
                    });

                    _deleteList.ForEach(x =>
                    {
                        x.Delflag = EnumType.DelflagType.已删除;

                        //更新缓存
                        _IPermissionInfoBLL.UpdateCache("PermissionList", x.Id, x);

                        //异步更新数据库
                        _jobs.Enqueue(() => _IPermissionInfoBLL.Update(x));
                    });
                }


                return Json(new { Success = true, SuccessModel = "生成项目权限列表成功！" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ee)
            {
                return Json(new { Success = false, ErrorModel = "生成项目权限列表失败！", ErrorMessage = ee.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 自动装载角色权限映射关系列表
        /// </summary>
        /// <returns></returns>
        public ActionResult InstallRolePermissions()
        {
            try
            {
                //获取库中映射数据
                List<RolePermission> _oldRolePermissionList = _IRolePermissionBLL.GetModels(x => x.Delflag == EnumType.DelflagType.正常, false, false, false, "").ToList();

                List<RoleInfo> _roleInfoList = _IRoleInfoBLL.GetModels(x => x.Delflag == EnumType.DelflagType.正常, true, false, false, "RoleList").ToList();

                List<PermissionInfo> _PermissionInfoList = _IPermissionInfoBLL.GetModels(x => x.Delflag == EnumType.DelflagType.正常, true, false, false, "PermissionList").ToList();

                //获取新的映射数据
                List<RolePermission> _newRolePermissionList = new List<RolePermission>();
                _roleInfoList.ForEach(x =>
                {
                    _PermissionInfoList.ForEach(y =>
                    {
                        RolePermission _rolePermission = new RolePermission
                        {
                            Id = ToolMethod.GetGuid(),
                            RoleId = x.Id,
                            RoleName = x.Name,
                            PermissionId = y.Id,
                            CDate = ToolMethod.GetNow(),
                            Controller = y.Controller,
                            ControllerDescription = y.ControllerDescription,
                            Action = y.Action,
                            ActionDescription = y.ActionDescription,
                            UsedType = EnumType.UsedType.未启用,
                            Delflag = EnumType.DelflagType.正常
                        };
                        _newRolePermissionList.Add(_rolePermission);
                    });
                });

                BackgroundJobClient _jobs = new BackgroundJobClient();

                //不存在映射关系
                if (_oldRolePermissionList.Count == 0)
                {
                    //直接创建映射关系
                    _newRolePermissionList.ForEach(x =>
                    {
                        //更新缓存
                        _IRolePermissionBLL.UpdateCache("RolePermission", x.Id, x);

                        //异步更新数据库
                        _jobs.Enqueue(() => _IRolePermissionBLL.Add(x));
                    });
                }
                //已存在映射关系
                else {
                    //对比新旧映射关系列表 不存在的删除 存在的保留
                    RolePermission_EqualityCompare _comparer = new RolePermission_EqualityCompare();
                    List<RolePermission> _createList = _newRolePermissionList.Except(_oldRolePermissionList,  _comparer).ToList();
                    List<RolePermission> _deleteList = _oldRolePermissionList.Except(_newRolePermissionList, _comparer).ToList();

                    _createList.ForEach(x =>
                    {
                        //更新缓存
                        _IRolePermissionBLL.UpdateCache("RolePermission", x.Id, x);

                        //异步更新数据库
                        _jobs.Enqueue(() => _IRolePermissionBLL.Add(x));
                    });

                    _deleteList.ForEach(x =>
                    {
                        x.Delflag = EnumType.DelflagType.已删除;

                        //更新缓存
                        _IRolePermissionBLL.UpdateCache("RolePermission", x.Id, x);

                        //异步更新数据库
                        _jobs.Enqueue(() => _IRolePermissionBLL.Update(x));
                    });
                }

                return Json(new { Success = true, SuccessModel = "生成角色权限映射关系成功！" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ee)
            {
                return Json(new { Success = false, ErrorModel = "生成角色权限映射关系失败！", ErrorMessage = ee.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
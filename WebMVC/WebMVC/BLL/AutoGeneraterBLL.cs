using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebMVC.Attributes;
using WebMVC.Common;

namespace WebMVC.BLL
{
    public class AutoGeneraterBLL
    {
        private string AssemblyName = "WebMVC";

        public string ControllerList() {
            List<Type> controllerTypes = new List<Type>();
            
            var assembly = Assembly.Load(AssemblyName);
            controllerTypes.AddRange(assembly.GetTypes().Where(type => type.Name.Contains("Controller") == true));

            List<object> controllerItems = new List<object>();

            foreach (var controller in controllerTypes)
            {
                controllerItems.Add(new { Text = controller.Name, Value = controller.Name });
            }
            return JsonHelper.SerializeObject(controllerItems);
        }

        public string ActionList(string controllerName)
        {
            //加载程序集 
            var assembly = Assembly.Load(AssemblyName);
            //获取对应controller类型
            var controller = assembly.GetTypes().Where(type => type.Name == controllerName && type.Name != "AccountController").FirstOrDefault();
            List<object> actionItems = new List<object>();
            //获取Controller下属性是HttpPost的Method
            var actions = controller.GetMethods().Where(m => m.IsDefined(typeof(Description), false));
            foreach (var actionItem in actions)
            {
                actionItems.Add(new{ Text = actionItem.Name, Value = actionItem.Name });
            }
            return JsonHelper.SerializeObject(actionItems);
        }
    }
}
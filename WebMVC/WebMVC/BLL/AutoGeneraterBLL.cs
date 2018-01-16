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

        public List<string> ControllerList() {
            List<Type> controllerTypes = new List<Type>();

            //加载程序集 
            var assembly = Assembly.Load(AssemblyName);
            controllerTypes.AddRange(assembly.GetTypes().Where(type => type.Name.Contains("Controller") == true));

            List<string> controllerItems = new List<string>();

            controllerTypes.ForEach(x =>
            {
                controllerItems.Add(x.Name);
            });

            return controllerItems;
        }

        public List<string> ActionList(string ControllerName)
        {
            //加载程序集 
            var assembly = Assembly.Load(AssemblyName);
            //获取对应controller类型
            var controller = assembly.GetTypes().Where(type => type.Name == ControllerName && type.Name != "AccountController").FirstOrDefault();
           
            if(controller != null) {
                List<string> actionItems = new List<string>();
                //获取Controller下属性是Description的Method
                var actions = controller.GetMethods().Where(m => m.IsDefined(typeof(AuthAttribute), false));
                foreach (var actionItem in actions)
                {
                    actionItems.Add(actionItem.Name);
                }
                return actionItems;
            }

            return null;
        }
    }
}
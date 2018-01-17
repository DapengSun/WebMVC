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

        /// <summary>
        /// 获取Controller列表
        /// </summary>
        /// <returns></returns>
        public List<KeyValuePair<string, string>> ControllerList() {
            List<Type> controllerTypes = new List<Type>();

            //加载程序集 
            var assembly = Assembly.Load(AssemblyName);
            controllerTypes.AddRange(assembly.GetTypes().Where(type => type.Name.Contains("Controller") == true));

            List<KeyValuePair<string, string>> controllerItems = new List<KeyValuePair<string, string>>();

            controllerTypes.ForEach(x =>
            {
                //获取Controller自定义信息
                DescriptionAttribute _descriptionAttribute = GetControllerAttribute<DescriptionAttribute>(x);

                controllerItems.Add(new KeyValuePair<string, string>( x.Name, _descriptionAttribute == null ? "" : _descriptionAttribute.DescptionName ));
            });

            return controllerItems;
        }

        /// <summary>
        /// 获取Action列表
        /// </summary>
        /// <param name="ControllerName"></param>
        /// <returns></returns>
        public List<KeyValuePair<string, string>> ActionList(string ControllerName)
        {
            //加载程序集 
            var assembly = Assembly.Load(AssemblyName);
            //获取对应controller类型
            var controller = assembly.GetTypes().Where(type => type.Name == ControllerName && type.Name != "AccountController").FirstOrDefault();
           
            if(controller != null) {
                List<KeyValuePair<string, string>> actionItems = new List<KeyValuePair<string,string>>();

                //获取Controller下属性是Description的Method
                var actions = controller.GetMethods().Where(m => m.IsDefined(typeof(AuthAttribute), false));
                foreach (var actionItem in actions)
                {
                    //获取Action自定义信息
                    DescriptionAttribute _descriptionAttribute = GetActionAttribute<DescriptionAttribute>(actionItem);

                    actionItems.Add(new KeyValuePair<string,string>(actionItem.Name, _descriptionAttribute == null ? "" : _descriptionAttribute.DescptionName ));
                }
                return actionItems;
            }

            return null;
        }

        /// <summary>
        /// 获取Controller自定义属性
        /// </summary>
        /// <typeparam name="T">自定义属性类型</typeparam>
        /// <param name="_type"></param>
        /// <returns></returns>
        public T GetControllerAttribute<T>(Type _type) {
            var _controllerAttribute = (T)(_type.GetCustomAttributes(false).FirstOrDefault(i => i is T));
            return _controllerAttribute;
        }

        /// <summary>
        /// 获取Action自定义属性
        /// </summary>
        /// <typeparam name="T">自定义属性类型</typeparam>
        /// <param name="_type"></param>
        /// <returns></returns>
        public T GetActionAttribute<T>(MethodInfo _methodInfo) {
            var _actionAttribute = (T)(_methodInfo.GetCustomAttributes(false).FirstOrDefault(i => i is T));
            return _actionAttribute;
        }
    }
}
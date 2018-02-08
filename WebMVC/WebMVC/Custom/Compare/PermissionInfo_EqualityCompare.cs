using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Models;

namespace WebMVC.Custom.Compare
{
    public class PermissionInfo_EqualityCompare : IEqualityComparer<PermissionInfo>
    {
        public bool Equals(PermissionInfo x, PermissionInfo y)
        {
            if (x.Controller == y.Controller && x.Action == y.Action && x.ActionDescription == y.ActionDescription && x.ControllerDescription == y.ControllerDescription)
            {
                return true;
            }
            else {
                return false;
            }
        }

        public int GetHashCode(PermissionInfo obj)
        {
            string key = obj.Controller + obj.Action;
            return key.GetHashCode();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Models;

namespace WebMVC.Custom.Compare
{
    public class RolePermission_EqualityCompare : IEqualityComparer<RolePermission>
    {
        public bool Equals(RolePermission x, RolePermission y)
        {
            if (x.RoleId == y.RoleId && x.PermissionId == y.PermissionId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(RolePermission obj)
        {
            string key = obj.RoleId + obj.PermissionId;
            return key.GetHashCode();
            //throw new NotImplementedException();
        }
    }
}
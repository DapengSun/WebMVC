using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.DBContext;
using WebMVC.Models;

namespace WebMVC.DAL
{
    public class RolePermissionDAL
    {
        public bool Add(RolePermission _RolePermission)
        {
            using (var context = new LocalDBContext())
            {
                context.RolePermission.Add(_RolePermission);
                context.SaveChanges();
                return true;
            }
        }

        public bool Update(RolePermission _RolePermission)
        {
            using (var context = new LocalDBContext())
            {
                context.RolePermission.Attach(_RolePermission);
                context.Entry(_RolePermission).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        public bool Delete(RolePermission _RolePermission)
        {
            using (var context = new LocalDBContext())
            {
                context.RolePermission.Attach(_RolePermission);
                context.Entry(_RolePermission).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        public RolePermission Get(string Id)
        {
            using (var context = new LocalDBContext())
            {
                return context.RolePermission.Where(i => i.Id == Id && i.Delflag == EnumType.DelflagType.正常).FirstOrDefault();
            }
        }

        public List<RolePermission> GetAll()
        {
            using (var context = new LocalDBContext())
            {
                return context.RolePermission.Where(x => x.Delflag == EnumType.DelflagType.正常).ToList();
            }
        }
    }
}
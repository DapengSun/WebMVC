using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.DBContext;
using WebMVC.Models;

namespace WebMVC.DAL
{
    public class PermissionInfoDAL
    {
        public bool Add(PermissionInfo _PermissionInfo)
        {
            using (var context = new LocalDBContext())
            {
                context.PermissionInfo.Add(_PermissionInfo);
                context.SaveChanges();
                return true;
            }
        }

        public bool Update(PermissionInfo _PermissionInfo)
        {
            using (var context = new LocalDBContext())
            {
                context.PermissionInfo.Attach(_PermissionInfo);
                context.Entry(_PermissionInfo).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        public bool Delete(PermissionInfo _PermissionInfo)
        {
            using (var context = new LocalDBContext())
            {
                context.PermissionInfo.Attach(_PermissionInfo);
                context.Entry(_PermissionInfo).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        public PermissionInfo Get(string Id)
        {
            using (var context = new LocalDBContext())
            {
                return context.PermissionInfo.Where(i => i.Id == Id && i.Delflag == EnumType.DelflagType.正常).FirstOrDefault();
            }
        }

        public List<PermissionInfo> GetAll()
        {
            using (var context = new LocalDBContext())
            {
                return context.PermissionInfo.Where(x=>x.Delflag == EnumType.DelflagType.正常).ToList();
            }
        }
    }
}
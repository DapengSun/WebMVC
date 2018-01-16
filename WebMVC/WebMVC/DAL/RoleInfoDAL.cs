using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.DBContext;
using WebMVC.Models;

namespace WebMVC.DAL
{
    public class RoleInfoDAL
    {
        public bool Add(RoleInfo _RoleInfo)
        {
            using (var context = new LocalDBContext())
            {
                context.RoleInfo.Add(_RoleInfo);
                context.SaveChanges();
                return true;
            }
        }

        public bool Update(RoleInfo _RoleInfo)
        {
            using (var context = new LocalDBContext())
            {
                context.RoleInfo.Attach(_RoleInfo);
                context.Entry(_RoleInfo).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        public bool Delete(RoleInfo _RoleInfo)
        {
            using (var context = new LocalDBContext())
            {
                context.RoleInfo.Attach(_RoleInfo);
                context.Entry(_RoleInfo).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        public RoleInfo Get(string Id)
        {
            using (var context = new LocalDBContext())
            {
                return context.RoleInfo.Where(i => i.Id == Id && i.Delflag == EnumType.DelflagType.正常).FirstOrDefault();
            }
        }

        public List<RoleInfo> GetAll()
        {
            using (var context = new LocalDBContext())
            {
                return context.RoleInfo.Where(x => x.Delflag == EnumType.DelflagType.正常).ToList();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.DBContext;
using WebMVC.Models;

namespace WebMVC.DAL
{
    public class UserProfileDAL
    {
        public bool Add(UserProfile _UserProfile) {
            using (var context = new LocalDBContext()) {
                context.UserProfile.Add(_UserProfile);
                context.SaveChanges();
                return true;
            }
        }

        public bool Update(UserProfile _UserProfile)
        {
            using (var context = new LocalDBContext())
            {
                context.UserProfile.Attach(_UserProfile);
                context.Entry(_UserProfile).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        public bool Delete(UserProfile _UserProfile)
        {
            using (var context = new LocalDBContext())
            {
                context.UserProfile.Attach(_UserProfile);
                context.Entry(_UserProfile).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        public UserProfile Get(string Id)
        {
            using (var context = new LocalDBContext())
            {
                return context.UserProfile.Where(i => i.Id == Id && i.SysStatus == UserProfile.EnumSysType.正常).FirstOrDefault();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.DBContext;
using WebMVC.Models;

namespace WebMVC.DAL
{
    public class MainDAL
    {
        public bool Add(Statistics _Statistics) {
            using (var Context = new LocalDBContext()) {
                Context.Statistics.Add(_Statistics);
                Context.SaveChanges();
                return true;
            }
        }

        public bool Update(Statistics _Statistics)
        {
            using (var Context = new LocalDBContext())
            {
                Context.Statistics.Attach(_Statistics);
                Context.Entry(_Statistics).State = System.Data.Entity.EntityState.Modified;
                Context.SaveChanges();
                return true;
            }
        }

        public Statistics Get()
        {
            using (var Context = new LocalDBContext())
            {
                return Context.Statistics.FirstOrDefault();
            }
        }
    }
}
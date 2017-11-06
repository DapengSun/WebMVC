using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebMVC.DBContext;
using WebMVC.Models;

namespace WebMVC.DAL
{
    public class MainDAL
    {
        public bool AddPV(Statistics _Statistics) {
            using (var Context = new LocalDBContext()) {
                Context.Statistics.Add(_Statistics);
                Context.SaveChanges();
                return true;
            }
        }

        public bool UpdatePV(Statistics _Statistics)
        {
            using (var Context = new LocalDBContext())
            {
                Context.Statistics.Attach(_Statistics);
                Context.Entry(_Statistics).State = System.Data.Entity.EntityState.Modified;
                Context.SaveChanges();
                return true;
            }
        }

        public Statistics GetPV()
        {
            using (var Context = new LocalDBContext())
            {
                return Context.Statistics.FirstOrDefault();
            }
        }

        public List<BTC_Price_Statistics> GetBTCPrice()
        {
            using (var Context = new LocalDBContext()) {
                return Context.BTC_Price_Statistics.OrderBy(i=>i.CDate).ToList();  
            }
        }
    }
}
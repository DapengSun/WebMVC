using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.DBContext;
using WebMVC.Models;

namespace WebMVC.DAL
{
    public class HouseInfoDAL
    {
        public List<houseinfo> Get(string HouseArea) {
            using (var dbContext = new LocalDBContext())
            {
                return dbContext.houseinfo.Where(i => i.HouseArea.Contains(HouseArea)).ToList();
            }
        }
    }
}
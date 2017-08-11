using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.DAL;
using WebMVC.Models;

namespace WebMVC.BLL
{
    public class HouseInfoBLL
    {
        public HouseInfoDAL _houseInfoDal = new HouseInfoDAL();

        public List<houseinfo> Get(string HouseArea) {
            return _houseInfoDal.Get(HouseArea);
        }
    }
}
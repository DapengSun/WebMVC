using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.DAL;
using WebMVC.Models;

namespace WebMVC.BLL
{
    public class UserProfileBLL
    {
        public UserProfileDAL _Dal = new UserProfileDAL();

        public bool Add(UserProfile _UserProfile)
        {
            return _Dal.Add(_UserProfile);
        }

        public bool Update(UserProfile _UserProfile)
        {
            return _Dal.Update(_UserProfile);
        }

        public bool Delete(UserProfile _UserProfile)
        {
            return _Dal.Delete(_UserProfile);
        }

        public UserProfile Get(string Id)
        {
            return _Dal.Get(Id);
        }
    }
}
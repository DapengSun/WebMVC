using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebMVC.Common;
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

        public UserProfile Get(string Username,string Password)
        {
            return _Dal.Get(Username, Password);
        }

        public string Login(string Username,string Password) {
            UserProfile _UserProfile = Get(Username, FormsAuthentication.HashPasswordForStoringInConfigFile(Password,"MD5"));
            if (_UserProfile != null)
            {
                string _SessionId = Guid.NewGuid().ToString().Replace("-","");
                string _UserProfileJson = Newtonsoft.Json.JsonConvert.SerializeObject(_UserProfile);

                RedisHelper.ItemSet<string>(_SessionId, _UserProfileJson);
                return _SessionId;
            }
            else {
                return null;
            }
        }
    }
}
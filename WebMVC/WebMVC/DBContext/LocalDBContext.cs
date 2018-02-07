using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebMVC.Models;

namespace WebMVC.DBContext
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class LocalDBContext: DbContext
    {
        public LocalDBContext() : base("name=MysqlConnection") { }

        public DbSet<FilmInfo> FilmInfo { get; set; }

        public DbSet<CodeFirstTestModel> CodeFirstTestModel { get; set; }

        public DbSet<houseinfo> houseinfo { get; set; }

        public DbSet<UserProfile> UserProfile { get; set; }

        public DbSet<Statistics> Statistics { get; set; }

        public DbSet<BTC_Price> BTC_Price { get; set; }
        
        public DbSet<BTC_Price_Statistics> BTC_Price_Statistics { get; set; }

        public DbSet<RoleInfo> RoleInfo { get; set; }

        public DbSet<RolePermission> RolePermission { get; set; }

        public DbSet<PermissionInfo> PermissionInfo { get; set; }

        //public DbSet<TestClass> TestClass { get; set; }
    }
}
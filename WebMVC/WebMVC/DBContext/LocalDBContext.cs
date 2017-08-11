using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebMVC.Models;

namespace WebMVC.DBContext
{
    [DbConfigurationType(typeof(MySqlConfiguration))]
    public class LocalDBContext: DbContext
    {
        public LocalDBContext() : base("name=MysqlConnection") { }

        public DbSet<FilmInfo> FilmInfo { get; set; }

        public DbSet<CodeFirstTestModel> CodeFirstTestModel { get; set; }

        public DbSet<houseinfo> houseinfo { get; set; }

    }
}
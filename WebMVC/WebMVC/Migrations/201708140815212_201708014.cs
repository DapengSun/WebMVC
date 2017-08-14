namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201708014 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FilmInfoes", "newtest", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FilmInfoes", "newtest");
        }
    }
}

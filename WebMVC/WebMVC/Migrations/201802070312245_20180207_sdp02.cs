namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180207_sdp02 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BTC_Price", "_Id");
            DropColumn("dbo.BTC_Price_Statistics", "_Id");
            DropColumn("dbo.CodeFirstTestModel", "_id");
            DropColumn("dbo.FilmInfoes", "_id");
            DropColumn("dbo.PermissionInfo", "_Id");
            DropColumn("dbo.RoleInfo", "_Id");
            DropColumn("dbo.Statistics", "_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Statistics", "_Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.RoleInfo", "_Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.PermissionInfo", "_Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.FilmInfoes", "_id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.CodeFirstTestModel", "_id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.BTC_Price_Statistics", "_Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.BTC_Price", "_Id", c => c.Int(nullable: false, identity: true));
        }
    }
}

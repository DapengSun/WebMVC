namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180309_sdp02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LogInfoes", "Level", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LogInfoes", "Level");
        }
    }
}

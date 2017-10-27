namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20171027_sdp03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "SysStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "SysStatus");
        }
    }
}

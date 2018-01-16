namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180112_sdp01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "RoleId", c => c.String(unicode: false));
            AddColumn("dbo.UserProfiles", "RoleName", c => c.String(unicode: false));
            DropColumn("dbo.UserProfiles", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "Role", c => c.Int(nullable: false));
            DropColumn("dbo.UserProfiles", "RoleName");
            DropColumn("dbo.UserProfiles", "RoleId");
        }
    }
}

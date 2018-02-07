namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180206_sdp08 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RolePermission", "NumId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RolePermission", "NumId", c => c.Int(nullable: false));
        }
    }
}

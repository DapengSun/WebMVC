namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180206_sdp05 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RolePermission", "NumId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RolePermission", "NumId");
        }
    }
}

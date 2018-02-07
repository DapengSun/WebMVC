namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180206_sdp06 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RolePermission", "_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RolePermission", "_Id", c => c.Int(nullable: false, identity: true));
        }
    }
}

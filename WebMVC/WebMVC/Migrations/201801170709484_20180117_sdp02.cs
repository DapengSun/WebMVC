namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180117_sdp02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RolePermission", "Controller", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AddColumn("dbo.RolePermission", "Action", c => c.String(maxLength: 50, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RolePermission", "Action");
            DropColumn("dbo.RolePermission", "Controller");
        }
    }
}

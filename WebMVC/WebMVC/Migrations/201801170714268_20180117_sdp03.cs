namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180117_sdp03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RolePermission", "ControllerDescription", c => c.String(maxLength: 150, storeType: "nvarchar"));
            AddColumn("dbo.RolePermission", "ActionDescription", c => c.String(maxLength: 150, storeType: "nvarchar"));
            DropColumn("dbo.RolePermission", "PermissionName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RolePermission", "PermissionName", c => c.String(maxLength: 50, storeType: "nvarchar"));
            DropColumn("dbo.RolePermission", "ActionDescription");
            DropColumn("dbo.RolePermission", "ControllerDescription");
        }
    }
}

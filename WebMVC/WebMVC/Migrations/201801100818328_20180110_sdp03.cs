namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180110_sdp03 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PermissionInfo",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        _Id = c.Int(nullable: false, identity: true),
                        Controller = c.String(maxLength: 50, storeType: "nvarchar"),
                        Action = c.String(maxLength: 50, storeType: "nvarchar"),
                        ControllerDescription = c.String(maxLength: 150, storeType: "nvarchar"),
                        ActionDescription = c.String(maxLength: 150, storeType: "nvarchar"),
                        CDate = c.DateTime(nullable: false, precision: 0),
                        Delflag = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleInfo",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        _Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50, storeType: "nvarchar"),
                        Description = c.String(maxLength: 50, storeType: "nvarchar"),
                        Delflag = c.Int(nullable: false),
                        CDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RolePermission",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        _Id = c.Int(nullable: false, identity: true),
                        RoleId = c.String(maxLength: 50, storeType: "nvarchar"),
                        PermissionId = c.String(maxLength: 50, storeType: "nvarchar"),
                        RoleName = c.String(maxLength: 50, storeType: "nvarchar"),
                        PermissionName = c.String(maxLength: 50, storeType: "nvarchar"),
                        Delflag = c.Int(nullable: false),
                        CDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RolePermission");
            DropTable("dbo.RoleInfo");
            DropTable("dbo.PermissionInfo");
        }
    }
}

namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180117_sdp01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RolePermission", "UsedType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RolePermission", "UsedType");
        }
    }
}

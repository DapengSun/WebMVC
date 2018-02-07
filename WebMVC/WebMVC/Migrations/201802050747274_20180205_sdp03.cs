namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180205_sdp03 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RolePermission", "tt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RolePermission", "tt", c => c.String(maxLength: 150, storeType: "nvarchar"));
        }
    }
}

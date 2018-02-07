namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180205_sdp02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RolePermission", "tt", c => c.String(maxLength: 150, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RolePermission", "tt");
        }
    }
}

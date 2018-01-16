namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180112_sdp02 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfiles", "RoleId", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.UserProfiles", "RoleName", c => c.String(maxLength: 100, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfiles", "RoleName", c => c.String(unicode: false));
            AlterColumn("dbo.UserProfiles", "RoleId", c => c.String(unicode: false));
        }
    }
}

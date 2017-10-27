namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20171027_sdp04 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "FirstName", c => c.String(maxLength: 30, storeType: "nvarchar"));
            AddColumn("dbo.UserProfiles", "LastName", c => c.String(maxLength: 30, storeType: "nvarchar"));
            DropColumn("dbo.UserProfiles", "NikeName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "NikeName", c => c.String(maxLength: 30, storeType: "nvarchar"));
            DropColumn("dbo.UserProfiles", "LastName");
            DropColumn("dbo.UserProfiles", "FirstName");
        }
    }
}

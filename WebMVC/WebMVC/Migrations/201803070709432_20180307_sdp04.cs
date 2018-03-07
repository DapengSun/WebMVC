namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180307_sdp04 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "City", c => c.String(maxLength: 100, storeType: "nvarchar"));
            AddColumn("dbo.UserProfiles", "Country", c => c.String(maxLength: 100, storeType: "nvarchar"));
            AddColumn("dbo.UserProfiles", "PostalCode", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AddColumn("dbo.UserProfiles", "PersonalitySignature", c => c.String(maxLength: 500, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "PersonalitySignature");
            DropColumn("dbo.UserProfiles", "PostalCode");
            DropColumn("dbo.UserProfiles", "Country");
            DropColumn("dbo.UserProfiles", "City");
        }
    }
}

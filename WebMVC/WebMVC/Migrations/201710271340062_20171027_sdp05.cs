namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20171027_sdp05 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "Describe", c => c.String(maxLength: 500, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "Describe");
        }
    }
}

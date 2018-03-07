namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180307_sdp01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "Company", c => c.String(maxLength: 100, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "Company");
        }
    }
}

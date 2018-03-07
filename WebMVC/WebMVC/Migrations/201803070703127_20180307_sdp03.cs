namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180307_sdp03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "Address", c => c.String(maxLength: 200, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "Address");
        }
    }
}

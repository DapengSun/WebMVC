namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180309_sdp05 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LogInfoes", "AccountId", c => c.String(maxLength: 50, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LogInfoes", "AccountId", c => c.String(maxLength: 30, storeType: "nvarchar"));
        }
    }
}

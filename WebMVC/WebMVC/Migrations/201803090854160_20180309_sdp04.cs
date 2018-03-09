namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180309_sdp04 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LogInfoes", "AccountId", c => c.String(maxLength: 30, storeType: "nvarchar"));
            AlterColumn("dbo.LogInfoes", "AccountName", c => c.String(maxLength: 50, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LogInfoes", "AccountName", c => c.String(unicode: false));
            AlterColumn("dbo.LogInfoes", "AccountId", c => c.String(unicode: false));
        }
    }
}

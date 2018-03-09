namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180309_sdp03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LogInfoes", "AccountId", c => c.String(unicode: false));
            AddColumn("dbo.LogInfoes", "AccountName", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LogInfoes", "AccountName");
            DropColumn("dbo.LogInfoes", "AccountId");
        }
    }
}

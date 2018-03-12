namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180312_sdp01 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LogInfoes", "Content", c => c.String(maxLength: 500, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LogInfoes", "Content", c => c.String(unicode: false));
        }
    }
}

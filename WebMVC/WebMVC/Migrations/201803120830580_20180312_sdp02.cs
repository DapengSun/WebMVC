namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180312_sdp02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogsInfo", "BlogAbstarct", c => c.String(maxLength: 1000, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlogsInfo", "BlogAbstarct");
        }
    }
}

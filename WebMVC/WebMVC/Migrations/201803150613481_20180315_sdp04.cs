namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180315_sdp04 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogsInfo", "BlogAuthorId", c => c.String(maxLength: 200, storeType: "nvarchar"));
            AddColumn("dbo.BlogsInfo", "BlogAuthorName", c => c.String(maxLength: 200, storeType: "nvarchar"));
            DropColumn("dbo.BlogsInfo", "BlogAuthor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlogsInfo", "BlogAuthor", c => c.String(maxLength: 200, storeType: "nvarchar"));
            DropColumn("dbo.BlogsInfo", "BlogAuthorName");
            DropColumn("dbo.BlogsInfo", "BlogAuthorId");
        }
    }
}

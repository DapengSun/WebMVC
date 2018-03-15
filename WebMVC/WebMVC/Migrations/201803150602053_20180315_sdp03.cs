namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180315_sdp03 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BlogsInfo", "BlogSurfacePlot");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlogsInfo", "BlogSurfacePlot", c => c.String(maxLength: 50, storeType: "nvarchar"));
        }
    }
}

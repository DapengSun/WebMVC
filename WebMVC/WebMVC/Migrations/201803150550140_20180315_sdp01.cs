namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180315_sdp01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogsInfo", "BlogSurfacePlot", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlogsInfo", "BlogSurfacePlot");
        }
    }
}

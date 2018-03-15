namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180315_sdp02 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BlogsInfo", "BlogSurfacePlot", c => c.String(maxLength: 50, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BlogsInfo", "BlogSurfacePlot", c => c.String(unicode: false));
        }
    }
}

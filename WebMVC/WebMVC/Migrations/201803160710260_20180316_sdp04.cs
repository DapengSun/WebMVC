namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180316_sdp04 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductInfoes", "version", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductInfoes", "version", c => c.Binary());
        }
    }
}

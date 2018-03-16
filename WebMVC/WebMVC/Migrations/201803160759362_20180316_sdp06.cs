namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180316_sdp06 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProductInfoes", "Version");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductInfoes", "Version", c => c.String(unicode: false));
        }
    }
}

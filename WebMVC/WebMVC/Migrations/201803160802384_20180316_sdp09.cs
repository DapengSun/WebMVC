namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180316_sdp09 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductInfoes", "StoreNum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductInfoes", "StoreNum");
        }
    }
}
